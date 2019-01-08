# 获取天气数据C#
#### 利用HttpClient的GetAsync方法
---
+ 发送http请求并获取数据
```csharp
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
 ```
 + json数据的转化为本地对象  
    1. 引入处理json的package:Newtonsoft.Json
    2. 建立包含json相同数据相同的属性类
    ```csharp
     //报文结构状态
    public class JsonInfo
    {
        public DateTime time { get; set; }
        public CityInfo cityinfo { get; set; }
        public string date { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public Data data { get; set; }
    }
    #region 详细数据
    //城市信息
    public class CityInfo
    {
        public string city { get; set; }
        public string cityId { get; set; }
        public string parent { get; set; } 
        public string upadataTime { get; set; }
    }
    //今天信息
    public class Data
    {
        public string shidu { get; set; }
        public string pm25 { get; set; }
        public string pm10 { get; set; }
        public string quality { get; set; }
        public string wendu { get; set; }
        public string ganmao { get; set; }
        public WeatherData yesterday { get; set; }
        public List<WeatherData> forecast { get; set; }

    }
    //预测信息
    public class WeatherData
    {
       
        public string date { get; set; }
        public string sunrise { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        //空气污染指数
        public string aqi { get; set; }
        public DateTime ymd { get; set; }
        public string week { get; set; }
        //风向
        public string fx { get; set; }
        //风级
        public string fl { get; set; }
        //天气
        public string type { get; set; }
        //提醒
        public string notice { get; set; }
    }
    #endregion
     ```
     3. 转化成对象：
     ```csharp
     public class JsonStrDel
    {
        
        public JsonInfo WeatherMessage;
        public void DataDel(string jsonMessage )
        {
            //反序列化
            WeatherMessage=JsonConvert.DeserializeObject<JsonInfo>(jsonMessage);
        }
    }
     ```
