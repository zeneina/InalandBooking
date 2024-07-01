// search.component.ts
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Country {
  name: string;
  capital: string;
  population: number;
}

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  searchTerm!: string;
  countries: Country[] = [];

  constructor(private http: HttpClient) {}

  searchCountries() {
    if (!this.searchTerm) {
      console.log('Please enter a search term.');
      return;
    }

    const searchUrl = `https://restcountries.com/v3.1/name/${this.searchTerm}`;
    this.http.get<Country[]>(searchUrl).subscribe(
      data => {
        this.countries = data;
      },
      error => {
        console.error('Error searching countries:', error);
      }
    );
  }
}
