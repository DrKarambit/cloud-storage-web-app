namespace CloudStorage.Domain.CloudFiles
{
    public class CloudFile
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Size { get; private set; }
        public string Type { get; private set; }
        public DateTime CreationDateTime { get; private set; }
        public byte[] Content { get; private set; }

        public CloudFile(string name, double size, string type, byte[] content)
        {
            Id = Guid.NewGuid();
            Name = name;
            Size = size;
            Type = type;
            CreationDateTime = DateTime.Now;
            Content = content;
        }
    }
}
