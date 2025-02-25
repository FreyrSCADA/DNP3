import ctypes
import os 
import platform
from dnp3types import *



DNP3_VERSION  = "21.06.008"


system = platform.system()

if 'Windows' in system: 
    # locating the 'dnp3x64d.dll' file in the 
    # same directory as this file 
    _file = 'dnp3x64d.dll' 

else:
    #linux
    _file = 'libx86_x64-dnp3.so'

_path = os.path.join(os.path.dirname(__file__), _file)
dnp3_lib = ctypes.cdll.LoadLibrary(_path)  

''' 
/*! \brief          Get Library Version
    \return         version number of library as a string of char with format AA.BB.CCC

    Example Usage:
    \code
                    printf("Version number: %s", DNP3GetLibraryVersion());
    \endcode
*/
'''

#PUBLICAPIPX const Integer8 * PUBLICAPISX DNP3GetLibraryVersion(void);
dnp3_lib.DNP3GetLibraryVersion.argtypes = None
dnp3_lib.DNP3GetLibraryVersion.restype = ctypes.c_char_p

'''
/*! \brief          Get Library Build Time
    \return         Build time of the library as a string of char. Format "Mmm dd yyyy hh:mm:ss"

    Example Usage:
    \code
                    printf("Build Time: %s", DNP3GetLibraryBuildTime());
    \endcode
*/
'''
#PUBLICAPIPX const Integer8 * PUBLICAPISX DNP3GetLibraryBuildTime(void);
dnp3_lib.DNP3GetLibraryBuildTime.argtypes = None
dnp3_lib.DNP3GetLibraryBuildTime.restype = ctypes.c_char_p
'''
/*! \brief          Create a client or server object with call-backs for reading, writing and updating data objects
    \param[in]      psParameters    DNP3 Object Parameters
    \param[out]     pi16ErrorCode     Pointer to a Error Code (if any error occurs)
    \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

    \return         Pointer to a new DNP3 object
    \return         NULL if an error occured (errorCode will contain an error code)

    Server Example Usage:
    \code
                    // Create Server
                    Integer16         i16ErrorCode      = EC_NONE;
                    DNP3Object                  myServer        = NULL;
                    struct sDNP3Parameters      sParameters     = {0};
                    tErrorValue              tErrorValue     = EV_NONE;

                    sParameters.eAppFlag            = APP_SERVER;           // This is a DNP3 Server
                    sParameters.u32Options          = DNP3_APP_OPTION_NONE;      // No options set
                    sParameters.ptReadCallback      = NULL;                 // Read Callback is not defined
                    sParameters.ptWriteCallback     = NULL;                 // Write Callback is not defined
                    sParameters.ptUpdateCallback    = NULL;                 // Update Callback is not defined
                    sParameters.ptSelectCallback    = NULL;                 // Select Callback is not defined
                    sParameters.ptOperateCallback   = NULL;                 // Operate Callback is not defined
                    
                    //Create a server object
                    myServer = DNP3Create(&sParameters, &i16ErrorCode, &tErrorValue);
                    if(myDNP3Obj == NULL)
                    {
                        printf("Server Failed to create: %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode

    Client Example Usage:
    \code
                    // Create Client
                    Integer16         i16ErrorCode      = EC_NONE;
                    DNP3Object                  myClient       = NULL;
                    struct sDNP3Parameters      sParameters     = {0};
                    tErrorValue              tErrorValue        = EV_NONE;

                    sParameters.eAppFlag            = APP_CLIENT;           // This is a DNP3 Client
                    sParameters.u32Options          = DNP3_APP_OPTION_NONE;      // No options set
                    sParameters.ptReadCallback      = NULL;                 // Read Callback is not defined
                    sParameters.ptWriteCallback     = NULL;                 // Write Callback is not defined
                    sParameters.ptUpdateCallback    = NULL;                 // Update Callback is not defined
                    sParameters.ptSelectCallback    = NULL;                 // Select Callback is not defined
                    sParameters.ptOperateCallback   = NULL;                 // Operate Callback is not defined
                    
                    //Create a CLIENT object
                    myClient = DNP3Create(&sParameters, &i16ErrorCode, &tErrorValue);
                    if(myDNP3Obj == NULL)
                    {
                        printf("Server Failed to create: %i %i", i16ErrorCode, tErrorValue);
                    }

    \endcode

    
*/
'''
#PUBLICAPIPX DNP3Object PUBLICAPISX DNP3Create(struct sDNP3Parameters * psParameters, Integer16 * pi16ErrorCode, tErrorValue * ptErrorValue);
dnp3_lib.DNP3Create.argtypes = [ctypes.POINTER(sDNP3Parameters), ctypes.POINTER(ctypes.c_short), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Create.restype = ctypes.POINTER(sDNP3AppObject) #DNP3Object
'''
/*! \brief          Load the configuration to be used by DNP3 object.
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      psDNP3Config    Pointer to DNP3 Configuration parameters 
    \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

    \return         EC_NONE on success
    \return         otherwise error code

    Server Example Usage:
    \code
                    Integer16                     i16ErrorCode      = EC_NONE;
                    tErrorValue                          tErrorValue     = EV_NONE;
                    struct sDNP3ConfigurationParameters     sDNP3Config     = {0};

                    sDNP3Config.eCommMode                       =   COMM_SERIAL;
                    sDNP3Config.sSerialSet.u8ComPort            =   1;
                    sDNP3Config.sSerialSet.eBaudRate            =   BIT_RATE_9600;
                    sDNP3Config.sSerialSet.eWordLen             =   WORDLENGTH_8BITS;
                    sDNP3Config.sSerialSet.eParity              =   NO_PARITY;
                    sDNP3Config.sSerialSet.eStopBit             =   STOP_1BIT;
                    sDNP3Config.sSerialSet.eFlowControl         =   FC_NONE;
                    sDNP3Config.sSerialSet.u16CharacterTimeout  =   1;
                    sDNP3Config.sSerialSet.u16MessageTimeout    =   0;
                    sDNP3Config.sSerialSet.u16PostTxDelay       =   0;
                    sDNP3Config.sSerialSet.u16PreTxDelay        =   0;
                    sDNP3Config.sSerialSet.u8CharacterRetries   =   5;
                    sDNP3Config.sSerialSet.u8MessageRetries     =   10;

                    sDNP3Config.sDebug.u32DebugOptions          =   ((DEBUG_OPTION_ERROR | DEBUG_OPTION_TX) | DEBUG_OPTION_RX);
                    
                    sDNP3Config.u16SlaveAddress                 =   1;      
                    sDNP3Config.u32LinkLayerTimeout             =   1000;   // link layer time out in ms
                    sDNP3Config.u16MasterAddress                =   2;      
                       
                    sDNP3Config.sUnsolicitedResponseSet.bEnableResponsesonStartup                               =   FALSE;   
                    sDNP3Config.sUnsolicitedResponseSet.u32Timeout                                              =   1000;   
                    sDNP3Config.sUnsolicitedResponseSet.u8Retries                                               =   5;      
                    sDNP3Config.sUnsolicitedResponseSet.u16MaxNumberofEvents                                    =   10;
                    sDNP3Config.sUnsolicitedResponseSet.asClassSet[CLASS1_SETTINGS].u16TriggerNumberofEvents    =   5;
                    sDNP3Config.sUnsolicitedResponseSet.asClassSet[CLASS1_SETTINGS].u16HoldTimeAfterResponse    =   1;
                    sDNP3Config.sUnsolicitedResponseSet.asClassSet[CLASS2_SETTINGS].u16TriggerNumberofEvents    =   5;
                    sDNP3Config.sUnsolicitedResponseSet.asClassSet[CLASS2_SETTINGS].u16HoldTimeAfterResponse    =   1;
                    sDNP3Config.sUnsolicitedResponseSet.asClassSet[CLASS3_SETTINGS].u16TriggerNumberofEvents    =   5;
                    sDNP3Config.sUnsolicitedResponseSet.asClassSet[CLASS3_SETTINGS].u16HoldTimeAfterResponse    =   1;
                    
                    
                    sDNP3Config.asEventClassBufferSet[CLASS1_SETTINGS].u16Size                                  =   1000;    // class 1 buffer size number of events to store
                    sDNP3Config.asEventClassBufferSet[CLASS1_SETTINGS].u8OverFlowPercentage                     =   90;
                    sDNP3Config.asEventClassBufferSet[CLASS2_SETTINGS].u16Size                                  =   1000;    // class 2 buffer size number of events to store
                    sDNP3Config.asEventClassBufferSet[CLASS2_SETTINGS].u8OverFlowPercentage                     =   90;
                    sDNP3Config.asEventClassBufferSet[CLASS3_SETTINGS].u16Size                                  =   1000;    // class 3 buffer size number of events to store
                    sDNP3Config.asEventClassBufferSet[CLASS3_SETTINGS].u8OverFlowPercentage                     =   90;
                    
                    
                       
                    sDNP3Config.u32TimeSyncIntervalSeconds      =   90;      // time sync bit will set for every 90 seconds, set high value, because every u32TimeSyncIntervalSeconds slave request time from master    
                       
                    sDNP3Config.sStaticVariation.eDeStVarBI     =   BI_WITH_FLAGS;                      // Default Static variation Binary Input
                    sDNP3Config.sStaticVariation.eDeStVarDBI    =   DBBI_WITH_FLAGS;                    // Default Static variation Double Bit Binary Input
                    sDNP3Config.sStaticVariation.eDeStVarBO     =   BO_WITH_FLAGS;                      // Default Static variation Double Bit Binary Output
                    sDNP3Config.sStaticVariation.eDeStVarCI     =   CI_32BIT_WITHFLAG;                  // Default Static variation counter Input
                    sDNP3Config.sStaticVariation.eDeStVarFzCI   =   FCI_32BIT_WITHFLAGANDTIME;          // Default Static variation Frozen counter Input
                    sDNP3Config.sStaticVariation.eDeStVarAI     =   AI_SINGLEPREC_FLOATWITHFLAG;        // Default Static variation Analog Input
                    sDNP3Config.sStaticVariation.eDeStVarFzAI   =   FAI_SINGLEPRECFLOATWITHFLAG;        // Default Static variation frozen Analog Input
                    sDNP3Config.sStaticVariation.eDeStVarAID    =   DAI_SINGLEPRECFLOAT;                // Default Static variation Analog Input Deadband
                    sDNP3Config.sStaticVariation.eDeStVarAO     =   AO_SINGLEPRECFLOAT_WITHFLAG;        // Default Static variation Analog Output
                                
                    sDNP3Config.sEventVariation.eDeEvVarBI      =   BIE_WITH_ABSOLUTETIME;              // Default event variation for binary input
                    sDNP3Config.sEventVariation.eDeEvVarDBI     =   DBBIE_WITH_ABSOLUTETIME;            // Default event variation for double bit binary input
                    sDNP3Config.sEventVariation.eDeEvVarCI      =   CIE_32BIT_WITHFLAG_WITHTIME;        // Default event variation for Counter input
                    sDNP3Config.sEventVariation.eDeEvVarAI      =   AIE_SINGLEPREC_WITHTIME;            // Default event variation for Analog input
                    sDNP3Config.sEventVariation.eDeEvVarFzCI    =   FCIE_32BIT_WITHFLAG_WITHTIME;       // Default event variation for Frozen counter input
                    sDNP3Config.sEventVariation.eDeEvVarFzAI    =   FAIE_SINGLEPREC_WITHTIME;           // Default event variation for Frozen Analog input

                    sDNP3Config.u8NoofObject                    =   1;
                    // Allocate memory for objects
                    sDNP3Config.psDNP3Objects = calloc(sDNP3Config.u8NoofObject, sizeof(struct sDNP3Object)); 

                    strcpy((char*)sDNP3Config.psDNP3Objects[0].ai8Name,"binary input 0-49");
                    sDNP3Config.psDNP3Objects[0].eGroupID               =   BINARY_INPUT;
                    sDNP3Config.psDNP3Objects[0].u16NoofPoints          =   50;
                    sDNP3Config.psDNP3Objects[0].eClassID               =   CLASS_THREE;
                    sDNP3Config.psDNP3Objects[0].eControlModel          =   INPUT_STATUS_ONLY;
                    sDNP3Config.psDNP3Objects[0].u32SBOTimeOut          =   0;
                    sDNP3Config.psDNP3Objects[0].f32AnalogInputDeadband =   0;

                    //current date 10/2/2013
                    sDNP3Config.sTimeStamp.u8Day            =   10;
                    sDNP3Config.sTimeStamp.u8Month          =   2;
                    sDNP3Config.sTimeStamp.u16Year          =   2013;
                    //time 13.35.0
                    sDNP3Config.sTimeStamp.u8Hour           =   13;
                    sDNP3Config.sTimeStamp.u8Minute         =   35;
                    sDNP3Config.sTimeStamp.u8Seconds        =   0;
                    sDNP3Config.sTimeStamp.u16MilliSeconds  =   0;
                    sDNP3Config.sTimeStamp.u16MicroSeconds  =   0;
                    sDNP3Config.sTimeStamp.i8DSTTime        =   0; //No Day light saving time
                    sDNP3Config.sTimeStamp.u8DayoftheWeek   =   4;

                    // Load configuration
                    i16ErrorCode = DNP3LoadConfiguration(myServer, &sDNP3Config, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3LoadConfiguration() failed:  %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode

    Client Example Usage:
    \code
    
                   Integer16                     i16ErrorCode      = EC_NONE;
                   tErrorValue                          tErrorValue     = EV_NONE;
                   struct sDNP3ConfigurationParameters     sDNP3Config     = {0};

                    sDNP3Config.sDNP3ClientSet.eCommMode =   COMM_SERIAL;
                    sDNP3Config.sDNP3ClientSet.sDebug.u32DebugOptions	=	 ((DEBUG_OPTION_ERROR | DEBUG_OPTION_TX) | DEBUG_OPTION_RX);

                            //current date 10/2/2013
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Day				=	1;
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Month			=	4;
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u16Year			=	2013;
                     //time 13.35.0
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Hour 			=	10;
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Minute			=	0;
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u8Seconds			=	0;
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u16MilliSeconds	=	0;
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u16MicroSeconds	=	0;
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.i8DSTTime			=	0; //No Day light saving time
                     sDNP3Config.sDNP3ClientSet.sTimeStamp.u8DayoftheWeek 	=	4;

                     sDNP3Config.sDNP3ClientSet.u16MasterAddress	=	6;

                     sDNP3Config.sDNP3ClientSet.u8NoofClient		=	1;

                     sDNP3Config.sDNP3ClientSet.psClientObjects	=	calloc(sDNP3Config.sDNP3ClientSet.u8NoofClient, sizeof(struct sClientObject));
                     if(sDNP3Config.sDNP3ClientSet.psClientObjects	==	NULL)
                     {
                       printf("\r\n calloc failed");
                       break;
                     }   

                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.u8SerialPortNumber =   4;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialBitRate =   BITRATE_9600;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eWordLength  =   WORDLEN_8BITS;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eSerialParity  =   NONE;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eStopBits =   STOPBIT_1BIT;

                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.eFlowControl =   FLOW_NONE;

                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16CharacterTimeout   =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16MessageTimeout   =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16InterCharacterDelay	=	2;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16PostDelay	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u16PreDelay		=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u8CharacterRetries	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientCommunicationSet.sSerialSet.sRxTimeParam.u8MessageRetries	=	0;

                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u16SlaveAddress	=	1;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class0123pollInterval	=	20000;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32Class123pollInterval	=	1000;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32LinkLayerTimeout		=	5000;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].sClientProtSet.u32ApplicationTimeout		=	5000;

                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].u8NoofObject                    			=   8;
                    // Allocate memory for objects
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects = calloc(sDNP3Config.sDNP3ClientSet.psClientObjects[0].u8NoofObject , sizeof(struct sDNP3clObject));
                    if(sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects == NULL)
                    {
                     printf("\r\nError: Not enough memory to alloc objects");
                     break;
                    }

                    strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].ai8Name,"binary input 0-9");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].eGroupID       =   BINARY_INPUT;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].u16StartingIndexAddress	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].u16NoofPoints  =   10;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].eClassID       =   CLASS_THREE;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].eControlModel  =   INPUT_STATUS_ONLY;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].u32SBOTimeOut  =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[0].f32AnalogInputDeadband  =   0;

                    strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].ai8Name,"double input 0-9");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].eGroupID       =   DOUBLE_INPUT;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].u16StartingIndexAddress	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].u16NoofPoints  =   10;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].eClassID       =   CLASS_THREE;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].eControlModel  =   INPUT_STATUS_ONLY;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].u32SBOTimeOut  =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[1].f32AnalogInputDeadband =   0;

                    strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].ai8Name,"binary output 0-8");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].eGroupID       =   BINARY_OUTPUT;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].u16StartingIndexAddress	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].u16NoofPoints  =   9;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].eClassID       =   NO_CLASS;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].eControlModel  =   SELECT_BEFORE_OPERATION;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].u32SBOTimeOut  =   5000;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[2].f32AnalogInputDeadband  =  0;

                    strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].ai8Name,"counter input 0-9");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].eGroupID       =   COUNTER_INPUT;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].u16StartingIndexAddress	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].u16NoofPoints  =   10;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].eClassID       =   CLASS_ONE;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].eControlModel  =   INPUT_STATUS_ONLY;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].u32SBOTimeOut  =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[3].f32AnalogInputDeadband =   0;


                    strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].ai8Name,"Analog input 0-9");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].eGroupID       =   ANALOG_INPUT;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].u16StartingIndexAddress	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].u16NoofPoints  =   10;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].eClassID       =   CLASS_TWO;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].eControlModel  =   INPUT_STATUS_ONLY;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].u32SBOTimeOut  =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[4].f32AnalogInputDeadband  =   10.0;
                    
                    strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].ai8Name,"Analog output 0-8");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].eGroupID       =   ANALOG_OUTPUTS;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].u16StartingIndexAddress	=	0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].u16NoofPoints  =   9;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].eClassID       =   NO_CLASS;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].eControlModel  =   SELECT_BEFORE_OPERATION;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].u32SBOTimeOut  =   5000;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[5].f32AnalogInputDeadband  =   0;

                    strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].ai8Name,"binary output 9");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].eGroupID       =   BINARY_OUTPUT;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].u16StartingIndexAddress	=	9;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].u16NoofPoints  =   1;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].eClassID       =   NO_CLASS;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].eControlModel  =   DIRECT_OPERATION;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].u32SBOTimeOut  =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[6].f32AnalogInputDeadband  =  0;
                    
                        strcpy((char*)sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].ai8Name,"ANALOG OUTPUTS 9");
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].eGroupID       =   ANALOG_OUTPUTS;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].u16StartingIndexAddress	=	9;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].u16NoofPoints  =   1;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].eClassID       =   NO_CLASS;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].eControlModel  =   DIRECT_OPERATION;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].u32SBOTimeOut  =   0;
                    sDNP3Config.sDNP3ClientSet.psClientObjects[0].psDNP3Objects[7].f32AnalogInputDeadband  =  0;

                       // Load configuration
                   i16ErrorCode = DNP3LoadConfiguration(myClient, &sDNP3Config, &tErrorValue);
                   if(i16ErrorCode != EC_NONE)
                   {
                     printf("\r\n Error DNP3LoadConfiguration() failed:  %d %d", i16ErrorCode,  tErrorValue);
                     break;
                   } 
    \endcode
*/
'''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3LoadConfiguration(DNP3Object myDNP3Obj, struct sDNP3ConfigurationParameters * psDNP3Config, tErrorValue * ptErrorValue);
dnp3_lib.DNP3LoadConfiguration.argtypes = [DNP3Object, ctypes.POINTER(sDNP3ConfigurationParameters), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3LoadConfiguration.restype = ctypes.c_short
'''
/*! \brief          Start DNP3 object communication
    \param[in]      myDNP3Obj       DNP3 object to Start
    \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

    \return         EC_NONE on success
    \return         otherwise error code

    Server Example Usage:
    \code
                    Integer16     i16ErrorCode      = EC_NONE;
                    tErrorValue          tErrorValue        = EV_NONE;

                    //Start the DNP3 Object 
                    i16ErrorCode = DNP3Start(myServer, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("Start DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode


    Client Example Usage:
    \code
                    Integer16     i16ErrorCode      = EC_NONE;
                    tErrorValue          tErrorValue        = EV_NONE;

                    //Start the DNP3 Object 
                    i16ErrorCode = DNP3Start(myClient, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("Start DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode

*/
'''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Start(DNP3Object myDNP3Obj, tErrorValue * ptErrorValue);
dnp3_lib.DNP3Start.argtypes = [DNP3Object, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Start.restype = ctypes.c_short

'''
 /*! \brief           Set DNP3 debug options.
      \param[in]      myDNP3Obj           DNP3 object to Get Type and Size
      \param[in]      psDebugParams       Pointer to debug parameters
      \param[out]     ptErrorValue        Pointer to a Error Value (if any error occurs while creating the object)
 
      \return         EC_NONE on success
      \return         otherwise error code
 
      Server Example Usage:
      \code
                      Integer16               i16ErrorCode      = EC_NONE;
                      tErrorValue                       tErrorValue     = EV_NONE;
                      struct sDNP3DebugParameters       sDebugParams    = {0};
 
                      // Set the debug option to error, tx and rx data 
                      sDebugParams.u32DebugOptions   = DEBUG_OPTION_ERROR | DEBUG_OPTION_TX | DEBUG_OPTION_RX;
 
                      //update debug option
                      i16ErrorCode = DNP3SetDebugOptions(myServer, &sDebugParams, &tErrorValue);
                      if(i16ErrorCode != EC_NONE)
                      {
                          printf("Set debug options DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                      }
      \endcode  

      Client Example Usage:
      \code
                      Integer16               i16ErrorCode      = EC_NONE;
                      tErrorValue                       tErrorValue     = EV_NONE;
                      struct sDNP3DebugParameters       sDebugParams    = {0};
 
                      // Set the debug option to error, tx and rx data 
                      sDebugParams.u32DebugOptions   = DEBUG_OPTION_ERROR | DEBUG_OPTION_TX | DEBUG_OPTION_RX;
 
                      //update debug option
                      i16ErrorCode = DNP3SetDebugOptions(myClient, &sDebugParams, &tErrorValue);
                      if(i16ErrorCode != EC_NONE)
                      {
                          printf("Set debug options DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                      }
      \endcode 

  */
 '''
 #PUBLICAPIPX Integer16 PUBLICAPISX DNP3SetDebugOptions(DNP3Object myDNP3Obj, struct sDNP3DebugParameters *psDebugParams, tErrorValue *ptErrorValue);  
dnp3_lib.DNP3SetDebugOptions.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DebugParameters), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3SetDebugOptions.restype =  ctypes.c_short

'''
/*! \brief          Stop DNP3 object communication
    \param[in]      myDNP3Obj       DNP3 object to Stop
    \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

    \return         EC_NONE on success
    \return         otherwise error code

    Server Example Usage:
    \code
                    Integer16     i16ErrorCode      = EC_NONE;
                    tErrorValue             tErrorValue     = EV_NONE;

                    //Stop the DNP3 Object
                    i16ErrorCode = DNP3Stop(myServer, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("Stop DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode

    Client Example Usage:
    \code
                    Integer16     i16ErrorCode      = EC_NONE;
                    tErrorValue             tErrorValue     = EV_NONE;

                    //Stop the DNP3 Object
                    i16ErrorCode = DNP3Stop(myClient, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("Stop DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode

*/
'''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Stop(DNP3Object myDNP3Obj,tErrorValue * ptErrorValue);
dnp3_lib.DNP3Stop.argtypes = [DNP3Object, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Stop.restype = ctypes.c_short
'''
/*! \brief          Free memory used by DNP3 object.
    \param[in]      myDNP3Obj     DNP3 object to free
    \param[out]     ptErrorValue  Pointer to a Error Value (if any error occurs while creating the object)

    \return         EC_NONE on success
    \return         otherwise error code

    Server Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue                 tErrorValue     = EV_NONE;

                    //Free DNP3 Object
                    i16ErrorCode = DNP3Free(myServer, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("Free DNP3 Object has failed: %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode

    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue                 tErrorValue     = EV_NONE;

                    //Free DNP3 Object
                    i16ErrorCode = DNP3Free(myClient, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("Free DNP3 Object has failed: %i %i", i16ErrorCode, tErrorValue);
                    }
    \endcode

*/
'''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Free(DNP3Object myDNP3Obj, tErrorValue * ptErrorValue);
dnp3_lib.DNP3Free.argtypes = [DNP3Object, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Free.restype = ctypes.c_short
'''

/*!\brief           Update DNP3 data attribute ID to the New Value. 
    \param[in]      myDNP3Obj       DNP3 object to Update
    \param[in]      psDAID          Pointer to DNP3 Data Attribute ID
    \param[in]      psNewValue      Pointer to DNP3 Data Attribute Data
    \param[in]      u16Count        Number of DNP3 Data attribute ID and Data attribute data to be updated simultaneously
    \param[in]      eUpdateClass  eUpdateClassID - here, we can decide, the event generate , you can chose, default, no event, create class 1 / 2/ 3 event
    \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

    \return         EC_NONE on success
    \return         otherwise error code

    Server Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    Unsigned8                   u8Data          =   0;
                    Unsigned16                  u16Count        =   0;
                    struct sDNP3DataAttributeID *psDAID         =   NULL;   //update data attribute
                    struct sDNP3DataAttributeData *psNewValue   =   NULL;   //updtae new value

                    
                    u16Count    =   1;
                    psDAID      =   calloc(u16Count,sizeof(struct sDNP3DataAttributeID));
                    psNewValue  =   calloc(u16Count,sizeof(struct sDNP3DataAttributeData));

                    psDAID[0].u16SlaveAddress	=	1;
                    psDAID[0].eGroupID          =   BINARY_INPUT;
                    psDAID[0].u16IndexNumber    =   2;      //3rd element

                    psNewValue[0].eDataSize     =   SINGLE_POINT_SIZE;
                    psNewValue[0].eDataType     =   SINGLE_POINT_DATATYPE;
                    psNewValue[0].tQuality      =   (ONLINE |   RESTART);

                    //current date 10/2/2013
                    psNewValue[0].sTimeStamp.u8Day              =   10;
                    psNewValue[0].sTimeStamp.u8Month            =   2;
                    psNewValue[0].sTimeStamp.u16Year            =   2013;

                    //time 13.35.0
                    psNewValue[0].sTimeStamp.u8Hour             =   13;
                    psNewValue[0].sTimeStamp.u8Minute           =   35;
                    psNewValue[0].sTimeStamp.u8Seconds          =   0;
                    psNewValue[0].sTimeStamp.u16MilliSeconds    =   0;
                    psNewValue[0].sTimeStamp.u16MicroSeconds    =   0;
                    psNewValue[0].sTimeStamp.i8DSTTime          =   0; //No Day light saving time
                    psNewValue[0].sTimeStamp.u8DayoftheWeek     =   4;

                    psNewValue[0].pvData                        =   &u8Data;
                    // Update server
                    i16ErrorCode = DNP3Update(myServer, psDAID, psNewValue, u16Count, &tErrorValue);  //Update myServer
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Update() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode            
*/ 
'''           
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Update(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psNewValue, Unsigned16 u16Count, enum eUpdateClassID eUpdateClass, tErrorValue * ptErrorValue);
u16Count = ctypes.c_ushort
eUpdateClass = ctypes.c_int
dnp3_lib.DNP3Update.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), u16Count, eUpdateClass, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Update.restype = ctypes.c_short
'''
/*!\brief           Read a value to a given Object ID. 
    \param[in]      myDNP3Obj        DNP3 object 
    \param[in]      psDAID           Pointer to DNP3 DataAttributeID structure (or compatable) that idendifies the point that is to be read
    \param[in]      psReturnedValue  Pointer to Object Data structure that hold the returned vaule
    \param[out]     ptErrorValue     Pointer to a Error Value (if any error occurs while reading the object)

    \return         EC_NONE on success
    \return         otherwise error code

    Server Example Usage:
                    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    struct sDNP3DataAttributeID   sDAID         =   {0};   
                    struct sDNP3DataAttributeData sNewValue     =   {0};   

                    
                    sDAID.u16SlaveAddress	=	1;            
                    sDAID.eGroupID          =   BINARY_INPUT;
                    sDAID.u16IndexNumber    =   2;      //3rd element           

                    
                    i16ErrorCode = DNP3Read(myServer, &sDAID, &sNewValue,&tErrorValue); 
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Read() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode 
    
    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    struct sDNP3DataAttributeID   sDAID         =   {0};   
                    struct sDNP3DataAttributeData sNewValue     =   {0};   

                    
                    sDAID.u16SlaveAddress	=	1;            
                    sDAID.eGroupID          =   BINARY_INPUT;
                    sDAID.u16IndexNumber    =   2;      //3rd element           

                    
                    i16ErrorCode = DNP3Read(myClient, &sDAID, &sNewValue,&tErrorValue); 
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Read() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode  

     
*/
'''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Read(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psReturnedValue, tErrorValue * ptErrorValue);
dnp3_lib.DNP3Read.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Read.restype = ctypes.c_short
'''
/*!\brief           Write a value to a given Object ID. 
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      eFunctionID     enum eWriteFunctionID 
    \param[in]      psDAID          Pointer to DNP3_DataAttributeID structure (or compatable) that idendifies the point that is to be written
    \param[in]      psNewValue      Pointer to Object Data structure that hold the new vaule of the tObjectID
    \param[out]     ptErrorValue    Pointer to a Error Value 

    \return         EC_NONE on success
    \return         otherwise error code
    
    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    struct sDNP3DataAttributeID   sDAID         =   {0};   
                    struct sDNP3DataAttributeData sNewValue     =   {0};   


                    i16ErrorCode = DNP3Write(myClient, &sDAID, &sNewValue,&tErrorValue); 
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Write() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode            
*/ 
'''           
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Write(DNP3Object myDNP3Obj, enum eWriteFunctionID eFunctionID, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psNewValue, tErrorValue * ptErrorValue);
eFunctionID = ctypes.c_int
dnp3_lib.DNP3Write.argtypes = [DNP3Object, eFunctionID, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Write.restype = ctypes.c_short
'''
/*!\brief           Select a given control Data object. 
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Selected
    \param[in]      psSelectValue   Pointer to DNP3 Data Attribute Data (The value the control is to be set)
    \param[in]      psSelectParams  Pointer to DNP3 struct sDNP3CommandParameters 
    \param[out]     ptErrorValue    Pointer to a Error Value 

    \return         EC_NONE on success
    \return         otherwise error code

    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    Unsigned8                   u8Data          =   0;
                    struct sDNP3DataAttributeID sDAID           =   {0};
                    struct sDNP3DataAttributeData sValue        =   {0};  
                    struct sDNP3CommandParameters sParams       =   {0};

                                
                    sDAID.eGroupID  =   BINARY_OUTPUT;
                    sDAID.u16SlaveAddress   =   8;
                    sDAID.u16IndexNumber    =   123;
                    sValue.eDataSize    =   SINGLE_POINT_SIZE;
                    sValue.eDataType    =   SINGLE_POINT_DATA;
                    sValue.tQuality     =   GOOD;
                    u8Data              =   1;
                    sValue.pvData       =   &u8Data;
                    
                    sValue.sTimeStamp.u8Day             =   1;
                    sValue.sTimeStamp.u8Month           =   4;
                    sValue.sTimeStamp.u16Year           =   2013;
                    //time 13.35.0
                    sValue.sTimeStamp.u8Hour            =   10;
                    sValue.sTimeStamp.u8Minute          =   0;
                    sValue.sTimeStamp.u8Seconds     =   0;
                    sValue.sTimeStamp.u16MilliSeconds   =   0;
                    sValue.sTimeStamp.u16MicroSeconds   =   0;
                    sValue.sTimeStamp.i8DSTTime     =   0; //No Day light saving time
                    sValue.sTimeStamp.u8DayoftheWeek    =   4;
                    
                    sParams.u8Count =   1;
                    sParams.eOPType =   PULSE_ON;
                    sParams.u32ONtime   =   1000;
                    sParams.u32OFFtime  =   1000;

                    
                    i16ErrorCode = DNP3Select(myClient, &sDAID, &sValue, &sParams, &tErrorValue);  
                    if(i16ErrorCode != EC_NONE)
                    {  
                        printf("\r\n Error select() failed: %d %d", i16ErrorCode,  tErrorValue);
                    }

    \endcode
*/ 
'''           
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Select(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psSelectValue, struct sDNP3CommandParameters *psSelectParams, tErrorValue * ptErrorValue);
dnp3_lib.DNP3Select.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Select.restype = ctypes.c_short
'''
/*!\brief           Send an Operate command on given control Data object. 
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Operated
    \param[in]      psOperateValue  Pointer to DNP3 Data Attribute Data (The value the control is to be set )
    \param[in]      psOperateParams Pointer to DNP3 struct sDNP3CommandParameters 
    \param[out]     ptErrorValue    Pointer to a Error Value 

    \return         EC_NONE on success
    \return         otherwise error code

    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    Unsigned8                   u8Data          =   0;
                    struct sDNP3DataAttributeID sDAID           =   {0};
                    struct sDNP3DataAttributeData sValue        =   {0};  
                    struct sDNP3CommandParameters sParams       =   {0};

                                
                    sDAID.eGroupID  =   BINARY_OUTPUT;
                    sDAID.u16SlaveAddress   =   8;
                    sDAID.u16IndexNumber    =   123;
                    sValue.eDataSize    =   SINGLE_POINT_SIZE;
                    sValue.eDataType    =   SINGLE_POINT_DATA;
                    sValue.tQuality     =   GOOD;
                    u8Data              =   1;
                    sValue.pvData       =   &u8Data;
                    
                    sValue.sTimeStamp.u8Day             =   1;
                    sValue.sTimeStamp.u8Month           =   4;
                    sValue.sTimeStamp.u16Year           =   2013;
                    //time 13.35.0
                    sValue.sTimeStamp.u8Hour            =   10;
                    sValue.sTimeStamp.u8Minute          =   0;
                    sValue.sTimeStamp.u8Seconds     =   0;
                    sValue.sTimeStamp.u16MilliSeconds   =   0;
                    sValue.sTimeStamp.u16MicroSeconds   =   0;
                    sValue.sTimeStamp.i8DSTTime     =   0; //No Day light saving time
                    sValue.sTimeStamp.u8DayoftheWeek    =   4;
                    
                    sParams.u8Count =   1;
                    sParams.eOPType =   PULSE_ON;
                    sParams.u32ONtime   =   1000;
                    sParams.u32OFFtime  =   1000;

                    
                    i16ErrorCode = DNP3Operate(myClient, &sDAID, &sValue, &sParams, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Operate() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode            
*/ 
'''            
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Operate(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psOperateValue,struct sDNP3CommandParameters *psOperateParams, tErrorValue * ptErrorValue);
dnp3_lib.DNP3Operate.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3Operate.restype = ctypes.c_short
'''
/*!\brief           SelectBeforeOperate a given control Data object. 
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Selected
    \param[in]      psSelectValue   Pointer to DNP3 Data Attribute Data (The value the control is to be set)
    \param[in]      psSelectParams  Pointer to DNP3 struct sDNP3CommandParameters 
    \param[out]     ptErrorValue    Pointer to a Error Value 

    \return         EC_NONE on success
    \return         otherwise error code

    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    Unsigned8                   u8Data          =   0;
                    struct sDNP3DataAttributeID sDAID           =   {0};
                    struct sDNP3DataAttributeData sValue        =   {0};  
                    struct sDNP3CommandParameters sParams       =   {0};

                                
                    sDAID.eGroupID  =   BINARY_OUTPUT;
                    sDAID.u16SlaveAddress   =   8;
                    sDAID.u16IndexNumber    =   123;
                    sValue.eDataSize    =   SINGLE_POINT_SIZE;
                    sValue.eDataType    =   SINGLE_POINT_DATA;
                    sValue.tQuality     =   GOOD;
                    u8Data              =   1;
                    sValue.pvData       =   &u8Data;
                    
                    sValue.sTimeStamp.u8Day             =   1;
                    sValue.sTimeStamp.u8Month           =   4;
                    sValue.sTimeStamp.u16Year           =   2013;
                    //time 13.35.0
                    sValue.sTimeStamp.u8Hour            =   10;
                    sValue.sTimeStamp.u8Minute          =   0;
                    sValue.sTimeStamp.u8Seconds     =   0;
                    sValue.sTimeStamp.u16MilliSeconds   =   0;
                    sValue.sTimeStamp.u16MicroSeconds   =   0;
                    sValue.sTimeStamp.i8DSTTime     =   0; //No Day light saving time
                    sValue.sTimeStamp.u8DayoftheWeek    =   4;
                    
                    sParams.u8Count =   1;
                    sParams.eOPType =   PULSE_ON;
                    sParams.u32ONtime   =   1000;
                    sParams.u32OFFtime  =   1000;

                    
                    i16ErrorCode = DNP3SelectBeforeOperate(myClient, &sDAID, &sValue, &sParams, &tErrorValue);  
                    if(i16ErrorCode != EC_NONE)
                    {  
                        printf("\r\n Error select() failed: %d %d", i16ErrorCode,  tErrorValue);
                    }

    \endcode
*/ 
'''           
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3SelectBeforeOperate(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psSelectValue, struct sDNP3CommandParameters *psSelectParams, tErrorValue * ptErrorValue);
dnp3_lib.DNP3SelectBeforeOperate.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3SelectBeforeOperate.restype = ctypes.c_short
'''
/*!\brief           Send an Direct Operate command with out ack from server on given control Data object. 
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Operated
    \param[in]      psOperateValue  Pointer to DNP3 Data Attribute Data (The value the control is to be set )
    \param[in]      psOperateParams Pointer to DNP3 struct sDNP3CommandParameters 
    \param[out]     ptErrorValue    Pointer to a Error Value 

    \return         EC_NONE on success
    \return         otherwise error code

    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    Unsigned8                   u8Data          =   0;
                    struct sDNP3DataAttributeID sDAID           =   {0};
                    struct sDNP3DataAttributeData sValue        =   {0};  
                    struct sDNP3CommandParameters sParams       =   {0};

                                
                    sDAID.eGroupID  =   BINARY_OUTPUT;
                    sDAID.u16SlaveAddress   =   8;
                    sDAID.u16IndexNumber    =   123;
                    sValue.eDataSize    =   SINGLE_POINT_SIZE;
                    sValue.eDataType    =   SINGLE_POINT_DATA;
                    sValue.tQuality     =   GOOD;
                    u8Data              =   1;
                    sValue.pvData       =   &u8Data;
                    
                    sValue.sTimeStamp.u8Day             =   1;
                    sValue.sTimeStamp.u8Month           =   4;
                    sValue.sTimeStamp.u16Year           =   2013;
                    //time 13.35.0
                    sValue.sTimeStamp.u8Hour            =   10;
                    sValue.sTimeStamp.u8Minute          =   0;
                    sValue.sTimeStamp.u8Seconds     =   0;
                    sValue.sTimeStamp.u16MilliSeconds   =   0;
                    sValue.sTimeStamp.u16MicroSeconds   =   0;
                    sValue.sTimeStamp.i8DSTTime     =   0; //No Day light saving time
                    sValue.sTimeStamp.u8DayoftheWeek    =   4;
                    
                    sParams.u8Count =   1;
                    sParams.eOPType =   PULSE_ON;
                    sParams.u32ONtime   =   1000;
                    sParams.u32OFFtime  =   1000;

                    
                    i16ErrorCode = DNP3DirectOperateWithNoAck(myClient, &sDAID, &sValue, &sParams, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Operate() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode            
*/ 
'''            
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3DirectOperateWithNoAck(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psOperateValue,struct sDNP3CommandParameters *psOperateParams, tErrorValue * ptErrorValue);
dnp3_lib.DNP3DirectOperateWithNoAck.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3DirectOperateWithNoAck.restype = ctypes.c_short
'''
/*!\brief           Send an Direct Operate command on given control Data object. 
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Operated
    \param[in]      psOperateValue  Pointer to DNP3 Data Attribute Data (The value the control is to be set )
    \param[in]      psOperateParams Pointer to DNP3 struct sDNP3CommandParameters 
    \param[out]     ptErrorValue    Pointer to a Error Value 

    \return         EC_NONE on success
    \return         otherwise error code

    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    Unsigned8                   u8Data          =   0;
                    struct sDNP3DataAttributeID sDAID           =   {0};
                    struct sDNP3DataAttributeData sValue        =   {0};  
                    struct sDNP3CommandParameters sParams       =   {0};

                                
                    sDAID.eGroupID  =   BINARY_OUTPUT;
                    sDAID.u16SlaveAddress   =   8;
                    sDAID.u16IndexNumber    =   123;
                    sValue.eDataSize    =   SINGLE_POINT_SIZE;
                    sValue.eDataType    =   SINGLE_POINT_DATA;
                    sValue.tQuality     =   GOOD;
                    u8Data              =   1;
                    sValue.pvData       =   &u8Data;
                    
                    sValue.sTimeStamp.u8Day             =   1;
                    sValue.sTimeStamp.u8Month           =   4;
                    sValue.sTimeStamp.u16Year           =   2013;
                    //time 13.35.0
                    sValue.sTimeStamp.u8Hour            =   10;
                    sValue.sTimeStamp.u8Minute          =   0;
                    sValue.sTimeStamp.u8Seconds     =   0;
                    sValue.sTimeStamp.u16MilliSeconds   =   0;
                    sValue.sTimeStamp.u16MicroSeconds   =   0;
                    sValue.sTimeStamp.i8DSTTime     =   0; //No Day light saving time
                    sValue.sTimeStamp.u8DayoftheWeek    =   4;
                    
                    sParams.u8Count =   1;
                    sParams.eOPType =   PULSE_ON;
                    sParams.u32ONtime   =   1000;
                    sParams.u32OFFtime  =   1000;

                    
                    i16ErrorCode = DNP3DirectOperate(myClient, &sDAID, &sValue, &sParams, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Operate() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode            
*/ 
'''            
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3DirectOperate(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psOperateValue, struct sDNP3CommandParameters *psOperateParams, tErrorValue * ptErrorValue);
dnp3_lib.DNP3DirectOperate.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3DirectOperate.restype = ctypes.c_short
'''

/*!\brief           Cancel current command on given control Data object. 
    \param[in]      myDNP3Obj       DNP3 object 
    \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be canceled
    \param[in]      psCancelValue   Pointer to DNP3 Data Attribute Data (The value the control is to be set to)
    \param[in]      psCancelParams  Pointer to struct sDNP3CommandParameters 
    \param[out]     ptErrorValue    Pointer to a Error Value 

    \return         EC_NONE on success
    \return         otherwise error code

    Client Example Usage:
    \code
                    Integer16         i16ErrorCode      = EC_NONE;
                    tErrorValue              tErrorValue        = EV_NONE;
                    Unsigned8                   u8Data          =   0;
                    struct sDNP3DataAttributeID sDAID           =   {0};
                    struct sDNP3DataAttributeData sValue        =   {0};  
                    struct sDNP3CommandParameters sParams       =   {0};

                                
                    sDAID.eGroupID  =   BINARY_OUTPUT;
                    sDAID.u16SlaveAddress   =   8;
                    sDAID.u16IndexNumber    =   123;
                    sValue.eDataSize    =   SINGLE_POINT_SIZE;
                    sValue.eDataType    =   SINGLE_POINT_DATA;
                    sValue.tQuality     =   GOOD;
                    u8Data              =   1;
                    sValue.pvData       =   &u8Data;
                    
                    sValue.sTimeStamp.u8Day             =   1;
                    sValue.sTimeStamp.u8Month           =   4;
                    sValue.sTimeStamp.u16Year           =   2013;
                    //time 13.35.0
                    sValue.sTimeStamp.u8Hour            =   10;
                    sValue.sTimeStamp.u8Minute          =   0;
                    sValue.sTimeStamp.u8Seconds     =   0;
                    sValue.sTimeStamp.u16MilliSeconds   =   0;
                    sValue.sTimeStamp.u16MicroSeconds   =   0;
                    sValue.sTimeStamp.i8DSTTime     =   0; //No Day light saving time
                    sValue.sTimeStamp.u8DayoftheWeek    =   4;
                    
                    sParams.u8Count =   1;
                    sParams.eOPType =   PULSE_ON;
                    sParams.u32ONtime   =   1000;
                    sParams.u32OFFtime  =   1000;

                    
                    i16ErrorCode = DNP3Cancel(myClient, &sDAID, &sValue, &sParams, &tErrorValue);
                    if(i16ErrorCode != EC_NONE)
                    {
                        printf("\r\nError: DNP3Operate() failed:  %i %i", i16ErrorCode, tErrorValue);
                        
                    }
    \endcode           
*/ 
'''            

#PUBLICAPIPX Integer16 PUBLICAPISX DNP3Cancel(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psCancelValue, struct sDNP3CommandParameters *psCancelParams,tErrorValue * ptErrorValue);
#dnp3_lib.DNP3Cancel.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ctypes.POINTER(ctypes.c_short) ]
#dnp3_lib.DNP3Cancel.restype = ctypes.c_short


'''

/*! \brief        Get DNP3 data type and data size to the returned Value.
    \param[in]    myDNP3Obj           DNP3 object to Get Type and Size
    \param[in]    psDAID              Pointer to DNP3 Data Attribute ID
    \param[out]   psReturnedValue     Pointer to DNP3 Data Attribute Data containing only data type and data size.
    \param[out]   ptErrorValue        Pointer to a Error Value 
         
    \return       EC_NONE on success
    \return       otherwise error code
         
    Server Example Usage:
    \code
                Integer16     i16ErrorCode                  = EC_NONE;
                tErrorValue          tErrorValue                    = EV_NONE;
                struct sDNP3DataAttributeID      sDAID              = {0};
                struct sDNP3DataAttributeData    sReturnedValue     = {0};
         
                // Set the Group ID for which you want to get the datatype and datasize 
                sDAID.eGroupID          =   DOUBLE_INPUT;
         
                //Call function to get type and size
                i16ErrorCode = DNP3GetDataTypeAndSize(myServer, &sDAID, &sReturnedValue, &tErrorValue);
                if(i16ErrorCode != EC_NONE)
                {
                    printf("Get Type DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                }
                else
                {
                    printf("\r\n Type is : %u, Size is %u", sReturnedValue.eDataType, sReturnedValue.eDataSize);
                }
    \endcode   

    Client Example Usage:
    \code
                Integer16     i16ErrorCode                  = EC_NONE;
                tErrorValue          tErrorValue                    = EV_NONE;
                struct sDNP3DataAttributeID      sDAID              = {0};
                struct sDNP3DataAttributeData    sReturnedValue     = {0};
         
                // Set the Group ID for which you want to get the datatype and datasize 
                sDAID.eGroupID          =   DOUBLE_INPUT;
         
                //Call function to get type and size
                i16ErrorCode = DNP3GetDataTypeAndSize(myClient, &sDAID, &sReturnedValue, &tErrorValue);
                if(i16ErrorCode != EC_NONE)
                {
                    printf("Get Type DNP3 has failed: %i %i", i16ErrorCode, tErrorValue);
                }
                else
                {
                    printf("\r\n Type is : %u, Size is %u", sReturnedValue.eDataType, sReturnedValue.eDataSize);
                }
    \endcode

*/
'''
 #PUBLICAPIPX Integer16 PUBLICAPISX DNP3GetDataTypeAndSize(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DataAttributeData * psReturnedValue, tErrorValue * ptErrorValue);
dnp3_lib.DNP3GetDataTypeAndSize.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3GetDataTypeAndSize.restype = ctypes.c_short
'''
/*! \brief		  Get dnp3 Client Connection Status.
 *	\par		  Get DNP3 Get Client connection status.
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   *peSat			  Pointer to enum eServerConnectionStatus 
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3ClientStatus(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, enum eServerConnectionStatus *peSat, tErrorValue *ptErrorValue);
eSat = ctypes.c_int
peSat= ctypes.POINTER(eSat)
dnp3_lib.DNP3ClientStatus.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), peSat, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3ClientStatus.restype = ctypes.c_short
'''
/*! \brief		  DNP3 File read.
 *	\par		  Get DNP3 File Read.
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   psDNP3FileAttributeData			  Pointer to struct sDNP3FileAttributeData 
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3FileRead(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3FileAttributeData *psDNP3FileAttributeData, tErrorValue * ptErrorValue);
dnp3_lib.DNP3FileRead.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3FileAttributeData), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3FileRead.restype = ctypes.c_short
'''
/*! \brief		  DNP3 File write.
 *	\par		  Get DNP3 File write.
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   psDNP3FileAttributeData			  Pointer to struct sDNP3FileAttributeData 
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3FileWrite(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3FileAttributeData *psDNP3FileAttributeData, tErrorValue * ptErrorValue);
dnp3_lib.DNP3FileWrite.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3FileAttributeData), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3FileWrite.restype = ctypes.c_short
'''
/*! \brief		  DNP3 Read DataSet Prototype
 *	\par		  Get DNP3 Read DataSet Prototype
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   psClDatasetPrototype 			  Pointer to struct sClientDatasetPrototype 
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3ReadDataSetPrototype(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sClientDatasetPrototype *psClDatasetPrototype, tErrorValue * ptErrorValue);
dnp3_lib.DNP3ReadDataSetPrototype.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sClientDatasetPrototype), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3ReadDataSetPrototype.restype = ctypes.c_short
'''
/*! \brief		  DNP3 Read DataSet Descriptor
 *	\par		  Get DNP3 Read DataSet Descriptor
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   psClDatasetDescriptor			  Pointer to struct sClientDatasetPrototype 
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3ReadDataSetDescriptor(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sClientDatasetPrototype *psClDatasetDescriptor, tErrorValue * ptErrorValue);
dnp3_lib.DNP3ReadDataSetDescriptor.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sClientDatasetPrototype), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3ReadDataSetDescriptor.restype = ctypes.c_short

'''
/*! \brief		  DNP3 Read DataSet Present Value
 *	\par		  Get DNP3 Read DataSet Present Value
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   *psClDatasetPsValue			  Pointer to struct sClientDatasetPresentvalue  
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3ReadDataSetPresentValue(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sClientDatasetPresentvalue *psClDatasetPsValue, tErrorValue * ptErrorValue);
dnp3_lib.DNP3ReadDataSetPresentValue.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sClientDatasetPresentvalue), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3ReadDataSetPresentValue.restype = ctypes.c_short
'''
/*! \brief		  DNP3 Directory Read
 *	\par		  Get DNP3 Directory Read
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   *psDNP3DirAttributeData			  Pointer to struct sDNP3DirAttributeData  
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3DirectoryRead(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, struct sDNP3DirAttributeData *psDNP3DirAttributeData, tErrorValue * ptErrorValue);
dnp3_lib.DNP3DirectoryRead.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DirAttributeData), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3DirectoryRead.restype = ctypes.c_short
'''
/*! \brief		  DNP3 Get Server Database Value
 *	\par		  DNP3 Get Server Database Value
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[out]   *psDNPServerDatabase Pointer to struct sDNPServerDatabase  
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3GetServerDatabaseValue(DNP3Object myDNP3Obj, struct sDNPServerDatabase *psDNPServerDatabase, tErrorValue * ptErrorValue);
dnp3_lib.DNP3GetServerDatabaseValue.argtypes = [DNP3Object, ctypes.POINTER(sDNPServerDatabase), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3GetServerDatabaseValue.restype = ctypes.c_short
'''
/*! \brief		  DNP3 Get Client Database Value
 *	\par		  DNP3 Get Client Database Value
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[out]   *psDNPClientDatabase Pointer to struct sDNPClientDatabase  
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3GetClientDatabaseValue(DNP3Object myDNP3Obj, struct sDNPClientDatabase *psDNPClientDatabase, tErrorValue * ptErrorValue);
dnp3_lib.DNP3GetClientDatabaseValue.argtypes = [DNP3Object, ctypes.POINTER(sDNPClientDatabase), ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3GetClientDatabaseValue.restype = ctypes.c_short
'''
/*! \brief		  DNP3 Read Device Attribute Data
 *	\par		  DNP3 Read Device Attribute Data
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[in]    u8Variation         variation to read and get value  
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
 #PUBLICAPIPX Integer16 PUBLICAPISX DNP3ReadDeviceAttribute(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, Unsigned8  u8Variation, tErrorValue * ptErrorValue);
u8Variation = ctypes.c_ubyte
dnp3_lib.DNP3ReadDeviceAttribute.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), u8Variation, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3ReadDeviceAttribute.restype = ctypes.c_short
'''
/*! \brief		  DNP3 Client Get IIN
 *	\par		  DNP3 Client Get Internal Indication
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   *pu8IIN1             Pointer to Unsigned8 IIN 1
 *	\param[out]   *pu8IIN2             Pointer to Unsigned8 IIN 2
 *	\param[out]   *ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
u8IIN1 = ctypes.c_ubyte
pu8IIN1 = ctypes.POINTER(u8IIN1)
u8IIN2 = ctypes.c_ubyte
pu8IIN2 = ctypes.POINTER(u8IIN2)

#PUBLICAPIPX Integer16 PUBLICAPISX DNP3ClientGetIIN(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID,  Unsigned8 *pu8IIN1, Unsigned8 *pu8IIN2, tErrorValue *ptErrorValue);
dnp3_lib.DNP3ClientGetIIN.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), pu8IIN1, pu8IIN2, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3ClientGetIIN.restype = ctypes.c_short

'''
/*! \brief		  Get DNP3 object Status.
 *	\par		  Get DNP3 Get object status -  loaded, running, stoped, freed.
 *
 *	\param[in]	  myDNP3Obj		  DNP3 object 
 *	\param[out]   *peCurrentState	  Pointer to enum  eAppState   
 *	\param[out]   *ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
'''
#PUBLICAPIPX Integer16 PUBLICAPISX GetDNP3ObjectStatus(DNP3Object myDNP3Obj, enum  eAppState  *peCurrentState, tErrorValue *ptErrorValue);
eCurrentState = ctypes.c_int
peCurrentState= ctypes.POINTER(eCurrentState)
dnp3_lib.GetDNP3ObjectStatus.argtypes = [DNP3Object, peCurrentState, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.GetDNP3ObjectStatus.restype = ctypes.c_short

'''
 /*! \brief		  Get Error code String
*  \par 		   For particular Error code , get Error String
*
*  \param[in]	   *psDNP3ErrorCodeDes - Pointer to struct sDNP3ErrorCode
*
*  \return		   error code string
*/
'''
 #PUBLICAPIPX void PUBLICAPISX DNP3ErrorCodeString(struct sDNP3ErrorCode *psDNP3ErrorCodeDes);
dnp3_lib.DNP3ErrorCodeString.argtypes = [ctypes.POINTER(sDNP3ErrorCode)]
dnp3_lib.DNP3ErrorCodeString.restype = None
'''
/*! \brief		  Get Error value String
*  \par 		   For particular Error value , get Error String
*
*  \param[in]	   *psDNP3ErrorValueDes - Pointer to struct sDNP3ErrorValue 
*
*  \return		   error value string
*/
'''
 #PUBLICAPIPX void PUBLICAPISX DNP3ErrorValueString(struct sDNP3ErrorValue *psDNP3ErrorValueDes);
dnp3_lib.DNP3ErrorValueString.argtypes = [ctypes.POINTER(sDNP3ErrorValue)]
dnp3_lib.DNP3ErrorValueString.restype = None

'''
/*! \brief			   Get DNP3 Library License information
 *	\par			   Function used to get DNP3 Library License information
 *
 *	\return 		   License information of library as a string of char 
 *	Example Usage:
 *	\code
 *		printf("Version number: %s", DNP3GetLibraryVersion(void));
 *	\endcode
 */
 '''
#PUBLICAPIPX const Integer8 * PUBLICAPISX DNP3GetLibraryLicenseInfo(void);
dnp3_lib.DNP3GetLibraryLicenseInfo.argtypes = None
dnp3_lib.DNP3GetLibraryLicenseInfo.restype = ctypes.c_char_p


'''
/*! \brief		  Get dnp3 Client - stop/start polling particular server in serial multi drop
 *	\par		  Get DNP3 Get Client - stop/start polling particular server in serial multi drop
 *
 *	\param[in]	  myDNP3Obj 	  DNP3 object 
 *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
 *	\param[out]   bStop 			True - stop , false - start polling particular server/device
 *	\param[out]   ptErrorValue		  Pointer to a Error Value
 *
 *	\return 	  EC_NONE on success
 *	\return 	  otherwise error code
 */
 '''
#PUBLICAPIPX Integer16 PUBLICAPISX DNP3ClientStopServerMultidrop(DNP3Object myDNP3Obj, struct sDNP3DataAttributeID * psDAID, Boolean bStop, tErrorValue *ptErrorValue);
bStop = ctypes.c_bool
dnp3_lib.DNP3ClientStopServerMultidrop.argtypes = [DNP3Object, ctypes.POINTER(sDNP3DataAttributeID), bStop, ctypes.POINTER(ctypes.c_short) ]
dnp3_lib.DNP3ClientStopServerMultidrop.restype = ctypes.c_short