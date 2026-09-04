import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from './shared/components/sidebar/sidebar';
import { Header } from './shared/components/header/header';
import { PageTitleService } from './core/services/page-title';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Sidebar, Header],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  constructor(protected pageTitle: PageTitleService) {}
}