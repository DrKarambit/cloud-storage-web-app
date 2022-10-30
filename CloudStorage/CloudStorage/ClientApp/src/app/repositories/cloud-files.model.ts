export class CloudFile
{
    id: string | undefined;
    name: string | undefined;
    size: number | undefined;
    type : string | undefined;
    creationDateTime : Date | undefined;
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
