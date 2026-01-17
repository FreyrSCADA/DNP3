import ctypes 
import time
import struct
import sys
import keyboard
from dnp3protocol.dnp3api import *

# if SERVER_TCP_COMMUNICATION enabled tcp works else serial communication works 
SERVER_TCP_COMMUNICATION  = 1

# enbale to view traffic
VIEW_TRAFFIC = 1

SERIAL_PORT_NUMBER  = 1

# print error code and description
def errorcodestring(errorcode):
    sDNP3ErrorCodeDes = sDNP3ErrorCode()
    sDNP3ErrorCodeDes.iErrorCode = errorcode
    dnp3_lib.DNP3ErrorCodeString(sDNP3ErrorCodeDes)
    return sDNP3ErrorCodeDes.LongDes.decode("utf-8")

# print error value and description
def errorvaluestring(errorvalue):
    sDNP3ErrorValueDes = sDNP3ErrorValue()
    sDNP3ErrorValueDes.iErrorValue = errorvalue   
    dnp3_lib.DNP3ErrorValueString(sDNP3ErrorValueDes)
    return sDNP3ErrorValueDes.LongDes.decode("utf-8")
  
# dnp3 cold restart callback
def cbColdRestart(u16ObjectId, ptWriteID,  ptErrorValue):

    i16ErrorCode = ctypes.c_short()
    i16ErrorCode = 0   

    print(" cbColdRestart() called")
    print(" Server ID : %u" % u16ObjectId)


    if ptWriteID.contents.eCommMode    ==  eCommunicationMode.COMM_SERIAL:    
        print("Serial Port %u"% ptWriteID.contents.u16SerialPortNumber)    
    else :    
        print("IP Address %s" % ptWriteID.contents.ai8IPAddress)
        print("\tPort %u" % ptWriteID.contents.u16PortNumber)

    return i16ErrorCode

# dnp3 write callback
def cbWrite(u16ObjectId, eFunctionID, ptWriteID, ptWriteValue, ptWriteParams, ptErrorValue):

    i16ErrorCode = ctypes.c_short()
    i16ErrorCode = 0   

    print(" cbWrite() called")
    print(" Server ID : %u" % u16ObjectId)


    if ptWriteID.contents.eCommMode    ==  eCommunicationMode.COMM_SERIAL:    
        print("Serial Port %u"% ptWriteID.contents.u16SerialPortNumber)    
    else :    
        print("IP Address %s" % ptWriteID.contents.ai8IPAddress)
        print("\tPort %u" % ptWriteID.contents.u16PortNumber)



    if ptWriteValue.contents.sTimeStamp.u16Year != 0:
        print(f" Date : {ptWriteValue.contents.sTimeStamp.u8Day:02}-{ptWriteValue.contents.sTimeStamp.u8Month:02}-{ptWriteValue.contents.sTimeStamp.u16Year:04}  DOW -{ptWriteValue.contents.sTimeStamp.u8DayoftheWeek}")
        print(f" Time : {ptWriteValue.contents.sTimeStamp.u8Hour:02}:{ptWriteValue.contents.sTimeStamp.u8Minute:02}:{ptWriteValue.contents.sTimeStamp.u8Seconds:02}:{ptWriteValue.contents.sTimeStamp.u16MilliSeconds:03}")

    return i16ErrorCode

# dnp3 warm restart callback
def cbWarmRestart(u16ObjectId, ptWriteID, ptErrorValue):

    i16ErrorCode = ctypes.c_short()
    i16ErrorCode = 0   

    print(" cbWarmRestart() called")

    print(" Server ID : %u" % u16ObjectId)


    if ptWriteID.contents.eCommMode    ==  eCommunicationMode.COMM_SERIAL:    
        print("Serial Port %u"% ptWriteID.contents.u16SerialPortNumber)    
    else :    
        print("IP Address %s" % ptWriteID.contents.ai8IPAddress)
        print("\tPort %u" % ptWriteID.contents.u16PortNumber)

    return i16ErrorCode

