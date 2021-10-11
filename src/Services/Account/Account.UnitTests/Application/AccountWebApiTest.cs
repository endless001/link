using Xunit;
using Account.API.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Account.API.Services;
using System.Threading.Tasks;

namespace Account.UnitTests.Application
{
    public class AccountWebApiTest
    {
        private readonly Mock<ILogger<AccountController>> _loggerMock;
        private readonly Mock<IAccountService> _accountServiceMock;
        public AccountWebApiTest()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _loggerMock = new Mock<ILogger<AccountController>>();
        }

        [Fact]
        public Task Get_account_success()
        {
            return Task.CompletedTask;
        }
    }
}
