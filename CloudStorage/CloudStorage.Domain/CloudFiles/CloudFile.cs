namespace CloudStorage.Domain.CloudFiles
{
    public class CloudFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public string Type { get; set; }
        public DateTime CreationDateTime { get; set; }
        public byte[] Content { get; set; }

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
