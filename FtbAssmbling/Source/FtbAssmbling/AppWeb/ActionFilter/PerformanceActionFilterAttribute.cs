using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.data.log;

namespace ftd.mvc.ActionFilter
{
    public class PerformanceActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //在Action執行前執行  
            //filterContext.HttpContext.Response.Write(@"<br />Before Action execute" + "\t " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff"));  
            getTimer(filterContext, "action").Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //在Action執行之後執行 輸出到輸出流中文字：After Action execute xxx  
            //filterContext.HttpContext.Response.Write(@"<br />After Action execute" + "\t " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff"));  
            getTimer(filterContext, "action").Stop();
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            getTimer(filterContext, "render").Start();
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //在Result執行之後  
            //filterContext.HttpContext.Response.Write(@"<br />After ViewResult execute" + "\t " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff"));  
            var renderTimer = getTimer(filterContext, "render");
            renderTimer.Stop();

            var actionTimer = getTimer(filterContext, "action");
            var msg = String.Format(
                        "Action '{0}/{1}', Execute: {2} , Render: {3} .",
                        filterContext.RouteData.Values["controller"],
                        filterContext.RouteData.Values["action"],
                        getTimeDesc(actionTimer.ElapsedTicks),
                        getTimeDesc(renderTimer.ElapsedTicks)
                    );
            var log = new PerformanceLog();
            log.LogContent = msg;
            log.post();
            base.OnResultExecuted(filterContext);
        }

        private Stopwatch getTimer(ControllerContext context, string name)
        {
            string key = "__timer__" + name;
            if (context.HttpContext.Items.Contains(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }

            var result = new Stopwatch();
            context.HttpContext.Items[key] = result;
            return result;
        }

        private string getTimeDesc(long ms)
        {
            var desc = "";
            TimeSpan span = new TimeSpan(ms);
            desc = string.Format("{0}:{1:00}:{2:00}.{3:000}", span.Hours, span.Minutes, span.Seconds, span.Milliseconds);
            return desc;
        }
    }
}