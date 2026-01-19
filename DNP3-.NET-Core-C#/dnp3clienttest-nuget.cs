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
/*!	\file		dnp3clienttest-nuget.cs
 *	\brief 		C# Source code file, DNP3 Client/Master library test program for https://www.nuget.org/packages/dnp3_protocol/
 *
 *	\par 		FreyrSCADA Embedded Solution Pvt Ltd
 *				Email	: tech.support@freyrscada.com
 */
/*****************************************************************************/

/*! \brief - Client Physical Communication Medium */
#define CLIENT_TCP_COMMUNICATION 

/*! \brief - if serial communication not defined - use serial communication */
#if !CLIENT_TCP_COMMUNICATION
	#define CLIENT_SERIAL_COMMUNICATION 
#endif



/*! \brief - Enable traffic flags to show transmit and receive signal  */
//#define VIEW_TRAFFIC 

/*! \brief - In a loop simulate issue command - for particular Group-index, Value changes - issue a command to server  */
//#define SIMULATE_COMMAND 

using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dnp3clienttest
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
        * Client Connection Status callback
        ******************************************************************************/
        static short cbClientStatus(ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID psDAID, ref dnp3_protocol.dnp3types.eServerConnectionStatus peSat, ref short ptErrorValue)
	    {
            Console.WriteLine("\r\n cbClientstatus called");

            if (psDAID.eCommMode == dnp3_protocol.dnp3types.eCommunicationMode.COMM_SERIAL)
            {
                Console.WriteLine("Serial Port "+ psDAID.u16SerialPortNumber);
            }
            else
            {
                Console.WriteLine("IP Address "+ psDAID.ai8IPAddress);
                Console.WriteLine("Port "+ psDAID.u16PortNumber);
            }

            Console.WriteLine("Server Address : "+ psDAID.u16SlaveAddress);

            if (peSat == dnp3_protocol.dnp3types.eServerConnectionStatus.SERVER_CONNECTED)
            {
                Console.WriteLine("Server Connected");
            }
            else
            {
                Console.WriteLine("Server Not connected");
            }

            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Update IIN callback
        ******************************************************************************/
        static short cbUpdateIIN( ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID ptUpdateID, byte u8IIN1, byte u8IIN2, ref short ptErrorValue)
        {
            //u16ObjectId *= u16ObjectId;
            Console.WriteLine("\r\n cbUpdateIIN  changed , Object ID " + u16ObjectId);


            if (ptUpdateID.eCommMode == dnp3_protocol.dnp3types.eCommunicationMode.COMM_SERIAL)
            {
                Console.WriteLine("Serial Port "+ ptUpdateID.u16SerialPortNumber);
            }
            else
            {
                Console.WriteLine("IP Address "+ ptUpdateID.ai8IPAddress);
                Console.WriteLine("Port "+ ptUpdateID.u16PortNumber);
            }

            Console.WriteLine("Server Address : "+ ptUpdateID.u16SlaveAddress);
            


            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.BROADCAST) == (byte)(dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.BROADCAST))
            {
                Console.WriteLine("BROADCAST");
            }

            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.CLASS_1_EVENTS) == (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.CLASS_1_EVENTS)
            {
                Console.WriteLine("CLASS_1_EVENTS");
            }

            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.CLASS_2_EVENTS) == (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.CLASS_2_EVENTS)
            {
                Console.WriteLine("CLASS_2_EVENTS");
            }

            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.CLASS_3_EVENTS) == (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.CLASS_3_EVENTS)
            {
                Console.WriteLine("CLASS_3_EVENTS");
            }

            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.NEED_TIME) == (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.NEED_TIME)
            {
                Console.WriteLine("NEED_TIME");
            }

            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.LOCAL_CONTROL) == (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.LOCAL_CONTROL)
            {
                Console.WriteLine("LOCAL_CONTROL");
            }

            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.DEVICE_TROUBLE) == (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.DEVICE_TROUBLE)
            {
                Console.WriteLine("DEVICE_TROUBLE");
            }

            if ((u8IIN1 & (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.DEVICE_RESTART) == (byte)dnp3_protocol.dnp3types.eIINFirstByteBitsFlag.DEVICE_RESTART)
            {
                Console.WriteLine("DEVICE_RESTART");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.NO_FUNC_CODE_SUPPORT) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.NO_FUNC_CODE_SUPPORT)
            {
                Console.WriteLine("NO_FUNC_CODE_SUPPORT");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.OBJECT_UNKNOWN) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.OBJECT_UNKNOWN)
            {
                Console.WriteLine("OBJECT_UNKNOWN ");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.PARAMETER_ERROR) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.PARAMETER_ERROR)
            {
                Console.WriteLine("PARAMETER_ERROR ");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.EVENT_BUFFER_OVERFLOW) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.EVENT_BUFFER_OVERFLOW)
            {
                Console.WriteLine("EVENT_BUFFER_OVERFLOW");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.ALREADY_EXECUTING) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.ALREADY_EXECUTING)
            {
                Console.WriteLine("ALREADY_EXECUTING ");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.CONFIG_CORRUPT) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.CONFIG_CORRUPT)
            {
                Console.WriteLine("CONFIG_CORRUPT ");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.RESERVED_2) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.RESERVED_2)
            {
                Console.WriteLine("RESERVED_2 ");
            }

            if ((u8IIN2 & (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.RESERVED_1) == (byte)dnp3_protocol.dnp3types.eIINSecondByteBitsFlag.RESERVED_1)
            {
                Console.WriteLine("RESERVED_1");
            }
 
 

            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Update callback
        ******************************************************************************/
        static short cbUpdate(ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID ptUpdateID, ref dnp3_protocol.dnp3types.sDNP3DataAttributeData ptUpdateValue, ref dnp3_protocol.dnp3types.sDNP3UpdateParameters ptUpdateParams, ref short ptErrorValue)
        {
            Console.WriteLine("\r\n cbUpdate called");

            if (ptUpdateID.eCommMode == dnp3_protocol.dnp3types.eCommunicationMode.COMM_SERIAL)
            {
                Console.Write("Serial Port "+ ptUpdateID.u16SerialPortNumber);
            }
            else
            {
                Console.Write("IP Address " + ptUpdateID.ai8IPAddress);
                Console.Write("\t Port " + ptUpdateID.u16PortNumber);
            }

            Console.Write("\t Group ID : " + ptUpdateID.eGroupID);
            Console.Write("\t Server Address : " + ptUpdateID.u16SlaveAddress);
            Console.Write("\t Index No : {0}", ptUpdateID.u16IndexNumber);

            switch (ptUpdateID.eGroupID)
            {
                case dnp3_protocol.dnp3types.eDNP3GroupID.BINARY_INPUT:  /*!< Binary Input (DNP3Group 1) */
                case dnp3_protocol.dnp3types.eDNP3GroupID.DOUBLE_INPUT: /*!< Double-bit Binary Input Input (DNP3Group 3) */
                case dnp3_protocol.dnp3types.eDNP3GroupID.BINARY_OUTPUT:/*!< Binary Output (DNP3Group 10) */
                    Console.Write("\t Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadByte(ptUpdateValue.pvData));
                    break;


                case dnp3_protocol.dnp3types.eDNP3GroupID.COUNTER_INPUT: /*!< Counter Input (DNP3Group 20) */
                case dnp3_protocol.dnp3types.eDNP3GroupID.FRCOUNTER_INPUT: /*!< Frozen Counter Input (DNP3Group 21) */
                    Console.Write("\t Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt32(ptUpdateValue.pvData));
                    break;


                case dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_INPUT: /*!< Analog Input (DNP3Group 30) */
                case dnp3_protocol.dnp3types.eDNP3GroupID.FRANALOG_INPUT: /*!< Frozen Analog Input (DNP3Group 30) */
                case dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_OUTPUTS: /*!< Analog output (DNP3Group 40) */

                    if (ptUpdateValue.eDataType == dnp3_protocol.tgtcommon.eDataTypes.FLOAT32_DATA)
                    {
                        SingleInt32Union f32data;
                        f32data.f = 0;
                        f32data.i = System.Runtime.InteropServices.Marshal.ReadInt32(ptUpdateValue.pvData);
                        Console.Write("\t Data : {0:F3}", f32data.f);
                    }
                    else if (ptUpdateValue.eDataType == dnp3_protocol.tgtcommon.eDataTypes.SIGNED_DWORD_DATA)
                    {
                        Console.Write("\t Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt32(ptUpdateValue.pvData));
                    }
                    else
                         Console.WriteLine("\r\n Invalid datatype in Update callback - analog");;
                        break;



                case dnp3_protocol.dnp3types.eDNP3GroupID.OCTECT_STRING:
                case dnp3_protocol.dnp3types.eDNP3GroupID.VIRTUAL_TERMINAL_OUTPUT:
                        Console.Write("\t Data : " + ptUpdateValue.pvData);
                    break;

                default:
                    Console.Write("\t Invalid Group ID");
                    break;
            }

            if (ptUpdateValue.sTimeStamp.u16Year != 0)
            {

                Console.Write("\t Date : {0:D}-{1:D}-{2:D} ", ptUpdateValue.sTimeStamp.u8Day, ptUpdateValue.sTimeStamp.u8Month, ptUpdateValue.sTimeStamp.u16Year, ptUpdateValue.sTimeStamp.u8DayoftheWeek);

                Console.Write("\t Time : {0:D}:{1:D2}:{2:D2}:{3:D3}", ptUpdateValue.sTimeStamp.u8Hour, ptUpdateValue.sTimeStamp.u8Minute, ptUpdateValue.sTimeStamp.u8Seconds, ptUpdateValue.sTimeStamp.u16MilliSeconds, ptUpdateValue.sTimeStamp.u16MicroSeconds);
            }


            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.ONLINE) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.ONLINE)
            {
                Console.Write("\t ONLINE");
            }
            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.RESTART) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.RESTART)
            {
                Console.Write("\t RESTART");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.COMM_LOST) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.COMM_LOST)
            {
                Console.Write("\t COMM_LOST");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.REMOTE_FORCED) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.REMOTE_FORCED)
            {
                Console.Write("\t REMOTE_FORCED");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.LOCAL_FORCED) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.LOCAL_FORCED)
            {
                Console.Write("\t LOCAL_FORCED");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.CHATTER_FILTER) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.CHATTER_FILTER)
            {
                Console.Write("\t CHATTER_FILTER");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.ROLLOVER) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.ROLLOVER)
            {
                Console.Write("\t ROLLOVER");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.OVER_RANGE) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.OVER_RANGE)
            {
                Console.Write("\t OVER_RANGE");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.DISCONTINUITY) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.DISCONTINUITY)
            {
                Console.Write("\t DISCONTINUITY");
            }

            if ((ptUpdateValue.tQuality & (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.REFERENCE_ERR) == (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.REFERENCE_ERR)
            {
                Console.Write("\t REFERENCE_ERR");
            }

            Console.Write(" Update Group : {0}", ptUpdateParams.u8Group);
            Console.Write(" Variation : {0}", ptUpdateParams.u8Variation);

            if(ptUpdateParams.eUpCause == dnp3_protocol.dnp3types.eUpdateCause.STATIC_DATA)
                Console.Write(" Cause: Static Data");
            else if (ptUpdateParams.eUpCause == dnp3_protocol.dnp3types.eUpdateCause.POLLED_EVENT)
                Console.Write(" Cause: Polled Event");
            else if (ptUpdateParams.eUpCause == dnp3_protocol.dnp3types.eUpdateCause.UNSOLICITED_EVENT)
                Console.Write(" Cause: Unsolicited Event");

            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Device Attribute callback
        ******************************************************************************/
        static short cbDeviceAttribute(ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DataAttributeID psDAID, ref dnp3_protocol.dnp3types.sDNP3DeviceAttributeData psDeviceAttrValue, ref short ptErrorValue)
        {
            Console.WriteLine("\n\r\n cbDeviceAttrribute device attribute called");

            if (psDAID.eCommMode == dnp3_protocol.dnp3types.eCommunicationMode.COMM_SERIAL)
            {
                Console.WriteLine("Serial Port " + psDAID.u16SerialPortNumber);
            }
            else
            {
                Console.WriteLine("IP Address " + psDAID.ai8IPAddress);
                Console.WriteLine("Port " + psDAID.u16PortNumber);
            }

            Console.WriteLine("Server Address : " + psDAID.u16SlaveAddress);


            Console.WriteLine("Variation "+ psDeviceAttrValue.u8Variation);
            Console.WriteLine("Datatype "+ psDeviceAttrValue.u8Datatype);
            Console.WriteLine("Length "+ psDeviceAttrValue.u16Length);

            //datatype
            //1- vstr
            //2-uint
            //3-int
            //4-float
            //5-ostr
            //6-bstr
            //254 -u8bs8list

            do
            {
                if (psDeviceAttrValue.u16Length == 0)
                    break;

                if (psDeviceAttrValue.u8Datatype == 1)
                {
                    Console.WriteLine("VSTR : ", psDeviceAttrValue.u8Data);
                    break;
                }

                if (psDeviceAttrValue.u8Datatype == 254)
                {
                    //u8bs8list
                    byte nu8Count = 0;
                    while (nu8Count < psDeviceAttrValue.u16Length)
                    {
                        Console.WriteLine("Variation number "+ psDeviceAttrValue.u8Data[nu8Count++]);
                        Console.WriteLine(" Attribute Properties "+ psDeviceAttrValue.u8Data[nu8Count++]);
                    }

                    break;
                }

                Console.WriteLine("\r\n ");

                byte nu8Count1 = 0;

                for (nu8Count1 = 0; nu8Count1 < psDeviceAttrValue.u16Length; nu8Count1++)
                {
                    Console.WriteLine("  %02x", psDeviceAttrValue.u8Data[nu8Count1]);
                }

            } while (false);

            Console.WriteLine("\r\n");
            return (short)dnp3_protocol.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Debug callback
        ******************************************************************************/
        static short cbDebug(ushort u16ObjectId, ref dnp3_protocol.dnp3types.sDNP3DebugData psDebugData, ref short ptErrorValue)
        {
            //Console.WriteLine("\n\r\n cbDebug called");
            Console.WriteLine("\r\n");

            
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
            System.IntPtr DNP3Clienthandle;       // DNP3 Client object
            dnp3_protocol.dnp3types.sDNP3Parameters sParameters;    // DNP3 client object callback paramters 
            dnp3_protocol.dnp3types.sDNP3DataAttributeID sDAID;
            dnp3_protocol.dnp3types.sDNP3DataAttributeData sNewValue;
            dnp3_protocol.dnp3types.sDNP3CommandParameters sParams;                    // command data- date and time structute  

            System.Console.WriteLine("\n\r\n \t\t**** FreyrSCADA - DNP3 Client/Master Library Test ****");
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

            DNP3Clienthandle = System.IntPtr.Zero;
            sParameters = new dnp3_protocol.dnp3types.sDNP3Parameters();
            
            // Initialize parameters
            sParameters.eAppFlag = dnp3_protocol.tgtcommon.eApplicationFlag.APP_CLIENT;			            // This is a DNP3 client   
            sParameters.ptReadCallback = null;					                            // Read Callback
            sParameters.ptWriteCallback = null;				// Write Callback           
            sParameters.ptUpdateCallback = new dnp3_protocol.dnp3types.DNP3UpdateCallback(cbUpdate);					                        // Update Callback
            sParameters.ptSelectCallback = null;	// Select commands
            sParameters.ptOperateCallback =  null;// Operate commands
            sParameters.ptDebugCallback = new dnp3_protocol.dnp3types.DNP3DebugMessageCallback(cbDebug);		// Debug Callback
            sParameters.ptColdRestartCallback = null;    // ColdRestart Callback
            sParameters.ptWarmRestartCallback =  null;   // ColdRestart Callback
            sParameters.ptClientStatusCallback = new dnp3_protocol.dnp3types.DNP3ClientStatusCallback(cbClientStatus);  // client connection status callback
            sParameters.ptDeviceAttrCallback = new dnp3_protocol.dnp3types.DNP3DeviceAttributeCallback(cbDeviceAttribute); // Device attribute callback
            sParameters.ptUpdateIINCallback = new dnp3_protocol.dnp3types.DNP3UpdateIINCallback(cbUpdateIIN);  // IIN internal indication update callback
            sParameters.u32Options = 0;
            sParameters.u16ObjectId = 1;
            
            short iErrorCode = 0;                                                         // API Function return error paramter
            short ptErrorValue = 0;                                                     // API Function return addtional error paramter

             do
            {
                // Create a Client object
                DNP3Clienthandle = dnp3_protocol.dnp3api.DNP3Create(ref sParameters, ref iErrorCode, ref ptErrorValue);
                if (DNP3Clienthandle == System.IntPtr.Zero)
                {
                    System.Console.WriteLine("DNP3 Create failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }



                 // Client load configuration - communication and protocol configuration parameters
                dnp3_protocol.dnp3types.sDNP3ConfigurationParameters sDNP3Config;
                sDNP3Config = new dnp3_protocol.dnp3types.sDNP3ConfigurationParameters();
                
#if VIEW_TRAFFIC
                sDNP3Config.sDNP3ClientSet.sDebug.u32DebugOptions = (uint)(dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX | dnp3_protocol.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX);
#else
	   sDNP3Config.sDNP3ClientSet.sDebug.u32DebugOptions = 0;
#endif

                date = DateTime.Now;
                //current date 
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Day = (byte)date.Day;
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Month = (byte)date.Month;
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u16Year = (ushort)date.Year;

                //time
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Hour = (byte)date.Hour;
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Minute = (byte)date.Minute;
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Seconds = (byte)date.Second;
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u16MilliSeconds = (ushort)date.Millisecond;
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u16MicroSeconds = 0;
                sDNP3Config.sDNP3ClientSet.sTimeStamp.i8DSTTime = 0; //No Day light saving time
                sDNP3Config.sDNP3ClientSet.sTimeStamp.u8DayoftheWeek = (byte)date.DayOfWeek;

                
                sDNP3Config.sDNP3ClientSet.benabaleUTCtime = 0;/*!< enable utc time/ local time*/
                sDNP3Config.sDNP3ClientSet.bUpdateCallbackCheckTimestamp = 0; /*!< if it true ,the timestamp change also create the updatecallback */
                sDNP3Config.sDNP3ClientSet.bAutoGenDNP3DataObjects = 1;

                sDNP3Config.sDNP3ClientSet.u16NoofClient = 1;


                dnp3_protocol.dnp3types.sClientObject[] psClientObjects = new dnp3_protocol.dnp3types.sClientObject[sDNP3Config.sDNP3ClientSet.u16NoofClient];
                sDNP3Config.sDNP3ClientSet.psClientObjects = System.Runtime.InteropServices.Marshal.AllocHGlobal(
                sDNP3Config.sDNP3ClientSet.u16NoofClient * System.Runtime.InteropServices.Marshal.SizeOf(psClientObjects[0]));



#if CLIENT_TCP_COMMUNICATION
    // tcp communication settings

     psClientObjects[0].eCommMode = dnp3_protocol.dnp3types.eCommunicationMode.TCP_IP_MODE;
     psClientObjects[0].sClientCommunicationSet.sEthernetCommsSet.ai8ToIPAddress = "127.0.0.1";
     psClientObjects[0].sClientCommunicationSet.sEthernetCommsSet.u16PortNumber = 20000;



#elif CLIENT_SERIAL_COMMUNICATION
   // serial communication settings

   psClientObjects[0].eCommMode =   dnp3.eCommunicationMode.COMM_SERIAL;


   psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialType = dnp3.eSerialTypes.SERIAL_RS232;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.u16SerialPortNumber = 1;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialBitRate = dnp3.eSerialBitRate.BITRATE_9600;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.eWordLength = dnp3.eSerialWordLength.WORDLEN_8BITS;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialParity = dnp3.eSerialParity.NONE;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.eStopBits = dnp3.eSerialStopBits.STOPBIT_1BIT;
   
	//Serial port flow control
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.bWinCTSoutputflow = 0;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.bWinDSRoutputflow = 0;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.eWinDTR = dnp3.eWinDTRcontrol.WIN_DTR_CONTROL_DISABLE;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.eWinRTS = dnp3.eWinRTScontrol.WIN_RTS_CONTROL_DISABLE;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.eLinuxFlowControl = dnp3.eLinuxSerialFlowControl.FLOW_NONE;


   psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16CharacterTimeout = 1;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16MessageTimeout = 0;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16InterCharacterDelay = 5;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16PostDelay = 0;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16PreDelay = 0;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u8CharacterRetries = 20;
   psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u8MessageRetries = 0;

 

#else
    System.Console.WriteLine("\r\n Invalid DNP3 Client Communication Medium");
    break;
#endif

                //Server protocol settings
   psClientObjects[0].sClientProtSet.u16MasterAddress = 2;
   psClientObjects[0].sClientProtSet.u16SlaveAddress = 1;
   psClientObjects[0].sClientProtSet.u32LinkLayerTimeout = 10000;
   psClientObjects[0].sClientProtSet.u32ApplicationTimeout = 20000;
   psClientObjects[0].sClientProtSet.u32Class0123pollInterval = 60000;
   psClientObjects[0].sClientProtSet.u32Class123pollInterval = 1000;
   psClientObjects[0].sClientProtSet.u32Class0pollInterval = 0;                              /*!<CLASS 0 poll interval in milliSeconds (minimum 1000ms - to max)*/
   psClientObjects[0].sClientProtSet.u32Class1pollInterval = 0;                              /*!<CLASS 1 poll interval in milliSeconds (minimum 1000ms - to max)*/
   psClientObjects[0].sClientProtSet.u32Class2pollInterval = 0;                              /*!<CLASS 2 poll interval in milliSeconds (minimum 1000ms - to max)*/
   psClientObjects[0].sClientProtSet.u32Class3pollInterval = 0;                              /*!<CLASS 3 poll interval in milliSeconds (minimum 1000ms - to max)*/
   psClientObjects[0].sClientProtSet.bFrozenAnalogInputSupport = 0;                          /*!<False- stack will not create points for frozen analog input.*/
   psClientObjects[0].sClientProtSet.bEnableFileTransferSupport = 0;
   psClientObjects[0].sClientProtSet.bDisableUnsolicitedStatup = 0;
   psClientObjects[0].sClientProtSet.bDisableResetofRemotelink = 0;
   psClientObjects[0].u32CommandTimeout = 50000;
   psClientObjects[0].u32FileOperationTimeout = 200000;

   //Define number of objects
   psClientObjects[0].u16NoofObject = 0;
   psClientObjects[0].psDNP3Objects = System.IntPtr.Zero;





     IntPtr tmp1 = new IntPtr(sDNP3Config.sDNP3ClientSet.psClientObjects.ToInt64());
   System.Runtime.InteropServices.Marshal.StructureToPtr(psClientObjects[0], tmp1, true);


                // Load configuration
    iErrorCode = dnp3_protocol.dnp3api.DNP3LoadConfiguration(DNP3Clienthandle, ref sDNP3Config, ref ptErrorValue);
    if(iErrorCode != 0)
    {
        System.Console.WriteLine("DNP3 Load failed");
        System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
        System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
        break;
    }

                // Start server
                iErrorCode = dnp3_protocol.dnp3api.DNP3Start(DNP3Clienthandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("DNP3 Start failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }


#if SIMULATE_COMMAND
                      
             
    sDAID = new dnp3_protocol.dnp3types.sDNP3DataAttributeID();
    sNewValue = new dnp3_protocol.dnp3types.sDNP3DataAttributeData();
    sParams = new dnp3_protocol.dnp3types.sDNP3CommandParameters();                    // command data- date and time structute  

    //command parameters
#if  CLIENT_TCP_COMMUNICATION
    sDAID.eCommMode    =   dnp3_protocol.dnp3types.eCommunicationMode.TCP_IP_MODE;
    sDAID.u16PortNumber = 20000;
    sDAID.ai8IPAddress = "127.0.0.1";

#elif  CLIENT_SERIAL_COMMUNICATION
    sDAID.eCommMode    =   dnp3.eCommunicationMode.COMM_SERIAL;
    sDAID.u16SerialPortNumber  =   2;
#endif

    sDAID.eGroupID = dnp3_protocol.dnp3types.eDNP3GroupID.ANALOG_OUTPUTS;
    sDAID.u16SlaveAddress = 1;
    sDAID.u16IndexNumber = 6;
    sDAID.pvUserData = IntPtr.Zero;

    sNewValue.eDataSize = dnp3_protocol.tgttypes.eDataSizes.FLOAT32_SIZE;
    sNewValue.eDataType = dnp3_protocol.tgtcommon.eDataTypes.FLOAT32_DATA;
    sNewValue.tQuality = (ushort)dnp3_protocol.dnp3types.eDNP3QualityFlags.GOOD;
    sParams.eCommandVariation = dnp3_protocol.dnp3types.eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_FLOAT32;

    SingleInt32Union f32data;
    f32data.i = 0;
    f32data.f = (float)123.456;

   
    sNewValue.pvData = System.Runtime.InteropServices.Marshal.AllocHGlobal((int)dnp3_protocol.tgttypes.eDataSizes.FLOAT32_SIZE);
    sParams.u8Count    =   1;

                


#endif

                System.Console.WriteLine("Enter CTRL-X to Exit");
                Thread.Sleep(5000);

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

#if SIMULATE_COMMAND
                        date = DateTime.Now;
                                               
                        //current date 
                        sNewValue.sTimeStamp.u8Day = (byte)date.Day;
                        sNewValue.sTimeStamp.u8Month = (byte)date.Month;
                        sNewValue.sTimeStamp.u16Year = (ushort)date.Year;

                        //time
                        sNewValue.sTimeStamp.u8Hour = (byte)date.Hour;
                        sNewValue.sTimeStamp.u8Minute = (byte)date.Minute;
                        sNewValue.sTimeStamp.u8Seconds = (byte)date.Second;
                        sNewValue.sTimeStamp.u16MilliSeconds = (ushort)date.Millisecond;
                        sNewValue.sTimeStamp.u16MicroSeconds = 0;
                        sNewValue.sTimeStamp.i8DSTTime = 0; //No Day light saving time
                        sNewValue.sTimeStamp.u8DayoftheWeek = (byte)date.DayOfWeek;


                        f32data.f += 0.1f;


                        //Console.WriteLine("Command Measured Float Value {0:F}", f32data.f);

                        System.Runtime.InteropServices.Marshal.WriteInt32(sNewValue.pvData, f32data.i);

                        // Select before oberate command for analog output
                        iErrorCode = dnp3_protocol.dnp3api.DNP3SelectBeforeOperate(DNP3Clienthandle, ref sDAID, ref sNewValue, ref sParams, ref ptErrorValue);
                        if (iErrorCode != 0)
                        {
                            Console.WriteLine("dnp3 Library API Function - DNP3DNP3SelectBeforeOperate() Analog Output Command failed: {0:D} {1:D}", iErrorCode, ptErrorValue);
                            System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                            System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                            
                        }
#endif
                        Thread.Sleep(6000);
                    }


                }


                // Stop server
                iErrorCode = dnp3_protocol.dnp3api.DNP3Stop(DNP3Clienthandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("DNP3 stop failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

                // Free server
                iErrorCode = dnp3_protocol.dnp3api.DNP3Free(DNP3Clienthandle, ref ptErrorValue);
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
