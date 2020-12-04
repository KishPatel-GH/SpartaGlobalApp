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

namespace SpartaGlobalAppGUI
{
    /// <summary>
    /// Interaction logic for TrainerHome.xaml
    /// </summary>
    public partial class TrainerHome : Window
    {
        public TrainerHome()
        {
            InitializeComponent();
        }
        CRUDManager _crudManager = new CRUDManager();
        private void createQ_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.CreateQuestion("New Question", "", (string)_crudManager.SelectedTrainer.TrainerId);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
