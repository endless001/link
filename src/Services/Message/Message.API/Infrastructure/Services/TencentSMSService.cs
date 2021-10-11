using Message.API.Configuration;
using Message.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Message.API.Infrastructure.Services
{
    public class TencentSMSService : ISMSService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private TencentSMSConfig _tencentSMSConfig;


        public TencentSMSService(IHttpClientFactory httpClientFactory, TencentSMSConfig tencentSMSConfig)
        {
            _httpClientFactory = httpClientFactory;
            _tencentSMSConfig = tencentSMSConfig;
        }
        public async Task<bool> SendSMS(string phone, int nationCode, int templateId, IEnumerable<string> content)
        {

            var random = GetRandom();
            var httpClient = _httpClientFactory.CreateClient();
            var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            var keys = new Dictionary<string, object>()
            {
                {"ext","" },
                {"extend","" },
                {"params",content },
                {"sig",ComputeSignature(phone,random,timestamp)},
                {"sign",_tencentSMSConfig.Sign },
                {"tel",new{ mobile = phone,nationcode = nationCode} },
                {"time",DateTime.Now.DateTimeToTimeStamp()},
                {"tpl_id",templateId}
            };

            var httpContent = new StringContent(JsonSerializer.Serialize(keys), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_tencentSMSConfig.Url}?sdkappid={_tencentSMSConfig.AppId}&random={random}", httpContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<dynamic>(result);
                return data.result == 0;

            }
            return false;
        }

        private string ComputeSignature(string phone, int random, long timestamp)
        {
            var input = $"appkey={_tencentSMSConfig.AppKey}&random={random}&time={timestamp}&mobile={phone}";
            var hasBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hasBytes.Select(b => b.ToString("x2")));

        }
        private int GetRandom()
        {
            return new Random().Next(100000, 999999);
        }
    }
}
