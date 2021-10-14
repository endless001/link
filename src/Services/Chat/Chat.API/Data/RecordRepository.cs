using Chat.API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.API.Data
{
    public class RecordRepository : IRecordRepository
    {
        private readonly ChatDbContext _context;
        public RecordRepository(ChatDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddRecordAsync(Record record, CancellationToken cancellationToken)
        {
            await _context.Records.InsertOneAsync(record, null, cancellationToken);
            return true;
        }
    }
}
