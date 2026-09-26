/******************************************************************************
*
* (c) 2026, 2027 by FreyrSCADA Embedded Solution Pvt Ltd
*
********************************************************************************
*
* Disclaimer: This program is an example and should be used as such.
*             If you wish to use this program or parts of it in your application,
*             you must validate the code yourself.  FreyrSCADA Embedded Solution Pvt Ltd
*             can not be held responsible for the correct functioning
*             or coding of this example
*******************************************************************************/

/*****************************************************************************/
/*! \file       dnp3clientapitest.c
 *  \brief      C Source code file, DNP3 Client library test program
 *
 *  \par        FreyrSCADA Embedded Solution Pvt Ltd
 *              Email   : tech.support@freyrscada.com
 */
/*****************************************************************************/

/******************************************************************************
* Includes
******************************************************************************/
#include <time.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <unistd.h>
#include <sys/time.h>
#include <termios.h>
#include <fcntl.h>
#include <terminalinput.h>

#include "dnp3api.h"



/*! \brief - Client Physical Communication Medium */
#define CLIENT_TCP_COMMUNICATION 1

/*! \brief - if serial communication not defined - use serial communication */
#ifndef CLIENT_TCP_COMMUNICATION
	#define CLIENT_SERIAL_COMMUNICATION 1
#endif


#ifdef CLIENT_SERIAL_COMMUNICATION
/*! \brief -  check computer configuration serial com port number,  if server and client application running in same system, we can use com0com */
	#define SERIAL_PORT_NUMBER 1 //ttyS1
#endif


  DNP3Object                              myClient         = NULL;         // DNP3 Client object
  Boolean viewtraffic =	FALSE;




/******************************************************************************
* Error code - Print information
******************************************************************************/
const char *  errorcodestring(int errorcode)
{
     struct sDNP3ErrorCode sDNP3ErrorCodeDes  = {0};
     const char *i8ReturnedMessage = " ";

     sDNP3ErrorCodeDes.iErrorCode = errorcode;

     DNP3ErrorCodeString(&sDNP3ErrorCodeDes);

     i8ReturnedMessage = sDNP3ErrorCodeDes.LongDes;

     return (i8ReturnedMessage);
}

/******************************************************************************
* Error value - Print information
******************************************************************************/
const char *  errorvaluestring(int errorvalue)
{
    struct sDNP3ErrorValue sDNP3ErrorValueDes  = {0};
     const char *i8ReturnedMessage = " ";

     sDNP3ErrorValueDes.iErrorValue = errorvalue;

     DNP3ErrorValueString(&sDNP3ErrorValueDes);

     i8ReturnedMessage = sDNP3ErrorValueDes.LongDes;

     return (i8ReturnedMessage);
}



/******************************************************************************
* Client Connection Status callback
******************************************************************************/
Integer16 cbClientStatus(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID, enum eServerConnectionStatus *peSat, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\ncbClientstatus called");
	printf("\r\nClient ID : %u", u16ObjectId);

    if(psDAID->eCommMode    ==  COMM_SERIAL)
    {
        printf("\t Serial Port %u", psDAID->u16SerialPortNumber);
    }
    else
    {
        printf("\t IP Address %s",psDAID->ai8IPAddress);
        printf("\t Port %u",psDAID->u16PortNumber);
    }

    printf("\t Server Address :%u",psDAID->u16SlaveAddress);

    if(*peSat == SERVER_CONNECTED)
    {
        printf("\r\nServer Connected");
    }
    else
    {
        printf("\r\nServer Not connected");
    }

    printf("\r\n");
    return i16ErrorCode;
}

