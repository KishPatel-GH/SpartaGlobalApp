using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpartaGlobalAppModel;
using SpartaGlobalAppBusiness;
using NUnit.Framework;

namespace SpartaGlobalAppBusiness
{
    public class Tests
    {
        CRUDManager _crudManager = new CRUDManager();

        [SetUp]

        public void Setup()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var selectedQuestion =
                from q in db.QuestionsTables
                where q.CategoryId == "TESTS"
                select q;
                foreach (var q in selectedQuestion)
                {
                    db.QuestionsTables.RemoveRange(q);
                }
                var selectedTrainer =
                from t in db.TrainerTables
                where t.TrainerId == "NMAND"
                select t;
                foreach (var t in selectedTrainer)
                {
                    db.TrainerTables.RemoveRange(t);
                }
                var selectedTrainee =
                from t in db.TraineeTables
                where t.TraineeName == "Kishan Patel"
                select t;
                foreach (var t in selectedTrainee)
                {
                    db.TraineeTables.RemoveRange(t);
                }
                db.SaveChanges();
            }
        }

        [TearDown]

        public void TearDown()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var selectedQuestion =
                from q in db.QuestionsTables
                where q.CategoryId == "TESTS"
                select q;
                foreach (var q in selectedQuestion)
                {
                    db.QuestionsTables.RemoveRange(q);
                }
                var selectedTrainer =
                from t in db.TrainerTables
                where t.TrainerId == "NMAND"
                select t;
                foreach (var t in selectedTrainer)
                {
                    db.TrainerTables.RemoveRange(t);
                }
                var selectedTrainee =
                from t in db.TraineeTables
                where t.TraineeName == "Kishan Patel"
                select t;
                foreach (var t in selectedTrainee)
                {
                    db.TraineeTables.RemoveRange(t);
                }
                db.SaveChanges();
            }
        }

        [Test] // TRAINER CREATE TEST
        public void WhenANewTrainerIsAdded_TheNumberOfTrainersIncreasesBy1()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var numberOfTrainersBefore = db.TrainerTables.ToList().Count();
                _crudManager.CreateTrainer("Nishant Mandal", "NMAND", "nishman123", "Eng71");
                var numberOfTrainersAfter = db.TrainerTables.ToList().Count();

                Assert.AreEqual(numberOfTrainersBefore + 1, numberOfTrainersAfter);
            }
        }
        [Test] // TRAINEE CREATE TEST
        public void WhenANewTraineeIsAdded_TheNumberOfTraineesIncreasesBy1()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                _crudManager.CreateTrainer("Nishant Mandal", "NMAND", "nishman123", "Eng71");
                var numberOfTraineesBefore = db.TraineeTables.ToList().Count();
                _crudManager.CreateTrainee("Kishan Patel", "kishpat123", "Eng71", "NMAND");
                var numberOfTraineesAfter = db.TrainerTables.ToList().Count();

                Assert.AreEqual(numberOfTraineesBefore + 1, numberOfTraineesAfter);
            }
        }
        [Test] // QUESTION CREATE TEST
        public void WhenANewQuestionIsAdded_TheNumberOfQuestionsIncreasesBy1()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var numberOfQuestionsBefore = db.QuestionsTables.ToList().Count();
                _crudManager.CreateQuestion("Test question?", "Test answer.", "TESTS", "Testing");
                var numberOfQuestionsAfter = db.QuestionsTables.ToList().Count();

                Assert.AreEqual(numberOfQuestionsBefore + 1, numberOfQuestionsAfter);
            }
        }

        [Test] // POSE QUESTION TEST
        public void TestWhenQuestionIsPosed()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                _crudManager.CreateQuestion("Test question?", "Test answer.", "TESTS", "Testing");
                _crudManager.CreateTrainer("Nishant Mandal", "NMAND", "nishman123", "Eng71");
                _crudManager.CreateTrainee("Kishan Patel", "kishpat123", "Eng71", "NMAND");
                var ThisQuestionID = db.QuestionsTables.Where(q => q.CategoryId == "TESTS").FirstOrDefault();
                int a = ThisQuestionID.QuestionId;
                var ThisTraineeID = db.TraineeTables.Where(t => t.TraineeName == "Kishan Patel").FirstOrDefault();
                int b = ThisTraineeID.TraineeId;
                _crudManager.TrainerPoseQuestion(a, b);
                Assert.IsNotNull(db.TraineeAnswersTables);
            }
        }

        [Test] // RESPOND TO QUESTION TEST
        public void TestWhenQuestionResponded()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                _crudManager.CreateQuestion("Test question?", "Test answer.", "TESTS", "Testing");
                _crudManager.CreateTrainer("Nishant Mandal", "NMAND", "nishman123", "Eng71");
                _crudManager.CreateTrainee("Kishan Patel", "kishpat123", "Eng71", "NMAND");
                var ThisQuestionID = db.QuestionsTables.Where(q => q.CategoryId == "TESTS").FirstOrDefault();
                int a = ThisQuestionID.QuestionId;
                var ThisTraineeID = db.TraineeTables.Where(t => t.TraineeName == "Kishan Patel").FirstOrDefault();
                int b = ThisTraineeID.TraineeId;
                _crudManager.TrainerPoseQuestion(a, b);
                _crudManager.TraineeRespondsToQuestion(a,"Test Response");
                Assert.IsNotNull(db.TraineeAnswersTables.Where(c => c.Response == "Test Response"));
            }
        }
    }
}