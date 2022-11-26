import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit } from '@angular/core';
import { switchMap } from 'rxjs';
import { CloudFile, CreateUpdateCloudFileDto, RemoveFile, UpdateLink, GetGUID } from '../repositories/cloud-files.model';
import { GenericHttpService } from '../repositories/generic-http-service';
import { DownloadService, ProgressStatus, ProgressStatusEnum } from '../repositories/cloud-files-download.service';
import { Injectable } from "@angular/core";
import { UrlSerializer } from '@angular/router';

@Component({
  selector: 'app-cloud-files',
  templateUrl: './cloud-files.component.html',
  styleUrls: ['./cloud-files.component.css']
})

@Injectable({ providedIn: 'root' })
export class CloudFilesComponent implements OnInit{
  public cloudFiles: CloudFile[] | undefined;
  public downloadStatus: EventEmitter<ProgressStatus>;

  constructor(
    private _genericHttpService: GenericHttpService,
    private _downloadService: DownloadService) {
    this.downloadStatus = new EventEmitter<ProgressStatus>();
  }

  ngOnInit(): void {
    this._genericHttpService.Get<CloudFile[]>().subscribe((result) => {
      this.cloudFiles = result;
    });
  }


  public DataTableOnActivate(event: any): void {
  }

  public OnTableContextMenu(event: any): void {
    event.event.preventDefault();
    event.event.stopPropagation();
  }

  public UploadFileInputChange(fileInputEvent: Event): void {
    const maxFileSizeInKilobyte: number = 350;
    const maxFileSizeInByte: number = maxFileSizeInKilobyte * 1024;
    const target: HTMLInputElement = fileInputEvent.target as HTMLInputElement;
    if (target.files) {
      const file: File = target.files[0];

      if (file.size <= maxFileSizeInByte) {
        const reader: FileReader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = (event: ProgressEvent<FileReader>) => {
          let cloudFile = this.GenerateCloudFileFromSelectedFile(file, event);

          this._genericHttpService.Post<CreateUpdateCloudFileDto, any>(cloudFile)
            .pipe(switchMap(() => { return this._genericHttpService.Get<CloudFile[]>() }))
            .subscribe((result) => {
              console.log(result);
              this.cloudFiles = result;
            });
        }
      }
      else {
        const msg = "File size is bigger then the exceptable maximum! Uploaded size: "
          + (file.size / 1024)
          + "KB > "
          + maxFileSizeInKilobyte
          + "KB";
        // TODO: Errorhandling
      }
    }
  }
  
  public DownloadFile(guid: string, fileName: string) {
    this.downloadStatus.emit(
      {
        status: ProgressStatusEnum.START
      });

    this._downloadService.DownloadFile(guid).subscribe(
      data => {
        switch (data.type) {
          case HttpEventType.DownloadProgress:
            {
              this.downloadStatus.emit(
                {
                  status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / (data.total ?? 1)) * 100)
                });

              break;
            }
          case HttpEventType.Response:
            {
              this.downloadStatus.emit(
                {
                  status: ProgressStatusEnum.COMPLETE
                });

              const downloadedFile = new Blob([data.body ?? ""], { type: data.body?.type });
              const a = document.createElement('a');
              a.setAttribute('style', 'display:none;');
              document.body.appendChild(a);
              a.download = fileName;
              a.href = URL.createObjectURL(downloadedFile);
              a.target = '_blank';
              a.click();
              document.body.removeChild(a);

              break;
            }
        }
      }
    );
  }

  public RemoveFile(guid: string): RemoveFile {

    let result = new RemoveFile();
    result.id = guid;

    this._genericHttpService.Delete<RemoveFile, any>(result)
      .pipe(switchMap(() => { return this._genericHttpService.Get<CloudFile[]>() }))
      .subscribe((result) => {
        console.log(result);
        this.cloudFiles = result;
      });
    return result;
  }

  public isEmpty(sharingLink: string) {
    if (sharingLink != null) {
      return false;
    }
    else {
      return true;
    }
  }

  public CreateRemoveShare(guid: string, isNull: boolean): UpdateLink {
    
    let result = new UpdateLink();
    result.id = guid;
    result.isNull = isNull;

      this._genericHttpService.UpdateLink<UpdateLink, any>(result)
        .pipe(switchMap(() => { return this._genericHttpService.Get<CloudFile[]>() }))
        .subscribe((result) => {
          console.log(result);
          this.cloudFiles = result;
        });

    return result;

  }

  public ShowShare(shareLink: string) {
    var baseURL = window.location.protocol + '//' + window.location.host;
    var message = 'A file megosztási linkje: ' + baseURL + '/download/' + shareLink;
    alert(message);

  }

  private GenerateCloudFileFromSelectedFile(file: File, event: ProgressEvent<FileReader>): CreateUpdateCloudFileDto {
    let result = new CreateUpdateCloudFileDto();
    result.name = file.name;
    result.size = file.size;
    result.type = file.type;
    result.content = event?.target?.result?.toString().split(',')[1];
    return result;
  }
}
