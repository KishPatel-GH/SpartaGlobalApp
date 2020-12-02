DROP TABLE TraineeAnswersTable
DROP TABLE TraineeTable
DROP TABLE QuestionsTable
DROP TABLE TrainerTable

CREATE TABLE TrainerTable (
    TrainerID char(5) PRIMARY KEY,
    TrainerName varchar(20),
    Course varchar(300),
    TrainerPassword varchar(10)
);
CREATE TABLE QuestionsTable (
    QuestionID int IDENTITY(2000,1) PRIMARY KEY,
    Question varchar(200),
    ModelAnswer varchar(300),
    CategoryID char(5),
    CategoryName varchar(20)
);
CREATE TABLE TraineeTable (
    TraineeID int IDENTITY(1000,1) PRIMARY KEY,
    TraineeName varchar(20),
    Course varchar(300),
    TrainerID char(5),
    TraineePassword varchar(10),
    FOREIGN KEY (TrainerID) REFERENCES TrainerTable(TrainerID)
);
CREATE TABLE TraineeAnswersTable (
    ResponseID int IDENTITY(3000,1) PRIMARY KEY,
    QuestionID int,
    TraineeID int,
    Response varchar(300),
    PassStatus bit,
    FOREIGN KEY (QuestionID) REFERENCES QuestionsTable(QuestionID),
    FOREIGN KEY (TraineeID) REFERENCES TraineeTable(TraineeID)
);