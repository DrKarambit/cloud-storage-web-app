public class CloudFileDownloadModel
{
    public MemoryStream Stream { get; private set; }
    public string ContentType { get; private set; }
    public string FileName { get; private set; }
    public bool FileGenerationSuccess { get; set; }

    public CloudFileDownloadModel(MemoryStream stream, string contentType, string fileName, bool fileGenerationSuccess)
    {
        Stream = stream;
        ContentType = contentType;
        FileName = fileName;
        FileGenerationSuccess = fileGenerationSuccess;
    }
}