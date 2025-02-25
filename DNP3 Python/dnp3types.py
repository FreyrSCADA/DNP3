
'''
/****************************************************************************
# \file          dnp3types.h
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
 
/****************************************************************************
'''

import ctypes
from enum import Enum
from structureWithEnums import *
from iec60870common import *
from tgtserialtypes import *
from tgtcommon import *
from tgtdefines import *
from tgttypes import *

    

# \brief  Max Size of Rx Message sent to callback 
DNP3_MAX_RX_MESSAGE  =        292

# \brief  Max Size of Tx Message sent to callback 
DNP3_MAX_TX_MESSAGE   =       292

     
        

# Flags for struct sDNP3Parameters.uiOptions flags 
class eDNP3ApplicationOptionFlag(IntEnum):        
    DNP3_APP_OPTION_NONE                                 = 0x00 # No options set 
        


# Flags for Communication Mode serial /tcp   
class  eCommunicationMode(IntEnum):

    COMM_SERIAL             =   1           # Serial communication 
    TCP_IP_MODE             =   2          #  TCP  communication 
    UDP_IP_MODE             =   3         #  UDP communication 




# List of error code returned by API functions 
class eAppErrorCodes(IntEnum):

    APP_ERROR_ERRORVALUE_IS_NULL                = -1501		# APP Error value is  null
    APP_ERROR_CREATE_FAILED                     = -1502       	# DNP3 create function failed 
    APP_ERROR_FREE_FAILED                       = -1503       	# DNP3 free function failed 
    APP_ERROR_INITIALIZE                        = -1504       	# DNP3 server/client initialize function failed 
    APP_ERROR_LOADCONFIG_FAILED                 = -1505       	# DNP3 Load configuration function failed 
    APP_ERROR_CHECKALLOCLOGICNODE               = -1506       	# DNP3 Load- check alloc logical node function failed 
    APP_ERROR_START_FAILED                      = -1507       	# DNP3 Start function failed 
    APP_ERROR_STOP_FAILED                       = -1508       	# DNP3 Stop function failed 
    APP_ERROR_SETDEBUGOPTIONS_FAILED            = -1509       	# DNP3 set debug option failed 
    APP_ERROR_PHYSICALLAYEROPEN_FAILED          = -1510      	# DNP3 Physical Layer open operation failed  
    APP_ERROR_PHYSICALLAYERCLOSE_FAILED         = -1511      	# DNP3 Physical Layer close operation failed 
    APP_ERROR_SERIALCOMOPEN_FAILED              = -1512      	# DNP3 Physical Layer com open failed    
    APP_ERROR_SERIALCOMCLOSE_FAILED             = -1513      	# DNP3 Physical Layer com close failed   
    APP_ERROR_PHYSICALINITIALIZE_FAILED         = -1514      	# DNP3 Physical Layer initialization failed  
    APP_ERROR_LINKLAYER_INITIALIZE              = -1515      	# DNP3 Data Link Layer initialization failed 
    APP_ERROR_LINKLAYER_DEINITIALIZE            = -1516      	# DNP3 Data Link Layer deinitialization failed   
    APP_ERROR_LINKLAYER_INVALIDSTATE            = -1517      	# DNP3 Data Link Layer Connection invalid state  
    APP_ERROR_TCPWAIT_FAILED                    = -1518      	# DNP3 physical layer ethernet wait operation failed 
    APP_ERROR_ETHERNET_INITIALIZATION_FAILED    = -1519      	# DNP3 Data Link Layer ethernet initialization like bind ip & port number failed 
    APP_ERROR_RECEIVE_FAILED                    = -1520      	# DNP3 Data Link Layer serial receive failed 
    APP_ERROR_DLDECODE_FAILED                   = -1521      	# DNP3 Data Link Layer Decode operation failed 
    APP_ERROR_TRANSLAYER_INITIALIZE             = -1522      	# DNP3 Transport function Layer initialization failed
    APP_ERROR_TRANSLAYER_FAILED                 = -1523      	# DNP3 Transport function Layer operation failed
    APP_ERROR_INVALIDDNP3_OBJECTPREFIXCODE      = -1524      	# DNP3 Transport function Layer operation failed
    APP_ERROR_DNP3RANGE_SPECIFIER_ERROR         = -1525      	# DNP3 app Layer decode operation failed- invalid range specifier
    APP_ERROR_DNP3APPL_ASDUPHARSE_FAILED        = -1526      	# DNP3 app Layer decode operation failed- asdu pharse failed
    APP_ERROR_APPLAYER_INITIALIZE_FAILED        = -1527      	# DNP3 App Layer initialization failed
    APP_ERROR_OBJECTDB_INITIALIZE_FAILED        = -1528      	# DNP3 Object Database initialization failed
    APP_ERROR_UPDATE_FAILED                     = -1529      	# DNP3 Update function failed 
    APP_ERROR_EVENTBUFFER_INITIALIZE_FAILED     = -1530      	# DNP3 Event Buffer initialization failed
    APP_ERROR_DNP3APPL_INVALID_OHDO             = -1531      	# DNP3 app Layer decode operation failed- invalid object header & data object 
    APP_ERROR_DNP3APPL_INVALID_VARIATION        = -1532      	# DNP3 app Layer decode operation failed- invalid variationr
    APP_ERROR_DNP3APPL_INVALID_QUALIFIER        = -1533      	# DNP3 app Layer decode operation failed- invalid qualifierr
    APP_ERROR_DNP3APPL_INVALID_INDEX            = -1534      	# DNP3 app Layer decode operation failed- invalid qualifier
    APP_ERROR_LOADCONFIG_INVALID_VAR            = -1535      	# DNP3 Load configuration function, Static / Event object variation is invalid  
    APP_ERROR_CREATESEMAPHORE_PHYSCIALLAYER     = -1536      	# DNP3 physical layer semaphore creation is invalid  
    APP_ERROR_DELETESEMAPHORE_PHYSCIALLAYER     = -1537      	# DNP3 physical layer semaphore deletion is invalid  
    APP_ERROR_RESERVESEMAPHORE_PHYSCIALLAYER    = -1538      	# DNP3 physical layer semaphore reservation is invalid  
    APP_ERROR_CREATESEMAPHORE_TRANSPORTLAYER    = -1539      	# DNP3 transport layer semaphore creation is invalid  
    APP_ERROR_DELETESEMAPHORE_TRANSPORTLAYER    = -1540      	# DNP3 transport layer semaphore deletion is invalid  
    APP_ERROR_RESERVESEMAPHORE_TRANSPORTLAYER   = -1541      	# DNP3 transport layer semaphore reservation is invalid              
    APP_ERROR_TIMESTRUCT_INVALID                = -1542      	# DNP3 time structure is invalid 
    APP_ERROR_READ_FAILED                       = -1543      	# DNP3 Read function failed 
    APP_ERROR_WRITE_FAILED                      = -1544      	# DNP3 Write function failed 
    APP_ERROR_SELECT_FAILED                     = -1545      	# DNP3 Select function failed 
    APP_ERROR_OPERATE_FAILED                    = -1546      	# DNP3 Operate function failed 
    APP_ERROR_CANCEL_FAILED                     = -1547      	# DNP3 Cancel function failed 
    APP_ERROR_GETDATATYPEANDSIZE_FAILED         = -1548      	# DNP3 Get Data type & size function failed 
    APP_ERROR_INVALID_POINTCOUNT                = -1549      	# Total Number of Points exceeding Point Count 
    APP_ERROR_TCPCONNECT_FAILED                 = -1550      	# DNP3 physical layer ethernet CONNECT operation failed 
    APP_ERROR_COMMAND_FAILED                    = -1551      	# DNP3 Client command failed 
    APP_ERROR_FILEREAD_FAILED                   = -1552     	# DNP3 Client  fileread command failed 
    APP_ERROR_DATASET_READ_FAILED               = -1553     	# DNP3 Client dataset command failed 
    APP_ERROR_CLIENTSTATUS_FAILED               = -1554     	# DNP3 Client status command failed 
    APP_ERROR_FILEWRITE_FAILED                  = -1555     	# DNP3 Client file write command failed 
    APP_ERROR_READ_DEVICEATTRIBUTE_FAILED       = -1556    	# DNP3 Client device attribute read command failed 
    APP_ERROR_GETIIN1_FAILED                    = -1557      	# DNP3 Get IIN 1 function failed 
    APP_ERROR_GET_OBJECTSTATUS_FAILED           = -1558    	# DNP3 get object status command failed 
    APP_ERROR_CLIENT_STOPSERVERMULTIDROP        = -1559		# DNP3 Client Api function stop server multidrop failed 
    APP_ERROR_ADD_MULTIBLOCK       = -1560		# DNP3 Server application layer multi block addition 2048b memory alloc  
    


