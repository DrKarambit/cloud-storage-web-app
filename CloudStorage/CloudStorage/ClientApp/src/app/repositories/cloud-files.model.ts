export class CloudFile
{
  id: string | undefined;
  name: string | undefined;
  size: number | undefined;
  type : string | undefined;
  creationDateTime: Date | undefined;
  sharingLink: string | undefined;
  content: string | undefined;
  
}

export class CreateUpdateCloudFileDto
{
  name: string | undefined;
  size: number | undefined;
  type : string | undefined;
  content?: string;
}

export class RemoveFile
{
  id: string | undefined;
}

export class UpdateLink
{
  id: string | undefined;
  isNull: boolean | undefined;
}

export class GetGUID
{
  shareLink: string | undefined;
  fileID?: string ;
  fileName?: string;
  fileType?: string;
  fileSize?: number;
}
