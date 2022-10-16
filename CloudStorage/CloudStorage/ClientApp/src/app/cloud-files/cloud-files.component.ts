import { Component, OnInit } from '@angular/core';
import { switchMap } from 'rxjs';
import { CloudFile } from '../repositories/cloud-files.model';
import { GenericHttpService } from '../repositories/generic-http-service';

@Component({
  selector: 'app-cloud-files',
  templateUrl: './cloud-files.component.html',
  styleUrls: ['./cloud-files.component.css']
})
export class CloudFilesComponent implements OnInit 
{
  public cloudFiles: CloudFile[] | undefined;
  
  constructor(
    private _genericHttpService: GenericHttpService) { }

  ngOnInit(): void 
  {
    this._genericHttpService.Get<CloudFile[]>().subscribe((result) =>
    {
      this.cloudFiles = result;
    });
  }

  
  public DataTableOnActivate(event: any): void
  {
  }

  public OnTableContextMenu(event: any): void
  {
    event.event.preventDefault();
    event.event.stopPropagation();
  }

  public UploadFileInputChange(fileInputEvent: Event): void
  {
    const maxFileSizeInKilobyte: number = 350;
    const maxFileSizeInByte: number = maxFileSizeInKilobyte * 1024;
    const target: HTMLInputElement = fileInputEvent.target as HTMLInputElement;
    if (target.files)
    {
      const file: File = target.files[0];

      if (file.size <= maxFileSizeInByte)
      {
        const reader: FileReader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = (event: ProgressEvent<FileReader>) =>
        {
          let cloudFile = this.GenerateCloudFileFromSelectedFile(file, event);

          this._genericHttpService.Post<any, CloudFile>(cloudFile)
            .pipe(switchMap(() => { return this._genericHttpService.Get<CloudFile[]>()}))
            .subscribe((result) =>
            {
              console.log(result);
              this.cloudFiles = result;
            });
        }
      }
      else
      {
        const msg = "File size is bigger then the exceptable maximum! Uploaded size: "
            + (file.size / 1024)
            + "KB > "
            + maxFileSizeInKilobyte
            + "KB";
        // TODO: Errorhandling
      }
    }
  }

  private GenerateCloudFileFromSelectedFile(file: File, event: ProgressEvent<FileReader>) : CloudFile
  {
    let result = new CloudFile();
    result.name= file.name;
    result.size = file.size;
    result.type = file.type;
    result.creationDateTime = new Date();   // TODO!
    result.content = event?.target?.result?.toString().split(',')[1];
    return result;
  }
}
