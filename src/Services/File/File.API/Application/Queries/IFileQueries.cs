using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.API.Application.Queries
{
    public interface IFileQueries
    {
        Task<IEnumerable<File>> GetFoldersFromUserAsync(int userId, string currentDirectory);
        Task<IEnumerable<File>> GetFilesFromUserAsync(int userId, string currentDirectory);
    }
}