# dnp3 select callback
def cbSelect(u16ObjectId, psSelectID, psSelectValue, psSelectParams,ptErrorValue):

    i16ErrorCode = ctypes.c_short()
    i16ErrorCode = 0   

    print("************cbSelect() called*****************")
    print(" Server ID : %u" % u16ObjectId)

    if psSelectID.contents.eCommMode    ==  eCommunicationMode.COMM_SERIAL:    
        print("Serial Port %u"% psSelectID.contents.u16SerialPortNumber)    
    else :    
        print("IP Address %s" % psSelectID.contents.ai8IPAddress)
        print("\tPort %u" % psSelectID.contents.u16PortNumber)

    if psSelectID.contents.eGroupID ==  eDNP3GroupID.ANALOG_OUTPUTS :
    
        print("GROUP ID : ANALOG_OUTPUT")
        print("Index Number %u"% psSelectID.contents.u16IndexNumber)

        if psSelectParams.contents.eCommandVariation == eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_FLOAT32 :		
            data = bytearray(ctypes.string_at(psSelectValue.contents.pvData, 4))
            f32data = struct.unpack('f', data)[0] 
            print(f" Data : {f32data:.3f}")

        elif psSelectParams.contents.eCommandVariation == eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER32:      
            data = bytearray(ctypes.string_at(psSelectValue.contents.pvData, 4))
            i32data = struct.unpack('i', data)[0]        
            print(f" Data : {i32data}")

        elif psSelectParams.contents.eCommandVariation == eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER16:
            data = bytearray(ctypes.string_at(psSelectValue.contents.pvData, 2))
            i16data = struct.unpack('h', data)[0]        
            print(f" Data : {i16data}")

        else :
            print(" invalid variation")

    

    if psSelectID.contents.eGroupID ==  eDNP3GroupID.BINARY_OUTPUT :

        print("GROUP ID : BINARY_OUTPUT")
        print("Index Number %u"% psSelectID.contents.u16IndexNumber)


        if psSelectParams.contents.eCommandVariation == eCommandObjectVariation.CROB_G12V1 :
             print(" variation : CROB_G12V1")
        else :
             print(" invalid variation")
            
        data = bytearray(ctypes.string_at(psSelectValue.contents.pvData, 1))
        u8data = struct.unpack('B', data)[0] 
        print(f" Data : {u8data}")

        print("Operation Type %u"% psSelectParams.contents.eOPType)
        print("Count %u"%psSelectParams.contents.u8Count)
        print("On time %u"%psSelectParams.contents.u32ONtime)
        print("Off time %u"%psSelectParams.contents.u32OFFtime)
        print("CR %u"%psSelectParams.contents.bCR)
    

    if psSelectValue.contents.sTimeStamp.u16Year != 0:
        print(f" Date : {psSelectValue.contents.sTimeStamp.u8Day:02}-{psSelectValue.contents.sTimeStamp.u8Month:02}-{psSelectValue.contents.sTimeStamp.u16Year:04}  DOW -{psSelectValue.contents.sTimeStamp.u8DayoftheWeek}")
        print(f" Time : {psSelectValue.contents.sTimeStamp.u8Hour:02}:{psSelectValue.contents.sTimeStamp.u8Minute:02}:{psSelectValue.contents.sTimeStamp.u8Seconds:02}:{psSelectValue.contents.sTimeStamp.u16MilliSeconds:03}")


    return i16ErrorCode

