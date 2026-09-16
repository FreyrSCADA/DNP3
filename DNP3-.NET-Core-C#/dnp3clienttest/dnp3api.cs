/*****************************************************************************/
/*! \file        DNP3API.cs
 *  \brief       DNP3 Server and Client API source file
 *  \author		 FreyrSCADA Embedded Solution Pvt Ltd
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

using System;
using System.Runtime.InteropServices;
using System.Text;




public partial class dnp3api
{
    /*! \brief          DNP3 Version Number */
    public const string DNP3_VERSION = "21.06.022";



    /*! \brief          Get Library Version
        \ingroup        Management

        \return         version number of library as a string of char with format AA.BB.CCC

    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3GetLibraryVersion", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern System.IntPtr DNP3GetLibraryVersion();

    /*! \brief          Get Library Build Time
        \ingroup        Management

        \return         Build time of the library as a string of char. Format "Mmm dd yyyy hh:mm:ss"
    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3GetLibraryBuildTime", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern System.IntPtr DNP3GetLibraryBuildTime();

    /*! \brief          Create a client or server object with call-backs for reading, writing and updating data objects
        \ingroup        Management

        \param[in]      psParameters    DNP3 Object Parameters
        \param[out]     pi16ErrorCode     Pointer to a Error Code (if any error occurs)
        \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

        \return         Pointer to a new DNP3 object
        \return         NULL if an error occured (errorCode will contain an error code)                
    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Create", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern System.IntPtr DNP3Create(ref dnp3types.sDNP3Parameters psParameters, ref short pi16ErrorCode, ref short ptErrorValue);

    /*! \brief          Load the configuration to be used by DNP3 object.
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object 
        \param[in]      psDNP3Config    Pointer to DNP3 Configuration parameters 
        \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

        \return         EC_NONE on success
        \return         otherwise error code


    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3LoadConfiguration", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern short DNP3LoadConfiguration(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3ConfigurationParameters psDNP3Config, ref short ptErrorValue);

    /*! \brief          Start DNP3 object communication
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object to Start
        \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

        \return         EC_NONE on success
        \return         otherwise error code



    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Start", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern short DNP3Start(System.IntPtr myDNP3Obj, ref short ptErrorValue);


    /*! \brief           Set DNP3 debug options.
        \ingroup         Management

         \param[in]      myDNP3Obj           DNP3 object to Get Type and Size
         \param[in]      psDebugParams       Pointer to debug parameters
         \param[out]     ptErrorValue        Pointer to a Error Value (if any error occurs while creating the object)

         \return         EC_NONE on success
         \return         otherwise error code          

     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3SetDebugOptions", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern short DNP3SetDebugOptions(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DebugParameters psDebugParams, ref short ptErrorValue);


    /*! \brief          Stop DNP3 object communication
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object to Stop
        \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

        \return         EC_NONE on success
        \return         otherwise error code

    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Stop", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern short DNP3Stop(System.IntPtr myDNP3Obj, ref short ptErrorValue);

    /*! \brief          Free memory used by DNP3 object.
        \ingroup        Management

        \param[in]      myDNP3Obj     DNP3 object to free
        \param[out]     ptErrorValue  Pointer to a Error Value (if any error occurs while creating the object)

        \return         EC_NONE on success
        \return         otherwise error code



    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Free", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern short DNP3Free(System.IntPtr myDNP3Obj, ref short ptErrorValue);


    /*!\brief           Update DNP3 data attribute ID to the New Value. 
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object to Update
        \param[in]      psDAID          Pointer to DNP3 Data Attribute ID
        \param[in]      psNewValue      Pointer to DNP3 Data Attribute Data
        \param[in]      u16Count        Number of DNP3 Data attribute ID and Data attribute data to be updated simultaneously
        \param[in]      eUpdateClass  eUpdateClassID - here, we can decide, the event generate , you can chose, default, no event, create class 1 / 2/ 3 event
        \param[out]     ptErrorValue    Pointer to a Error Value (if any error occurs while creating the object)

        \return         EC_NONE on success
        \return         otherwise error code


    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Update", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif
    public static extern short DNP3Update(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psNewValue, ushort u16Count, dnp3types.eUpdateClassID eUpdateClass, ref short ptErrorValue);

    /*!\brief           Read a value to a given Object ID. 
        \ingroup        Management

        \param[in]      myDNP3Obj        DNP3 object 
        \param[in]      psDAID           Pointer to DNP3 DataAttributeID structure (or compatable) that idendifies the point that is to be read
        \param[in]      psReturnedValue  Pointer to Object Data structure that hold the returned vaule
        \param[out]     ptErrorValue     Pointer to a Error Value (if any error occurs while reading the object)

        \return         EC_NONE on success
        \return         otherwise error code

    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Read", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif       
    public static extern short DNP3Read(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psReturnedValue, ref short ptErrorValue);

    /*!\brief           Write a value to a given Object ID. 
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object 
        \param[in]      psDAID          Pointer to DNP3_DataAttributeID structure (or compatable) that idendifies the point that is to be written
        \param[in]      psNewValue      Pointer to Object Data structure that hold the new vaule of the tObjectID
        \param[out]     ptErrorValue    Pointer to a Error Value 

        \return         EC_NONE on success
        \return         otherwise error code


    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Write", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif            
    public static extern short DNP3Write(System.IntPtr myDNP3Obj, dnp3types.eWriteFunctionID eFunctionID, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psNewValue, ref short ptErrorValue);

    /*!\brief           Select a given control Data object. 
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object 
        \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Selected
        \param[in]      psSelectValue   Pointer to DNP3 Data Attribute Data (The value the control is to be set)
        \param[in]      psSelectParams  Pointer to DNP3 struct sDNP3CommandParameters 
        \param[out]     ptErrorValue    Pointer to a Error Value 

        \return         EC_NONE on success
        \return         otherwise error code


    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Select", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif            
    public static extern short DNP3Select(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psSelectValue, ref dnp3types.sDNP3CommandParameters psSelectParams, ref short ptErrorValue);

    /*!\brief           Send an Operate command on given control Data object. 
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object 
        \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Operated
        \param[in]      psOperateValue  Pointer to DNP3 Data Attribute Data (The value the control is to be set )
        \param[in]      psOperateParams Pointer to DNP3 struct sDNP3CommandParameters 
        \param[out]     ptErrorValue    Pointer to a Error Value 

        \return         EC_NONE on success
        \return         otherwise error code


    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Operate", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif            
    public static extern short DNP3Operate(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psOperateValue, ref dnp3types.sDNP3CommandParameters psOperateParams, ref short ptErrorValue);

    /*!\brief           SelectBeforeOperate a given control Data object. 
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object 
        \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Selected
        \param[in]      psSelectValue   Pointer to DNP3 Data Attribute Data (The value the control is to be set)
        \param[in]      psSelectParams  Pointer to DNP3 struct sDNP3CommandParameters 
        \param[out]     ptErrorValue    Pointer to a Error Value 

        \return         EC_NONE on success
        \return         otherwise error code


    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3SelectBeforeOperate", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3SelectBeforeOperate(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psSelectValue, ref dnp3types.sDNP3CommandParameters psSelectParams, ref short ptErrorValue);

    /*!\brief           Send an Direct Operate with out ack command on given control Data object. 
        \ingroup        Management

        \param[in]      myDNP3Obj       DNP3 object 
        \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Operated
        \param[in]      psOperateValue  Pointer to DNP3 Data Attribute Data (The value the control is to be set )
        \param[in]      psOperateParams Pointer to DNP3 struct sDNP3CommandParameters 
        \param[out]     ptErrorValue    Pointer to a Error Value 

        \return         EC_NONE on success
        \return         otherwise error code


    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3DirectOperateWithNoAck", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif            
    public static extern short DNP3DirectOperateWithNoAck(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psOperateValue, ref dnp3types.sDNP3CommandParameters psOperateParams, ref short ptErrorValue);

    /*!\brief           Send an DirectOperate command on given control Data object. 
               \ingroup        Management

               \param[in]      myDNP3Obj       DNP3 object 
               \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Operated
               \param[in]      psOperateValue  Pointer to DNP3 Data Attribute Data (The value the control is to be set )
               \param[in]      psOperateParams Pointer to DNP3 struct sDNP3CommandParameters 
               \param[out]     ptErrorValue    Pointer to a Error Value 

               \return         EC_NONE on success
               \return         otherwise error code


           */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3DirectOperate", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif           
    public static extern short DNP3DirectOperate(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psOperateValue, ref dnp3types.sDNP3CommandParameters psOperateParams, ref short ptErrorValue);


    /*!\brief           Send an cancel command on given control Data object. 
              \ingroup        Management

              \param[in]      myDNP3Obj       DNP3 object 
              \param[in]      psDAID          Pointer to DNP3 Data Attribute ID of control that is to be Cancel
              \param[in]      psCancelValue  Pointer to DNP3 Data Attribute Data (The value the control is to be set )
              \param[in]      psCancelParams Pointer to DNP3 struct sDNP3CommandParameters 
              \param[out]     ptErrorValue    Pointer to a Error Value 

              \return         EC_NONE on success
              \return         otherwise error code


          */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3Cancel", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif            
    public static extern short DNP3Cancel(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psCancelValue, ref dnp3types.sDNP3CommandParameters psCancelParams, ref short ptErrorValue);


    /*! \brief        Get DNP3 data type and data size to the returned Value.
        \ingroup      Management

        \param[in]    myDNP3Obj           DNP3 object to Get Type and Size
        \param[in]    psDAID              Pointer to DNP3 Data Attribute ID
        \param[out]   psReturnedValue     Pointer to DNP3 Data Attribute Data containing only data type and data size.
        \param[out]   ptErrorValue        Pointer to a Error Value 

        \return       EC_NONE on success
        \return       otherwise error code
    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3GetDataTypeAndSize", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif            
    public static extern short DNP3GetDataTypeAndSize(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DataAttributeData psReturnedValue, ref short ptErrorValue);

    /*! \brief		  Get dnp3 Client Connection Status.
     *	\par		  Get DNP3 Get Client connection status.
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   *peSat			  Pointer to enum eStatus 
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ClientStatus", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif            
    public static extern short DNP3ClientStatus(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.eServerConnectionStatus peSat, ref short ptErrorValue);

    /*! \brief		  DNP3 File read.
     *	\par		  Get DNP3 File Read.
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   *psDNP3FileAttributeData,			  Pointer to struct sDNP3FileAttributeData 
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3FileRead", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif             
    public static extern short DNP3FileRead(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3FileAttributeData psDNP3FileAttributeData, ref short ptErrorValue);

    /*! \brief		  DNP3 File write.
     *	\par		  Get DNP3 File write.
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   *psDNP3FileAttributeData,			  Pointer to struct sDNP3FileAttributeData 
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3FileWrite", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif             
    public static extern short DNP3FileWrite(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3FileAttributeData psDNP3FileAttributeData, ref short ptErrorValue);

    /*! \brief		  DNP3 Read DataSet Prototype
     *	\par		  Get DNP3 Read DataSet Prototype
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   *psClDatasetPrototype 			  Pointer to struct sClientDatasetPrototype 
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ReadDataSetPrototype", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3ReadDataSetPrototype(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sClientDatasetPrototype psClDatasetPrototype, ref short ptErrorValue);

    /*! \brief		  DNP3 Read DataSet Descriptor
     *	\par		  Get DNP3 Read DataSet Descriptor
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   *psClDatasetDescriptor			  Pointer to struct sClientDatasetPrototype 
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ReadDataSetDescriptor", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3ReadDataSetDescriptor(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sClientDatasetPrototype psClDatasetDescriptor, ref short ptErrorValue);

    /*! \brief		  DNP3 Read DataSet Present Value
     *	\par		  Get DNP3 Read DataSet Present Value
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   *psClDatasetPsValue			  Pointer to struct sClientDatasetPresentvalue  
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ReadDataSetPresentValue", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3ReadDataSetPresentValue(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sClientDatasetPresentvalue psClDatasetPsValue, ref short ptErrorValue);

    /*! \brief		  DNP3 Directory Read
     *	\par		  Get DNP3 Directory Read
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   *psDNP3DirAttributeData			  Pointer to struct sDNP3DirAttributeData  
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3DirectoryRead", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3DirectoryRead(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref dnp3types.sDNP3DirAttributeData psDNP3DirAttributeData, ref short ptErrorValue);

    /*! \brief		  DNP3 Get Server Database Value
     *	\par		  DNP3 Get Server Database Value
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[out]   *psDNPServerDatabase Pointer to struct sDNPServerDatabase  
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3GetServerDatabaseValue", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3GetServerDatabaseValue(System.IntPtr myDNP3Obj, ref dnp3types.sDNPServerDatabase psDNPServerDatabase, ref short ptErrorValue);

    /*! \brief		  DNP3 Get Client Database Value
     *	\par		  DNP3 Get Client Database Value
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[out]   *psDNPClientDatabase Pointer to struct sDNPClientDatabase  
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3GetClientDatabaseValue", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3GetClientDatabaseValue(System.IntPtr myDNP3Obj, ref dnp3types.sDNPClientDatabase psDNPClientDatabase, ref short ptErrorValue);

    /*! \brief		  DNP3 Read Device Attribute Data
     *	\par		  DNP3 Read Device Attribute Data
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[in]    u8Variation         variation to read and get value  
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ReadDeviceAttribute", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3ReadDeviceAttribute(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, byte u8Variation, ref short ptErrorValue);

    /*! \brief		  DNP3 Client Get IIN
     *	\par		  DNP3 Client Get IIN
     *	\ingroup	  Management
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
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ClientGetIIN", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3ClientGetIIN(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, ref byte pu8IIN1, ref byte pu8IIN2, ref short ptErrorValue);


    /*! \brief		  Get DNP3 object Status.
     *	\par		  Get DNP3 Get object status -  loaded, running, stoped, freed.
     *	\ingroup	  Management
     *
     *	\param[in]	  myDNP3Obj		  DNP3 object 
     *	\param[out]   *peCurrentState	  Pointer to enum  eAppState   
     *	\param[out]   *ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "GetDNP3ObjectStatus", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short GetDNP3ObjectStatus(System.IntPtr myDNP3Obj, ref tgtcommon.eAppState peCurrentState, ref short ptErrorValue);


    /*! \brief		  Get Error code String
   *  \par 		   For particular Error code , get Error String
   *  \ingroup 	   Management
   *
   *  \param[in]	   *psDNP3ErrorCodeDes - Pointer to struct sDNP3ErrorCode
   *
   *  \return		   error code string
   */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ErrorCodeString", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif		
    public static extern void DNP3ErrorCodeString(ref dnp3types.sDNP3ErrorCode psDNP3ErrorCodeDes);

    /*! \brief		  Get Error value String
    *  \par 		   For particular Error value , get Error String
    *  \ingroup 	   Management
    *
    *  \param[in]	   *psDNP3ErrorValueDes - Pointer to struct sDNP3ErrorValue 
    *
    *  \return		   error value string
    */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ErrorValueString", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif		
    public static extern void DNP3ErrorValueString(ref dnp3types.sDNP3ErrorValue psDNP3ErrorValueDes);


    /*! \brief			   Get DNP3 Library License information
     *	\par			   Function used to get DNP3 Library License information
     *
     *	\return 		   License information of library as a string of char 
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3GetLibraryLicenseInfo", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern System.IntPtr DNP3GetLibraryLicenseInfo();

    /*! \brief		  Set dnp3 Client - stop/start polling particular server in serial multi drop
     *	\par		  Set DNP3 Get Client - stop/start polling particular server in serial multi drop
     *
     *	\param[in]	  myDNP3Obj 	  DNP3 object 
     *	\param[in]	  psDAID			  Pointer to dnp3 Data Attribute ID
     *	\param[out]   bStop 			True - stop , false - start polling particular server/device
     *	\param[out]   ptErrorValue		  Pointer to a Error Value
     *
     *	\return 	  EC_NONE on success
     *	\return 	  otherwise error code
     */
#if Windows
    [DllImport("dnp3x64d.dll", EntryPoint = "DNP3ClientStopServerMultidrop", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-dnp3.so")]
#endif      
    public static extern short DNP3ClientStopServerMultidrop(System.IntPtr myDNP3Obj, ref dnp3types.sDNP3DataAttributeID psDAID, byte bStop, ref short ptErrorValue);



}

