import { Component, OnInit } from '@angular/core';
import { SuggestionsService } from '../../services/suggestions.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-suggestions',
  templateUrl: './suggestions.component.html',
  styleUrls: ['./suggestions.component.css']
})
export class SuggestionsComponent implements OnInit {

    constructor(private suggestionService: SuggestionsService,
        private router: Router) { }
    Save(f) {
        this.suggestionService.AddSuggestion(f.value)
            .subscribe(a => {
                this.router.navigate(['/']);
            });
    }
  ngOnInit(): void {
  }

}
