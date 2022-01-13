using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Account.FunctionalTests.Base
{
    class AccountScenarioBase
    {
        private const string ApiUrlBase = "api/v1/basket";
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(AccountScenarioBase))
               .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {

                }).UseStartup<AccountTestsStartup>();

            return new TestServer(hostBuilder);
        }

        public static class Get
        {
            public static string GetBasket(int id)
            {
                return $"{ApiUrlBase}/{id}";
            }
        }

        public static class Post
        {
            public static string Account = $"{ApiUrlBase}/";
        }

    }
}