# List of error value returned by API functions 
class eAppErrorValues(IntEnum):

    APP_ERRORVALUE_ERRORCODE_IS_NULL                = -1501          # APP Error code is Null 
    APP_ERRORVALUE_INVALID_INPUTPARAMETERS          = -1502          # Supplied Parameters are invalid 
    APP_ERRORVALUE_INVALID_APPFLAG                  = -1503          # Invalid Application Flag , Client not supported by the API
    APP_ERRORVALUE_UPDATECALLBACK_CLIENTONLY        = -1504          # Update Callback used only for client
    APP_ERRORVALUE_NO_MEMORY                        = -1505          # Allocation of memory has failed 
    APP_ERRORVALUE_INVALID_DNP3OBJECT               = -1506          # Supplied DNP3Object is invalid 
    APP_ERRORVALUE_DNP3FREE_CALLED_BEFORE_STOP      = -1507          # APP state is running free function called before stop function
    APP_ERRORVALUE_INVALID_STATE                    = -1508          # DNP3OBJECT invalid state  
    APP_ERRORVALUE_INVALID_DEBUG_OPTION             = -1509          # Invalid debug option  
    APP_ERRORVALUE_INVALID_COMMODE                  = -1510          # Invalid communication mode serial, tcp only allowed  
    APP_ERRORVALUE_TASK_CREATEFAILED                = -1511          # Task creation failed  
    APP_ERRORVALUE_TASK_STOPFAILED                  = -1512          # Task stop failed 
    APP_ERRORVALUE_DATALINKLAYER_INVALIDSTATE       = -1513          # DNP3 Data Link Layer Connection invalid state    
    APP_ERRORVALUE_DLRECEIVE_INVALIDSTARTCHAR       = -1514          # DNP3 slave received invalid start char  
    APP_ERRORVALUE_DLRECEIVE_INVALIDCRC             = -1515          # DNP3 data link layer invalid CRC Received 
    APP_ERRORVALUE_DLRECEIVE_INVALIDSLAVEADDRESS    = -1516          # DNP3 data link layer invalid slave address received
    APP_ERRORVALUE_DLDECODE_INVALID_DIRBIT          = -1517          # DNP3 data link layer invalid direction bit received
    APP_ERRORVALUE_DLDECODE_INVALID_FUNCTIONCODE    = -1518          # DNP3 data link layer invalid function code received
    APP_ERRORVALUE_DLDECODE_INVALID_PRMBIT          = -1519          # DNP3 data link layer invalid prm bit received
    APP_ERRORVALUE_DLDECODE_INVALID_FCVBIT          = -1520          # DNP3 data link layer invalid FCV Bit received
    APP_ERRORVALUE_TRANSLAYER_INVALID_STATE         = -1521          # DNP3 transport layer invalid state
    APP_ERRORVALUE_TRANSLAYER_INVALID_FIRFIN        = -1522          # DNP3 transport layer invalid fir fin 
    APP_ERRORVALUE_INVALID_GROUPID                  = -1523          # In the function eGroupID not valid, or later we will implement 
    APP_ERRORVALUE_INVALIDUPDATE_COUNT              = -1524          # Invalid update count 
    APP_ERRORVALUE_UPDATEOBJECT_NOTFOUND            = -1525          # For particular group id, index number not found 
    APP_ERRORVALUE_INVALID_DATATYPE                 = -1526          # For particular group id, sDNP3DataAttributeData invalid data type 
    APP_ERRORVALUE_INVALID_DATASIZE                 = -1527          # For particular group id, sDNP3DataAttributeData invalid data size 
    APP_ERRORVALUE_INVALID_BI_STATICVAR             = -1528          # DNP3 Load config parameters Binary input static variation is invalid
    APP_ERRORVALUE_INVALID_DBI_STATICVAR            = -1529          # DNP3 Load config parameters Double Binary input static variation is invalid
    APP_ERRORVALUE_INVALID_BO_STATICVAR             = -1530          # DNP3 Load config parameters Binary Output static variation is invalid
    APP_ERRORVALUE_INVALID_CI_STATICVAR             = -1531          # DNP3 Load config parameters Counter input static variation is invalid
    APP_ERRORVALUE_INVALID_FZCI_STATICVAR           = -1532          # DNP3 Load config parameters frozen counter input static variation is invalid
    APP_ERRORVALUE_INVALID_AI_STATICVAR             = -1533          # DNP3 Load config parameters Analog input static variation is invalid
    APP_ERRORVALUE_INVALID_FZAI_STATICVAR           = -1534          # DNP3 Load config parameters Frozen analog input static variation is invalid
    APP_ERRORVALUE_INVALID_AID_STATICVAR            = -1535          # DNP3 Load config parameters Analog input deadband static variation is invalid
    APP_ERRORVALUE_INVALID_AO_STATICVAR             = -1536          # DNP3 Load config parameters Analog output static variation is invalid
    APP_ERRORVALUE_INVALID_BI_EVENTVAR              = -1537          # DNP3 Load config parameters Binary input Event variation is invalid
    APP_ERRORVALUE_INVALID_DBI_EVENTVAR             = -1538          # DNP3 Load config parameters Double Binary input Event variation is invalid
    APP_ERRORVALUE_INVALID_CI_EVENTVAR              = -1539          # DNP3 Load config parameters counter input Event variation is invalid
    APP_ERRORVALUE_INVALID_AI_EVENTVAR              = -1540          # DNP3 Load config parameters Analog input Event variation is invalid
    APP_ERRORVALUE_INVALID_FZCI_EVENTVAR            = -1541          # DNP3 Load config parameters Frozen counter input Event variation is invalid
    APP_ERRORVALUE_INVALID_FZAI_EVENTVAR            = -1542          # DNP3 Load config parameters Frozen Analog input Event variation is invalid
    APP_ERRORVALUE_INVALID_COM_MODE                 = -1543          # DNP3 Load config parameters Communication mode is invalid
    APP_ERRORVALUE_INVALID_COMPORT_NUMBER           = -1544          # DNP3 Load config parameters Communication Serial com port number is greater than 9
    APP_ERRORVALUE_INVALID_BAUD_RATE                = -1545          # DNP3 Load config parameters Communication SERIAL COM Invalid baud rate
    APP_ERRORVALUE_INVALID_PARITY                   = -1546          # DNP3 Load config parameters Communication SERIAL COM Invalid parity
    APP_ERRORVALUE_INVALID_STOPBIT                  = -1547          # DNP3 Load config parameters Communication SERIAL COM Invalid Stop bit
    APP_ERRORVALUE_INVALID_WORDLENGTH               = -1548          # DNP3 Load config parameters Communication SERIAL COM Invalid word length
    APP_ERRORVALUE_INVALID_FLOWCONTROL              = -1549          # DNP3 Load config parameters Communication SERIAL COM Invalid flow control                
    APP_ERRORVALUE_INVALID_ETHERNETCOMMODE          = -1550          # DNP3 Load config parameters Communication ethernet now tcp only support, later we will support UDP
    APP_ERRORVALUE_INVALID_IPPORTNUMBER             = -1551          # DNP3 Load config parameters Communication TCP Invalid port Number
    APP_ERRORVALUE_INVALID_DEBUGOPTION              = -1552          # DNP3 Load config parameters Invalid Debug option
    APP_ERRORVALUE_INVALID_MASTER_ADDRESS           = -1553          # DNP3 Load config parameters Invalid master address
    APP_ERRORVALUE_INVALID_SLAVE_ADDRESS            = -1554          # DNP3 Load config parameters invalid slave address
    APP_ERRORVALUE_INVALID_SLAVEMASTER_ADDRESSSAME  = -1555          # DNP3 Load config parameters master & slave address must not be equal
    APP_ERRORVALUE_INVALID_LINKLAYER_TIMEOUT        = -1556          # DNP3 Load config parameters invalid link layer timeout
    APP_ERRORVALUE_INVLAID_EVENTBUFFER_SIZE         = -1557          # DNP3 Load config parameters invalid  Event buffer size  10
    APP_ERRORVALUE_INVLAID_EVENTBUF_OVERFLOWPER     = -1558          # DNP3 Load config parameters invalid  Event buffer OVER FLOW percentage  25|| >100
    APP_ERRORVALUE_INVALID_DATETIME_STRUCT          = -1559          # DNP3 invalid date time struct user input
    APP_ERRORVALUE_INVALID_NUMBEROFOBJECTS          = -1560          # DNP3 invalid no of objects user input
    APP_ERRORVALUE_INVALID_DNP3OBJECTS              = -1561          # DNP3 Load config parameters dnp3 objects , invalid u16NoofPoints must be 1-1000  & each group total no of objects 1 - 1000
    APP_ERRORVALUE_INVALID_MAXNOOFEVENTSUNSOL       = -1562          # Each Unsolicited message contains max no of events, minimum 1 
    APP_ERRORVALUE_READCALLBACK_CLIENTONLY          = -1563          # Read Callback used only for client
    APP_ERRORVALUE_CANCELCALLBACK_CLIENTONLY        = -1564          # Cancel Callback used only for client
    APP_ERRORVALUE_INVALID_DATAPOINTER              = -1565          # Update function invalid void data pointer
    APP_ERRORVALUE_INVALID_POINTCOUNT               = -1566          # Total Number of Points exceeding Point Count
    APP_ERRORVALUE_INVALID_INDEX                    = -1567          # Invalid index number
    APP_ERRORVALUE_INVALID_APPSQUENCE               = -1568          # Invalid api function calling sequence
    APP_ERRORVALUE_INVALID_CONTROLMODEL             = -1569          # Invalid control mode 
    APP_ERRORVALUE_SERVER_NOTCONNECTED              = -1570          # Server device not connected- command sending failed 
    APP_ERRORVALUE_INVALID_OPTYPE                   = -1571          # Invalid operation mode 
    APP_ERRORVALUE_INVALID_DEADBANDCALCULATION_METHOD = -1572        # Invalid Deadband calculation method
    APP_ERRORVALUE_INVALID_CCOMMANDTIMEOUT          = -1573          # Invalid Command timeout minimum 3000ms
    APP_ERRORVALUE_COMMAND_TIMEOUT                  = -1574          # Command timeout  
    APP_ERRORVALUE_FILE_INVALIDINPUTFILE            = -1575          # Invalid input file cannot fopen
    APP_ERRORVALUE_FILEREAD_PERMISSION_DENIED        = -1576         # Permission was denied due to improper authentication key, user name or password         
    APP_ERRORVALUE_FILEREAD_INVALID_MODE             = -1577         # An unsupported or unknown operation mode was requested 
    APP_ERRORVALUE_FILEREAD_FILE_NOT_FOUND           = -1578         # The requested file does not exist 
    APP_ERRORVALUE_FILEREAD_FILE_LOCKED              = -1579         # The requested file is already in use by another user 
    APP_ERRORVALUE_FILEREAD_TOO_MANY_OPEN            = -1580         # File could not be opened because the number of simultaneously opened files would be exceeded 
    APP_ERRORVALUE_FILEREAD_INVALID_HANDLE           = -1581         # There is no file opened with the handle in the request 
    APP_ERRORVALUE_FILEREAD_WRITE_BLOCK_SIZE         = -1582         # The outstation is unable to negotiate a suitable write block size  
    APP_ERRORVALUE_FILEREAD_COMM_LOST                = -1583         # Communications were lost or cannot be established with the end device where the file resides 
    APP_ERRORVALUE_FILEREAD_CANNOT_ABORT             = -1584         # An abort request was unsuccessful because the outstation is unable or not programmed to abort, or the outstation knows that aborting the file would make it unusable 
    APP_ERRORVALUE_FILEREAD_NOT_OPENED               = -1585         # File handle does not reference an opened file 
    APP_ERRORVALUE_FILE_INVALID_OUTPUTFILE           = -1586         # File Read, invalid destination file 
    APP_ERRORVALUE_CALLBACK_TIMEOUT                  = -1587      		# Request not accepted because timeout 
    APP_ERRORVALUE_CALLBACK_NO_SELECT                = -1588      		# Request not accepted because No Previous select 
    APP_ERRORVALUE_CALLBACK_FORMAT_ERROR             = -1589      		# Request not accepted because there were formatting errors in the control request (either select, operate, or direct operate) 
    APP_ERRORVALUE_CALLBACK_NOT_SUPPORTED            = -1590      		# Request not accepted because a control operation is not supported for this point 
    APP_ERRORVALUE_CALLBACK_ALREADY_ACTIVE           = -1591      		# Request not accepted, because the control queue is full or the point is already active 
    APP_ERRORVALUE_CALLBACK_HARDWARE_ERROR           = -1592      		# Request not accepted because of control hardware problems 
    APP_ERRORVALUE_CALLBACK_LOCAL                    = -1593      		# Request not accepted because Local/Remote switch is in Local position 
    APP_ERRORVALUE_CALLBACK_NOT_AUTHORIZED           = -1594      		# Request not accepted because of insufficient authorization 
    APP_ERRORVALUE_CALLBACK_AUTOMATION_INHIBIT       = -1595      		# Request not accepted because it was prevented or inhibited by a local automation process 
    APP_ERRORVALUE_CALLBACK_PROCESSING_LIMITED       = -1596      		# Request not accepted because the device cannot process any more activities than are presently in progress 
    APP_ERRORVALUE_CALLBACK_OUT_OF_RANGE             = -1597      		# Request not accepted because the value is outside the acceptable range permitted for this point 
    APP_ERRORVALUE_CALLBACK_NON_PARTICIPATING        = -1598      		# Sent in request messages indicating that the outstation shall not issue or perform the control operation 
    APP_ERRORVALUE_CALLBACK_UNDEFINED                = -1599      		# Request not accepted because of some other undefined reason 
    APP_ERRORVALUE_INVALID_DEADBAND                  = -1600      		# For AI, ONLY THE DEADBAND VALUE APPLICABLE,FOR OTHER Groupid must be zero   
    APP_ERRORVALUE_INVALID_SBO_TIMEOUT               = -1601      		# For input group,sbo timeout must be zero, for direct operate it must be zero, if sbo controlmodel,minimum value 1000,max 20000 
    APP_ERRORVALUE_INVALID_APPLAYER_TIMEOUT          = -1602    		# DNP3 Load config parameters invalid APP layer timeout 5000, 100000
    APP_ERRORVALUE_INVALID_TIMESYNC_TIMEOUT          = -1603    		# Time sync timeout 
    APP_ERRORVALUE_FILETRANSFER_DISABLED             = -1604       	# File transfer operation disabled  
    APP_ERRORVALUE_INVALID_INTIAL_DATABASE_QUALITYFLAG 	= -1605     	# Invalid initialdatabase quality flag 
    APP_ERRORVALUE_TRIAL_EXPIRED                      	= -1606     	# Trial software expired contact support@freyrscada.com
    APP_ERRORVALUE_TRIAL_INVALID_POINTCOUNT           	= -1607     	# Trial software - Total Number of Points exceeded, maximum 100 points
    APP_ERRORVALUE_SERVER_DISABLED						= -1608		# Server functionality disabled in the api, please contact support@freyrscada.com 
    APP_ERRORVALUE_CLIENT_DISABLED						= -1609		# Client functionality disabled in the api, please contact support@freyrscada.com
    APP_ERRORVALUE_INVALID_BO_EVENTVAR              	= -1610        # DNP3 Load config parameters Binary Output Event variation is invalid
    APP_ERRORVALUE_INVALID_AO_EVENTVAR              	= -1611        # DNP3 Load config parameters Analog Output Event variation is invalid
    APP_ERRORVALUE_FILEREAD_HANDLE_EXPIRED          	= -1612        # File closed due to inactivity timeout 
    APP_ERRORVALUE_FILEREAD_BUFFER_OVERRUN          	= -1613        # Too much data was received in a write request 
    APP_ERRORVALUE_FILEREAD_FATAL						= -1614        # A fatal error has occurred
    APP_ERRORVALUE_FILEREAD_BLOCK_SEQ					= -1615        # The received data block does not have the expected sequence number       
    APP_ERRORVALUE_INVALID_CROB_TCC_VALUE				= -1616        # CROB Command data , tcc - 0-null, 1 close, 2 trip, only allowed, 3 reserved not allowed       
    APP_ERRORVALUE_INVALID_COMMAND_VARIATION            = -1617		# CROB Command v1, analog output command data v1,2,3 supported 
    APP_ERRORVALUE_MORETHAN_100BLOCKS					= -1618		# Server add more than 100 blocks app multi frame transmission 
    




        
