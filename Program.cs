using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetPost
{
    class GetJson
    {
        //目标链接
        private string APIStr = "http://t.weather.sojson.com/api/weather/city/101030100";
        public async Task<string> HttpGet()
        {
            //转化为url格式
            Uri APIUri = new Uri(APIStr);
            //存储返回的json数据
            string data = null;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //设置访问基址
                    //httpClient.BaseAddress = APIUri;
                    //设置相应时间
                    TimeSpan timeOut = new TimeSpan(0, 0, 30);
                    httpClient.Timeout = timeOut;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    //向服务器发送get请求
                    data = await httpClient.GetStringAsync(APIUri);
                }
            }//超时抓取
            catch(ArgumentOutOfRangeException e)
            {
                return e.Message.ToString();
            }
            return data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string data;
            GetJson getJson = new GetJson();
            data = getJson.HttpGet().Result;
            JsonStrDel jsonStrDel=new JsonStrDel();
            jsonStrDel.DataDel(data);
            jsonStrDel.WeatherMessage.date.ToString();
            Console.WriteLine("Hello World!");
        }
    }
}
