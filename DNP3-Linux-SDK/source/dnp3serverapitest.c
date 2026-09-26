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
/*! \file       dnp3serverapitest.c
 *  \brief      C Source code file, DNP3 Outstation/Server library test program
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


/*! \brief - Server Physical Communication Medium */
#define SERVER_TCP_COMMUNICATION 1

/*! \brief - if serial communication not defined - use serial communication */
#ifndef SERVER_TCP_COMMUNICATION
	#define SERVER_SERIAL_COMMUNICATION 1
#endif

#ifdef SERVER_SERIAL_COMMUNICATION
/*! \brief -  check computer configuration serial com port number,  if server and client application running in same system, we can use com0com */
	#define SERIAL_PORT_NUMBER 0 //ttySO
#endif


	DNP3Object                          myServer         = NULL;         // DNP3 Server object
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
* ColdRestart Callback information
******************************************************************************/
Integer16 cbColdRestart(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptWriteID,  tErrorValue *ptErrorValue)
{
        Integer16 i16ErrorCode = EC_NONE;

        printf("\n\r\ncbColdRestart() called");
		printf("\r\nServer ID : %u", u16ObjectId);

		printf("\r\n ");
		if(ptWriteID->eCommMode    ==  COMM_SERIAL)
		{
			printf("Serial Port %u", ptWriteID->u16SerialPortNumber);
		}
		else
		{
			printf("IP Address %s",ptWriteID->ai8IPAddress);
			printf("\tPort %u",ptWriteID->u16PortNumber);
		}

        printf("\r\n");

        return i16ErrorCode;
}

/******************************************************************************
*  WarmRestart Callback information
******************************************************************************/
Integer16 cbWarmRestart(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptWriteID,  tErrorValue *ptErrorValue)
{
        Integer16 i16ErrorCode = EC_NONE;

        printf("\n\r\ncbWarmRestart() called");
		printf("\r\nServer ID : %u", u16ObjectId);

		printf("\r\n");
		if(ptWriteID->eCommMode    ==  COMM_SERIAL)
		{
			printf("Serial Port %u", ptWriteID->u16SerialPortNumber);
		}
		else
		{
			printf("IP Address %s",ptWriteID->ai8IPAddress);
			printf("\t Port %u",ptWriteID->u16PortNumber);
		}

        printf("\r\n");

        return i16ErrorCode;
}

/******************************************************************************
* Write callback
******************************************************************************/
Integer16 cbWrite(Unsigned16 u16ObjectId, enum eWriteFunctionID eFunctionID, struct sDNP3DataAttributeID * ptWriteID, struct sDNP3DataAttributeData * ptWriteValue,struct sDNP3WriteParameters *ptWriteParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\ncbWrite() called - Clock sync from DNP3 Client ");
	printf("\r\nServer ID : %u", u16ObjectId);

	printf("\r\n");
    if(ptWriteID->eCommMode    ==  COMM_SERIAL)
    {
        printf("Serial Port %u", ptWriteID->u16SerialPortNumber);
    }
    else
    {
        printf("IP Address %s",ptWriteID->ai8IPAddress);
        printf("\t Port %u",ptWriteID->u16PortNumber);
    }



    printf( "\r\nDate : %u-%u-%u",ptWriteValue->sTimeStamp.u8Day,ptWriteValue->sTimeStamp.u8Month, ptWriteValue->sTimeStamp.u16Year);

    printf( "\r\nTime : %u:%02u:%02u:%03u", ptWriteValue->sTimeStamp.u8Hour, ptWriteValue->sTimeStamp.u8Minute, ptWriteValue->sTimeStamp.u8Seconds, ptWriteValue->sTimeStamp.u16MilliSeconds );

    printf("\r\n");
    return i16ErrorCode;
}