/******************************************************************************
* Debug callback
******************************************************************************/
Integer16 cbDebug(Unsigned16 u16ObjectId,  struct sDNP3DebugData *ptDebugData, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;
    Unsigned16 u16nav                = 0;

    //printf("\r\ncbDebug() called");

	if(viewtraffic == TRUE)
	{

    if((ptDebugData->u32DebugOptions & DEBUG_OPTION_TX ) == DEBUG_OPTION_TX)
    {
        if(ptDebugData->eCommMode   ==  COMM_SERIAL)
        {
            printf("\r\nSerial port %u Transmit ->",ptDebugData->u16ComportNumber);
        }
        else
        {
            printf("\r\nIP %s Port %u Transmit ->", ptDebugData->ai8IPAddress, ptDebugData->u16PortNumber);
        }
        for(u16nav = 0; u16nav < (ptDebugData->u16TxCount); u16nav++)
        {
            printf(" %02x",ptDebugData->au8TxData[u16nav]);
        }
    }

    if((ptDebugData->u32DebugOptions & DEBUG_OPTION_RX ) == DEBUG_OPTION_RX)
    {
        if(ptDebugData->eCommMode   ==  COMM_SERIAL)
        {
            printf("\r\nSerial Port %u Receive <-",ptDebugData->u16ComportNumber);
        }
        else
        {
            printf("\r\nIP %s port %u Receive <-", ptDebugData->ai8IPAddress, ptDebugData->u16PortNumber);
        }


        for(u16nav = 0; u16nav < (ptDebugData->u16RxCount); u16nav++)
        {
            printf(" %02x",ptDebugData->au8RxData[u16nav]);
        }
    }

     if((ptDebugData->u32DebugOptions & DEBUG_OPTION_ERROR ) == DEBUG_OPTION_ERROR)
    {
        printf("\r\nError message %s", ptDebugData->au8ErrorMessage);
		printf("\r\nErrorCode %d", ptDebugData->i16ErrorCode);
        printf("\r\nErrorValue %d", ptDebugData->tErrorValue);
    }

    if((ptDebugData->u32DebugOptions & DEBUG_OPTION_WARNING ) == DEBUG_OPTION_WARNING)
    {
        printf("\r\nError message %s", ptDebugData->au8WarningMessage);
		printf("\r\nErrorCode %d", ptDebugData->i16ErrorCode);
        printf("\r\nErrorValue %d", ptDebugData->tErrorValue);
    }

    printf("\r\n");
	}

    return i16ErrorCode;
}