# List of Quality flags 
class eDNP3QualityFlags(IntEnum):
	   
	GOOD            = 0x0000   # OFFLINE 
	ONLINE          = 0x0001   # ONLINE - If clear, the point is inactive or disabled and unable to obtain field data
	RESTART         = 0x0002   # RESTART - indicates that the data has not been updated from the field since device reset
	COMM_LOST       = 0x0004   # COMM_LOST - indicates that there is a communication failure in the path between the device where the data originates and the reporting device.
	REMOTE_FORCED   = 0x0008   # REMOTE_FORCED - If set, the data value is overridden in a downstream reporting device
	LOCAL_FORCED    = 0x0010   # LOCAL_FORCED -If set, the data value is overridden by the device
	CHATTER_FILTER  = 0x0020   # CHATTER_FILTER - Only applicable to Binary Input and Double Input object groups - changing between states at a sufficiently high enough rate
	ROLLOVER        = 0x0040   # ROLLOVER - Only applicable to Counter Input object group - counter rollover occurs  
	OVER_RANGE      = 0x0080   # OVER_RANGE - Only applicable to Analog Input, Analog Output status  object groups - If set, the data object’s true value exceeds the valid measurement range of the object    
	DISCONTINUITY   = 0x0100   # DISCONTINUITY - Only applicable to Counter Input object groups - If set, the reported counter value cannot be compared against a prior value    
	REFERENCE_ERR   = 0x0200   # REFERENCE_ERR - Only applicable to Analog Input, Analog Output status object groups.If set, object’s data value might not have the expected level of accuracy 


# Group Identication List 
class eDNP3GroupID(IntEnum):

	BINARY_INPUT                    =   1  # Binary Input (DNP3Group 1) 
	DOUBLE_INPUT                    =   3  # Double-bit Binary Input (DNP3Group 3) 
	BINARY_OUTPUT                   =   10 # Binary Output (DNP3Group 10) 
	COUNTER_INPUT                   =   20 # Counter Input (DNP3Group 20) 
	FRCOUNTER_INPUT                 =   21 # Frozen Counter Input (DNP3Group 21) 
	ANALOG_INPUT                    =   30 # Analog Input (DNP3Group 30) 
	FRANALOG_INPUT                  =   31 # Frozen Analog Input (DNP3Group 31) 
	ANALOG_OUTPUTS                  =   40 # Analog output (DNP3Group 40) 
	DATE_TIME                       =   50 # Date & time (DNP3Group 50) 
	OCTECT_STRING                   =   110 # Octect String (DNP3Group 110) 
	VIRTUAL_TERMINAL_OUTPUT         =   112 # virtual terminal String (DNP3Group 112) 
	


# Default Static Variation for BinaryInput  
class eDefaultStaticVariationBinaryInput(IntEnum):

	BI_PACKED_FORMAT              =   1  # Binary Input –  format 
	BI_WITH_FLAGS                 =   2  # Binary Input – With flags 


# Default Static Variation for DoubleBit Binary Input 
class eDefaultStaticVariationDoubleBitBinaryInput(IntEnum):

	DBBI_PACKED_FORMAT    =   1  # Double-bit Binary Input –  format 
	DBBI_WITH_FLAGS       =   2  # Double-bit Binary Input – With flags


#  Default Static Variation for Binary Output 
class eDefaultStaticVariationBinaryOutput(IntEnum):

	BO_PACKED_FORMAT             =   1  # Binary Output –  format
	BO_WITH_FLAGS                =   2  # Binary Output – Output status with flags


# Default Static Variation for Counter Input 
class eDefaultStaticVariationCounterInput(IntEnum):

	CI_32BIT_WITHFLAG                  =   1  # Counter – 32-bit with flag
	CI_16BIT_WITHFLAG                  =   2  # Counter – 16-bit with flag
	CI_32BIT_WITHOUTFLAG               =   5  # Counter – 32-bit without flag
	CI_16BIT_WITHOUTFLAG               =   6  # Counter – 16-bit without flag


# Default Static Variation for Frozen Counter Input 
class eDefaultStaticVariationFrozenCounterInput(IntEnum):

	FCI_32BIT_WITHFLAG            =   1  # Frozen Counter – 32-bit with flag
	FCI_16BIT_WITHFLAG            =   2  # Frozen Counter – 16 bit with flag
	FCI_32BIT_WITHFLAGANDTIME     =   5  # Frozen Counter – 32-bit with flag and time
	FCI_16BIT_WITHFLAGANDTIME     =   6  # Frozen Counter – 16-bit with flag and time
	FCI_32BIT_WITHOUTFLAG         =   9  # Frozen Counter – 32-bit without flag
	FCI_16BIT_WITHOUTFLAG         =   10 # Frozen Counter – 16-bit without flag


# Default Static Variation for Analog Input 
class eDefaultStaticVariationAnalogInput(IntEnum): 

	AI_32BIT_WITHFLAG                  =   1  # Analog Input – 32-bit with flag
	AI_16BIT_WITHFLAG                  =   2  # Analog Input – 16-bit with flag
	AI_32BIT_WITHOUTFLAG               =   3  # Analog Input – 32-bit without flag
	AI_16BIT_WITHOUTFLAG               =   4  # Analog Input – 16-bit without flag
	AI_SINGLEPREC_FLOATWITHFLAG        =   5  # Analog Input – Single-prec flt-pt with flag


# Default Static Variation for Frozen Analog Input 
class eDefaultStaticVariationFrozenAnalogInput(IntEnum):

	FAI_32BITWITHFLAG            =   1  # Frozen Analog Input – 32-bit with flag 
	FAI_16BITWITHFLAG            =   2  # Frozen Analog Input – 16-bit with flag
	FAI_32BITWITHTIMEOFFREEZE    =   3  # Frozen Analog Input – 32-bit with time-of-freeze
	FAI_16BITWITHTIMEOFFREEZE    =   4  # Frozen Analog Input – 16-bit with time-of-freeze
	FAI_32BITWITHOUTFLAG         =   5  # Frozen Analog Input – 32-bit without flag
	FAI_16BITWITHOUTFLAG         =   6  # Frozen Analog Input – 16-bit without flag
	FAI_SINGLEPRECFLOATWITHFLAG  =   7  # Frozen Analog Input – Single-prec flt-pt with flag


# Default Static Variation for Analog Input DeadBand 
class eDefaultStaticVariationAnalogInputDeadBand(IntEnum): 

	DAI_16BIT                  =   1  # Analog Input Deadband – 16-bit 
	DAI_32BIT                  =   2  # Analog Input Deadband – 32-bit        
	DAI_SINGLEPRECFLOAT        =   3  # Analog Input Deadband – Single-prec flt-pt


# Default Static Variation for Analog Output 
class eDefaultStaticVariationAnalogOutput(IntEnum):

	AO_32BIT_WITHFLAG               =   1  # Analog Output Status – 32-bit with flag
	AO_16BIT_WITHFLAG               =   2  # Analog Output Status – 16-bit with flag
	AO_SINGLEPRECFLOAT_WITHFLAG     =   3  # Analog Output Status – Single-prec flt-pt with flag


