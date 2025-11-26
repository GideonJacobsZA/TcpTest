using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using VxGlobals;
using System.Diagnostics;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace TcpTest
{
    public partial class Main : Form
    {
        public delegate void dOnScan(string aData);
        public static event dOnScan OnScan;

        public Dictionary<string, TcpClient> fTCPClients = new Dictionary<string, TcpClient>();
        public Dictionary<string, string> fClientData = new Dictionary<string, string>();

        private string fLastException = "";

        public string fAddress { get { return GetAddress(); } }
        private string GetAddress()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(() => GetAddress()));
            }
            else
            {
                return tbAddress.Text;
            }
        }

        public int fPort { get { return GetPort(); } }
        private int GetPort()
        {
            if (InvokeRequired)
            {
                return (int)Invoke(new Func<int>(() => GetPort()));
            }
            else
            {
                return Convert.ToInt32(tbPort.Text);
            }
        }

        public int fClientPort { get { return GetClientPort(); } }
        private int GetClientPort()
        {
            if (InvokeRequired)
            {
                return (int)Invoke(new Func<int>(() => GetClientPort()));
            }
            else
            {
                return Convert.ToInt32(tbClientPort.Text);
            }
        }

        public int fConnectionTimeOut = 30000;
        public int fReconnectDelay = 1000;
        public int fBufferSize = 6048;

        private byte fAutoReplyWithCRCHeeaderData = 0x02;
        private byte fAutoReplyData = 0x01;
        
        private bool fAutoReply = true;
        private bool fAutoReplyWithCRC = false;
        private bool fAutoReplyWithCRCHeader = true;
        private bool fBroadCastClientData = true;
        private bool fWaitForReply = false;

        private volatile bool _Continue = true;

        public Main()
        {
            InitializeComponent();

            tbPort.Text = "60522";
        }

        ~Main()
        {
            _Continue = false;
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Continue = false;
        }

        private void Log(string aMessage, eLogType aLogType)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => Log(aMessage, aLogType)));
            }
            else
            {
                rtbLog.AppendText(aMessage + "\r\n");
            }
        }

        private void SetButton(Button aButton, bool aEnabled)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => SetButton(aButton, aEnabled)));
            }
            else
            {
                aButton.Enabled = aEnabled;
            }
        }

        void _DataReceived(string aDataReceived)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new MethodInvoker(() => rtbLog.AppendText(aDataReceived + "\n")));
            }
            else
            {
                rtbLog.AppendText(aDataReceived + "\n");
            }
        }

        public void RunningThreadTCP()
        {
            try
            {
                Log("Generic Scanner Interface <" + fAddress + "> TCP DEVICE has started its thread", eLogType.Activity);

                while (_Continue)
                {
                    using (TcpClient vTcpClient = new TcpClient())
                    {
                        vTcpClient.Connect(fAddress, fPort);

                        using (NetworkStream stream = vTcpClient.GetStream())
                        {
                            stream.WriteByte(255);

                            while (_Continue && vTcpClient.Connected)
                            {
                                Thread.Sleep(10);

                                try
                                {
                                    Byte[] vData = new Byte[fBufferSize];
                                    if (fConnectionTimeOut > 0)
                                    {
                                        stream.ReadTimeout = fConnectionTimeOut;
                                    }
                                    Int32 vBytes = stream.Read(vData, 0, vData.Length);
                                    if (vBytes == 0)
                                    {
                                        Exception eX = new Exception();
                                        throw eX;
                                    }

                                    byte[] vDataLean = new byte[vBytes];
                                    Array.Copy(vData, 0, vDataLean, 0, vBytes);

                                    string vDataReceived = TVxConvertors.ByteArrayToHexString(vDataLean, false, true, true);
                                    vDataReceived = vDataReceived.Replace("\r\n", "");

                                    string vWithbrackets = TVxConvertors.ByteArrayToHexString(vDataLean, true, true, true);

                                    Log("<" + fAddress + "> received raw data < " + vDataReceived + " >\r\n<"+ vWithbrackets + "> \r\n", eLogType.Info);

                                    Thread.Sleep(25);

                                    if (fAutoReply)
                                    {
                                        try
                                        {
                                            if (fAutoReplyWithCRC)
                                            {
                                                if (fAutoReplyWithCRCHeader)
                                                {
                                                    vTcpClient.Client.Send(new byte[3] { fAutoReplyWithCRCHeeaderData, vDataLean[vDataLean.Length - 2], vDataLean[vDataLean.Length - 1] });
                                                }
                                                else
                                                {
                                                    vTcpClient.Client.Send(new byte[2] { vDataLean[vDataLean.Length - 2], vDataLean[vDataLean.Length - 1] });
                                                }
                                            }
                                            else
                                            {
                                                vTcpClient.Client.Send(new byte[1] { fAutoReplyData });
                                            }
                                            
                                        }
                                        catch (Exception eX)
                                        {
                                            Log("Exception sending auto reply to <" + fAddress + "> <<" + eX.Message + ">> \r\n", eLogType.Info);
                                        }
                                    }

                                    ReceivedData(fAddress, vData);
                                }
                                catch (Exception eX)
                                {
                                    if (eX.Message == fLastException)
                                    {
                                        continue;
                                    }
                                    fLastException = eX.Message;

                                    List<string> vIgnoreExceptions = new List<string>() { "Unable to read".ToUpper(), "Connection timeout".ToUpper() };
                                    if (vIgnoreExceptions.Where(p => eX.Message.ToUpper().IndexOf(p.ToUpper()) >= 0).ToList().Count > 0)
                                    {
                                        continue;
                                    }

                                    Log("Exception in Generic Scanner Interface  RunningThreadTCP - Read Data <<" + eX.Message + ">>", eLogType.Exception);

                                }
                            }//inner while continue
                        }//using Network Stream
                    }//using TcpClient
                }//end while continue
            }
            catch (Exception eX)
            {
                if (eX.Message != fLastException)
                {
                    fLastException = eX.Message;
                    Log("Exception in Generic Scanner Interface  RunningThreadTCP <<" + eX.Message + ">>", eLogType.Exception);
                }
            }
            finally
            {
                if (fReconnectDelay > 0)
                {
                    Thread.Sleep(fReconnectDelay);
                }

                Thread vTcpListenThread = new Thread(() => RunningThreadTCP());
                vTcpListenThread.Priority = ThreadPriority.BelowNormal;
                vTcpListenThread.IsBackground = true;
                vTcpListenThread.Start();
            }
        }

        public void RunningThreadTCPServer(int aPort)
        {
            try
            {
                while (_Continue)
                {
                    TcpListener vTcpListener = new TcpListener(IPAddress.Any, aPort);

                    TcpClient vClient;
                    vTcpListener.Start();

                    Log("RunningThreadTCP STARTED", eLogType.Exception);

                    while (_Continue) // Add your exit flag here
                    {
                        try
                        {
                            vClient = vTcpListener.AcceptTcpClient();
                            ThreadPool.QueueUserWorkItem(ClientThread2, vClient);
                            Thread.Sleep(10);
                        }
                        catch (Exception eX)
                        {
                            if (eX.Message != fLastException)
                            {
                                fLastException = eX.Message;
                                Log("Exception RunningThreadTCP-AcceptTcpClient <<" + eX.Message + ">>", eLogType.Exception);
                            }
                        }
                    }
                }//end while continue

                SetButton(btnStart, true);
                Log("RunningThreadTCP STOPPED", eLogType.Exception);
            }
            catch (Exception eX)
            {
                if (eX.Message != fLastException)
                {
                    fLastException = eX.Message;
                    Log("Exception RunningThreadTCP <<" + eX.Message + ">>", eLogType.Exception);
                }
            }
            finally
            {
                if (_Continue)
                {
                    if (fReconnectDelay > 0)
                    {
                        Thread.Sleep(fReconnectDelay);
                    }

                    Thread vTcpListenThread = new Thread(() => RunningThreadTCPServer(aPort));
                    vTcpListenThread.Priority = ThreadPriority.BelowNormal;
                    vTcpListenThread.IsBackground = true;
                    vTcpListenThread.Start();
                }
            }
        }

        private void ClientThread2(object obj)
        {
            TcpClient vTcpClient = (TcpClient)obj;
            string vIP = vTcpClient.Client.RemoteEndPoint.ToString();
            fTCPClients.Add(vIP, vTcpClient);

            Log(" Client <" + vIP + "> Accepted", eLogType.Info);

            try
            {
                using (NetworkStream stream = vTcpClient.GetStream())
                {
                    if (vTcpClient.Connected)
                    {
                        Log(" Client <" + vIP + "> Connected", eLogType.Info);
                    }

                    while (_Continue)
                    {
                        Thread.Sleep(10);

                        if (vTcpClient == null || !vTcpClient.Connected)
                        {
                            Log(" Client <" + vIP + "> Disconnected", eLogType.Info);
                            fTCPClients.Remove(vIP);
                            break;
                        }

                        try
                        {
                            Byte[] vData = new Byte[fBufferSize];
                            if (fConnectionTimeOut > 0)
                            {
                                stream.ReadTimeout = fConnectionTimeOut;
                            }
                            Int32 vBytes = stream.Read(vData, 0, vData.Length);
                            if (vBytes == 0)
                            {
                                //Exception eX = new Exception();
                                //throw eX;
                                continue;
                            }

                            byte[] vDataLean = new byte[vBytes];
                            Array.Copy(vData, 0, vDataLean, 0, vBytes);

                            string vDataReceived = TVxConvertors.ByteArrayToHexString(vDataLean, false, true, true);
                            vDataReceived = vDataReceived.Replace("\r\n", "");

                            string vWithbrackets = TVxConvertors.ByteArrayToHexString(vDataLean, true, true, true);

                            Log("<" + fAddress + "> received raw data < " + vDataReceived + " >\r\n<" + vWithbrackets + "> \r\n", eLogType.Info);

                            Thread.Sleep(25);

                            if (fAutoReply)
                            {
                                #region Auto Reply and Wait for Reply

                                try
                                {
                                    if (fAutoReplyWithCRC)
                                    {
                                        if (fAutoReplyWithCRCHeader)
                                        {
                                            vTcpClient.Client.Send(new byte[3] { fAutoReplyWithCRCHeeaderData, vDataLean[vDataLean.Length - 2], vDataLean[vDataLean.Length - 1] });
                                            Log("<" + fAddress + "> sent CRC reply with header \r\n", eLogType.Info);
                                        }
                                        else
                                        {
                                            vTcpClient.Client.Send(new byte[2] { vDataLean[vDataLean.Length - 2], vDataLean[vDataLean.Length - 1] });
                                            Log("<" + fAddress + "> sent CRC reply without header \r\n", eLogType.Info);
                                        }
                                    }
                                    else
                                    {
                                        vTcpClient.Client.Send(new byte[1] { fAutoReplyData });

                                        Log("<" + fAddress + "> sent reply \r\n", eLogType.Info);
                                    }

                                }
                                catch (Exception eX)
                                {
                                    Log("Exception sending auto reply to <" + fAddress + "> <<" + eX.Message + ">> \r\n", eLogType.Info);
                                }

                                //wait for reply data in-line
                                if (fWaitForReply)
                                {
                                    try
                                    {
                                        vData = new Byte[fBufferSize];
                                        if (fConnectionTimeOut > 0)
                                        {
                                            stream.ReadTimeout = fConnectionTimeOut;
                                        }
                                        vBytes = stream.Read(vData, 0, vData.Length);
                                        if (vBytes == 0)
                                        {
                                            //Exception eX = new Exception();
                                            //throw eX;
                                            continue;
                                        }

                                        vDataLean = new byte[vBytes];
                                        Array.Copy(vData, 0, vDataLean, 0, vBytes);

                                        vDataReceived = TVxConvertors.ByteArrayToHexString(vDataLean, false, true, true);
                                        vDataReceived = vDataReceived.Replace("\r\n", "");

                                        vWithbrackets = TVxConvertors.ByteArrayToHexString(vDataLean, true, true, true);

                                        Log("<" + fAddress + "> received raw data < " + vDataReceived + " >\r\n<" + vWithbrackets + "> \r\n", eLogType.Info);

                                        Thread.Sleep(25);
                                    }
                                    catch
                                    {
                                    }
                                }

                                #endregion
                            }

                            if (vDataLean.Length > 0)
                            {
                                if (vDataLean[0] == 0x01) //valid galileo starting byte STX (Start of Text)
                                {
                                    //check if we have all the bytes
                                    if (TVxConvertors.GetBit(vDataLean[1], 0))
                                    {
                                        //the bit was 1,  indicating that there is unsent data

                                        //wait for more data here
                                        vData = new Byte[fBufferSize];
                                        if (fConnectionTimeOut > 0)
                                        {
                                            stream.ReadTimeout = fConnectionTimeOut;
                                        }
                                        vBytes = stream.Read(vData, 0, vData.Length);
                                        if (vBytes > 0)
                                        {
                                            //add bytes to current data

                                            byte[] vDataLean2 = new byte[vBytes];
                                            Array.Copy(vData, 0, vDataLean2, 0, vBytes);

                                            byte[] vNewArray = new byte[vDataLean.Length + vBytes];
                                            Array.Copy(vDataLean, 0, vNewArray, 0, vDataLean.Length);
                                            Array.Copy(vDataLean2, 0, vNewArray, vDataLean.Length, vDataLean2.Length);

                                            vDataLean = new byte[vNewArray.Length];

                                            Array.Copy(vNewArray, 0, vDataLean, 0, vNewArray.Length);
                                        }
                                    }


                                    ReceivedData(vIP, vDataLean);
                                }
                            }
                        }
                        catch (Exception eX)
                        {
                            if (eX.Message == fLastException)
                            {
                                continue;
                            }
                            fLastException = eX.Message;

                            List<string> vIgnoreExceptions = new List<string>() { "Unable to read".ToUpper(), "Connection timeout".ToUpper() };
                            if (vIgnoreExceptions.Where(p => eX.Message.ToUpper().IndexOf(p.ToUpper()) >= 0).ToList().Count > 0)
                            {
                                continue;
                            }

                            Log("Exception in Client <" + vIP + "> RunningThreadServerTCP - Read Data <<" + eX.Message + ">>", eLogType.Exception);

                        }
                    }//inner while continue
                }//using Network Stream
            }
            catch (Exception eX)
            {
                Log("Exception in Client <" + fAddress + "> RunningThreadServerTCP -  <<" + eX.Message + ">>", eLogType.Exception);
            }
            //vTcpClient.Close();
        }

        private void ReceivedData(string aAddress, byte[] aDataReceived)
        {
            try
            {
                //broadcast data to other clients
                Thread vThread = new Thread(() => ProcessGalileoData(aAddress, aDataReceived));
                vThread.IsBackground = true;
                vThread.Priority = ThreadPriority.BelowNormal;
                vThread.Start();

                if (fBroadCastClientData)
                {
                    List<TcpClient> vClients = fTCPClients.Values.Where(p => p.Client.RemoteEndPoint.ToString() != aAddress).ToList(); //all but this one
                    foreach (TcpClient vClient in vClients)
                    {
                        try
                        {
                            vClient.Client.Send(aDataReceived);
                        }
                        catch
                        { }
                    }
                }
            }
            catch (Exception eX)
            {
                Log("Exception in <" + fAddress + "> Broadcast <<" + eX.Message + ">>\r\n<<" + eX.StackTrace + ">>", eLogType.Exception);
            }

            try
            {
                //do something with data?

            }
            catch (Exception eX)
            {
                Log("Exception in <" + fAddress + ">ReceivedData <<" + eX.Message + ">>\r\n<<" + eX.StackTrace + ">>", eLogType.Exception);
            }
        }

        private void ProcessGalileoData(string aAddress, byte[] aDataReceived)
        {
            try
            {
                TGalileoProtocolRaw vProtocolRaw = new TGalileoProtocolRaw(aDataReceived);

                TGalileoProtocolClean vProtocolClean = new TGalileoProtocolClean(vProtocolRaw);

                if (vProtocolClean.Cmd_03_IMEI.IsEmpty())
                {
                    Log("Got some BAD data!!!", eLogType.Activity);
                    return;
                }

                Log("Got some GOOD data <"+ vProtocolClean.Cmd_03_IMEI + "> <"+ vProtocolClean.Cmd_90_First_iButton + ">", eLogType.Activity);
            }
            catch
            { 
            }
        }

        //SERVER START
        private void btnStart_Click(object sender, EventArgs e)
        {
            _Continue = true;

            SetButton(btnStart, false);

            Thread vRunningThread = new Thread(() => RunningThreadTCPServer(fPort));
            vRunningThread.Priority = ThreadPriority.BelowNormal;
            vRunningThread.IsBackground = true;
            vRunningThread.Start();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            _Continue = false;
        }

        //CLIENT SEND
        private void btnSendToClient_Click(object sender, EventArgs e)
        {
            try
            {
                //byte[] vBytesToSend = TVxConvertors.HexStringToByteArray(tbDataToSend.Text);
                //
                //byte[] vIMEI = new byte[vBytesToSend.Length - 2];
                //Array.Copy(vBytesToSend, 2, vIMEI, 0, vIMEI.Length);
                //
                //string vIMEIString = TVxConvertors.ByteArrayToString(vIMEI);

                byte[] vBytesToSend = TVxConvertors.HexStringToByteArray(tbDataToSend.Text);

                if (cbSendToServer.Checked)
                {
                    foreach (TcpClient vClient in fTCPClients.Values)
                    {
                        try
                        {
                            vClient.Client.Send(vBytesToSend);
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    try
                    {
                        using (TcpClient vTcpClient = new TcpClient())
                        {
                            vTcpClient.Connect(fAddress, fClientPort);

                            if (vTcpClient.Connected)
                            {
                                Log(" Client <" + fAddress + "> Connected to remote end point: " + vTcpClient.Client.RemoteEndPoint.ToString(), eLogType.Info);

                                Thread.Sleep(250);

                                using (NetworkStream stream = vTcpClient.GetStream())
                                {
                                    stream.Write(vBytesToSend, 0, vBytesToSend.Length);

                                    Log(" Client <" + fAddress + "> Sent Data: <" + tbDataToSend.Text + ">", eLogType.Info);

                                    Thread.Sleep(250);
                                }
                            }
                        }//disposing closes the tcp connection
                    }
                    catch (Exception eX)
                    {
                        Log("Exception in Client <" + fAddress + "> Sending Data To Client -  <<" + eX.Message + ">>", eLogType.Exception);
                    }
                }
            }
            catch
            {
            }
        }

        private void cbBroadCastClientData_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fBroadCastClientData = cbBroadCastClientData.Checked;
            }
            catch
            { 
            }
        }

        private void cbAutoReply_CheckedChanged(object sender, EventArgs e)
        {
            fAutoReply = cbAutoReply.Checked;
        }

        private void cbAutoReplyWithCRC_CheckedChanged(object sender, EventArgs e)
        {
            fAutoReplyWithCRC = cbAutoReplyWithCRC.Checked;
        }

        private void cbAutoReplyWithCRCHeader_CheckedChanged(object sender, EventArgs e)
        {
            fAutoReplyWithCRCHeader = cbAutoReplyWithCRCHeader.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbDataToSend_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
