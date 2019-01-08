using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace GetPost
{
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
    public class JsonStrDel
    {
        
        public JsonInfo WeatherMessage;
        public void DataDel(string jsonMessage )
        {
            //反序列化
            WeatherMessage=JsonConvert.DeserializeObject<JsonInfo>(jsonMessage);
        }
    }
}