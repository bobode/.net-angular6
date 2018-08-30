import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule, MatProgressBarModule, MatIconModule } from '@angular/material';
import { JokeCardItemComponent } from './joke-card-item/joke-card-item.component';
import { JokeCardListComponent } from './joke-card-list/joke-card-list.component';
@NgModule({
    imports: [
        CommonModule,
        MatCardModule,
        MatProgressBarModule,
        MatIconModule 
    ],
    declarations: [JokeCardItemComponent, JokeCardListComponent],
    exports: [JokeCardItemComponent, JokeCardListComponent]
})
export class JokesModule { }