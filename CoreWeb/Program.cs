using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CoreWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //必须指定端口，否则在Win10命令行运行端口是5000，在CentOS docker运行端口是80
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();
    }
}
