/*****************************************************************************/
/*! \file          dnp3types.h
   *  \brief       DNP3 Server and Client API-types Header file
   *  \author      FreyrSCADA Embedded Solution Pvt Ltd
   *  \copyright (c) FreyrSCADA Embedded Solution Pvt Ltd. All rights reserved.
   *
   * THIS IS PROPRIETARY SOFTWARE AND YOU NEED A LICENSE TO USE OR REDISTRIBUTE.
   *
   * THIS SOFTWARE IS PROVIDED BY FREYRSCADA AND CONTRIBUTORS ``AS IS'' AND ANY
   * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
   * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
   * PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL FREYRSCADA OR CONTRIBUTORS BE
   * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
   * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
   * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
   * BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
   * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
   * OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
   * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/ 
/*****************************************************************************/



#ifndef DNP3TYPES_H
    /*! \brief  Define DNP3 Types */
    #define DNP3TYPES_H       1



    #ifdef __cplusplus
        extern "C" {
    #endif

        #include <tgttypes.h>
        #include <tgtincludes.h>
        #include <tgtcommon.h>
        #include <tgtserialtypes.h>


       

        /*! \brief  Max Size of Rx Message sent to callback */
        #define DNP3_MAX_RX_MESSAGE          292

        /*! \brief  Max Size of Tx Message sent to callback */
        #define DNP3_MAX_TX_MESSAGE          292

     
        

        /*! Flags for struct sDNP3Parameters.uiOptions flags */
        enum eDNP3ApplicationOptionFlag
        {
            DNP3_APP_OPTION_NONE                                 = 0x00, /*!< No options set */
        };


        /*! Flags for Communication Mode serial /tcp   */
        enum  eCommunicationMode
        {
            COMM_SERIAL             = 1,            /*!< Serial communication */
            TCP_IP_MODE             =   2,          /*!<  TCP  communication */
            UDP_IP_MODE             =   3,          /*!<  UDP communication */
        };



        /*! List of error code returned by API functions */
        enum eAppErrorCodes
        {
            APP_ERROR_ERRORVALUE_IS_NULL                = -1501,		/*!< APP Error value is  null*/
            APP_ERROR_CREATE_FAILED                     = -1502,       	/*!< DNP3 create function failed */
            APP_ERROR_FREE_FAILED                       = -1503,       	/*!< DNP3 free function failed */
            APP_ERROR_INITIALIZE                        = -1504,       	/*!< DNP3 server/client initialize function failed */
            APP_ERROR_LOADCONFIG_FAILED                 = -1505,       	/*!< DNP3 Load configuration function failed */
            APP_ERROR_CHECKALLOCLOGICNODE               = -1506,       	/*!< DNP3 Load- check alloc logical node function failed */
            APP_ERROR_START_FAILED                      = -1507,       	/*!< DNP3 Start function failed */
            APP_ERROR_STOP_FAILED                       = -1508,       	/*!< DNP3 Stop function failed */
            APP_ERROR_SETDEBUGOPTIONS_FAILED            = -1509,       	/*!< DNP3 set debug option failed */
            APP_ERROR_PHYSICALLAYEROPEN_FAILED          = -1510,      	/*!< DNP3 Physical Layer open operation failed  */
            APP_ERROR_PHYSICALLAYERCLOSE_FAILED         = -1511,      	/*!< DNP3 Physical Layer close operation failed */
            APP_ERROR_SERIALCOMOPEN_FAILED              = -1512,      	/*!< DNP3 Physical Layer com open failed    */
            APP_ERROR_SERIALCOMCLOSE_FAILED             = -1513,      	/*!< DNP3 Physical Layer com close failed   */
            APP_ERROR_PHYSICALINITIALIZE_FAILED         = -1514,      	/*!< DNP3 Physical Layer initialization failed  */
            APP_ERROR_LINKLAYER_INITIALIZE              = -1515,      	/*!< DNP3 Data Link Layer initialization failed */
            APP_ERROR_LINKLAYER_DEINITIALIZE            = -1516,      	/*!< DNP3 Data Link Layer deinitialization failed   */
            APP_ERROR_LINKLAYER_INVALIDSTATE            = -1517,      	/*!< DNP3 Data Link Layer Connection invalid state  */
            APP_ERROR_TCPWAIT_FAILED                    = -1518,      	/*!< DNP3 physical layer ethernet wait operation failed */
            APP_ERROR_ETHERNET_INITIALIZATION_FAILED    = -1519,      	/*!< DNP3 Data Link Layer ethernet initialization like bind ip & port number failed */
            APP_ERROR_RECEIVE_FAILED                    = -1520,      	/*!< DNP3 Data Link Layer serial receive failed */
            APP_ERROR_DLDECODE_FAILED                   = -1521,      	/*!< DNP3 Data Link Layer Decode operation failed */
            APP_ERROR_TRANSLAYER_INITIALIZE             = -1522,      	/*!< DNP3 Transport function Layer initialization failed*/
            APP_ERROR_TRANSLAYER_FAILED                 = -1523,      	/*!< DNP3 Transport function Layer operation failed*/
            APP_ERROR_INVALIDDNP3_OBJECTPREFIXCODE      = -1524,      	/*!< DNP3 Transport function Layer operation failed*/
            APP_ERROR_DNP3RANGE_SPECIFIER_ERROR         = -1525,      	/*!< DNP3 app Layer decode operation failed- invalid range specifier*/
            APP_ERROR_DNP3APPL_ASDUPHARSE_FAILED        = -1526,      	/*!< DNP3 app Layer decode operation failed- asdu pharse failed*/
            APP_ERROR_APPLAYER_INITIALIZE_FAILED        = -1527,      	/*!< DNP3 App Layer initialization failed*/
            APP_ERROR_OBJECTDB_INITIALIZE_FAILED        = -1528,      	/*!< DNP3 Object Database initialization failed*/
            APP_ERROR_UPDATE_FAILED                     = -1529,      	/*!< DNP3 Update function failed */
            APP_ERROR_EVENTBUFFER_INITIALIZE_FAILED     = -1530,      	/*!< DNP3 Event Buffer initialization failed*/
            APP_ERROR_DNP3APPL_INVALID_OHDO             = -1531,      	/*!< DNP3 app Layer decode operation failed- invalid object header & data object */
            APP_ERROR_DNP3APPL_INVALID_VARIATION        = -1532,      	/*!< DNP3 app Layer decode operation failed- invalid variationr*/
            APP_ERROR_DNP3APPL_INVALID_QUALIFIER        = -1533,      	/*!< DNP3 app Layer decode operation failed- invalid qualifierr*/
            APP_ERROR_DNP3APPL_INVALID_INDEX            = -1534,      	/*!< DNP3 app Layer decode operation failed- invalid qualifier*/
            APP_ERROR_LOADCONFIG_INVALID_VAR            = -1535,      	/*!< DNP3 Load configuration function, Static / Event object variation is invalid  */
            APP_ERROR_CREATESEMAPHORE_PHYSCIALLAYER     = -1536,      	/*!< DNP3 physical layer semaphore creation is invalid  */
            APP_ERROR_DELETESEMAPHORE_PHYSCIALLAYER     = -1537,      	/*!< DNP3 physical layer semaphore deletion is invalid  */
            APP_ERROR_RESERVESEMAPHORE_PHYSCIALLAYER    = -1538,      	/*!< DNP3 physical layer semaphore reservation is invalid  */
            APP_ERROR_CREATESEMAPHORE_TRANSPORTLAYER    = -1539,      	/*!< DNP3 transport layer semaphore creation is invalid  */
            APP_ERROR_DELETESEMAPHORE_TRANSPORTLAYER    = -1540,      	/*!< DNP3 transport layer semaphore deletion is invalid  */
            APP_ERROR_RESERVESEMAPHORE_TRANSPORTLAYER   = -1541,      	/*!< DNP3 transport layer semaphore reservation is invalid  */            
            APP_ERROR_TIMESTRUCT_INVALID                = -1542,      	/*!< DNP3 time structure is invalid */
            APP_ERROR_READ_FAILED                       = -1543,      	/*!< DNP3 Read function failed */
            APP_ERROR_WRITE_FAILED                      = -1544,      	/*!< DNP3 Write function failed */
            APP_ERROR_SELECT_FAILED                     = -1545,      	/*!< DNP3 Select function failed */
            APP_ERROR_OPERATE_FAILED                    = -1546,      	/*!< DNP3 Operate function failed */
            APP_ERROR_CANCEL_FAILED                     = -1547,      	/*!< DNP3 Cancel function failed */
            APP_ERROR_GETDATATYPEANDSIZE_FAILED         = -1548,      	/*!< DNP3 Get Data type & size function failed */
            APP_ERROR_INVALID_POINTCOUNT                = -1549,      	/*!< Total Number of Points exceeding Point Count*/ 
            APP_ERROR_TCPCONNECT_FAILED                 = -1550,      	/*!< DNP3 physical layer ethernet CONNECT operation failed */
            APP_ERROR_COMMAND_FAILED                    = -1551,      	/*!< DNP3 Client command failed */
            APP_ERROR_FILEREAD_FAILED                   = -1552,     	/*!< DNP3 Client  fileread command failed */
            APP_ERROR_DATASET_READ_FAILED               = -1553,     	/*!< DNP3 Client dataset command failed */
            APP_ERROR_CLIENTSTATUS_FAILED               = -1554,     	/*!< DNP3 Client status command failed */
            APP_ERROR_FILEWRITE_FAILED                  = -1555,    	/*!< DNP3 Client file write command failed */
            APP_ERROR_READ_DEVICEATTRIBUTE_FAILED       = -1556,    	/*!< DNP3 Client device attribute read command failed */
            APP_ERROR_GETIIN1_FAILED                    = -1557,      	/*!< DNP3 Get IIN 1 function failed */
            APP_ERROR_GET_OBJECTSTATUS_FAILED           = -1558,    	/*!< DNP3 get object status command failed */
            APP_ERROR_CLIENT_STOPSERVERMULTIDROP        = -1559,		/*!< DNP3 Client Api function stop server multidrop failed */
            APP_ERROR_ADD_MULTIBLOCK       = -1560,		/*!< DNP3 Server application layer multi block addition 2048b memory alloc  */
           
        };

        /*! List of error value returned by API functions */
        enum eAppErrorValues
        {
            APP_ERRORVALUE_ERRORCODE_IS_NULL                = -1501,          /*!< APP Error code is Null */
            APP_ERRORVALUE_INVALID_INPUTPARAMETERS          = -1502,          /*!< Supplied Parameters are invalid */
            APP_ERRORVALUE_INVALID_APPFLAG                  = -1503,          /*!< Invalid Application Flag , Client not supported by the API*/
            APP_ERRORVALUE_UPDATECALLBACK_CLIENTONLY        = -1504,          /*!< Update Callback used only for client*/
            APP_ERRORVALUE_NO_MEMORY                        = -1505,          /*!< Allocation of memory has failed */
            APP_ERRORVALUE_INVALID_DNP3OBJECT               = -1506,          /*!< Supplied DNP3Object is invalid */
            APP_ERRORVALUE_DNP3FREE_CALLED_BEFORE_STOP      = -1507,          /*!< APP state is running free function called before stop function*/
            APP_ERRORVALUE_INVALID_STATE                    = -1508,          /*!< DNP3OBJECT invalid state */ 
            APP_ERRORVALUE_INVALID_DEBUG_OPTION             = -1509,          /*!< Invalid debug option */ 
            APP_ERRORVALUE_INVALID_COMMODE                  = -1510,          /*!< Invalid communication mode serial, tcp only allowed */ 
            APP_ERRORVALUE_TASK_CREATEFAILED                = -1511,          /*!< Task creation failed */ 
            APP_ERRORVALUE_TASK_STOPFAILED                  = -1512,          /*!< Task stop failed */
            APP_ERRORVALUE_DATALINKLAYER_INVALIDSTATE       = -1513,          /*!< DNP3 Data Link Layer Connection invalid state  */  
            APP_ERRORVALUE_DLRECEIVE_INVALIDSTARTCHAR       = -1514,          /*!< DNP3 slave received invalid start char  */
            APP_ERRORVALUE_DLRECEIVE_INVALIDCRC             = -1515,          /*!< DNP3 data link layer invalid CRC Received */
            APP_ERRORVALUE_DLRECEIVE_INVALIDSLAVEADDRESS    = -1516,          /*!< DNP3 data link layer invalid slave address received*/
            APP_ERRORVALUE_DLDECODE_INVALID_DIRBIT          = -1517,          /*!< DNP3 data link layer invalid direction bit received*/
            APP_ERRORVALUE_DLDECODE_INVALID_FUNCTIONCODE    = -1518,          /*!< DNP3 data link layer invalid function code received*/
            APP_ERRORVALUE_DLDECODE_INVALID_PRMBIT          = -1519,          /*!< DNP3 data link layer invalid prm bit received*/
            APP_ERRORVALUE_DLDECODE_INVALID_FCVBIT          = -1520,          /*!< DNP3 data link layer invalid FCV Bit received*/
            APP_ERRORVALUE_TRANSLAYER_INVALID_STATE         = -1521,          /*!< DNP3 transport layer invalid state*/
            APP_ERRORVALUE_TRANSLAYER_INVALID_FIRFIN        = -1522,          /*!< DNP3 transport layer invalid fir fin */
            APP_ERRORVALUE_INVALID_GROUPID                  = -1523,          /*!< In the function eGroupID not valid, or later we will implement */
            APP_ERRORVALUE_INVALIDUPDATE_COUNT              = -1524,          /*!< Invalid update count */
            APP_ERRORVALUE_UPDATEOBJECT_NOTFOUND            = -1525,          /*!< For particular group id, index number not found */
            APP_ERRORVALUE_INVALID_DATATYPE                 = -1526,          /*!< For particular group id, sDNP3DataAttributeData invalid data type */
            APP_ERRORVALUE_INVALID_DATASIZE                 = -1527,          /*!< For particular group id, sDNP3DataAttributeData invalid data size */
            APP_ERRORVALUE_INVALID_BI_STATICVAR             = -1528,          /*!< DNP3 Load config parameters Binary input static variation is invalid*/
            APP_ERRORVALUE_INVALID_DBI_STATICVAR            = -1529,          /*!< DNP3 Load config parameters Double Binary input static variation is invalid*/
            APP_ERRORVALUE_INVALID_BO_STATICVAR             = -1530,          /*!< DNP3 Load config parameters Binary Output static variation is invalid*/
            APP_ERRORVALUE_INVALID_CI_STATICVAR             = -1531,          /*!< DNP3 Load config parameters Counter input static variation is invalid*/
            APP_ERRORVALUE_INVALID_FZCI_STATICVAR           = -1532,          /*!< DNP3 Load config parameters frozen counter input static variation is invalid*/
            APP_ERRORVALUE_INVALID_AI_STATICVAR             = -1533,          /*!< DNP3 Load config parameters Analog input static variation is invalid*/
            APP_ERRORVALUE_INVALID_FZAI_STATICVAR           = -1534,          /*!< DNP3 Load config parameters Frozen analog input static variation is invalid*/
            APP_ERRORVALUE_INVALID_AID_STATICVAR            = -1535,          /*!< DNP3 Load config parameters Analog input deadband static variation is invalid*/
            APP_ERRORVALUE_INVALID_AO_STATICVAR             = -1536,          /*!< DNP3 Load config parameters Analog output static variation is invalid*/
            APP_ERRORVALUE_INVALID_BI_EVENTVAR              = -1537,          /*!< DNP3 Load config parameters Binary input Event variation is invalid*/
            APP_ERRORVALUE_INVALID_DBI_EVENTVAR             = -1538,          /*!< DNP3 Load config parameters Double Binary input Event variation is invalid*/
            APP_ERRORVALUE_INVALID_CI_EVENTVAR              = -1539,          /*!< DNP3 Load config parameters counter input Event variation is invalid*/
            APP_ERRORVALUE_INVALID_AI_EVENTVAR              = -1540,          /*!< DNP3 Load config parameters Analog input Event variation is invalid*/
            APP_ERRORVALUE_INVALID_FZCI_EVENTVAR            = -1541,          /*!< DNP3 Load config parameters Frozen counter input Event variation is invalid*/
            APP_ERRORVALUE_INVALID_FZAI_EVENTVAR            = -1542,          /*!< DNP3 Load config parameters Frozen Analog input Event variation is invalid*/
            APP_ERRORVALUE_INVALID_COM_MODE                 = -1543,          /*!< DNP3 Load config parameters Communication mode is invalid*/
            APP_ERRORVALUE_INVALID_COMPORT_NUMBER           = -1544,          /*!< DNP3 Load config parameters Communication Serial com port number is greater than 9*/
            APP_ERRORVALUE_INVALID_BAUD_RATE                = -1545,          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid baud rate*/
            APP_ERRORVALUE_INVALID_PARITY                   = -1546,          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid parity*/
            APP_ERRORVALUE_INVALID_STOPBIT                  = -1547,          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid Stop bit*/
            APP_ERRORVALUE_INVALID_WORDLENGTH               = -1548,          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid word length*/
            APP_ERRORVALUE_INVALID_FLOWCONTROL              = -1549,          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid flow control */               
            APP_ERRORVALUE_INVALID_ETHERNETCOMMODE          = -1550,          /*!< DNP3 Load config parameters Communication ethernet now tcp only support, later we will support UDP*/
            APP_ERRORVALUE_INVALID_IPPORTNUMBER             = -1551,          /*!< DNP3 Load config parameters Communication TCP Invalid port Number*/
            APP_ERRORVALUE_INVALID_DEBUGOPTION              = -1552,          /*!< DNP3 Load config parameters Invalid Debug option*/
            APP_ERRORVALUE_INVALID_MASTER_ADDRESS           = -1553,          /*!< DNP3 Load config parameters Invalid master address*/
            APP_ERRORVALUE_INVALID_SLAVE_ADDRESS            = -1554,          /*!< DNP3 Load config parameters invalid slave address*/
            APP_ERRORVALUE_INVALID_SLAVEMASTER_ADDRESSSAME  = -1555,          /*!< DNP3 Load config parameters master & slave address must not be equal*/
            APP_ERRORVALUE_INVALID_LINKLAYER_TIMEOUT        = -1556,          /*!< DNP3 Load config parameters invalid link layer timeout*/
            APP_ERRORVALUE_INVLAID_EVENTBUFFER_SIZE         = -1557,          /*!< DNP3 Load config parameters invalid  Event buffer size < 10*/
            APP_ERRORVALUE_INVLAID_EVENTBUF_OVERFLOWPER     = -1558,          /*!< DNP3 Load config parameters invalid  Event buffer OVER FLOW percentage < 25|| >100*/
            APP_ERRORVALUE_INVALID_DATETIME_STRUCT          = -1559,          /*!< DNP3 invalid date time struct user input*/
            APP_ERRORVALUE_INVALID_NUMBEROFOBJECTS          = -1560,          /*!< DNP3 invalid no of objects user input*/
            APP_ERRORVALUE_INVALID_DNP3OBJECTS              = -1561,          /*!< DNP3 Load config parameters dnp3 objects , invalid u16NoofPoints must be 1-1000  & each group total no of objects 1 - 1000*/
            APP_ERRORVALUE_INVALID_MAXNOOFEVENTSUNSOL       = -1562,          /*!< Each Unsolicited message contains max no of events, minimum 1 */
            APP_ERRORVALUE_READCALLBACK_CLIENTONLY          = -1563,          /*!< Read Callback used only for client*/
            APP_ERRORVALUE_CANCELCALLBACK_CLIENTONLY        = -1564,          /*!< Cancel Callback used only for client*/
            APP_ERRORVALUE_INVALID_DATAPOINTER              = -1565,          /*!< Update function invalid void data pointer*/
            APP_ERRORVALUE_INVALID_POINTCOUNT               = -1566,          /*!< Total Number of Points exceeding Point Count*/
            APP_ERRORVALUE_INVALID_INDEX                    = -1567,          /*!< Invalid index number*/
            APP_ERRORVALUE_INVALID_APPSQUENCE               = -1568,          /*!< Invalid api function calling sequence*/
            APP_ERRORVALUE_INVALID_CONTROLMODEL             = -1569,          /*!< Invalid control mode */
            APP_ERRORVALUE_SERVER_NOTCONNECTED              = -1570,          /*!< Server device not connected- command sending failed */
            APP_ERRORVALUE_INVALID_OPTYPE                   = -1571,          /*!< Invalid operation mode */
            APP_ERRORVALUE_INVALID_DEADBANDCALCULATION_METHOD = -1572,        /*!< Invalid Deadband calculation method*/
            APP_ERRORVALUE_INVALID_CCOMMANDTIMEOUT          = -1573,          /*!< Invalid Command timeout minimum 3000ms*/
            APP_ERRORVALUE_COMMAND_TIMEOUT                  = -1574,          /*!< Command timeout  */
            APP_ERRORVALUE_FILE_INVALIDINPUTFILE            = -1575,          /*!< Invalid input file cannot fopen*/
            APP_ERRORVALUE_FILEREAD_PERMISSION_DENIED        = -1576,         /*!< Permission was denied due to improper authentication key, user name or password */        
            APP_ERRORVALUE_FILEREAD_INVALID_MODE             = -1577,         /*!< An unsupported or unknown operation mode was requested */
            APP_ERRORVALUE_FILEREAD_FILE_NOT_FOUND           = -1578,         /*!< The requested file does not exist */
            APP_ERRORVALUE_FILEREAD_FILE_LOCKED              = -1579,         /*!< The requested file is already in use by another user */
            APP_ERRORVALUE_FILEREAD_TOO_MANY_OPEN            = -1580,         /*!< File could not be opened because the number of simultaneously opened files would be exceeded */
            APP_ERRORVALUE_FILEREAD_INVALID_HANDLE           = -1581,         /*!< There is no file opened with the handle in the request */
            APP_ERRORVALUE_FILEREAD_WRITE_BLOCK_SIZE         = -1582,         /*!< The outstation is unable to negotiate a suitable write block size  */
            APP_ERRORVALUE_FILEREAD_COMM_LOST                = -1583,         /*!< Communications were lost or cannot be established with the end device where the file resides */
            APP_ERRORVALUE_FILEREAD_CANNOT_ABORT             = -1584,         /*!< An abort request was unsuccessful because the outstation is unable or not programmed to abort, or the outstation knows that aborting the file would make it unusable */
            APP_ERRORVALUE_FILEREAD_NOT_OPENED               = -1585,         /*!< File handle does not reference an opened file */
            APP_ERRORVALUE_FILE_INVALID_OUTPUTFILE           = -1586,         /*!< File Read, invalid destination file */
            APP_ERRORVALUE_CALLBACK_TIMEOUT                  = -1587,      		/*!< Request not accepted because timeout */
            APP_ERRORVALUE_CALLBACK_NO_SELECT                = -1588,      		/*!< Request not accepted because No Previous select */
            APP_ERRORVALUE_CALLBACK_FORMAT_ERROR             = -1589,      		/*!< Request not accepted because there were formatting errors in the control request (either select, operate, or direct operate) */
            APP_ERRORVALUE_CALLBACK_NOT_SUPPORTED            = -1590,      		/*!< Request not accepted because a control operation is not supported for this point */
            APP_ERRORVALUE_CALLBACK_ALREADY_ACTIVE           = -1591,      		/*!< Request not accepted, because the control queue is full or the point is already active */
            APP_ERRORVALUE_CALLBACK_HARDWARE_ERROR           = -1592,      		/*!< Request not accepted because of control hardware problems */
            APP_ERRORVALUE_CALLBACK_LOCAL                    = -1593,      		/*!< Request not accepted because Local/Remote switch is in Local position */
            APP_ERRORVALUE_CALLBACK_NOT_AUTHORIZED           = -1594,      		/*!< Request not accepted because of insufficient authorization */
            APP_ERRORVALUE_CALLBACK_AUTOMATION_INHIBIT       = -1595,      		/*!< Request not accepted because it was prevented or inhibited by a local automation process */
            APP_ERRORVALUE_CALLBACK_PROCESSING_LIMITED       = -1596,      		/*!< Request not accepted because the device cannot process any more activities than are presently in progress */
            APP_ERRORVALUE_CALLBACK_OUT_OF_RANGE             = -1597,      		/*!< Request not accepted because the value is outside the acceptable range permitted for this point */
            APP_ERRORVALUE_CALLBACK_NON_PARTICIPATING        = -1598,      		/*!< Sent in request messages indicating that the outstation shall not issue or perform the control operation */
            APP_ERRORVALUE_CALLBACK_UNDEFINED                = -1599,      		/*!< Request not accepted because of some other undefined reason */
            APP_ERRORVALUE_INVALID_DEADBAND                  = -1600,      		/*!< For AI, ONLY THE DEADBAND VALUE APPLICABLE,FOR OTHER Groupid must be zero */  
            APP_ERRORVALUE_INVALID_SBO_TIMEOUT               = -1601,      		/*!< For input group,sbo timeout must be zero, for direct operate it must be zero, if sbo controlmodel,minimum value 1000,max 20000 */
            APP_ERRORVALUE_INVALID_APPLAYER_TIMEOUT          = -1602,    		/*!< DNP3 Load config parameters invalid APP layer timeout 5000, 100000*/
            APP_ERRORVALUE_INVALID_TIMESYNC_TIMEOUT          = -1603,    		/*!< Time sync timeout */
            APP_ERRORVALUE_FILETRANSFER_DISABLED             = -1604,       	/*!< File transfer operation disabled  */
            APP_ERRORVALUE_INVALID_INTIAL_DATABASE_QUALITYFLAG 	= -1605,     	/*!< Invalid initialdatabase quality flag */
            APP_ERRORVALUE_TRIAL_EXPIRED                      	= -1606,     	/*!< Trial software expired contact support@freyrscada.com*/
            APP_ERRORVALUE_TRIAL_INVALID_POINTCOUNT           	= -1607,     	/*!< Trial software - Total Number of Points exceeded, maximum 100 points*/
			APP_ERRORVALUE_SERVER_DISABLED						= -1608,		/*!< Server functionality disabled in the api, please contact support@freyrscada.com */
			APP_ERRORVALUE_CLIENT_DISABLED						= -1609,		/*!< Client functionality disabled in the api, please contact support@freyrscada.com*/
            APP_ERRORVALUE_INVALID_BO_EVENTVAR              	= -1610,        /*!< DNP3 Load config parameters Binary Output Event variation is invalid*/
            APP_ERRORVALUE_INVALID_AO_EVENTVAR              	= -1611,        /*!< DNP3 Load config parameters Analog Output Event variation is invalid*/
            APP_ERRORVALUE_FILEREAD_HANDLE_EXPIRED          	= -1612,        /*!< File closed due to inactivity timeout */
            APP_ERRORVALUE_FILEREAD_BUFFER_OVERRUN          	= -1613,        /*!< Too much data was received in a write request */
            APP_ERRORVALUE_FILEREAD_FATAL						= -1614,        /*!< A fatal error has occurred*/
            APP_ERRORVALUE_FILEREAD_BLOCK_SEQ					= -1615,        /*!< The received data block does not have the expected sequence number*/       
			APP_ERRORVALUE_INVALID_CROB_TCC_VALUE				= -1616,        /*!< CROB Command data , tcc - 0-null, 1 close, 2 trip, only allowed, 3 reserved not allowed*/       
        	APP_ERRORVALUE_INVALID_COMMAND_VARIATION            = -1617,		/*!< CROB Command v1, analog output command data v1,2,3 supported */
			APP_ERRORVALUE_MORETHAN_100BLOCKS					= -1618,		/*!< Server add more than 100 blocks app multi frame transmission */
			
		};



        
        /*! List of Quality flags */
        enum eDNP3QualityFlags
        {       
            GOOD            = 0x0000,   /*!< OFFLINE */
            ONLINE          = 0x0001,   /*!< ONLINE - If clear, the point is inactive or disabled and unable to obtain field data*/
            RESTART         = 0x0002,   /*!< RESTART - indicates that the data has not been updated from the field since device reset*/
            COMM_LOST       = 0x0004,   /*!< COMM_LOST - indicates that there is a communication failure in the path between the device where the data originates and the reporting device.*/
            REMOTE_FORCED   = 0x0008,   /*!< REMOTE_FORCED - If set, the data value is overridden in a downstream reporting device*/
            LOCAL_FORCED    = 0x0010,   /*!< LOCAL_FORCED -If set, the data value is overridden by the device*/
            CHATTER_FILTER  = 0x0020,   /*!< CHATTER_FILTER - Only applicable to Binary Input and Double Input object groups - changing between states at a sufficiently high enough rate*/
            ROLLOVER        = 0x0040,   /*!< ROLLOVER - Only applicable to Counter Input object group - counter rollover occurs */ 
            OVER_RANGE      = 0x0080,   /*!< OVER_RANGE - Only applicable to Analog Input, Analog Output status  object groups - If set, the data object’s true value exceeds the valid measurement range of the object*/    
            DISCONTINUITY   = 0x0100,   /*!< DISCONTINUITY - Only applicable to Counter Input object groups - If set, the reported counter value cannot be compared against a prior value*/    
            REFERENCE_ERR   = 0x0200,   /*!< REFERENCE_ERR - Only applicable to Analog Input, Analog Output status object groups.If set, object’s data value might not have the expected level of accuracy */
        };

        /*! Group Identication List */
        enum eDNP3GroupID
        {
            BINARY_INPUT                    =   1,  /*!< Binary Input (DNP3Group 1) */
            DOUBLE_INPUT                    =   3,  /*!< Double-bit Binary Input (DNP3Group 3) */
            BINARY_OUTPUT                   =   10, /*!< Binary Output (DNP3Group 10) */
            COUNTER_INPUT                   =   20, /*!< Counter Input (DNP3Group 20) */
            FRCOUNTER_INPUT                 =   21, /*!< Frozen Counter Input (DNP3Group 21) */
            ANALOG_INPUT                    =   30, /*!< Analog Input (DNP3Group 30) */
            FRANALOG_INPUT                  =   31, /*!< Frozen Analog Input (DNP3Group 31) */
            ANALOG_OUTPUTS                  =   40, /*!< Analog output (DNP3Group 40) */
            DATE_TIME                       =   50, /*!< Date & time (DNP3Group 50) */
            OCTECT_STRING                   =   110, /*!< Octect String (DNP3Group 110) */
            VIRTUAL_TERMINAL_OUTPUT         =   112, /*!< virtual terminal String (DNP3Group 112) */
            
        };

        /*! Default Static Variation for BinaryInput */ 
        enum eDefaultStaticVariationBinaryInput
        {
            BI_PACKED_FORMAT              =   1,  /*!< Binary Input –  format */
            BI_WITH_FLAGS                 =   2,  /*!< Binary Input – With flags */
        };

        /*! Default Static Variation for DoubleBit Binary Input */
        enum eDefaultStaticVariationDoubleBitBinaryInput
        {
            DBBI_PACKED_FORMAT    =   1,  /*!< Double-bit Binary Input –  format */
            DBBI_WITH_FLAGS       =   2,  /*!< Double-bit Binary Input – With flags*/
        };

        /*!  Default Static Variation for Binary Output */
        enum eDefaultStaticVariationBinaryOutput
        {
            BO_PACKED_FORMAT             =   1,  /*!< Binary Output –  format*/
            BO_WITH_FLAGS                =   2,  /*!< Binary Output – Output status with flags*/
        };

        /*! Default Static Variation for Counter Input */
        enum eDefaultStaticVariationCounterInput
        {
            CI_32BIT_WITHFLAG                  =   1,  /*!< Counter – 32-bit with flag*/
            CI_16BIT_WITHFLAG                  =   2,  /*!< Counter – 16-bit with flag*/
            CI_32BIT_WITHOUTFLAG               =   5,  /*!< Counter – 32-bit without flag*/
            CI_16BIT_WITHOUTFLAG               =   6,  /*!< Counter – 16-bit without flag*/
        };

        /*! Default Static Variation for Frozen Counter Input */
        enum eDefaultStaticVariationFrozenCounterInput
        {
            FCI_32BIT_WITHFLAG            =   1,  /*!< Frozen Counter – 32-bit with flag*/
            FCI_16BIT_WITHFLAG            =   2,  /*!< Frozen Counter – 16 bit with flag*/
            FCI_32BIT_WITHFLAGANDTIME     =   5,  /*!< Frozen Counter – 32-bit with flag and time*/
            FCI_16BIT_WITHFLAGANDTIME     =   6,  /*!< Frozen Counter – 16-bit with flag and time*/
            FCI_32BIT_WITHOUTFLAG         =   9,  /*!< Frozen Counter – 32-bit without flag*/
            FCI_16BIT_WITHOUTFLAG         =   10, /*!< Frozen Counter – 16-bit without flag*/
        };

        /*! Default Static Variation for Analog Input */
        enum eDefaultStaticVariationAnalogInput 
        {
            AI_32BIT_WITHFLAG                  =   1,  /*!< Analog Input – 32-bit with flag*/
            AI_16BIT_WITHFLAG                  =   2,  /*!< Analog Input – 16-bit with flag*/
            AI_32BIT_WITHOUTFLAG               =   3,  /*!< Analog Input – 32-bit without flag*/
            AI_16BIT_WITHOUTFLAG               =   4,  /*!< Analog Input – 16-bit without flag*/
            AI_SINGLEPREC_FLOATWITHFLAG        =   5,  /*!< Analog Input – Single-prec flt-pt with flag*/
        };

        /*! Default Static Variation for Frozen Analog Input */
        enum eDefaultStaticVariationFrozenAnalogInput
        {
            FAI_32BITWITHFLAG            =   1,  /*!< Frozen Analog Input – 32-bit with flag */
            FAI_16BITWITHFLAG            =   2,  /*!< Frozen Analog Input – 16-bit with flag*/
            FAI_32BITWITHTIMEOFFREEZE    =   3,  /*!< Frozen Analog Input – 32-bit with time-of-freeze*/
            FAI_16BITWITHTIMEOFFREEZE    =   4,  /*!< Frozen Analog Input – 16-bit with time-of-freeze*/
            FAI_32BITWITHOUTFLAG         =   5,  /*!< Frozen Analog Input – 32-bit without flag*/
            FAI_16BITWITHOUTFLAG         =   6,  /*!< Frozen Analog Input – 16-bit without flag*/
            FAI_SINGLEPRECFLOATWITHFLAG  =   7,  /*!< Frozen Analog Input – Single-prec flt-pt with flag*/
        };

        /*! Default Static Variation for Analog Input DeadBand */
        enum eDefaultStaticVariationAnalogInputDeadBand 
        {
            DAI_16BIT                  =   1,  /*!< Analog Input Deadband – 16-bit */
            DAI_32BIT                  =   2,  /*!< Analog Input Deadband – 32-bit*/        
            DAI_SINGLEPRECFLOAT        =   3,  /*!< Analog Input Deadband – Single-prec flt-pt*/
        };

        /*! Default Static Variation for Analog Output */
        enum eDefaultStaticVariationAnalogOutput
        {
            AO_32BIT_WITHFLAG               =   1,  /*!< Analog Output Status – 32-bit with flag*/
            AO_16BIT_WITHFLAG               =   2,  /*!< Analog Output Status – 16-bit with flag*/
            AO_SINGLEPRECFLOAT_WITHFLAG     =   3,  /*!< Analog Output Status – Single-prec flt-pt with flag*/
        };

        /*! Default Event Variation for Binary Input */
        enum eDefaultEventVariationBinaryInput
        {
            BIE_WITHOUT_TIME                   =   1,  /*!< Binary Input Event – Without time */
            BIE_WITH_ABSOLUTETIME              =   2,  /*!< Binary Input Event – With absolute time*/
            BIE_WITH_RELATIVETIME              =   3,  /*!< Binary Input Event – With relative time*/
        };

        /*! Default Event Variation for Double Bit Binary Input */
        enum eDefaultEventVariationDoubleBitBinaryInput
        {
            DBBIE_WITHOUT_TIME          =   1,  /*!< Double-bit Binary Input Event – Without time*/
            DBBIE_WITH_ABSOLUTETIME     =   2,  /*!< Double-bit Binary Input Event – With absolute time*/
            DBBIE_WITH_RELATIVETIME     =   3,  /*!< Double-bit Binary Input Event – With relative time*/
        };

        /*! Default Event Variation for Counter Input */
        enum eDefaultEventVariationCounterInput
        {
             CIE_32BIT_WITHFLAG                    =   1,  /*!< Counter Event – 32-bit with flag */
             CIE_16BIT_WITHFLAG                    =   2,  /*!< Counter Event – 16-bit with flag */
             CIE_32BIT_WITHFLAG_WITHTIME           =   5,  /*!< Counter Event – 32-bit with flag and time */
             CIE_16BIT_WITHFLAG_WITHTIME           =   6,  /*!< Counter Event – 16-bit with flag and time */
        };

        /*! Default Event Variation for Frozen Counter Input */
        enum eDefaultEventVariationFrozenCounterInput 
        {
            FCIE_32BIT_WITHFLAG                    =   1, /*!< Frozen Counter Event – 32-bit with flag */
            FCIE_16BIT_WITHFLAG                    =   2, /*!< Frozen Counter Event – 16-bit with flag */
            FCIE_32BIT_WITHFLAG_WITHTIME           =   5, /*!< Frozen Counter Event – 32-bit with flag and time*/
            FCIE_16BIT_WITHFLAG_WITHTIME           =   6, /*!< Frozen Counter Event – 16-bit with flag and time*/
        };

        /*! Default Event Variation for Analog Input */
        enum eDefaultEventVariationAnalogInput
        {
            AIE_32BIT_WITHOUTTIME               =   1,  /*!< Analog Input Event – 32-bit without time */
            AIE_16BIT_WITHOUTTIME               =   2,  /*!< Analog Input Event –16-bit without time*/
            AIE_32BIT_WITHTIME                  =   3,  /*!< Analog Input Event – 32-bit with time*/
            AIE_16BIT_WITHTIME                  =   4,  /*!< Analog Input Event – 16-bit with time*/
            AIE_SINGLEPREC_WITHOUTTIME          =   5,  /*!< Analog Input Event – Single-prec flt-pt without time*/
            AIE_SINGLEPREC_WITHTIME             =   7,  /*!< Analog Input Event – Single-prec flt-pt with time*/
        };


		/*! Default Event Variation for Analog Output */
        enum eDefaultEventVariationAnalogOutput
        {
            AOE_32BIT_WITHOUTTIME               =   1,  /*!< Analog Output Event – 32-bit without time */
            AOE_16BIT_WITHOUTTIME               =   2,  /*!< Analog Output Event –16-bit without time*/
            AOE_32BIT_WITHTIME                  =   3,  /*!< Analog Output Event – 32-bit with time*/
            AOE_16BIT_WITHTIME                  =   4,  /*!< Analog Output Event – 16-bit with time*/
            AOE_SINGLEPREC_WITHOUTTIME          =   5,  /*!< Analog Output Event – Single-prec flt-pt without time*/
            AOE_SINGLEPREC_WITHTIME             =   7,  /*!< Analog Output Event – Single-prec flt-pt with time*/
        };

		

        /*! Default Event Variation for Frozen Analog Input */
        enum eDefaultEventVariationFrozenAnalogInput
        {
            FAIE_32BIT_WITHOUTTIME               =   1,    /*!< Frozen Analog Input Event – 32-bit without time */
            FAIE_16BIT_WITHOUTTIME               =   2,    /*!< Frozen Analog Input Event – 16-bit without time */
            FAIE_32BIT_WITHTIME                  =   3,    /*!< Frozen Analog Input Event – 32-bit with time */
            FAIE_16BIT_WITHTIME                  =   4,    /*!< Frozen Analog Input Event – 16-bit with time */
            FAIE_SINGLEPREC_WITHOUTTIME          =   5,    /*!< Frozen Analog Input Event – Single-prec flt-pt without time*/
            FAIE_SINGLEPREC_WITHTIME             =   7,    /*!< Frozen Analog Input Event – Single-prec flt-pt with time*/
        };

		/*! Default Event Variation for Binary Output */
        enum eDefaultEventVariationBinaryOutput
        {
            BOE_WITHOUT_TIME                   	=   1,  /*!< Binary Output Event – Without time */
            BOE_WITH_TIME              			=   2,  /*!< Binary Output Event – With time*/
        };

              

        /*! Class Identication List */
        enum eDNP3ClassID 
        {
            NO_CLASS                        =   0,  /*!< 0 – Static data (current value), no events will be generated for this data*/
            CLASS_ONE                       =   1,  /*!< 1 – Event classes, events will be generated for this data.*/
            CLASS_TWO                       =   2,  /*!< 2 – Event classes, events will be generated for this data.*/
            CLASS_THREE                     =   3,  /*!< 3 – Event classes, events will be generated for this data.*/
        };

         /*!   Flags for eDNP3ControlModelConfig*/
        enum eDNP3ControlModelConfig
        {
             INPUT_STATUS_ONLY                    = 0x00,       /*!< Control Model Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...*/
             DIRECT_OPERATION               = 0x01,       /*!< Direct Operate */
             SELECT_BEFORE_OPERATION        = 0x02,       /*!< Select Before Operate */ 
        };

        /*!   enum eClassSet list*/
        enum eClassSet
        {
            CLASS1_SETTINGS   =   0,            /*!< Class 1 settings */
            CLASS2_SETTINGS   =   1,            /*!< Class 2 settings */
            CLASS3_SETTINGS   =   2,            /*!< Class 3 settings */
        };     

         /*!   Flags for dnp3 write function */
        enum eWriteFunctionID
        {
            READCLASS0              =   1,      /*!< read class event buffer 0 */
            READCLASS1              =   2,      /*!< read class event buffer 1 */
            READCLASS2              =   3,      /*!< read class event buffer 2 */
            READCLASS3              =   4,      /*!< read class event buffer 3 */
            READCLASS123            =   5,      /*!< read class event buffer 1,2,3 */
            READCLASS0123           =   6,      /*!< read class event buffer 0,1,2,3 */
            TIMESYNC                =   7,      /*!< Send time sync command */
            CLEARRESTARTIIN         =   8,      /*!< send clear restart iin command */
            ENABLESPONT             =   9,      /*!< send Enable spontaneous event report - UnsolicitedResponse */      
            DISABLESPONT            =   10,     /*!< send Disable spontaneous event report - UnsolicitedResponse */     
            COLDRESTART             =   11,     /*!< send cold restart command to server */ 
            WARMRESTART             =   12,     /*!< send Warm restart command to server */
            DELAYMEASURE            =   13,     /*!< send delay measurement command to server */
            COUNTER_IMMEDIATE_FREEZE        =   14, /*!< send counter immediate freeze command to server */
            COUNTER_IMMEDIATE_FREEZE_NOACK  =   15, /*!< send counter immediate freeze - no ack command to server */
            COUNTER_FREEZE_AND_CLEAR        =   16, /*!< send counter immediate freeze  & clear  command to server */
            COUNTER_FREEZE_AND_CLEAR_NOACK  =   17, /*!< send counter immediate freeze  & clear - no ack command to server */
            AI_IMMEDIATE_FREEZE        =   18,      /*!< send analog input immediate freeze command to server */
            AI_IMMEDIATE_FREEZE_NOACK  =   19,      /*!< send analog input immediate freeze - no ack command to server */
            AI_FREEZE_AND_CLEAR        =   20,      /*!< send analog input immediate freeze  & clear  command to server */
            AI_FREEZE_AND_CLEAR_NOACK  =   21,      /*!< send analog input immediate freeze  & clear - no ack command to server */
            
        };

        /*!   Flags for analog input deadband calculation */
        enum   eAnalogInputDeadbandMethod
        {
            DEADBAND_NONE   =   0,      /*!< Analog Input , Deadband calculation method - none */               
            DEADBAND_FIXED  =   1,      /*!< Analog Input , Deadband calculation method - Fixed */
            DEADBAND_INTEGRATING =   2, /*!< Analog Input , Deadband calculation method - Integrtion */
        };


            /*! \typedef enum eIINFirstByteBitsFlag
    *   \brief iin1 p-22 Internal indications first octect
    */
    enum eIINFirstByteBitsFlag
    {
        BROADCAST           =   0x01, /*!<  A broadcast message was received */
        CLASS_1_EVENTS      =   0x02,/*!<  The outstation has unreported Class 1 events.  */
        CLASS_2_EVENTS      =   0x04, /*!< The outstation has unreported Class 2 events.   */
        CLASS_3_EVENTS      =   0x08, /*!< The outstation has unreported Class 3 events.   */
        NEED_TIME           =   0x10, /*!< Time synchronization is required.   */
        LOCAL_CONTROL       =   0x20, /*!< One or more of the outstation’s points are in local control mode.   */
        DEVICE_TROUBLE      =   0x40, /*!<  An abnormal, device-specific condition exists in the outstation.  */
        DEVICE_RESTART      =   0x80, /*!<  The outstation restarted.  */ 
    };



    /*! \typedef enum eIINSecondByteBitsFlag
    *   \brief iin1 p-22 Internal indications second octect
    */
    enum eIINSecondByteBitsFlag
    {
        NO_FUNC_CODE_SUPPORT        =   0x01, /*!<  The outstation does not support this function code.  */
        OBJECT_UNKNOWN              =   0x02, /*!<   Outstation does not support requested operation for objects in the request. */
        PARAMETER_ERROR             =   0x04, /*!<  A parameter error was detected.  */
        EVENT_BUFFER_OVERFLOW       =   0x08, /*!<   An event buffer overflow condition exists in the outstation, and at least one unconfirmed event was lost. */
        ALREADY_EXECUTING           =   0x10, /*!<  The operation requested is already executing. Support is optional.  */
        CONFIG_CORRUPT              =   0x20, /*!<  The outstation detected corrupt configuration. Support is optional.  */
        RESERVED_2                  =   0x40, /*!<  Reserved for future use.  */
        RESERVED_1                  =   0x80, /*!<  Reserved for future use.   */

    };

        /*! \brief      Parameters in Command callback   - operation type */
    enum eOperationType
    {
        NUL         =   0,      /*!< None operation */
        PULSE_ON    =   1,      /*!< Pulse on */
        PULSE_OFF   =   2,      /*!< Pulse off */
        LATCH_ON    =   3,      /*!< Latch mode on */
        LATCH_OFF   =   4,      /*!< latch mode off */
    };

		
	/*! \brief		TCC - field in CROB -Command Data */
	  enum eTripCloseCode
	  {
		  NULLL		  	=   0,	  /*!< NULL operation */
		  CLOSE	  		=   1,	  /*!< CLOSE - on */
		  TRIP  		=   2,	  /*!< trip - open */
		  RESERVED	  	=   3,	  /*!< reserved - not used */
		  
	  };

    /*! \brief      Server Connection status*/
    enum eServerConnectionStatus
    {
        SERVER_NOTCONNECTED   =   0,    /*!< server not connected */
        SERVER_CONNECTED       =   1,    /*!< server connected, link layer */
        SERVER_STOPPED_BY_USER       =   2,   // CLIENT multi server connect, user can stop communication for particular server, MULTDROP
    };

    /*! \brief      File type */
    enum eFileType 
    {
        DIRECTORY_TYPE   =   0, /*!< Directory */
        SIMPLE_FILE        =   1, /*!< simple file */
    };

	/*! \brief CROB, Analog Output Block - Command Variation -  Used in DNP3Select, DNP3Operate, DNP3SelectBeforeOperate, DNP3DirectOperate API function*/
    enum eCommandObjectVariation
    {
        CROB_G12V1                  	=   1,  /*!< Control relay output block - Group 12 - Variation 1  */
        ANALOG_OUTPUT_BLOCK_INTEGER32 	=   2,  /*!< 32-bit signed integer analog output Group 41 - Variation 1 */        
        ANALOG_OUTPUT_BLOCK_INTEGER16 	=   3,  /*!< 16-bit signed integer analog output Group 41 - Variation 2 */ 
        ANALOG_OUTPUT_BLOCK_FLOAT32		=   4,  /*!< Float analog output Group 41 - Variation 3 */ 
    };


	/*! DNP3 Update function - mention which event class need to generate event */
        enum eUpdateClassID 
        {
        	UPDATE_DEFAULT_EVENT					=	0,  /*!< 0- according to loadconfig, already defined class event group - event will be generated*/
            UPDATE_NO_CLASS                        	=   1,  /*!< 1 – Static data (current value), no events will be generated for this data*/
            UPDATE_CLASS_ONE                       	=   2,  /*!< 2 – Event classes, events will be generated for this data.*/
            UPDATE_CLASS_TWO                       	=   3,  /*!< 3 – Event classes, events will be generated for this data.*/
            UPDATE_CLASS_THREE                     	=   4,  /*!< 4 – Event classes, events will be generated for this data.*/
        };


	/*! DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input*/
        enum eAnalogStorageType 
        {
        	AS_FLOAT					=	0,  /*!< 0- default, it will store float value, as ieee 754 format */
            AS_INTEGER32                =   1,  /*!< 1 – integer32, it will store as i32 value - for Range : -2,147,483,648 to 2,147,483,647*/
        };

		/*! DNP3 Update function - mention which event class need to generate event */
		enum  eUpdateCause
		{
			STATIC_DATA 		= 0,   /*!< update callback caused by static data class 0 polled by client */
			POLLED_EVENT 		= 1,   /*!< update callback caused by event data class 123 polled by client */
			UNSOLICITED_EVENT 	= 2,   /*!< update callback caused by Unsolicited event data from Server */
		};

		/*! Data link layer confirmation  */
		enum eLinkLayerConform
		{
			CONFORM_NEVER = 0,	/*!< Default - most of dnp3 devices support datalink confirmation - never*/
			CONFORM_ALWAYS = 1, /*!< low end devices, and very nosiy environment - make more data transmission slow connection*/
		};



    /*! \brief  DNP3 Quality data type. (as specified in #eDNP3QualityFlags) */
    typedef Unsigned16 tDNP3Quality;

    /*!  \brief      Dataset present value element Structure */
     struct sDatasetpsvalueeelement
     {
        Unsigned8   u8Datasetvaluelength;  /*!<  data set value length*/ 
        Unsigned8   au8Datasetvalue[255];  /*!<  data set value*/ 
     };

    /*!  \brief      Dataset present  Structure */
     struct sDatasetPsvalue
    {
        Unsigned32  u32ID;                          /*!< dataset identification number */                   
        struct sTargetTimeStamp    sTimeStamp;         /*!< TimeStamp */        
        Unsigned16  u16Noofdatasetpseelement;       /*!< Total number of dataset element*/ 
        struct sDatasetpsvalueeelement *psDatasetpsvalueeelement; /*!<  Pointer to struct sDatasetpsvalueeelement */ 
    };


    /*!  \brief   Client Dataset present  Structure */
    struct sClientDatasetPresentvalue
    {
        Unsigned32  u32NoofDefinedDataSetDescriptor;   /*!< Total number of defined dataset descriptor */         
        struct sDatasetPsvalue *psDatasetPsvalue;    /*!<  Dataset present  Structure */  
    };

    /*!  \brief   Dataset prototype element  Structure */
    struct sDatasetprototypeelement
    {
        Unsigned8   u8Descriptorcode; /*!< Descriptor code */
        Unsigned8   u8Datatypecode;     /*!< Data type code */
        Unsigned8   u8Maxdatalength;        /*!< max data length */
        Unsigned8   u8Auxdatasetvaluelength;    /*!< auxilary dataset value length */
        Unsigned8   au8Auxdatasetvalue[255]; /*!< auxilary dataset value array */
    };

    /*!  \brief   Dataset prototype Structure */
    struct sDatasetPrototype 
    {
        Unsigned16  u16Noofdatasetprototypeelement; /*!< Number of dataset prototype element */
        struct sDatasetprototypeelement *psDatasetprototypeelement; /*!< dataset prototype element structure */
    };

    /*!  \brief   Client Dataset prototype Structure */
    struct sClientDatasetPrototype
    {
        Unsigned32  u32NoofDefinedDataSetPrototype; /*!< Number of defined dataset prototype  */           
        struct sDatasetPrototype *psDatasetPrototype; /*!< dataset prototype  structure */
    };



        /*!  \brief      Ethernet Port Settings Structure */
        struct sEthernetPortSettings 
        {
            Unsigned16              u16PortNumber;                         /*!< Port Number */ 
            Integer8                ai8FromIPAddress[MAX_IPV4_ADDRSIZE];   /*!< Local IP Address  only for dnp3 server udp*/
            Integer8                ai8ToIPAddress[MAX_IPV4_ADDRSIZE];     /*!< Connect To IP Address only for dnp3 client udp*/
            
        };

        /*! \brief      Ethernet Communication Settings Structure */
        struct sEthernetCommunicationSettings
        {
            Boolean     bServerUDPtransmitPortNumberdefault;             /*!< in udp , server transmit default port number 20000, or in which port data received , server will transmit same port*/   
            struct sEthernetPortSettings         sEthernetportSet;     /*!<  pointer to struct ethernet port setting */  
            
        };

      
        /*!  \brief      DNP3 Object Structure */
        struct sDNP3Object
        {
            enum eDNP3GroupID                   eGroupID;                   /*!< Group Identifcation see  */
            Unsigned16                          u16NoofPoints;              /*!< total number of points  , Intially index start with 0, if already some points included same group id , then index will increment min 1- 1000*/
            enum eDNP3ClassID                   eClassID;                   /*!< Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS*/
            enum eDNP3ControlModelConfig            eControlModel;              /*!< Control Model specified in eControlModelFlags ,Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...*/
            Unsigned32                          u32SBOTimeOut;              /*!< Select Before Operate Timeout  in milliseconds , for input points like BINARY_INPUT , must be 0, like for output points like binary output -> if control mode ->DIRECT_OPERATION  must be 0 else min 1000 - 20000*/
            Float32                             f32AnalogInputDeadband;     /*!< consider for analog input, other groups it must be zero, groupDeadband 0 permits any change in the analog input value to generate an event, and a deadband of the full range of the variable prevents generation of an event */
			enum eAnalogStorageType 			eAnalogStoreType;			/*! DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input*/
  			Integer8                            ai8Name[APP_OBJNAMESIZE];   /*!< Name */
            
        };

        /*! \brief  DNP3 Debug Parameters */
        struct sDNP3DebugParameters
        {
            Unsigned32                      u32DebugOptions;                            /*!< Debug Option see eDebugOptionsFlag */
        };

        /*!  \brief      static variation Structure  */
        struct sDefaultStaticVariation  
        {
            enum eDefaultStaticVariationBinaryInput                 eDeStVarBI;                             /*!< Default Static variation Binary Input*/
            enum eDefaultStaticVariationDoubleBitBinaryInput        eDeStVarDBI;                            /*!< Default Static variation Double Bit Binary Input*/
            enum eDefaultStaticVariationBinaryOutput                eDeStVarBO;                             /*!< Default Static variation Binary Output*/
            enum eDefaultStaticVariationCounterInput                eDeStVarCI;                             /*!< Default Static variation counter Input*/
            enum eDefaultStaticVariationFrozenCounterInput          eDeStVarFzCI;                           /*!< Default Static variation Frozen counter Input*/
            enum eDefaultStaticVariationAnalogInput                 eDeStVarAI;                             /*!< Default Static variation Analog Input*/
            enum eDefaultStaticVariationFrozenAnalogInput           eDeStVarFzAI;                           /*!< Default Static variation frozen Analog Input*/
            enum eDefaultStaticVariationAnalogInputDeadBand         eDeStVarAID;                            /*!< Default Static variation Analog Input Deadband*/
            enum eDefaultStaticVariationAnalogOutput                eDeStVarAO;                             /*!< Default Static variation Analog Output*/
            
        };

        /*!  \brief      event variation Structure */
        struct sDefaultEventVariation   
        {
            enum eDefaultEventVariationBinaryInput                  eDeEvVarBI;                             /*!< Default Event variation Binary Input*/
            enum eDefaultEventVariationDoubleBitBinaryInput         eDeEvVarDBI;                            /*!< Default Event variation Double bit Binary Input*/
            enum eDefaultEventVariationCounterInput                 eDeEvVarCI;                             /*!< Default Event variation Counter Input*/
            enum eDefaultEventVariationAnalogInput                  eDeEvVarAI;                             /*!< Default Event variation Analog Input*/
            enum eDefaultEventVariationFrozenCounterInput           eDeEvVarFzCI;                           /*!< Default Event variation Frozen Counter Input*/
            enum eDefaultEventVariationFrozenAnalogInput            eDeEvVarFzAI;  							/*!< Default Event variation Frozen Analog Input*/
			enum eDefaultEventVariationBinaryOutput                 eDeEvVarBO;   							/*!< Default Event variation Binary Output*/
			enum eDefaultEventVariationAnalogOutput                 eDeEvVarAO;								/*!< Default Event variation Analog Output*/
		};


 

        /*!  \brief Unsolicited Response Settings */
        struct sUnsolicitedResponseSettings
        {
            Boolean                                     bEnableUnsolicited;             /*!< enable to slave send unsolicited message*/
            Boolean                                     bEnableResponsesonStartup;      /*!< enable to slave send unsolicited message on statup*/
            Unsigned32                                  u32Timeout;                     /*!< timeout in milliseconds for unsolicites response from master minimum 1000 max app layer timeout*/
            Unsigned8                                   u8Retries;                      /*!< Unsolicited message retries default 5, min 1, max 10*/
            Unsigned16                                  u16MaxNumberofEvents;           /*!< each Unsolicited message contains max no of events minimum 1 -255*/
            Unsigned16									u16Class1TriggerNumberofEvents;		/*!< Class 1 Number of Class events to trigger the unsolicited response message , value should be < u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event */
			Unsigned16									u16Class1HoldTimeAfterResponse;		/*!< Class 1 after send the class unsoldiated message Hold Time in ms, */
			Unsigned16									u16Class2TriggerNumberofEvents; 	/*!< Class 2 Number of Class events to trigger the unsolicited response message , value should be < u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event */
			Unsigned16									u16Class2HoldTimeAfterResponse; 	/*!< Class 2 after send the class unsoldiated message Hold Time in ms, */
			Unsigned16									u16Class3TriggerNumberofEvents; 	/*!< Class 3 Number of Class events to trigger the unsolicited response message , value should be < u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event */
			Unsigned16									u16Class3HoldTimeAfterResponse; 	/*!< Class 3 after send the class unsoldiated message Hold Time in ms, */

		};

		/*!  \brief Server Device attribute paramaeters  */
        
		struct sDeviceAttributes
		{			
			
			Integer8				ai8HW_VERSION[32];	/*!< G00 v243 Device Attributes - Device Manufacturers HW Version - Min 3- 32 char */
			Integer8				ai8LOCATION[32];	/*!< G00 V245 Device Attributes - User-Assigned Location - Min 3- 32 char */
			Integer8				ai8ID_CODE[32]; 	/*!< G00 V246 Device Attributes - User-Assigned ID code/number- Min 3- 32 char */
			Integer8				ai8DEVICE_NAME[32]; /*!< G00 V247 Device Attributes - User-Assigned Device Name- Min 3- 32 char */
			Integer8				ai8SERIAL_NUMBER[32];	/*!< G00 V248 Device Attributes - Device Serial Number- Min 3- 32 char */
			Integer8				ai8PRODUCTNAME_MODEL[32];	/*!< G00 V250 Device Attributes - Device Product Name and Model */
			Integer8				ai8MANUFACTURE_NAME[32];/*!< G00 V252 Device Attributes - Device Manufacturers Name */		
			
		};



        /*!  \brief Server Communication Settings    */
        struct sServerCommunicationSettings 
        {
            enum  eCommunicationMode                    eCommMode;                                          /*!< Communication Mode serial /TCP_IP/UDP */
            struct sEthernetCommunicationSettings       sEthernetCommsSet;                                  /*!< Ethernet Communcation Settings */
            struct sSerialCommunicationSettings         sSerialSet;                                       /*!< pointer to struct sSerialCommunicationSettings  */
            
        };

        /*!  \brief sServer Protocol Settings    */
        struct sServerProtocolSettings 
        {
            Unsigned16                                  u16SlaveAddress;                                    /*!< Slave address range 0 to 65519 */
            Unsigned32                                  u32LinkLayerTimeout;                                /*!< Link layer time out in milliSeconds (minimum 1000ms - to max)*/
            Unsigned32                                  u32ApplicationLayerTimeout;                         /*!< application layer timeout in millisecond 5 * Linklayer timeout */                    
            Unsigned16                                  u16MasterAddress;                                   /*!< Master address range 0 to 65519 for unsolicited response*/
            struct sUnsolicitedResponseSettings         sUnsolicitedResponseSet;                            /*!< Unsolicited response settings */
            Unsigned32                                  u32TimeSyncIntervalSeconds;                         /*!< in Seconds, 0 to 3600s (1 hour) */            
            struct sDefaultStaticVariation              sStaticVariation;                                   /*!< default static variation structure */
            struct sDefaultEventVariation               sEventVariation;                                    /*!< default event variation structure */ 
            struct sTargetTimeStamp                        sTimeStamp;                                         /*!< TimeStamp @ load config*/
            Boolean                                     bAddBIinClass0;                                     /*!< add Binary Input in class 0 request*/
            Boolean                                     bAddDBIinClass0;                                    /*!< add Double Binary Input in class 0 request*/
            Boolean                                     bAddBOinClass0;                                     /*!< add Binary Output in class 0 request*/
            Boolean                                     bAddCIinClass0;                                     /*!< add Counter Input in class 0 request*/
            Boolean                                     bAddFzCIinClass0;                                   /*!< add Frozen Counter Input in class 0 request*/
            Boolean                                     bAddAIinClass0;                                     /*!< add Analog Input in class 0 request*/
            Boolean                                     bAddFzAIinClass0;                                   /*!< add Frozen Analog Input in class 0 request*/
            Boolean                                     bAddAIDinClass0;                                    /*!< add Analog Input Deadband in class 0 request*/
            Boolean                                     bAddAOinClass0;                                     /*!< add Analog Output in class 0 request*/
            Boolean                                     bAddOSinClass0;                                     /*!< add Octect String in class 0 request*/            
            Boolean                                     bAddBIEvent;                                        /*!< add Binary Input Event in class 1,2,3 request*/
            Boolean                                     bAddDBIEvent;                                       /*!< add Double Bit Binary Input Event in class 1,2,3 request*/
            Boolean                                     bAddBOEvent;                                        /*!< add Binary Output Event in class 1,2,3 request*/
            Boolean                                     bAddCIEvent;                                        /*!< add Counter Input Event in class 1,2,3 request*/
            Boolean                                     bAddFzCIEvent;                                      /*!< add Frozen Counter Input Event in class 1,2,3 request*/
            Boolean                                     bAddAIEvent;                                        /*!< add Analog Input Event in class 1,2,3 request*/
            Boolean                                     bAddFzAIEvent;                                      /*!< add Frozen Analog Input Event in class 1,2,3 request*/
            Boolean                                     bAddAIDEvent;                                       /*!< add Analog  Input Deadband Event in class 1,2,3 request*/
            Boolean                                     bAddAOEvent;                                        /*!< add Analog Output Event in class 1,2,3 request*/
            Boolean                                     bAddOSEvent;                                        /*!< add Octect String Event in class 1,2,3 request*/
            Boolean                                     bAddVTOEvent;                                       /*!< add Vitual termianal output Event in class 1,2,3 request*/
            enum   eAnalogInputDeadbandMethod           eAIDeadbandMethod;                                  /*!< Analog Input Deadband Calculation method*/
            Boolean                                     bFrozenAnalogInputSupport;                          /*!< False- stack will not create points for frozen analog input.*/            
            Boolean                                     bEnableSelfAddressSupport;          				/*!< Enable Self Address Support */
            Boolean                                     bEnableFileTransferSupport;         				/*!< Enable File Transfr Support*/
            Unsigned8                                   u8IntialdatabaseQualityFlag; 						/*!< 0- OFFLINE, 1 BIT- ONLINE, 2 BIT-RESTART, 3 BIT -COMMLOST, MAX VALUE -7   */
            Boolean                                     bLocalMode;  										/*!< if local mode set true, then -all remote command for binary output/ analog output   control statusset to not supported */
            Boolean                                     bUpdateCheckTimestamp; 								/*!< if it true ,the timestamp change also generate event  during the dnp3update */  
            Unsigned16                                  u16Class1EventBufferSize;                        /*!< Class 1 EventBufferSize - no of events to hold minimum 50*/
            Unsigned8                                   u8Class1EventBufferOverFlowPercentage;           /*!< Class 1 buffer overflow percentage 50 to 95*/
 			Unsigned16                                  u16Class2EventBufferSize;                        /*!< Class 2 EventBufferSize - no of events to hold minimum 50*/
            Unsigned8                                   u8Class2EventBufferOverFlowPercentage;           /*!< Class 2 buffer overflow percentage 50 to 95*/
 			Unsigned16                                  u16Class3EventBufferSize;                        /*!< Class 3 EventBufferSize - no of events to hold minimum 50*/
            Unsigned8                                   u8Class3EventBufferOverFlowPercentage;           /*!< Class 3 buffer overflow percentage 50 to 95*/
 			struct sDeviceAttributes					sConfigureDeviceAttributes;						/*!< configurable device attributes*/
              
        };

         /*!  \brief sServer Protocol Settings   */
        struct sDNP3ServerSettings 
        {
            struct sServerCommunicationSettings         sServerCommunicationSet;                            /*!< serial communication settings */
            struct sDNP3DebugParameters                 sDebug;                                             /*!< Debug options settings on loading the configuarion See struct sDNP3DebugParameters */
            struct sServerProtocolSettings              sServerProtSet;                                     /*!< Server protocol settings*/
            Unsigned16                                   u16NoofObject;                                       /*!< Total number of DNP3 Objects min 1, max 6000*/
            Boolean                                     benabaleUTCtime;                                    /*!< enable utc time/ local time*/ 
            struct sDNP3Object                          *psDNP3Objects;                                     /*!< Pointer to strcuture DNP3 Objects */
            
         };

        /*!  \brief Client Communication Settings   */
        struct sClientCommunicationSettings 
        {
            struct sSerialCommunicationSettings         sSerialSet;                                         /*!< Serial communication settings */
            struct sEthernetPortSettings                sEthernetCommsSet;                                  /*!< Ethernet Communcation Settings */
        };

        /*!  \brief Client Protocol Settings   */
        struct sClientProtocolSettings 
        {
			Unsigned16                                  u16MasterAddress;                                   /*!< Master address range 0 to 65519 for unsolicited response*/       
            Unsigned16                                  u16SlaveAddress;                                    /*!< Slave address range 0 to 65519 */
            Unsigned32                                  u32LinkLayerTimeout;                                /*!< Link layer time out in milliSeconds (minimum 1000ms - to max)*/
            Unsigned32                                  u32ApplicationTimeout;                              /*!< Application layer timeout in millisecond 5 * Linklayer timeout */      
            Unsigned32                                  u32Class123pollInterval;                            /*!<CLASS 123 poll interval in milliSeconds (minimum 1000ms - to max)*/
            Unsigned32                                  u32Class0123pollInterval;                           /*!<CLASS 0123 poll interval in milliSeconds (minimum 1000ms - to max)*/
            Unsigned32                                  u32Class0pollInterval;                              /*!<CLASS 0 poll interval in milliSeconds (minimum 1000ms - to max)*/
            Unsigned32                                  u32Class1pollInterval;                              /*!<CLASS 1 poll interval in milliSeconds (minimum 1000ms - to max)*/
            Unsigned32                                  u32Class2pollInterval;                              /*!<CLASS 2 poll interval in milliSeconds (minimum 1000ms - to max)*/
            Unsigned32                                  u32Class3pollInterval;                              /*!<CLASS 3 poll interval in milliSeconds (minimum 1000ms - to max)*/
            Boolean                                     bDisableUnsolicitedStatup;                          /*!<true- send disable unsolicited command at start up*/
            Boolean                                     bFrozenAnalogInputSupport;                          /*!<False- stack will not create points for frozen analog input.*/
            Boolean                                     bEnableFileTransferSupport;                         /*!<Enable file transfer*/
			Boolean                             		bDisableResetofRemotelink;                      	/*!< if it true ,client will not send the reset of remote link in startup*/
			enum eLinkLayerConform					    eLinkConform;										/*! Data link layer confirmation default - CONFORM_NEVER*/
			
		};

        /*! \brief      DNP3 Object Structure */
        struct sDNP3clObject
        {
            Unsigned16                          u16StartingIndexAddress;    /*!< Starting index number */
            Unsigned16                          u16NoofPoints;              /*!< total number of points , Intially index start with 0, if already some points included same group id , then index will increment*/            
            enum eDNP3GroupID                   eGroupID;                   /*!< Group Identifcation */
            enum eDNP3ClassID                   eClassID;                   /*!< Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS*/
            enum eDNP3ControlModelConfig        eControlModel;              /*!< Control Model specified in eControlModelFlags ,Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...*/
            Unsigned32                          u32SBOTimeOut;              /*!< Select Before Operate Timeout  in milliseconds , for input points like BINARY_INPUT , must be 0, like for output points like binary output -> if control mode ->DIRECT_OPERATION  must be 0*/
            Float32                             f32AnalogInputDeadband;     /*!< consider for analog input, other groups it must be zero, groupDeadband 0 permits any change in the analog input value to generate an event, and a deadband of the full range of the variable prevents generation of an event */
			enum eAnalogStorageType 			eAnalogStoreType;			/*! DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input*/
    		Integer8                            ai8Name[APP_OBJNAMESIZE];   /*!< Object Name */            
        };        
            

        /*! \brief      Client object structure  */
        struct sClientObject
        {
            enum  eCommunicationMode                    eCommMode;                                          /*!< Communication Mode serial /tcp */
            struct sClientCommunicationSettings         sClientCommunicationSet;                            /*!< Client communication settings */           
            struct sClientProtocolSettings              sClientProtSet;                                     /*!< Client protocol settings */        
            Unsigned32                                  u32CommandTimeout;                                  /*!< Command timout in milliseconds, minimum 3000 */
            Unsigned32                                  u32FileOperationTimeout;                            /*!< file read/write timout in milliseconds, minimum 10000 */
            Unsigned16                                   u16NoofObject;                                       /*!< Total number of DNP3 Objects 1- 6000*/
            struct sDNP3clObject                        *psDNP3Objects;                                     /*!< Pointer to strcuture DNP3 Objects */            
        };

        /*! \brief      Client settings  */
        struct  sDNP3ClientSettings
        {
        
            Boolean                             		bAutoGenDNP3DataObjects;                      		/*!< if it true ,the DNP3 Objects created automaticallay, use u16NoofObject = 0, psClientObjects = NULL*/
			Unsigned16 									u16UpdateBuffersize;								/*!< if bAutoGenDNP3DataObjects true, update callback buffersize, approx 3 * max count of monitoring points in the server */		
			struct sDNP3DebugParameters                 sDebug;                                             /*!< Debug options settings on loading the configuarion See struct sDNP3DebugParameters */          
            struct sTargetTimeStamp                        sTimeStamp;                                         /*!< TimeStamp @ load config*/
            Boolean                                     benabaleUTCtime;									/*!< enable utc time/ local time*/ 
            Boolean                                     bUpdateCallbackCheckTimestamp; 						/*!< if it true ,the timestamp change also create the updatecallback */
            Unsigned16                                   u16NoofClient;                                     /*!< Total number of client Objects */
            struct sClientObject                        *psClientObjects;                                   /*!< Pointer to strcuture sClientObject */            
        };
       
        
        /*! \brief    DNP3 Configuration parameters */
        struct sDNP3ConfigurationParameters
        {   
            struct sDNP3ServerSettings          sDNP3ServerSet;                         /*!< DNP3 Server settings*/
            struct sDNP3ClientSettings          sDNP3ClientSet;                         /*!< DNP3 Client settings*/
        };

        

         /*! \brief      This structure hold the identification of a DNP3 Data Attribute */
        struct sDNP3DataAttributeID
        {
            enum  eCommunicationMode        eCommMode;                           /*!< Communication Mode serial /tcp */
            Unsigned16                      u16SerialPortNumber;                 /*!< Serial COM port number*/
            Unsigned16                      u16PortNumber;                      /*!< tcp/udp port number */
            Unsigned16                      u16SlaveAddress;                    /*!< slave address range 0 to 65519 */
            enum eDNP3GroupID               eGroupID;                           /*!< Group Identifcation see  */
            Unsigned16                      u16IndexNumber;                     /*!< object index number */           
            void                            *pvUserData;                        /*!< Application specific User Data */
            Integer8                        ai8IPAddress[MAX_IPV4_ADDRSIZE];     /*!< Connect To IP Address only for dnp3 client udp*/            
         };

        /*! \brief      A Data object structure. Used to exchange data objects between DNP3 object and application. */
        struct sDNP3DataAttributeData
        {
            struct sTargetTimeStamp    sTimeStamp;         /*!< TimeStamp */
            tDNP3Quality            tQuality;           /*!< Quality of Data see eDNP3QualityFlags */
            enum    eDataTypes      eDataType;          /*!< Data Type */
            enum    eDataSizes      eDataSize;          /*!< Data Size */
            enum eTimeQualityFlags eTimeQuality; /*!< time quality */
            void                    *pvData;            /*!< Pointer to Data */ 
        };


        /*! \brief  DNP3 File Attribute Data Structure     */
        struct sDNP3FileAttributeData
        {
            //file related
            Integer8     ai8sourceFile[MAX_LICENSE_PATH];        /*!< source file name */   
            Integer8     ai8DestinationFile[MAX_LICENSE_PATH];        /*!< destination file*/                        
        };


        /*! \brief  DNP3 File Descriptor Structure     */
        struct sFileDescriptor
        {
            Unsigned16 u16FileNameOffset;               /*!< File Name offset */
            Unsigned16 u16Filenamesize;                 /*!< File Name Size */
            enum       eFileType    eFltype;            /*!< File type- directory/ file */
            Unsigned32  u32Filesize;                    /*!< file size */
            Unsigned16  u16Permissions;                 /*!< user permission read, write */
            Unsigned16  u16RequestID;                   /*!< request id */
            struct sTargetTimeStamp    sTimeStamp;         /*!< TimeStamp */
            Integer8  ai8Filename[MAX_LICENSE_PATH];    /*!< File Name */            
        };

        /*! \brief  DNP3 Directory attribute Structure     */
        struct sDNP3DirAttributeData
        {
            Unsigned16                        u16TotalNumberofFiles;                          	/*!< Number of files in the directory */                    
            struct sFileDescriptor              *psFileDescriptor;                          	/*!< File Descriptor Structure */
            Integer8                          ai8DestinationDirPath[MAX_LICENSE_PATH];        	/*!< directory Path */            
        };


         /*! \brief      Parameters provided by Command callback   */
        struct sDNP3CommandParameters
        {   
        	enum eCommandObjectVariation eCommandVariation; /*!< command variation*/
            enum eOperationType  eOPType;   /*!< operation type */
            Unsigned8   u8Count;            /*!< operation - number of types */
            Unsigned32  u32ONtime;          /*!< On Time in Milli Seconds */
            Unsigned32  u32OFFtime;         /*!< Off Time in Milli Seconds */
			Boolean     bCR;  				/*!< Clear field */
        };

		 

         /*! \brief      Parameters provided by write callback   */
        struct sDNP3WriteParameters
        {
            Unsigned8   u8Dummy;                /*!< Dummy only for future expansion purpose */
        };

          /*! \brief      Parameters provided by read callback   */
        struct sDNP3ReadParameters
        {
            Unsigned8   u8Dummy;                /*!< Dummy only for future expansion purpose */
        };

          
        /*! \brief      Parameters provided by update callback   */
        struct sDNP3UpdateParameters
        {
        	Unsigned8   u8Group;  				/*!< Reported group number from  dnp3 server */
			Unsigned8   u8Variation;			/*!< reported Variation number from  dnp3 server*/
			enum        eUpdateCause  eUpCause; /*!< reported cause - static / polled event / unsolicited event */           
        };
       
       
        /*! \brief  DNP3 Debug Callback Data Structure*/
        struct sDNP3DebugData
        {
            Unsigned32                      u32DebugOptions;                            /*!< Debug Option see eDebugOptionsFlag */
            Integer16             			i16ErrorCode;                               /*!< error code if any */
            tErrorValue                     tErrorValue;                                /*!< error value if any */
            enum  eCommunicationMode        eCommMode;                                  /*!< Communication Mode serial /tcp */
            Unsigned16                      u16ComportNumber;                           /*!< serial com port number for transmit & receive */
            Unsigned16                      u16RxCount;                                 /*!< Received data count*/
            Unsigned16                      u16TxCount;                                 /*!< Transmitted data count */
            Unsigned16                      u16PortNumber;                              /*!< Port Number */ 
            Unsigned8                       au8RxData[DNP3_MAX_RX_MESSAGE];             /*!< Received data from master */
            Unsigned8                       au8TxData[DNP3_MAX_TX_MESSAGE];             /*!< Transmitted data from master */
            Unsigned8                       au8ErrorMessage[MAX_ERROR_MESSAGE];         /*!< error message */
            Unsigned8                       au8WarningMessage[MAX_WARNING_MESSAGE];     /*!< warning message */
            Integer8                        ai8IPAddress[MAX_IPV4_ADDRSIZE];            /*!< tcp, udp ip address */
        };


        /*! \brief  DNP3 Server Database Point Structure*/
        struct sServerDatabasePoint
        {
            enum eDNP3GroupID       eGroupID;                   /*!< Group Identifcation see  */
            Unsigned16              u16IndexNumber;            /*!< Index number  */
            enum eDataTypes         eDataType;                  /*!< Data Type */
            enum eDataSizes         eDataSize;                  /*!< Data Size */
            tDNP3Quality            tQuality;                  /*!< Quality of Data see eDNP3QualityFlags */
            struct sTargetTimeStamp    sTimeStamp;                /*!< TimeStamp */
            void                    *pvData;                   /*!< Pointer to Data */          
        };

        /*! \brief  DNP3 Server Database Structure*/
        struct sDNPServerDatabase 
        {
            Unsigned32      u32TotalPoints;                      /*!< Total number of points  */
            struct sServerDatabasePoint *psServerDatabasePoint;  /*!< DNP3 Server Database Point Structure */
        };

        /*! \brief  DNP3 Client Database Point Structure*/
        struct sClientDatabasePoint
        {            
            enum  eCommunicationMode         eCommMode;                     /*!< Communication Mode serial /tcp */
            Unsigned16                       u16SerialPortNumber;           /*!< Serial COM port number*/
            Unsigned16              u16PortNumber;                          /*!< TCP, UDP port number*/
            Unsigned16              u16SlaveAddress;                        /*!< slave address range 0 to 65519 */           
            enum eDNP3GroupID       eGroupID;                               /*!< Group Identifcation see */
            enum eDataTypes         eDataType;                              /*!< Data Type */
            enum eDataSizes         eDataSize;                              /*!< Data Size */            
            Unsigned16              u16IndexNumber;                         /*!< Index number  */            
            enum eDNP3ClassID       eClassID;                               /*!<  Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS*/
            tDNP3Quality            tQuality;                               /*!< Quality of Data see eDNP3QualityFlags */
            struct sTargetTimeStamp    sTimeStamp;                             /*!< TimeStamp */
            void                    *pvData;                                /*!< Pointer to Data */
            Integer8                ai8IPAddress[MAX_IPV4_ADDRSIZE];        /*!< Connect To IP Address only for dnp3 client udp*/            
        };

        /*! \brief  DNP3 Client Database Structure*/
        struct sDNPClientDatabase 
        {
            Unsigned32      u32TotalPoints;                     /*!< Total number of points  */
            struct sClientDatabasePoint *psClientDatabasePoint; /*!< DNP3 Client Database Point Structure */
        };
        
        /*! \brief  DNP3 Device Attribute Data Structure*/
        struct sDNP3DeviceAttributeData
        {
                Unsigned8   u8Variation;        /*!< Variastion */
                Unsigned8   u8Datatype;         /*!< Datatype */
                Unsigned16  u16Length;          /*!< length of data*/
                Unsigned8   u8Data[512];        /*!< Data array*/
        };

        /*! \brief error code more description */
        struct sDNP3ErrorCode
        {
             Integer16 iErrorCode;      /*!< errorcode */   
             char* shortDes;        /*!< error code short description*/ 
             char* LongDes;     /*!< error code brief description*/
        };

    
        /*! \brief error value more description */
        struct sDNP3ErrorValue
        {
             Integer16 iErrorValue;     /*!< errorvalue */
             char* shortDes;        /*!< error value short description*/    
             char* LongDes;     /*!< error value brief description*/
        };
        

        struct sDNP3AppObject; // Forward Declaration of struct

        /*! \brief  Pointer to a DNP3 object */
        typedef struct sDNP3AppObject *DNP3Object;
        

        /*! \brief  Command Read CallBack */
        typedef Integer16 (*DNP3ReadCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptReadID, struct sDNP3DataAttributeData * ptReadValue, struct sDNP3ReadParameters *ptReadParams, tErrorValue *ptErrorValue );

        /*! \brief  Command Write CallBack */
        typedef Integer16 (*DNP3WriteCallback)(Unsigned16 u16ObjectId, enum eWriteFunctionID eFunctionID, struct sDNP3DataAttributeID * ptWriteID, struct sDNP3DataAttributeData * ptWriteValue,struct sDNP3WriteParameters *ptWriteParams, tErrorValue *ptErrorValue);

        /*! \brief  Command Update CallBack */
        typedef Integer16 (*DNP3UpdateCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, struct sDNP3DataAttributeData * ptUpdateValue,struct sDNP3UpdateParameters *ptUpdateParams, tErrorValue *ptErrorValue);

        /*! \brief  Command Update Internal Indication Bit 1 CallBack */
        typedef Integer16 (*DNP3UpdateIINCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, Unsigned8 u8IIN1, Unsigned8 u8IIN2, tErrorValue *ptErrorValue);

		/*! \brief  Client Poll Status for a particular CallBack */
        typedef Integer16 (*DNP3ClientPollStatusCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, enum eWriteFunctionID eFunctionID, tErrorValue *ptErrorValue);


		/*! \brief  Command Select CallBack */
        /*! \brief  Select command success return error code 0 - EC_NONE and *ptErrorValue = EV_NONE, 
            else return errorcode = APP_ERROR_SELECT_FAILED and for *ptErrorValue the following values accepted 
            
			APP_ERRORVALUE_CALLBACK_TIMEOUT                  = -1587,      		// Request not accepted because timeout 
            APP_ERRORVALUE_CALLBACK_NO_SELECT                = -1588,      		// Request not accepted because No Previous select 
            APP_ERRORVALUE_CALLBACK_FORMAT_ERROR             = -1589,      		// Request not accepted because there were formatting errors in the control request (either select, operate, or direct operate) 
            APP_ERRORVALUE_CALLBACK_NOT_SUPPORTED            = -1590,      		// Request not accepted because a control operation is not supported for this point 
            APP_ERRORVALUE_CALLBACK_ALREADY_ACTIVE           = -1591,      		// Request not accepted, because the control queue is full or the point is already active 
            APP_ERRORVALUE_CALLBACK_HARDWARE_ERROR           = -1592,      		// Request not accepted because of control hardware problems 
            APP_ERRORVALUE_CALLBACK_LOCAL                    = -1593,      		// Request not accepted because Local/Remote switch is in Local position
            APP_ERRORVALUE_CALLBACK_NOT_AUTHORIZED           = -1594,      		// Request not accepted because of insufficient authorization 
            APP_ERRORVALUE_CALLBACK_AUTOMATION_INHIBIT       = -1595,      		// Request not accepted because it was prevented or inhibited by a local automation process 
            APP_ERRORVALUE_CALLBACK_PROCESSING_LIMITED       = -1596,      		// Request not accepted because the device cannot process any more activities than are presently in progress 
            APP_ERRORVALUE_CALLBACK_OUT_OF_RANGE             = -1597,      		// Request not accepted because the value is outside the acceptable range permitted for this point 
            APP_ERRORVALUE_CALLBACK_NON_PARTICIPATING        = -1598,      		// Sent in request messages indicating that the outstation shall not issue or perform the control operation 
            APP_ERRORVALUE_CALLBACK_UNDEFINED                = -1599,      		// Request not accepted because of some other undefined reason 

    
        */
        typedef Integer16 (*DNP3ControlSelectCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psSelectID, struct sDNP3DataAttributeData * psSelectValue,struct sDNP3CommandParameters *psSelectParams, tErrorValue *ptErrorValue);

        /*! \brief  Command Operate CallBack */
        /*! \brief  Operate command success return error code 0 - EC_NONE and *ptErrorValue = EV_NONE, 
            else return errorcode = APP_ERROR_OPERATE_FAILED and for *ptErrorValue the following values accepted 
            
			APP_ERRORVALUE_CALLBACK_TIMEOUT                  = -1587,      		// Request not accepted because timeout 
            APP_ERRORVALUE_CALLBACK_NO_SELECT                = -1588,      		// Request not accepted because No Previous select 
            APP_ERRORVALUE_CALLBACK_FORMAT_ERROR             = -1589,      		// Request not accepted because there were formatting errors in the control request (either select, operate, or direct operate) 
            APP_ERRORVALUE_CALLBACK_NOT_SUPPORTED            = -1590,      		// Request not accepted because a control operation is not supported for this point 
            APP_ERRORVALUE_CALLBACK_ALREADY_ACTIVE           = -1591,      		// Request not accepted, because the control queue is full or the point is already active 
            APP_ERRORVALUE_CALLBACK_HARDWARE_ERROR           = -1592,      		// Request not accepted because of control hardware problems 
            APP_ERRORVALUE_CALLBACK_LOCAL                    = -1593,      		// Request not accepted because Local/Remote switch is in Local position
            APP_ERRORVALUE_CALLBACK_NOT_AUTHORIZED           = -1594,      		// Request not accepted because of insufficient authorization 
            APP_ERRORVALUE_CALLBACK_AUTOMATION_INHIBIT       = -1595,      		// Request not accepted because it was prevented or inhibited by a local automation process 
            APP_ERRORVALUE_CALLBACK_PROCESSING_LIMITED       = -1596,      		// Request not accepted because the device cannot process any more activities than are presently in progress 
            APP_ERRORVALUE_CALLBACK_OUT_OF_RANGE             = -1597,      		// Request not accepted because the value is outside the acceptable range permitted for this point 
            APP_ERRORVALUE_CALLBACK_NON_PARTICIPATING        = -1598,      		// Sent in request messages indicating that the outstation shall not issue or perform the control operation 
            APP_ERRORVALUE_CALLBACK_UNDEFINED                = -1599,      		// Request not accepted because of some other undefined reason 

    
        
    
        */
        typedef Integer16 (*DNP3ControlOperateCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psOperateID, struct sDNP3DataAttributeData * psOperateValue,struct sDNP3CommandParameters *psOperateParams, tErrorValue *ptErrorValue);

        /*! \brief  Debug Message CallBack */
        typedef Integer16 (*DNP3DebugMessageCallback)(Unsigned16 u16ObjectId, struct sDNP3DebugData * psDebugData, tErrorValue *ptErrorValue);

        /*! \brief  Client connection status CallBack */
        typedef Integer16 (*DNP3ClientStatusCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID, enum eServerConnectionStatus *peSat, tErrorValue *ptErrorValue);

        /*! \brief  Server cold restart CallBack */
        typedef Integer16 (*DNP3ColdRestartCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID,  tErrorValue *ptErrorValue);

        /*! \brief  Server warm restart CallBack */
        typedef Integer16 (*DNP3WarmRestartCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID,  tErrorValue *ptErrorValue);

        /*! \brief  device attribute CallBack */
        typedef Integer16 (*DNP3DeviceAttributeCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID, struct sDNP3DeviceAttributeData * psDeviceAttrValue,  tErrorValue *ptErrorValue); 
        
        

        /*! \brief      Create Server/client parameters structure  */
        struct sDNP3Parameters
        {
            enum eApplicationFlag             eAppFlag;                 /*!< Flag set to indicate the type of application */
            Unsigned32                        u32Options;               /*!< Options flag, used to set client/server global options see #eDNP3ApplicationOptionFlag for values */
            Unsigned16                        u16ObjectId;              /*!<  user idenfication will be retured in the callback for dnp3object identification*/
            DNP3ReadCallback                  ptReadCallback;           /*!< Read callback function. If equal to NULL then callback is not used. */
            DNP3WriteCallback                 ptWriteCallback;          /*!< Write callback function. If equal to NULL then callback is not used. */
            DNP3UpdateCallback                ptUpdateCallback;         /*!< Update callback function. If equal to NULL then callback is not used. */
            DNP3ControlSelectCallback         ptSelectCallback;         /*!< Function called when a Select Command  is executed.  If equal to NULL then callback is not used*/
            DNP3ControlOperateCallback        ptOperateCallback;        /*!< Function called when a Operate command is executed.  If equal to NULL then callback is not used */
            DNP3DebugMessageCallback          ptDebugCallback;          /*!< Function called when debug options are set. If equal to NULL then callback is not used */
            DNP3UpdateIINCallback             ptUpdateIINCallback;      /*!< Function called when IIN 1 byte changed. If equal to NULL then callback is not used */
			DNP3ClientPollStatusCallback	  ptClientPollStatusCallback;/*!< Function called when Client Compteated Poll operation for particular Server. If equal to NULL then callback is not used */
			DNP3ClientStatusCallback          ptClientStatusCallback;   /*!< Function called when client Connection status changed */
            DNP3ColdRestartCallback           ptColdRestartCallback;    /*!< Function called when a cold restart Command is executed.  If equal to NULL then callback is not used*/
            DNP3WarmRestartCallback           ptWarmRestartCallback;    /*!< Function called when a warm restart Command is executed.  If equal to NULL then callback is not used*/
            DNP3DeviceAttributeCallback       ptDeviceAttrCallback;     /*!< Device Attribute callback function. If equal to NULL then callback is not used. */
        };


    #ifdef __cplusplus
        }
    #endif

#endif
// End of File
