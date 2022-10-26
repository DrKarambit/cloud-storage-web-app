namespace CloudStorage.ApiModels
{
    public class CreateUpdateCloudFileDto
    {
        public string? Name { get; set; }
        public double Size { get; set; }
        public string? Type { get; set; }
        public byte[]? Content { get; set; }
    }
}
