using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.API.Application.Queries
{
    public class FileQueries : IFileQueries
    {
        private readonly string _connectionString = string.Empty;

        public FileQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task<IEnumerable<File>> GetFilesFromUserAsync(int userId, string currentDirectory)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<File>(@"SELECT file_name,file_hash,is_directory
                    FROM file
                    WHERE user_id=@userId and parent_path=@currentDirectory", new { userId, currentDirectory });
            }
        }

        public async Task<IEnumerable<File>> GetFoldersFromUserAsync(int userId, string currentDirectory)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<File>(@"SELECT file_name as filename FROM file WHERE user_id=@userId AND parent_path=@currentDirectory
                        AND isdirectory=1 GROUP BY file_name", new { userId, currentDirectory });
            }
        }
    }
}
