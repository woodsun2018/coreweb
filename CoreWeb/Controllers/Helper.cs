using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helper
{

    #region Http辅助类

    public static class HttpContextExtension
    {
       //获取服务器环境信息
        public static Dictionary<string, string> GetWebInfo(this HttpContext context)
        {
            Dictionary<string, string> webInfoes = new Dictionary<string, string>();

            webInfoes["Environment"] = "==============================";
            webInfoes["DateTime.Now"] = $"{DateTime.Now:F}";
            webInfoes["CurrentDirectory"] = $"{Environment.CurrentDirectory}";
            webInfoes["CurrentManagedThreadId"] = $"{Environment.CurrentManagedThreadId}";
            webInfoes["MachineName"] = $"{Environment.MachineName}";
            webInfoes["OSVersion"] = $"{Environment.OSVersion}";
            webInfoes["ProcessorCount"] = $"{Environment.ProcessorCount}";
            webInfoes["UserName"] = $"{Environment.UserName}";
            webInfoes["Version"] = $"{Environment.Version}";
            webInfoes["WorkingSet"] = $"{Environment.WorkingSet:N0}";

            webInfoes["Request"] = "==============================";
            webInfoes["ContentType"] = $"{context.Request.ContentType}";
            webInfoes["Host"] = $"{context.Request.Host}";
            webInfoes["Path"] = $"{context.Request.Path}";
            webInfoes["Protocol"] = $"{context.Request.Protocol}";
            webInfoes["Scheme"] = $"{context.Request.Scheme}";
            webInfoes["GetClientIP"] = $"{context.Request.GetClientIP()}";

            webInfoes["HttpContext.Connection"] = "==============================";
            webInfoes["LocalIpAddress"] = $"{context.Connection.LocalIpAddress}";
            webInfoes["LocalPort"] = $"{context.Connection.LocalPort}";
            webInfoes["RemoteIpAddress"] = $"{context.Connection.RemoteIpAddress}";
            webInfoes["RemotePort"] = $"{context.Connection.RemotePort}";

            return webInfoes;
        }

    }//HttpContextExtension

    #endregion

    #region 获取客户端真实IP

    public static class HttpRequestExtension
    {
        //获取客户端IP地址;这里通过了Nginx获取;X-Real-IP
        public static String GetClientIP(this HttpRequest request)
        {
            String fromSource = "X-Real-IP";
            String ip = request.Headers.FirstOrDefault(x => x.Key == fromSource).Value;
            if (string.IsNullOrWhiteSpace(ip) || (ip.ToLower() == "unknown"))
            {
                fromSource = "X-Forwarded-For";
                ip = request.Headers.FirstOrDefault(x => x.Key == fromSource).Value;
            }
            if (string.IsNullOrWhiteSpace(ip) || (ip.ToLower() == "unknown"))
            {
                fromSource = "Proxy-Client-IP";
                ip = request.Headers.FirstOrDefault(x => x.Key == fromSource).Value;
            }
            if (string.IsNullOrWhiteSpace(ip) || (ip.ToLower() == "unknown"))
            {
                fromSource = "WL-Proxy-Client-IP";
                ip = request.Headers.FirstOrDefault(x => x.Key == fromSource).Value;
            }
            if (string.IsNullOrWhiteSpace(ip) || (ip.ToLower() == "unknown"))
            {
                fromSource = "request.HttpContext.Connection.RemoteIpAddress";
                ip = request.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            return ip;
        }
    }

    #endregion

}
