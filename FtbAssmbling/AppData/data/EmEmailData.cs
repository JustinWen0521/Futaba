using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ftd.data
{
    /// <summary>
    /// Email
    /// </summary>
    [XmlRoot("EmEmailData")]
    public class EmEmailData
    {      
        #region [BodyKindEnum]
        /// <summary>
        /// 內容類型
        /// </summary>
        public enum BodyKindEnum
        {
            /// <summary>
            /// 文字
            /// </summary>
            TEXT = 0,
            /// <summary>
            /// HTML
            /// </summary>
            HTML
        } 
        #endregion

        /// <summary>
        /// 寄件者
        /// </summary>
        [XmlAttribute("SenderName")]
        public string SenderName { get; set; }

        /// <summary>
        /// 寄件者Email
        /// </summary>
        [XmlAttribute("SenderEmail")]
        public string SenderEmail { get; set; }

        /// <summary>
        /// 收件者
        /// </summary>
        [XmlAttribute("ReceiverName")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收件者Email
        /// </summary>
        [XmlAttribute("ReceiverEmail")]
        public string ReceiverEmail { get; set; }      

        /// <summary>
        /// 主旨
        /// </summary>
        [XmlElement("Subject")]
        public string Subject { get; set; }
      
        /// <summary>
        /// 內容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 內容類型
        /// </summary>
        public BodyKindEnum BodyKind { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EmEmailData()
        {
            BodyKind = BodyKindEnum.TEXT;            
        }

    }
}
