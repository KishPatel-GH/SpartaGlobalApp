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
    /// Interaction logic for TraineeHome.xaml
    /// </summary>
    public partial class TraineeHome : Window
    {
        public TraineeHome(string traineestring)
        {
            InitializeComponent();
            using (var db = new SpartaGlobalDBContext())
            {
                trainee = db.TraineeTables.Where(u => u.TraineeUsername == traineestring).FirstOrDefault();
            }
            UserWelcome.Content = $"{trainee.TraineeName} - {trainee.Course}";
            PopulateTraineeQuestionListBox();
        }

        CRUDManager _crudManager = new CRUDManager();

        public TraineeTable trainee { get; set; }

        private void PopulateTraineeQuestionListBox()
        {
            MyQuestionsListbox.ItemsSource = _crudManager.RetrieveAllTraineeQuestions(trainee.TraineeId);
        }
        private void PopulateTraineeQuestionField()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                string rID = MyQuestionsListbox.SelectedItem.ToString();
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
                else
                {
                    Response.Text = "";
                }
                if (x.q.Feedback != null)
                {
                    Feedback.Text = x.q.Feedback;
                }
                else
                {
                    Feedback.Text = "";
                }
            }
        }
        private void Response_Click(object sender, RoutedEventArgs e)
        {
            string rID = (MyQuestionsListbox.SelectedItem.ToString());
            int rID1 = Int32.Parse((rID.Substring(rID.Length - 4)));
            _crudManager.AddResponse(rID1, Response.Text);
            PopulateTraineeQuestionField();
        }

        private void MyQuestionsListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyQuestionsListbox.SelectedItem != null)
            {
                PopulateTraineeQuestionField();
            }
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
        private void SpartaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            App.Current.MainWindow.Show();
        }
    }
}
