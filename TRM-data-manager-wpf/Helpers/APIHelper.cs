using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TRM_data_manager_wpf.Models;

namespace TRM_data_manager_wpf.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient { get; set; }
        public APIHelper()
        {
            InitializeClient();
        }
        private void InitializeClient()
        {
            // 컴파일할 때 App.config에 있는 api로 기존 설정을 override 한다.
            string api = ConfigurationManager.AppSettings["api"];

            // ApiClient로 API를 호출하면 로그인 정보에 따라 토큰을 반환한다.
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // await을 쓰기 위해 async Task 반환. async Task는 void를 리턴함.
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            // API endpoint로 보낼 데이터
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            using (HttpResponseMessage response = await apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    // ReasonPhrase: 왜 fail인지 response를 출력한다.
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
