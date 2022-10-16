import { Component, OnInit } from '@angular/core';
import { FussballDeClientService } from './services/fussball-de-client.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'fussball-de-matchplan-ripper';

  constructor(private readonly _fussballDeService: FussballDeClientService) {}

  ngOnInit(): void {
    this._fussballDeService
      .getTeamOverviewPage('https://www.google.com/search?q=bypass')
      .subscribe((x) => console.log(x));
  }
}