# Default Event Variation for Binary Input 
class eDefaultEventVariationBinaryInput(IntEnum):

	BIE_WITHOUT_TIME                   =   1  # Binary Input Event – Without time 
	BIE_WITH_ABSOLUTETIME              =   2  # Binary Input Event – With absolute time
	BIE_WITH_RELATIVETIME              =   3  # Binary Input Event – With relative time


# Default Event Variation for Double Bit Binary Input 
class eDefaultEventVariationDoubleBitBinaryInput(IntEnum):

	DBBIE_WITHOUT_TIME          =   1  # Double-bit Binary Input Event – Without time
	DBBIE_WITH_ABSOLUTETIME     =   2  # Double-bit Binary Input Event – With absolute time
	DBBIE_WITH_RELATIVETIME     =   3  # Double-bit Binary Input Event – With relative time


# Default Event Variation for Counter Input 
class eDefaultEventVariationCounterInput(IntEnum):
    CIE_32BIT_WITHFLAG                    =   1  # Counter Event – 32-bit with flag 
    CIE_16BIT_WITHFLAG                    =   2  # Counter Event – 16-bit with flag 
    CIE_32BIT_WITHFLAG_WITHTIME           =   5  # Counter Event – 32-bit with flag and time 
    CIE_16BIT_WITHFLAG_WITHTIME           =   6  # Counter Event – 16-bit with flag and time 


# Default Event Variation for Frozen Counter Input 
class eDefaultEventVariationFrozenCounterInput(IntEnum): 

	FCIE_32BIT_WITHFLAG                    =   1 # Frozen Counter Event – 32-bit with flag 
	FCIE_16BIT_WITHFLAG                    =   2 # Frozen Counter Event – 16-bit with flag 
	FCIE_32BIT_WITHFLAG_WITHTIME           =   5 # Frozen Counter Event – 32-bit with flag and time
	FCIE_16BIT_WITHFLAG_WITHTIME           =   6 # Frozen Counter Event – 16-bit with flag and time


# Default Event Variation for Analog Input 
class eDefaultEventVariationAnalogInput(IntEnum):

	AIE_32BIT_WITHOUTTIME               =   1  # Analog Input Event – 32-bit without time 
	AIE_16BIT_WITHOUTTIME               =   2  # Analog Input Event –16-bit without time
	AIE_32BIT_WITHTIME                  =   3  # Analog Input Event – 32-bit with time
	AIE_16BIT_WITHTIME                  =   4  # Analog Input Event – 16-bit with time
	AIE_SINGLEPREC_WITHOUTTIME          =   5  # Analog Input Event – Single-prec flt-pt without time
	AIE_SINGLEPREC_WITHTIME             =   7  # Analog Input Event – Single-prec flt-pt with time



# Default Event Variation for Analog Output 
class eDefaultEventVariationAnalogOutput(IntEnum):

	AOE_32BIT_WITHOUTTIME               =   1  # Analog Output Event – 32-bit without time 
	AOE_16BIT_WITHOUTTIME               =   2  # Analog Output Event –16-bit without time
	AOE_32BIT_WITHTIME                  =   3  # Analog Output Event – 32-bit with time
	AOE_16BIT_WITHTIME                  =   4  # Analog Output Event – 16-bit with time
	AOE_SINGLEPREC_WITHOUTTIME          =   5  # Analog Output Event – Single-prec flt-pt without time
	AOE_SINGLEPREC_WITHTIME             =   7  # Analog Output Event – Single-prec flt-pt with time




# Default Event Variation for Frozen Analog Input 
class eDefaultEventVariationFrozenAnalogInput(IntEnum):

	FAIE_32BIT_WITHOUTTIME               =   1    # Frozen Analog Input Event – 32-bit without time 
	FAIE_16BIT_WITHOUTTIME               =   2    # Frozen Analog Input Event – 16-bit without time 
	FAIE_32BIT_WITHTIME                  =   3    # Frozen Analog Input Event – 32-bit with time 
	FAIE_16BIT_WITHTIME                  =   4    # Frozen Analog Input Event – 16-bit with time 
	FAIE_SINGLEPREC_WITHOUTTIME          =   5    # Frozen Analog Input Event – Single-prec flt-pt without time
	FAIE_SINGLEPREC_WITHTIME             =   7    # Frozen Analog Input Event – Single-prec flt-pt with time


# Default Event Variation for Binary Output 
class eDefaultEventVariationBinaryOutput(IntEnum):

	BOE_WITHOUT_TIME                   	=   1  # Binary Output Event – Without time 
	BOE_WITH_TIME              			=   2  # Binary Output Event – With time


	  

# Class Identication List 
class eDNP3ClassID(IntEnum): 

	NO_CLASS                        =   0  # 0 – Static data (current value), no events will be generated for this data
	CLASS_ONE                       =   1  # 1 – Event classes, events will be generated for this data.
	CLASS_TWO                       =   2  # 2 – Event classes, events will be generated for this data.
	CLASS_THREE                     =   3  # 3 – Event classes, events will be generated for this data.


 #   Flags for eDNP3ControlModelConfig
class eDNP3ControlModelConfig(IntEnum):
    INPUT_STATUS_ONLY                    = 0x00       # Control Model Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...
    DIRECT_OPERATION               = 0x01       # Direct Operate 
    SELECT_BEFORE_OPERATION        = 0x02       # Select Before Operate  


#   enum eClassSet list
class eClassSet(IntEnum):

	CLASS1_SETTINGS   =   0            # Class 1 settings 
	CLASS2_SETTINGS   =   1            # Class 2 settings 
	CLASS3_SETTINGS   =   2            # Class 3 settings 
   

 #   Flags for dnp3 write function 
class eWriteFunctionID(IntEnum):

	READCLASS0              =   1      # read class event buffer 0 
	READCLASS1              =   2      # read class event buffer 1 
	READCLASS2              =   3      # read class event buffer 2 
	READCLASS3              =   4      # read class event buffer 3 
	READCLASS123            =   5      # read class event buffer 1,2,3 
	READCLASS0123           =   6      # read class event buffer 0,1,2,3 
	TIMESYNC                =   7      # Send time sync command 
	CLEARRESTARTIIN         =   8      # send clear restart iin command 
	ENABLESPONT             =   9      # send Enable spontaneous event report - UnsolicitedResponse       
	DISABLESPONT            =   10     # send Disable spontaneous event report - UnsolicitedResponse      
	COLDRESTART             =   11     # send cold restart command to server  
	WARMRESTART             =   12     # send Warm restart command to server 
	DELAYMEASURE            =   13     # send delay measurement command to server 
	COUNTER_IMMEDIATE_FREEZE        =   14 # send counter immediate freeze command to server 
	COUNTER_IMMEDIATE_FREEZE_NOACK  =   15 # send counter immediate freeze - no ack command to server 
	COUNTER_FREEZE_AND_CLEAR        =   16 # send counter immediate freeze  & clear  command to server 
	COUNTER_FREEZE_AND_CLEAR_NOACK  =   17 # send counter immediate freeze  & clear - no ack command to server 
	AI_IMMEDIATE_FREEZE        =   18      # send analog input immediate freeze command to server 
	AI_IMMEDIATE_FREEZE_NOACK  =   19      # send analog input immediate freeze - no ack command to server 
	AI_FREEZE_AND_CLEAR        =   20      # send analog input immediate freeze  & clear  command to server 
	AI_FREEZE_AND_CLEAR_NOACK  =   21      # send analog input immediate freeze  & clear - no ack command to server 
	


#   Flags for analog input deadband calculation 
class   eAnalogInputDeadbandMethod(IntEnum):

	DEADBAND_NONE   =   0      # Analog Input , Deadband calculation method - none                
	DEADBAND_FIXED  =   1      # Analog Input , Deadband calculation method - Fixed 
	DEADBAND_INTEGRATING =   2 # Analog Input , Deadband calculation method - Integrtion 



	# \typedef enum eIINFirstByteBitsFlag
	#   \brief iin1 p-22 Internal indications first octect

class eIINFirstByteBitsFlag(IntEnum):
    BROADCAST           =   0x01 #  A broadcast message was received 
    CLASS_1_EVENTS      =   0x02 #  The outstation has unreported Class 1 events.  
    CLASS_2_EVENTS      =   0x04 # The outstation has unreported Class 2 events.   
    CLASS_3_EVENTS      =   0x08 # The outstation has unreported Class 3 events.   
    NEED_TIME           =   0x10 # Time synchronization is required.   
    LOCAL_CONTROL       =   0x20 # One or more of the outstation’s points are in local control mode.   
    DEVICE_TROUBLE      =   0x40 #  An abnormal, device-specific condition exists in the outstation.  
    DEVICE_RESTART      =   0x80 #  The outstation restarted.   




# \typedef enum eIINSecondByteBitsFlag
#   \brief iin1 p-22 Internal indications second octect

class eIINSecondByteBitsFlag(IntEnum):
    NO_FUNC_CODE_SUPPORT        =   0x01 #  The outstation does not support this function code.  
    OBJECT_UNKNOWN              =   0x02 #   Outstation does not support requested operation for objects in the request. 
    PARAMETER_ERROR             =   0x04 #  A parameter error was detected.  
    EVENT_BUFFER_OVERFLOW       =   0x08 #   An event buffer overflow condition exists in the outstation, and at least one unconfirmed event was lost. 
    ALREADY_EXECUTING           =   0x10 #  The operation requested is already executing. Support is optional.  
    CONFIG_CORRUPT              =   0x20 #  The outstation detected corrupt configuration. Support is optional.  
    RESERVED_2                  =   0x40 #  Reserved for future use.  
    RESERVED_1                  =   0x80 #  Reserved for future use.   



# \brief      Parameters in Command callback   - operation type 
class eOperationType(IntEnum):
    NUL         =   0      # None operation 
    PULSE_ON    =   1      # Pulse on 
    PULSE_OFF   =   2      # Pulse off 
    LATCH_ON    =   3      # Latch mode on 
    LATCH_OFF   =   4      # latch mode off 



# \brief		TCC - field in CROB -Command Data 
class eTripCloseCode(IntEnum):
  NULLL		  	=   0	  # NULL operation 
  CLOSE	  		=   1	  # CLOSE - on 
  TRIP  		=   2	  # trip - open 
  RESERVED	  	=   3	  # reserved - not used 
  


# \brief      Server Connection status
class eServerConnectionStatus(IntEnum):
    SERVER_NOTCONNECTED   		=   0    # server not connected 
    SERVER_CONNECTED       		=   1    # server connected, link layer 
    SERVER_STOPPED_BY_USER      =   2   # CLIENT multi server connect, user can stop communication for particular server, MULTDROP


# \brief      File type 
class eFileType(IntEnum): 
    DIRECTORY_TYPE   	=   0 # Directory 
    SIMPLE_FILE        	=   1 # simple file 


