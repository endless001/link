using System;
using System.Collections.Generic;
using System.Linq;
using File.Domain.Exceptions;
using File.Domain.SeedWork;

namespace File.Domain.AggregatesModel
{
    public class FileStatus : Enumeration
    {
        public static FileStatus Deleted = new FileStatus(-1, nameof(Deleted).ToLowerInvariant());
        public static FileStatus Normal = new FileStatus(1, nameof(Normal).ToLowerInvariant());
        public FileStatus(int id, string name)
             : base(id, name)
        {

        }

        private static IEnumerable<FileStatus> List() =>
            new[] { Deleted, Normal };

        public static FileStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new FileDomainException($"Possible values for FileStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static FileStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new FileDomainException($"Possible values for FileStatus: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
