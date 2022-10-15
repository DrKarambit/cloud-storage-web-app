namespace CloudStorage.Domain.CloudFiles
{
    public class CloudFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CloudFile(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