# \brief CROB, Analog Output Block - Command Variation -  Used in DNP3Select, DNP3Operate, DNP3SelectBeforeOperate, DNP3DirectOperate API function
class eCommandObjectVariation(IntEnum):
    CROB_G12V1                  	=   1  # Control relay output block - Group 12 - Variation 1  
    ANALOG_OUTPUT_BLOCK_INTEGER32 	=   2  # 32-bit signed integer analog output Group 41 - Variation 1         
    ANALOG_OUTPUT_BLOCK_INTEGER16 	=   3  # 16-bit signed integer analog output Group 41 - Variation 2  
    ANALOG_OUTPUT_BLOCK_FLOAT32		=   4  # Float analog output Group 41 - Variation 3  



# DNP3 Update function - mention which event class need to generate event 
class eUpdateClassID(IntEnum): 
	UPDATE_DEFAULT_EVENT					=	0  # 0- according to loadconfig, already defined class event group - event will be generated
	UPDATE_NO_CLASS                        	=   1  # 1 – Static data (current value), no events will be generated for this data
	UPDATE_CLASS_ONE                       	=   2  # 2 – Event classes, events will be generated for this data.
	UPDATE_CLASS_TWO                       	=   3  # 3 – Event classes, events will be generated for this data.
	UPDATE_CLASS_THREE                     	=   4  # 4 – Event classes, events will be generated for this data.



# DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input
class eAnalogStorageType(IntEnum):
	AS_FLOAT					=	0  # 0- default, it will store float value, as ieee 754 format 
	AS_INTEGER32                =   1  # 1 – integer32, it will store as i32 value - for Range : -2,147,483,648 to 2,147,483,647


# DNP3 Update function - mention which event class need to generate event 
class  eUpdateCause(IntEnum):
	STATIC_DATA 		= 0   # update callback caused by static data class 0 polled by client 
	POLLED_EVENT 		= 1   # update callback caused by event data class 123 polled by client 
	UNSOLICITED_EVENT 	= 2   # update callback caused by Unsolicited event data from Server 


# Data link layer confirmation  
class eLinkLayerConform(IntEnum):
	CONFORM_NEVER = 0	# Default - most of dnp3 devices support datalink confirmation - never
	CONFORM_ALWAYS = 1 # low end devices, and very nosiy environment - make more data transmission slow connection




# \brief  DNP3 Quality data type. (as specified in #eDNP3QualityFlags) 
#typedef Unsigned16 tDNP3Quality;

#  \brief      Dataset present value element Structure 
class sDatasetpsvalueeelement(ctypes.Structure):
    _fields_ = [
    ("u8Datasetvaluelength", ctypes.c_ubyte),  #  data set value length 
    ("au8Datasetvalue", ctypes.c_ubyte * 255)  #  data set value 
    ]

#  \brief      Dataset present  Structure 
class sDatasetPsvalue(ctypes.Structure):
    _fields_ = [
    ("u32ID",ctypes.c_uint32),                          # dataset identification number                    
    ("sTimeStamp",sTargetTimeStamp),         # struct sTargetTimeStamp - TimeStamp         
    ("u16Noofdatasetpseelement",ctypes.c_ushort),       # Total number of dataset element 
    ("psDatasetpsvalueeelement",ctypes.POINTER(sDatasetpsvalueeelement)) #  Pointer to struct sDatasetpsvalueeelement  
    ]


#  \brief   Client Dataset present  Structure 
class sClientDatasetPresentvalue(ctypes.Structure):
    _fields_ = [
    ("u32NoofDefinedDataSetDescriptor",ctypes.c_uint32),   # Total number of defined dataset descriptor          
    ("psDatasetPsvalue",ctypes.POINTER(sDatasetPsvalue))    #  pointer to struct sDatasetPsvalue Dataset present  Structure   
    ]

#  \brief   Dataset prototype element  Structure 
class sDatasetprototypeelement(ctypes.Structure):
    _fields_ = [
    ("u8Descriptorcode", ctypes.c_ubyte), # Descriptor code 
    ("u8Datatypecode", ctypes.c_ubyte),     # Data type code 
    ("u8Maxdatalength", ctypes.c_ubyte),        # max data length 
    ("u8Auxdatasetvaluelength", ctypes.c_ubyte),    # auxilary dataset value length 
    ("au8Auxdatasetvalue", ctypes.c_ubyte * 255) # auxilary dataset value array 
    ]

#  \brief   Dataset prototype Structure 
class sDatasetPrototype(ctypes.Structure): 
    _fields_ = [
    ("u16Noofdatasetprototypeelement",ctypes.c_ushort), # Number of dataset prototype element 
    ("psDatasetprototypeelement",ctypes.POINTER(sDatasetprototypeelement)) # pointer to struct sDatasetprototypeelement dataset prototype element structure 
    ]

#  \brief   Client Dataset prototype Structure 
class sClientDatasetPrototype(ctypes.Structure):
    _fields_ = [
    ("u32NoofDefinedDataSetPrototype",ctypes.c_uint32), # Number of defined dataset prototype             
    ("psDatasetPrototype",ctypes.POINTER(sDatasetPrototype)) # pointer to struct sDatasetPrototype dataset prototype  structure 
    ]



