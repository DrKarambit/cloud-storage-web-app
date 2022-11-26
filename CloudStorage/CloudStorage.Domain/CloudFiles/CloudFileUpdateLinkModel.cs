public class CloudFileUpdateLinkModel
{
    public Guid FileID { get; private set; }
    public bool CreateSuccess { get; set; }

    public CloudFileUpdateLinkModel (Guid fileID, bool createSuccess)
    {
        FileID = fileID;
        CreateSuccess = createSuccess;
    }
}
