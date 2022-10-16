import { Component, OnInit } from '@angular/core';
import { CloudFiles } from '../repositories/cloud-files.model';
import { GenericHttpService } from '../repositories/generic-http-service';

@Component({
  selector: 'app-cloud-files',
  templateUrl: './cloud-files.component.html',
  styleUrls: ['./cloud-files.component.css']
})
export class CloudFilesComponent implements OnInit {

  public cloudFiles: CloudFiles[] | undefined;
  
  constructor(
    private _genericHttpService: GenericHttpService) { }

  ngOnInit(): void 
  {
    this._genericHttpService.Get<CloudFiles[]>().subscribe((result) =>
    {
      console.log(result);
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
}
