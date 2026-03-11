🗞️ Fake News Detector
                      
    An AI-powered full-stack web application that analyzes news articles and classifies them as Real or Fake using a BERT-based NLP model from HuggingFace.

📸 Screenshots
            
            Home
![Home Screenshot](https://github.com/user-attachments/assets/89f53d19-97d2-4556-bf8c-ad14b146efae)



          
          Result
![Result Screenshot](https://github.com/user-attachments/assets/3d76e2d3-0fdf-4150-8bec-d2bc5fd2aa8a)


🚀 Tech Stack

    LayerTechnologyFrontendAngular + Tailwind CSSBackend.NET Web API (C#)AI Modeljy46604790/Fake-News-Bert-Detect via HuggingFaceHTTP ClientNewtonsoft.Json + HttpClient

🤖 AI Model

            Model: jy46604790/Fake-News-Bert-Detect
            Base: RoBERTa (fine-tuned on 40,000+ news articles)
            Dataset: ISOT Fake News Dataset (2016–2017)
            Label Mapping
            LabelMeaningLABEL_0🔴 FAKELABEL_1🟢 REAL

🧪 Example Inputs

    ✅ Real News (returns LABEL_1)
                  The United States Federal Reserve held interest rates steady on Wednesday,
                  keeping the federal funds rate at its current target range. Fed Chair Jerome
                  Powell said officials need more data before considering rate cuts, citing
                  persistent inflation concerns. The decision was unanimous among voting members
                  of the Federal Open Market Committee.
                  
    ❌ Fake News (returns LABEL_0)
          BREAKING: Scientists at a secret government facility have confirmed that 5G towers
          are being used to control human behavior through electromagnetic pulses. Whistleblowers
          inside the Deep State have leaked documents proving world leaders agreed to depopulate
          the planet by 2030. The mainstream media is actively suppressing this information.
        
              
  ⚙️ Setup & Installation
        
          Prerequisites
          
          Node.js + Angular CLI
          .NET 8 SDK
          HuggingFace account + API token
          
          1. Clone the repository
          bashgit clone https://github.com/leonischu/FakeNewsDetector.git
          cd FakeNewsDetector
          2. Backend setup
          bashcd Backend
          dotnet restore
          Set your HuggingFace token using User Secrets (never hardcode it):
          bashdotnet user-secrets init
          dotnet user-secrets set "HuggingFace:Token" "hf_your_token_here"
          Run the backend:
          bashdotnet run
          3. Frontend setup
          bashcd Frontend
          npm install
          ng serve
          Open http://localhost:4200 in your browser.

⚠️ Limitations

      Model trained on 2016–2017 data only — may misclassify modern news articles
      Works best on formal political/world news written in Reuters/AP style
      Not suitable for scientific, entertainment, or sports news classification
