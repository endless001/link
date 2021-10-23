using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.ViewModels;

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
            _remoteServiceBaseUrl = $"{_settings.Value.ContactUrl}/api/v1/contact/";
        }

        public async Task<IEnumerable<ContactViewModel>> GetContacts()
        {
            var uri = API.Contact.GetContactList(_remoteServiceBaseUrl);
            var response = await _httpClient.GetStringAsync(uri);

            var contacts = JsonSerializer.Deserialize<List<ContactViewModel>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return contacts;
        }
    }
}
