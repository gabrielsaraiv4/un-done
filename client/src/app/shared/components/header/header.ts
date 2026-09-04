import { Component, input } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.scss'
})
export class Header {
  level = input<number>(1);
  currentXp = input<number>(0);
  xpToNextLevel = input<number>(100);
  coins = input<number>(0);
}