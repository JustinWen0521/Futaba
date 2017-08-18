using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ftd.data
{
    /// <summary>
    /// 簡訊
    /// </summary>
    [XmlRoot("EmSmsData")]
    public class EmSmsData
    {       
        /// <summary>
        /// 收件者SMS
        /// </summary>
        [XmlAttribute("SmsNumber")]
        public string SmsNumber { get; set; }    
  
        /// <summary>
        /// 內容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EmSmsData()
        {
        }
    }
}
