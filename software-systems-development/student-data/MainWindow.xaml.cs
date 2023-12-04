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

namespace AHPA_15___Student_Data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Student student = new Student();

        public MainWindow()
        {
            InitializeComponent();
            GenerateData();
        }

        private void GenerateData()
        {
            
            this.DataContext = student;
        }

        private void btnChangeData_Click(object sender, RoutedEventArgs e)
        {

            lblFirstName.Content = student.FirstName;
            lblLastName.Content = student.LastName;
            lblID.Content = student.ID;
        }

    }
}
