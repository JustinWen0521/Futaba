using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ftd.mvc.Areas.AL.Controllers
{
    /// <summary>
    /// 這是讀取組立工程明細 controller
    /// </summary>
    public class AssmblingDetailController : ApiController
    {
        
        /// <summary>
        /// 預設選取多筆資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 取得此項目的資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/assmblingdetail
        public void Post([FromBody]string value)
        {
        }

        // PUT api/assmblingdetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/assmblingdetail/5
        public void Delete(int id)
        {
        }
    }
}
