DROP TABLE TraineeAnswersTable
DROP TABLE TraineeTable
DROP TABLE QuestionsTable
DROP TABLE TrainerTable

CREATE TABLE TrainerTable (
    TrainerID char(5) PRIMARY KEY,
    TrainerName varchar(20),
    TrainerUsername varchar(20),
    Course varchar(300),
    TrainerPassword varchar(10)
);
CREATE TABLE QuestionsTable (
    QuestionID int IDENTITY(2000,1) PRIMARY KEY,
    Question varchar(200),
    TrainerId char(5),
    CategoryName varchar(20),
    FOREIGN KEY (TrainerID) REFERENCES TrainerTable(TrainerID));

CREATE TABLE TraineeTable (
    TraineeID int IDENTITY(1000,1) PRIMARY KEY,
    TraineeName varchar(20),
    TraineeUsername varchar(20),
    Course varchar(300),
    TrainerID char(5),
    TraineePassword varchar(10),
    FOREIGN KEY (TrainerID) REFERENCES TrainerTable(TrainerID)
);
CREATE TABLE TraineeAnswersTable (
    ResponseID int IDENTITY(3000,1) PRIMARY KEY,
    QuestionID int,
    TraineeID int,
    TrainerID char(5),
    Response varchar(300),
    Feedback varchar(300),
    PassStatus bit,
    FOREIGN KEY (QuestionID) REFERENCES QuestionsTable(QuestionID),
    FOREIGN KEY (TrainerID) REFERENCES TrainerTable(TrainerID),
    FOREIGN KEY (TraineeID) REFERENCES TraineeTable(TraineeID));