/******************************************************************************
* Update callback
******************************************************************************/
Integer16 cbUpdate(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, struct sDNP3DataAttributeData * ptUpdateValue,struct sDNP3UpdateParameters *ptUpdateParams, tErrorValue *ptErrorValue)
{

    Integer16 i16ErrorCode = EC_NONE;
    Unsigned8   u8data  =   0;
    Float32     f32data =   0;
    Integer32   i32data =   0;

    printf("\n\r\ncbUpdate called");
	printf("\r\nClient ID : %u", u16ObjectId);

    if(ptUpdateID->eCommMode    ==  COMM_SERIAL)
    {
        printf("\t Serial Port %u", ptUpdateID->u16SerialPortNumber);
    }
    else
    {
        printf("\t IP Address %s",ptUpdateID->ai8IPAddress);
        printf("\t Port %u",ptUpdateID->u16PortNumber);
    }

    printf("\t Group ID :%u",ptUpdateID->eGroupID);
    printf("\t Server Address :%u",ptUpdateID->u16SlaveAddress);
    printf("\t Index No :%u",ptUpdateID->u16IndexNumber);

    switch(ptUpdateID->eGroupID)
    {
    case BINARY_INPUT:  /*!< Binary Input (DNP3Group 1) */
        memcpy(&u8data,ptUpdateValue->pvData,sizeof(Unsigned8));
        printf("\t Data : %u",u8data);
        break;

    case DOUBLE_INPUT: /*!< Double-bit Binary Input Input (DNP3Group 3) */
        memcpy(&u8data,ptUpdateValue->pvData,sizeof(Unsigned8));
        printf("\t Data : %u",u8data);
        break;

    case BINARY_OUTPUT:/*!< Binary Output (DNP3Group 10) */
        memcpy(&u8data,ptUpdateValue->pvData,sizeof(Unsigned8));
        printf("\t Data : %u",u8data);
        break;

    case COUNTER_INPUT: /*!< Counter Input (DNP3Group 20) */
    case FRCOUNTER_INPUT: /*!< Frozen Counter Input (DNP3Group 21) */
        memcpy(&i32data,ptUpdateValue->pvData,sizeof(Integer32));
        printf("\t Data : %d",i32data);
        break;


    case ANALOG_INPUT: /*!< Analog Input (DNP3Group 30) */
    case FRANALOG_INPUT: /*!< Frozen Analog Input (DNP3Group 30) */
        if(ptUpdateValue->eDataType == FLOAT32_DATA)
        {
            memcpy(&f32data,ptUpdateValue->pvData,sizeof(Float32));
            printf("\t Data : %0.3f",f32data);
        }
        else if(ptUpdateValue->eDataType == SIGNED_DWORD_DATA)
        {
            memcpy(&i32data,ptUpdateValue->pvData,sizeof(Integer32));
           printf("\t Data : %d",i32data);
        }
        else
            printf("\r\n invalid datatype in update - analog");

        break;

    case ANALOG_OUTPUTS: /*!< Analog output (DNP3Group 40) */
                if(ptUpdateValue->eDataType == FLOAT32_DATA)
        {
            memcpy(&f32data,ptUpdateValue->pvData,sizeof(Float32));
            printf("\t Data : %0.3f",f32data);
        }
        else if(ptUpdateValue->eDataType == SIGNED_DWORD_DATA)
        {
            memcpy(&i32data,ptUpdateValue->pvData,sizeof(Integer32));
           printf("\t Data : %d",i32data);
        }
        else
            printf("\r\n invalid datatype in update - analog");

        break;

    case OCTECT_STRING:
    case VIRTUAL_TERMINAL_OUTPUT:
        printf("\t Data : %s",(char*)ptUpdateValue->pvData);
        break;

    default:
        printf("\t Invalid Group ID");
        break;
    }

    if( ptUpdateValue->sTimeStamp.u16Year != 0 )
    {
        printf( "\t Date : %u-%u-%u",ptUpdateValue->sTimeStamp.u8Day,ptUpdateValue->sTimeStamp.u8Month, ptUpdateValue->sTimeStamp.u16Year);

        printf( "\t Time : %u:%02u:%02u:%03u", ptUpdateValue->sTimeStamp.u8Hour, ptUpdateValue->sTimeStamp.u8Minute, ptUpdateValue->sTimeStamp.u8Seconds, ptUpdateValue->sTimeStamp.u16MilliSeconds );
    }

       if((ptUpdateValue->tQuality & ONLINE) == ONLINE)
       {
           printf(" ONLINE");
       }
        if((ptUpdateValue->tQuality & RESTART) == RESTART)
       {
           printf(" RESTART");
       }

      if((ptUpdateValue->tQuality & COMM_LOST) == COMM_LOST)
       {
           printf(" COMM_LOST");
       }

        if((ptUpdateValue->tQuality & REMOTE_FORCED) == REMOTE_FORCED)
       {
           printf(" REMOTE_FORCED");
       }

        if((ptUpdateValue->tQuality & LOCAL_FORCED) == LOCAL_FORCED)
       {
           printf(" LOCAL_FORCED");
       }

        if((ptUpdateValue->tQuality & CHATTER_FILTER) == CHATTER_FILTER)
       {
           printf(" CHATTER_FILTER");
       }

        if((ptUpdateValue->tQuality & ROLLOVER) == ROLLOVER)
       {
           printf(" ROLLOVER");
       }

        if((ptUpdateValue->tQuality & OVER_RANGE) == OVER_RANGE)
       {
           printf(" OVER_RANGE");
       }

       if((ptUpdateValue->tQuality & DISCONTINUITY) == DISCONTINUITY)
       {
           printf(" DISCONTINUITY");
       }

        if((ptUpdateValue->tQuality & REFERENCE_ERR) == REFERENCE_ERR)
       {
           printf(" REFERENCE_ERR");
       }

	    printf("\r\n");


    return i16ErrorCode;

}

