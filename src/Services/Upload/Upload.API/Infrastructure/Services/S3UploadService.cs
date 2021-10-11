using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Upload.API.Infrastructure.Services
{
    public class S3UploadService : IUploadService
    {
        private readonly AmazonS3Client _awsClient;

        public S3UploadService(AmazonS3Client awsClient)
        {
            _awsClient = awsClient;
        }

        public async Task<bool> CompleteMultipartUpload(string objectName, string uploadId)
        {
            var completeMultipartUploadRequest = new CompleteMultipartUploadRequest();
            await _awsClient.CompleteMultipartUploadAsync(completeMultipartUploadRequest);
            return true;
        }

        public async Task<string> GetFileHash(string objectName)
        {
           return (await _awsClient.GetObjectAsync("",objectName)).ETag;
        }

        public async Task<string> InitiateMultipartUpload(string objectName)
        {
            var result = await _awsClient.InitiateMultipartUploadAsync("", "");
            return result.UploadId;
        }

        public async Task<bool> MultipartUpload(string objectName, string uploadId, Stream content, int index, long size)
        {
            var request = new UploadPartRequest()
            {
                InputStream = content,
                PartSize = size,
                PartNumber = index + 1,
            };
            await _awsClient.UploadPartAsync(request);
            return true;
        }

        public async Task<bool> Upload(string objectName, Stream content)
        {
            var request = new PutObjectRequest()
            {
                BucketName = objectName,
                CannedACL = S3CannedACL.PublicRead,
                Key = $"UPLOADS/{objectName}",
                InputStream = content
            };
            await _awsClient.PutObjectAsync(request);
            return true;
        }

        public async Task<bool> UploadUserPhoto(string objectName, Stream content)
        {
            var request = new PutObjectRequest()
            {
                BucketName = objectName,
                CannedACL = S3CannedACL.PublicRead,
                Key = $"UPLOADS/{objectName}",
                InputStream = content
            };
            await _awsClient.PutObjectAsync(request);
            return true;
        }

        private async Task CreateBucket(string bucketName)
        {
            await _awsClient.PutBucketAsync(bucketName);

        }
        private async Task<bool> BucketExist(string bucketName)
        {
            var buckets = (await _awsClient.ListBucketsAsync()).Buckets;
            return buckets.Any(b => b.BucketName == bucketName);
        }
    }
}
