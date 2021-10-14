using Chat.API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.API.Data
{
    public interface IRecordRepository
    {
        Task<bool> AddRecordAsync(Record record, CancellationToken cancellationToken);
    }
}