#  \brief      Ethernet Port Settings Structure 
class sEthernetPortSettings(ctypes.Structure): 
    _fields_ = [
        ("u16PortNumber",ctypes.c_ushort),                         # Port Number  
        ("ai8FromIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE),   # Local IP Address  only for dnp3 server udp
        ("ai8ToIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)     # Connect To IP Address only for dnp3 client udp
        
    ]

# \brief      Ethernet Communication Settings Structure 
class sEthernetCommunicationSettings(ctypes.Structure):
    _fields_ = [
        ("bServerUDPtransmitPortNumberdefault", ctypes.c_bool),             # in udp , server transmit default port number 20000, or in which port data received , server will transmit same port   
        ("sEthernetportSet", sEthernetPortSettings)     #  struct sEthernetPortSettings - pointer to struct ethernet port setting   
        
    ]


#  \brief      DNP3 Object Structure 
class sDNP3Object(ctypes.Structure):
    _fields_ = [
	("eGroupID",ctypes.c_int),                   # enum eDNP3GroupID - Group Identifcation see  
	("u16NoofPoints",ctypes.c_ushort),              # total number of points  , Intially index start with 0, if already some points included same group id , then index will increment min 1- 1000
	("eClassID",ctypes.c_int),                   # enum eDNP3ClassID - Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS
	("eControlModel",ctypes.c_int),              # enum eDNP3ControlModelConfig - Control Model specified in eControlModelFlags ,Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...
	("u32SBOTimeOut",ctypes.c_uint32),              # Select Before Operate Timeout  in milliseconds , for input points like BINARY_INPUT , must be 0, like for output points like binary output -> if control mode ->DIRECT_OPERATION  must be 0 else min 1000 - 20000
	("f32AnalogInputDeadband",ctypes.c_float),     # consider for analog input, other groups it must be zero, groupDeadband 0 permits any change in the analog input value to generate an event, and a deadband of the full range of the variable prevents generation of an event 
	("eAnalogStoreType",ctypes.c_int),			# enum eAnalogStorageType - DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input
	("ai8Name", ctypes.c_char * APP_OBJNAMESIZE)   # Name 
	
    ]

# \brief  DNP3 Debug Parameters 
class sDNP3DebugParameters(ctypes.Structure):
    _fields_ = [
	("u32DebugOptions",ctypes.c_uint32)                            # Debug Option see eDebugOptionsFlag 
    ]

#  \brief      static variation Structure  
class sDefaultStaticVariation(ctypes.Structure):  
    _fields_ = [
	("eDeStVarBI",ctypes.c_int),                             # enum eDefaultStaticVariationBinaryInput - Default Static variation Binary Input
	("eDeStVarDBI",ctypes.c_int),                            # enum eDefaultStaticVariationDoubleBitBinaryInput - Default Static variation Double Bit Binary Input
	("eDeStVarBO",ctypes.c_int),                             # enum eDefaultStaticVariationBinaryOutput - Default Static variation Binary Output
	("eDeStVarCI",ctypes.c_int),                             # enum eDefaultStaticVariationCounterInput - Default Static variation counter Input
	("eDeStVarFzCI",ctypes.c_int),                           # enum eDefaultStaticVariationFrozenCounterInput - Default Static variation Frozen counter Input
	("eDeStVarAI",ctypes.c_int),                             # enum eDefaultStaticVariationAnalogInput - Default Static variation Analog Input
	("eDeStVarFzAI",ctypes.c_int),                           # enum eDefaultStaticVariationFrozenAnalogInput - Default Static variation frozen Analog Input
	("eDeStVarAID",ctypes.c_int),                            # enum eDefaultStaticVariationAnalogInputDeadBand - Default Static variation Analog Input Deadband
	("eDeStVarAO",ctypes.c_int)                             # enum eDefaultStaticVariationAnalogOutput - Default Static variation Analog Output
	
    ]

#  \brief      event variation Structure 
class sDefaultEventVariation(ctypes.Structure):   
    _fields_ = [
	("eDeEvVarBI",ctypes.c_int),                             # enum eDefaultEventVariationBinaryInput - Default Event variation Binary Input
	("eDeEvVarDBI",ctypes.c_int),                            # enum eDefaultEventVariationDoubleBitBinaryInput -Default Event variation Double bit Binary Input
	("eDeEvVarCI",ctypes.c_int),                             # enum eDefaultEventVariationCounterInput - Default Event variation Counter Input
	("eDeEvVarAI",ctypes.c_int),                             # enum eDefaultEventVariationAnalogInput - Default Event variation Analog Input
	("eDeEvVarFzCI",ctypes.c_int),                           # enum eDefaultEventVariationFrozenCounterInput - Default Event variation Frozen Counter Input
	("eDeEvVarFzAI",ctypes.c_int),  							# enum eDefaultEventVariationFrozenAnalogInput - Default Event variation Frozen Analog Input
	("eDeEvVarBO",ctypes.c_int),   							# enum eDefaultEventVariationBinaryOutput - Default Event variation Binary Output
	("eDeEvVarAO",ctypes.c_int)								# enum eDefaultEventVariationAnalogOutput - Default Event variation Analog Output
    ]




#  \brief Unsolicited Response Settings 
class sUnsolicitedResponseSettings(ctypes.Structure):
    _fields_ = [
	("bEnableUnsolicited", ctypes.c_bool),             # enable to slave send unsolicited message
	("bEnableResponsesonStartup", ctypes.c_bool),      # enable to slave send unsolicited message on statup
	("u32Timeout",ctypes.c_uint32),                     # timeout in milliseconds for unsolicites response from master minimum 1000 max app layer timeout
	("u8Retries", ctypes.c_ubyte),                      # Unsolicited message retries default 5, min 1, max 10
	("u16MaxNumberofEvents",ctypes.c_ushort),           # each Unsolicited message contains max no of events minimum 1 -255
	("u16Class1TriggerNumberofEvents",ctypes.c_ushort),		# Class 1 Number of Class events to trigger the unsolicited response message , value should be  u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event 
	("u16Class1HoldTimeAfterResponse",ctypes.c_ushort),		# Class 1 after send the class unsoldiated message Hold Time in ms, 
	("u16Class2TriggerNumberofEvents",ctypes.c_ushort), 	# Class 2 Number of Class events to trigger the unsolicited response message , value should be  u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event 
	("u16Class2HoldTimeAfterResponse",ctypes.c_ushort), 	# Class 2 after send the class unsoldiated message Hold Time in ms, 
	("u16Class3TriggerNumberofEvents",ctypes.c_ushort), 	# Class 3 Number of Class events to trigger the unsolicited response message , value should be  u16ClassEventBufferSize if it is 0, unsoltiated will not trigger from class event 
	("u16Class3HoldTimeAfterResponse",ctypes.c_ushort) 	# Class 3 after send the class unsoldiated message Hold Time in ms, 

    ]

#  \brief Server Device attribute paramaeters  

class sDeviceAttributes(ctypes.Structure):
    _fields_ = [		
	("ai8HW_VERSION", ctypes.c_char * 32),	# G00 v243 Device Attributes - Device Manufacturers HW Version - Min 3- 32 char 
	("ai8LOCATION", ctypes.c_char * 32),	# G00 V245 Device Attributes - User-Assigned Location - Min 3- 32 char 
	("ai8ID_CODE", ctypes.c_char * 32), 	# G00 V246 Device Attributes - User-Assigned ID code/number- Min 3- 32 char 
	("ai8DEVICE_NAME", ctypes.c_char * 32), # G00 V247 Device Attributes - User-Assigned Device Name- Min 3- 32 char 
	("ai8SERIAL_NUMBER", ctypes.c_char * 32),	# G00 V248 Device Attributes - Device Serial Number- Min 3- 32 char 
	("ai8PRODUCTNAME_MODEL", ctypes.c_char * 32),	# G00 V250 Device Attributes - Device Product Name and Model 
	("ai8MANUFACTURE_NAME", ctypes.c_char * 32)# G00 V252 Device Attributes - Device Manufacturers Name 		
	
    ]



#  \brief Server Communication Settings    
class sServerCommunicationSettings(ctypes.Structure): 
    _fields_ = [
	("eCommMode",ctypes.c_int),                                          # enum  eCommunicationMode - Communication Mode serial /TCP_IP/UDP 
	("sEthernetCommsSet",sEthernetCommunicationSettings),       # struct sEthernetCommunicationSettings - Ethernet Communcation Settings 
	("sSerialSet",sSerialCommunicationSettings)               # struct sSerialCommunicationSettings - pointer to struct sSerialCommunicationSettings  
	
    ]

#  \brief sServer Protocol Settings    
class sServerProtocolSettings(ctypes.Structure): 
    _fields_ = [
	("u16SlaveAddress",ctypes.c_ushort),                                    # Slave address range 0 to 65519 
	("u32LinkLayerTimeout",ctypes.c_uint32),                                # Link layer time out in milliSeconds (minimum 1000ms - to max)
	("u32ApplicationLayerTimeout",ctypes.c_uint32),                         # application layer timeout in millisecond 5 * Linklayer timeout                     
	("u16MasterAddress",ctypes.c_ushort),                                   # Master address range 0 to 65519 for unsolicited response
	("sUnsolicitedResponseSet",sUnsolicitedResponseSettings),               # struct sUnsolicitedResponseSettings - Unsolicited response settings 
	("u32TimeSyncIntervalSeconds",ctypes.c_uint32),                         # in Seconds, 0 to 3600s (1 hour)             
	("sStaticVariation",sDefaultStaticVariation),                           # struct sDefaultStaticVariation - default static variation structure 
	("sEventVariation",sDefaultEventVariation),                             # struct sDefaultEventVariation - default event variation structure  
	("sTimeStamp",sTargetTimeStamp),                                         # struct sTargetTimeStamp - TimeStamp @ load config
	("bAddBIinClass0", ctypes.c_bool),                                     # add Binary Input in class 0 request
	("bAddDBIinClass0", ctypes.c_bool),                                    # add Double Binary Input in class 0 request
	("bAddBOinClass0", ctypes.c_bool),                                     # add Binary Output in class 0 request
	("bAddCIinClass0", ctypes.c_bool),                                     # add Counter Input in class 0 request
	("bAddFzCIinClass0", ctypes.c_bool),                                   # add Frozen Counter Input in class 0 request
	("bAddAIinClass0", ctypes.c_bool),                                     # add Analog Input in class 0 request
	("bAddFzAIinClass0", ctypes.c_bool),                                   # add Frozen Analog Input in class 0 request
	("bAddAIDinClass0", ctypes.c_bool),                                    # add Analog Input Deadband in class 0 request
	("bAddAOinClass0", ctypes.c_bool),                                     # add Analog Output in class 0 request
	("bAddOSinClass0", ctypes.c_bool),                                     # add Octect String in class 0 request            
	("bAddBIEvent", ctypes.c_bool),                                        # add Binary Input Event in class 1,2,3 request
	("bAddDBIEvent", ctypes.c_bool),                                       # add Double Bit Binary Input Event in class 1,2,3 request
	("bAddBOEvent", ctypes.c_bool),                                        # add Binary Output Event in class 1,2,3 request
	("bAddCIEvent", ctypes.c_bool),                                        # add Counter Input Event in class 1,2,3 request
	("bAddFzCIEvent", ctypes.c_bool),                                      # add Frozen Counter Input Event in class 1,2,3 request
	("bAddAIEvent", ctypes.c_bool),                                        # add Analog Input Event in class 1,2,3 request
	("bAddFzAIEvent", ctypes.c_bool),                                      # add Frozen Analog Input Event in class 1,2,3 request
	("bAddAIDEvent", ctypes.c_bool),                                       # add Analog  Input Deadband Event in class 1,2,3 request
	("bAddAOEvent", ctypes.c_bool),                                        # add Analog Output Event in class 1,2,3 request
	("bAddOSEvent", ctypes.c_bool),                                        # add Octect String Event in class 1,2,3 request
	("bAddVTOEvent", ctypes.c_bool),                                       # add Vitual termianal output Event in class 1,2,3 request
	("eAIDeadbandMethod",ctypes.c_int),                                  # enum   eAnalogInputDeadbandMethod - Analog Input Deadband Calculation method
	("bFrozenAnalogInputSupport", ctypes.c_bool),                          # False- stack will not create points for frozen analog input.            
	("bEnableSelfAddressSupport", ctypes.c_bool),          				# Enable Self Address Support 
	("bEnableFileTransferSupport", ctypes.c_bool),         				# Enable File Transfr Support
	("u8IntialdatabaseQualityFlag", ctypes.c_ubyte), 						# 0- OFFLINE, 1 BIT- ONLINE, 2 BIT-RESTART, 3 BIT -COMMLOST, MAX VALUE -7   
	("bLocalMode", ctypes.c_bool),  										# if local mode set true, then -all remote command for binary output/ analog output   control statusset to not supported 
	("bUpdateCheckTimestamp", ctypes.c_bool), 								# if it true ,the timestamp change also generate event  during the dnp3update   
	("u16Class1EventBufferSize",ctypes.c_ushort),                        # Class 1 EventBufferSize - no of events to hold minimum 50
	("u8Class1EventBufferOverFlowPercentage", ctypes.c_ubyte),           # Class 1 buffer overflow percentage 50 to 95
	("u16Class2EventBufferSize",ctypes.c_ushort),                        # Class 2 EventBufferSize - no of events to hold minimum 50
	("u8Class2EventBufferOverFlowPercentage", ctypes.c_ubyte),           # Class 2 buffer overflow percentage 50 to 95
	("u16Class3EventBufferSize",ctypes.c_ushort),                        # Class 3 EventBufferSize - no of events to hold minimum 50
	("u8Class3EventBufferOverFlowPercentage", ctypes.c_ubyte),           # Class 3 buffer overflow percentage 50 to 95
	("sConfigureDeviceAttributes",sDeviceAttributes)						#struct sDeviceAttributes - configurable device attributes
	  
    ]

 #  \brief sServer Protocol Settings   
class sDNP3ServerSettings(ctypes.Structure): 
    _fields_ = [
	("sServerCommunicationSet",sServerCommunicationSettings),                            # struct sServerCommunicationSettings - serial communication settings 
	("sDebug",sDNP3DebugParameters),                                             # struct sDNP3DebugParameters - Debug options settings on loading the configuarion See struct sDNP3DebugParameters 
	("sServerProtSet",sServerProtocolSettings),                                     # struct sServerProtocolSettings - Server protocol settings
	("u16NoofObject",ctypes.c_ushort),                                       # Total number of DNP3 Objects min 1, max 6000
	("benabaleUTCtime", ctypes.c_bool),                                    # enable utc time/ local time 
	("psDNP3Objects",ctypes.POINTER(sDNP3Object))                                     # Pointer to struct sDNP3Object - strcuture DNP3 Objects 
	
    ]

#  \brief Client Communication Settings   
class sClientCommunicationSettings(ctypes.Structure): 
    _fields_ = [
	("sSerialSet",sSerialCommunicationSettings),                                         # struct sSerialCommunicationSettings - Serial communication settings 
	("sEthernetCommsSet",sEthernetPortSettings)                                  # struct sEthernetPortSettings - Ethernet Communcation Settings 
    ]

#  \brief Client Protocol Settings   
class sClientProtocolSettings(ctypes.Structure): 
    _fields_ = [
	("u16MasterAddress",ctypes.c_ushort),                                   # Master address range 0 to 65519 for unsolicited response       
	("u16SlaveAddress",ctypes.c_ushort),                                    # Slave address range 0 to 65519 
	("u32LinkLayerTimeout",ctypes.c_uint32),                               # Link layer time out in milliSeconds (minimum 1000ms - to max)
	("u32ApplicationTimeout",ctypes.c_uint32),                              # Application layer timeout in millisecond 5 * Linklayer timeout       
	("u32Class123pollInterval",ctypes.c_uint32),                            #CLASS 123 poll interval in milliSeconds (minimum 1000ms - to max)
	("u32Class0123pollInterval",ctypes.c_uint32),                           #CLASS 0123 poll interval in milliSeconds (minimum 1000ms - to max)
	("u32Class0pollInterval",ctypes.c_uint32),                              #CLASS 0 poll interval in milliSeconds (minimum 1000ms - to max)
	("u32Class1pollInterval",ctypes.c_uint32),                              #CLASS 1 poll interval in milliSeconds (minimum 1000ms - to max)
	("u32Class2pollInterval",ctypes.c_uint32),                              #CLASS 2 poll interval in milliSeconds (minimum 1000ms - to max)
	("u32Class3pollInterval",ctypes.c_uint32),                              #CLASS 3 poll interval in milliSeconds (minimum 1000ms - to max)
	("bDisableUnsolicitedStatup", ctypes.c_bool),                          #true- send disable unsolicited command at start up
	("bFrozenAnalogInputSupport", ctypes.c_bool),                          #False- stack will not create points for frozen analog input.
	("bEnableFileTransferSupport", ctypes.c_bool),                         #Enable file transfer
	("bDisableResetofRemotelink", ctypes.c_bool),                      	# if it true ,client will not send the reset of remote link in startup
	("eLinkConform",ctypes.c_int)										# enum eLinkLayerConform - Data link layer confirmation default - CONFORM_NEVER
	
    ]

# \brief      DNP3 Object Structure 
class sDNP3clObject(ctypes.Structure):
    _fields_ = [
	("u16StartingIndexAddress",ctypes.c_ushort),    # Starting index number 
	("u16NoofPoints",ctypes.c_ushort),              # total number of points , Intially index start with 0, if already some points included same group id , then index will increment            
	("eGroupID",ctypes.c_int),                   # enum eDNP3GroupID - Group Identifcation 
	("eClassID",ctypes.c_int),                   # enum eDNP3ClassID - Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS
	("eControlModel",ctypes.c_int),              # enum eDNP3ControlModelConfig - Control Model specified in eControlModelFlags ,Status Only  for input points like BINARY_INPUT, DOUBLE_INPUT...
	("u32SBOTimeOut",ctypes.c_uint32),              # Select Before Operate Timeout  in milliseconds , for input points like BINARY_INPUT , must be 0, like for output points like binary output -> if control mode ->DIRECT_OPERATION  must be 0
	("f32AnalogInputDeadband",ctypes.c_float),     # consider for analog input, other groups it must be zero, groupDeadband 0 permits any change in the analog input value to generate an event, and a deadband of the full range of the variable prevents generation of an event 
	("eAnalogStoreType",ctypes.c_int),			# enum eAnalogStorageType -DNP3 load analog point setting - the analog point storage type in stack internal database - applicable to analog input, analog output, frozen analog input
	("ai8Name", ctypes.c_char * APP_OBJNAMESIZE)   # Object Name             
    ]       
	

# \brief      Client object structure  
class sClientObject(ctypes.Structure):
    _fields_ = [
	("eCommMode",ctypes.c_int),                                          # enum  eCommunicationMode -Communication Mode serial /tcp 
	("sClientCommunicationSet",sClientCommunicationSettings),    # struct sClientCommunicationSettings - Client communication settings            
	("sClientProtSet",sClientProtocolSettings),             # struct sClientProtocolSettings - Client protocol settings         
	("u32CommandTimeout",ctypes.c_uint32),                                  # Command timout in milliseconds, minimum 3000 
	("u32FileOperationTimeout",ctypes.c_uint32),                            # file read/write timout in milliseconds, minimum 10000 
	("u16NoofObject",ctypes.c_ushort),                                       # Total number of DNP3 Objects 1- 6000
	("psDNP3Objects",ctypes.POINTER(sDNP3clObject))                                     # Pointer to struct sDNP3clObject - strcuture DNP3 Objects             
    ]

# \brief      Client settings  
class  sDNP3ClientSettings(ctypes.Structure):
    _fields_ = [

	("bAutoGenDNP3DataObjects", ctypes.c_bool),                      		# if it true ,the DNP3 Objects created automaticallay, use u16NoofObject = 0, psClientObjects = NULL
	("u16UpdateBuffersize",ctypes.c_ushort),								# if bAutoGenDNP3DataObjects true, update callback buffersize, approx 3 * max count of monitoring points in the server 		
	("sDebug",sDNP3DebugParameters),                     # struct sDNP3DebugParameters - Debug options settings on loading the configuarion See struct sDNP3DebugParameters           
	("sTimeStamp",sTargetTimeStamp),                                         # struct sTargetTimeStamp - TimeStamp @ load config
	("benabaleUTCtime", ctypes.c_bool),									# enable utc time/ local time 
	("bUpdateCallbackCheckTimestamp", ctypes.c_bool), 						# if it true ,the timestamp change also create the updatecallback 
	("u16NoofClient",ctypes.c_ushort),                                     # Total number of client Objects 
	("psClientObjects",ctypes.POINTER(sClientObject))                                   # struct sClientObject - Pointer to strcuture sClientObject             
]


# \brief    DNP3 Configuration parameters 
class sDNP3ConfigurationParameters(ctypes.Structure):
    _fields_ = [   
	("sDNP3ServerSet",sDNP3ServerSettings),                         # struct sDNP3ServerSettings - DNP3 Server settings
	("sDNP3ClientSet",sDNP3ClientSettings)                         # struct sDNP3ClientSettings  - DNP3 Client settings
]



 # \brief      This structure hold the identification of a DNP3 Data Attribute 
class sDNP3DataAttributeID(ctypes.Structure):
    _fields_ = [
	("eCommMode",ctypes.c_int),                           # enum  eCommunicationMode - Communication Mode serial /tcp 
	("u16SerialPortNumber",ctypes.c_ushort),                 # Serial COM port number
	("u16PortNumber",ctypes.c_ushort),                      # tcp/udp port number 
	("u16SlaveAddress",ctypes.c_ushort),                    # slave address range 0 to 65519 
	("eGroupID",ctypes.c_int),                           # enum eDNP3GroupID - Group Identifcation see  
	("u16IndexNumber",ctypes.c_ushort),                     # object index number            
	("pvUserData",ctypes.c_void_p),   # Application specific User Data 
	("ai8IPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)     # Connect To IP Address only for dnp3 client udp            
 ]

# \brief      A Data object structure. Used to exchange data objects between DNP3 object and application. 
class sDNP3DataAttributeData(ctypes.Structure):
    _fields_ = [
	("sTimeStamp",sTargetTimeStamp),                # struct sTargetTimeStamp - TimeStamp 
	("tQuality",ctypes.c_ushort),           # Quality of Data see eDNP3QualityFlags 
	("eDataType",ctypes.c_int),          # enum    eDataTypes Data Type 
	("eDataSize",ctypes.c_int),          # enum    eDataSizes Data Size 
	("eTimeQuality",ctypes.c_int), # enum eTimeQualityFlags - time quality 
	("pvData",ctypes.c_void_p)            # Pointer to Data  
]


# \brief  DNP3 File Attribute Data Structure     
class sDNP3FileAttributeData(ctypes.Structure):
    _fields_ = [
	#file related
	("ai8sourceFile", ctypes.c_char * MAX_LICENSE_PATH),        # source file name    
	("ai8DestinationFile", ctypes.c_char * MAX_LICENSE_PATH)        # destination file                        
]


# \brief  DNP3 File Descriptor Structure     
class sFileDescriptor(ctypes.Structure):
    _fields_ = [
	("u16FileNameOffset",ctypes.c_ushort),               # File Name offset 
	("u16Filenamesize",ctypes.c_ushort),                 # File Name Size 
	("eFltype",ctypes.c_int),            # enum       eFileType - File type- directory/ file 
	("u32Filesize",ctypes.c_uint32),                    # file size 
	("u16Permissions",ctypes.c_ushort),                 # user permission read, write 
	("u16RequestID",ctypes.c_ushort),                   # request id 
	("sTimeStamp",sTargetTimeStamp),                # struct sTargetTimeStamp - TimeStamp 
	("ai8Filename", ctypes.c_char * MAX_LICENSE_PATH)    # File Name             
]

# \brief  DNP3 Directory attribute Structure     
class sDNP3DirAttributeData(ctypes.Structure):
    _fields_ = [
	("u16TotalNumberofFiles",ctypes.c_ushort),                          	# Number of files in the directory                     
	("psFileDescriptor",ctypes.POINTER(sFileDescriptor)),                          	# pointer to struct sFileDescriptor - File Descriptor Structure 
	("ai8DestinationDirPath", ctypes.c_char * MAX_LICENSE_PATH)        	# directory Path             
]


 # \brief      Parameters provided by Command callback   
class sDNP3CommandParameters(ctypes.Structure):
    _fields_ = [   
	("eCommandVariation",ctypes.c_int), # enum eCommandObjectVariation -command variation
	("eOPType",ctypes.c_int),   # enum eOperationType - operation type 
	("u8Count", ctypes.c_ubyte),            # operation - number of types 
	("u32ONtime",ctypes.c_uint32),          # On Time in Milli Seconds 
	("u32OFFtime",ctypes.c_uint32),         # Off Time in Milli Seconds 
	("bCR", ctypes.c_bool)  				# Clear field 
]

 

 # \brief      Parameters provided by write callback   
class sDNP3WriteParameters(ctypes.Structure):
    _fields_ = [
	("u8Dummy", ctypes.c_ubyte)                # Dummy only for future expansion purpose 
]

  # \brief      Parameters provided by read callback   
class sDNP3ReadParameters(ctypes.Structure):
    _fields_ = [
	("u8Dummy", ctypes.c_ubyte)                # Dummy only for future expansion purpose 
]

  
# \brief      Parameters provided by update callback   
class sDNP3UpdateParameters(ctypes.Structure):
    _fields_ = [
	("u8Group", ctypes.c_ubyte),  				# Reported group number from  dnp3 server 
	("u8Variation", ctypes.c_ubyte),			# reported Variation number from  dnp3 server
	("eUpCause",ctypes.c_int) # enum        eUpdateCause - reported cause - static / polled event / unsolicited event            
]


# \brief  DNP3 Debug Callback Data Structure
class sDNP3DebugData(ctypes.Structure):
    _fields_ = [
	("u32DebugOptions",ctypes.c_uint32),                            # Debug Option see eDebugOptionsFlag 
	("i16ErrorCode",ctypes.c_short),                                # error code if any 
	("tErrorValue",ctypes.c_short),                                # error value if any
	("eCommMode",ctypes.c_int),                                  #enum  eCommunicationMode -  Communication Mode serial /tcp 
	("u16ComportNumber",ctypes.c_ushort),                           # serial com port number for transmit & receive 
	("u16RxCount",ctypes.c_ushort),                                 # Received data count
	("u16TxCount",ctypes.c_ushort),                                 # Transmitted data count 
	("u16PortNumber",ctypes.c_ushort),                              # Port Number  
	("au8RxData", ctypes.c_ubyte * DNP3_MAX_RX_MESSAGE),             # Received data from master 
	("au8TxData", ctypes.c_ubyte * DNP3_MAX_TX_MESSAGE),             # Transmitted data from master 
	("au8ErrorMessage", ctypes.c_ubyte * MAX_ERROR_MESSAGE),         # error message 
	("au8WarningMessage", ctypes.c_ubyte * MAX_WARNING_MESSAGE),     # warning message 
	("ai8IPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)            # tcp, udp ip address 
]


# \brief  DNP3 Server Database Point Structure
class sServerDatabasePoint(ctypes.Structure):
    _fields_ = [
	("eGroupID",ctypes.c_int),                   # enum eDNP3GroupID - Group Identifcation see  
	("u16IndexNumber",ctypes.c_ushort),            # Index number  
	("eDataType",ctypes.c_int),                  # enum eDataTypes - Data Type 
	("eDataSize",ctypes.c_int),                  # enum eDataSizes - Data Size 
	("tQuality",ctypes.c_ushort),                  # Quality of Data see eDNP3QualityFlags 
	("sTimeStamp",sTargetTimeStamp),                # struct sTargetTimeStamp - TimeStamp 
	("pvData",ctypes.c_void_p)            # Pointer to Data           
]

# \brief  DNP3 Server Database Structure
class sDNPServerDatabase(ctypes.Structure): 
    _fields_ = [
	("u32TotalPoints",ctypes.c_uint32),                      # Total number of points  
	("psServerDatabasePoint",ctypes.POINTER(sServerDatabasePoint))  # Pointer to struct sServerDatabasePoint DNP3 Server Database Point Structure 
]

# \brief  DNP3 Client Database Point Structure
class sClientDatabasePoint(ctypes.Structure):
    _fields_ = [           
	("eCommMode",ctypes.c_int),                     # enum  eCommunicationMode - Communication Mode serial /tcp 
	("u16SerialPortNumber",ctypes.c_ushort),           # Serial COM port number
	("u16PortNumber",ctypes.c_ushort),                          # TCP, UDP port number
	("u16SlaveAddress",ctypes.c_ushort),                        # slave address range 0 to 65519            
	("eGroupID",ctypes.c_int),                               # enum eDNP3GroupID - Group Identifcation see 
	("eDataType",ctypes.c_int),                              # enum eDataTypes - Data Type 
	("eDataSize",ctypes.c_int),                              # enum eDataSizes - Data Size             
	("u16IndexNumber",ctypes.c_ushort),                         # Index number              
	("eClassID",ctypes.c_int),                               #  enum eDNP3ClassID - Events report in class - see Class Identication List , for output points ex- binary output class must be NO_CLASS
	("tQuality",ctypes.c_ushort),                               # Quality of Data see eDNP3QualityFlags 
	("sTimeStamp", sTargetTimeStamp),                             # struct sTargetTimeStamp - TimeStamp 
	("pvData",ctypes.c_void_p),            # Pointer to Data 
	("ai8IPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)        # Connect To IP Address only for dnp3 client udp            
]

# \brief  DNP3 Client Database Structure
class sDNPClientDatabase(ctypes.Structure): 
    _fields_ = [
	("u32TotalPoints",ctypes.c_uint32),                     # Total number of points  
	("psClientDatabasePoint",ctypes.POINTER(sClientDatabasePoint)) # pointer to struct sClientDatabasePoint - DNP3 Client Database Point Structure 
]

# \brief  DNP3 Device Attribute Data Structure
class sDNP3DeviceAttributeData(ctypes.Structure):
    _fields_ = [
		("u8Variation", ctypes.c_ubyte),        # Variastion 
		("u8Datatype", ctypes.c_ubyte),         # Datatype 
		("u16Length",ctypes.c_ushort),          # length of data
		("u8Data", ctypes.c_ubyte * 512)        # Data array
]

# \brief error code more description 
class sDNP3ErrorCode(ctypes.Structure):
    _fields_ = [
	 ("iErrorCode", ctypes.c_short),      # errorcode    
	 ("shortDes",ctypes.c_char_p),       # error code short description
	 ("LongDes",ctypes.c_char_p)        # error code brief description
]


# \brief error value more description 
class sDNP3ErrorValue(ctypes.Structure):
    _fields_ = [
	 ("iErrorValue", ctypes.c_short),     # errorvalue 
	 ("shortDes",ctypes.c_char_p),       # error code short description
	 ("LongDes",ctypes.c_char_p)        # error code brief description
]





 # Forward Declaration of struct
class sDNP3AppObject(ctypes.Structure):
    pass

# \brief  Pointer to a IEC 101 object 
DNP3Object = ctypes.POINTER(sDNP3AppObject)
	
tErrorValue = ctypes.c_short
ptErrorValue= ctypes.POINTER(tErrorValue)
	
iErrorCode = ctypes.c_short
	
u16ObjectId = ctypes.c_ushort




# \brief  Command Read CallBack 
#typedef Integer16 (*)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptReadID, struct sDNP3DataAttributeData * ptReadValue, struct sDNP3ReadParameters *ptReadParams, tErrorValue *ptErrorValue );
DNP3ReadCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3ReadParameters),  ptErrorValue )

# \brief  Command Write CallBack 
#typedef Integer16 (*)(Unsigned16 u16ObjectId, enum eWriteFunctionID eFunctionID, struct sDNP3DataAttributeID * ptWriteID, struct sDNP3DataAttributeData * ptWriteValue,struct sDNP3WriteParameters *ptWriteParams, tErrorValue *ptErrorValue);
eFunctionID = ctypes.c_int
DNP3WriteCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, eFunctionID, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3WriteParameters), ptErrorValue )

# \brief  Command Update CallBack 
#typedef Integer16 (*DNP3UpdateCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, struct sDNP3DataAttributeData * ptUpdateValue,struct sDNP3UpdateParameters *ptUpdateParams, tErrorValue *ptErrorValue);
DNP3UpdateCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId,  ctypes.POINTER(sDNP3DataAttributeID),  ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3UpdateParameters), ptErrorValue )

