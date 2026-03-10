import { ChangeDetectorRef, Component } from '@angular/core';
import { NewsService } from '../../services/news';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-analyze',
  imports: [CommonModule, FormsModule],
  templateUrl: './analyze.html',
  styleUrl: './analyze.css',
})
export class Analyze {
  articleText = '';
  prediction = '';
  confidence = 0;
  loading = false;

  constructor(private newsService: NewsService,
    private cdr: ChangeDetectorRef
  ) {}

  // Map model labels → human-readable
  private mapLabel(label: string): string {
    const map: Record<string, string> = {
   LABEL_0: 'FAKE',   // jy46604790 model convention
    LABEL_1: 'REAL',
   
    };
    return map[label?.toUpperCase()] ?? label;
  }

  get isFake(): boolean {
    return this.prediction === 'FAKE';
  }

  get confidencePercent(): string {
    return (this.confidence * 100).toFixed(1) + '%';
  }

  analyzeNews() {
    if (!this.articleText.trim()) return;
    this.loading = true;
    this.prediction = '';

    this.newsService.analyze(this.articleText).subscribe((res: any) => {
      console.log('Backend Response:', res);
      console.log('Prediction:', res.prediction);
      console.log('Confidence:', res.confidence);

      this.prediction = this.mapLabel(res.prediction);
      this.confidence = res.confidence;
      this.loading = false;
       this.cdr.detectChanges();
    });
  }
}