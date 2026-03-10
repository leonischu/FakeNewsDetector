import { Component } from '@angular/core';
import { NewsService } from '../../services/news';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-analyze',
  imports: [CommonModule,FormsModule],
  templateUrl: './analyze.html',
  styleUrl: './analyze.css',
})
export class Analyze {
articleText = '';
prediction = '';
confidence = 0;
loading = false ;

constructor(private newsService:NewsService){}

analyzeNews() {
  if(!this.articleText) return;
  this.loading = true;
  this.newsService.analyze(this.articleText).subscribe(
    (res:any) =>{

            // 🔎 LOG FULL RESPONSE FROM BACKEND
        console.log("Backend Response:", res);

        // 🔎 Log individual fields
        console.log("Prediction:", res.prediction);
        console.log("Confidence:", res.confidence);
      this.prediction = res.prediction;
      this.confidence = res.confidence;
      this.loading = false;
      // console.log(this.prediction);


    }
  );
}

}
