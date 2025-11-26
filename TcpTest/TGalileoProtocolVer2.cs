using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TcpTest.Properties;
using VxGlobals;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TcpTest
{
    public class TGalileoProtocolClean
    {
        public byte STX;
        public string Length;                     //should be 294 for all of these

        public string Cmd_01_HWVersion;
        public string Cmd_02_FirmwareVersion;
        public string Cmd_03_IMEI;

        public string Cmd_20_Datetime;
        public string Cmd_30_COORDS;
        public string Satelites;
        public string Lat;
        public string Long;

        public string Cmd_33_Speed;
        public string Cmd_34_Altitude;

        public string Cmd_40_DeviceStatus;

        public string Cmd_45_Status_of_outputs;
        public string Cmd_46_Status_of_inputs;
        public string Cmd_50_Input_voltage_0;
        public string Cmd_51_Input_voltage_1;
        public string Cmd_52_Input_voltage_2;
        public string Cmd_53_Input_voltage_3;
        public string Cmd_54_Input_4_values;
        public string Cmd_55_Input_5_values;

        public string Cmd_90_First_iButton;
        
        public string Cmd_A0_CAN8BITR15;          // or the eighth byte in the procedure for receiving of prefix WA CAN-LOG
        public string Cmd_A1_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A2_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A3_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A4_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A5_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A6_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A7_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A8_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_A9_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_AA_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_AB_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_AC_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_AD_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_AE_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public string Cmd_AF_CAN8BITR30;

        public string Cmd_B0_CAN16BITR5;
        public string Cmd_B1_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B2_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B3_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B4_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B5_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B6_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B7_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B8_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public string Cmd_B9_CAN16BITR14;

        public string Cmd_C0_CAN_bus;             // and CAN-LOG data(CAN_A0). Fuel used by a vehicle from the date of manufacturing, l
        public string Cmd_C1_CAN_bus;             // and CAN-LOG data(CAN_A1). Fuel level, %; coolant temperature, ⁰C; Enginespeed, rpm.
        public string Cmd_C2_CAN_bus;             // and CAN-LOG data(CAN_B0). Vehicle`s mileage, m
        public string Cmd_C3_CAN_B1;
        public string Cmd_C4_CAN8BITR0;           // or vehicle speed from CAN-LOG, km/h
        public string Cmd_C5_CAN8BITR1;           // or the 2rd byte of prefix S CAN-LOG
        public string Cmd_C6_CAN8BITR2;           // or the 1st byte of prefix S CAN-LOG
        public string Cmd_C7_CAN8BITR3;           // or lower byte of prefix S CAN-LOG
        public string Cmd_C8_CAN8BITR4;           // or the 3rd byte of prefix P CAN-LOG
        public string Cmd_C9_CAN8BITR5;           // or the 2rd byte of prefix P CAN-LOG
        public string Cmd_CA_CAN8BITR6;           // or the 1st byte of prefix P CAN-LOG
        public string Cmd_CB_CAN8BITR7;           // or lower byte of prefix P CAN-LOG
        public string Cmd_CC_CAN8BITR8;           // or the first byte in the procedure for receiving of prefix WA CAN-LOG
        public string Cmd_CD_CAN8BITR9;           // or the second byte in the procedure for receiving of prefix WA CAN-LOG
        public string Cmd_CE_CAN8BITR10;          // or the third byte in the procedure for receiving of prefix WA CAN-LOG
        public string Cmd_CF_CAN8BITR11;          // or the fourth byte in the procedure for receiving of prefix WA CAN-LOG

        public string Cmd_D0_CAN8BITR12;          // or the fifth byte in the procedure for receiving of prefix WA CAN-LOG
        public string Cmd_D1_CAN8BITR13;          // or the sixth byte in the procedure for receiving of prefix WA CAN-LOG
        public string Cmd_D2_CAN8BITR14;          // or the seventh byte in the procedure for receiving of prefix WA CAN-LOG

        public string Cmd_D3_Second_iButton;
        public string Cmd_D4_GPDOdo;              // according to GPS/GLONASS units data, m.
        public string Cmd_D5_State;               // of iButton keys, identifiers of which are set by iButton command.

        public string Cmd_D6_CAN16BITR0;          //Depending on settings: 1. CAN16BITR0 2. the 1st vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public string Cmd_D7_CAN16BITR1;          //Depending on settings: 1. CAN16BITR1 2. the 2nd vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public string Cmd_D8_CAN16BITR2;          //Depending on settings: 1. CAN16BITR2 2. the 3rd vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public string Cmd_D9_CAN16BITR3;          //Depending on settings: 1. CAN16BITR3 2. the 4th vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public string Cmd_DA_CAN16BITR4;          //Depending on settings: 1. CAN16BITR4 2. the 5th vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public string Cmd_DB_CAN32BITR0;          //Depending on settings: 1. CAN32BITR0 2. total time of engine operation, h
        public string Cmd_DC_CAN32BITR1;          //Depending on settings: 1. CAN32BITR1 2. CAN-LOG, R prefix, fuel level, l
        public string Cmd_DD_CAN32BITR2;          //Depending on settings: 1.CAN32BITR2 2. CAN-LOG, user prefix
        public string Cmd_DE_CAN16BITR0;          //Depending on settings: 1. CAN32BITR3 2. CAN-LOG, user prefix
        public string Cmd_DF_CAN16BITR0;          //Depending on settings: 1.CAN32BITR4 2. CAN-LOG, user prefix

        public string Cmd_F0_CAN32BITR5;
        public string Cmd_F1_Tags_CAN32BITR6;     // – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F2_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F3_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F4_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F5_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F6_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F7_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F8_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public string Cmd_F9_CAN32BITR14l;

        public byte[] CRC;

        public TGalileoProtocolClean(TGalileoProtocolRaw aRaw)
        {
            try
            {
                STX = aRaw.STX;
                Length = GetInt16(aRaw.Length).ToString();  //GetASCIIString(aRaw.Length);

                Cmd_01_HWVersion = Convert.ToInt16(GetData(aRaw.Cmd_01_HWVersion)[0]).ToString(); //Convert.ToInt32(GetASCIIString(GetData(aRaw.Cmd_01_HWVersion))).ToString();

                Cmd_02_FirmwareVersion = Convert.ToInt16(GetData(aRaw.Cmd_02_FirmwareVersion)[0]).ToString();  // Convert.ToInt32(GetASCIIString(GetData(aRaw.Cmd_02_FirmwareVersion))).ToString();

                Cmd_03_IMEI = GetASCIIString(GetData(aRaw.Cmd_03_IMEI)).ToString();

                //GetASCIIString(GetData(aRaw.Cmd_20_Datetime));
                Cmd_20_Datetime = GetInt32(GetData(aRaw.Cmd_20_Datetime)).ToString();

                //Cmd_30_COORDS = GetASCIIString(GetData(aRaw.Cmd_30_COORDS));
                //       COORDS
                //   0  1      2    3   4   5     6   7   8   9
                // [30][F0]   [00][00][00][00]   [00][00][00][00]
                try
                {
                    byte[] vCoords = GetData(aRaw.Cmd_30_COORDS);

                    byte vCoordState1 = vCoords[0]; //shows accuracy 
                    //byte vCoordState2 = vCoords[1]; //shows satelites?

                    string vSats = vCoordState1.ToString("X");
                    if (vSats.Length == 1)
                    {
                        vSats = "0" + vSats;
                    }

                    Satelites = vSats;
                    Lat       = BitConverter.ToInt32(vCoords, 1).ToString();
                    Long      = BitConverter.ToInt32(vCoords, 5).ToString();

                    //if lat is negative is Southern Hemi
                    if (Lat.Length > 3)
                    {
                        Lat = Lat.Insert(3, ".");
                        Long = Long.Insert(2, ".");
                    }
                }
                catch
                {
                }

                Cmd_33_Speed = GetInt32(GetData(aRaw.Cmd_33_Speed)).ToString(); //GetASCIIString(GetData(aRaw.Cmd_33_Speed));

                Cmd_34_Altitude = GetInt16(GetData(aRaw.Cmd_34_Altitude)).ToString();//GetASCIIString(GetData(aRaw.Cmd_34_Altitude));

                Cmd_40_DeviceStatus = TVxConvertors.ByteArrayToHexString(aRaw.Cmd_40_DeviceStatus, false, true);    //  GetInt16(GetData(aRaw.Cmd_40_DeviceStatus)).ToString(); //GetASCIIString(GetData(aRaw.Cmd_40_DeviceStatus));

                //INPUTS
                Cmd_45_Status_of_outputs = GetInt16(GetData(aRaw.Cmd_45_Status_of_outputs)).ToString();     // GetASCIIString(GetData(aRaw.Cmd_45_Status_of_outputs));
                Cmd_46_Status_of_inputs  = GetInt16(GetData(aRaw.Cmd_46_Status_of_inputs)).ToString();      // GetASCIIString(GetData(aRaw.Cmd_46_Status_of_inputs));
                Cmd_50_Input_voltage_0   = GetInt16(GetData(aRaw.Cmd_50_Input_voltage_0)).ToString();       // GetASCIIString(GetData(aRaw.Cmd_50_Input_voltage_0));
                Cmd_51_Input_voltage_1   = GetInt16(GetData(aRaw.Cmd_51_Input_voltage_1)).ToString();       // GetASCIIString(GetData(aRaw.Cmd_51_Input_voltage_1));
                Cmd_52_Input_voltage_2   = GetInt16(GetData(aRaw.Cmd_52_Input_voltage_2)).ToString();       // GetASCIIString(GetData(aRaw.Cmd_52_Input_voltage_2));
                Cmd_53_Input_voltage_3   = GetInt16(GetData(aRaw.Cmd_53_Input_voltage_3)).ToString();       // GetASCIIString(GetData(aRaw.Cmd_53_Input_voltage_3));
                Cmd_54_Input_4_values    = GetInt16(GetData(aRaw.Cmd_54_Input_4_values)).ToString();        // GetASCIIString(GetData(aRaw.Cmd_54_Input_4_values));
                Cmd_55_Input_5_values    = GetInt16(GetData(aRaw.Cmd_55_Input_5_values)).ToString();        // GetASCIIString(GetData(aRaw.Cmd_55_Input_5_values));

                Cmd_90_First_iButton     = TVxConvertors.ByteArrayToHexString(aRaw.Cmd_90_First_iButton, false, true, true, true);    //GetInt32(GetData(aRaw.Cmd_90_First_iButton)).ToString();      //GetASCIIString(GetData(aRaw.Cmd_90_First_iButton));
                Cmd_90_First_iButton     = Cmd_90_First_iButton.Substring(0, Cmd_90_First_iButton.Length - 2);
                Cmd_90_First_iButton     = Convert.ToInt32(Cmd_90_First_iButton, 16).ToString();

                //needs to be 10 in length 0008710109
                Cmd_90_First_iButton = TVxConvertors.StringFill(Cmd_90_First_iButton, 10);

                Cmd_A0_CAN8BITR15        = GetASCIIString(GetData(aRaw.Cmd_A0_CAN8BITR15));
                Cmd_A1_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A1_Tags_CAN8BITR16));
                Cmd_A2_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A2_Tags_CAN8BITR16));
                Cmd_A3_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A3_Tags_CAN8BITR16));
                Cmd_A4_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A4_Tags_CAN8BITR16));
                Cmd_A5_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A5_Tags_CAN8BITR16));
                Cmd_A6_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A6_Tags_CAN8BITR16));
                Cmd_A7_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A7_Tags_CAN8BITR16));
                Cmd_A8_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A8_Tags_CAN8BITR16));
                Cmd_A9_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_A9_Tags_CAN8BITR16));
                Cmd_AA_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_AA_Tags_CAN8BITR16));
                Cmd_AB_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_AB_Tags_CAN8BITR16));
                Cmd_AC_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_AC_Tags_CAN8BITR16));
                Cmd_AD_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_AD_Tags_CAN8BITR16));
                Cmd_AE_Tags_CAN8BITR16   = GetASCIIString(GetData(aRaw.Cmd_AE_Tags_CAN8BITR16));
                Cmd_AF_CAN8BITR30        = GetASCIIString(GetData(aRaw.Cmd_AF_CAN8BITR30));

                Cmd_B0_CAN16BITR5        = GetASCIIString(GetData(aRaw.Cmd_B0_CAN16BITR5));

                Cmd_B1_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B1_Tags_CAN16BITR6));
                Cmd_B2_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B2_Tags_CAN16BITR6));
                Cmd_B3_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B3_Tags_CAN16BITR6));
                Cmd_B4_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B4_Tags_CAN16BITR6));
                Cmd_B5_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B5_Tags_CAN16BITR6));
                Cmd_B6_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B6_Tags_CAN16BITR6));
                Cmd_B7_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B7_Tags_CAN16BITR6));
                Cmd_B8_Tags_CAN16BITR6   = GetASCIIString(GetData(aRaw.Cmd_B8_Tags_CAN16BITR6));
                Cmd_B9_CAN16BITR14       = GetASCIIString(GetData(aRaw.Cmd_B9_CAN16BITR14));

                Cmd_C0_CAN_bus           = GetASCIIString(GetData(aRaw.Cmd_C0_CAN_bus));
                Cmd_C1_CAN_bus           = GetASCIIString(GetData(aRaw.Cmd_C1_CAN_bus));
                Cmd_C2_CAN_bus           = GetASCIIString(GetData(aRaw.Cmd_C2_CAN_bus));
                Cmd_C3_CAN_B1            = GetASCIIString(GetData(aRaw.Cmd_C3_CAN_B1));
                Cmd_C4_CAN8BITR0         = GetASCIIString(GetData(aRaw.Cmd_C4_CAN8BITR0));
                Cmd_C5_CAN8BITR1         = GetASCIIString(GetData(aRaw.Cmd_C5_CAN8BITR1));
                Cmd_C6_CAN8BITR2         = GetASCIIString(GetData(aRaw.Cmd_C6_CAN8BITR2));
                Cmd_C7_CAN8BITR3         = GetASCIIString(GetData(aRaw.Cmd_C7_CAN8BITR3));
                Cmd_C8_CAN8BITR4         = GetASCIIString(GetData(aRaw.Cmd_C8_CAN8BITR4));
                Cmd_C9_CAN8BITR5         = GetASCIIString(GetData(aRaw.Cmd_C9_CAN8BITR5));
                Cmd_CA_CAN8BITR6         = GetASCIIString(GetData(aRaw.Cmd_CA_CAN8BITR6));
                Cmd_CB_CAN8BITR7         = GetASCIIString(GetData(aRaw.Cmd_CB_CAN8BITR7));
                Cmd_CC_CAN8BITR8         = GetASCIIString(GetData(aRaw.Cmd_CC_CAN8BITR8));
                Cmd_CD_CAN8BITR9         = GetASCIIString(GetData(aRaw.Cmd_CD_CAN8BITR9));
                Cmd_CE_CAN8BITR10        = GetASCIIString(GetData(aRaw.Cmd_02_FirmwareVersion));
                Cmd_CF_CAN8BITR11        = GetASCIIString(GetData(aRaw.Cmd_02_FirmwareVersion));

                Cmd_D0_CAN8BITR12        = GetASCIIString(GetData(aRaw.Cmd_D0_CAN8BITR12));
                Cmd_D1_CAN8BITR13        = GetASCIIString(GetData(aRaw.Cmd_D1_CAN8BITR13));
                Cmd_D2_CAN8BITR14        = GetASCIIString(GetData(aRaw.Cmd_D2_CAN8BITR14));

                Cmd_D3_Second_iButton = TVxConvertors.ByteArrayToHexString(aRaw.Cmd_D3_Second_iButton, false, true, true, true);
                Cmd_D3_Second_iButton = Cmd_D3_Second_iButton.Substring(0, Cmd_D3_Second_iButton.Length - 2);
                Cmd_D3_Second_iButton = Convert.ToInt32(Cmd_D3_Second_iButton, 16).ToString();

                //needs to be 10 in length 0008710109
                Cmd_D3_Second_iButton = TVxConvertors.StringFill(Cmd_D3_Second_iButton, 10);

                Cmd_D4_GPDOdo = GetInt32(GetData(aRaw.Cmd_D4_GPDOdo)).ToString();          
                Cmd_D5_State             = GetASCIIString(GetData(aRaw.Cmd_D5_State)).ToString();

                Cmd_D6_CAN16BITR0        = GetASCIIString(GetData(aRaw.Cmd_D6_CAN16BITR0));
                Cmd_D7_CAN16BITR1        = GetASCIIString(GetData(aRaw.Cmd_D7_CAN16BITR1));
                Cmd_D8_CAN16BITR2        = GetASCIIString(GetData(aRaw.Cmd_D8_CAN16BITR2));
                Cmd_D9_CAN16BITR3        = GetASCIIString(GetData(aRaw.Cmd_D9_CAN16BITR3));
                Cmd_DA_CAN16BITR4        = GetASCIIString(GetData(aRaw.Cmd_DA_CAN16BITR4));
                Cmd_DB_CAN32BITR0        = GetASCIIString(GetData(aRaw.Cmd_DB_CAN32BITR0));
                Cmd_DC_CAN32BITR1        = GetASCIIString(GetData(aRaw.Cmd_DC_CAN32BITR1));
                Cmd_DD_CAN32BITR2        = GetASCIIString(GetData(aRaw.Cmd_DD_CAN32BITR2));
                Cmd_DE_CAN16BITR0        = GetASCIIString(GetData(aRaw.Cmd_DE_CAN16BITR0));
                Cmd_DF_CAN16BITR0        = GetASCIIString(GetData(aRaw.Cmd_DF_CAN16BITR0));

                Cmd_F0_CAN32BITR5        = GetASCIIString(GetData(aRaw.Cmd_F0_CAN32BITR5));
                Cmd_F1_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F1_Tags_CAN32BITR6));
                Cmd_F2_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F2_Tags_CAN32BITR6));
                Cmd_F3_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F3_Tags_CAN32BITR6));
                Cmd_F4_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F4_Tags_CAN32BITR6));
                Cmd_F5_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F5_Tags_CAN32BITR6));
                Cmd_F6_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F6_Tags_CAN32BITR6));
                Cmd_F7_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F7_Tags_CAN32BITR6));
                Cmd_F8_Tags_CAN32BITR6   = GetASCIIString(GetData(aRaw.Cmd_F8_Tags_CAN32BITR6));
                Cmd_F9_CAN32BITR14l      = GetASCIIString(GetData(aRaw.Cmd_F9_CAN32BITR14l));

                CRC = aRaw.CRC;
            }
            catch (Exception eX)
            { 
                //show some error
            }
        }

        public short GetInt16(byte[] aBytes)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(aBytes);
                    return BitConverter.ToInt16(aBytes, 0);
                }
                else
                {
                    return BitConverter.ToInt16(aBytes, 0);
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetInt32(byte[] aBytes)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(aBytes);
                    return BitConverter.ToInt32(aBytes, 0);
                }
                else
                {
                    return BitConverter.ToInt32(aBytes, 0);
                }

            }
            catch
            {
                return 0;
            }
        }

        public long GetInt64(byte[] aBytes)
        {
            try
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(aBytes);
                    return BitConverter.ToInt64(aBytes, 0);
                }
                else
                {
                    return BitConverter.ToInt64(aBytes, 0);
                }
            }
            catch
            {
                return 0;
            }
        }

        public byte[] GetData(byte[] aBytes)
        {
            byte[] vResult = new byte[aBytes.Length - 1];
            Array.Copy(aBytes, 1, vResult, 0, vResult.Length);
            return vResult;
        }

        public double GetLength(byte[] aBytes)
        {
            return Convert.ToInt64(ASCIIEncoding.ASCII.GetString(aBytes));
        }

        public string GetASCIIString(byte[] aBytes) 
        {
            return ASCIIEncoding.ASCII.GetString(aBytes);
        }
    }

    public class TGalileoProtocolRaw
    {
        public byte[] fRawData;

        public byte STX;
        public byte[] Length;                     //should be 294 for all of these
        public byte[] Cmd_01_HWVersion;
        public byte[] Cmd_02_FirmwareVersion;
        public byte[] Cmd_03_IMEI;
        public byte[] Cmd_20_Datetime;
        public byte[] Cmd_30_COORDS;
        public byte[] Cmd_33_Speed;
        public byte[] Cmd_34_Altitude;
        public byte[] Cmd_40_DeviceStatus;
        public byte[] Cmd_45_Status_of_outputs;
        public byte[] Cmd_46_Status_of_inputs;
        public byte[] Cmd_50_Input_voltage_0;
        public byte[] Cmd_51_Input_voltage_1;
        public byte[] Cmd_52_Input_voltage_2;
        public byte[] Cmd_53_Input_voltage_3;
        public byte[] Cmd_54_Input_4_values;
        public byte[] Cmd_55_Input_5_values;
        public byte[] Cmd_90_First_iButton;
        public byte[] Cmd_A0_CAN8BITR15;          // or the eighth byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_A1_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A2_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A3_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A4_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A5_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A6_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A7_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A8_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_A9_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_AA_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_AB_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_AC_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_AD_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_AE_Tags_CAN8BITR16;     // - CAN8BITR29(0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
        public byte[] Cmd_AF_CAN8BITR30;
        public byte[] Cmd_B0_CAN16BITR5;
        public byte[] Cmd_B1_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B2_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B3_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B4_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B5_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B6_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B7_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B8_Tags_CAN16BITR6;     // – CAN16BITR13(0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
        public byte[] Cmd_B9_CAN16BITR14;
        public byte[] Cmd_C0_CAN_bus;             // and CAN-LOG data(CAN_A0). Fuel used by a vehicle from the date of manufacturing, l
        public byte[] Cmd_C1_CAN_bus;             // and CAN-LOG data(CAN_A1). Fuel level, %; coolant temperature, ⁰C; Enginespeed, rpm.
        public byte[] Cmd_C2_CAN_bus;             // and CAN-LOG data(CAN_B0). Vehicle`s mileage, m
        public byte[] Cmd_C3_CAN_B1;
        public byte[] Cmd_C4_CAN8BITR0;           // or vehicle speed from CAN-LOG, km/h
        public byte[] Cmd_C5_CAN8BITR1;           // or the 2rd byte of prefix S CAN-LOG
        public byte[] Cmd_C6_CAN8BITR2;           // or the 1st byte of prefix S CAN-LOG
        public byte[] Cmd_C7_CAN8BITR3;           // or lower byte of prefix S CAN-LOG
        public byte[] Cmd_C8_CAN8BITR4;           // or the 3rd byte of prefix P CAN-LOG
        public byte[] Cmd_C9_CAN8BITR5;           // or the 2rd byte of prefix P CAN-LOG
        public byte[] Cmd_CA_CAN8BITR6;           // or the 1st byte of prefix P CAN-LOG
        public byte[] Cmd_CB_CAN8BITR7;           // or lower byte of prefix P CAN-LOG
        public byte[] Cmd_CC_CAN8BITR8;           // or the first byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_CD_CAN8BITR9;           // or the second byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_CE_CAN8BITR10;          // or the third byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_CF_CAN8BITR11;          // or the fourth byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_D0_CAN8BITR12;          // or the fifth byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_D1_CAN8BITR13;          // or the sixth byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_D2_CAN8BITR14;          // or the seventh byte in the procedure for receiving of prefix WA CAN-LOG
        public byte[] Cmd_D3_Second_iButton;
        public byte[] Cmd_D4_GPDOdo;              // according to GPS/GLONASS units data, m.
        public byte[] Cmd_D5_State;               // of iButton keys, identifiers of which are set by iButton command.
        public byte[] Cmd_D6_CAN16BITR0;          //Depending on settings: 1. CAN16BITR0 2. the 1st vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public byte[] Cmd_D7_CAN16BITR1;          //Depending on settings: 1. CAN16BITR1 2. the 2nd vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public byte[] Cmd_D8_CAN16BITR2;          //Depending on settings: 1. CAN16BITR2 2. the 3rd vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public byte[] Cmd_D9_CAN16BITR3;          //Depending on settings: 1. CAN16BITR3 2. the 4th vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public byte[] Cmd_DA_CAN16BITR4;          //Depending on settings: 1. CAN16BITR4 2. the 5th vehicle’s axle load, kg 3. failure code OBD ΙΙ
        public byte[] Cmd_DB_CAN32BITR0;          //Depending on settings: 1. CAN32BITR0 2. total time of engine operation, h
        public byte[] Cmd_DC_CAN32BITR1;          //Depending on settings: 1. CAN32BITR1 2. CAN-LOG, R prefix, fuel level, l
        public byte[] Cmd_DD_CAN32BITR2;          //Depending on settings: 1.CAN32BITR2 2. CAN-LOG, user prefix
        public byte[] Cmd_DE_CAN16BITR0;          //Depending on settings: 1. CAN32BITR3 2. CAN-LOG, user prefix
        public byte[] Cmd_DF_CAN16BITR0;          //Depending on settings: 1.CAN32BITR4 2. CAN-LOG, user prefix
        public byte[] Cmd_F0_CAN32BITR5;
        public byte[] Cmd_F1_Tags_CAN32BITR6;     // – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F2_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F3_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F4_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F5_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F6_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F7_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F8_Tags_CAN32BITR6;     // – CAN32BITR13(0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
        public byte[] Cmd_F9_CAN32BITR14l;
        public byte[] CRC;

        public volatile bool _Processing = false;

        public TGalileoProtocolRaw()
        { 
        }

        //only allow already cleaned data to enter here
        public TGalileoProtocolRaw(byte[] aRawData)
        {
            _Processing = true;

            try
            {
                fRawData = new byte[aRawData.Length];
                Array.Copy(aRawData, 0, fRawData, 0, aRawData.Length);

                //copy data into byte arrays
                int vIndex = 0;

                STX = fRawData[vIndex++];                                           //1
                Length = fRawData.GetNextBytes(2, ref vIndex);                      //2       

                Cmd_01_HWVersion = fRawData.GetNextBytes(2, ref vIndex);            //2
                Cmd_02_FirmwareVersion = fRawData.GetNextBytes(2, ref vIndex);      //2
                Cmd_03_IMEI = fRawData.GetNextBytes(16, ref vIndex);                //16

                Cmd_20_Datetime = fRawData.GetNextBytes(5, ref vIndex);             //
                Cmd_30_COORDS = fRawData.GetNextBytes(10, ref vIndex);
                Cmd_33_Speed = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_34_Altitude = fRawData.GetNextBytes(3, ref vIndex);

                Cmd_40_DeviceStatus = fRawData.GetNextBytes(3, ref vIndex);

                Cmd_45_Status_of_outputs = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_46_Status_of_inputs = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_50_Input_voltage_0 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_51_Input_voltage_1 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_52_Input_voltage_2 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_53_Input_voltage_3 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_54_Input_4_values = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_55_Input_5_values = fRawData.GetNextBytes(3, ref vIndex);

                Cmd_90_First_iButton = fRawData.GetNextBytes(5, ref vIndex);

                Cmd_A0_CAN8BITR15 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A1_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A2_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A3_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A4_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A5_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A6_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A7_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A8_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_A9_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_AA_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_AB_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_AC_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_AD_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_AE_Tags_CAN8BITR16 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_AF_CAN8BITR30 = fRawData.GetNextBytes(2, ref vIndex);

                Cmd_B0_CAN16BITR5 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B1_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B2_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B3_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B4_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B5_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B6_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B7_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B8_Tags_CAN16BITR6 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_B9_CAN16BITR14 = fRawData.GetNextBytes(3, ref vIndex);

                Cmd_C0_CAN_bus = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_C1_CAN_bus = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_C2_CAN_bus = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_C3_CAN_B1 = fRawData.GetNextBytes(5, ref vIndex);

                Cmd_C4_CAN8BITR0 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_C5_CAN8BITR1 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_C6_CAN8BITR2 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_C7_CAN8BITR3 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_C8_CAN8BITR4 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_C9_CAN8BITR5 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_CA_CAN8BITR6 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_CB_CAN8BITR7 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_CC_CAN8BITR8 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_CD_CAN8BITR9 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_CE_CAN8BITR10 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_CF_CAN8BITR11 = fRawData.GetNextBytes(2, ref vIndex);

                Cmd_D0_CAN8BITR12 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_D1_CAN8BITR13 = fRawData.GetNextBytes(2, ref vIndex);
                Cmd_D2_CAN8BITR14 = fRawData.GetNextBytes(2, ref vIndex);

                Cmd_D3_Second_iButton = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_D4_GPDOdo = fRawData.GetNextBytes(5, ref vIndex);

                Cmd_D5_State = fRawData.GetNextBytes(2, ref vIndex);

                Cmd_D6_CAN16BITR0 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_D7_CAN16BITR1 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_D8_CAN16BITR2 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_D9_CAN16BITR3 = fRawData.GetNextBytes(3, ref vIndex);
                Cmd_DA_CAN16BITR4 = fRawData.GetNextBytes(3, ref vIndex);

                Cmd_DB_CAN32BITR0 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_DC_CAN32BITR1 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_DD_CAN32BITR2 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_DE_CAN16BITR0 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_DF_CAN16BITR0 = fRawData.GetNextBytes(5, ref vIndex);

                Cmd_F0_CAN32BITR5 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F1_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F2_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F3_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F4_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F5_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F6_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F7_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F8_Tags_CAN32BITR6 = fRawData.GetNextBytes(5, ref vIndex);
                Cmd_F9_CAN32BITR14l = fRawData.GetNextBytes(5, ref vIndex);

                CRC = fRawData.GetNextBytes(2, ref vIndex);
            }
            catch
            {
                
            }
        }

        public void TGalileoProtocolRawFromCommand(byte[] aRawData)
        { 
        }

        public void GetNextBytes(ref byte[] aArray, ref int aIndex, int aLength)
        {
            aArray = new byte[aLength];
            try
            {
                for (int i = 0; i < aLength; i++)
                {
                    aArray[i] = fRawData[aIndex++];
                }
            }
            catch
            { 
            }
        }

        /*
            [01]                                                                        STX
            [21][81]                                                                    Length binary   21->0010 0001     81->1000 0001

            [01][00]                                                                    01  HW version
            [02][05]                                                                    02  Firmware version
            [03][38][36][35][35][31][33][30][37][31][32][30][38][30][32][35]            03 IMEI

            [20][22][1F][00][00]                                                        20 Datetime
            [30][10][00][00][00][00][00][00][00][00]                                    30 COORDS
            [33][00][00][00][00]                                                        33 Speed
            [34][00][00]                                                                34 Altitude
            [40][08][4A]                                                                40 DeviceStatus

            [45][0F][00]                                                                45 Status of outputs
            [46][00][00]                                                                46 Status of inputs
            [50][00][00]                                                                50 Input voltage 0
            [51][00][00]                                                                51 Input voltage 1
            [52][00][00]                                                                52 Input voltage 2
            [53][00][00]                                                                53 Input voltage 3
            [54][00][00]                                                                54 Input 4 values
            [55][00][00]                                                                55 Input 5 values

            [90][DD][E7][84][00]                                                        90 First iButton key identification number

            [A0][00]                                                                    A0 CAN8BITR15 or the eighth byte in the procedure for receiving of prefix WA CAN-LOG
            [A1][00]                                                                    A1 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A2][00]                                                                    A2 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A3][00]                                                                    A3 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A4][00]                                                                    A4 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A5][00]                                                                    A5 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A6][00]                                                                    A6 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A7][00]                                                                    A7 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A8][00]                                                                    A8 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [A9][00]                                                                    A9 Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [AA][00]                                                                    AA Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [AB][00]                                                                    AB Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [AC][00]                                                                    AC Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [AD][00]                                                                    AD Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [AE][00]                                                                    AE Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
            [AF][00]                                                                    AF CAN8BITR30

            [B0][00][00]                                                                B0 CAN16BITR5
            [B1][00][00]                                                                B1 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B2][00][00]                                                                B2 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B3][00][00]                                                                B3 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B4][00][00]                                                                B4 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B5][00][00]                                                                B5 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B6][00][00]                                                                B6 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B7][00][00]                                                                B7 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B8][00][00]                                                                B8 Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
            [B9][00][00]                                                                B9 CAN16BITR14

            [C0][00][00][00][00]                                                        C0 CAN-bus and CAN-LOG data (CAN_A0). Fuel used by a vehicle from the date of manufacturing, l
            [C1][00][00][00][00]                                                        C1 CAN-bus and CAN-LOG data (CAN_A1). Fuel level, %; coolant temperature, ⁰C; Enginespeed, rpm.
            [C2][00][00][00][00]                                                        C2 CAN-bus and CAN-LOG data (CAN_B0). Vehicle`s mileage, m
            [C3][00][00][00][00]                                                        C3 CAN_B1
            [C4][00]                                                                    C4 CAN8BITR0 or vehicle speed from CAN-LOG, km/h
            [C5][00]                                                                    C5 CAN8BITR1 or the 2rd byte of prefix S CAN-LOG
            [C6][00]                                                                    C6 CAN8BITR2 or the 1st byte of prefix S CAN-LOG
            [C7][00]                                                                    C7 CAN8BITR3 or lower byte of prefix S CAN-LOG
            [C8][00]                                                                    C8 CAN8BITR4 or the 3rd byte of prefix P CAN-LOG
            [C9][00]                                                                    C9 CAN8BITR5 or the 2rd byte of prefix P CAN-LOG
            [CA][00]                                                                    CA CAN8BITR6 or the 1st byte of prefix P CAN-LOG
            [CB][00]                                                                    CB CAN8BITR7 or lower byte of prefix P CAN-LOG
            [CC][00]                                                                    CC CAN8BITR8 or the first byte in the procedure for receiving of prefix WA CAN-LOG
            [CD][00]                                                                    CD CAN8BITR9 or the second byte in the procedure for receiving of prefix WA CAN-LOG
            [CE][00]                                                                    CE CAN8BITR10 or the third byte in the procedure for receiving of prefix WA CAN-LOG
            [CF][00]                                                                    CF CAN8BITR11 or the fourth byte in the procedure for receiving of prefix WA CAN-LOG

            [D0][00]                                                                    D0 CAN8BITR12 or the fifth byte in the procedure for receiving of prefix WA CAN-LOG
            [D1][00]                                                                    D1 CAN8BITR13 or the sixth byte in the procedure for receiving of prefix WA CAN-LOG
            [D2][00]                                                                    D2 CAN8BITR14 or the seventh byte in the procedure for receiving of prefix WA CAN-LOG
            [D3][00][00][00][00]                                                        D3 The second iButton key identification number
            [D4][00][00][00][00]                                                        D4 Total mileage according to GPS/GLONASS units data, m.
            [D5][01]                                                                    D5 State of iButton keys, identifiers of which are set by iButton command.
            [D6][00][00]                                                                D6 Depending on settings: 1. CAN16BITR0 2. the 1st vehicle’s axle load, kg 3. failure code OBD ΙΙ
            [D7][00][00]                                                                D7 Depending on settings: 1. CAN16BITR1 2. the 2nd vehicle’s axle load, kg 3. failure code OBD ΙΙ
            [D8][00][00]                                                                D8 Depending on settings: 1. CAN16BITR2 2. the 3rd vehicle’s axle load, kg 3. failure code OBD ΙΙ
            [D9][00][00]                                                                D9 Depending on settings: 1. CAN16BITR3 2. the 4th vehicle’s axle load, kg 3. failure code OBD ΙΙ
            [DA][00][00]                                                                DA Depending on settings: 1. CAN16BITR4 2. the 5th vehicle’s axle load, kg 3. failure code OBD ΙΙ
            [DB][00][00][00][00]                                                        DB Depending on settings: 1. CAN32BITR0 2. total time of engine operation, h
            [DC][00][00][00][00]                                                        DC Depending on settings: 1. CAN32BITR1 2. CAN-LOG, R prefix, fuel level, l
            [DD][00][00][00][00]                                                        DD Depending on settings: 1.CAN32BITR2 2. CAN-LOG, user prefix
            [DE][00][00][00][00]                                                        DE Depending on settings: 1. CAN32BITR3 2. CAN-LOG, user prefix
            [DF][00][00][00][00]                                                        DF Depending on settings: 1.CAN32BITR4 2. CAN-LOG, user prefix

            [F0][00][00][00][00]                                                        F0 CAN32BITR5
            [F1][00][00][00][00]                                                        F1 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F2][00][00][00][00]                                                        F2 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F3][00][00][00][00]                                                        F3 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F4][00][00][00][00]                                                        F4 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F5][00][00][00][00]                                                        F5 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F6][00][00][00][00]                                                        F6 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F7][00][00][00][00]                                                        F7 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F8][00][00][00][00]                                                        F8 Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
            [F9][00][00][00][00]                                                        F9 CAN32BITR14

            [9C][57]                                                                    CRC
         */


        /*
        
        [01]
        [21][81]

        [01][00]
        [02][03]
        [03][38][36][35][35][31][33][30][37][31][32][30][38][30][32][35]

        [20][FE][C3][02][00] 
        [30][10][00][00][00][00][00][00][00][00]
        [33][00][00][00][00]
        [34][00][00]
        [40][08][4A]
        [45][0F][00]
        [46][00][00]
        [50][00][00]
        [51][00][00]
        [52][00][00]
        [53][00][00]
        [54][00][00]
        [55][00][00]

        [90][DD][E7][84][00]

        [A0][00]
        [A1][00]
        [A2][00]
        [A3][00]
        [A4][00]
        [A5][00]
        [A6][00]
        [A7][00]
        [A8][00]
        [A9][00]
        [AA][00]
        [AB][00]
        [AC][00]
        [AD][00]
        [AE][00]
        [AF][00]

        [B0][00][00]
        [B1][00][00]
        [B2][00][00]
        [B3][00][00]
        [B4][00][00]
        [B5][00][00]
        [B6][00][00]
        [B7][00][00]
        [B8][00][00]
        [B9][00][00]

        [C0][00][00][00][00]
        [C1][00][00][00][00]
        [C2][00][00][00][00]
        [C3][00][00][00][00]
        [C4][00]
        [C5][00]
        [C6][00]
        [C7][00]
        [C8][00]
        [C9][00]
        [CA][00]
        [CB][00]
        [CC][00]
        [CD][00]
        [CE][00]
        [CF][00]
        [D0][00]
        [D1][00]
        [D2][00]
        [D3][00][00][00][00]
        [D4][00][00][00][00]
        [D5][01]
        [D6][00][00]
        [D7][00][00]
        [D8][00][00]
        [D9][00][00]
        [DA][00][00]
        [DB][00][00][00][00]
        [DC][00][00][00][00]
        [DD][00][00][00][00]
        [DE][00][00][00][00]
        [DF][00][00][00][00]
        [F0][00][00][00][00]
        [F1][00][00][00][00]
        [F2][00][00][00][00]
        [F3][00][00][00][00]
        [F4][00][00][00][00]
        [F5][00][00][00][00]
        [F6][00][00][00][00]
        [F7][00][00][00][00]
        [F8][00][00][00][00]
        [F9][00][00][00][00]
        [8D][33]

         */

        /*

                Tag
                
                Description
                
                Length, 
                
                byte
                
                Format
                
                1
                
                0x01
                
                Hardware version
                
                1
                
                Unsigned integer
                
                2
                
                0x02
                
                Firmware version
                
                1
                
                Unsigned integer
                
                3
                
                0x03
                
                IMEI
                
                15
                
                ASCII string
                
                4
                
                0x04
                
                Identifier of a device
                
                2
                
                Unsigned integer
                
                5
                
                0x10
                
                Number of an archive record
                
                2
                
                Unsigned integer
                
                6
                
                0x20
                
                Date and time
                
                4
                
                Unsigned integer, seconds since 1970-01-01
                
                00:00:00 GMT
                
                7
                
                0x30
                
                Coordinates in degrees,
                
                number of satellites,
                
                indication of coordinates
                
                determination correctness
                
                and source of coordinates
                
                9
                
                4 lower bits: number of satellites.
                
                The next 4 bits: coordinates correctness,
                
                0 – coordinates are correct,
                
                GLONASS/GPS module is a source,
                
                2 - coordinates are correct,
                
                cellular base stations are a source,
                
                other values – coordinates are incorrect.
                
                The next 4 bytes: signed integer,
                
                latitude, the value should be divided
                
                by 1000000, negative values correspond
                
                to southern latitude.
                
                Last 4 bytes: signed integer,
                
                longitude, the value should be divided
                
                by 1000000, negative values correspond
                
                to western longitude.
                
                For example, received:
                
                07 C0 0E 32 03 B8 D7 2D 05.
                
                Coordinates correctness:
                
                0 (coordinates are correct).
                
                Satellites number: 7
                
                Latitude: 53.612224
                
                Longitude: 86.890424
                
                8
                
                0x33
                
                Speed in km/h and direction in
                
                degrees
                
                4
                
                2 lower bytes: unsigned integer,
                
                speed, the value should be divided by 10.
                
                2 higher bytes: unsigned integer,
                
                direction, the value should be divided by 10.
                
                For example, received: 5C 00 48 08.
                
                Speed: 9.2 km/h.
                
                Direction: 212 degrees.
                
                9
                
                0x34
                
                Height, m
                
                2
                
                Signed integer
                
                10
                
                0x35
                
                One of the values:
                
                HDOP, if GLONASS/GPS
                
                module is coordinates source
                
                Error in meters, if cellular base
                
                stations are a source.
                
                1
                
                Unsigned integrer.
                
                In case of HDOP, the value should be
                
                divided by 10.
                
                In case of error, the value should be multiplied
                
                by 10.
                
                11
                
                0x40
                
                Status of device
                
                2
                
                Unsigned integer, each bit corresponds
                
                to a separate unit state, see explanations
                
                below
                
                12
                
                0x41
                
                Supply voltage, mV
                
                2
                
                Unsigned integer
                
                13
                
                0x42
                
                Battery voltage, mV
                
                2
                
                Unsigned integer
                
                14
                
                0x43
                
                Inside temperature, °C
                
                1
                
                Signed integer
                
                15
                
                0x44
                
                Acceleration (this tag can only
                
                be used on tracking devices up to
                
                and including the 5.1 version)
                
                4
                
                10 lower bits: acceleration by X axis.
                
                Next 10 bits: acceleration by Y axis.
                
                Next 10 bits: acceleration by Z axis.
                
                0g = 512, values less than 512 – acceleration,
                
                directed against the axis. Scale 1g=186.
                
                For example, 326 = -1g, 605 = 0,5g.
                
                Example, received: AF 21 98 15.
                
                Acceleration X: 431, Y: 520, Z: 345.
                
                16
                
                0x45
                
                Status of outputs
                
                2
                
                Each bit, beginning with the lower one,
                
                indicates the state of a correspondent
                
                output
                
                17
                
                0x46
                
                Status of inputs
                
                2
                
                Each bit, beginning with the lower one,
                
                indicates triggering on a correspondent
                
                input
                
                18
                
                0x50
                
                Input voltage 0
                
                Depending on settings:
                
                1. voltage, mV,
                
                2. number of pulses;
                
                3. frequency,Hz.
                
                2
                
                Unsigned integer
                
                19
                
                0x51
                
                Input voltage 1
                
                Depending on settings:
                
                1. voltage, mV,
                
                2. number of pulses;
                
                3. frequency,Hz.
                
                2
                
                Unsigned integer
                
                20
                
                0x52
                
                Input voltage 2
                
                Depending on settings:
                
                1. voltage, mV,
                
                2. number of pulses;
                
                3. frequency,Hz.
                
                2
                
                Unsigned integer
                
                21
                
                0x53
                
                Input voltage 3
                
                Depending on settings:
                
                1. voltage, mV,
                
                2. number of pulses;
                
                3. frequency,Hz.
                
                2
                
                Unsigned integer
                
                22
                
                0x58
                
                RS232 0
                
                2
                
                The format depends on the port settings
                
                23
                
                0x59
                
                RS232 1
                
                2
                
                The format depends on the port settings
                
                24
                
                0x70
                
                Thermometer 0 identifier and
                
                measured temperature, °C
                
                2
                
                Lower byte: unsigned integer, identifier.
                
                Higher byte: signed integer, temperature.
                
                Identifier 127 with temperature -128 ºC mean
                
                a disconnection.
                
                Example, received: 01 10
                
                Identifier: 01
                
                Temperature: 16ºC
                
                25
                
                0x71
                
                Thermometer 1 identifier and
                
                measured temperature, °C
                
                2
                
                Analogous to temperature sensor 1
                
                26
                
                0x72
                
                Thermometer 2 identifier and
                
                measured temperature, °C
                
                2
                
                Analogous to temperature sensor 2
                
                27
                
                0x73
                
                Thermometer 3 identifier and
                
                measured temperature, °C
                
                2
                
                Analogous to temperature sensor 3
                
                28
                
                0x74
                
                Thermometer 4 identifier and
                
                measured temperature, °C
                
                2
                
                Analogous to temperature sensor 4
                
                29
                
                0x75
                
                Thermometer 5 identifier and
                
                measured temperature, °C
                
                2
                
                Analogous to temperature sensor 5
                
                30
                
                0x76
                
                Thermometer 6 identifier and
                
                measured temperature, °C
                
                2
                
                Analogous to temperature sensor 6
                
                31
                
                0x77
                
                Thermometer 7 identifier and
                
                measured temperature, °C
                
                2
                
                Analogous to temperature sensor 7
                
                32
                
                0x90
                
                First iButton key identification
                
                number
                
                4
                
                 
                
                33
                
                0xc0
                
                CAN-bus and CAN-LOG data
                
                (CAN_A0). Fuel used by
                
                a vehicle from the date of
                
                manufacturing, l
                
                4
                
                Unsigned integer, the value should be
                
                divided by 2
                
                34
                
                0xc1
                
                CAN-bus and CAN-LOG data
                
                (CAN_A1). Fuel level, %;
                
                coolant temperature, ⁰C;
                
                Enginespeed, rpm.
                
                4
                
                Lower byte: fuel level, the value should be
                
                multiplied by 0.4
                
                The second byte: coolant temperature,
                
                the value should be deducted 40.
                
                The third and fourth bytes: engine speed,
                
                values should be multiplied by 0.125.
                
                Example of data from bus in order of
                
                receiving: FA 72 50 25.
                
                Fuel level: 100%.
                
                Temperature 74ºC.
                
                Engine speed: 1194 rmp
                
                35
                
                0xC2
                
                CAN-bus and CAN-LOG data
                
                (CAN_B0).
                Vehicle`s mileage, m.
                
                4
                
                Unsigned integer, the value should be
                
                multiplied by 5
                
                36
                
                0xC3
                
                CAN_B1
                
                4
                
                 
                
                37
                
                0xC4
                
                CAN8BITR0
                
                or vehicle speed from
                CAN-LOG, km/h
                
                1
                
                If speed is transmitted from CAN-LOG,
                
                the value is an unsigned integer
                
                
                38
                
                0xC5
                
                CAN8BITR1 or the 2rd byte
                
                of prefix S CAN-LOG
                
                1
                
                 
                
                39
                
                0xC6
                
                CAN8BITR2 or the 1st byte
                
                of prefix S CAN-LOG
                
                1
                
                 
                
                40
                
                0xC7
                
                CAN8BITR3 or lower byte
                
                of prefix S CAN-LOG
                
                1
                
                 
                
                41
                
                0xC8
                
                CAN8BITR4 or the 3rd byte
                
                of prefix P CAN-LOG
                
                1
                
                 
                
                42
                
                0xC9
                
                CAN8BITR5 or the 2rd byte
                
                of prefix P CAN-LOG
                
                1
                
                 
                
                43
                
                0xCA
                
                CAN8BITR6 or the 1st byte
                
                of prefix P CAN-LOG
                
                1
                
                 
                
                44
                
                0xCB
                
                CAN8BITR7 or lower byte
                
                of prefix P CAN-LOG
                
                1
                
                 
                
                45
                
                0xCC
                
                CAN8BITR8 or the first byte
                
                in the procedure for receiving
                
                of prefix WA CAN-LOG
                
                1
                
                 
                
                46
                
                0xCD
                
                CAN8BITR9 or the second
                
                byte in the procedure for
                
                receiving of prefix WA CAN-LOG
                
                1
                
                 
                
                47
                
                0xCE
                
                CAN8BITR10 or the third byte
                
                in the procedure for receiving
                
                of prefix WA CAN-LOG
                
                1
                
                 
                
                48
                
                0xCF
                
                CAN8BITR11 or the fourth byte
                
                in the procedure for receiving
                
                of prefix WA CAN-LOG
                
                1
                
                 
                
                49
                
                0xD0
                
                CAN8BITR12 or the fifth byte
                
                in the procedure for receiving
                
                of prefix WA CAN-LOG
                
                1
                
                 
                
                50
                
                0xD1
                
                CAN8BITR13 or the sixth byte
                
                in the procedure for receiving
                
                of prefix WA CAN-LOG
                
                1
                
                 
                
                51
                
                0xD2
                
                CAN8BITR14 or the seventh
                
                byte in the procedure for
                
                receiving of prefix WA CAN-LOG
                
                1
                
                 
                
                52
                
                0xD3
                
                The second iButton key
                
                identification number
                
                4
                
                 
                
                53
                
                0xD4
                
                Total mileage according to
                
                GPS/GLONASS units data, m.
                
                4
                
                Unsigned integer
                
                54
                
                0xD5
                
                State of iButton keys, identifiers
                
                of which are set by iButton
                
                
                
                command.
                
                1
                
                Each bit corresponds to one key.
                
                Example, received: 05 or 00000101
                
                in binary system. It means that the first and
                
                the third keys are connected
                
                55
                
                0xD6
                
                Depending on settings:
                
                1. CAN16BITR0
                
                2. the 1st vehicle’s axle
                
                load, kg
                
                3. failure code OBD ΙΙ
                
                2
                
                In case the load is on axle, the value is
                
                an unsigned integer; values should be
                
                divided by 2
                
                56
                
                0xD7
                
                Depending on settings:
                
                1. CAN16BITR1
                
                2. the 2nd vehicle’s axle
                
                load, kg
                
                3. failure code OBD ΙΙ
                
                2
                
                In case the load is on axle, the value is
                
                an unsigned integer; values should be
                
                divided by 2
                
                57
                
                0xD8
                
                Depending on settings:
                
                1. CAN16BITR2
                
                2. the 3rd vehicle’s axle
                
                load, kg
                
                3. failure code OBD ΙΙ
                
                2
                
                In case the load is on axle, the value is
                
                an unsigned integer; values should be
                
                divided by 2
                
                58
                
                0xD9
                
                Depending on settings:
                
                1. CAN16BITR3
                
                2. the 4th vehicle’s axle
                
                load, kg
                
                3. failure code OBD ΙΙ
                
                2
                
                In case the load is on axle, the value is
                
                an unsigned integer; values should be
                
                divided by 2
                
                59
                
                0xDA
                
                Depending on settings:
                
                1. CAN16BITR4
                
                2. the 5th vehicle’s axle
                
                load, kg
                
                3. failure code OBD ΙΙ
                
                2
                
                In case the load is on axle, the value is
                
                an unsigned integer; values should be
                
                divided by 2
                
                60
                
                0xDB
                
                Depending on settings:
                
                1. CAN32BITR0
                
                2. total time of engine
                
                operation, h
                
                4
                
                In case the time of engine operation is
                
                transmitted,
                
                the value is an unsigned integer;
                
                values should be divided by 100
                
                61
                
                0xDC
                
                Depending on settings:
                
                1. CAN32BITR1
                
                2. CAN-LOG, R prefix,
                
                fuel level, l
                
                4
                
                In case the fuel level is on CAN-LOG,
                the value is an unsigned integer; values
                
                should be divided by 10
                
                62
                
                0xDD
                
                Depending on settings:
                
                1.CAN32BITR2
                
                2. CAN-LOG, user prefix
                
                4
                
                 
                
                63
                
                0xDE
                
                Depending on settings:
                
                1. CAN32BITR3
                
                2. CAN-LOG, user prefix
                
                4
                
                 
                
                64
                
                0xDF
                
                Depending on settings:
                
                1.CAN32BITR4
                
                2. CAN-LOG, user prefix
                
                4
                
                 
                
                65
                
                0x54
                
                Input 4 values.
                
                Depending on settings:
                
                1. voltage, mV
                
                2. number of pulses
                
                3. frequency, Hz
                
                2
                
                Unsigned integer
                
                66
                
                0x55
                
                Input 5 values.
                
                Depending on settings:
                
                1. voltage, mV
                
                2. number of pulses
                
                3. frequency, Hz
                
                2
                
                Unsigned integer
                
                67
                
                0x56
                
                Input 6 values.
                
                Depending on settings:
                
                1. voltage, mV
                
                2. number of pulses
                
                3. frequency, Hz
                
                2
                
                Unsigned integer
                
                68
                
                0x57
                
                Input 7 values.
                
                Depending on settings:
                
                1. voltage, mV
                
                2. number of pulses
                
                3. frequency, H
                
                2
                
                Unsigned integer
                
                69
                
                0x80
                
                Zero DS1923 sensor
                
                Identifier, measured
                
                temperature ºC and
                
                humidity %
                
                3
                
                Lower byte: unsigned integer, identifier.
                
                The second byte: signed integer, temperature.
                
                Higher byte: humidity, values should be
                
                multiplied by 100 and divided by 255.
                
                Example, received: 01 10 20.
                
                Identifier: 01
                
                Temperature: 16ºC.
                
                Humidity: 12.54%
                
                70
                
                0x81
                
                The 1st DS1923 sensor
                
                Identifier, measured
                
                temperature °C and
                
                humidity %.
                
                3
                
                Analogous to DS1923 zero sensor
                
                71
                
                0x82
                
                The 2nd DS232sensor
                
                Identifier, measured
                
                temperature °C and
                
                humidity %
                
                3
                
                Analogous to DS1923 zero sensor
                
                72
                
                0x83
                
                The 3rd DS232 sensor
                
                Identifier, measured
                
                temperature °C and
                
                humidity %
                
                3
                
                Analogous to DS1923 zero sensor
                
                73
                
                0x84
                
                The 4th DS232 sensor
                
                Identifier, measured
                
                temperature °C and
                
                humidity %
                
                3
                
                Analogous to DS1923 zero sensor
                
                74
                
                0x85
                
                The 5th DS232 sensor
                
                Identifier, measured
                
                temperature °C and
                
                humidity %
                
                3
                
                Analogous to DS1923 zero sensor
                
                75
                
                0x86
                
                The 6th DS232 sensor
                
                Identifier, measured
                
                temperature °C and
                
                humidity %
                
                3
                
                Analogous to DS1923 zero sensor
                
                76
                
                0x87
                
                The 7th DS232 sensor
                
                Identifier, measured
                
                temperature °C and
                
                humidity %
                
                3
                
                Analogous to DS1923 zero sensor
                
                77
                
                0x60
                
                RS485 [0].  Fuel level
                
                sensor with address 0
                
                2
                
                Unsigned integer
                
                78
                
                0x61
                
                RS485 [1]. Fuel level
                
                sensor with address 1
                
                2
                
                Unsigned integer
                
                79
                
                0x62
                
                RS485 [2]. Fuel level
                
                sensor with address 2
                
                2
                
                Unsigned integer
                
                80
                
                0x63
                
                RS485 [3]. Fuel level
                
                sensor with address 3.
                
                Relative fuel level and
                
                temperature
                
                3
                
                2 lower bytes: unsigned integer,
                
                relative fuel level.
                
                Higher byte: signed integer,
                
                temperature, °C
                
                81
                
                0x64
                
                RS485 [4]. Fuel level
                
                sensor with address 4.
                
                Relative fuel level and
                
                temperature
                
                3
                
                2 lower bytes: unsigned integer,
                
                relative fuel level.
                
                Higher byte: signed integer,
                
                temperature, °C
                
                Tags RS485[5] - RS485[14] (0x65-0x6E) are similar to RS485[4] with numbers 82-91
                
                92
                
                0x6F
                
                RS485 [15]. Fuel level
                
                sensor with address 15.
                
                Relative fuel level and temperature.
                
                3
                
                2 lower bytes: unsigned integer,
                
                relative fuel level.
                
                Higher byte: signed integer,
                
                temperature, °C
                
                93
                
                0x88
                
                Extended data RS232[0].
                
                Depending on settings:
                
                1. Temperature from fuel
                
                level sensors connected
                
                to RS232 0, °C
                
                2. Weight, received from
                
                weight identifier.
                
                1
                
                Signed integer
                
                94
                
                0x89
                
                Expanded data RS232[1].
                
                Depending on the settings:
                
                1. Temperature from fuel
                
                level sensors connected
                
                to Rs232[1], °C
                
                2. Weight received from
                
                weight identifier
                
                1
                
                Signed integer
                
                95
                
                0x8A
                
                Temperature from fuel
                
                level sensors connected
                
                to RS485 port with
                
                address 0, °C
                
                1
                
                Signed integer
                
                96
                
                0x8B
                
                Temperature from fuel
                
                level sensors connected
                
                to RS485 port with
                
                address 1, °C
                
                1
                
                Signed integer
                
                97
                
                0x8C
                
                Temperature from fuel
                
                level sensors connected
                
                to RS485 port with
                
                address 2, °C
                
                1
                
                Signed integer
                
                98
                0x78
                
                Input 8 value.
                Depending on the settings, one of the options is the following:
                1. voltage, mV;
                2. number of pulses;
                frequency, Hz.
                2
                Unsigned integer
                99
                0x79
                Input 9 value.
                Depending on the settings, one of the options is the following:
                1. voltage, mV;
                2. number of pulses;
                frequency, Hz.
                
                2
                Unsigned integer
                100
                0x7A
                Input 10 value.
                Depending on the settings, one of the options is the following:
                1. voltage, mV;
                2. number of pulses;
                frequency, Hz.
                
                2
                Unsigned integer
                101
                0x7B
                Input 11 value.
                Depending on the settings, one of the options is the following:
                1. voltage, mV;
                2. number of pulses;
                frequency, Hz.
                
                2
                Unsigned integer
                102
                0x7C
                Input 12 value.
                Depending on the settings, one of the options is the following:
                1. voltage, mV;
                2. number of pulses;
                frequency, Hz.
                
                2
                Unsigned integer
                103
                0x7D
                Input 13 value.
                Depending on the settings, one of the options is the following:
                1. voltage, mV;
                2. number of pulses;
                frequency, Hz.
                
                2
                Unsigned integer
                104
                0x21
                Milliseconds
                2
                Unsigned integer, the number of milliseconds (0 to 999) completes the date and time value
                129
                
                0xA0
                
                CAN8BITR15 or the eighth
                
                byte in the procedure for
                
                receiving of prefix WA
                
                CAN-LOG
                
                1
                
                Accessible only by a dynamic archive
                
                structure
                
                Tags CAN8BITR16 - CAN8BITR29 (0xA1-0xAE) similar to CAN8BITR16 with numbers 130-143
                
                144
                
                0xAF
                
                CAN8BITR30
                
                1
                
                Accessible only by the dynamic archive structure
                
                145
                
                0xB0
                
                CAN16BITR5
                
                2
                
                Accessible only by the dynamic archive
                
                structure
                
                Tags CAN16BITR6 – CAN16BITR13 (0xB1-0xB8) similar to CAN16BITR5 with numbers 146-153
                
                154
                
                0xB9
                
                CAN16BITR14
                
                2
                
                Accessible only by the dynamic archive
                
                structure
                
                161
                
                0xF0
                
                CAN32BITR5
                
                4
                
                Accessible only by the dynamic archive
                
                structure
                
                Tags CAN32BITR6 – CAN32BITR13 (0xF1-0xF8) similar to CAN32BITR5 with numbers 162-169
                
                170
                
                0xF9
                
                CAN32BITR14
                
                4
                
                Accessible only by the dynamic archive
                
                structure
                
                171
                
                0x5A
                
                REP-500 electricity meter
                
                readings
                
                4
                
                Unsigned integer
                
                173
                
                0x5B
                
                Refrigeration unit data
                
                 
                
                See the format below
                
                174
                
                0x47
                
                EcoDrive and driving style
                
                determination
                
                4
                
                Accessible only by the dynamic archive
                
                structure.
                
                Unsigned integer.
                
                Lower byte: acceleration.
                
                The second byte: braking.
                
                The third byte: cornering acceleration.
                
                The fourth byte: strike on bumps.
                
                All accelerations are expressed in standard
                
                units, 100 = 1g = 9,8 m/s2
                
                175
                
                0x5C
                
                PressurePro tires pressure
                
                monitoring system, 34 sensors
                
                68
                
                Array from 34 structures per 2 bytes.
                
                Index in array corresponds to the sensor number.
                
                Data structure from sensor:
                
                Lower byte: unsigned integer, tire pressure, psi.
                
                Higher byte:
                
                Bit 0-2: temperature, from -40°С up
                
                to 100°C with the 20°C interval.
                
                Bit 3:1 – no connection with the sensor,
                
                0 –sensor is connected.
                
                Bit 4: identifier of sensor battery low charge.
                
                Bit 5-7: the reason of data sending
                
                from the sensor.
                
                000 – occassional sending.
                
                001 – pressure decrease by 10%
                for PressurePro or by 12,5% for TPMS.
                
                010 – pressure decrease by 20%
                for PressurePro or by 25% for TPMS.
                
                100 – high temperature for TPMS.
                
                101 – rapid pressure decrease for TPMS.
                
                011 – pressure decrease by 50% for TPMS.
                
                110 – the tire is inflated for PressurePro
                or high pressure for TPMS.
                
                111 - New Magnet for PressurePro
                
                176
                
                0x5D
                
                DBG-S11Ddosimeter data
                
                3
                
                2 lower bytes: ADER, 3V/h,
                
                unsigned integer, (xxxxxxyy yyyyyyyy –
                
                x-order, y – floating-point coefficient).
                
                Higher byte: dosimeter state.
                
                Bit 0-2: dose power and its indeterminacy
                
                value:
                
                000 –weighted average value is typed out
                
                via 2 channels
                
                001 –channel 1 value is typed out
                
                010 – channel 2 value is typed out
                
                101 – false value is typed out (device in
                
                testing mode)
                
                Bit 3 – channel 1 state: 0 – is off, 1 – is on.
                
                Bit 4: channel 1 state: 0 – OK, 1 – failure.
                
                Bit 5: channel 2 state: 0 – is off, 1 – is on.
                
                Bit 6: channel 2 state: 0 - OK, 1 - failure.
                
                Bit 7: economy mode: 0 –is off, 1 – is on.
                
                177
                
                0xE2
                
                User data 0
                
                4
                
                 
                
                User data tags with numbers 178-183
                
                184
                
                0xE9
                
                User data 7
                
                4
                
                 
                
                185
                
                0xEA
                
                UserArray
                
                 
                
                Lower byte is array length
                
                186
                
                Minimum data set
                
                
                188
                
                0x48
                
                Expanded status of the
                
                device
                
                2
                
                Bit 0 is the connection state to the primary
                
                server. 1 is “connected”, 0 is “not connected”.
                
                Bit 1 is GPRS session status. 1 is “on”,
                
                0 is “off”.
                
                Bit 2 is the sign of GSM jamming.
                
                1 is “GSM jamming detected”,
                
                0 is “no jamming detected”.
                
                Bit 3 is the connection state to the additional
                
                server. 1 is “connected”, 0 is “not connected”.
                
                Bit 4 is the sign of GPS/GLONASS
                
                 jamming. 1 is “jamming detected”,
                
                0 is “no jamming detected”
                
                Bit 5 is sign of connection to cable
                
                USB of device USB. 1 is “connected”,
                
                0 is “not connected.
                
                Bit 6 – sign of SD car presence in device. 
                
                1 – present, 0 – absent.
                
                191
                0x49
                Transmission channel
                1
                Bits 0 to 3 - transmission channel
                
                0001 GSM
                
                0010 WiFi
                
                0011 BLE
                
                Bits 4 to 7 - transmission path
                
                0001 Server
                
                0010 Hub
                
                192
                0x11
                Number of the current record in the archive
                4
                Unsigned integer
                193
                0x36
                PDOP (Position Dilution of Precision). GNSS Positioning Accuracy Metric
                1
                Unsigned integer, the value should be divided by 10.
                 
                
                0xFE
                
                Extended tags
                
                 
                
                Length is determined by the content
                
                of the tag
                
                
                Extended tags are transmitted as tag data of 0xFE.
                
                
                
                Extended tags
                №	Tag	Description	Parameter
                Length, byte	Format	Example
                1	0x0001	Tag Modbus 0	4	The result value must be divided by 100	 
                
                
                
                
                
                
                Modbus tags with numbers 1-31
                21
                0x0021
                Tag Bluetooth 0	4		 
                1-62 Bluetooth tags
                84
                0x0060
                Tag Bluetooth 63	4		 
                85
                0x0061
                Tag Modbus 32
                4	The result value must be divided by 100	 
                Tags Modbus with numbers 33-62
                128	0x0080	Tag Modbus 63	4	The result value must be divided by 100	 
                129
                0x0081	Cell identifier (CID)	2	 	 
                130	0x0082	Local area code (LAC)	2	 	 
                131	0x0083	Country code (MCC)	2	 	 
                132	0x0084	Operator code (MNC)	2	 	 
                133	0x0085	RSSI	1	 	 
                134	0x0086	Temperature sensor extended value tag 0	4	 	
                8600 0600801A
                
                0600 — unsigned integer sensor ID (6),
                
                801A — real sign value (6784), the value must be divided by 256 (26,5)
                
                Extended temperature sensor tags numbered 1-6
                141	0x008D	Temperature sensor extended value tag 7	4	 	
                8D00 7F000080
                
                7F00 — unsigned integer sensor ID (127),
                
                0080 — real sign value (-32768), the value must be divided by 256 (-128)
                
                142	0x008E	GPS satellite information tag	4	 	
                8E00 0A051EAE
                
                0A – number of visible - 10 (1 byte, unsigned integer)
                
                05 — number of used - 5 (1 byte, unsigned integer)
                
                1E – SNR (signal/noise) average - 30 (1 byte, unsigned integer)
                
                33 – SNR max - 51 (1 byte, unsigned integer)
                
                143	0x008F	GLONASS satellite information tag	4	 	 
                144	0x0090	BAIDOU satellite information tag	4	 	 
                145	0x0091	GALILEO satellite information tag	4	 	 
                146
                0x0092
                Active SIM IMSI tag in hexadecimal ASCII format
                15
                
                9200 323530393938323037303239303531, where 323530393938323037303239303531 = 250998207029051
                147
                0x0093
                Currently used SIM card slot
                1
                
                
                148
                0x0094
                Active SIM CCID tag 
                20
                
                
                153
                
                0x00A4	Modem WIFI Status
                1
                
                Tag value:
                0 - Wi-Fi module disabled
                1 - Turn on Wi-Fi.
                2 - Turn off Wi-Fi.
                3 - Set Wi-Fi to initial state.
                4 - Select Wi-Fi.
                5 mode - Get a list of available Wi-Fi networks. Used to scan surrounding networks.
                6 - Connect to a given Wi-Fi network (access point, AP) .
                7 - Start your own access point. This state enables AP mode on the terminal, allowing other devices to connect to it.
                8 - Starting the server on the AP. The server on the terminal is activated when it operates as an access point.
                9 - Server session. In this mode, clients receive connections to the terminal server and process data from them.
                10 - Activation of client mode (STA) when the terminal is connected to a Wi-Fi network (access point, AP) .
                11 - Session in client mode. In this mode, the terminal connects to the specified servers and exchanges data with them.
                154
                0x00A5
                Current WIFI error code
                1
                
                Tag value:
                0 - No errors. Indicates no errors during Wi-Fi.
                1 - operation - TCP initialization failed. Indicates a problem initializing the TCP connection.
                2 - Driver initialization error. Indicates a problem when starting or initializing the driver Wi-Fi.
                3 - Firmware download error. Indicates a problem when downloading or updating Wi-Fi firmware module.
                4 - Error setting scan region. Indicates a problem when configuring the region to find available networks.
                5 - Deinitialization error. Indicates a problem when shutting down or clearing Wi-Fi resources on the module.
                6 - M2M connection error. Indicates a problem establishing a connection between M2M (Machine-to-Machine) devices.
                7 - Access Point (AP) connection failure. Indicates a problem when trying to connect to a Wi-Fi network.
                8 - Access point startup error. Indicates a problem when trying to start the device in access point mode.
                9 - Error getting RSSI value (signal strength). Indicates a problem while trying to measure the Wi-Fi signal level.
                10 - Access point disconnect error. Indicates a problem when trying to disable access point mode.
                11 - Client Shutdown Error (STA). Indicates a problem when trying to disable client mode Wi-Fi.
                12 - WLAN break time error. Indicates a problem with the connection break time interval Wi-Fi.
                13 - Error getting firmware information. Indicates a problem when trying to get information about the current firmware version.
                14 - Error getting MAC address. Indicates a problem when trying to get the Wi-Fi MAC address of the module.
                155
                0x00A6
                GSM modem status
                1
                
                Tag Value:
                0 - Initialized. Indicates that the system has been successfully initialized and is running normally.
                1 - Powered up. Indicates that the device is powered on and running.
                2 - Session restart required. Indicates that the GPRS session will be restarted.
                3 - Module restart required. Indicates whether the device module will be restarted.
                4 - Power is off. Indicates that the device is powered off.
                156
                0x00A7
                Network registration status
                1
                
                Tag value:
                0 - Not registered, the device does not look for an operator to register. Indicates that the device is not registered on the network and is not currently looking for available operators to connect.
                1 - Registered, home network. Indicates that the device has successfully registered with its home network.
                2 - Not registered, but the device is currently looking for a new operator to register. Indicates that the device is not registered but is actively looking for available networks to connect.
                3 - Registration denied. Indicates that an attempt to register with the network has been rejected.
                4 - Unknown (e.g. out of GERAN/UTRAN coverage). Indicates that the registration status is unknown, possibly due to lack of network coverage.
                5 - Registered, roaming. Indicates that the device is registered on the network but roaming (outside the home network).
                6 - Registered for "SMS only," home network. Indicates that the device is registered on its home network, but only for sending and receiving SMS.
                7 - Registered for SMS only, roaming. Indicates that the device is registered to send and receive SMS while roaming.
                8 - Counter of registration status types. Specifies the number of different types of registration statuss.
                255 - Undefined. Indicates that the registration status is uncertain or unknown.
                157
                0x00A8
                GPRS status
                1
                
                Established GPRS Session Feature:
                1 - Session Active
                0 - Session Inactive
                158
                0x00A9
                Amount of free RAM
                4
                Unsigned integer. Value in bytes
                
                160
                0x00AB
                Status of records in archive
                12
                Byte 0-3: total number of points (unsigned integer)
                Bytes 4-7: number of points sent to primary server (unsigned integer)
                Bytes 8-11: number of points sent to secondary server (unsigned integer)
                2E3F0000 3E020000 DD040000, where
                00003F2E is the unsigned integer total number of points (16174)
                00003E02 is the unsigned integer number of points sent to the primary server (15874)
                000004DD is the unsigned integer number of points sent to the secondary server (1245)
                161
                0x00AC
                Number of the last record in the archive
                4
                Unsigned integer
                
                163
                0x00AD
                MAC address WiFi
                6
                MAC address in HEX format
                0080C25E265A
                162
                0x00AE
                MAC address BLE
                6
                MAC address in HEX format
                80EACA004F3A
                164
                0x00AF
                self-troubleshooting
                14
                Data Structure:
                Bytes 0-7: Last Reset Date and Time (UNIX time)
                Bytes 8-9: Device Reboot Reason
                Bytes 10-13: Number of reboots due to 8-9 bytes
                1700 - System error in autoinformer operation
                100 - System error in GNSS module operation
                0 - System error during GPRS
                1200 - operation - System error in power supply circuit
                400 - System error when working with SD card or eMMC memory
                500 - Task system error I2C
                503 - Accelerometer System Error
                600 - 1-Wire
                1300 Interface System Error - System Task Error Outs
                1301 - Output State Control Errors
                1400 - System error in processing IN
                1401 input states - System error in system power control (Battery, USB, external voltage)
                1602 - Audio system error (autoinformer, voice communication on terminals with ublox 3G)
                300 - System error when writing to memory
                301 - System error when reading from memory
                1900-1908 - Processor errors
                
                8982DF6700000000 F701 09000000, where 0000000067DF8289 - date 03.23.2025 03:39:53 (1742701193 sec)
                01F7 - unsigned integer reason for rebooting the device (503)
                00000009 - unsigned integer number of reboots of the device (9)
                165
                0x00B0
                Total mean SNR
                1
                Unsigned integer
                If value:
                > 50 - level excellent
                from 30 to 50 - level good
                from 10 to 30 - level satisfactory
                < 10 - level poor
                166
                0x00B1
                SD card status
                1
                Unsigned integer
                Tag value:
                0 - Initialize and power up.
                1 - Initialize MSD
                2 - mode - MSD
                3 - mode - Mount FS
                4 - Monitor terminal, memory card and file system
                5 - Deinitialize SD card
                167
                0x00B2
                SD card errors
                1
                Unsigned integer
                Tag Value:
                0 - No Errors
                1 - SD Card Not Found or No External Feed
                2 - Failed to Mark File as Shipped
                3 - Failed to Get Main Data Package
                4 - Failed to Mark Record
                5 - Failed to Write
                168
                0x00B3
                Collector Archive Status
                12
                Byte 0-3: Total packets (unsigned integer)
                Bytes 4-7: Number of packets sent to primary server (unsigned integer)
                Bytes 8-11: Reserve
                2E3F0000 3E020000 DD040000
                where
                00003F2E is the unsigned integer total number of packets (16174)
                00003E02 is the unsigned integer number of packets sent to the primary server (15874)
                169
                0x00B4
                Client MAC address 1
                6
                MAC address in HEX format
                0080C25E4F3A
                170
                0x00B5
                Client MAC address 2
                6
                MAC address in HEX format
                
                171
                0x00B6
                Client MAC address 3
                6
                MAC address in HEX format
                
                217
                0x00D9
                TMPS wheel tag 0
                3
                
                Structure of the data from the sensor:
                
                Byte 0: unsigned integer, tyre pressure, psi
                
                Byte 1: signed integer, temperature, °C
                
                Byte 2:
                
                Bit 0: 1 - no communication with sensor. 0 - sensor is communicating
                
                Bit 1: sign of low sensor battery or sensor error
                
                Bit 2-4: the reason for sending data from the sensor
                
                000 - periodic sending.
                001 - 10% pressure loss for PressurePro or 12.5% TPMS.
                010 - 20% pressure loss for PressurePro or 25% pressure loss for TPMS.
                100 - high temperature for TPMS.
                101 - rapid pressure drop for TPMS.
                011 - 50% loss of pressure for TPMS.
                110 - tyre re-inflated for PressurePro or high pressure for TPMS.
                111 - New Magnet for PressurePro
                
                TMPS wheel tags 217 to 250
                250
                0x00FA
                TMPS wheel tag 33
                3
                
                
                252
                0x00FC
                Reason for recording an archive point
                1
                
                Tag values:
                1 - Periodic recording by device settings
                2 - iButton key events
                3 - Data from DataCOLD500 received
                4 - Data from EuroScan received 
                5 - Data from ThermoKing received
                8 - Device status changed
                9 - User record from pawn algorithm or script
                10 - Inputs event
                11 - Distance specified by the user in the settings was covered
                12 - Alarm by signalling settings was triggered
                13 - Emergency signal
                
                253
                0x00FD
                iButton64 tag
                8
                
                
                254
                0x00FE
                iButton64 2 tag
                8
                
                
                10020
                0x2724
                Engine Coolant Pressure 1 (Extended Range), kPa
                
                size depends on the tag content
                
                
                SPN tags 10021 to 32768
                32769
                0x8001
                Brake Wear Life Remaining, Trailer Axle #8, Left Wheel, %	size depends on the tag content
         */

    }
}
