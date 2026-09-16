/*****************************************************************************/
/*! \file        dnp3types.cs
 *  \brief       DNP3 Protocol c# wrapper file
 *	\author 	 FreyrSCADA Embedded Solution Pvt Ltd
 *	\copyright (c) FreyrSCADA Embedded Solution Pvt Ltd. All rights reserved.
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
/*! \brief dnp3types c# class  */

public partial class dnp3types
{

		       

        /*! \brief  Max Size of Rx Message sent to callback */
        public const int DNP3_MAX_RX_MESSAGE         = 292;

        /*! \brief  Max Size of Tx Message sent to callback */
        public const int DNP3_MAX_TX_MESSAGE         = 292;
     
        

        /*! Flags for struct sDNP3Parameters.uiOptions flags */
        public enum eDNP3ApplicationOptionFlag
        {
            DNP3_APP_OPTION_NONE                                 = 0x00, /*!< No options set */
        }

        /*! Flags for Communication Mode serial / tcp   */
        public enum  eCommunicationMode
        {
            COMM_SERIAL             =   1,            /*!<  Serial communication */
            TCP_IP_MODE             =   2,            /*!<  TCP  communication */
            UDP_IP_MODE             =   3,            /*!<  UDP  communication*/
        }

        /*! List of error code returned by API functions */
        public class eAppErrorCodes
        {
            public const int APP_ERROR_ERRORVALUE_IS_NULL                = -1501;       /*!< APP Error value is  null*/
            public const int APP_ERROR_CREATE_FAILED                     = -1502;       /*!< DNP3 create function failed */
            public const int APP_ERROR_FREE_FAILED                       = -1503;       /*!< DNP3 free function failed */
            public const int APP_ERROR_INITIALIZE                        = -1504;       /*!< DNP3 server/client initialize function failed */
            public const int APP_ERROR_LOADCONFIG_FAILED                 = -1505;       /*!< DNP3 Load configuration function failed */
            public const int APP_ERROR_CHECKALLOCLOGICNODE               = -1506;       /*!< DNP3 Load- check alloc logical node function failed */
            public const int APP_ERROR_START_FAILED                      = -1507;       /*!< DNP3 Start function failed */
            public const int APP_ERROR_STOP_FAILED                       = -1508;       /*!< DNP3 Stop function failed */
            public const int APP_ERROR_SETDEBUGOPTIONS_FAILED            = -1509;       /*!< DNP3 set debug option failed */
            public const int APP_ERROR_PHYSICALLAYEROPEN_FAILED          = -1510;      /*!< DNP3 Physical Layer open operation failed  */
            public const int APP_ERROR_PHYSICALLAYERCLOSE_FAILED         = -1511;      /*!< DNP3 Physical Layer close operation failed */
            public const int APP_ERROR_SERIALCOMOPEN_FAILED              = -1512;      /*!< DNP3 Physical Layer com open failed    */
            public const int APP_ERROR_SERIALCOMCLOSE_FAILED             = -1513;      /*!< DNP3 Physical Layer com close failed   */
            public const int APP_ERROR_PHYSICALINITIALIZE_FAILED         = -1514;      /*!< DNP3 Physical Layer initialization failed  */
            public const int APP_ERROR_LINKLAYER_INITIALIZE              = -1515;      /*!< DNP3 Data Link Layer initialization failed */
            public const int APP_ERROR_LINKLAYER_DEINITIALIZE            = -1516;      /*!< DNP3 Data Link Layer deinitialization failed   */
            public const int APP_ERROR_LINKLAYER_INVALIDSTATE            = -1517;      /*!< DNP3 Data Link Layer Connection invalid state  */
            public const int APP_ERROR_TCPWAIT_FAILED                    = -1518;      /*!< DNP3 physical layer ethernet wait operation failed */
            public const int APP_ERROR_ETHERNET_INITIALIZATION_FAILED    = -1519;      /*!< DNP3 Data Link Layer ethernet initialization like bind ip & port number failed */
            public const int APP_ERROR_RECEIVE_FAILED                    = -1520;      /*!< DNP3 Data Link Layer serial receive failed */
            public const int APP_ERROR_DLDECODE_FAILED                   = -1521;      /*!< DNP3 Data Link Layer Decode operation failed */
            public const int APP_ERROR_TRANSLAYER_INITIALIZE             = -1522;      /*!< DNP3 Transport function Layer initialization failed*/
            public const int APP_ERROR_TRANSLAYER_FAILED                 = -1523;      /*!< DNP3 Transport function Layer operation failed*/
            public const int APP_ERROR_INVALIDDNP3_OBJECTPREFIXCODE      = -1524;      /*!< DNP3 Transport function Layer operation failed*/
            public const int APP_ERROR_DNP3RANGE_SPECIFIER_ERROR         = -1525;      /*!< DNP3 app Layer decode operation failed- invalid range specifier*/
            public const int APP_ERROR_DNP3APPL_ASDUPHARSE_FAILED        = -1526;      /*!< DNP3 app Layer decode operation failed- asdu pharse failed*/
            public const int APP_ERROR_APPLAYER_INITIALIZE_FAILED        = -1527;      /*!< DNP3 App Layer initialization failed*/
            public const int APP_ERROR_OBJECTDB_INITIALIZE_FAILED        = -1528;      /*!< DNP3 Object Database initialization failed*/
            public const int APP_ERROR_UPDATE_FAILED                     = -1529;      /*!< DNP3 Update function failed */
            public const int APP_ERROR_EVENTBUFFER_INITIALIZE_FAILED     = -1530;      /*!< DNP3 Event Buffer initialization failed*/
            public const int APP_ERROR_DNP3APPL_INVALID_OHDO             = -1531;      /*!< DNP3 app Layer decode operation failed- invalid object header & data object */
            public const int APP_ERROR_DNP3APPL_INVALID_VARIATION        = -1532;      /*!< DNP3 app Layer decode operation failed- invalid variationr*/
            public const int APP_ERROR_DNP3APPL_INVALID_QUALIFIER        = -1533;      /*!< DNP3 app Layer decode operation failed- invalid qualifierr*/
            public const int APP_ERROR_DNP3APPL_INVALID_INDEX            = -1534;      /*!< DNP3 app Layer decode operation failed- invalid qualifier*/
            public const int APP_ERROR_LOADCONFIG_INVALID_VAR            = -1535;      /*!< DNP3 Load configuration function, Static object variation is invalid  */
            public const int APP_ERROR_CREATESEMAPHORE_PHYSCIALLAYER     = -1536;      /*!< DNP3 physical layer semaphore creation is invalid  */
            public const int APP_ERROR_DELETESEMAPHORE_PHYSCIALLAYER     = -1537;      /*!< DNP3 physical layer semaphore deletion is invalid  */
            public const int APP_ERROR_RESERVESEMAPHORE_PHYSCIALLAYER    = -1538;      /*!< DNP3 physical layer semaphore reservation is invalid  */
            public const int APP_ERROR_CREATESEMAPHORE_TRANSPORTLAYER    = -1539;      /*!< DNP3 transport layer semaphore creation is invalid  */
            public const int APP_ERROR_DELETESEMAPHORE_TRANSPORTLAYER    = -1540;      /*!< DNP3 transport layer semaphore deletion is invalid  */
            public const int APP_ERROR_RESERVESEMAPHORE_TRANSPORTLAYER   = -1541;      /*!< DNP3 transport layer semaphore reservation is invalid  */            
            public const int APP_ERROR_TIMESTRUCT_INVALID                = -1542;      /*!< dnp3 time structure is invalid */
            public const int APP_ERROR_READ_FAILED                       = -1543;      /*!< DNP3 Read function failed */
            public const int APP_ERROR_WRITE_FAILED                      = -1544;      /*!< DNP3 Write function failed */
            public const int APP_ERROR_SELECT_FAILED                     = -1545;      /*!< DNP3 Select function failed */
            public const int APP_ERROR_OPERATE_FAILED                    = -1546;      /*!< DNP3 Operate function failed */
            public const int APP_ERROR_CANCEL_FAILED                     = -1547;      /*!< DNP3 Cancel function failed */
            public const int APP_ERROR_GETDATATYPEANDSIZE_FAILED         = -1548;      /*!< DNP3 Get Data type & size function failed */
            public const int APP_ERROR_INVALID_POINTCOUNT                = -1549;      /*!< Total Number of Points exceeding Point Count*/ 
		    public const int APP_ERROR_TCPCONNECT_FAILED                 = -1550;      /*!< DNP3 physical layer ethernet CONNECT operation failed */
		    public const int APP_ERROR_COMMAND_FAILED                    = -1551;      /*!< DNP3 Client command failed */
            public const int APP_ERROR_FILEREAD_FAILED                   = -1552;	 /*!< DNP3 Client  fileread command failed */
            public const int APP_ERROR_DATASET_READ_FAILED               = -1553;	 /*!< DNP3 Client dataset command failed */
            public const int APP_ERROR_CLIENTSTATUS_FAILED               = -1554;	 /*!< DNP3 Client status command failed */
            public const int APP_ERROR_FILEWRITE_FAILED                  = -1555;	/*!< DNP3 Client file write command failed */
            public const int APP_ERROR_READ_DEVICEATTRIBUTE_FAILED       = -1556;	/*!< DNP3 Client device attribute read command failed */
			public const int APP_ERROR_GETIIN1_FAILED                    = -1557;      /*!< DNP3 Get IIN 1 function failed */
			public const int APP_ERROR_GET_OBJECTSTATUS_FAILED           = -1558;	/*!< DNP3 get object status command failed */
            public const int APP_ERROR_CLIENT_STOPSERVERMULTIDROP        = -1559;		/*!< DNP3 Client Api function stop server multidrop failed */
            
            
		}

