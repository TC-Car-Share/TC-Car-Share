using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models.Request;
using TCCarShare.Models.Response;

namespace TCCarShare.Services
{
    public class MapServices
    {
        /// <summary>
        /// 关键词输入提示
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetSuggestionListResponse GetSuggestionList(GetSuggestionListRequest request)
        {
            var response = new GetSuggestionListResponse() {

            };


            return response;
        }
    }
}
