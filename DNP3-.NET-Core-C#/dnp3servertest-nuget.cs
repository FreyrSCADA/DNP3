/******************************************************************************
*
* (c) 2026 by FreyrSCADA Embedded Solution Pvt Ltd
*
********************************************************************************
*
* Disclaimer: This program is an example and should be used as such.
*             If you wish to use this program or parts of it in your application,
*             you must validate the code yourself.  FreyrSCADA Embedded Solution Pvt Ltd
*             can not be held responsible for the correct functioning
*			  or coding of this example
*******************************************************************************/

/*****************************************************************************/
/*!	\file		dnp3servertest-nuget.cs
 *	\brief 		C# Source code file, DNP3 Outstation library test program for https://www.nuget.org/packages/dnp3_protocol/
 *
 *	\par 		FreyrSCADA Embedded Solution Pvt Ltd
 *				Email	: tech.support@freyrscada.com
 */
/*****************************************************************************/

/*! \brief - Server Physical Communication Medium */
#define SERVER_TCP_COMMUNICATION 

/*! \brief - if serial communication not defined - use serial communication */
#if !SERVER_TCP_COMMUNICATION
	#define SERVER_SERIAL_COMMUNICATION 
#endif


/*! \brief - Enable traffic flags to show transmit and receive signal  */
//#define VIEW_TRAFFIC 

/*! \brief - In a loop simulate update - for particular Group-index, Value changes - generates a event  */
#define SIMULATE_UPDATE 