/******************************************************************************
* Device Attribute callback
******************************************************************************/
Integer16 cbDeviceAtt(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID, struct sDNP3DeviceAttributeData * psDeviceAttrValue,  tErrorValue *ptErrorValue)
{
        Integer16 i16ErrorCode = EC_NONE;
        Unsigned8  nu8Count             =   0;

            printf("\n\r\ncbDeviceAttrribute device attribute called");
			printf("\r\nClient ID : %u", u16ObjectId);

            if(psDAID->eCommMode    ==  COMM_SERIAL)
            {
                printf("\t Serial port %u", psDAID->u16SerialPortNumber);
            }
            else
            {
                printf("\t IP Address %s",psDAID->ai8IPAddress);
                printf("\t Port %u",psDAID->u16PortNumber);
            }

            printf("\t Server Address :%u",psDAID->u16SlaveAddress);
            printf("\r\nVariation %u", psDeviceAttrValue->u8Variation);
            printf("\r\nDatatype %u", psDeviceAttrValue->u8Datatype);
            printf("\r\nLength %u", psDeviceAttrValue->u16Length);

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
                if(psDeviceAttrValue->u16Length ==  0)
                    break;

                if(psDeviceAttrValue->u8Datatype    ==  1)
                {
                    printf("\r\n VSTR : %s",psDeviceAttrValue->u8Data);
                    break;
                }

                if(psDeviceAttrValue->u8Datatype    ==  254)
                {
                    //u8bs8list
                    nu8Count    =   0;
                     while(nu8Count < psDeviceAttrValue->u16Length)
                     {
                         printf(" \r\n Variation number %u", psDeviceAttrValue->u8Data[nu8Count++]);
                         printf(" Attribute Properties %u", psDeviceAttrValue->u8Data[nu8Count++]);
                     }

                    break;
                }

                printf("\r\n ");
                for( nu8Count   =   0;  nu8Count < psDeviceAttrValue->u16Length; nu8Count++)
                {
                    printf("  %02x",psDeviceAttrValue->u8Data[nu8Count]);
                }

            }while(FALSE);

            printf("\r\n");

            return i16ErrorCode;
}


/******************************************************************************
* Update IIN callback
******************************************************************************/
Integer16 cbUpdateIIN(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, Unsigned8 u8IIN1, Unsigned8 u8IIN2,  tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;
    printf("\n\r\ncbUpdateIIN  changed ");
	printf("\r\nClient ID : %u", u16ObjectId);

    printf("\r\n ");

    if(ptUpdateID->eCommMode    ==  COMM_SERIAL)
    {
        printf("\t Serial Port %u", ptUpdateID->u16SerialPortNumber);
    }
    else
    {
        printf("\t IP Address %s",ptUpdateID->ai8IPAddress);
        printf("\t Port %u",ptUpdateID->u16PortNumber);
    }

    printf("\t Server Address :%u",ptUpdateID->u16SlaveAddress);


    if((u8IIN1 & BROADCAST) == BROADCAST)
    {
        printf("\t BROADCAST");
    }

    if((u8IIN1 & CLASS_1_EVENTS) == CLASS_1_EVENTS)
    {
        printf("\t CLASS_1_EVENTS");
    }

    if((u8IIN1 & CLASS_2_EVENTS) == CLASS_2_EVENTS)
    {
        printf("\t CLASS_2_EVENTS");
    }

    if((u8IIN1 & CLASS_3_EVENTS) == CLASS_3_EVENTS)
    {
        printf("\t CLASS_3_EVENTS");
    }

    if((u8IIN1 & NEED_TIME) == NEED_TIME)
    {
        printf("\t NEED_TIME");
    }

    if((u8IIN1 & LOCAL_CONTROL) == LOCAL_CONTROL)
    {
        printf("\t LOCAL_CONTROL");
    }

    if((u8IIN1 &  DEVICE_TROUBLE) ==  DEVICE_TROUBLE)
    {
        printf("\t  DEVICE_TROUBLE");
    }

    if((u8IIN1 &  DEVICE_RESTART ) ==  DEVICE_RESTART )
    {
        printf("\t  DEVICE_RESTART");
    }

    if((u8IIN2 &  NO_FUNC_CODE_SUPPORT ) ==  NO_FUNC_CODE_SUPPORT )
    {
        printf("\t  NO_FUNC_CODE_SUPPORT");
    }

    if((u8IIN2 &  OBJECT_UNKNOWN ) ==   OBJECT_UNKNOWN)
    {
        printf("\t  OBJECT_UNKNOWN ");
    }

    if((u8IIN2 &  PARAMETER_ERROR ) ==  PARAMETER_ERROR )
    {
        printf("\t PARAMETER_ERROR ");
    }

    if((u8IIN2 &   EVENT_BUFFER_OVERFLOW) ==   EVENT_BUFFER_OVERFLOW)
    {
        printf("\t  EVENT_BUFFER_OVERFLOW");
    }

    if((u8IIN2 &   ALREADY_EXECUTING) ==  ALREADY_EXECUTING )
    {
        printf("\t ALREADY_EXECUTING ");
    }

    if((u8IIN2 &  CONFIG_CORRUPT ) ==  CONFIG_CORRUPT )
    {
        printf("\t CONFIG_CORRUPT ");
    }

    if((u8IIN2 &  RESERVED_2 ) ==  RESERVED_2 )
    {
        printf("\t RESERVED_2 ");
    }

    if((u8IIN2 &  RESERVED_1 ) ==  RESERVED_1 )
    {
        printf("\t  RESERVED_1");
    }

    printf("\r\n");

    return i16ErrorCode;
}