/******************************************************************************
* Debug callback
******************************************************************************/
Integer16 cbDebug(Unsigned16 u16ObjectId, struct sDNP3DebugData *ptDebugData, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;
    Unsigned16 u16nav                = 0;

	if(viewtraffic == TRUE)
	{


    //printf("\r\ncbDebug() called");

    if((ptDebugData->u32DebugOptions & DEBUG_OPTION_TX ) == DEBUG_OPTION_TX)
    {

        if(ptDebugData->eCommMode   ==  COMM_SERIAL)
        {
            printf("\r\nSerial port %u Transmit %u bytes ->  ",ptDebugData->u16ComportNumber, ptDebugData->u16TxCount);
        }
        else
        {
            printf("\r\nIP %s Ethernet port %u Transmit %u bytes ->  ", ptDebugData->ai8IPAddress, ptDebugData->u16PortNumber, ptDebugData->u16TxCount);
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
            printf("\r\nSerial port %u Receive %u bytes <-  ",ptDebugData->u16ComportNumber, ptDebugData->u16RxCount);
        }
        else
        {
            printf("\r\nIP %s Ethernet port %u Receive %u bytes <-  ", ptDebugData->ai8IPAddress, ptDebugData->u16PortNumber, ptDebugData->u16RxCount);
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
        printf("\r\nWarning message %s", ptDebugData->au8WarningMessage);
        printf("\r\nErrorCode %d", ptDebugData->i16ErrorCode);
        printf("\r\nErrorValue %d", ptDebugData->tErrorValue);
    }

    printf("\r\n");
	}

    return i16ErrorCode;
}

/******************************************************************************
* Operate callback
******************************************************************************/
Integer16 cbOperate(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psOperateID, struct sDNP3DataAttributeData * psOperateValue, struct sDNP3CommandParameters * psOperateParams, tErrorValue * ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;
    Float32   f32Data   =   0;
	Integer32 i32Data    =   0;
	Integer16 i16Data    =   0;
    Unsigned8 u8Data    =   0;


    printf("\n\r\n************cbOperate() called*****************");
	printf("\r\nServer ID : %u", u16ObjectId);

	printf("\r\n");
    if(psOperateID->eCommMode    ==  COMM_SERIAL)
    {
        printf("Serial Port %u", psOperateID->u16SerialPortNumber);
    }
    else
    {
        printf("IP Address %s",psOperateID->ai8IPAddress);
        printf("\t Port %u",psOperateID->u16PortNumber);
    }

        if(psOperateID->eGroupID    ==  ANALOG_OUTPUTS)
    {
        printf("\r\nGROUP ID : ANALOG_OUTPUT");
        printf("\r\nIndex Number %u",psOperateID->u16IndexNumber);

		if(psOperateParams->eCommandVariation == ANALOG_OUTPUT_BLOCK_FLOAT32)
		{
			printf("\r\n variation : ANALOG_OUTPUT_BLOCK_FLOAT32");
			memcpy(&f32Data, psOperateValue->pvData, sizeof(Float32));
			printf("\r\nData : %0.3f",f32Data);
		}
		else if(psOperateParams->eCommandVariation == ANALOG_OUTPUT_BLOCK_INTEGER32)
		{
			printf("\r\n variation : ANALOG_OUTPUT_BLOCK_INTEGER32");
			memcpy(&i32Data, psOperateValue->pvData, sizeof(Integer32));
			printf("\r\nData : %d",i32Data);
		}
		else if(psOperateParams->eCommandVariation == ANALOG_OUTPUT_BLOCK_INTEGER16)
		{
			printf("\r\n variation : ANALOG_OUTPUT_BLOCK_INTEGER16");
			memcpy(&i16Data, psOperateValue->pvData, sizeof(Integer16));
			printf("\r\nData : %d",i16Data);
		}
		else
			printf("\r\n invalid variation");
    }

    if(psOperateID->eGroupID    ==  BINARY_OUTPUT)
    {
        printf("\r\nGROUP ID : BINARY_OUTPUT");
        printf("\r\nIndex Number %u",psOperateID->u16IndexNumber);

		if(psOperateParams->eCommandVariation == CROB_G12V1)
		{
			printf("\r\n variation : CROB_G12V1");
		}
		else
			printf("\r\n invalid variation");

        memcpy(&u8Data, psOperateValue->pvData, sizeof(Unsigned8));
        printf("\r\nData : %u",u8Data);

        printf("\r\nOperation Type %u",psOperateParams->eOPType);
        printf("\r\nCount %u",psOperateParams->u8Count);
        printf("\r\nOn time %u",psOperateParams->u32ONtime);
        printf("\r\nOff time %u",psOperateParams->u32OFFtime);
		printf("\r\nCR %u",psOperateParams->bCR);
    }

	printf( "\r\nDate : %u-%u-%u", psOperateValue->sTimeStamp.u8Day,psOperateValue->sTimeStamp.u8Month, psOperateValue->sTimeStamp.u16Year);
	printf( "\r\nTime : %u:%02u:%02u:%03u", psOperateValue->sTimeStamp.u8Hour, psOperateValue->sTimeStamp.u8Minute, psOperateValue->sTimeStamp.u8Seconds, psOperateValue->sTimeStamp.u16MilliSeconds );


     printf("\r\n");

    return i16ErrorCode;
}

/******************************************************************************
* Select callback
******************************************************************************/
Integer16 cbSelect(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psSelectID, struct sDNP3DataAttributeData * psSelectValue, struct sDNP3CommandParameters * psSelectParams, tErrorValue * ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;
    Float32   f32Data   =   0;
	Integer32 i32Data    =   0;
	Integer16 i16Data    =   0;
    Unsigned8 u8Data    =   0;

    printf("\n\r\n************cbSelect() called*****************");
	printf("\r\nServer ID : %u", u16ObjectId);

	 printf("\r\n");
    if(psSelectID->eCommMode    ==  COMM_SERIAL)
    {
        printf("Serial Port %u", psSelectID->u16SerialPortNumber);
    }
    else
    {
        printf("IP Address %s",psSelectID->ai8IPAddress);
        printf("\t Port %u",psSelectID->u16PortNumber);
    }

    if(psSelectID->eGroupID ==  ANALOG_OUTPUTS)
    {
        printf("\r\nGROUP ID : ANALOG_OUTPUT");
        printf("\r\nIndex Number %u",psSelectID->u16IndexNumber);

		if(psSelectParams->eCommandVariation == ANALOG_OUTPUT_BLOCK_FLOAT32)
		{
			printf("\r\n variation : ANALOG_OUTPUT_BLOCK_FLOAT32");
			memcpy(&f32Data, psSelectValue->pvData, sizeof(Float32));
			printf("\r\nData : %0.3f",f32Data);
		}
		else if(psSelectParams->eCommandVariation == ANALOG_OUTPUT_BLOCK_INTEGER32)
		{
			printf("\r\n variation : ANALOG_OUTPUT_BLOCK_INTEGER32");
			memcpy(&i32Data, psSelectValue->pvData, sizeof(Integer32));
			printf("\r\nData : %d",i32Data);
		}
		else if(psSelectParams->eCommandVariation == ANALOG_OUTPUT_BLOCK_INTEGER16)
		{
			printf("\r\n variation : ANALOG_OUTPUT_BLOCK_INTEGER16");
			memcpy(&i16Data, psSelectValue->pvData, sizeof(Integer16));
			printf("\r\nData : %d",i16Data);
		}
		else
			printf("\r\n invalid variation");

    }

    if(psSelectID->eGroupID ==  BINARY_OUTPUT)
    {
        printf("\r\nGROUP ID : BINARY_OUTPUT");
        printf("\r\nIndex Number %u",psSelectID->u16IndexNumber);

		if(psSelectParams->eCommandVariation == CROB_G12V1)
		{
			printf("\r\n variation : CROB_G12V1");
		}
		else
			printf("\r\n invalid variation");

        memcpy(&u8Data, psSelectValue->pvData, sizeof(Unsigned8));
        printf("\r\nData : %u",u8Data);

        printf("\r\nOperation Type %u",psSelectParams->eOPType);
        printf("\r\nCount %u",psSelectParams->u8Count);
        printf("\r\nOn time %u",psSelectParams->u32ONtime);
        printf("\r\nOff time %u",psSelectParams->u32OFFtime);
		printf("\r\nCR %u",psSelectParams->bCR);
    }

	printf( "\r\nDate : %u-%u-%u", psSelectValue->sTimeStamp.u8Day,psSelectValue->sTimeStamp.u8Month, psSelectValue->sTimeStamp.u16Year);
	printf( "\r\nTime : %u:%02u:%02u:%03u", psSelectValue->sTimeStamp.u8Hour, psSelectValue->sTimeStamp.u8Minute, psSelectValue->sTimeStamp.u8Seconds, psSelectValue->sTimeStamp.u16MilliSeconds );



     printf("\r\n");

    return i16ErrorCode;
}


void update()
{

   Integer16                 i16ErrorCode       = EC_NONE;      // API Function return error paramter
   tErrorValue                         tErrorValue      = EV_NONE;      // API Function return additional error parameter

   struct sDNP3DataAttributeID         *psDAID          = NULL;         // Update data attribute
   struct sDNP3DataAttributeData       *psNewValue      = NULL;         // Update new value
//   Unsigned8                           u8Data           = 0;            // Update data
   Float32                             f32Data           = 0;            // Update data
   unsigned int	index =	0;


	unsigned int uiCount;                                                // Update number of parameters
   struct tm * timeinfo;                                                // Update date and time structute
   time_t now;                                                          // To get current data and time


	        set_tty_cooked(); //Unix setup to reverse tty_set_raw()
	    printf("\r\n");

		printf ("Enter Index address to update for Analog Output Group (0-9): ");
		scanf("%u", &index);
		printf("\r\n");

		printf ("Enter update float value: ");
		scanf("%f", &f32Data);
		printf("\r\n");


    //Update parameters
    uiCount    =   1;
    psDAID     =   (struct sDNP3DataAttributeID *)calloc(uiCount,sizeof(struct sDNP3DataAttributeID));
    psNewValue  =   (struct sDNP3DataAttributeData *)calloc(uiCount,sizeof(struct sDNP3DataAttributeData));



	psDAID[0].u16SlaveAddress   =   1;
    psDAID[0].eGroupID          =   ANALOG_OUTPUTS;
    psDAID[0].u16IndexNumber    =   (Unsigned16)index;

    psNewValue[0].eDataSize     =   FLOAT32_SIZE;
    psNewValue[0].eDataType     =   FLOAT32_DATA;
    psNewValue[0].tQuality      =   ONLINE ;
    psNewValue[0].pvData        =   &f32Data;


            time(&now);
            timeinfo = localtime(&now);
            timeinfo->tm_year += 1900;

            //current date
            psNewValue[0].sTimeStamp.u8Day              =   (Unsigned8)timeinfo->tm_mday;
            psNewValue[0].sTimeStamp.u8Month            =   (Unsigned8)(timeinfo->tm_mon + 1);
            psNewValue[0].sTimeStamp.u16Year            =   timeinfo->tm_year;

            //current time
            psNewValue[0].sTimeStamp.u8Hour             =   (Unsigned8)timeinfo->tm_hour;
            psNewValue[0].sTimeStamp.u8Minute           =   (Unsigned8)timeinfo->tm_min;
            psNewValue[0].sTimeStamp.u8Seconds          =   (Unsigned8)(timeinfo->tm_sec);
            psNewValue[0].sTimeStamp.u16MilliSeconds    =   0;
            psNewValue[0].sTimeStamp.u16MicroSeconds    =   0;
            psNewValue[0].sTimeStamp.i8DSTTime          =   0; //No Day light saving time
            psNewValue[0].sTimeStamp.u8DayoftheWeek     =   4;


           // printf("update date - %02u:%02u:%04u",  psNewValue[0].sTimeStamp.u8Day,psNewValue[0].sTimeStamp.u8Month,psNewValue[0].sTimeStamp.u16Year  );



            // Update server
            i16ErrorCode = DNP3Update(myServer,psDAID,psNewValue,uiCount,UPDATE_DEFAULT_EVENT,&tErrorValue);
            if(i16ErrorCode != EC_NONE)
            {
              printf("\r\nDNP3 Library API Function - DNP3Update() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            }
			else
			{
				printf("\r\nDNP3 Library API Function - DNP3Update() Success");
			}




        free(psDAID);
        free(psNewValue);


		set_tty_raw() ;  // Unix setup to read a character at a time.

		printf("\r\n");



}


/******************************************************************************
* main()
******************************************************************************/
int main (void)
{

   Integer16                 i16ErrorCode       = EC_NONE;      // API Function return error paramter
   tErrorValue                         tErrorValue      = EV_NONE;      // API Function return additional error parameter
   struct sDNP3Parameters              sParameters      = {0};          // DNP3 Server object callback paramters
   Unsigned16                          u16Char          =  0;           // Get control+x key to stop update values
   Boolean bexit							=	FALSE;

   struct sDNP3ConfigurationParameters sDNP3Config;                     // Server protocol , point configuration parameters
   struct tm * timeinfo;                                                // Update date and time structute
   time_t now;                                                          // To get current data and time

do
{

    printf("\n\r\n \t\t**** DNP3 Protocol Outstation / Server Library Test ****");
   // Check library version against the library header file
   if(strcmp((char*)DNP3GetLibraryVersion(), DNP3_VERSION) != 0)
   {
     printf("\r\nError: Version Number Mismatch");
     printf("\r\n Library Version is  : %s", DNP3GetLibraryVersion());
     printf("\r\n The Version used is : %s", DNP3_VERSION);
	 printf("\r\n");
     return 0;
   }

   printf("\r\nLibrary Version is : %s", DNP3GetLibraryVersion());
   printf("\r\nLibrary Build on   : %s", DNP3GetLibraryBuildTime());
   printf("\r\n Library License Information   : %s", DNP3GetLibraryLicenseInfo());


   // Initialize DNP3 Server object parameters
   memset(&sParameters,0,sizeof(struct sDNP3Parameters));
   sParameters.eAppFlag                 = APP_SERVER;           // This is a DNP3 Server
   sParameters.ptReadCallback           = NULL;                 // Read Callback
   sParameters.ptWriteCallback          = cbWrite;              // Write Callback
   sParameters.ptUpdateCallback         = NULL;                 // Update Callback
   sParameters.ptSelectCallback         = cbSelect;             // Select commands
   sParameters.ptOperateCallback        = cbOperate;            // Operate commands
   sParameters.ptDebugCallback          = cbDebug;              // Debug Callback
   sParameters.ptColdRestartCallback    = cbColdRestart;        // ColdRestart Callback
   sParameters.ptWarmRestartCallback    = cbWarmRestart;        // ColdRestart Callback
   sParameters.ptClientPollStatusCallback = NULL;
   sParameters.u16ObjectId				= 1;				    //Server ID which used in callbacks to identify the DNP3 server object

   sParameters.u32Options               = 0;

   // Create a server Object
   myServer         = NULL;
   myServer = DNP3Create(&sParameters, &i16ErrorCode, &tErrorValue);
   if(myServer == NULL)
   {
        printf("\r\n DNP3 Library API Function - DNP3Create() failed:  %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
        break;
   }

   // Server load configuration - communication and protocol configuration parameters
   memset(&sDNP3Config,0,sizeof(struct sDNP3ConfigurationParameters));

#if defined (SERVER_TCP_COMMUNICATION)

   // tcp communication settings
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.eCommMode                     =   TCP_IP_MODE;
	// check computer configuration - TCP/IP Address
   strcpy((char*)sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sEthernetCommsSet.sEthernetportSet.ai8FromIPAddress, "127.0.0.1");  // Server works on every interface
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sEthernetCommsSet.sEthernetportSet.u16PortNumber   =   20000;


#elif defined (SERVER_SERIAL_COMMUNICATION)

    //serial communication setting
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.eCommMode =   COMM_SERIAL;
   memset(&sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet, 0, sizeof(struct sSerialCommunicationSettings));


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

   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialType   = SERIAL_RS232;
   // check system configuration serial com port number
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.u16SerialPortNumber =   SERIAL_PORT_NUMBER;  // serial port /dev/ttyS0
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialBitRate =   BITRATE_9600;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eWordLength  =   WORDLEN_8BITS;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialParity  =   EVEN;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eStopBits =   STOPBIT_1BIT;

	//Serial port flow control
	sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.bWinCTSoutputflow         =  FALSE;
	sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.bWinDSRoutputflow         =  FALSE;
	sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eWinDTR					  =	 WIN_DTR_CONTROL_DISABLE;
	sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eWinRTS					  =  WIN_RTS_CONTROL_DISABLE;
	sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eLinuxFlowControl         = FLOW_NONE;

   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16CharacterTimeout   =   1;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16MessageTimeout   =   0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16InterCharacterDelay    =   5;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16PostDelay  =   0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16PreDelay       =   0;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u8CharacterRetries    =   20;
   sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u8MessageRetries  =   0;

#else
    printf("\r\n Invalid DNP3 Server Communication Medium");
    getchar();
    return(0);
#endif


   //protocol communication settings
   sDNP3Config.sDNP3ServerSet.sServerProtSet.u16SlaveAddress                            =   1;          // slave address
   sDNP3Config.sDNP3ServerSet.sServerProtSet.u16MasterAddress                           =   2;          // master address
   sDNP3Config.sDNP3ServerSet.sServerProtSet.u32LinkLayerTimeout                        =   10000;      // link layer time out in ms
   sDNP3Config.sDNP3ServerSet.sServerProtSet.u32ApplicationLayerTimeout                 =   20000;      // app link layer time out in ms
   sDNP3Config.sDNP3ServerSet.sServerProtSet.u32TimeSyncIntervalSeconds                     =   90;     // time sync bit will set for every 90 seconds, set high value, because every u32TimeSyncIntervalSeconds slave request time from master

    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarBI                               =   BI_WITH_FLAGS;                      // Default Static variation Binary Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarDBI                              =   DBBI_WITH_FLAGS;                // Default Static variation Double Bit Binary Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarBO                               =   BO_WITH_FLAGS;                      // Default Static variation Double Bit Binary Output
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarCI                               =   CI_32BIT_WITHFLAG;                      // Default Static variation counter Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarFzCI                             =   FCI_32BIT_WITHFLAGANDTIME;          // Default Static variation Frozen counter Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAI                               =   AI_SINGLEPREC_FLOATWITHFLAG;                        // Default Static variation Analog Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarFzAI                             =   FAI_SINGLEPRECFLOATWITHFLAG;        // Default Static variation frozen Analog Input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAID                              =   DAI_SINGLEPRECFLOAT;            // Default Static variation Analog Input Deadband
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAO                               =   AO_SINGLEPRECFLOAT_WITHFLAG;    // Default Static variation Analog Output

    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarBI                                =   BIE_WITHOUT_TIME;               // Default event variation for binary input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarDBI                               =   DBBIE_WITH_ABSOLUTETIME;    // Default event variation for double bit binary input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarCI                                =   CIE_32BIT_WITHFLAG_WITHTIME;            // Default event variation for Counter input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarAI                                =   AIE_SINGLEPREC_WITHTIME;                // Default event variation for Analog input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarFzCI                              =   FCIE_32BIT_WITHFLAG_WITHTIME;       // Default event variation for Frozen counter input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarFzAI                              =   FAIE_SINGLEPREC_WITHTIME;           // Default event variation for Frozen Analog input
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarBO                                =   BOE_WITH_TIME;               // Default event variation for binary Output
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarAO                                =   AOE_SINGLEPREC_WITHTIME;                // Default event variation for Analog Output

    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class1EventBufferSize                    =   50;    // class 1 buffer size number of events to store
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class1EventBufferOverFlowPercentage       =   90;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class2EventBufferSize                    =   50;    // class 2 buffer size number of events to store
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class2EventBufferOverFlowPercentage       =   90;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class3EventBufferSize                     =   50;    // class 3 buffer size number of events to store
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class3EventBufferOverFlowPercentage       =   90;

    time(&now);
    timeinfo = localtime(&now);
    timeinfo->tm_year += 1900;

    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Day              =  (Unsigned8)timeinfo->tm_mday;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Month            =   (Unsigned8)(timeinfo->tm_mon+1);
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16Year            =   timeinfo->tm_year;

    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Hour             =   (Unsigned8)timeinfo->tm_hour;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Minute           =   (Unsigned8)timeinfo->tm_min;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Seconds          =   (Unsigned8)(timeinfo->tm_sec);
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16MilliSeconds    =   0;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16MicroSeconds    =   0;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.i8DSTTime          =   0; //No Day light saving time
    sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8DayoftheWeek     =   4;

    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBIinClass0    =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddDBIinClass0   =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBOinClass0    =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddCIinClass0    =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzCIinClass0  =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIinClass0    =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzAIinClass0  =   FALSE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIDinClass0   =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAOinClass0    =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddOSinClass0    =   TRUE;


    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBIEvent       =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddDBIEvent      =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBOEvent       =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddCIEvent       =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzCIEvent     =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIEvent       =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzAIEvent     =   FALSE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIDEvent      =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAOEvent       =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddOSEvent       =   TRUE;
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddVTOEvent      =   TRUE;

    sDNP3Config.sDNP3ServerSet.sServerProtSet.eAIDeadbandMethod     =   DEADBAND_FIXED;                                  /*!< Analog Input Deadband Calculation method*/
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bFrozenAnalogInputSupport = FALSE;        /*!<False- stack will not create points for frozen analog input.*/
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bEnableSelfAddressSupport = TRUE;         /*!< Enable Self Address Support */
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bEnableFileTransferSupport = FALSE;       /*!< Enable File Transfr Support*/
    sDNP3Config.sDNP3ServerSet.sServerProtSet.u8IntialdatabaseQualityFlag = ONLINE;       /*!< 0- OFFLINE, 1 BIT- ONLINE, 2 BIT-RESTART, 3 BIT -COMMLOST, MAX VALUE -7   */
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bLocalMode                    =   FALSE;  /*!< if local mode set true, then -all remote command for binary output/ analog output   control statusset to not supported */
    sDNP3Config.sDNP3ServerSet.sServerProtSet.bUpdateCheckTimestamp     =   FALSE;      /*!< if it true ,the timestamp change also generate event  during the dnp3update */



    //Unsolicited Response Setttings
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.bEnableUnsolicited         =   FALSE;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.bEnableResponsesonStartup  =   FALSE;   // enable or disable unsolicited response to master
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u32Timeout                 =   5000;   // unsolicited response timeout in ms

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class1TriggerNumberofEvents   =   1;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class1HoldTimeAfterResponse   =   1;

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class2TriggerNumberofEvents  =   1;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class2HoldTimeAfterResponse  =   1;

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class3TriggerNumberofEvents  =   1;
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class3HoldTimeAfterResponse   =   1;

   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u8Retries                      =   5;      // Unsolicited message retries
   sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16MaxNumberofEvents   =   10;

    // Debug option settings
    sDNP3Config.sDNP3ServerSet.sDebug.u32DebugOptions                             =   ((DEBUG_OPTION_TX) | DEBUG_OPTION_RX);
    //sDNP3Config.sDNP3ServerSet.sDebug.u32DebugOptions                               =   0;

    // Define number of objects
    sDNP3Config.sDNP3ServerSet.u16NoofObject                             =   4;
    // Allocate memory for objects
    sDNP3Config.sDNP3ServerSet.psDNP3Objects = NULL;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects = (struct sDNP3Object*)calloc(sDNP3Config.sDNP3ServerSet.u16NoofObject, sizeof(struct sDNP3Object));
       if(sDNP3Config.sDNP3ServerSet.psDNP3Objects == NULL)
       {
         printf("\r\nError: Not enough memory to alloc objects");
         break;
       }

    strcpy((char*)sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].ai8Name,"binary input 0-9");
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eGroupID       =   BINARY_INPUT;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].u16NoofPoints  =   10;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eClassID       =   CLASS_ONE;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eControlModel  =   INPUT_STATUS_ONLY;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].u32SBOTimeOut  =   0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].f32AnalogInputDeadband  =   0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eAnalogStoreType = AS_FLOAT;


	strcpy((char*)sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].ai8Name,"analog Input 0-9");
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eGroupID       =   ANALOG_INPUT;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].u16NoofPoints  =   10;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eClassID       =   CLASS_ONE;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eControlModel  =   INPUT_STATUS_ONLY;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].u32SBOTimeOut  =   0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].f32AnalogInputDeadband  =  0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eAnalogStoreType = AS_FLOAT;




    strcpy((char*)sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].ai8Name,"binary output 0-9");
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eGroupID       =   BINARY_OUTPUT;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].u16NoofPoints  =   10;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eClassID       =   NO_CLASS;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eControlModel  =   DIRECT_OPERATION;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].u32SBOTimeOut  =   0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].f32AnalogInputDeadband  =  0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eAnalogStoreType = AS_FLOAT;




    strcpy((char*)sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].ai8Name,"analog output 0-9");
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eGroupID       =   ANALOG_OUTPUTS;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].u16NoofPoints  =   10;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eClassID       =   CLASS_ONE;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eControlModel  =   DIRECT_OPERATION;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].u32SBOTimeOut  =   0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].f32AnalogInputDeadband  =  0;
    sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eAnalogStoreType = AS_FLOAT;



    // Load configuration
    i16ErrorCode = DNP3LoadConfiguration(myServer, &sDNP3Config, &tErrorValue);
    if(i16ErrorCode != EC_NONE)
    {
        printf("\r\nDNP3 Library API Function - DNP3LoadConfiguration() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
        break;
    }

    // Start server
    i16ErrorCode = DNP3Start(myServer, &tErrorValue);
    if(i16ErrorCode != EC_NONE)
    {
      printf("\r\n DNP3 Library API Function - DNP3Start() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
      break;
    }


		fflush(stdout);
        set_tty_raw();         /* set up character-at-a-time */


        printf("\r\n Enter CTRL-X to Exit \t u- Update \t e - enable view traffic \t d - disable view traffic");
        printf("\r\n");


        sleep(3);

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

					case 0x75:  // u - update
						printf("\r\n ***********update called ***********\r\n");
						update();
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
 				printf("\r\n Enter CTRL-X to Exit \t u- Update \t e - enable view traffic \t d - disable view traffic");
                printf("\r\n");

		  }




        //time interval
        usleep(1);

    }

        //printf("\r\n dnp3 stop called");
        // Stop server
        i16ErrorCode = DNP3Stop(myServer, &tErrorValue);
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n EDNP3 Library API Function - DNP3Stop() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }

   }while(FALSE);


    //printf("\r\n dnp3 free called");
    // Free server
    i16ErrorCode = DNP3Free(myServer, &tErrorValue);
    if(i16ErrorCode != EC_NONE)
    {
        printf("\r\n DNP3 Library API Function - DNP3Free() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));

    }

   printf("\r\nBye\r\n");

   return(0);
}

// End of file

