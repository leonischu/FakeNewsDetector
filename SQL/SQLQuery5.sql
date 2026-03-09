CREATE TABLE NewsHistory
(
    Id INT PRIMARY KEY IDENTITY,
    ArticleText NVARCHAR(MAX),
    Prediction NVARCHAR(20),
    Confidence FLOAT,
    Explanation NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE()
)