public class CloudFileRemoveModel
{
    public Guid FileID { get; private set; }
    public bool FileRemoveSuccess { get; set; }

    public CloudFileRemoveModel (Guid fileID, bool fileRemoveSuccess)
    {
        FileID = fileID;
        FileRemoveSuccess = fileRemoveSuccess;
    }
}