        /*! List of error value returned by API functions */
        public class eAppErrorValues
        {
            public const int APP_ERRORVALUE_ERRORCODE_IS_NULL                =   -1501;          /*!< APP Error code is Null */
            public const int APP_ERRORVALUE_INVALID_INPUTPARAMETERS          =   -1502;          /*!< Supplied Parameters are invalid */
            public const int APP_ERRORVALUE_INVALID_APPFLAG                  =   -1503;          /*!< Invalid Application Flag , Client not supported by the API*/
            public const int APP_ERRORVALUE_UPDATECALLBACK_CLIENTONLY        =   -1504;          /*!< Update Callback used only for client*/
            public const int APP_ERRORVALUE_NO_MEMORY                        =   -1505;          /*!< Allocation of memory has failed */
            public const int APP_ERRORVALUE_INVALID_DNP3OBJECT               =   -1506;          /*!< Supplied DNP3Object is invalid */
            public const int APP_ERRORVALUE_DNP3FREE_CALLED_BEFORE_STOP      =   -1507;          /*!< APP state is running free function called before stop function*/
            public const int APP_ERRORVALUE_INVALID_STATE                    =   -1508;          /*!< DNP3OBJECT invalid state */ 
            public const int APP_ERRORVALUE_INVALID_DEBUG_OPTION             =   -1509;          /*!< invalid debug option */ 
            public const int APP_ERRORVALUE_INVALID_COMMODE                  =   -1510;          /*!< Invalid communication mode serial, tcp only allowed */ 
            public const int APP_ERRORVALUE_TASK_CREATEFAILED                =   -1511;          /*!< Task creation failed */ 
            public const int APP_ERRORVALUE_TASK_STOPFAILED                  =   -1512;          /*!< Task stop failed */
            public const int APP_ERRORVALUE_DATALINKLAYER_INVALIDSTATE       =   -1513;          /*!< DNP3 Data Link Layer Connection invalid state  */  
            public const int APP_ERRORVALUE_DLRECEIVE_INVALIDSTARTCHAR       =   -1514;          /*!< DNP3 slave received invalid start char  */
            public const int APP_ERRORVALUE_DLRECEIVE_INVALIDCRC             =   -1515;          /*!< DNP3 data link layer invalid CRC Received */
            public const int APP_ERRORVALUE_DLRECEIVE_INVALIDSLAVEADDRESS    =   -1516;          /*!< DNP3 data link layer invalid slave address received*/
            public const int APP_ERRORVALUE_DLDECODE_INVALID_DIRBIT          =   -1517;          /*!< DNP3 data link layer invalid direction bit received*/
            public const int APP_ERRORVALUE_DLDECODE_INVALID_FUNCTIONCODE    =   -1518;          /*!< DNP3 data link layer invalid function code received*/
            public const int APP_ERRORVALUE_DLDECODE_INVALID_PRMBIT          =   -1519;          /*!< DNP3 data link layer invalid prm bit received*/
            public const int APP_ERRORVALUE_DLDECODE_INVALID_FCVBIT          =   -1520;          /*!< DNP3 data link layer invalid FCV Bit received*/
            public const int APP_ERRORVALUE_TRANSLAYER_INVALID_STATE         =   -1521;          /*!< DNP3 transport layer invalid state*/
            public const int APP_ERRORVALUE_TRANSLAYER_INVALID_FIRFIN        =   -1522;          /*!< DNP3 transport layer invalid fir fin */
            public const int APP_ERRORVALUE_INVALID_GROUPID                  =   -1523;          /*!< In the function eGroupID not valid, or later we will implement */
            public const int APP_ERRORVALUE_INVALIDUPDATE_COUNT              =   -1524;          /*!< Invalid update count */
            public const int APP_ERRORVALUE_UPDATEOBJECT_NOTFOUND            =   -1525;          /*!< For particular group id, index number not found */
            public const int APP_ERRORVALUE_INVALID_DATATYPE                 =   -1526;          /*!< For particular group id, sDNP3DataAttributeData invalid data type */
            public const int APP_ERRORVALUE_INVALID_DATASIZE                 =   -1527;          /*!< For particular group id, sDNP3DataAttributeData invalid data size */
            public const int APP_ERRORVALUE_INVALID_BI_STATICVAR             =   -1528;          /*!< DNP3 Load config parameters Binary input static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_DBI_STATICVAR            =   -1529;          /*!< DNP3 Load config parameters Double Binary input static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_BO_STATICVAR             =   -1530;          /*!< DNP3 Load config parameters Binary Output static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_CI_STATICVAR             =   -1531;          /*!< DNP3 Load config parameters Counter input static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_FZCI_STATICVAR           =   -1532;          /*!< DNP3 Load config parameters frozen counter input static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_AI_STATICVAR             =   -1533;          /*!< DNP3 Load config parameters Analog input static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_FZAI_STATICVAR           =   -1534;          /*!< DNP3 Load config parameters Frozen analog input static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_AID_STATICVAR            =   -1535;          /*!< DNP3 Load config parameters Analog input deadband static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_AO_STATICVAR             =   -1536;          /*!< DNP3 Load config parameters Analog output static variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_BI_EVENTVAR              =   -1537;          /*!< DNP3 Load config parameters Binary input Event variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_DBI_EVENTVAR             =   -1538;          /*!< DNP3 Load config parameters Double Binary input Event variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_CI_EVENTVAR              =   -1539;          /*!< DNP3 Load config parameters counter input Event variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_AI_EVENTVAR              =   -1540;          /*!< DNP3 Load config parameters Analog input Event variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_FZCI_EVENTVAR            =   -1541;          /*!< DNP3 Load config parameters Frozen counter input Event variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_FZAI_EVENTVAR            =   -1542;          /*!< DNP3 Load config parameters Frozen Analog input Event variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_COM_MODE                 =   -1543;          /*!< DNP3 Load config parameters Communication mode is invalid*/
            public const int APP_ERRORVALUE_INVALID_COMPORT_NUMBER           =   -1544;          /*!< DNP3 Load config parameters Communication Serial com port number is greater than 9*/
            public const int APP_ERRORVALUE_INVALID_BAUD_RATE                =   -1545;          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid baud rate*/
            public const int APP_ERRORVALUE_INVALID_PARITY                   =   -1546;          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid parity*/
            public const int APP_ERRORVALUE_INVALID_STOPBIT                  =   -1547;          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid Stop bit*/
            public const int APP_ERRORVALUE_INVALID_WORDLENGTH               =   -1548;          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid word length*/
            public const int APP_ERRORVALUE_INVALID_FLOWCONTROL              =   -1549;          /*!< DNP3 Load config parameters Communication SERIAL COM Invalid flow control */               
            public const int APP_ERRORVALUE_INVALID_ETHERNETCOMMODE          =   -1550;          /*!< DNP3 Load config parameters Communication ethernet now tcp only support, later we will support UDP*/
            public const int APP_ERRORVALUE_INVALID_IPPORTNUMBER             =   -1551;          /*!< DNP3 Load config parameters Communication TCP Invalid port Number*/
            public const int APP_ERRORVALUE_INVALID_DEBUGOPTION              =   -1552;          /*!< DNP3 Load config parameters Invalid Debug option*/
            public const int APP_ERRORVALUE_INVALID_MASTER_ADDRESS           =   -1553;          /*!< DNP3 Load config parameters Invalid master address*/
            public const int APP_ERRORVALUE_INVALID_SLAVE_ADDRESS            =   -1554;          /*!< DNP3 Load config parameters invalid slave address*/
            public const int APP_ERRORVALUE_INVALID_SLAVEMASTER_ADDRESSSAME  =   -1555;          /*!< DNP3 Load config parameters master & slave address must not be equal*/
            public const int APP_ERRORVALUE_INVALID_LINKLAYER_TIMEOUT        =   -1556;          /*!< DNP3 Load config parameters invalid link layer timeout*/
            public const int APP_ERRORVALUE_INVLAID_EVENTBUFFER_SIZE         =   -1557;          /*!< DNP3 Load config parameters invalid  Event buffer size < 10*/
            public const int APP_ERRORVALUE_INVLAID_EVENTBUF_OVERFLOWPER     =   -1558;          /*!< DNP3 Load config parameters invalid  Event buffer OVER FLOW percentage < 25|| >100*/
            public const int APP_ERRORVALUE_INVALID_DATETIME_STRUCT          =   -1559;          /*!< DNP3  invalid date time struct user input*/
            public const int APP_ERRORVALUE_INVALID_NUMBEROFOBJECTS          =   -1560;          /*!< DNP3  invalid no of objects user input*/
            public const int APP_ERRORVALUE_INVALID_DNP3OBJECTS              =   -1561;          /*!< DNP3 Load config parameters dnp3 objects , invalid u16NoofPoints must be 1-1000  & each group total no of objects 1 - 1000*/
            public const int APP_ERRORVALUE_INVALID_MAXNOOFEVENTSUNSOL       =   -1562;          /*!< each Unsolicited message contains max no of events, minimum 1 */
            public const int APP_ERRORVALUE_READCALLBACK_CLIENTONLY          =   -1563;          /*!< Read Callback used only for client*/
            public const int APP_ERRORVALUE_CANCELCALLBACK_CLIENTONLY        =   -1564;          /*!< Cancel Callback used only for client*/
			public const int APP_ERRORVALUE_INVALID_DATAPOINTER				 =	-1565;			 /*!< Update function invalid void data pointer*/
			public const int APP_ERRORVALUE_INVALID_POINTCOUNT               =   -1566;          /*!<  Total Number of Points exceeding Point Count*/
			public const int APP_ERRORVALUE_INVALID_INDEX					 =	-1567;           /*!<  Invalid index number*/
			public const int APP_ERRORVALUE_INVALID_APPSQUENCE				 =	-1568;           /*!<  Invalid api function calling sequence*/
			public const int APP_ERRORVALUE_INVALID_CONTROLMODEL             =   -1569;          /*!<  Invalid control mode */
			public const int APP_ERRORVALUE_SERVER_NOTCONNECTED              =   -1570;          /*!<  server device not connected- command sending failed */
			public const int APP_ERRORVALUE_INVALID_OPTYPE					 =	-1571;           /*!<  Invalid operation mode */
			public const int APP_ERRORVALUE_INVALID_DEADBANDCALCULATION_METHOD = -1572;          /*!<  Invalid Deadband calculation method*/
			public const int APP_ERRORVALUE_INVALID_CCOMMANDTIMEOUT          =   -1573;          /*!<  Invalid Command timeout minimum 3000ms*/
			public const int APP_ERRORVALUE_COMMAND_TIMEOUT                  =   -1574;			 /*!<  commad timeout  */
			public const int APP_ERRORVALUE_FILE_INVALIDINPUTFILE            =   -1575;			 /*!<  Invalid input file cannot fopen*/
			public const int APP_ERRORVALUE_FILEREAD_PERMISSION_DENIED        =   -1576;         /*!< Permission was denied due to improper authentication key, user name or password */        
			public const int APP_ERRORVALUE_FILEREAD_INVALID_MODE             =   -1577;         /*!< An unsupported or unknown operation mode was requested */
			public const int APP_ERRORVALUE_FILEREAD_FILE_NOT_FOUND           =   -1578;         /*!< The requested file does not exist */
			public const int APP_ERRORVALUE_FILEREAD_FILE_LOCKED              =   -1579;         /*!< The requested file is already in use by another user */
			public const int APP_ERRORVALUE_FILEREAD_TOO_MANY_OPEN            =   -1580;         /*!< File could not be opened because the number of simultaneously opened files would be exceeded */
			public const int APP_ERRORVALUE_FILEREAD_INVALID_HANDLE           =   -1581;         /*!< There is no file opened with the handle in the request */
			public const int APP_ERRORVALUE_FILEREAD_WRITE_BLOCK_SIZE         =   -1582;         /*!< The outstation is unable to negotiate a suitable write block size  */
			public const int APP_ERRORVALUE_FILEREAD_COMM_LOST                =   -1583;         /*!< Communications were lost or cannot be established with the end device where the file resides */
			public const int APP_ERRORVALUE_FILEREAD_CANNOT_ABORT             =   -1584;         /*!< An abort request was unsuccessful because the outstation is unable or not programmed to abort, or the outstation knows that aborting the file would make it unusable */
			public const int APP_ERRORVALUE_FILEREAD_NOT_OPENED               =   -1585;         /*!< File handle does not reference an opened file */
			public const int APP_ERRORVALUE_FILE_INVALID_OUTPUTFILE           =   -1586;         /*!< File Read, invalid destination file */
			public const int APP_ERRORVALUE_CALLBACK_TIMEOUT                  = -1587;      /*!< Request not accepted because timeout */
            public const int APP_ERRORVALUE_CALLBACK_NO_SELECT                = -1588;      /*!< Request not accepted because No Previous select */
            public const int APP_ERRORVALUE_CALLBACK_FORMAT_ERROR             = -1589;      /*!< Request not accepted because there were formatting errors in the control request (either select, operate, or direct operate) */
            public const int APP_ERRORVALUE_CALLBACK_NOT_SUPPORTED            = -1590;      /*!< Request not accepted because a control operation is not supported for this point */
            public const int APP_ERRORVALUE_CALLBACK_ALREADY_ACTIVE           = -1591;      /*!< Request not accepted, because the control queue is full or the point is already active */
            public const int APP_ERRORVALUE_CALLBACK_HARDWARE_ERROR           = -1592;      /*!< Request not accepted because of control hardware problems */
            public const int APP_ERRORVALUE_CALLBACK_LOCAL                    = -1593;      /*!< Request not accepted because Local/Remote switch is in Local position */
            public const int APP_ERRORVALUE_CALLBACK_NOT_AUTHORIZED           = -1594;      /*!< Request not accepted because of insufficient authorization */
            public const int APP_ERRORVALUE_CALLBACK_AUTOMATION_INHIBIT       = -1595;      /*!< Request not accepted because it was prevented or inhibited by a local automation process */
            public const int APP_ERRORVALUE_CALLBACK_PROCESSING_LIMITED       = -1596;      /*!< Request not accepted because the device cannot process any more activities than are presently in progress */
            public const int APP_ERRORVALUE_CALLBACK_OUT_OF_RANGE             = -1597;      /*!< Request not accepted because the value is outside the acceptable range permitted for this point */
            public const int APP_ERRORVALUE_CALLBACK_NON_PARTICIPATING        = -1598;      /*!< Sent in request messages indicating that the outstation shall not issue or perform the control operation */
            public const int APP_ERRORVALUE_CALLBACK_UNDEFINED                = -1599;      /*!< Request not accepted because of some other undefined reason */
            public const int APP_ERRORVALUE_INVALID_DEADBAND                  = -1600;      /*!< for AI, ONLY THE DEADBAND VALUE APPLICABLE,FOR OTHER Groupid must be zero */  
            public const int APP_ERRORVALUE_INVALID_SBO_TIMEOUT				 = -1601;      /*!< For input group,sbo timeout must be zero, for direct operate it must be zero, if sbo controlmodel,minimum value 1000,max 20000 */
            public const int APP_ERRORVALUE_INVALID_APPLAYER_TIMEOUT          =   -1602;    /*!< DNP3 Load config parameters invalid APP layer timeout 5000, 100000*/
            public const int APP_ERRORVALUE_INVALID_TIMESYNC_TIMEOUT          =   -1603;    /*!<  time sync timeout */
            public const int APP_ERRORVALUE_FILETRANSFER_DISABLED			 = -1604;		/*!<  file transfer operation disabled  */
            public const int APP_ERRORVALUE_INVALID_INTIAL_DATABASE_QUALITYFLAG = -1605;		/*!<  Invalid initialdatabase quality flag */
            public const int APP_ERRORVALUE_DEMO_EXPIRED						= -1606;     /*!< Demo software expired contact support@freyrscada.com*/
            public const int APP_ERRORVALUE_DEMO_INVALID_POINTCOUNT				= -1607;   /*!<Demo software - Total Number of Points exceeded, maximum 100 points*/
			public const int APP_ERRORVALUE_SERVER_DISABLED						= -1608;		/*!< Server functionality disabled in the api, please contact tech.support@freyrscada.com */
			public const int APP_ERRORVALUE_CLIENT_DISABLED						= -1609;		/*!< Client functionality disabled in the api, please contact tech.support@freyrscada.com*/
            public const int APP_ERRORVALUE_INVALID_BO_EVENTVAR              =   -1610;          /*!< DNP3 Load config parameters Binary Output Event variation is invalid*/
            public const int APP_ERRORVALUE_INVALID_AO_EVENTVAR              =   -1611;          /*!< DNP3 Load config parameters Analog Output Event variation is invalid*/
            public const int APP_ERRORVALUE_FILEREAD_HANDLE_EXPIRED          	= -1612;        /*!< File closed due to inactivity timeout */
            public const int APP_ERRORVALUE_FILEREAD_BUFFER_OVERRUN          	= -1613;        /*!< Too much data was received in a write request */
            public const int APP_ERRORVALUE_FILEREAD_FATAL						= -1614;        /*!< A fatal error has occurred*/
            public const int APP_ERRORVALUE_FILEREAD_BLOCK_SEQ					= -1615;        /*!< The received data block does not have the expected sequence number*/                
		    public const int APP_ERRORVALUE_INVALID_CROB_TCC_VALUE				= -1616;        /*!< CROB Command data , tcc - 0-null, 1 close, 2 trip, only allowed, 3 reserved not allowed*/
            public const int APP_ERRORVALUE_INVALID_COMMAND_VARIATION           = -1617;		/*!< CROB Command v1, analog output command data v1,2,3 supported */
		
        }



        
        /*! List of Quality flags */
        public enum eDNP3QualityFlags
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
        }

        /*! Group Identication List */
        public enum eDNP3GroupID
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
			OCTECT_STRING					=   110, /*!< Octect String (DNP3Group 110) */
            VIRTUAL_TERMINAL_OUTPUT			=   112, /*!< virtual terminal String (DNP3Group 112) */
			
        }

        /*! Default Static Variation for BinaryInput */ 
        public enum eDefaultStaticVariationBinaryInput
        {
            BI_PACKED_FORMAT              =   1,  /*!< Binary Input – Packed format */
            BI_WITH_FLAGS                 =   2,  /*!< Binary Input – With flags */
        }

        /*! Default Static Variation for DoubleBit Binary Input */
        public enum eDefaultStaticVariationDoubleBitBinaryInput
        {
            DBBI_PACKED_FORMAT    =   1,  /*!< Double-bit Binary Input – Packed format */
            DBBI_WITH_FLAGS       =   2,  /*!< Double-bit Binary Input – With flags*/
        }

        /*!  Default Static Variation for Binary Output */
        public enum eDefaultStaticVariationBinaryOutput
        {
            BO_PACKED_FORMAT             =   1,  /*!< Binary Output – Packed format*/
            BO_WITH_FLAGS                =   2,  /*!< Binary Output – Output status with flags*/
        }

        /*! Default Static Variation for Counter Input */
        public enum eDefaultStaticVariationCounterInput
        {
            CI_32BIT_WITHFLAG                  =   1,  /*!< Counter – 32-bit with flag*/
            CI_16BIT_WITHFLAG                  =   2,  /*!< Counter – 16-bit with flag*/
            CI_32BIT_WITHOUTFLAG               =   5,  /*!< Counter – 32-bit without flag*/
            CI_16BIT_WITHOUTFLAG               =   6,  /*!< Counter – 16-bit without flag*/
        }

        /*! Default Static Variation for Frozen Counter Input */
        public enum eDefaultStaticVariationFrozenCounterInput
        {
            FCI_32BIT_WITHFLAG            =   1,  /*!< Frozen Counter – 32-bit with flag*/
            FCI_16BIT_WITHFLAG            =   2,  /*!< Frozen Counter – 16 bit with flag*/
            FCI_32BIT_WITHFLAGANDTIME     =   5,  /*!< Frozen Counter – 32-bit with flag and time*/
            FCI_16BIT_WITHFLAGANDTIME     =   6,  /*!< Frozen Counter – 16-bit with flag and time*/
            FCI_32BIT_WITHOUTFLAG         =   9,  /*!< Frozen Counter – 32-bit without flag*/
            FCI_16BIT_WITHOUTFLAG         =   10, /*!< Frozen Counter – 16-bit without flag*/
        }

        /*! Default Static Variation for Analog Input */
        public enum eDefaultStaticVariationAnalogInput 
        {
            AI_32BIT_WITHFLAG                  =   1,  /*!< Analog Input – 32-bit with flag*/
            AI_16BIT_WITHFLAG                  =   2,  /*!< Analog Input – 16-bit with flag*/
            AI_32BIT_WITHOUTFLAG               =   3,  /*!< Analog Input – 32-bit without flag*/
            AI_16BIT_WITHOUTFLAG               =   4,  /*!< Analog Input – 16-bit without flag*/
            AI_SINGLEPREC_FLOATWITHFLAG        =   5,  /*!< Analog Input – Single-prec flt-pt with flag*/
        }

        /*! Default Static Variation for Frozen Analog Input */
        public enum eDefaultStaticVariationFrozenAnalogInput
        {
            FAI_32BITWITHFLAG            =   1,  /*!< Frozen Analog Input – 32-bit with flag */
            FAI_16BITWITHFLAG            =   2,  /*!< Frozen Analog Input – 16-bit with flag*/
            FAI_32BITWITHTIMEOFFREEZE    =   3,  /*!< Frozen Analog Input – 32-bit with time-of-freeze*/
            FAI_16BITWITHTIMEOFFREEZE    =   4,  /*!< Frozen Analog Input – 16-bit with time-of-freeze*/
            FAI_32BITWITHOUTFLAG         =   5,  /*!< Frozen Analog Input – 32-bit without flag*/
            FAI_16BITWITHOUTFLAG         =   6,  /*!< Frozen Analog Input – 16-bit without flag*/
            FAI_SINGLEPRECFLOATWITHFLAG  =   7,  /*!< Frozen Analog Input – Single-prec flt-pt with flag*/
        }

        /*! Default Static Variation for Analog Input DeadBand */
        public enum eDefaultStaticVariationAnalogInputDeadBand 
        {
            DAI_16BIT                  =   1,  /*!< Analog Input Deadband – 16-bit */
            DAI_32BIT                  =   2,  /*!< Analog Input Deadband – 32-bit*/        
            DAI_SINGLEPRECFLOAT        =   3,  /*!< Analog Input Deadband – Single-prec flt-pt*/
        }

        /*! Default Static Variation for Analog Output */
        public enum eDefaultStaticVariationAnalogOutput
        {
            AO_32BIT_WITHFLAG               =   1,  /*!< Analog Output Status – 32-bit with flag*/
            AO_16BIT_WITHFLAG               =   2,  /*!< Analog Output Status – 16-bit with flag*/
            AO_SINGLEPRECFLOAT_WITHFLAG     =   3,  /*!< Analog Output Status – Single-prec flt-pt with flag*/
        }

        /*! Default Event Variation for Binary Input */
        public enum eDefaultEventVariationBinaryInput
        {
            BIE_WITHOUT_TIME                   =   1,  /*!< Binary Input Event – Without time */
            BIE_WITH_ABSOLUTETIME              =   2,  /*!< Binary Input Event – With absolute time*/
            BIE_WITH_RELATIVETIME              =   3,  /*!< Binary Input Event – With relative time*/
        }

        /*! Default Event Variation for Double Bit Binary Input */
        public enum eDefaultEventVariationDoubleBitBinaryInput
        {
            DBBIE_WITHOUT_TIME          =   1,  /*!< Double-bit Binary Input Event – Without time*/
            DBBIE_WITH_ABSOLUTETIME     =   2,  /*!< Double-bit Binary Input Event – With absolute time*/
            DBBIE_WITH_RELATIVETIME     =   3,  /*!< Double-bit Binary Input Event – With relative time*/
        }

        /*! Default Event Variation for Counter Input */
        public enum eDefaultEventVariationCounterInput
        {
             CIE_32BIT_WITHFLAG                    =   1,  /*!< Counter Event – 32-bit with flag */
             CIE_16BIT_WITHFLAG                    =   2,  /*!< Counter Event – 16-bit with flag */
             CIE_32BIT_WITHFLAG_WITHTIME           =   5,  /*!< Counter Event – 32-bit with flag and time */
             CIE_16BIT_WITHFLAG_WITHTIME           =   6,  /*!< Counter Event – 16-bit with flag and time */
        }

        /*! Default Event Variation for Frozen Counter Input */
        public enum eDefaultEventVariationFrozenCounterInput 
        {
            FCIE_32BIT_WITHFLAG                    =   1, /*!< Frozen Counter Event – 32-bit with flag */
            FCIE_16BIT_WITHFLAG                    =   2, /*!< Frozen Counter Event – 16-bit with flag */
            FCIE_32BIT_WITHFLAG_WITHTIME           =   5, /*!< Frozen Counter Event – 32-bit with flag and time*/
            FCIE_16BIT_WITHFLAG_WITHTIME           =   6, /*!< Frozen Counter Event – 16-bit with flag and time*/
        }

        /*! Default Event Variation for Analog Input */
        public enum eDefaultEventVariationAnalogInput
        {
            AIE_32BIT_WITHOUTTIME               =   1,  /*!< Analog Input Event – 32-bit without time */
            AIE_16BIT_WITHOUTTIME               =   2,  /*!< Analog Input Event –16-bit without time*/
            AIE_32BIT_WITHTIME                  =   3,  /*!< Analog Input Event – 32-bit with time*/
            AIE_16BIT_WITHTIME                  =   4,  /*!< Analog Input Event – 16-bit with time*/
            AIE_SINGLEPREC_WITHOUTTIME          =   5,  /*!< Analog Input Event – Single-prec flt-pt without time*/
            AIE_SINGLEPREC_WITHTIME             =   7,  /*!< Analog Input Event – Single-prec flt-pt with time*/
        }
		
		/*! Default Event Variation for Analog Output */
        public  enum eDefaultEventVariationAnalogOutput
        {
            AOE_32BIT_WITHOUTTIME               =   1,  /*!< Analog Output Event – 32-bit without time */
            AOE_16BIT_WITHOUTTIME               =   2,  /*!< Analog Output Event –16-bit without time*/
            AOE_32BIT_WITHTIME                  =   3,  /*!< Analog Output Event – 32-bit with time*/
            AOE_16BIT_WITHTIME                  =   4,  /*!< Analog Output Event – 16-bit with time*/
            AOE_SINGLEPREC_WITHOUTTIME          =   5,  /*!< Analog Output Event – Single-prec flt-pt without time*/
            AOE_SINGLEPREC_WITHTIME             =   7,  /*!< Analog Output Event – Single-prec flt-pt with time*/
        }

        /*! Default Event Variation for Frozen Analog Input */
        public enum eDefaultEventVariationFrozenAnalogInput
        {
            FAIE_32BIT_WITHOUTTIME               =   1,    /*!< Frozen Analog Input Event – 32-bit without time */
            FAIE_16BIT_WITHOUTTIME               =   2,    /*!< Frozen Analog Input Event – 16-bit without time */
            FAIE_32BIT_WITHTIME                  =   3,    /*!< Frozen Analog Input Event – 32-bit with time */
            FAIE_16BIT_WITHTIME                  =   4,    /*!< Frozen Analog Input Event – 16-bit with time */
            FAIE_SINGLEPREC_WITHOUTTIME          =   5,    /*!< Frozen Analog Input Event – Single-prec flt-pt without time*/
            FAIE_SINGLEPREC_WITHTIME             =   7,    /*!< Frozen Analog Input Event – Single-prec flt-pt with time*/
        }

		/*! Default Event Variation for Binary Output */
        public enum eDefaultEventVariationBinaryOutput
        {
            BOE_WITHOUT_TIME                   	=   1,  /*!< Binary Output Event – Without time */
            BOE_WITH_TIME              			=   2,  /*!< Binary Output Event – With time*/
        }
              

        /*! Class Identication List */
        public enum eDNP3ClassID 
        {
            NO_CLASS                        =   0,  /*!< 0 – Static data (current value), no events will be generated for this data*/
            CLASS_ONE                       =   1,  /*!< 1 – Event classes, events will be generated for this data.*/
            CLASS_TWO                       =   2,  /*!< 2 – Event classes, events will be generated for this data.*/
            CLASS_THREE                     =   3,  /*!< 3 – Event classes, events will be generated for this data.*/
        }

         /*!   Flags for eDNP3ControlModelConfig*/
        public enum eDNP3ControlModelConfig
        {
             INPUT_STATUS_ONLY                    = 0x00,       /*!< Control Model Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...*/
             DIRECT_OPERATION               = 0x01,       /*!< Direct Operate */
             SELECT_BEFORE_OPERATION        = 0x02,       /*!< Select Before Operate */ 
        }


        /*!   enum eClassSet list*/
        public enum eClassSet
        {
            CLASS1_SETTINGS   =   0,            /*!< Class 1 settings */
            CLASS2_SETTINGS   =   1,            /*!< Class 2 settings */
            CLASS3_SETTINGS   =   2,            /*!< Class 3 settings */
        }     

         /*!   Flags for dnp3 write function */
        public enum eWriteFunctionID
        {
            READCLASS0				=	1,		/*!< read class event buffer 0 */
		    READCLASS1				=	2,		/*!< read class event buffer 1 */
		    READCLASS2				=	3,		/*!< read class event buffer 2 */
		    READCLASS3				=	4,		/*!< read class event buffer 3 */
		    READCLASS123			=	5,		/*!< read class event buffer 1,2,3 */
		    READCLASS0123			=	6,		/*!< read class event buffer 0,1,2,3 */
		    TIMESYNC                =   7,		/*!< Send time sync command */
		    CLEARRESTARTIIN         =   8,		/*!< send clear restart iin command */
		    ENABLESPONT             =   9,		/*!< send Enable spontaneous event report - UnsolicitedResponse */		
		    DISABLESPONT            =   10,		/*!< send Disable spontaneous event report - UnsolicitedResponse */		
		    COLDRESTART             =   11,		/*!< send cold restart command to server */	
		    WARMRESTART             =   12,		/*!< send Warm restart command to server */
		    DELAYMEASURE            =   13,		/*!< send delay measurement command to server */
		    COUNTER_IMMEDIATE_FREEZE        =   14,	/*!< send counter immediate freeze command to server */
		    COUNTER_IMMEDIATE_FREEZE_NOACK  =   15, /*!< send counter immediate freeze - no ack command to server */
		    COUNTER_FREEZE_AND_CLEAR        =   16, /*!< send counter immediate freeze  & clear  command to server */
		    COUNTER_FREEZE_AND_CLEAR_NOACK  =   17, /*!< send counter immediate freeze  & clear - no ack command to server */
		    AI_IMMEDIATE_FREEZE        =   18,		/*!< send analog input immediate freeze command to server */
		    AI_IMMEDIATE_FREEZE_NOACK  =   19,		/*!< send analog input immediate freeze - no ack command to server */
		    AI_FREEZE_AND_CLEAR        =   20,		/*!< send analog input immediate freeze  & clear  command to server */
		    AI_FREEZE_AND_CLEAR_NOACK  =   21,		/*!< send analog input immediate freeze  & clear - no ack command to server */
		    
        }

        /*!   Flags for analog input deadband calculation */
        public enum   eAnalogInputDeadbandMethod
        {
            DEADBAND_NONE   =   0,		/*!< Analog Input , Deadband calculation method - none */				
            DEADBAND_FIXED  =   1,		/*!< Analog Input , Deadband calculation method - Fixed */
            DEADBAND_INTEGRATING =   2, /*!< Analog Input , Deadband calculation method - Integrtion */
        }


            /*! \typedef enum eIINFirstByteBitsFlag
    *   \brief iin1 p-22 Internal indications first octect
    */
    public enum eIINFirstByteBitsFlag
    {
        BROADCAST           =   0x01, /*!<  A broadcast message was received */
        CLASS_1_EVENTS      =   0x02,/*!<  The outstation has unreported Class 1 events.  */
        CLASS_2_EVENTS      =   0x04, /*!< The outstation has unreported Class 2 events.   */
        CLASS_3_EVENTS      =   0x08, /*!< The outstation has unreported Class 3 events.   */
        NEED_TIME           =   0x10, /*!< Time synchronization is required.   */
        LOCAL_CONTROL       =   0x20, /*!< One or more of the outstation’s points are in local control mode.   */
        DEVICE_TROUBLE      =   0x40, /*!<  An abnormal, device-specific condition exists in the outstation.  */
        DEVICE_RESTART      =   0x80, /*!<  The outstation restarted.  */ 
    }



    /*! \typedef enum eIINSecondByteBitsFlag
    *   \brief iin1 p-22 Internal indications second octect
    */
    public enum eIINSecondByteBitsFlag
    {
        NO_FUNC_CODE_SUPPORT        =   0x01, /*!<  The outstation does not support this function code.  */
        OBJECT_UNKNOWN              =   0x02, /*!<   Outstation does not support requested operation for objects in the request. */
        PARAMETER_ERROR             =   0x04, /*!<  A parameter error was detected.  */
        EVENT_BUFFER_OVERFLOW       =   0x08, /*!<   An event buffer overflow condition exists in the outstation, and at least one unconfirmed event was lost. */
        ALREADY_EXECUTING           =   0x10, /*!<  The operation requested is already executing. Support is optional.  */
        CONFIG_CORRUPT              =   0x20, /*!<  The outstation detected corrupt configuration. Support is optional.  */
        RESERVED_2                  =   0x40, /*!<  Reserved for future use.  */
        RESERVED_1                  =   0x80, /*!<  Reserved for future use.   */

    }

        /*! \brief      Parameters in Command callback   - operation type */
    public enum eOperationType
    {
        NUL         =   0,      /*!< None operation */
        PULSE_ON    =   1,      /*!< Pulse on */
        PULSE_OFF   =   2,      /*!< Pulse off */
        LATCH_ON    =   3,      /*!< Latch mode on */
        LATCH_OFF   =   4,      /*!< latch mode off */
    }

    /*! \brief		TCC - field in CROB -Command Data */
    public enum eTripCloseCode
    {
        NULLL = 0,	  /*!< NULL operation */
        CLOSE = 1,	  /*!< CLOSE - on */
        TRIP = 2,	  /*!< trip - open */
        RESERVED = 3,	  /*!< reserved - not used */

    }


    /*! \brief      Server Connection status*/
    public enum eServerConnectionStatus
    {
        SERVER_NOTCONNECTED   =   0,    /*!< server not connected */
        SERVER_CONNECTED       =   1,    /*!< server connected, link layer */
        SERVER_STOPPED_BY_USER = 2,   // CLIENT multi server connect, user can stop communication for particular server, MULTDROP
    
    }

	/*! \brief      File type */
    public enum eFileType 
	{
		DIRECTORY_TYPE      =   0, /*!< Directory */
		SIMPLE_FILE         =   1, /*!< simple file */
	}


    /*! \brief CROB, Analog Output Block - Command Variation -  Used in DNP3Select, DNP3Operate, DNP3SelectBeforeOperate, DNP3DirectOperate API function*/
    public enum eCommandObjectVariation
    {
        CROB_G12V1 = 1,  /*!< Control relay output block - Group 12 - Variation 1  */
        ANALOG_OUTPUT_BLOCK_INTEGER32 = 2,  /*!< 32-bit signed integer analog output Group 41 - Variation 1 */
        ANALOG_OUTPUT_BLOCK_INTEGER16 = 3,  /*!< 16-bit signed integer analog output Group 41 - Variation 2 */
        ANALOG_OUTPUT_BLOCK_FLOAT32 = 4,  /*!< Float analog output Group 41 - Variation 3 */
    }


    /*! DNP3 Update function - mention which event class need to generate event */
    public enum eUpdateClassID
    {
        UPDATE_DEFAULT_EVENT = 0,  /*!< 0- according to loadconfig, already defined class event group - event will be generated*/
        UPDATE_NO_CLASS = 1,  /*!< 1 – Static data (current value), no events will be generated for this data*/
        UPDATE_CLASS_ONE = 2,  /*!< 2 – Event classes, events will be generated for this data.*/
        UPDATE_CLASS_TWO = 3,  /*!< 3 – Event classes, events will be generated for this data.*/
        UPDATE_CLASS_THREE = 4,  /*!< 4 – Event classes, events will be generated for this data.*/
    }

    /*! DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input*/
    public enum eAnalogStorageType
    {
        AS_FLOAT = 0,  /*!< 0- default, it will store float value, as ieee 754 format*/
        AS_INTEGER32 = 1,  /*!< 1 – integer32, it will store as i32 value - for Range : -2,147,483,648 to 2,147,483,647*/
    }

    /*! DNP3 Update function - mention which event class need to generate event */
    public enum eUpdateCause
    {
        STATIC_DATA = 0,   /*!< update callback caused by static data class 0 polled by client */
        POLLED_EVENT = 1,   /*!< update callback caused by event data class 123 polled by client */
        UNSOLICITED_EVENT = 2,   /*!< update callback caused by Unsolicited event data from Server */
    }

    /*! Data link layer confirmation  */
    public enum eLinkLayerConform
    {
        CONFORM_NEVER = 0,	/*!< Default - most of dnp3 devices support datalink confirmation - never*/
        CONFORM_ALWAYS = 1, /*!< low end devices, and very nosiy environment - make more data transmission slow connection*/
    }


	/*!  \brief      Dataset present value element Structure */
	 [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sDatasetpsvalueeelement
	 {
	    public byte   u8Datasetvaluelength;  /*!<  data set value length*/
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U1)]
        public byte[]   au8Datasetvalue;  /*!<  data set value*/ 
	 }

	/*!  \brief      Dataset present  Structure */
	 [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sDatasetPsvalue
	{
	    public uint  u32ID;							/*!< dataset identification number */ 					
	    public tgtcommon.sTargetTimeStamp    sTimeStamp;         /*!< TimeStamp */        
	    public ushort  u16Noofdatasetpseelement;		/*!< Total number of dataset element*/ 
	    public System.IntPtr psDatasetpsvalueeelement; /*!<  Pointer to struct sDatasetpsvalueeelement */ 
	}


	/*!  \brief   Client Dataset present  Structure */
	[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sClientDatasetPresentvalue
	{
	    public uint  u32NoofDefinedDataSetDescriptor;   /*!< Total number of defined dataset descriptor */         
	    public System.IntPtr psDatasetPsvalue;	 /*!<  Dataset present  Structure - pointer to struct sDatasetPsvalue*/  
	}

	/*!  \brief   Dataset prototype element  Structure */
	[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sDatasetprototypeelement
	{
	    public byte   u8Descriptorcode; /*!< Descriptor code */
	    public byte   u8Datatypecode;		/*!< Data type code */
	    public byte   u8Maxdatalength;		/*!< max data length */
		public byte   u8Auxdatasetvaluelength;	/*!< auxilary dataset value length */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U1)]
        public byte[]   au8Auxdatasetvalue; /*!< auxilary dataset value array */
	}

	/*!  \brief   Dataset prototype Structure */
	[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sDatasetPrototype 
	{
	    public ushort  u16Noofdatasetprototypeelement; /*!< Number of dataset prototype element */
	    public System.IntPtr psDatasetprototypeelement; /*!< dataset prototype element structure - pointer to struct sDatasetprototypeelement*/
	}

	/*!  \brief   Client Dataset prototype Structure */
	[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sClientDatasetPrototype
	{
	    public uint  u32NoofDefinedDataSetPrototype; /*!< Number of defined dataset prototype  */           
	    public System.IntPtr psDatasetPrototype; /*!< dataset prototype  structure - pointer to struct sDatasetPrototype*/
	}

      
        /*!  \brief      Ethernet Port Settings Structure */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sEthernetPortSettings 
		{
			public ushort              u16PortNumber;                         /*!< Port Number */
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
			public string				ai8FromIPAddress;   /*!< Local IP Address  only for dnp3 server udp*/
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
			public string                ai8ToIPAddress;     /*!< Connect To IP Address only for dnp3 client udp*/
            
		}

        /*! \brief      Ethernet Communication Settings Structure */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sEthernetCommunicationSettings
        {
            public byte     bServerUDPtransmitPortNumberdefault;             /*!< in udp , server transmit default port number 20000, or in which port data received , server will transmit same port*/   
           public sEthernetPortSettings         sEthernetportSet;     /*!<  pointer to struct ethernet port setting */  
             
            
        }

      
        /*!  \brief      DNP3 Object Structure */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3Object
        {
            public eDNP3GroupID                   eGroupID;                   /*!< Group Identifcation see  */
            public ushort                          u16NoofPoints;              /*!< total number of points  , Intially index start with 0, if already some points included same group id , then index will increment*/
            public eDNP3ClassID                   eClassID;                   /*!< Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS*/
            public eDNP3ControlModelConfig            eControlModel;              /*!< Control Model specified in eControlModelFlags ,Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...*/
            public uint                          u32SBOTimeOut;              /*!< Select Before Operate Timeout  in milliseconds , for input points like BINARY_INPUT , must be 0, like for output points like binary output -> if control mode ->DIRECT_OPERATION  must be 0*/
            public float                          f32AnalogInputDeadband;     /*!< consider for analog input, other groups it must be zero, groupDeadband 0 permits any change in the analog input value to generate an event, and a deadband of the full range of the variable prevents generation of an event */
            public eAnalogStorageType 			eAnalogStoreType;			/*! DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input*/
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtcommon.APP_OBJNAMESIZE)]
			public string                        ai8Name;   /*!< Name */
            
		}

        /*! \brief  DNP3 Debug Parameters */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3DebugParameters
        {
            public uint                      u32DebugOptions;                            /*!< Debug Option see eDebugOptionsFlag */
        }

        /*!  \brief      static variation Structure  */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDefaultStaticVariation  
        {
            public eDefaultStaticVariationBinaryInput                 eDeStVarBI;                             /*!< Default Static variation Binary Input*/
            public eDefaultStaticVariationDoubleBitBinaryInput        eDeStVarDBI;                            /*!< Default Static variation Double Bit Binary Input*/
            public eDefaultStaticVariationBinaryOutput                eDeStVarBO;                             /*!< Default Static variation Binary Output*/
            public eDefaultStaticVariationCounterInput                eDeStVarCI;                             /*!< Default Static variation counter Input*/
            public eDefaultStaticVariationFrozenCounterInput          eDeStVarFzCI;                           /*!< Default Static variation Frozen counter Input*/
            public eDefaultStaticVariationAnalogInput                 eDeStVarAI;                             /*!< Default Static variation Analog Input*/
            public eDefaultStaticVariationFrozenAnalogInput           eDeStVarFzAI;                           /*!< Default Static variation frozen Analog Input*/
            public eDefaultStaticVariationAnalogInputDeadBand         eDeStVarAID;                            /*!< Default Static variation Analog Input Deadband*/
            public eDefaultStaticVariationAnalogOutput                eDeStVarAO;                             /*!< Default Static variation Analog Output*/
            
        }

        /*!  \brief      event variation Structure */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDefaultEventVariation   
        {
            public eDefaultEventVariationBinaryInput                  eDeEvVarBI;                             /*!< Default Event variation Binary Input*/
            public eDefaultEventVariationDoubleBitBinaryInput         eDeEvVarDBI;                            /*!< Default Event variation Double bit Binary Input*/
            public eDefaultEventVariationCounterInput                 eDeEvVarCI;                             /*!< Default Event variation Counter Input*/
            public eDefaultEventVariationAnalogInput                  eDeEvVarAI;                             /*!< Default Event variation Analog Input*/
            public eDefaultEventVariationFrozenCounterInput           eDeEvVarFzCI;                           /*!< Default Event variation FrozenCounter Input*/
            public eDefaultEventVariationFrozenAnalogInput            eDeEvVarFzAI;                           /*!< Default Event variation Frozen Analog Input*/
			public eDefaultEventVariationBinaryOutput                 eDeEvVarBO;   							/*!< Default Event variation Binary Output*/
			public eDefaultEventVariationAnalogOutput                 eDeEvVarAO;								/*!< Default Event variation Analog Output*/
	
		}




        /*!  \brief Unsolicited Response Settings */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sUnsolicitedResponseSettings
        {
            public byte                                     bEnableUnsolicited;             /*!< enable to slave send unsolicited message*/
            public byte                                     bEnableResponsesonStartup;      /*!< enable to slave send unsolicited message on statup*/
            public uint                                  u32Timeout;                     /*!< timeout in milliseconds for unsolicites response from master minimum 1000 max app layer timeout*/
            public byte                                   u8Retries;                      /*!< Unsolicited message retries default 5, min 1, max 10*/
            public ushort                                  u16MaxNumberofEvents;           /*!< each Unsolicited message contains max no of events minimum 1 -255*/
            public ushort u16Class1TriggerNumberofEvents;		/*!< Class 1 Number of Class events to trigger the unsolicited response message , value should be < u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event */
            public ushort u16Class1HoldTimeAfterResponse;		/*!< Class 1 after send the class unsoldiated message Hold Time in ms, */
            public ushort u16Class2TriggerNumberofEvents; 	/*!< Class 1 Number of Class events to trigger the unsolicited response message , value should be < u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event */
            public ushort u16Class2HoldTimeAfterResponse; 	/*!< Class 1 after send the class unsoldiated message Hold Time in ms, */
            public ushort u16Class3TriggerNumberofEvents; 	/*!< Class 1 Number of Class events to trigger the unsolicited response message , value should be < u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event */
            public ushort u16Class3HoldTimeAfterResponse; 	/*!< Class 1 after send the class unsoldiated message Hold Time in ms, */
        }


        /*!  \brief Server Device attribute paramaeters  */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDeviceAttributes
		{			
			
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
			public string				ai8HW_VERSION;	/*!< G00 v243 Device Attributes - Device Manufacturers HW Version - Min 3- 32 char */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
			public string				ai8LOCATION;	/*!< G00 V245 Device Attributes - User-Assigned Location - Min 3- 32 char */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
			public string				ai8ID_CODE; 	/*!< G00 V246 Device Attributes - User-Assigned ID code/number- Min 3- 32 char */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
			public string				ai8DEVICE_NAME; /*!< G00 V247 Device Attributes - User-Assigned Device Name- Min 3- 32 char */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
			public string				ai8SERIAL_NUMBER;	/*!< G00 V248 Device Attributes - Device Serial Number- Min 3- 32 char */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
			public string				ai8PRODUCTNAME_MODEL;	/*!< G00 V250 Device Attributes - Device Product Name and Model */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
			public string				ai8MANUFACTURE_NAME;/*!< G00 V252 Device Attributes - Device Manufacturers Name */		
			
		}


        /*!  \brief Server Communication Settings	 */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sServerCommunicationSettings	
		{
			public eCommunicationMode                    eCommMode;                                          /*!< Communication Mode serial /TCP_IP/UDP */
			public sEthernetCommunicationSettings       sEthernetCommsSet;                                  /*!< Ethernet Communcation Settings */
            public tgtserialtypes.sSerialCommunicationSettings sSerialSet;                                      /*!< pointer to struct sSerialCommunicationSettings  */
            
		}

        /*!  \brief sServer Protocol Settings 	 */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sServerProtocolSettings 
		{
			public ushort                                  u16SlaveAddress;                                    /*!< Slave address range 0 to 65519 */
            public uint                                  u32LinkLayerTimeout;                                /*!< Link layer time out in milliSeconds (minimum 1000ms - to max)*/
            public uint                                  u32ApplicationLayerTimeout;                         /*!< application layer timeout in millisecond 5 * Linklayer timeout */                    
            public ushort                                  u16MasterAddress;                                   /*!< Master address range 0 to 65519 for unsolicited response*/
            public sUnsolicitedResponseSettings         sUnsolicitedResponseSet;                            /*!< Unsolicited response settings */
            public uint                                  u32TimeSyncIntervalSeconds;                         /*!< in Seconds, 0 to 3600s (1 hour) */            
            public sDefaultStaticVariation              sStaticVariation;                                   /*!< default static variation structure */
            public sDefaultEventVariation               sEventVariation;                                    /*!< default event variation structure */ 
            public tgtcommon.sTargetTimeStamp                        sTimeStamp;                                         /*!< TimeStamp @ load config*/
			public byte										bAddBIinClass0;										/*!< add Binary Input in class 0 request*/
            public byte										bAddDBIinClass0;									/*!< add Double Binary Input in class 0 request*/
			public byte										bAddBOinClass0;										/*!< add Binary Output in class 0 request*/
			public byte										bAddCIinClass0;										/*!< add Counter Input in class 0 request*/
			public byte										bAddFzCIinClass0;									/*!< add Frozen Counter Input in class 0 request*/
			public byte										bAddAIinClass0;										/*!< add Analog Input in class 0 request*/
			public byte										bAddFzAIinClass0;									/*!< add Frozen Analog Input in class 0 request*/
			public byte										bAddAIDinClass0;									/*!< add Analog Input Deadband in class 0 request*/
			public byte										bAddAOinClass0;										/*!< add Analog Output in class 0 request*/
            public byte                                     bAddOSinClass0;										/*!< add Octect String in class 0 request*/            
            public byte                                     bAddBIEvent;										/*!< add Binary Input Event in class 1,2,3 request*/
            public byte										bAddDBIEvent;										/*!< add Double Bit Binary Input Event in class 1,2,3 request*/
			public byte										bAddBOEvent;										/*!< add Binary Output Event in class 1,2,3 request*/
			public byte										bAddCIEvent;										/*!< add Counter Input Event in class 1,2,3 request*/
			public byte										bAddFzCIEvent;										/*!< add Frozen Counter Input Event in class 1,2,3 request*/
			public byte										bAddAIEvent;										/*!< add Analog Input Event in class 1,2,3 request*/
			public byte										bAddFzAIEvent;										/*!< add Frozen Analog Input Event in class 1,2,3 request*/
			public byte										bAddAIDEvent;										/*!< add Analog  Input Deadband Event in class 1,2,3 request*/
			public byte										bAddAOEvent;										/*!< add Analog Output Event in class 1,2,3 request*/
            public byte                                     bAddOSEvent;										/*!< add Octect String Event in class 1,2,3 request*/
			public byte                                     bAddVTOEvent;										/*!< add Vitual termianal output Event in class 1,2,3 request*/
            public eAnalogInputDeadbandMethod           eAIDeadbandMethod;                                  /*!< Analog Input Deadband Calculation method*/
            public byte                                     bFrozenAnalogInputSupport;                          /*!<False- stack will not create points for frozen analog input.*/            
			public byte										bEnableSelfAddressSupport;			/*!< Enable Self Address Support */
			public byte										bEnableFileTransferSupport;			/*!< Enable File Transfr Support*/
			public byte    								u8IntialdatabaseQualityFlag; /*!< 0- OFFLINE, 1 BIT- ONLINE, 2 BIT-RESTART, 3 BIT -COMMLOST, MAX VALUE -7   */
			public byte     								bLocalMode;  /*!< if local mode set true, then -all remote command for binary output/ analog output   control statusset to not supported */
			public byte      								bUpdateCheckTimestamp; /*!< if it true ,the timestamp change also generate event  during the dnp3update */
            public ushort u16Class1EventBufferSize;                        /*!< Class 1 EventBufferSize - no of events to hold minimum 50*/
            public byte u8Class1EventBufferOverFlowPercentage;           /*!< Class 1 buffer overflow percentage 50 to 95*/
            public ushort u16Class2EventBufferSize;                        /*!< Class 2 EventBufferSize - no of events to hold minimum 50*/
            public byte u8Class2EventBufferOverFlowPercentage;           /*!< Class 2 buffer overflow percentage 50 to 95*/
            public ushort u16Class3EventBufferSize;                        /*!< Class 3 EventBufferSize - no of events to hold minimum 50*/
            public byte u8Class3EventBufferOverFlowPercentage;           /*!< Class 3 buffer overflow percentage 50 to 95*/
            public sDeviceAttributes					sConfigureDeviceAttributes;						/*!< configurable device attributes*/
                          
		}

         /*!  \brief sServer Protocol Settings 	 */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3ServerSettings 
		{
			public sServerCommunicationSettings			sServerCommunicationSet;                            /*!< serial communication settings */
			public sDNP3DebugParameters                 sDebug;                                             /*!< Debug options settings on loading the configuarion See struct sDNP3DebugParameters */
			public sServerProtocolSettings              sServerProtSet;                                     /*!< Server protocol settings*/
			public ushort                                   u16NoofObject;                                       /*!< Total number of DNP3 Objects */
            public byte                 					benabaleUTCtime;									/*!< enable utc time/ local time*/ 
			public System.IntPtr                          psDNP3Objects;                                     /*!< Pointer to strcuture DNP3 Objects */
			
		 }

        /*!  \brief Client Communication Settings   */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sClientCommunicationSettings	
		{
			public tgtserialtypes.sSerialCommunicationSettings         sSerialSet;                                         /*!< Serial communication settings */
            public sEthernetPortSettings				sEthernetCommsSet;                                  /*!< Ethernet Communcation Settings */
		}

        /*!  \brief Client Protocol Settings   */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sClientProtocolSettings 
		{
            public ushort                                  u16MasterAddress;                                   /*!< Master address range 0 to 65519 for unsolicited response*/           	
			public ushort                                  u16SlaveAddress;                                    /*!< Slave address range 0 to 65519 */
            public uint                                  u32LinkLayerTimeout;                                /*!< Link layer time out in milliSeconds (minimum 1000ms - to max)*/
            public uint                                  u32ApplicationTimeout;                              /*!< Application layer timeout in millisecond 5 * Linklayer timeout */      
			public uint                                  u32Class123pollInterval;                            /*!<CLASS 123 poll interval in milliSeconds (minimum 1000ms - to max)*/
            public uint                                  u32Class0123pollInterval;                           /*!<CLASS 0123 poll interval in milliSeconds (minimum 1000ms - to max)*/
            public uint                                  u32Class0pollInterval;								/*!<CLASS 0 poll interval in milliSeconds (minimum 1000ms - to max)*/
            public uint                                  u32Class1pollInterval;								/*!<CLASS 1 poll interval in milliSeconds (minimum 1000ms - to max)*/
            public uint                                  u32Class2pollInterval;								/*!<CLASS 2 poll interval in milliSeconds (minimum 1000ms - to max)*/
            public uint                                  u32Class3pollInterval;								/*!<CLASS 3 poll interval in milliSeconds (minimum 1000ms - to max)*/
            public byte                                     bDisableUnsolicitedStatup;                          /*!<true- send disable unsolicited command at start up*/
            public byte                                     bFrozenAnalogInputSupport;                          /*!<False- stack will not create points for frozen analog input.*/
			public byte										bEnableFileTransferSupport;							/*!<Enable file transfer*/
            public byte                                     bDisableResetofRemotelink;                      	/*!< if it true ,client will not send the reset of remote link in startup*/
            public eLinkLayerConform					    eLinkConform;										/*! Data link layer confirmation default - CONFORM_NEVER*/
		
        }

        /*! \brief      DNP3 Object Structure */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3clObject
        {
            public ushort                          u16StartingIndexAddress;    /*!< Starting index number */
            public ushort                          u16NoofPoints;              /*!< total number of points , Intially index start with 0, if already some points included same group id , then index will increment*/            
            public eDNP3GroupID                   eGroupID;                   /*!< Group Identifcation */
            public eDNP3ClassID                   eClassID;                   /*!< Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS*/
            public eDNP3ControlModelConfig            eControlModel;              /*!< Control Model specified in eControlModelFlags ,Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...*/
            public uint                          u32SBOTimeOut;              /*!< Select Before Operate Timeout  in milliseconds , for input points like BINARY_INPUT , must be 0, like for output points like binary output -> if control mode ->DIRECT_OPERATION  must be 0*/
            public float                             f32AnalogInputDeadband;     /*!< consider for analog input, other groups it must be zero, groupDeadband 0 permits any change in the analog input value to generate an event, and a deadband of the full range of the variable prevents generation of an event */
            public eAnalogStorageType 			eAnalogStoreType;			/*! DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input*/
    		[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtcommon.APP_OBJNAMESIZE)]
			public string                             ai8Name;   /*!< Object Name */
            
		}        
			

		/*! \brief      Client object structure  */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sClientObject
        {
            public eCommunicationMode                    eCommMode;                                          /*!< Communication Mode serial /tcp */
            public sClientCommunicationSettings			sClientCommunicationSet;                            /*!< Client communication settings */			
			public sClientProtocolSettings              sClientProtSet;			                            /*!< Client protocol settings */		
			public uint                                  u32CommandTimeout;                                  /*!< Command timout in milliseconds, minimum 3000 */
            public uint                                  u32FileOperationTimeout;                            /*!< file read/write timout in milliseconds, minimum 10000 */
			public ushort                                  u16NoofObject;                                       /*!< Total number of DNP3 Objects */
            public System.IntPtr                        psDNP3Objects;                                     /*!< Pointer to strcuture DNP3 Objects - struct sDNP3clObject */
            
		}

        /*! \brief      Client settings  */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct  sDNP3ClientSettings
		{
			public byte                           		bAutoGenDNP3DataObjects;                      /*!< if it true ,the DNP3 Objects created automaticallay, use u16NoofObject = 0, psClientObjects = NULL*/
            public ushort                               u16UpdateBuffersize;								/*!< if bAutoGenDNP3DataObjects true, update callback buffersize, approx 3 * max count of monitoring points in the server */		
			public sDNP3DebugParameters                 sDebug;                                             /*!< Debug options settings on loading the configuarion See struct sDNP3DebugParameters */			
			public tgtcommon.sTargetTimeStamp                        sTimeStamp;                                         /*!< TimeStamp @ load config*/
			public byte                 					benabaleUTCtime;/*!< enable utc time/ local time*/ 
			public byte      								bUpdateCallbackCheckTimestamp; /*!< if it true ,the timestamp change also create the updatecallback */
			public ushort                                   u16NoofClient;                                       /*!< Total number of client Objects */
            public System.IntPtr                        psClientObjects;                                   /*!< Pointer to strcuture IEC 101 Objects - struct sClientObject*/
            
		}
       
        
        /*! \brief    DNP3 Configuration parameters */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3ConfigurationParameters
        {   
			public sDNP3ServerSettings          sDNP3ServerSet;                         /*!< DNP3 Server settings*/
            public sDNP3ClientSettings          sDNP3ClientSet;                         /*!< DNP3 Client settings*/
		}

        

         /*! \brief      This structure hold the identification of a DNP3 Data Attribute */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3DataAttributeID
        {
            public eCommunicationMode        eCommMode;                           /*!< Communication Mode serial /tcp */
            public ushort                      u16SerialPortNumber;                 /*!< Serial COM port number*/
            public ushort                      u16PortNumber; 						/*!< tcp/udp port number */
            public ushort                      u16SlaveAddress;                    /*!< slave address range 0 to 65519 */
            public eDNP3GroupID               eGroupID;                           /*!< Group Identifcation see  */
            public ushort                      u16IndexNumber;                     /*!< object index number */           
            public System.IntPtr		pvUserData;                        /*!< Application specific User Data */
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
			public string                        ai8IPAddress;     /*!< Connect To IP Address only for dnp3 client udp*/
            
		 }

        /*! \brief      A Data object structure. Used to exchange data objects between DNP3 object and application. */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3DataAttributeData
        {
            public tgtcommon.sTargetTimeStamp    sTimeStamp;         /*!< TimeStamp */
            public ushort            tQuality;           /*!< Quality of Data see eDNP3QualityFlags */
            public tgtcommon.eDataTypes      eDataType;          /*!< Data Type */
            public tgttypes.eDataSizes      eDataSize;          /*!< Data Size */
			public tgtcommon.eTimeQualityFlags eTimeQuality; /*!< time quality */
            public System.IntPtr		pvData;            /*!< Pointer to Data */ 
        }


        /*! \brief  DNP3 File Attribute Data Structure     */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3FileAttributeData
        {
            //file related
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_LICENSE_PATH)]
			public string                          ai8sourceFile;        /*!< source file name */
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_LICENSE_PATH)]
			public string                          ai8DestinationFile;        /*!< destination file*/	
                        
        }


		/*! \brief  DNP3 File Descriptor Structure     */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sFileDescriptor
        {
            public ushort u16FileNameOffset;   			/*!< File Name offset */
            public ushort u16Filenamesize; 				/*!< File Name Size */
            public eFileType    eFltype;			/*!< File type- directory/ file */
            public uint	u32Filesize;					/*!< file size */
            public ushort	u16Permissions;					/*!< user permission read, write */
            public ushort	u16RequestID;					/*!< request id */
            public tgtcommon.sTargetTimeStamp    sTimeStamp;         /*!< TimeStamp */
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_LICENSE_PATH)]
			public string  ai8Filename;	/*!< File Name */
            
		}

		/*! \brief  DNP3 Directory attribute Structure     */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3DirAttributeData
        {
        	public ushort                        u16TotalNumberofFiles;						  /*!< Number of files in the directory */					  
        	public System.IntPtr             psFileDescriptor;							/*!< File Descriptor Structure */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_LICENSE_PATH)]
			public string                         ai8DestinationDirPath;        /*!< directory Path */	
        	
        }


         /*! \brief      Parameters provided by Command callback   */
		 [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3CommandParameters
        {  
            public eCommandObjectVariation eCommandVariation; /*!< command variation*/
            public eOperationType  eOPType;   /*!< operation type */
            public byte   u8Count;            /*!< operation - number of types */
            public uint  u32ONtime;          /*!< On Time in Milli Seconds */
            public uint  u32OFFtime;         /*!< Off Time in Milli Seconds */
            public byte bCR;              /*!< Clear bit*/
        }

         /*! \brief      Parameters provided by write callback   */
		 [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3WriteParameters
        {
            public byte   u8Dummy;                /*!< Dummy only for future expansion purpose */
        }

          /*! \brief      Parameters provided by read callback   */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3ReadParameters
        {
            public byte   u8Dummy;                /*!< Dummy only for future expansion purpose */
        }

          
           /*! \brief      Parameters provided by update callback   */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3UpdateParameters
        {
            public byte    u8Group;  				/*!< Reported group number from  dnp3 server */
			public byte    u8Variation;			/*!< reported Variation number from  dnp3 server*/
			public  eUpdateCause  eUpCause; /*!< reported cause - static / polled event / unsolicited event */           
        }
       
       
        /*! \brief  DNP3 Debug Callback Data Structure*/
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3DebugData
        {
            public uint                      u32DebugOptions;                            /*!< Debug Option see eDebugOptionsFlag */
            public short             i16ErrorCode;                                 /*!< error code if any */
            public short						tErrorValue;                                /*!< error value if any */
            public eCommunicationMode        eCommMode;                                  /*!< Communication Mode serial /tcp */
            public ushort                       u16ComportNumber;                          /*!< serial com port number for transmit & receive */
            public ushort                      u16RxCount;                                 /*!< Received data count*/
            public ushort                      u16TxCount;                                 /*!< Transmitted data count */
			public ushort              		u16PortNumber;                         		/*!< Port Number */ 
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = DNP3_MAX_RX_MESSAGE)]
			public byte[]                      au8RxData;                  /*!< Received data from master */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = DNP3_MAX_TX_MESSAGE)]
			public byte[]                       au8TxData;                  /*!< Transmitted data from master */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_ERROR_MESSAGE)]
			public string                       au8ErrorMessage;         /*!< error message */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_WARNING_MESSAGE)]
			public string                       au8WarningMessage;     /*!< warning message */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
			public string                   ai8IPAddress;     		/*!< tcp, udp ip address */ 			
            

		}


		/*! \brief  DNP3 Server Database Point Structure*/
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sServerDatabasePoint
		{
			public eDNP3GroupID       eGroupID;                   /*!< Group Identifcation see  */
			public ushort              u16IndexNumber;            /*!< Index number  */
			public tgtcommon.eDataTypes         eDataType;                  /*!< Data Type */
			public tgttypes.eDataSizes         eDataSize;                  /*!< Data Size */
			public ushort            tQuality;                  /*!< Quality of Data see eDNP3QualityFlags */
			public tgtcommon.sTargetTimeStamp    sTimeStamp;                /*!< TimeStamp */
			public System.IntPtr                   pvData;                   /*!< Pointer to Data */
			
		}

		/*! \brief  DNP3 Server Database Structure*/
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNPServerDatabase 
		{
			public uint		u32TotalPoints;						 /*!< Total number of points  */
			public System.IntPtr psServerDatabasePoint;	 /*!< DNP3 Server Database Point Structure */
		}

		/*! \brief  DNP3 Client Database Point Structure*/
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sClientDatabasePoint
        {
            
            public eCommunicationMode         eCommMode;                   	/*!< Communication Mode serial /tcp */
            public ushort                       u16SerialPortNumber;     		/*!< Serial COM port number*/
            public ushort              u16PortNumber; 							/*!< TCP, UDP port number*/
			public ushort              u16SlaveAddress;                     	/*!< slave address range 0 to 65519 */           
            public eDNP3GroupID       eGroupID;                   			/*!< Group Identifcation see */
            public tgtcommon.eDataTypes         eDataType;                  			/*!< Data Type */
            public tgttypes.eDataSizes         eDataSize;                  			/*!< Data Size */            
            public ushort              u16IndexNumber;            				/*!< Index number  */            
            public eDNP3ClassID       eClassID;                  				/*!<  Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS*/
            public ushort            tQuality;                  				/*!< Quality of Data see eDNP3QualityFlags */
            public tgtcommon.sTargetTimeStamp    sTimeStamp;                				/*!< TimeStamp */
			public System.IntPtr   pvData;                   				/*!< Pointer to Data */
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
			public string                ai8IPAddress;     	/*!< Connect To IP Address only for dnp3 client udp*/
            
		}

		/*! \brief  DNP3 Client Database Structure*/
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNPClientDatabase 
		{
			public uint		u32TotalPoints;						/*!< Total number of points  */
			public System.IntPtr  psClientDatabasePoint;	/*!< DNP3 Client Database Point Structure accoring to u32TotalPoints*/
		}
		
		/*! \brief  DNP3 Device Attribute Data Structure*/
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3DeviceAttributeData
        {
                public byte   u8Variation;		/*!< Variastion */
                public byte   u8Datatype;			/*!< Datatype */
                public ushort  u16Length;			/*!< length of data*/
				[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 512, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U2)]
                public byte[]   u8Data;		/*!< Data array*/
        }

		/*! \brief error code more description */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct sDNP3ErrorCode
		{
			 public short iErrorCode;		/*!< errorcode */
             public System.IntPtr shortDes;		/*!< string - error code short description*/
             public System.IntPtr LongDes; 	/*!< string - error code brief description*/

		}

	
		/*! \brief error value more description */
		[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    	public struct sDNP3ErrorValue
		{
			 public short iErrorValue;		/*!< errorvalue */
			 public System.IntPtr shortDes;		/*!< string - error value short description*/
			 public System.IntPtr LongDes;		/*!< string - error value brief description*/
		}


	
	/*! \brief	Command Read CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3ReadCallback(ushort u16ObjectId, ref sDNP3DataAttributeID ptReadID, ref sDNP3DataAttributeData ptReadValue, ref sDNP3ReadParameters ptReadParams, ref short ptErrorValue);
	
	/*! \brief	Command Write CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3WriteCallback(ushort u16ObjectId,  eWriteFunctionID eFunctionID, ref sDNP3DataAttributeID ptWriteID, ref sDNP3DataAttributeData ptWriteValue, ref sDNP3WriteParameters ptWriteParams, ref short ptErrorValue);
	
	/*! \brief	Command Update CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3UpdateCallback(ushort u16ObjectId, ref sDNP3DataAttributeID ptUpdateID, ref sDNP3DataAttributeData ptUpdateValue, ref sDNP3UpdateParameters ptUpdateParams, ref short ptErrorValue);
	
	/*! \brief	Command Update Internal Indication Bit 1 CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3UpdateIINCallback(ushort u16ObjectId, ref sDNP3DataAttributeID ptUpdateID, byte u8IIN1, byte u8IIN2, ref short ptErrorValue);
	
    /*! \brief  Client Poll Status for a particular CallBack */
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3ClientPollStatusCallback(ushort u16ObjectId, ref sDNP3DataAttributeID ptUpdateID, eWriteFunctionID eFunctionID, ref short ptErrorValue);



	/*! \brief	Command Select CallBack */
	/*! \brief	Select success return error code 0 EC_NONE, else following error codes are accepted
				APP_ERROR_CALLBACK_FORMAT_ERROR 			= -42,		
				APP_ERROR_CALLBACK_NOT_SUPPORTED			= -43,		
				APP_ERROR_CALLBACK_ALREADY_ACTIVE			= -44,		
				APP_ERROR_CALLBACK_HARDWARE_ERROR			= -45,		
				APP_ERROR_CALLBACK_LOCAL					= -46,		
				APP_ERROR_CALLBACK_NOT_AUTHORIZED			= -47,		
				APP_ERROR_CALLBACK_AUTOMATION_INHIBIT		= -48,		
				APP_ERROR_CALLBACK_PROCESSING_LIMITED		= -49,		
				APP_ERROR_CALLBACK_OUT_OF_RANGE 			= -50,		
				APP_ERROR_CALLBACK_NON_PARTICIPATING		= -51,		
				APP_ERROR_CALLBACK_UNDEFINED				= -52,		
	
	*/
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3ControlSelectCallback(ushort u16ObjectId, ref sDNP3DataAttributeID psSelectID, ref sDNP3DataAttributeData psSelectValue, ref sDNP3CommandParameters psSelectParams, ref short ptErrorValue);
	
	/*! \brief	Command Operate CallBack */
	/*! \brief	Operate success return error code 0 EC_NONE, else following error codes are accepted
				APP_ERROR_CALLBACK_FORMAT_ERROR 			= -42,		
				APP_ERROR_CALLBACK_NOT_SUPPORTED			= -43,		
				APP_ERROR_CALLBACK_ALREADY_ACTIVE			= -44,		
				APP_ERROR_CALLBACK_HARDWARE_ERROR			= -45,		
				APP_ERROR_CALLBACK_LOCAL					= -46,		
				APP_ERROR_CALLBACK_NOT_AUTHORIZED			= -47,		
				APP_ERROR_CALLBACK_AUTOMATION_INHIBIT		= -48,		
				APP_ERROR_CALLBACK_PROCESSING_LIMITED		= -49,		
				APP_ERROR_CALLBACK_OUT_OF_RANGE 			= -50,		
				APP_ERROR_CALLBACK_NON_PARTICIPATING		= -51,		
				APP_ERROR_CALLBACK_UNDEFINED				= -52,		
	
	*/
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3ControlOperateCallback(ushort u16ObjectId, ref sDNP3DataAttributeID psOperateID, ref sDNP3DataAttributeData psOperateValue, ref sDNP3CommandParameters psOperateParams, ref short ptErrorValue);
	
	/*! \brief	Debug Message CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3DebugMessageCallback(ushort u16ObjectId, ref sDNP3DebugData psDebugData, ref short ptErrorValue);
	
	/*! \brief	Client connection status CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3ClientStatusCallback(ushort u16ObjectId, ref sDNP3DataAttributeID psDAID, ref eServerConnectionStatus peSat, ref short ptErrorValue);
	
	/*! \brief	Server cold restart CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3ColdRestartCallback(ushort u16ObjectId, ref sDNP3DataAttributeID psDAID, ref short ptErrorValue);
	
	/*! \brief	Server warm restart CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3WarmRestartCallback(ushort u16ObjectId, ref sDNP3DataAttributeID psDAID, ref short ptErrorValue);
	
	/*! \brief	device attribute CallBack */
	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short DNP3DeviceAttributeCallback(ushort u16ObjectId, ref sDNP3DataAttributeID psDAID, ref sDNP3DeviceAttributeData psDeviceAttrValue, ref short ptErrorValue); 
	
	
	
	/*! \brief		Create Server/client parameters structure  */
	[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
     CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
	public struct sDNP3Parameters
	{
		public  tgtcommon.eApplicationFlag	eAppFlag; 		  /*!< Flag set to indicate the type of application */
		public uint						  	u32Options;		  /*!< Options flag, used to set client/server global options see #eApplicationOptionFlag for values */
		public ushort 						u16ObjectId;/*!<  user idenfication will be retured in the callback for dnp3object identification*/
		public DNP3ReadCallback				ptReadCallback;	  /*!< Read callback function. If equal to NULL then callback is not used. */
		public DNP3WriteCallback			ptWriteCallback;	  /*!< Write callback function. If equal to NULL then callback is not used. */
		public DNP3UpdateCallback			ptUpdateCallback;   /*!< Update callback function. If equal to NULL then callback is not used. */
		public DNP3ControlSelectCallback	ptSelectCallback;   /*!< Function called when a Select Command  is executed.	If equal to NULL then callback is not used*/
		public DNP3ControlOperateCallback	ptOperateCallback;  /*!< Function called when a Operate command is executed.	If equal to NULL then callback is not used */
		public DNP3DebugMessageCallback		ptDebugCallback;	  /*!< Function called when debug options are set. If equal to NULL then callback is not used */
		public DNP3UpdateIINCallback		ptUpdateIINCallback;/*!< Function called when IIN 1 byte changed. If equal to NULL then callback is not used */
        public DNP3ClientPollStatusCallback ptClientPollStatusCallback;/*!< Function called when Client Compteated Poll operation for particular Server. If equal to NULL then callback is not used */
        public DNP3ClientStatusCallback		ptClientStatusCallback;	 /*!< Function called when client Connection status changed */
		public DNP3ColdRestartCallback 		ptColdRestartCallback;	/*!< Function called when a cold restart Command is executed.  If equal to NULL then callback is not used*/
		public DNP3WarmRestartCallback 		ptWarmRestartCallback;	 /*!< Function called when a warm restart Command is executed.	If equal to NULL then callback is not used*/
		public DNP3DeviceAttributeCallback 	ptDeviceAttrCallback;   /*!< Device Attribute callback function. If equal to NULL then callback is not used. */

	}


}
