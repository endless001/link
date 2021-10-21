using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace WebMVC.Infrastructure.Services
{
  public class ContactService :IContactService
  {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ContactService> _logger;
        private readonly string _remoteServiceBaseUrl;

        public ContactService(HttpClient httpClient, ILogger<ContactService> logger, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            _logger = logger;
            _remoteServiceBaseUrl = $"{_settings.Value.ContactUrl}/c/api/v1/contact/";
        }
    }
}
