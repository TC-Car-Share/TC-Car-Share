using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.Entity.Request;
using TCCarShare.Entity.Response;
using TCCarShare.IServices;
using TCCarShare.Models.Request;
using TCCarShare.Models.Response;

namespace TCCarShare.Services
{
    public class MapServices
    {
        private const string key = "H4RBZ-BEBEU-GDFV7-BLILH-LT4EJ-XWFFP";
        private readonly DataContext _context;
        public MapServices(DataContext context)
        {
            _context = context;
        }
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
            var response = new GetMoneyNumberResponse()
            {
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

        /// <summary>
        /// 路线信息解压
        /// </summary>
        /// <param name="coors"></param>
        /// <returns></returns>
        public List<string> GetlatlngInfoList(List<double> latlngBaseInfo)
        {
            var latlngInfoList = new List<string>();
            latlngInfoList.Add($"{latlngBaseInfo[0]},{latlngBaseInfo[1]}");
            var coors = latlngBaseInfo;
            for (var i = 2; i < coors.Count; i++)
            {
                coors[i] = coors[i - 2] + coors[i] / 1000000;
                if (i % 2 == 1)
                {
                    latlngInfoList.Add($"{latlngBaseInfo[i - 1]},{latlngBaseInfo[i]}");
                }
            };
            //有很多重复的点，节约时间
            return latlngInfoList.Distinct().ToList();
        }

        /// <summary>
        /// 司机获取订单列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetOrderListByDriverResponse GetOrderListByDriver(GetOrderListByDriverRequest request)
        {
            var response = new GetOrderListByDriverResponse()
            {
                StateCode = 201,
                ResultMsg = "查无数据"
            };
            if (request == null || request.FromLat == null || request.FromLat == "" || request.FromLng == "" || request.FromLng == null
                || request.ToLat == null || request.ToLat == "" || request.ToLng == "" || request.ToLng == null || request.Date == null || request.Date == "")
            {
                response.ResultMsg = "请求参数异常，请稍后重试";
                return response;
            }

            //获取所有的符合条件的订单
            var orderList = new OrderServices(_context).GetAllWaiting(new WaitingOrderRequest()
            {
                sex=request.SexType,
                startDate=request.Date,
                isSingle=request.IsSingle                
            });
            if (orderList == null || orderList.Count <= 0)
            {
                response.ResultMsg = "查无数据";
                return response;
            }

            //获取司机路线和距离
            var drivingInfo = GetDrivingInfo(new GetDrivingInfoResquest()
            {
                FromLocation = request.FromLat + "," + request.FromLng,
                ToLocation = request.ToLat + "," + request.ToLng
            });
            if (drivingInfo == null || drivingInfo.status != 0 || drivingInfo.result.routes == null || drivingInfo.result.routes.Count <= 0)
            {
                response.ResultMsg = "查无数据";
                return response;
            }

            List<Task> taskFororders = new List<Task>();
            foreach (var item in orderList)
            {
                taskFororders.Add(Task.Factory.StartNew(() =>
                {
                    var isCan = false;
                    var dis = 0m;
                    if (drivingInfo.result.routes.FirstOrDefault().distance < item.info.distance)
                    {
                        //如果小于乘客，则去查询乘客路线
                        var userInfo = GetDrivingInfo(new GetDrivingInfoResquest()
                        {
                            FromLocation = item.info.startLat + "," + item.info.startLon,
                            ToLocation = item.info.endLat + "," + item.info.endLon
                        });
                        if (userInfo == null || userInfo.status != 0 || userInfo.result.routes == null || userInfo.result.routes.Count <= 0)
                        {
                            return;
                        }

                        var coors = GetlatlngInfoList(userInfo.result.routes.FirstOrDefault().polyline);

                        List<Task> tasks = new List<Task>();
                        var isCan1 = false;
                        var isCan2 = false;
                        var location1 = "";
                        var location2 = "";
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            var result = GetCanTakeitResult(request.FromLat + "," + request.FromLng, coors);
                            isCan1 = result.result;
                            location1 = result.location;
                        }));
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            var result = GetCanTakeitResult(request.ToLat + "," + request.ToLng, coors);
                            isCan2 = result.result;
                            location2 = result.location;
                        }));

                        Task.WhenAll(tasks.ToArray()).Wait();

                        var disInfo = GetDrivingInfo(new GetDrivingInfoResquest()
                        {
                            FromLocation = location1,
                            ToLocation = location2
                        });
                        if (userInfo != null && userInfo.status == 0 && userInfo.result.routes != null && userInfo.result.routes.Count > 0)
                        {
                            dis = userInfo.result.routes.FirstOrDefault().distance;
                        }

                        isCan = isCan1 && isCan2;
                    }
                    else
                    {
                        var coors = GetlatlngInfoList(drivingInfo.result.routes.FirstOrDefault().polyline);
                        List<Task> tasks = new List<Task>();
                        var isCan1 = false;
                        var isCan2 = false;
                        var location1 = "";
                        var location2 = "";
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            var result = GetCanTakeitResult(item.info.startLat + "," + item.info.startLon, coors);
                            isCan1 = result.result;
                            location1 = result.location;
                        }));
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            var result = GetCanTakeitResult(item.info.endLat + "," + item.info.endLon, coors);
                            isCan2 = result.result;
                            location2 = result.location;
                        }));

                        Task.WhenAll(tasks.ToArray()).Wait();

                        var disInfo = GetDrivingInfo(new GetDrivingInfoResquest()
                        {
                            FromLocation = location1,
                            ToLocation = location2
                        });
                        if (disInfo != null && disInfo.status == 0 && disInfo.result.routes != null && disInfo.result.routes.Count > 0)
                        {
                            dis = disInfo.result.routes.FirstOrDefault().distance;
                        }
                        isCan = isCan1 && isCan2;
                    }

                    if (isCan)
                    {
                        response.OrderList.Add(new OrderListByDriver()
                        {
                            Id = item.info.id,
                            SexType = Convert.ToInt32(item.info.sex),
                            IsSingle = Convert.ToInt32(item.extension.isSingle),
                            Date = item.info.startDateTime.ToString("yyyy-MM-dd HH:mm"),
                            FromPlace = item.info.startPoint,
                            Money = item.info.orderAmount,
                            PeopleCount = item.info.passengerNum,
                            ToPlace = item.info.endPoint,
                            PhoneNumber = item.extension.phoneNumber,
                            Name = item.extension.passengerName,
                            Percent = Convert.ToDecimal((dis / item.info.distance).ToString("0.##")) > 95m ? 90m : Convert.ToDecimal((dis / item.info.distance).ToString("0.##"))
                        });
                    }
                }));
            }
            Task.WhenAll(taskFororders.ToArray()).Wait();
            response.OrderList = response.OrderList.OrderByDescending(m => m.Percent).ToList();
            response.StateCode = 200;
            response.ResultMsg = "查询成功";

            return response;
        }     

        /// <summary>
        /// 是否顺路(二分法计算)
        /// </summary>
        /// <param name="resquest"></param>
        /// <returns></returns>
        public (bool result,string location) GetCanTakeitResult(string fromLocation, List<string> latlngBaseInfo)
        {
            int low = 0;
            int high = latlngBaseInfo.Count - 1;
            var disTemp = 1000000m;
            var location = "";
            while (low <= high)
            {
                int middle = (low + high) / 2;
                //距离计算一对多
                var toLoncation = latlngBaseInfo[low] + ";" + latlngBaseInfo[middle] + ";" + latlngBaseInfo[high];
                var url = $"https://apis.map.qq.com/ws/distance/v1/?mode=driving&from={fromLocation}&to={toLoncation}&key={key}";

                var resultPost = new HttpClient().GetAsync(url).Result;
                if (resultPost == null || !resultPost.IsSuccessStatusCode && resultPost.Content == null)
                {
                    break;
                }
                var resultStr = resultPost.Content.ReadAsStringAsync().Result;
                if (resultStr == null || resultStr == "")
                {
                    break;
                }
                var result = JsonConvert.DeserializeObject<Distance>(resultStr);
                if (result == null || result.status != 0 || result.result == null || result.result.elements == null || result.result.elements.Count <= 0)
                {
                    break;
                }

                //取距离最短的两个点
                var points = result.result.elements.OrderBy(m => m.distance).Take(2).ToList();
                //获取最短的距离
                var dis = points.FirstOrDefault().distance;
                if (disTemp > dis)
                {
                    disTemp = dis;
                }
 
                var firstLocation = points[0].to.lat + "," + points[0].to.lng;
                var secondLocation = points[1].to.lat + "," + points[1].to.lng;
                if (firstLocation == latlngBaseInfo[low])
                {
                    location = firstLocation;
                    break;//最短距离已找到，直接结束
                }
                else if (firstLocation == latlngBaseInfo[high])
                {
                    location = firstLocation;
                    break;//最短距离已找到，直接结束
                }
                else if (secondLocation == latlngBaseInfo[low] && firstLocation == latlngBaseInfo[middle])
                {
                    low = low + 1;
                    high = middle - 1;
                }
                else if (secondLocation == latlngBaseInfo[high] && firstLocation == latlngBaseInfo[middle])
                {
                    low = middle + 1;
                    high = high - 1;
                }
            }

            //大于2.5公里都不符合
            return (disTemp < 2500, location);
        }
    }
}
