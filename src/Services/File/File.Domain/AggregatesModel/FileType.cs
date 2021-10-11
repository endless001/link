using File.Domain.Exceptions;
using File.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.AggregatesModel
{

    public class FileType : Enumeration
    {
        public static FileType Music = new FileType(1, nameof(Music).ToLowerInvariant());
        public static FileType Video = new FileType(2, nameof(Video).ToLowerInvariant());
        public static FileType Image = new FileType(3, nameof(Image).ToLowerInvariant());
        public static FileType Other = new FileType(10, nameof(Other).ToLowerInvariant());
        public FileType(int id, string name)
             : base(id, name)
        {

        }

        private static IEnumerable<FileType> List() =>
            new[] { Music, Video, Image, Other };

        public static FileType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new FileDomainException($"Possible values for FileType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static FileType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new FileDomainException($"Possible values for FileType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
