using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

            var url = $"https://apis.map.qq.com/ws/place/v1/suggestion/?region={request.Region}&keyword={request.Keyword}&location={request.Location}&page_index=1&page_size=5&key={key}";
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
            if (result == null || result.data == null || result.data.Count <= 0)
            {
                response.ResultMsg = "网络异常，请稍后重试";
                return response;
            }

            //实体赋值
            foreach (var item in result.data)
            {
                response.List.Add(new SuggestionList() {
                    Title=item.title,
                    Address=item.address,
                    City=item.city,
                    Province=item.province,
                    Distance=item._distance,
                    Type=item.type,
                    Location=new LocationBaseInfo() {
                        Lat=item.location.lat,
                        Lng=item.location.lng
                    }
                });
            }
            response.StateCode = 200;
            response.ResultMsg = "查询成功";

            return response;
        }
    }
}
