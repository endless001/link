using System.Threading.Tasks;
using Account.API.Models;
using Account.API.Services;
using Grpc.Core;


namespace Account.API.Grpc
{
    public class AccountGrpcService : AccountGrpc.AccountGrpcBase
    {
        private readonly IAccountService _accountService;
        public AccountGrpcService(IAccountService accountService)
        {
            _accountService = accountService;;
        }

        public override async Task<AccountResponse> CheckOrCreate(AccountRequest request, ServerCallContext context)
        {
            var account=  await _accountService.CheckOrCreateAsync(request.Phone);
            if (account != null)
            {
                return MapResponse(account);
            }

            context.Status = new Status(StatusCode.NotFound, $"account with id {request.AccountId} do not exist");
            return null;
        }

        public override async Task<AccountResponse> RegisterEmail(AccountRequest request, ServerCallContext context)
        {
            var account = MapRequest(request);
            await _accountService.RegisterEmailAsync(account);
            return new AccountResponse { };
        }

        public override async Task<AccountResponse> RegisterPhone(AccountRequest request, ServerCallContext context)
        {
            var account = MapRequest(request);
            await _accountService.RegisterPhoneAsync(account);
            return new AccountResponse { };
        }

        public override async Task<AccountResponse> Search(AccountRequest request, ServerCallContext context)
        {
            var account = await _accountService.SearchAsync(request.Phone);
            if (account != null)
            {
                return MapResponse(account);
            }

            context.Status = new Status(StatusCode.NotFound, $"account with id {request.AccountId} do not exist");
            return null;
        }

        public override async Task<AccountResponse> SignInPassword(AccountRequest request, ServerCallContext context)
        {
            var account = await _accountService.SignInPasswordAsync(request.AccountName, request.Password);
            if (account != null)
            {
                return MapResponse(account);
            }
            context.Status = new Status(StatusCode.NotFound, $"account with id {request.AccountId} do not exist");
            return null;
        }

        private AccountResponse MapResponse(AccountModel  account)
        {
            return new AccountResponse()
            {
                AccountId = account.AccountId,
                Avatar = account.Avatar ?? string.Empty,
                AccountName = account.AccountName ?? string.Empty,
                Email = account.Email ?? string.Empty,
                Phone = account.Phone ?? string.Empty,
                Sex = account.Sex,
                Tel = account.Tel ?? string.Empty
            };
        }

        private AccountModel MapRequest(AccountRequest account)
        {
            return new AccountModel()
            {
                AccountId = account.AccountId,
                Password = account.Password,
                Avatar = account.Avatar ?? string.Empty,
                AccountName = account.AccountName ?? string.Empty,
                Email = account.Email ?? string.Empty,
                Phone = account.Phone ?? string.Empty,
                Sex = account.Sex,
                Tel = account.Tel ?? string.Empty
            };
        }
    }
}
