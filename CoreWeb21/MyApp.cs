using System;

namespace CoreWeb21
{
    //应用程序类
    public class MyApp
    {
        //产品型号
        public readonly string ProductType = "CoreWeb21";

        //软件版本
        public readonly string SoftVersion = "1.00.07";

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
