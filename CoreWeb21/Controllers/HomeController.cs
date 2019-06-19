using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWeb21.Models;
using Microsoft.Extensions.Logging;
using Helper;

namespace CoreWeb21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        //应用程序对象
        private readonly MyApp _myApp;

        public HomeController(ILogger<HomeController> logger, MyApp myApp)
        {
            _logger = logger;
            _myApp = myApp;
        }

        public IActionResult Index()
        {
            _logger.LogDebug($"{DateTime.Now}, Get work infomation");

            //获取服务器环境信息
            Dictionary<string, string> model = HttpContext.GetWebInfo();

            model["WorkInfo"] = "==============================";
            model["BasicInfo"] = MyBasicInfo();
            model["RunTimeInfo"] = MyRunTimeInfo();
            model["ProcessInfo"] = GetProcessInfo();

            return View(model);
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = "这是一个测试网站。";

            //故意引发异常，页面提示错误，不会退出软件
            string msg = null;
            int len = msg.Length;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            //模拟软件异常结束，页面提示错误，不会退出软件
            //Thread.CurrentThread.Abort();

            //模拟软件异常结束，页面无法访问，软件退出
            Environment.Exit(0);

            return View();
        }

        //软件基本信息
        public string MyBasicInfo()
        {
            string msg = $"{_myApp.ProductType} V{_myApp.SoftVersion}";
            return msg;
        }

        //软件运行时间信息
        public string MyRunTimeInfo()
        {
            TimeSpan runTime = DateTime.Now.Subtract(_myApp.StartTime);

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
