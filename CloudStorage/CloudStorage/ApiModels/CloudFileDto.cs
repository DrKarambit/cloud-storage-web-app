namespace CloudStorage.ApiModels
{
    public class CloudFileDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Size { get; set; }
        public string? Type { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
