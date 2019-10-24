using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TCCarShare.Entity.Request;
using TCCarShare.Entity.Response;
using TCCarShare.Models.Request;
using TCCarShare.Models.Response;

namespace TCCarShare.Services
{
    public class MapServices
    {
        private const string key = "H4RBZ-BEBEU-GDFV7-BLILH-LT4EJ-XWFFP";
        /// <summary>
        /// 关键词输入提示
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetSuggestionListResponse GetSuggestionList(GetSuggestionListRequest request)
        {
            var response = new GetSuggestionListResponse()
            {
                StateCode = 201,
                ResultMsg = "查无数据"
            };

            if (request == null || request.Keyword == null || request.Keyword == "")
            {
                response.ResultMsg = "请求参数异常，请稍后重试";
                return response;
            }

            var url = $"https://apis.map.qq.com/ws/place/v1/suggestion/?region={request.Region}&keyword={request.Keyword}&page_index=1&page_size=5&key={key}";
            if (request.Location != null && request.Location != "")
            {
                url += $"location={request.Location}";
            }
            var resultPost = new HttpClient().GetAsync(url).Result;

            if (resultPost == null || !resultPost.IsSuccessStatusCode && resultPost.Content == null)
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }
            var resultStr = resultPost.Content.ReadAsStringAsync().Result;
            if (resultStr == null || resultStr == "")
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }
            var result = JsonConvert.DeserializeObject<Suggestion>(resultStr);
            if (result == null || result.status != 0 || result.data == null || result.data.Count <= 0)
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }

            //实体赋值
            foreach (var item in result.data)
            {
                response.List.Add(new SuggestionList()
                {
                    Title = item.title,
                    Address = item.address,
                    City = item.city,
                    Province = item.province,
                    Distance = item._distance,
                    Type = item.type,
                    Location = new LocationBaseInfo()
                    {
                        Lat = item.location.lat,
                        Lng = item.location.lng
                    }
                });
            }
            response.StateCode = 200;
            response.ResultMsg = "查询成功";

            return response;
        }

        /// <summary>
        /// 逆地址解析
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GeocoderResponse GetAddressBylnglat(GeocoderRequest request)
        {
            var response = new GeocoderResponse()
            {
                StateCode = 201,
                ResultMsg = "查无数据"
            };

            if (request == null || request.Location == null || request.Location == "")
            {
                response.ResultMsg = "请求参数异常，请稍后重试";
                return response;
            }

            var url = $"https://apis.map.qq.com/ws/geocoder/v1/?location={request.Location}&key={key}";
            var resultPost = new HttpClient().GetAsync(url).Result;

            if (resultPost == null || !resultPost.IsSuccessStatusCode && resultPost.Content == null)
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }
            var resultStr = resultPost.Content.ReadAsStringAsync().Result;
            if (resultStr == null || resultStr == "")
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }
            var result = JsonConvert.DeserializeObject<Geocoder>(resultStr);
            if (result == null || result.status != 0 || result.result == null || result.result.location == null)
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }

            response.Address = result.result.address;
            response.Lat = result.result.location.lat;
            response.Lng = result.result.location.lng;
            response.StateCode = 200;
            response.ResultMsg = "查询成功";

            return response;
        }

        /// <summary>
        /// 获取路线金额
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetMoneyNumberResponse GetMoneyNumber(GetMoneyNumberResquest request)
        {
            var response = new GetMoneyNumberResponse() {
                StateCode = 201,
                ResultMsg = "查无数据"
            };
            if (request == null || request.FromLocation == null || request.FromLocation == "" || request.ToLocation == null || request.ToLocation == "")
            {
                response.ResultMsg = "请求参数异常，请稍后重试";
                return response;
            }
            var param = new GetDrivingInfoResquest()
            {
                FromLocation = request.FromLocation,
                ToLocation = request.ToLocation
            };
            var result = GetDrivingInfo(param);
            if (result == null)
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }
            response.StateCode = 200;
            response.ResultMsg = "查询成功";
            response.Money = result.result.routes.FirstOrDefault().taxi_fare.fare;

            return response;
        }

        /// <summary>
        /// 获取路线规划信息(api只会出一条数据)
        /// </summary>
        /// <param name="resquest"></param>
        /// <returns></returns>
        public GetDrivingInfoResponse GetDrivingInfo(GetDrivingInfoResquest resquest)
        {
            var url = $"https://apis.map.qq.com/ws/direction/v1/driving/?from={resquest.FromLocation}&to={resquest.ToLocation}" +
                $"&output=json&callback=cb&key={key}";
            var resultPost = new HttpClient().GetAsync(url).Result;

            if (resultPost == null || !resultPost.IsSuccessStatusCode && resultPost.Content == null)
            {
                return null;
            }
            var resultStr = resultPost.Content.ReadAsStringAsync().Result;
            if (resultStr == null || resultStr == "")
            {
                return null;
            }
            var result = JsonConvert.DeserializeObject<GetDrivingInfoResponse>(resultStr);
            if (result == null || result.status != 0 || result.result == null || result.result.routes == null || result.result.routes.Count <= 0)
            {
                return null;
            }

            return result;
        }


    }
}