# dnp3 operate callback
def cbOperate(u16ObjectId, psOperateID, psOperateValue, psOperateParams, ptErrorValue):

    i16ErrorCode = ctypes.c_short()
    i16ErrorCode = 0   

    print("************cbOperate() called*****************")
    print(" Server ID : %u" % u16ObjectId)


    if psOperateID.contents.eCommMode    ==  eCommunicationMode.COMM_SERIAL:    
        print("Serial Port %u"% psOperateID.contents.u16SerialPortNumber)    
    else :    
        print("IP Address %s" % psOperateID.contents.ai8IPAddress)
        print("\tPort %u" % psOperateID.contents.u16PortNumber)

    if psOperateID.contents.eGroupID ==  eDNP3GroupID.ANALOG_OUTPUTS :
    
        print("GROUP ID : ANALOG_OUTPUT")
        print("Index Number %u"% psOperateID.contents.u16IndexNumber)

        if psOperateParams.contents.eCommandVariation == eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_FLOAT32 :		
            data = bytearray(ctypes.string_at(psOperateValue.contents.pvData, 4))
            f32data = struct.unpack('f', data)[0] 
            print(f" Data : {f32data:.3f}")

        elif psOperateParams.contents.eCommandVariation == eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER32:      
            data = bytearray(ctypes.string_at(psOperateValue.contents.pvData, 4))
            i32data = struct.unpack('i', data)[0]        
            print(f" Data : {i32data}")

        elif psOperateParams.contents.eCommandVariation == eCommandObjectVariation.ANALOG_OUTPUT_BLOCK_INTEGER16:
            data = bytearray(ctypes.string_at(psOperateValue.contents.pvData, 2))
            i16data = struct.unpack('h', data)[0]        
            print(f" Data : {i16data}")

        else :
            print(" invalid variation")

    

    if psOperateID.contents.eGroupID ==  eDNP3GroupID.BINARY_OUTPUT :

        print("GROUP ID : BINARY_OUTPUT")
        print("Index Number %u"% psOperateID.contents.u16IndexNumber)


        if psOperateParams.contents.eCommandVariation == eCommandObjectVariation.CROB_G12V1 :
             print(" variation : CROB_G12V1")
        else :
             print(" invalid variation")
            
        data = bytearray(ctypes.string_at(psOperateValue.contents.pvData, 1))
        u8data = struct.unpack('B', data)[0] 
        print(f" Data : {u8data}")

        print("Operation Type %u"% psOperateParams.contents.eOPType)
        print("Count %u"%psOperateParams.contents.u8Count)
        print("On time %u"%psOperateParams.contents.u32ONtime)
        print("Off time %u"%psOperateParams.contents.u32OFFtime)
        print("CR %u"%psOperateParams.contents.bCR)
    

    if psOperateValue.contents.sTimeStamp.u16Year != 0:
        print(f" Date : {psOperateValue.contents.sTimeStamp.u8Day:02}-{psOperateValue.contents.sTimeStamp.u8Month:02}-{psOperateValue.contents.sTimeStamp.u16Year:04}  DOW -{psOperateValue.contents.sTimeStamp.u8DayoftheWeek}")
        print(f" Time : {psOperateValue.contents.sTimeStamp.u8Hour:02}:{psOperateValue.contents.sTimeStamp.u8Minute:02}:{psOperateValue.contents.sTimeStamp.u8Seconds:02}:{psOperateValue.contents.sTimeStamp.u16MilliSeconds:03}")


    return i16ErrorCode

# dnp3 debug callback
def cbDebug(u16ObjectId, ptDebugData, ptErrorValue):

    i16ErrorCode = ctypes.c_short()
    i16ErrorCode = 0 

    u16nav = ctypes.c_ushort()
    u16nav = 0

    #printf("cbDebug() called");

      
    if (ptDebugData.contents.u32DebugOptions & eDebugOptionsFlag.DEBUG_OPTION_TX) == eDebugOptionsFlag.DEBUG_OPTION_TX : 

        if ptDebugData.contents.eCommMode   ==  eCommunicationMode.COMM_SERIAL:
        
            print(f"Serial port {ptDebugData.contents.u16ComportNumber} Transmit { ptDebugData.contents.u16TxCount} bytes ->  ", end='')
        
        else :
        
            print(f"IP {ptDebugData.contents.ai8IPAddress} Ethernet port {ptDebugData.contents.u16PortNumber} Transmit {ptDebugData.contents.u16TxCount} bytes ->  ", end='' )
        

        for u16nav in range(ptDebugData.contents.u16TxCount):
            print(f" {ptDebugData.contents.au8TxData[u16nav]:02x}", end='')
    

    if (ptDebugData.contents.u32DebugOptions & eDebugOptionsFlag.DEBUG_OPTION_RX) == eDebugOptionsFlag.DEBUG_OPTION_RX : 

        if ptDebugData.contents.eCommMode   ==  eCommunicationMode.COMM_SERIAL:
        
            print(f"Serial port {ptDebugData.contents.u16ComportNumber} Receive { ptDebugData.contents.u16RxCount} bytes <-  ", end='')
        
        else :
        
            print(f"IP {ptDebugData.contents.ai8IPAddress} Ethernet port {ptDebugData.contents.u16PortNumber} Receive {ptDebugData.contents.u16RxCount} bytes <-  ", end='')
        
        

        for u16nav in range(ptDebugData.contents.u16RxCount):
            print(f" {ptDebugData.contents.au8RxData[u16nav]:02x}", end='')


    
    if (ptDebugData.contents.u32DebugOptions & eDebugOptionsFlag.DEBUG_OPTION_ERROR) == eDebugOptionsFlag.DEBUG_OPTION_ERROR: 
    
        print(f"Error message {ptDebugData.contents.au8ErrorMessage}")
        print(f"ErrorCode  {ptDebugData.contents.i16ErrorCode}")
        print(f"ErrorValue {ptDebugData.contents.tErrorValue}")
    

    if (ptDebugData.contents.u32DebugOptions & eDebugOptionsFlag.DEBUG_OPTION_WARNING) == eDebugOptionsFlag.DEBUG_OPTION_WARNING: 
    
        print(f"Error message {ptDebugData.contents.au8WarningMessage}")
        print(f"ErrorCode  {ptDebugData.contents.i16ErrorCode}")
        print(f"ErrorValue {ptDebugData.contents.tErrorValue}")

    print("", flush=True)

    return i16ErrorCode