# \brief  Command Update Internal Indication Bit 1 CallBack 

#typedef Integer16 (*)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, Unsigned8 u8IIN1, Unsigned8 u8IIN2, tErrorValue *ptErrorValue);
u8IIN1 = ctypes.c_ubyte
u8IIN2 = ctypes.c_ubyte
DNP3UpdateIINCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), u8IIN1, u8IIN2, ptErrorValue )

# \brief  Client Poll Status for a particular CallBack 
#typedef Integer16 (*)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * ptUpdateID, enum eWriteFunctionID eFunctionID, tErrorValue *ptErrorValue);
eFunctionID = ctypes.c_int
DNP3ClientPollStatusCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), eFunctionID, ptErrorValue )
'''

# \brief  Command Select CallBack 
# \brief  Select command success return error code 0 - EC_NONE and *ptErrorValue = EV_NONE, 
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

'''        
#typedef Integer16 (*DNP3ControlSelectCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psSelectID, struct sDNP3DataAttributeData * psSelectValue,struct sDNP3CommandParameters *psSelectParams, tErrorValue *ptErrorValue);
DNP3ControlSelectCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ptErrorValue )
'''
# \brief  Command Operate CallBack 
# \brief  Operate command success return error code 0 - EC_NONE and *ptErrorValue = EV_NONE, 
#    else return errorcode = APP_ERROR_OPERATE_FAILED and for *ptErrorValue the following values accepted 
	
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

'''        
#typedef Integer16 (*DNP3ControlOperateCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psOperateID, struct sDNP3DataAttributeData * psOperateValue,struct sDNP3CommandParameters *psOperateParams, tErrorValue *ptErrorValue);
DNP3ControlOperateCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DataAttributeData), ctypes.POINTER(sDNP3CommandParameters), ptErrorValue )



