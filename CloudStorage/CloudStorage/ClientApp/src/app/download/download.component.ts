import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetGUID } from '../repositories/cloud-files.model';
import { GenericHttpService } from '../repositories/generic-http-service';
import { CloudFilesComponent } from '../cloud-files/cloud-files.component';


@Component({
  selector: 'app-download',
  templateUrl: './download.component.html',

})
export class DownloadComponent implements OnInit, OnDestroy {
  private sub: any;
  public sharedFile = new Array<GetGUID>();

  constructor(
    private route: ActivatedRoute,
    private _cloudFileComponent: CloudFilesComponent,
    private _genericHttpService: GenericHttpService) {}


  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      var shareLink = params['route'];

      this._genericHttpService.GetGUID<GetGUID>(shareLink)
        .subscribe((result) => {
          this.sharedFile.push(result);
          this.sharedFile = [...this.sharedFile];
        });
    })
  }

  public DataTableOnActivate(event: any): void {
  }

  public OnTableContextMenu(event: any): void {
    event.event.preventDefault();
    event.event.stopPropagation();
  }

  public ShareLinkDownload(fileID: string, fileName: string) {
    this._cloudFileComponent.DownloadFile(fileID, fileName);
  }


  ngOnDestroy() {
    this.sub.unsubscribe(); 
  }
}
