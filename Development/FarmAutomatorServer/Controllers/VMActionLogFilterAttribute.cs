using log4net;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
//using VisitMeServer.VisitMeUtils;

namespace FarmAutomatorServer.Controllers
{
    public class VmActionLogFilterAttribute : ActionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(VmActionLogFilterAttribute));

        public override void OnActionExecuting(HttpActionContext context)
        {
            //try
            //{
                // Skip Multipart requests
                //if (context.Request.Headers.Contains("Content-Type") && 
                //    context.Request.Headers.First(h => h.Key == "Content-Type").Value.Any(v => v.ToLower().Contains("multipart")))
                //    return;

                const bool stop = false;
                if(stop)
                    return;

            //    if (!Log.IsDebugEnabled)
            //        return;

            //    var controller = context.ControllerContext.Controller as BaseApiController;
            //    string userId = "<unknown>";
            //    if (controller != null)
            //        userId = controller.GetUserId() ?? userId;

            //    if (context.ControllerContext.ControllerDescriptor.ControllerName == "Account" &&
            //        context.ActionDescriptor.ActionName == "UpdateAvatar" ||
            //        context.ControllerContext.ControllerDescriptor.ControllerName == "Chat" &&
            //        context.ActionDescriptor.ActionName == "AddImage" ||
            //        context.ControllerContext.ControllerDescriptor.ControllerName == "ProductCategory" &&
            //        context.ActionDescriptor.ActionName == "UpdateImage" ||
            //        context.ControllerContext.ControllerDescriptor.ControllerName == "Product" &&
            //        context.ActionDescriptor.ActionName == "UpdateImage")
            //    {
            //        Log.Debug(
            //            "-------------------------------- START ------\n" +
            //            $"VM API Action: userID: {userId} - {context.ControllerContext.ControllerDescriptor.ControllerName}-{context.ActionDescriptor.ActionName}: \n" +
            //            $"Uri: {context.Request.RequestUri}");

            //        return;
            //    }
                
            //    var requestStringTask = context.Request.Content.ReadAsStreamAsync();
            //    requestStringTask.Wait();
            //    Stream stream = requestStringTask.Result;
            //    stream.Seek(0, SeekOrigin.Begin);

            //    //MemoryStream stream = new MemoryStream();
            //    //Task task = context.Request.Content.CopyToAsync(stream);
            //    //Task.WaitAll(task);

            //    byte[] buffer = new byte[stream.Length];
            //    string requestString = "";

            //    if (stream.Length > 0)
            //    {
            //        stream.Read(buffer, 0, buffer.Length);
            //        requestString = Encoding.UTF8.GetString(buffer);
            //    }

            //    Log.Debug(
            //            "-------------------------------- START ------\n" +
            //        $"VM API Action: userID: {userId} - {context.ControllerContext.ControllerDescriptor.ControllerName}-{context.ActionDescriptor.ActionName}: \n" +
            //        $"Uri: {context.Request.RequestUri}\nBody: {requestString}");
            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine(ex.ToString());
            //}
        }

        // override 
        public Task OnActionExecutedAsync_(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            //const bool stop = false;
            //if (stop)
            //    return Task.CompletedTask;

            //if (!Log.IsDebugEnabled)
            //    return Task.CompletedTask;

            //var controller = context.ActionContext.ControllerContext.Controller as BaseApiController;
            //string userId = "<unknown>";
            //if (controller != null)
            //    userId = controller.GetUserId() ?? userId;

            //if (context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName == "Account" &&
            //    context.ActionContext.ActionDescriptor.ActionName == "UpdateAvatar" ||
            //    context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName == "Chat" &&
            //    context.ActionContext.ActionDescriptor.ActionName == "AddImage" ||
            //    context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName == "ProductCategory" &&
            //    context.ActionContext.ActionDescriptor.ActionName == "UpdateImage" ||
            //    context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName == "Product" &&
            //    context.ActionContext.ActionDescriptor.ActionName == "UpdateImage")
            //{
            //    Log.Debug(
            //        "-------------------------------- STOP ------\n" +
            //        $"VM API Action: userID: {userId} - {context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName}" +
            //        $"-{context.ActionContext.ActionDescriptor.ActionName}: \n" +
            //        $"Uri: {context.Request.RequestUri}");

            //    return Task.CompletedTask;
            //}

            //var responseStringTask = context.Response.Content.ReadAsStreamAsync();
            //responseStringTask.Wait(cancellationToken);
            //var stream = responseStringTask.Result;
            //stream.Seek(0, SeekOrigin.Begin);

            ////MemoryStream stream = new MemoryStream();
            ////Task task = context.Request.Content.CopyToAsync(stream);
            ////Task.WaitAll(task);

            //byte[] buffer = new byte[stream.Length];
            //var responseString = "";

            //if (stream.Length > 0)
            //{
            //    stream.Read(buffer, 0, buffer.Length);
            //    responseString = Encoding.UTF8.GetString(buffer);
            //}

            //Log.Debug(
            //    "-------------------------------- STOP ------\n" +
            //    $"VM API Action: userID: {userId} - {context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName}" +
            //    $"-{context.ActionContext.ActionDescriptor.ActionName}: \n" +
            //    $"Uri: {context.Request.RequestUri}\nBody: {responseString}");

            //return Task.CompletedTask;

            return null;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //OnActionExecutedAsync(actionExecutedContext, CancellationToken.None);
        }
    }
}