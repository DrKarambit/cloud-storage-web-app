public class GetGuidModel
{
    public Guid ShareLink { get; private set; }
    public Guid FileID { get; private set; }
    public string FileName { get; private set; }      
    public string FileType { get; private set; }
    public double FileSize { get; private set; }   

    public GetGuidModel (Guid shareLink, Guid fileId, string fileName, string fileType, double fileSize)
    {
        ShareLink= shareLink;
        FileID= fileId;
        FileName= fileName;
        FileType= fileType;
        FileSize= fileSize;
    }
}
