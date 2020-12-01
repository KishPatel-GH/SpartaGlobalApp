DROP TABLE TraineeAnswersTable
DROP TABLE TraineeTable
DROP TABLE QuestionsTable
DROP TABLE TrainerTable
DROP TABLE CategoriesTable

CREATE TABLE CategoriesTable (
    CategoryID char(5) PRIMARY KEY,
    CategoryName varchar(20)
);
CREATE TABLE TrainerTable (
    TrainerID char(5) PRIMARY KEY,
    TrainerName varchar(20),
    Course varchar(300),
);
CREATE TABLE QuestionsTable (
    QuestionID int PRIMARY KEY,
    Question varchar(200),
    ModelAnswer varchar(300),
    CategoryID char(5),
    FOREIGN KEY (CategoryID) REFERENCES CategoriesTable(CategoryID)
);
CREATE TABLE TraineeTable (
    TraineeID int PRIMARY KEY,
    TraineeName varchar(20),
    Course varchar(300),
    TrainerID char(5),
    FOREIGN KEY (TrainerID) REFERENCES TrainerTable(TrainerID)
);
CREATE TABLE TraineeAnswersTable (
    ResponseID int PRIMARY KEY,
    QuestionID int,
    TraineeID int,
    Response varchar(300),
    PassStatus bit,
    FOREIGN KEY (QuestionID) REFERENCES QuestionsTable(QuestionID),
    FOREIGN KEY (TraineeID) REFERENCES TraineeTable(TraineeID)
);