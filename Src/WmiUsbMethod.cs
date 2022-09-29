using System;
using System.Collections.Generic;

using System.Management;
using System.Text.RegularExpressions;

namespace USBmodify.Src
{
    #region USB

    /// <summary>
    /// USB控制設備類型
    /// </summary>
    public struct USBControllerDevice
    {
        /// <summary>
        /// USB控制器設備ID
        /// </summary>
        public string antecedent;
        /// <summary>
        /// USB即插即用設備ID
        /// </summary>
        public string dependent;
    }

    /// <summary>
    /// 監視USB插拔
    /// </summary>
    public class USB
    {
        /// <summary>
        /// USB插入事件監視
        /// </summary>
        private ManagementEventWatcher insertWatcher = null;
        /// <summary>
        /// USB拔出事件監視
        /// </summary>
        private ManagementEventWatcher removeWatcher = null;

        public bool AddUSBEventWatcher(EventArrivedEventHandler usbInsertHandler, EventArrivedEventHandler usbRemoveHandler, TimeSpan withinInterval)
        {           
            try
            {
                ManagementScope Scope = new ManagementScope("root\\CIMV2");
                Scope.Options.EnablePrivileges = true;

                //USB插入監視
                if (usbInsertHandler != null)
                {
                    WqlEventQuery InsertQuery = new WqlEventQuery("__InstanceCreationEvent",
                        withinInterval,
                        "TargetInstance isa 'Win32_USBControllerDevice'");

                    insertWatcher = new ManagementEventWatcher(Scope, InsertQuery);
                    insertWatcher.EventArrived += usbInsertHandler;
                    insertWatcher.Start();
                }

                //USB拔出監視
                if(usbRemoveHandler != null)
                {
                    WqlEventQuery RemoveQuery = new WqlEventQuery("__InstanceDeletionEvent",
                        withinInterval,
                        "TargetInstance isa 'Win32_USBControllerDevice'");

                    removeWatcher = new ManagementEventWatcher(Scope, RemoveQuery);
                    removeWatcher.EventArrived += usbRemoveHandler;
                    removeWatcher.Start();
                }
                return true;
            }
            catch(Exception)
            {                
                return false;
            }
        }

        /// <summary>
        /// 移去USB事件监视器
        /// </summary>
        public void RemoveUSBEventWatcher()
        {
            if (insertWatcher != null)
            {
                insertWatcher.Stop();
                insertWatcher = null;
            }

            if (removeWatcher != null)
            {
                removeWatcher.Stop();
                removeWatcher = null;
            }
        }
    }



    #endregion

    #region
    public struct PnPEntityInfo
    {
        public String PNPDeviceID;      // 設備ID
        public String VID;              // 廠商ID
        public String PID;              // 產品ID    
        public String ComPort;          // 設備標題(COM)        
    }
    public class WmiUsbAttributes
    {
        public string commend { get { return "SELECT * FROM Win32_PnPEntity"; } }
    }
    
    /// 基於WMI獲取USB設備信息
    public class WmiUsbMethod:WmiUsbAttributes
    {
        #region PnPEntity
        public  PnPEntityInfo[] AllPnPEntities
        {
            get{ return WhoPnPEntity(UInt16.MinValue, UInt16.MinValue, Guid.Empty); }
        }

        public PnPEntityInfo[] WhoPnPEntity(UInt16 VendorID, UInt16 ProductID, Guid ClassGuid)
        {
            
            List<PnPEntityInfo> PnPEntities = new List<PnPEntityInfo>();
            // 枚舉即插即用設備實體
            ManagementObjectCollection PnPEntityCollection = new ManagementObjectSearcher(commend).Get();
            if (PnPEntityCollection != null)
            {
                foreach (ManagementObject Entity in PnPEntityCollection)
                {
                    String PNPDeviceID = Entity["PNPDeviceID"] as String;
                    String Caption = Entity["Caption"] as String;                    
                    Match match_ComPort = null;
                    Match match_VidPid = null;
                    Match match_VID = null;
                    Match match_PID = null;

                    if (!String.IsNullOrWhiteSpace(Caption))
                    {
                        match_ComPort = Regex.Match(Caption, @"COM\d*");
                    }                    
                    if(!String.IsNullOrWhiteSpace(PNPDeviceID))
                    {
                        match_VidPid = Regex.Match(PNPDeviceID, "VID_[0-9|A-F]{4}.?PID_[0-9|A-F]{4}");
                        match_VID = Regex.Match(PNPDeviceID, "VID_[0-9|A-F]{4}");
                        match_PID = Regex.Match(PNPDeviceID, "PID_[0-9|A-F]{4}");
                    }

                    if (match_VidPid.Success)
                    {
                        PnPEntityInfo Element;
                        Element.PNPDeviceID = PNPDeviceID;                          // 設備ID
                        Element.VID = match_VID.Value;                              // 廠商ID
                        Element.PID = match_PID.Value;                              // 產品ID  
                        Element.ComPort = match_ComPort.Value;                      // 設備標題(COM)
                                                                                    
                        PnPEntities.Add(Element);
                    }
                }
            }

            if (PnPEntities.Count == 0) return null;            
            else return PnPEntities.ToArray();
        }
        #endregion        
    }
    #endregion
}