# dnp3 update particular group and index from user inpur
def update(myServer):

    i16ErrorCode = ctypes.c_short()
    tErrorValue =  ctypes.c_short()

    '''
    psNewValue[1].pvData        =   &f32Data;'''
    
    print("UPDATE CALLED")
    while True:
        try:
            u16index = ctypes.c_uint16(int(input("Analog Input Enter Information Index- 0 to 9 ")))
        except ValueError:
            print("Please enter a number 0 to 9")
        else:
            break

    while True:
        try:
            f32value = ctypes.c_float(float(input("Enter update float value: ")))
        except ValueError:
            print("Please enter a float number ")
        else:
            break

   
    psDAID = sDNP3DataAttributeID()
    psNewValue  = sDNP3DataAttributeData()

    psDAID.u16SlaveAddress   =   1
    psDAID.eGroupID          =   eDNP3GroupID.ANALOG_INPUT
    psDAID.u16IndexNumber    =   u16index     

    psNewValue.eDataSize     =   eDataSizes.FLOAT32_SIZE
    psNewValue.eDataType     =   eDataTypes.FLOAT32_DATA
    psNewValue.tQuality      =   eDNP3QualityFlags.ONLINE 


    psNewValue.pvData                           =   ctypes.cast(ctypes.pointer(f32value),ctypes.c_void_p)
    

    now = time.time()
    timeinfo = time.localtime(now)
    
    #current date
    psNewValue.sTimeStamp.u8Day = timeinfo.tm_mday
    psNewValue.sTimeStamp.u8Month = timeinfo.tm_mon
    psNewValue.sTimeStamp.u16Year = timeinfo.tm_year 

    psNewValue.sTimeStamp.u8Hour = timeinfo.tm_hour
    psNewValue.sTimeStamp.u8Minute = timeinfo.tm_min
    psNewValue.sTimeStamp.u8Seconds = timeinfo.tm_sec
    psNewValue.sTimeStamp.u16MilliSeconds = 0
    psNewValue.sTimeStamp.u16MicroSeconds = 0
    psNewValue.sTimeStamp.i8DSTTime = 0
    psNewValue.sTimeStamp.u8DayoftheWeek = 4
    psNewValue.bTimeInvalid = False

    #printf(" update float value %f",f32data);
    # Update server
   
    i16ErrorCode = dnp3_lib.DNP3Update(myServer,ctypes.byref(psDAID),ctypes.byref(psNewValue),1,eUpdateClassID.UPDATE_DEFAULT_EVENT,ctypes.byref((tErrorValue)))
    if i16ErrorCode != 0:
        message = f"DNP3 Library API Function - DNP3Update() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)     

    else:
        message = f"DNP3 Library API Function - DNP3Update() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 

