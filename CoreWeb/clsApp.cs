using System;

namespace CoreWeb
{
    //应用程序类
    public class MyApp
    {
        //产品型号
        public readonly string ProductType = "CoreWeb";

        //软件版本
        public readonly string SoftVersion = "1.00.05";

        //开始运行时间
        public DateTime StartTime { get; private set; }

        //初始化
        public void Init()
        {
            //开始运行时间
            StartTime = DateTime.Now;
        }

    }//MyApp

}