void sendcommand()
{
	Integer16                    i16ErrorCode        = EC_NONE;      // API Function return error parameter
	tErrorValue                          tErrorValue         = EV_NONE;      // API Function return additional error paramter

    //command parameters
	struct sDNP3DataAttributeID      sDAID           = {0};                  // Command data identification parameters
	Float32                      f32Data         =   0.00;                   // command data
	//    Boolean bexit							=	FALSE;
	unsigned int	index =	0;

	struct sDNP3CommandParameters    sParams;                    // command data- date and time structute
	struct sDNP3DataAttributeData    sValue;                 // Command data value parameters

	time_t now;                                                              // to get current data and time
	struct tm * timeinfo;                                                    // Structure data and time

   	set_tty_cooked(); //Unix setup to reverse tty_set_raw()
   	printf("\r\n");

	printf ("Enter Index address to send command for Analog Output Group (0-9): ");
	scanf("%u", &index);
	printf("\r\n");

	printf ("Enter update float value: ");
	scanf("%f", &f32Data);
	printf("\r\n");
    //command parameters
#if defined (CLIENT_TCP_COMMUNICATION)
    sDAID.eCommMode    =   TCP_IP_MODE;
    sDAID.u16PortNumber    =   20000;
    strcpy((char*)sDAID.ai8IPAddress, "127.0.0.1");

#elif defined (CLIENT_SERIAL_COMMUNICATION)
    sDAID.eCommMode    =   COMM_SERIAL;
    sDAID.u16SerialPortNumber  =   SERIAL_PORT_NUMBER;
#endif

    sDAID.eGroupID =   ANALOG_OUTPUTS;
    sDAID.u16SlaveAddress  =   1;
    sDAID.u16IndexNumber   =   (Unsigned16)index;
    sValue.eDataSize   =   FLOAT32_SIZE;
    sValue.eDataType   =   FLOAT32_DATA;
    sValue.tQuality        =   GOOD;
    sValue.pvData      =   &f32Data;
    sParams.u8Count    =   1;
    sParams.eCommandVariation = ANALOG_OUTPUT_BLOCK_FLOAT32;



            time(&now);
            timeinfo = localtime(&now);
            timeinfo->tm_year += 1900;

            sValue.sTimeStamp.u8Day              =  (Unsigned8)timeinfo->tm_mday;
            sValue.sTimeStamp.u8Month            = (Unsigned8)(timeinfo->tm_mon + 1);
            sValue.sTimeStamp.u16Year            = timeinfo->tm_year;

            //time
            sValue.sTimeStamp.u8Hour             = (Unsigned8)timeinfo->tm_hour;
            sValue.sTimeStamp.u8Minute           = (Unsigned8)timeinfo->tm_min;
            sValue.sTimeStamp.u8Seconds          = (Unsigned8)(timeinfo->tm_sec);
            sValue.sTimeStamp.u16MilliSeconds    =   0;
            sValue.sTimeStamp.u16MicroSeconds    =   0;
            sValue.sTimeStamp.i8DSTTime          =   0; //No Day light saving time
            sValue.sTimeStamp.u8DayoftheWeek     =   4;

            // SelectBeforeOperate - Analog Output
            i16ErrorCode = DNP3DirectOperate(myClient, &sDAID, &sValue, &sParams, &tErrorValue);
            if(i16ErrorCode != EC_NONE)
            {
                printf("\r\n DNP3 Library API Function - DNP3DirectOperate() Analog output failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));

            }
			else
			{
				printf("\r\nDNP3 Library API Function - DNP3DirectOperate() Analog output Success");
			}


		set_tty_raw() ;  // Unix setup to read a character at a time.

		printf("\r\n");


}

/******************************************************************************
* main()
******************************************************************************/
int main (void)
{

   Integer16                    i16ErrorCode        = EC_NONE;      // API Function return error parameter
   tErrorValue                          tErrorValue         = EV_NONE;      // API Function return additional error paramter
   struct sDNP3Parameters               sParameters         = {0};          // DNP3 Client object callback paramters
  Boolean bexit							=	FALSE;
  Unsigned16                   u16Char         =   0;                      // Get control+x key to stop send command

   struct sDNP3ConfigurationParameters  sDNP3Config;            // Client protocol, point configuration parameters
   time_t now;                                                              // to get current data and time
   struct tm * timeinfo;                                                    // Structure data and time

do
{

     printf("\n\r\n \t\t**** DNP3 Protocol Client Library Test ****");

   //Check library version against the library header file
   if(strcmp((char*)DNP3GetLibraryVersion(), DNP3_VERSION) != 0)
   {
     printf("\r\n Error: Version Number Mismatch");
     printf("\r\n Library Version is  : %s", DNP3GetLibraryVersion());
     printf("\r\n The Version used is : %s", DNP3_VERSION);
     printf("\r\n");
     return 0;
   }

   printf("\r\nLibrary Version is : %s", DNP3GetLibraryVersion());
   printf("\r\nLibrary Build on   : %s", DNP3GetLibraryBuildTime());
   printf("\r\n Library License Information   : %s", DNP3GetLibraryLicenseInfo());


   //Initialize DNP3 Client object parameters
   memset(&sParameters,0,sizeof(struct sDNP3Parameters));

   sParameters.eAppFlag          = APP_CLIENT;       // This is a DNP3 CLIENT
   sParameters.ptReadCallback    = NULL;             // Read Callback
   sParameters.ptWriteCallback   = NULL;             // Write Callback
   sParameters.ptUpdateCallback  = cbUpdate;         // Update Callback
   sParameters.ptSelectCallback  = NULL;             // Select commands
   sParameters.ptOperateCallback = NULL;             // Operate commands
   sParameters.ptDebugCallback   = cbDebug;          // Debug Callback
   sParameters.ptUpdateIINCallback		= cbUpdateIIN;            // Update IIN Callback
   sParameters.ptClientStatusCallback   = cbClientStatus;         // Client connection Status Callback
   sParameters.ptDeviceAttrCallback     =   cbDeviceAtt;          // Device attribute callback
   sParameters.ptClientPollStatusCallback = NULL;
   sParameters.u32Options				= 0;
   sParameters.u16ObjectId				= 1;					  //Client ID which used in callbacks to identify the DNP3 client object

   //Create a Client object
   myClient = DNP3Create(&sParameters, &i16ErrorCode, &tErrorValue);
   if(myClient  == NULL)
   {
        printf("\r\nDNP3 Library API Function - DNP3Create() failed:  %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
        break;
   }

    //Client load configuration - communication and protocol configuration parameters

     memset(&sDNP3Config,0,sizeof(struct sDNP3ConfigurationParameters));


    //set debug option
    sDNP3Config.sDNP3ClientSet.sDebug.u32DebugOptions =    ( DEBUG_OPTION_TX | DEBUG_OPTION_RX);
    // sDNP3Config.sDNP3ClientSet.sDebug.u32DebugOptions  =   0;

    time(&now);
    timeinfo = localtime(&now);
    timeinfo->tm_year += 1900;

    sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Day             =   (Unsigned8)timeinfo->tm_mday;
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Month           =   (Unsigned8)(timeinfo->tm_mon + 1);
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u16Year           =   timeinfo->tm_year;
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Hour            =   (Unsigned8)timeinfo->tm_hour;
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Minute          =   (Unsigned8)timeinfo->tm_min;
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Seconds         =   (Unsigned8)(timeinfo->tm_sec);
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u16MilliSeconds   =   0;
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u16MicroSeconds   =   0;
    sDNP3Config.sDNP3ClientSet.sTimeStamp.i8DSTTime         =   0; //No Day light saving time
    sDNP3Config.sDNP3ClientSet.sTimeStamp.u8DayoftheWeek    =   4;


    sDNP3Config.sDNP3ClientSet.benabaleUTCtime = FALSE;/*!< enable utc time/ local time*/
    sDNP3Config.sDNP3ClientSet.bUpdateCallbackCheckTimestamp = FALSE; /*!< if it true ,the timestamp change also create the updatecallback */


    sDNP3Config.sDNP3ClientSet.u16NoofClient        =   1;
    sDNP3Config.sDNP3ClientSet.psClientObjects  =   NULL;
    sDNP3Config.sDNP3ClientSet.psClientObjects  =   (struct sClientObject*)calloc(sDNP3Config.sDNP3ClientSet.u16NoofClient, sizeof(struct sClientObject));
    if(sDNP3Config.sDNP3ClientSet.psClientObjects   ==  NULL)
    {
       printf("\r\n Error: Not enough memory to alloc objects");
       break;
    }



#if defined (CLIENT_TCP_COMMUNICATION)
    // tcp communication settings
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].eCommMode  =   TCP_IP_MODE;
   // check computer configuration - TCP/IP Address
   strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sEthernetCommsSet.ai8ToIPAddress,"127.0.0.1");
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sEthernetCommsSet.u16PortNumber    =   20000;

#elif defined (CLIENT_SERIAL_COMMUNICATION)
   // serial communication settings
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].eCommMode  =   COMM_SERIAL;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialType   = SERIAL_RS232;

/******************************************************************************
* Linux-Serial Port Number
* "/dev/ttyS0" to "/dev/ttyS9" portnumber 0-9
* "/dev/ttySP0" to "/dev/ttySP9" portnumber 10-19
* "/dev/ttyUSB0" to "/dev/ttyUSB9" portnumber 20-29
* "/dev/ttyAPP0" to "/dev/ttyAPP9" portnumber 30-39
* "/dev/ttyAMA0" to "/dev/ttyAMA9" portnumber 40-49
* "/dev/ttyAP0" to "/dev/ttyAP9" portnumber 50-59
* "/dev/ttyO0" to"/dev/ttyO9" port number 60-69
more details - support@freyrscada.com
******************************************************************************/
	// check computer configuration serial com port number,
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.u16SerialPortNumber =   SERIAL_PORT_NUMBER; // serial port /dev/ttyS1
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialBitRate =   BITRATE_9600;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eWordLength  =   WORDLEN_8BITS;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialParity  =   EVEN;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eStopBits =   STOPBIT_1BIT;

   //Serial port flow control
	sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.bWinCTSoutputflow         =  FALSE;
	sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.bWinDSRoutputflow         =  FALSE;
	sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.eWinDTR					  =	 WIN_DTR_CONTROL_DISABLE;
	sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.eWinRTS					  =  WIN_RTS_CONTROL_DISABLE;
	sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sFlowControl.eLinuxFlowControl         = FLOW_NONE;

   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16CharacterTimeout   =   1;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16MessageTimeout   =   0;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16InterCharacterDelay =   5;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16PostDelay   =   0;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16PreDelay        =   0;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u8CharacterRetries =   20;
   sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u8MessageRetries   =   0;
#else
    printf("\r\n Invalid DNP3 Client Communication Medium");
    getchar();
    return(0);
#endif

    //Server protocol settings
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u16MasterAddress           =   2;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u16SlaveAddress            =   1;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32LinkLayerTimeout        =   10000;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32ApplicationTimeout      =   20000;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class0123pollInterval   =   60000;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class123pollInterval    =   5000;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class0pollInterval      =   0;                              /*!<CLASS 0 poll interval in milliSeconds (minimum 1000ms - to max)*/
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class1pollInterval      =   0;                              /*!<CLASS 1 poll interval in milliSeconds (minimum 1000ms - to max)*/
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class2pollInterval      =   0;                              /*!<CLASS 2 poll interval in milliSeconds (minimum 1000ms - to max)*/
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class3pollInterval      =   0;                              /*!<CLASS 3 poll interval in milliSeconds (minimum 1000ms - to max)*/
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.bFrozenAnalogInputSupport  =   FALSE;                          /*!<False- stack will not create points for frozen analog input.*/
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.bEnableFileTransferSupport =   FALSE;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.bDisableUnsolicitedStatup  =   FALSE;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.bDisableResetofRemotelink  =   FALSE;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].u32CommandTimeout                         =   50000;
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].u32FileOperationTimeout                   =   200000;


	sDNP3Config.sDNP3ClientSet.bAutoGenDNP3DataObjects  = TRUE;
    //Define number of objects
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].u16NoofObject   =   0;
    // Allocate memory for objects
    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects = NULL;

   //Load configuration
   i16ErrorCode = DNP3LoadConfiguration(myClient, &sDNP3Config, &tErrorValue);
   if(i16ErrorCode != EC_NONE)
   {
        printf("\r\n DNP3 Library API Function - DNP3LoadConfiguration() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
        break;
   }

   //Start Client
   i16ErrorCode = DNP3Start(myClient, &tErrorValue);
   if(i16ErrorCode != EC_NONE)
   {
        printf("\r\n DNP3 Library API Function - DNP3Start() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
        break;
   }

		fflush(stdout);
        set_tty_raw();         /* set up character-at-a-time */


        printf("\r\n Enter CTRL-X to Exit \t s - Send command called \t e - enable view traffic \t d - disable view traffic\r\n");
        printf("\r\n");

        sleep(2);



    // Loop
    while(bexit ==	FALSE)
    {


          u16Char =kb_getc();                                  /* char typed by user? */
		  if(u16Char == 0)
          {
            continue;
          }
		  else
		  {
				switch(u16Char)
				{
					case 0x03: //CTRL + C
					case 0x18: //CTRL + X
						set_tty_cooked();                           /* restore normal TTY mode */
                        bexit = TRUE;
                        break;

					case 0x73:  // s - send command called
						printf("\r\n ***********send command called ***********\r\n");
						sendcommand();
						break;

					case 0x65:  // e - enable view traffic
						printf("\r\n ***********view traffic enabled ***********\r\n");
						viewtraffic =TRUE;
						break;

					case 0x64:  // d - disable view traffic
					printf("\r\n ***********view traffic disabled ***********\r\n");
						viewtraffic =FALSE;
						break;

					default:
						break;
				}

				printf("\r\n Enter CTRL-X to Exit \t s - Send command called \t e - enable view traffic \t d - disable view traffic\r\n");
				printf("\r\n");

		  }


		// update time interval
        usleep(1);

    }

	// Stop Client
        i16ErrorCode = DNP3Stop(myClient, &tErrorValue);
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n DNP3 Library API Function - DNP3Stop() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
			break;
        }



   }while(FALSE);



        printf("\r\n Enter any key to free");
        getchar();

        // Free Client
        i16ErrorCode = DNP3Free(myClient, &tErrorValue);
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n DNP3 Library API Function - DNP3Free() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));

        }

   printf("\r\nBye\r\n");

   getchar();
   return(0);
}

// End of file

