using Minio;
using StackExchange.Redis;
using System.IO;
using System.Threading.Tasks;

namespace Upload.API.Infrastructure.Services
{
    public class MinioUploadService : IUploadService
    {
        private readonly MinioClient _client;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public MinioUploadService(MinioClient client, ConnectionMultiplexer redis)
        {
            _client = client; 
            _redis = redis;
            _database = redis.GetDatabase();

        }
        public Task<bool> CompleteMultipartUpload(string objectName, string uploadId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetFileHash(string objectName)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> InitiateMultipartUpload(string objectName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> MultipartUpload(string objectName, string uploadId, Stream content, int index, long size)
        {
            throw new System.NotImplementedException();
        }

        public async  Task<bool> Upload(string objectName, Stream content)
        {
            if (!await _client.BucketExistsAsync(""))
            {
                await _client.MakeBucketAsync("");
            }

            await _client.PutObjectAsync("", objectName, content, content.Length);
            return true;
        }

        public async Task<bool> UploadUserPhoto(string objectName, Stream content)
        {
            if (!await _client.BucketExistsAsync(""))
            {
                await _client.MakeBucketAsync("");
            }

            await  _client.PutObjectAsync("", objectName, content, content.Length);
            return true;
        }
      
    }
}
