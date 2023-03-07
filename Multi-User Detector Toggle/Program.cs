using System;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Multi_User_Detector_Toggle
{
    internal class Program
    {
        static string[] useragent = { 
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 OPR/26.0.1656.60",
            "Mozilla/5.0 (X11; U; Linux x86_64; zh-CN; rv:1.9.2.10) Gecko/20100922 Ubuntu/10.10 (maverick) Firefox/3.6.10", 
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36", 
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.11 TaoBrowser/2.0 Safari/536.11",
            "Mozilla/5.0 (Linux; U; Android 9.0; zh-cn; HTC_Wildfire_A3333 Build/FRG83D) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1",
            "MQQBrowser/26 Mozilla/5.0 (Linux; U; Android 2.3.7; zh-cn; MB200 Build/GRJ22; CyanogenMod-7) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1",
            "Mozilla/5.0 (Linux; Android 7.1.1; ONEPLUS A5000) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Mobile Safari/537.36", 
            "Mozilla/5.0 (iPhone; CPU iPhone OS 16_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.1 Mobile/15E148 Safari/604.1",
            "MicroMessenger Client", 
            "Mozilla/5.0 (iPhone; CPU iPhone OS 15_3_1 like Mac OS X; zh-CN) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/19D52 UCBrowser/15.0.5.1847 Mobile/AliApp/TUnionSDK/0.1.20.4", 
            "Mozilla/5.0 (Linux; U; Android 8.0.0; zh-cn; MI 5s Plus Build/OPR1.170623.032) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/61.0.3163.128 Mobile Safari/537.36/XiaoMi/MiuiBrowser/10.4.5",
            "Mozilla/5.0 (linux; android 9; v1816a build/pkq1.180819.001; wv) applewebkit/537.36 (khtml, like gecko) chrome/62.0.3202.84 mobile safari/537.36 vivobrowser/8.1.14.2",
            "Mozilla/5.0 (Linux; Android 11; Redmi Note 8 Pro Build/RP1A.200720.011; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/89.0.4389.72 MQQBrowser/6.2 TBS/045913 Mobile Safari/537.36 V1_AND_SQ_8.8.68_2538_YYB_D A_8086800 QQ/8.8.68.7265 NetType/WIFI WebP/0.3.0 Pixel/1080 StatusBarHeight/76 SimpleUISwitch/1 QQTheme/2971 InMagicWin/0 StudyMode/0 CurrentMode/1 CurrentFontScale/1.0 GlobalDensityScale/0.9818182 AppId/537112567 Edg/98.0.4758.102",
            "Mozilla/5.0 (Linux; Android 11; Redmi Note 8 Pro Build/RP1A.200720.011; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/86.0.4240.99 XWEB/3185 MMWEBSDK/20211001 Mobile Safari/537.36 MMWEBID/6210 MicroMessenger/8.0.16.2040(0x2800105F) Process/toolsmp WeChat/arm64 Weixin NetType/WIFI Language/zh_CN ABI/arm64] Edg/98.0.4758.102"
        };
        static Random rd = new Random();
        static string[] urlstr = {
            "https://120.241.21.112",
            "https://183.192.169.15",
            "https://221.181.99.18",
            "https://117.184.242.106",
            "https://183.192.169.101",
            "https://183.240.80.18",
            "http://120.241.21.112",
            "http://183.192.169.15",
            "http://221.181.99.18",
            "http://117.184.242.106",
            "http://183.192.169.101",
            "http://183.240.80.18"
        };
        static void Main(string[] args)
        {
            Console.WriteLine("按任意键继续，用来测试校园网的，挂后台测试10min出结果");
            Console.ReadKey();
            var handler = new HttpClientHandler() { UseCookies = false };
            var client = new HttpClient(handler);
            //client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36");

            
            for (; ; )
            {
                int i = rd.Next(0,13);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                //client.DefaultRequestHeaders.Add("Host", "dns,weixin.qq.com.cn");
                client.DefaultRequestHeaders.Add("Connection", "close");
                //client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                //client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
                client.DefaultRequestHeaders.Add("Accept-Language", "zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7,zh-CN;q=0.6");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", useragent[8].ToString());
                    //Console.WriteLine("当前检测UA：" + useragent[i].ToString());
                }
                catch (Exception ex)
                {
                    client.DefaultRequestHeaders.Add("User-Agent", useragent[8].ToString());
                    //Console.WriteLine("当前检测UA：" + useragent[1].ToString());
                }
                int a = rd.Next(1000000000, 2000000000);
                int b = rd.Next(1,12);
                var api_url = urlstr[b].ToString();
                //Console.WriteLine(a);
                api_url = $"http://dns.weixin.qq.com.cn/cgi-bin/micromsg-bin/newgetdns?uin={a}&clientversion=671094617&scene=0&net=1&md5=ab6b057d36e6d859bf04ae5d38fdedbf&devicetype=android-27&lan=zh_CN&sigver=2&lasteffecttime=1665374690&xagreementid=0&networkid=93cb20a0629e6d0bb9295549cb586881&networkidctx=Vko%2BH%2FKvjuiL%2B9aoBBSOmbd%2FnXNEJ4a75TYjzrn32x7QZv8qjpikEmg%3D&mccmnc=";
                try{
                    var response = client.GetAsync(api_url).Result;
                }
                catch (Exception e)
                {

                }
                Thread.Sleep(300);
            }
        }
    }
}
