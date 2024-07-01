import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {
  currentIndex = 0;
  images = [
    { src: 'assets/image1.jpg', alt: 'Image 1' },
    { src: 'assets/image2.jpg', alt: 'Image 2' },
    { src: 'assets/image3.jpg', alt: 'Image 3' }
  ];

  ngOnInit(): void {
    this.showSlide(this.currentIndex);
    setInterval(() => {
      this.next();
    }, 3000);
  }

  showSlide(index: number) {
    this.currentIndex = index;
  }

  next() {
    if (this.currentIndex < this.images.length - 1) {
      this.currentIndex++;
    } else {
      this.currentIndex = 0;
    }
    this.showSlide(this.currentIndex);
  }

  prev() {
    if (this.currentIndex > 0) {
      this.currentIndex--;
    } else {
      this.currentIndex = this.images.length - 1;
    }
    this.showSlide(this.currentIndex);
  }

  goTo(index: number) {
    this.currentIndex = index;
    this.showSlide(this.currentIndex);
  }
}
