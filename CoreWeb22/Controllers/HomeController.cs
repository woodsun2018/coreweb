using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWeb22.Models;
using Microsoft.Extensions.Logging;
using Helper;

namespace CoreWeb22.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogDebug($"{DateTime.Now}, Get work infomation");

            //获取服务器环境信息
            Dictionary<string, string> model = HttpContext.GetWebInfo();

            model["WorkInfo"] = "==============================";
            model["RunTimeInfo"] = MyRunTimeInfo();
            model["ProcessInfo"] = GetProcessInfo();

            return View(model);
        }

        //软件运行时间信息
        public string MyRunTimeInfo()
        {
            TimeSpan runTime = DateTimeOffset.Now.Subtract(Program.StartTime);

            string msg = $"运行时间 {runTime.Days:0}天 {runTime.Hours:00}:{runTime.Minutes:00}:{runTime.Seconds:00}";

            return msg;
        }

        //获取进程信息
        public string GetProcessInfo()
        {
            Process process = Process.GetCurrentProcess();

            string processInfo = $"内存 {process.WorkingSet64:N0} / 峰值{process.PeakWorkingSet64:N0}, 线程 {process.Threads.Count}, 句柄 {process.HandleCount}";

            return processInfo;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
