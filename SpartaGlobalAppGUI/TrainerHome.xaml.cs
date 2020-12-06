using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SpartaGlobalAppBusiness;
using Microsoft.EntityFrameworkCore;
using SpartaGlobalAppModel;
using System.Linq;

namespace SpartaGlobalAppGUI
{
    /// <summary>
    /// Interaction logic for TrainerHome.xaml
    /// </summary>
    public partial class TrainerHome : Window
    {
        CRUDManager _crudManager = new CRUDManager();

        public TrainerHome(string trainerstring)
        {
            InitializeComponent();
            using (var db = new SpartaGlobalDBContext())
            {
                trainer = db.TrainerTables.Where(u => u.TrainerUsername == trainerstring).FirstOrDefault();
            }
            PopulateListBox();
            PopulateTraineeListBox();
            PopulateTraineeQuestionListBox();
            UserWelcome.Content = $"{trainer.TrainerName} - {trainer.Course}";
        }

        public TrainerTable trainer { get; set; }

        private void PopulateListBox()
        {
            QList.ItemsSource = _crudManager.RetrieveAllQuestions(trainer.TrainerId);
        }
        private void PopulateTraineeListBox()
        {
            TraineeList.ItemsSource = _crudManager.RetrieveAllTrainees(trainer.TrainerId);
        }
        private void PopulateTraineeQuestionListBox()
        {
            TraineeQuestionListbox.ItemsSource = _crudManager.RetrieveAllTraineeQuestions(trainer.TrainerId);
        }

        private void createQ_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                _crudManager.CreateQuestion(SelectedQTB.Text, CategoryTB.Text, trainer.TrainerId);
                PopulateListBox();
            }
        }
        private void PopulateQuestionField()
        {
            SelectedQTB.Text = _crudManager.SelectedQuestion.Question;
            CategoryTB.Text = _crudManager.SelectedQuestion.CategoryName;
        }
        private void PopulateTraineeField()
        {
            StudentName.Text = _crudManager.SelectedTrainee.TraineeName;
            StudentID.Text = $"{_crudManager.SelectedTrainee.TraineeId}";
            StudentCourse.Text = _crudManager.SelectedTrainee.Course;
        }
        private void PopulateTraineeQuestionField()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                string rID = TraineeQuestionListbox.SelectedItem.ToString();
                var x = (from q in db.TraineeAnswersTables
                         join t in db.TraineeTables on q.TraineeId equals t.TraineeId
                         join r in db.QuestionsTables on q.QuestionId equals r.QuestionId
                         where q.ResponseId == Int32.Parse((rID.Substring(rID.Length - 4)))
                         select new { q, t, r }).First();
                SelectedQTB.Text = x.r.Question;
                CategoryTB.Text = x.r.CategoryName;
                StudentName.Text = x.t.TraineeName;
                StudentID.Text = $"{x.t.TraineeId}";
                StudentCourse.Text = x.t.Course;
                if (x.q.Response != null)
                {
                    Response.Text = x.q.Response;
                }
                if (x.q.Feedback != null)
                {
                    Feedback.Text = x.q.Feedback;
                }
            }
        }
        private void QList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QList.SelectedItem != null)
            {
                _crudManager.SetSelectedQuestion(QList.SelectedItem);
                PopulateQuestionField();
            }
        }


        private void EditQ_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.UpdateQuestion(SelectedQTB.Text, CategoryTB.Text);
            PopulateListBox();
            PopulateTraineeQuestionListBox();
        }

        private void DeleteQ_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.DeleteQuestion();
            PopulateListBox();
            SelectedQTB.Text = "";
            CategoryTB.Text = "";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            SelectedQTB.Text = "";
            CategoryTB.Text = "";
            StudentCourse.Text = "";
            StudentID.Text = "";
            StudentName.Text = "";
            Feedback.Text = "";
            Response.Text = "";
        }

        private void PoseQ_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.TrainerPoseQuestion();
            PopulateTraineeQuestionListBox();
        }

        private void TraineeListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TraineeList.SelectedItem != null)
            {
                _crudManager.SetSelectedTrainee(TraineeList.SelectedItem);
                PopulateTraineeField();
            }
        }
        private void TraineeQuestionListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TraineeQuestionListbox.SelectedItem != null)
            {
                PopulateTraineeQuestionField();
            }
        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            string rID = (TraineeQuestionListbox.SelectedItem.ToString());
            int rID1 = Int32.Parse((rID.Substring(rID.Length - 4)));
            _crudManager.AddFeedback(rID1, Feedback.Text);
            PopulateTraineeQuestionField();
        }

        private void SpartaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            App.Current.MainWindow.Show();
        }
    }
}