using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dnp3outstationtest
{
    class Program
    {
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
        struct SingleInt32Union
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public float f;
            [System.Runtime.InteropServices.FieldOffset(0)]
            public int i;
        }

        /******************************************************************************
        * ColdRestart Callback information
        ******************************************************************************/
        static short cbColdRestart( ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID psDAID, ref short ptErrorValue)
        {
            Console.WriteLine("\r\n cbColdRestart called");

            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        *  WarmRestart Callback information
        ******************************************************************************/
        static short cbWarmRestart( ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID psDAID, ref short ptErrorValue)
        {
            Console.WriteLine("\r\n cbWarmRestart called");

            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Select callback
        ******************************************************************************/
        static short cbSelect(ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID psSelectID, ref dnp3_protocol.dnp3types.sDNP3DataAttributeData psSelectValue, ref dnp3_protocol.dnp3types.sDNP3CommandParameters psSelectParams, ref short ptErrorValue)
        {
            Console.WriteLine("\r\n cbSelect called");

            if (psSelectID.eGroupID == dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_OUTPUTS)
            {
                Console.WriteLine("GROUP ID : ANALOG_OUTPUT");
                Console.WriteLine("Index Number " + psSelectID.u16IndexNumber);
                

                if (psSelectParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_FLOAT32)
                {
                    Console.WriteLine("Variation : ANALOG_OUTPUT_BLOCK_FLOAT32");
                    SingleInt32Union f32Data;
                    f32Data.f = 0;
                    f32Data.i = System.Runtime.InteropServices.Marshal.ReadInt32(psSelectValue.pvData);
                    Console.WriteLine("Data : {0:F3}", f32Data.f);

                }
                else if (psSelectParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER32)
                {
                    Console.WriteLine("Variation : ANALOG_OUTPUT_BLOCK_INTEGER32");
                    Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt32(psSelectValue.pvData));
                    
                }
                else if (psSelectParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER16)
                {
                    Console.WriteLine("Variation : ANALOG_OUTPUT_BLOCK_INTEGER16");
                    Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt16(psSelectValue.pvData));
                }
                else
                    Console.WriteLine("Invalid variation");


            }

            if (psSelectID.eGroupID == dnp3_protocol.dnp3types.eDNP3GroupID.BINARY_OUTPUT)
            {
                Console.WriteLine("GROUP ID : BINARY_OUTPUT");
                Console.WriteLine("Index Number " + psSelectID.u16IndexNumber);

                if (psSelectParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.CROB_G12V1)
                {
                    Console.WriteLine("Variation : CROB_G12V1");
                }
                else
                    Console.WriteLine("Invalid variation");


                Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadByte(psSelectValue.pvData));

                Console.WriteLine("Operation Type " + psSelectParams.eOPType);
                Console.WriteLine("Count " + psSelectParams.u8Count);
                Console.WriteLine("On time " + psSelectParams.u32ONtime);
                Console.WriteLine("Off time " + psSelectParams.u32OFFtime);
                Console.WriteLine("CR %u", psSelectParams.bCR);
            }

            Console.WriteLine("Date : {0:D}-{1:D}-{2:D}", psSelectValue.sTimeStamp.u8Day, psSelectValue.sTimeStamp.u8Month, psSelectValue.sTimeStamp.u16Year);

            Console.WriteLine("Time : {0:D}:{1:D2}:{2:D2}:{3:D3}", psSelectValue.sTimeStamp.u8Hour, psSelectValue.sTimeStamp.u8Minute, psSelectValue.sTimeStamp.u8Seconds, psSelectValue.sTimeStamp.u16MilliSeconds);


            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Operate callback
        ******************************************************************************/
        static short cbOperate( ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID psOperateID, ref dnp3_protocol.dnp3types.sDNP3DataAttributeData psOperateValue, ref dnp3_protocol.dnp3types.sDNP3CommandParameters psOperateParams, ref short ptErrorValue)
        {
            Console.WriteLine("\r\n cbOperate called");

            if (psOperateID.eGroupID == dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_OUTPUTS)
            {
                Console.WriteLine("GROUP ID : ANALOG_OUTPUT");
                Console.WriteLine("Index Number " + psOperateID.u16IndexNumber);


                if (psOperateParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_FLOAT32)
                {
                    Console.WriteLine("Variation : ANALOG_OUTPUT_BLOCK_FLOAT32");
                    SingleInt32Union f32Data;
                    f32Data.f = 0;
                    f32Data.i = System.Runtime.InteropServices.Marshal.ReadInt32(psOperateValue.pvData);
                    Console.WriteLine("Data : {0:F3}", f32Data.f);

                }
                else if (psOperateParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER32)
                {
                    Console.WriteLine("Variation : ANALOG_OUTPUT_BLOCK_INTEGER32");
                    Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt32(psOperateValue.pvData));

                }
                else if (psOperateParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER16)
                {
                    Console.WriteLine("Variation : ANALOG_OUTPUT_BLOCK_INTEGER16");
                    Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt16(psOperateValue.pvData));
                }
                else
                    Console.WriteLine("Invalid variation");


            }

            if (psOperateID.eGroupID == dnp3_protocol.dnp3types.eDNP3GroupID.BINARY_OUTPUT)
            {
                Console.WriteLine("GROUP ID : BINARY_OUTPUT");
                Console.WriteLine("Index Number " + psOperateID.u16IndexNumber);

                if (psOperateParams.eCommandVariation == dnp3_protocol.dnp3types.eCommandObjectVariation.CROB_G12V1)
                {
                    Console.WriteLine("Variation : CROB_G12V1");
                }
                else
                    Console.WriteLine("Invalid variation");


                Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadByte(psOperateValue.pvData));

                Console.WriteLine("Operation Type " + psOperateParams.eOPType);
                Console.WriteLine("Count " + psOperateParams.u8Count);
                Console.WriteLine("On time " + psOperateParams.u32ONtime);
                Console.WriteLine("Off time " + psOperateParams.u32OFFtime);
                Console.WriteLine("CR %u", psOperateParams.bCR);
            }

            Console.WriteLine("Date : {0:D}-{1:D}-{2:D}", psOperateValue.sTimeStamp.u8Day, psOperateValue.sTimeStamp.u8Month, psOperateValue.sTimeStamp.u16Year);

            Console.WriteLine("Time : {0:D}:{1:D2}:{2:D2}:{3:D3}", psOperateValue.sTimeStamp.u8Hour, psOperateValue.sTimeStamp.u8Minute, psOperateValue.sTimeStamp.u8Seconds, psOperateValue.sTimeStamp.u16MilliSeconds);


            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Debug callback
        ******************************************************************************/
        static short cbDebug( ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DebugData psDebugData, ref short ptErrorValue)
        {
            //Console.WriteLine("\r\n cbDebug called");

            Console.WriteLine("");

            
            if ((psDebugData.u32DebugOptions & (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX) == (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX)
            {


                if (psDebugData.eCommMode == dnp3_protocol.dnp3types.eCommunicationMode.COMM_SERIAL)
                {
                    Console.WriteLine("Rx Serial port " + psDebugData.u16ComportNumber + " <- ");
                }
                else
                {
                    Console.WriteLine("Rx IP " + psDebugData.ai8IPAddress + " Port " + psDebugData.u16PortNumber + " <- ");
                }
                
                for (ushort i = 0; i < psDebugData.u16RxCount; i++)
                    Console.Write("{0:X2} ", psDebugData.au8RxData[i]);

            }

            if ((psDebugData.u32DebugOptions & (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX) == (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX)
            {

                if (psDebugData.eCommMode == dnp3_protocol.dnp3types.eCommunicationMode.COMM_SERIAL)
                {
                    Console.WriteLine("Tx Serial port " + psDebugData.u16ComportNumber + " -> ");
                }
                else
                {
                    Console.WriteLine("Tx IP " + psDebugData.ai8IPAddress + " Port " + psDebugData.u16PortNumber + " -> ");
                }
                for (ushort i = 0; i < psDebugData.u16TxCount; i++)
                    Console.Write("{0:X2} ", psDebugData.au8TxData[i]);

            }

            if ((psDebugData.u32DebugOptions & (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_ERROR) == (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_ERROR)
            {
                Console.WriteLine("Error message " + psDebugData.au8ErrorMessage);
                Console.WriteLine("ErrorCode " + psDebugData.i16ErrorCode);
                Console.WriteLine("ErrorValue " + psDebugData.tErrorValue);
            }

            if ((psDebugData.u32DebugOptions & (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_WARNING) == (uint)dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_WARNING)
            {

                Console.WriteLine("Warning message " + psDebugData.au8WarningMessage);
                Console.WriteLine("ErrorCode " + psDebugData.i16ErrorCode);
                Console.WriteLine("ErrorValue " + psDebugData.tErrorValue);
            }

            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;

        }

        /******************************************************************************
        * Write callback
        ******************************************************************************/
        static short cbWrite( ushort u16ObjectId,  dnp3_protocol.dnp3types.eWriteFunctionID eFunctionID, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID ptWriteID, ref dnp3_protocol.dnp3types.sDNP3DataAttributeData ptWriteValue, ref dnp3_protocol.dnp3types.sDNP3WriteParameters ptWriteParams, ref short ptErrorValue)
        {
            Console.WriteLine("\r\n cbWrite called");

           // Console.WriteLine("Write Function ID " + eFunctionID);

            Console.WriteLine("Date : {0:D}-{1:D}-{2:D}", ptWriteValue.sTimeStamp.u8Day, ptWriteValue.sTimeStamp.u8Month, ptWriteValue.sTimeStamp.u16Year);

            Console.WriteLine("Time : {0:D}:{1:D2}:{2:D2}:{3:D3}", ptWriteValue.sTimeStamp.u8Hour, ptWriteValue.sTimeStamp.u8Minute, ptWriteValue.sTimeStamp.u8Seconds, ptWriteValue.sTimeStamp.u16MilliSeconds);


            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }



        /******************************************************************************
    * Error code - Print information
    ******************************************************************************/
        static string errorcodestring(short errorcode)
        {
            dnp3_protocol.dnp3types.sDNP3ErrorCode sDNP3ErrorCodeDes;
            sDNP3ErrorCodeDes = new dnp3_protocol.dnp3types.sDNP3ErrorCode();

            sDNP3ErrorCodeDes.iErrorCode = errorcode;
            
            dnp3_protocol.dnp3api.DNP3ErrorCodeString(ref sDNP3ErrorCodeDes);

            string returnmessage = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(sDNP3ErrorCodeDes.LongDes);

            return returnmessage;
        }

        /******************************************************************************
        * Error value - Print information
        ******************************************************************************/
        static string errorvaluestring(short errorvalue)
        {
            dnp3_protocol.dnp3types.sDNP3ErrorValue sDNP3ErrorValueDes;
            sDNP3ErrorValueDes = new dnp3_protocol.dnp3types.sDNP3ErrorValue();

            sDNP3ErrorValueDes.iErrorValue = errorvalue;

            dnp3_protocol.dnp3api.DNP3ErrorValueString(ref sDNP3ErrorValueDes);

            string returnmessage = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(sDNP3ErrorValueDes.LongDes);

            return returnmessage;
        }
	
	
 
        /******************************************************************************
        * main()
        ******************************************************************************/        
        static void Main(string[] args)
        {

            System.DateTime date;                   // update date and time structute
            System.IntPtr DNP3serverhandle;       // DNP3 Server object
            dnp3_protocol.dnp3types.sDNP3Parameters sParameters;    // DNP3 Server object callback paramters 

            System.Console.WriteLine("\r\n \t\t**** FreyrSCADA - DNP3 Outstation Library Test ****");

            try
            {
                if (String.Compare(System.Runtime.InteropServices.Marshal.PtrToStringAnsi(dnp3_protocol.dnp3api.DNP3GetLibraryVersion()), dnp3_protocol.dnp3api.DNP3_VERSION, true) != 0)
                {
                    System.Console.WriteLine("\r\nError: Version Number Mismatch");
                    System.Console.WriteLine("Library Version is : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(dnp3_protocol.dnp3api.DNP3GetLibraryVersion()));
                    System.Console.WriteLine("The Version used is : {0:D}", dnp3_protocol.dnp3api.DNP3_VERSION);
                    System.Console.Write("Press <Enter> to exit... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    return;
                }
            }
            catch (DllNotFoundException e)
            {
                System.Console.WriteLine(e.ToString());
                System.Console.Write("Press <Enter> to exit... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                return;
            }

            System.Console.WriteLine("Library Version is : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(dnp3_protocol.dnp3api.DNP3GetLibraryVersion()));
            System.Console.WriteLine("Library Build on   : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(dnp3_protocol.dnp3api.DNP3GetLibraryBuildTime()));
            System.Console.WriteLine("Library Licence Information  : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(dnp3_protocol.dnp3api.DNP3GetLibraryLicenseInfo()));


            DNP3serverhandle = System.IntPtr.Zero;
            sParameters = new dnp3_protocol.dnp3types.sDNP3Parameters();
            
            // Initialize parameters
            sParameters.eAppFlag = dnp3_protocol.tgtcommon.eApplicationFlag.APP_SERVER;			            // This is a DNP3 Server   
            sParameters.ptReadCallback = null;					                            // Read Callback
            sParameters.ptWriteCallback = new dnp3_protocol.dnp3types.DNP3WriteCallback(cbWrite);				// Write Callback           
            sParameters.ptUpdateCallback = null;					                        // Update Callback
            sParameters.ptSelectCallback = new dnp3_protocol.dnp3types.DNP3ControlSelectCallback(cbSelect);	// Select commands
            sParameters.ptOperateCallback =  new dnp3_protocol.dnp3types.DNP3ControlOperateCallback(cbOperate);// Operate commands
            sParameters.ptDebugCallback =  new dnp3_protocol.dnp3types.DNP3DebugMessageCallback(cbDebug);		// Debug Callback
            sParameters.ptColdRestartCallback = new dnp3_protocol.dnp3types.DNP3ColdRestartCallback(cbColdRestart);    // ColdRestart Callback
            sParameters.ptWarmRestartCallback =  new dnp3_protocol.dnp3types.DNP3WarmRestartCallback(cbWarmRestart);   // ColdRestart Callback
            sParameters.ptClientStatusCallback = null;  // client connection status callback
            sParameters.ptDeviceAttrCallback = null; // Device attribute callback
            sParameters.ptUpdateIINCallback = null;  // IIN internal indication update callback
            sParameters.u16ObjectId = 1;				    //Server ID which used in callbacks to identify the DNP3 server object   

            sParameters.u32Options = 0;
            short iErrorCode = 0;                                                         // API Function return error paramter
            short ptErrorValue = 0;                                                     // API Function return addtional error paramter

             do
            {
                // Create a server object
                DNP3serverhandle = dnp3_protocol.dnp3api.DNP3Create(ref sParameters, ref iErrorCode, ref ptErrorValue);
                if (DNP3serverhandle == System.IntPtr.Zero)
                {
                    System.Console.WriteLine("DNP3 Library API Function - Create failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }


                 // Server load configuration - communication and protocol configuration parameters
                dnp3_protocol.dnp3types.sDNP3ConfigurationParameters sDNP3Config;
                sDNP3Config = new dnp3_protocol.dnp3types.sDNP3ConfigurationParameters();

#if SERVER_TCP_COMMUNICATION

   // tcp communication settings
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.eCommMode                     =   dnp3_protocol.dnp3types.eCommunicationMode.TCP_IP_MODE;

   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sEthernetCommsSet.sEthernetportSet.ai8FromIPAddress = "127.0.0.1";  // Server works on every interface
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sEthernetCommsSet.sEthernetportSet.u16PortNumber = 20000;
   

#elif SERVER_SERIAL_COMMUNICATION

    //serial communication setting
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.eCommMode =   dnp3.eCommunicationMode.COMM_SERIAL;

                 

   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialType = dnp3.eSerialTypes.SERIAL_RS232;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.u16SerialPortNumber = 1;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialBitRate = dnp3.eSerialBitRate.BITRATE_9600;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eWordLength = dnp3.eSerialWordLength.WORDLEN_8BITS;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialParity = dnp3.eSerialParity.NONE;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eStopBits = dnp3.eSerialStopBits.STOPBIT_1BIT;
   
	//Serial port flow control
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.bWinCTSoutputflow = 0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.bWinDSRoutputflow = 0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eWinDTR = dnp3.eWinDTRcontrol.WIN_DTR_CONTROL_DISABLE;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eWinRTS = dnp3.eWinRTScontrol.WIN_RTS_CONTROL_DISABLE;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eLinuxFlowControl = dnp3.eLinuxSerialFlowControl.FLOW_NONE;


   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16CharacterTimeout = 1;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16MessageTimeout = 0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16InterCharacterDelay = 5;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16PostDelay = 0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16PreDelay = 0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u8CharacterRetries = 20;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u8MessageRetries = 0;

   
#else
    System.Console.WriteLine("\r\n Invalid DNP3 Server Communication Medium");
    break;
#endif


   //protocol communication settings
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16SlaveAddress                            =   1;          // slave address
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16MasterAddress                           =   2;          // master address
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u32LinkLayerTimeout                        =   10000;      // link layer time out in ms
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u32ApplicationLayerTimeout                 =   20000;      // app link layer time out in ms
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u32TimeSyncIntervalSeconds                     =   90;     // time sync bit will set for every 90 seconds, set high value, because every u32TimeSyncIntervalSeconds slave request time from master

    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarBI                               =   dnp3_protocol.dnp3types.eDefaultStaticVariationBinaryInput.BI_WITH_FLAGS;                      // Default Static variation Binary Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarDBI                              =   dnp3_protocol.dnp3types.eDefaultStaticVariationDoubleBitBinaryInput.DBBI_WITH_FLAGS;                // Default Static variation Double Bit Binary Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarBO                               =   dnp3_protocol.dnp3types.eDefaultStaticVariationBinaryOutput.BO_WITH_FLAGS;                      // Default Static variation Double Bit Binary Output
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarCI                               =   dnp3_protocol.dnp3types.eDefaultStaticVariationCounterInput.CI_32BIT_WITHFLAG;                      // Default Static variation counter Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarFzCI                             =   dnp3_protocol.dnp3types.eDefaultStaticVariationFrozenCounterInput.FCI_32BIT_WITHFLAGANDTIME;          // Default Static variation Frozen counter Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAI                               =   dnp3_protocol.dnp3types.eDefaultStaticVariationAnalogInput.AI_SINGLEPREC_FLOATWITHFLAG;                        // Default Static variation Analog Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarFzAI                             =   dnp3_protocol.dnp3types.eDefaultStaticVariationFrozenAnalogInput.FAI_SINGLEPRECFLOATWITHFLAG;        // Default Static variation frozen Analog Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAID                              =   dnp3_protocol.dnp3types.eDefaultStaticVariationAnalogInputDeadBand.DAI_SINGLEPRECFLOAT;            // Default Static variation Analog Input Deadband
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAO                               =   dnp3_protocol.dnp3types.eDefaultStaticVariationAnalogOutput.AO_SINGLEPRECFLOAT_WITHFLAG;    // Default Static variation Analog Output

    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarBI                                =   dnp3_protocol.dnp3types.eDefaultEventVariationBinaryInput.BIE_WITHOUT_TIME;               // Default event variation for binary input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarDBI                               =   dnp3_protocol.dnp3types.eDefaultEventVariationDoubleBitBinaryInput.DBBIE_WITH_ABSOLUTETIME;    // Default event variation for double bit binary input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarCI                                =   dnp3_protocol.dnp3types.eDefaultEventVariationCounterInput.CIE_32BIT_WITHFLAG_WITHTIME;            // Default event variation for Counter input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarAI                                =   dnp3_protocol.dnp3types.eDefaultEventVariationAnalogInput.AIE_SINGLEPREC_WITHTIME;                // Default event variation for Analog input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarFzCI                              =   dnp3_protocol.dnp3types.eDefaultEventVariationFrozenCounterInput.FCIE_32BIT_WITHFLAG_WITHTIME;       // Default event variation for Frozen counter input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarFzAI                              =   dnp3_protocol.dnp3types.eDefaultEventVariationFrozenAnalogInput.FAIE_SINGLEPREC_WITHTIME;           // Default event variation for Frozen Analog input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarBO = dnp3_protocol.dnp3types.eDefaultEventVariationBinaryOutput.BOE_WITH_TIME;               // Default event variation for binary Output
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarAO = dnp3_protocol.dnp3types.eDefaultEventVariationAnalogOutput.AOE_SINGLEPREC_WITHTIME;                // Default event variation for Analog Output
    
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class1EventBufferSize = 50;    // class 1 buffer size number of events to store
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class1EventBufferOverFlowPercentage = 90;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class2EventBufferSize = 50;    // class 2 buffer size number of events to store
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class2EventBufferOverFlowPercentage = 90;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class3EventBufferSize = 50;    // class 3 buffer size number of events to store
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class3EventBufferOverFlowPercentage = 90;

    date = DateTime.Now;


    //current date 
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Day = (byte)date.Day;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Month = (byte)date.Month;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16Year  = (ushort)date.Year;

    //time
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Hour  = (byte)date.Hour;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Minute = (byte)date.Minute;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Seconds = (byte)date.Second;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16MilliSeconds = (ushort)date.Millisecond;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16MicroSeconds = 0;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.i8DSTTime = 0; //No Day light saving time
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8DayoftheWeek = (byte)date.DayOfWeek;

    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBIinClass0    =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddDBIinClass0   =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBOinClass0    =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddCIinClass0    =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzCIinClass0  =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIinClass0    =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzAIinClass0  =   0;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIDinClass0   =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAOinClass0    =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddOSinClass0    =   1;


    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBIEvent       =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddDBIEvent      =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBOEvent       =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddCIEvent       =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzCIEvent     =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIEvent       =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzAIEvent     =   0;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIDEvent      =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAOEvent       =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddOSEvent       =   1;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddVTOEvent      =   1;

    sDNP3Config.sDNP3ServerSet.sServerProtSet.eAIDeadbandMethod     =   dnp3_protocol.dnp3types.eAnalogInputDeadbandMethod.DEADBAND_FIXED;                                  /*!< Analog Input Deadband Calculation method*/
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bFrozenAnalogInputSupport = 0;        /*!<False- stack will not create points for frozen analog input.*/
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bEnableSelfAddressSupport = 1;         /*!< Enable Self Address Support */
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bEnableFileTransferSupport = 0;       /*!< Enable File Transfr Support*/
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8IntialdatabaseQualityFlag = (byte)dnp3_protocol.dnp3types.eDNP3QualityFlags.ONLINE;       /*!< 0- OFFLINE, 1 BIT- ONLINE, 2 BIT-RESTART, 3 BIT -COMMLOST, MAX VALUE -7   */
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bLocalMode                    =   0;  /*!< if local mode set true, then -all remote command for binary output/ analog output   control statusset to not supported */
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bUpdateCheckTimestamp     =   0;      /*!< if it true ,the timestamp change also generate event  during the dnp3update */

    //Unsolicited Response Setttings
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.bEnableUnsolicited         =   0;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.bEnableResponsesonStartup  =   0;   // enable or disable unsolicited response to master
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u32Timeout                 =   5000;   // unsolicited response timeout in ms

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class1TriggerNumberofEvents   =   1;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class1HoldTimeAfterResponse = 1;

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class2TriggerNumberofEvents = 1;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class2HoldTimeAfterResponse = 1;

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class3TriggerNumberofEvents = 1;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class3HoldTimeAfterResponse = 1;

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u8Retries                      =   5;      // Unsolicited message retries
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16MaxNumberofEvents   =   1;

    // Debug option settings
#if VIEW_TRAFFIC
   sDNP3Config.sDNP3ServerSet.sDebug.u32DebugOptions = (uint)(dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX | dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX);
#else
	   sDNP3Config.sDNP3ServerSet.sDebug.u32DebugOptions     =   0;
#endif
    // Define number of objects
    sDNP3Config.sDNP3ServerSet.u16NoofObject                             =   4;


    // Allocate memory for objects


                // Allocate memory for objects
                dnp3_protocol.dnp3types.sDNP3Object[] psDNP3Objects = new dnp3_protocol.dnp3types.sDNP3Object[sDNP3Config.sDNP3ServerSet.u16NoofObject];
                sDNP3Config.sDNP3ServerSet.psDNP3Objects = System.Runtime.InteropServices.Marshal.AllocHGlobal(
                    sDNP3Config.sDNP3ServerSet.u16NoofObject * System.Runtime.InteropServices.Marshal.SizeOf(psDNP3Objects[0]));
                for (int i = 0; i < sDNP3Config.sDNP3ServerSet.u16NoofObject; ++i)
                {
                    switch (i)
                    {

                        case 0:
                            psDNP3Objects[0].ai8Name = "binary input 0-9";
                            psDNP3Objects[0].eGroupID       =   dnp3_protocol.dnp3types.eDNP3GroupID.BINARY_INPUT;
                            psDNP3Objects[0].u16NoofPoints  =   10;
                            psDNP3Objects[0].eClassID       =   dnp3_protocol.dnp3types.eDNP3ClassID.CLASS_THREE;
                            psDNP3Objects[0].eControlModel  =   dnp3_protocol.dnp3types.eDNP3ControlModelConfig.INPUT_STATUS_ONLY;
                            psDNP3Objects[0].u32SBOTimeOut  =   0;
                            psDNP3Objects[0].f32AnalogInputDeadband  =   0;
                            psDNP3Objects[0].eAnalogStoreType = dnp3_protocol.dnp3types.eAnalogStorageType.AS_FLOAT;
                            break;

                        case 1:
                            psDNP3Objects[1].ai8Name ="binary output 0-9";
                            psDNP3Objects[1].eGroupID = dnp3_protocol.dnp3types.eDNP3GroupID.BINARY_OUTPUT;
                            psDNP3Objects[1].u16NoofPoints  =   10;
                            psDNP3Objects[1].eClassID = dnp3_protocol.dnp3types.eDNP3ClassID.NO_CLASS;
                            psDNP3Objects[1].eControlModel = dnp3_protocol.dnp3types.eDNP3ControlModelConfig.SELECT_BEFORE_OPERATION;
                            psDNP3Objects[1].u32SBOTimeOut  =   5000;
                            psDNP3Objects[1].f32AnalogInputDeadband  =  0;
                            psDNP3Objects[1].eAnalogStoreType = dnp3_protocol.dnp3types.eAnalogStorageType.AS_FLOAT;
                            break;

                        case 2:
                            psDNP3Objects[2].ai8Name = "analog input 0-9";
                            psDNP3Objects[2].eGroupID = dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_INPUT;
                            psDNP3Objects[2].u16NoofPoints = 10;
                            psDNP3Objects[2].eClassID = dnp3_protocol.dnp3types.eDNP3ClassID.CLASS_ONE;
                            psDNP3Objects[2].eControlModel = dnp3_protocol.dnp3types.eDNP3ControlModelConfig.INPUT_STATUS_ONLY;
                            psDNP3Objects[2].u32SBOTimeOut = 0;
                            psDNP3Objects[2].f32AnalogInputDeadband = 0;
                            psDNP3Objects[2].eAnalogStoreType = dnp3_protocol.dnp3types.eAnalogStorageType.AS_FLOAT;
                            break;

                        case 3:
                            psDNP3Objects[3].ai8Name = "analog output 0-9";
                            psDNP3Objects[3].eGroupID = dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_OUTPUTS;
                            psDNP3Objects[3].u16NoofPoints  =   10;
                            psDNP3Objects[3].eClassID = dnp3_protocol.dnp3types.eDNP3ClassID.NO_CLASS;
                            psDNP3Objects[3].eControlModel = dnp3_protocol.dnp3types.eDNP3ControlModelConfig.SELECT_BEFORE_OPERATION;
                            psDNP3Objects[3].u32SBOTimeOut  =   5000;
                            psDNP3Objects[3].f32AnalogInputDeadband  =  0;
                            psDNP3Objects[3].eAnalogStoreType = dnp3_protocol.dnp3types.eAnalogStorageType.AS_FLOAT;
                            break;
                    }
                    IntPtr tmp = new IntPtr(sDNP3Config.sDNP3ServerSet.psDNP3Objects.ToInt64() + i * System.Runtime.InteropServices.Marshal.SizeOf(psDNP3Objects[0]));
                    System.Runtime.InteropServices.Marshal.StructureToPtr(psDNP3Objects[i], tmp, true);
                }

                // Load configuration
                iErrorCode = dnp3_protocol.dnp3api.DNP3LoadConfiguration(DNP3serverhandle, ref sDNP3Config, ref ptErrorValue);
                if(iErrorCode != 0)
                {
                    System.Console.WriteLine("DNP3 Load failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

                // Start server
                iErrorCode = dnp3_protocol.dnp3api.DNP3Start(DNP3serverhandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("DNP3 Start failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }


#if SIMULATE_UPDATE
                // update id & parameters        
                ushort uiCount = 1;
                dnp3_protocol.dnp3types.sDNP3DataAttributeID[] psDAID = new dnp3_protocol.dnp3types.sDNP3DataAttributeID[uiCount];
                dnp3_protocol.dnp3types.sDNP3DataAttributeData[] psNewValue = new dnp3_protocol.dnp3types.sDNP3DataAttributeData[uiCount];
                                             


                psDAID[0].u16SlaveAddress = 1;
                psDAID[0].eGroupID = dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_INPUT;
                psDAID[0].u16IndexNumber = 6;

                psNewValue[0].eDataSize =  dnp3_protocol.tgttypes.eDataSizes.FLOAT32_SIZE;
                psNewValue[0].eDataType =  dnp3_protocol.tgtcommon.eDataTypes.FLOAT32_DATA;

                psDAID[0].pvUserData = IntPtr.Zero;
                psNewValue[0].tQuality = (ushort)(dnp3_protocol.dnp3types.eDNP3QualityFlags.ONLINE);
                psNewValue[0].pvData = System.Runtime.InteropServices.Marshal.AllocHGlobal((int)dnp3_protocol.tgttypes.eDataSizes.FLOAT32_SIZE);


                SingleInt32Union f32data;
                f32data.i = 0;
                f32data.f = 1;
                
#endif

                System.Console.WriteLine("\r\n Enter CTRL-X to Exit");


                while (true)
                {
                    if (Console.KeyAvailable) // since .NET 2.0
                    {
                        char c = Console.ReadKey().KeyChar;
                        if (c == 24)
                        {
                            break;
                        }
                    }
                    else
                    {

#if SIMULATE_UPDATE
                        date = DateTime.Now;
                        //current date 
                        psNewValue[0].sTimeStamp.u8Day = (byte)date.Day;
                        psNewValue[0].sTimeStamp.u8Month = (byte)date.Month;
                        psNewValue[0].sTimeStamp.u16Year = (ushort)date.Year;

                        //time
                        psNewValue[0].sTimeStamp.u8Hour = (byte)date.Hour;
                        psNewValue[0].sTimeStamp.u8Minute = (byte)date.Minute;
                        psNewValue[0].sTimeStamp.u8Seconds = (byte)date.Second;
                        psNewValue[0].sTimeStamp.u16MilliSeconds = (ushort)date.Millisecond;
                        psNewValue[0].sTimeStamp.u16MicroSeconds = 0;
                        psNewValue[0].sTimeStamp.i8DSTTime = 0; //No Day light saving time
                        psNewValue[0].sTimeStamp.u8DayoftheWeek = (byte)date.DayOfWeek;


                        f32data.f += 0.1f;



                        Console.WriteLine("Update Measured Float Value {0:F3}", f32data.f);

                        System.Runtime.InteropServices.Marshal.WriteInt32(psNewValue[0].pvData, f32data.i);
                        

                        // Update server
                        iErrorCode = dnp3_protocol.dnp3api.DNP3Update(DNP3serverhandle, ref psDAID[0], ref psNewValue[0], uiCount, dnp3_protocol.dnp3types.eUpdateClassID.UPDATE_DEFAULT_EVENT, ref ptErrorValue);
                        if (iErrorCode != 0)
                        {
                            Console.WriteLine("dnp3 Library API Function - DNP3Update() failed: {0:D} {1:D}", iErrorCode, ptErrorValue);
                            System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                            System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                            
                        }
#endif
                        Thread.Sleep(1000);
                    }


                }


                // Stop server
                iErrorCode = dnp3_protocol.dnp3api.DNP3Stop(DNP3serverhandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("DNP3 stop failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

                // Free server
                iErrorCode = dnp3_protocol.dnp3api.DNP3Free(DNP3serverhandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("DNP3 free failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

            } while (false);




            System.Console.WriteLine("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
         
    }            
}
