using File.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.AggregatesModel
{
    public interface IFileRepository : IRepository<File>
    {
        Task<File> GetAsync(int id);
        Task<File> GetAsync(string fileHash);
        File Add(File file);
        File Update(File file);
    }
}
