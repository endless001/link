using File.Domain.SeedWork;

namespace File.Domain.AggregatesModel
{

    public class FileAddress : Entity
    {
        public string FileHash{ get; set; }
        public string AddressPath { get; set; }
    }
}