# \brief  Debug Message CallBack 
#typedef Integer16 (*DNP3DebugMessageCallback)(Unsigned16 u16ObjectId, struct sDNP3DebugData * psDebugData, tErrorValue *ptErrorValue);
DNP3DebugMessageCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DebugData), ptErrorValue )

# \brief  Client connection status CallBack 
eSat = ctypes.c_int
peSat= ctypes.POINTER(eSat)
#typedef Integer16 (*DNP3ClientStatusCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID, enum eServerConnectionStatus *peSat, tErrorValue *ptErrorValue);
DNP3ClientStatusCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), peSat,  ptErrorValue )

# \brief  Server cold restart CallBack 
#typedef Integer16 (*DNP3ColdRestartCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID,  tErrorValue *ptErrorValue);
DNP3ColdRestartCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), ptErrorValue )

# \brief  Server warm restart CallBack 
#typedef Integer16 (*DNP3WarmRestartCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID,  tErrorValue *ptErrorValue);
DNP3WarmRestartCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), ptErrorValue )

# \brief  device attribute CallBack 
#typedef Integer16 (*DNP3DeviceAttributeCallback)(Unsigned16 u16ObjectId, struct sDNP3DataAttributeID * psDAID, struct sDNP3DeviceAttributeData * psDeviceAttrValue,  tErrorValue *ptErrorValue); 
DNP3DeviceAttributeCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sDNP3DataAttributeID), ctypes.POINTER(sDNP3DeviceAttributeData), ptErrorValue )


# \brief      Create Server/client parameters structure  
class sDNP3Parameters(ctypes.Structure):
    _fields_ = [
	("eAppFlag",ctypes.c_int),                 # enum eApplicationFlag -Flag set to indicate the type of application 
	("u32Options",ctypes.c_uint32),               # Options flag, used to set client/server global options see #eDNP3ApplicationOptionFlag for values 
	("u16ObjectId",ctypes.c_ushort),              #  user idenfication will be retured in the callback for dnp3object identification
	("ptReadCallback",DNP3ReadCallback),           # Read callback function. If equal to NULL then callback is not used. 
	("ptWriteCallback",DNP3WriteCallback),          # Write callback function. If equal to NULL then callback is not used. 
	("ptUpdateCallback",DNP3UpdateCallback),         # Update callback function. If equal to NULL then callback is not used. 
	("ptSelectCallback",DNP3ControlSelectCallback),         # Function called when a Select Command  is executed.  If equal to NULL then callback is not used
	("ptOperateCallback",DNP3ControlOperateCallback),        # Function called when a Operate command is executed.  If equal to NULL then callback is not used 
	("ptDebugCallback",DNP3DebugMessageCallback),          # Function called when debug options are set. If equal to NULL then callback is not used 
	("ptUpdateIINCallback",DNP3UpdateIINCallback),      # Function called when IIN 1 byte changed. If equal to NULL then callback is not used 
	("ptClientPollStatusCallback",DNP3ClientPollStatusCallback),# Function called when Client Compteated Poll operation for particular Server. If equal to NULL then callback is not used 
	("ptClientStatusCallback",DNP3ClientStatusCallback),   # Function called when client Connection status changed 
	("ptColdRestartCallback",DNP3ColdRestartCallback),    # Function called when a cold restart Command is executed.  If equal to NULL then callback is not used
	("ptWarmRestartCallback",DNP3WarmRestartCallback),    # Function called when a warm restart Command is executed.  If equal to NULL then callback is not used
	("ptDeviceAttrCallback",DNP3DeviceAttributeCallback)            # Device Attribute callback function. If equal to NULL then callback is not used. 
]