#main program
def main():
    print(" \t\t**** DNP3 Protocol Server Library Test ****")
    # Check library version against the library header file
    if dnp3_lib.DNP3GetLibraryVersion().decode("utf-8") != DNP3_VERSION:
        print(" Error: Version Number Mismatch")
        print(" Library Version is  : {}".format(dnp3_lib.DNP3GetLibraryVersion().decode("utf-8")))
        print(" The Header Version used is : {}".format(DNP3_VERSION))
        print("")
        input(" Press Enter to free dnp3 Server object")
        exit(0)

    print(" Library Version is : {}".format(dnp3_lib.DNP3GetLibraryVersion().decode("utf-8")))
    print(" Library Build on   : {}".format(dnp3_lib.DNP3GetLibraryBuildTime().decode("utf-8")))
    print(" Library License Information   : {}".format(dnp3_lib.DNP3GetLibraryLicenseInfo().decode("utf-8")))

    i16ErrorCode = ctypes.c_short()
    tErrorValue =  ctypes.c_short() 

    sParameters = sDNP3Parameters()

   

    # Initialize IEC 60870-5-104 Server object parameters
    sParameters.eAppFlag          =  eApplicationFlag.APP_SERVER        # This is a IEC104 Server      
    sParameters.ptReadCallback    = ctypes.cast(None,DNP3ReadCallback)               # Read Callback
    sParameters.ptWriteCallback   = DNP3WriteCallback(cbWrite)                # Write Callback
    sParameters.ptUpdateCallback  = ctypes.cast(None,DNP3UpdateCallback) #IEC104UpdateCallback(0)                 # Update Callback
    sParameters.ptSelectCallback  = DNP3ControlSelectCallback(cbSelect)               # Select Callback
    sParameters.ptOperateCallback = DNP3ControlOperateCallback(cbOperate)              # Operate Callback
    sParameters.ptDebugCallback   = DNP3DebugMessageCallback(cbDebug)                # Debug Callback
    sParameters.ptUpdateIINCallback = ctypes.cast(None,DNP3UpdateIINCallback)
    sParameters.ptClientPollStatusCallback = ctypes.cast(None,DNP3ClientPollStatusCallback)				# Function called when Client Compteated Poll operation for particular Server. If equal to NULL then callback is not used 
    sParameters.ptClientStatusCallback = ctypes.cast(None,DNP3ClientStatusCallback)
    sParameters.ptColdRestartCallback    = DNP3ColdRestartCallback(cbColdRestart)        # ColdRestart Callback
    sParameters.ptWarmRestartCallback    = DNP3WarmRestartCallback(cbWarmRestart)        # ColdRestart Callback
    sParameters.ptDeviceAttrCallback    = ctypes.cast(None,DNP3DeviceAttributeCallback)
    sParameters.u32Options        = 0
    sParameters.u16ObjectId				= 1				#Server ID which used in callbacks to identify the iec 104 server object   

    
    # Create a server object

    myServer =  dnp3_lib.DNP3Create(ctypes.byref(sParameters), ctypes.byref((i16ErrorCode)), ctypes.byref((tErrorValue)))
    if i16ErrorCode.value != 0:
        message = f"DNP3 Library API Function - DNP3Create() failed: {i16ErrorCode.value} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)    
        exit(0) 
    else:
        message = f"DNP3 Library API Function - DNP3Create() success: {i16ErrorCode.value} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 


    while(True):

        sDNP3Config = sDNP3ConfigurationParameters()


        if  'SERVER_TCP_COMMUNICATION' in globals():
            
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.eCommMode                     =   eCommunicationMode.TCP_IP_MODE
            # check computer configuration - TCP/IP Address
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sEthernetCommsSet.sEthernetportSet.ai8FromIPAddress = "127.0.0.1".encode('utf-8')  # Server works on every interface
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sEthernetCommsSet.sEthernetportSet.u16PortNumber   =   20000
            
        else:
            
            #serial communication setting
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.eCommMode =   eCommunicationMode.COMM_SERIAL
            
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialType   = eSerialTypes.SERIAL_RS232
            #check computer configuration serial com port number,  if server and client application running in same system, we can use com0com
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.u16SerialPortNumber =   SERIAL_PORT_NUMBER  
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialBitRate =   eSerialBitRate.BITRATE_9600
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eWordLength  =   eSerialWordLength.WORDLEN_8BITS
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eSerialParity  =   eSerialParity.EVEN
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.eStopBits =   eSerialStopBits.STOPBIT_1BIT
            
            #Serial port flow control
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.bWinCTSoutputflow         =  False
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.bWinDSRoutputflow         =  False
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eWinDTR					  =	 eWinDTRcontrol.WIN_DTR_CONTROL_DISABLE
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eWinRTS					  =  eWinRTScontrol.WIN_RTS_CONTROL_DISABLE
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sFlowControl.eLinuxFlowControl         = eLinuxSerialFlowControl.FLOW_NONE

            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16CharacterTimeout   =   1
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16MessageTimeout   =   0
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16InterCharacterDelay    =   5
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16PostDelay  =   0
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u16PreDelay       =   0
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u8CharacterRetries    =   20
            sDNP3Config.sDNP3ServerSet.sServerCommunicationSet.sSerialSet.sRxTimeParam.u8MessageRetries  =   0


        #protocol communication settings
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u16SlaveAddress                            =   1          # slave address
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u16MasterAddress                           =   2          # master address
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u32LinkLayerTimeout                        =   10000      # link layer time out in ms
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u32ApplicationLayerTimeout                 =   20000      # app link layer time out in ms
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u32TimeSyncIntervalSeconds                 =   90     # time sync bit will set for every 90 seconds, set high value, because every u32TimeSyncIntervalSeconds slave request time from master

        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarBI                =   eDefaultStaticVariationBinaryInput.BI_WITH_FLAGS                      # Default Static variation Binary Input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarDBI               =   eDefaultStaticVariationDoubleBitBinaryInput.DBBI_WITH_FLAGS                # Default Static variation Double Bit Binary Input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarBO                =   eDefaultStaticVariationBinaryOutput.BO_WITH_FLAGS                      # Default Static variation Double Bit Binary Output
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarCI                =   eDefaultStaticVariationCounterInput.CI_32BIT_WITHFLAG                      # Default Static variation counter Input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarFzCI              =   eDefaultStaticVariationFrozenCounterInput.FCI_32BIT_WITHFLAGANDTIME          # Default Static variation Frozen counter Input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAI                =   eDefaultStaticVariationAnalogInput.AI_SINGLEPREC_FLOATWITHFLAG                        # Default Static variation Analog Input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarFzAI              =   eDefaultStaticVariationFrozenAnalogInput.FAI_SINGLEPRECFLOATWITHFLAG        # Default Static variation frozen Analog Input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAID               =   eDefaultStaticVariationAnalogInputDeadBand.DAI_SINGLEPRECFLOAT            # Default Static variation Analog Input Deadband
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sStaticVariation.eDeStVarAO                =   eDefaultStaticVariationAnalogOutput.AO_SINGLEPRECFLOAT_WITHFLAG    # Default Static variation Analog Output

        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarBI                 =   eDefaultEventVariationBinaryInput.BIE_WITH_ABSOLUTETIME               # Default event variation for binary input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarDBI                =   eDefaultEventVariationDoubleBitBinaryInput.DBBIE_WITH_ABSOLUTETIME    # Default event variation for double bit binary input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarCI                 =   eDefaultEventVariationCounterInput.CIE_32BIT_WITHFLAG_WITHTIME            # Default event variation for Counter input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarAI                 =   eDefaultEventVariationAnalogInput.AIE_SINGLEPREC_WITHTIME                # Default event variation for Analog input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarFzCI               =   eDefaultEventVariationFrozenCounterInput.FCIE_32BIT_WITHFLAG_WITHTIME       # Default event variation for Frozen counter input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarFzAI               =   eDefaultEventVariationFrozenAnalogInput.FAIE_SINGLEPREC_WITHTIME           # Default event variation for Frozen Analog input
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarBO                 =   eDefaultEventVariationBinaryOutput.BOE_WITH_TIME               #/ Default event variation for binary Output
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sEventVariation.eDeEvVarAO                 =   eDefaultEventVariationAnalogOutput.AOE_SINGLEPREC_WITHTIME               # Default event variation for Analog Output
        

        sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class1EventBufferSize                    =   50    # class 1 buffer size number of events to store
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class1EventBufferOverFlowPercentage       =   90
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class2EventBufferSize                    =   50    # class 2 buffer size number of events to store
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class2EventBufferOverFlowPercentage       =   90
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u16Class3EventBufferSize                    =   50    # class 3 buffer size number of events to store
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u8Class3EventBufferOverFlowPercentage       =   90





        now = time.time()
        timeinfo = time.localtime(now)
        
        #current date
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Day = timeinfo.tm_mday
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Month = timeinfo.tm_mon
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16Year = timeinfo.tm_year 

        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Hour = timeinfo.tm_hour
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Minute = timeinfo.tm_min
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8Seconds = timeinfo.tm_sec
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16MilliSeconds = 0
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u16MicroSeconds = 0
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.i8DSTTime = 0
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sTimeStamp.u8DayoftheWeek = 4
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bTimeInvalid = False


        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBIinClass0    =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddDBIinClass0   =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBOinClass0    =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddCIinClass0    =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzCIinClass0  =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIinClass0    =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzAIinClass0  =   False
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIDinClass0   =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAOinClass0    =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddOSinClass0    =   True


        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBIEvent       =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddDBIEvent      =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddBOEvent       =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddCIEvent       =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzCIEvent     =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIEvent       =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddFzAIEvent     =   False
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAIDEvent      =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddAOEvent       =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddOSEvent       =   True
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bAddVTOEvent      =   True

        sDNP3Config.sDNP3ServerSet.sServerProtSet.eAIDeadbandMethod     =   eAnalogInputDeadbandMethod.DEADBAND_FIXED                                  # Analog Input Deadband Calculation method
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bFrozenAnalogInputSupport = False        #False- stack will not create points for frozen analog input.*/
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bEnableSelfAddressSupport = True         # Enable Self Address Support */
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bEnableFileTransferSupport = False       # Enable File Transfr Support*/
        sDNP3Config.sDNP3ServerSet.sServerProtSet.u8IntialdatabaseQualityFlag = eDNP3QualityFlags.ONLINE       # 0- OFFLINE, 1 BIT- ONLINE, 2 BIT-RESTART, 3 BIT -COMMLOST, MAX VALUE -7   */
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bLocalMode                    =   False  # if local mode set true, then -all remote command for binary output/ analog output   control statusset to not supported */
        sDNP3Config.sDNP3ServerSet.sServerProtSet.bUpdateCheckTimestamp     =   False      # if it true ,the timestamp change also generate event  during the dnp3update */



        #Unsolicited Response Setttings
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.bEnableUnsolicited         =   False
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.bEnableResponsesonStartup  =   False   # enable or disable unsolicited response to master
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u32Timeout                 =   5000   # unsolicited response timeout in ms

        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class1TriggerNumberofEvents   =   1
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class1HoldTimeAfterResponse   =   1

        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class2TriggerNumberofEvents  =   1
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class2HoldTimeAfterResponse  =   1

        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class3TriggerNumberofEvents  =   1
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16Class3HoldTimeAfterResponse   =   1

        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u8Retries                      =   5      # Unsolicited message retries
        sDNP3Config.sDNP3ServerSet.sServerProtSet.sUnsolicitedResponseSet.u16MaxNumberofEvents   =   10

        # Debug option settings
        if  'VIEW_TRAFFIC' in globals():
            sDNP3Config.sDNP3ServerSet.sDebug.u32DebugOptions   =   (eDebugOptionsFlag.DEBUG_OPTION_RX | eDebugOptionsFlag.DEBUG_OPTION_TX)
        else:
             sDNP3Config.sDNP3ServerSet.sDebug.u32DebugOptions  =   0



        # Define number of objects
        sDNP3Config.sDNP3ServerSet.u16NoofObject                             =   4
        sDNP3Config.sDNP3ServerSet.psDNP3Objects  = ( sDNP3Object * sDNP3Config.sDNP3ServerSet.u16NoofObject)()

        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].ai8Name = "binary input 0-9".encode('utf-8')
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eGroupID       =   eDNP3GroupID.BINARY_INPUT
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].u16NoofPoints  =   10
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eClassID       =   eDNP3ClassID.CLASS_ONE
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eControlModel  =   eDNP3ControlModelConfig.INPUT_STATUS_ONLY
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].u32SBOTimeOut  =   0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].f32AnalogInputDeadband  =   0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[0].eAnalogStoreType =	eAnalogStorageType.AS_FLOAT

        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].ai8Name = "analog Input 0-9".encode('utf-8')
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eGroupID       =   eDNP3GroupID.ANALOG_INPUT
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].u16NoofPoints  =   10
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eClassID       =   eDNP3ClassID.CLASS_ONE
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eControlModel  =   eDNP3ControlModelConfig.INPUT_STATUS_ONLY
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].u32SBOTimeOut  =   0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].f32AnalogInputDeadband  =  0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[1].eAnalogStoreType =	eAnalogStorageType.AS_FLOAT


        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].ai8Name = "binary output 0-9".encode('utf-8')
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eGroupID       =   eDNP3GroupID.BINARY_OUTPUT
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].u16NoofPoints  =   10
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eClassID       =   eDNP3ClassID.CLASS_ONE
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eControlModel  =   eDNP3ControlModelConfig.DIRECT_OPERATION
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].u32SBOTimeOut  =   0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].f32AnalogInputDeadband  =  0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[2].eAnalogStoreType =	eAnalogStorageType.AS_FLOAT

        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].ai8Name = "analog output 0-9".encode('utf-8')
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eGroupID       =   eDNP3GroupID.ANALOG_OUTPUTS
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].u16NoofPoints  =   10
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eClassID       =   eDNP3ClassID.CLASS_ONE
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eControlModel  =   eDNP3ControlModelConfig.DIRECT_OPERATION
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].u32SBOTimeOut  =   0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].f32AnalogInputDeadband  =  0
        sDNP3Config.sDNP3ServerSet.psDNP3Objects[3].eAnalogStoreType =	eAnalogStorageType.AS_FLOAT


        i16ErrorCode =  dnp3_lib.DNP3LoadConfiguration(myServer, ctypes.byref(sDNP3Config), ctypes.byref((tErrorValue)))
        if i16ErrorCode != 0:
            message = f"DNP3 Library API Function - DNP3IEC104LoadConfiguration() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message)    
            break

        else:
            message = f"DNP3 Library API Function - DNP3IEC104LoadConfiguration() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message) 



        i16ErrorCode =  dnp3_lib.DNP3Start(myServer, ctypes.byref((tErrorValue)))
        if i16ErrorCode != 0:
            message = f"DNP3 Library API Function - DNP3Start() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message)    
            break

        else:
            message = f"DNP3 Library API Function - DNP3Start() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message) 

        print("press x to exit")

        while(True):
            if keyboard.is_pressed('x'):
                print("x pressed, exiting loop")
                keyboard.release('x')
                time.sleep(0.1)
                break
            elif keyboard.is_pressed('u'):
                print("u pressed, update called")
                keyboard.release('u')
                time.sleep(0.1)
                update(myServer)

            #Xprint("sleep called")
            time.sleep(50 /1000)

        break
            
            

      



    i16ErrorCode =  dnp3_lib.DNP3Stop(myServer, ctypes.byref((tErrorValue)))
    if i16ErrorCode != 0:
        message = f"DNP3 Library API Function - DNP3Stop() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)        
    else:
        message = f"DNP3 Library API Function - DNP3Stop() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 



    i16ErrorCode =  dnp3_lib.DNP3Free(myServer, ctypes.byref((tErrorValue)))
    if i16ErrorCode != 0:
        message = f"DNP3 Library API Function - DNP3Free() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)    
    else:
        message = f"DNP3 Library API Function - DNP3Free() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 


    print("Exiting the program...")

if __name__ == "__main__":
    main()