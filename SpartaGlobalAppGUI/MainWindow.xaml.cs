using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpartaGlobalAppBusiness;
using Microsoft.EntityFrameworkCore;
using SpartaGlobalAppModel;

namespace SpartaGlobalAppGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        CRUDManager _crudManager = new CRUDManager();

        private void btnRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            slideCanvas.X = 0;
        }
        private void btnLoginPage_Click(object sender, RoutedEventArgs e)
        {
            slideCanvas.X = 360;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                if (db.TraineeTables.Where(u => u.TraineeUsername == loginUsername.Text).FirstOrDefault() != null && db.TraineeTables.Where(u => u.TraineeUsername == loginUsername.Text).First().TraineePassword == loginPassword.Text)
                {
                    // Login as Trainee
                    TraineeHome tr = new TraineeHome(loginUsername.Text);
                    tr.Show();
                    this.Hide();
                }
                else if (db.TrainerTables.Where(u => u.TrainerUsername == loginUsername.Text).FirstOrDefault() != null && db.TrainerTables.Where(u => u.TrainerUsername == loginUsername.Text).First().TrainerPassword == loginPassword.Text)
                {
                    // Login as Trainer
                    TrainerHome t = new TrainerHome(loginUsername.Text);
                    t.Show();
                    this.Hide();
                }
                else
                {
                    // Login Failed
                    loginUsername.BorderBrush = Brushes.Red;
                    loginPassword.BorderBrush = Brushes.Red;
                }
            }
            if (RememberMe.IsChecked != true)
            {
                loginUsername.Text = "";
                loginPassword.Text = "";
            }

        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                if (registerPassword.Text == registerCPassword.Text)
                {
                    if (trainerBox.IsChecked.Value)
                    {
                        if ((db.TrainerTables.Where(t => t.TrainerId == registerTrainer.Text).FirstOrDefault() == null))
                        {
                            registerTrainer.BorderBrush = Brushes.Red;
                            registerCPassword.BorderBrush = Brushes.Green;
                            registerCourse.BorderBrush = Brushes.Green;
                            registerName.BorderBrush = Brushes.Green;
                            registerPassword.BorderBrush = Brushes.Green;
                            registerUsername.BorderBrush = Brushes.Green;
                        }
                        else
                        {
                            _crudManager.CreateTrainee(registerName.Text, registerPassword.Text, registerCourse.Text, registerTrainer.Text, registerUsername.Text);
                            registerTrainer.BorderBrush = Brushes.Green;
                            registerCPassword.BorderBrush = Brushes.Green;
                            registerCourse.BorderBrush = Brushes.Green;
                            registerName.BorderBrush = Brushes.Green;
                            registerPassword.BorderBrush = Brushes.Green;
                            registerUsername.BorderBrush = Brushes.Green;

                        }
                    }
                    else
                    {
                        if ((db.TrainerTables.Where(t => t.TrainerId == registerTrainer.Text).FirstOrDefault() == null))
                        {
                            _crudManager.CreateTrainer(registerName.Text, registerTrainer.Text, registerPassword.Text, registerCourse.Text, registerUsername.Text);
                            registerTrainer.BorderBrush = Brushes.Green;
                            registerCPassword.BorderBrush = Brushes.Green;
                            registerCourse.BorderBrush = Brushes.Green;
                            registerName.BorderBrush = Brushes.Green;
                            registerPassword.BorderBrush = Brushes.Green;
                            registerUsername.BorderBrush = Brushes.Green;
                        }
                        else
                        {
                            registerTrainer.BorderBrush = Brushes.Red;
                            registerCPassword.BorderBrush = Brushes.Green;
                            registerCourse.BorderBrush = Brushes.Green;
                            registerName.BorderBrush = Brushes.Green;
                            registerPassword.BorderBrush = Brushes.Green;
                            registerUsername.BorderBrush = Brushes.Green;
                        }
                    }
                }
            }

        }
    }
}
