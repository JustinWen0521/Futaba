using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ftd.data
{
    /// <summary>
    /// 裝置命令
    /// </summary>
    [XmlRoot("EmEmailData")]
    public class EmDeviceCommandData
    {      
        /// <summary>
        /// 裝置id
        /// </summary>
        [XmlAttribute("DeviceId")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 服務名稱
        /// </summary>
        [XmlAttribute("ServiceName")]
        public string ServiceName { get; set; }

        /// <summary>
        /// 命令名稱
        /// </summary>
        [XmlAttribute("CommandName")]
        public string CommandName { get; set; }

        /// <summary>
        /// 參數
        /// </summary>
        [XmlAttribute("CommandParameter")]
        public string CommandParameter { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EmDeviceCommandData()
        {
        }

    }
}
