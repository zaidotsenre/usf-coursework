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

namespace AHPA_19___The_Middle_Name_Problem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Clipboard.Clear();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            string Name = ((RoutedCommand)e.Command).Name;
            if(Name == "Copy"){
                if(tbSource == null)
                {
                    e.CanExecute = false;
                    return;
                }
                if (tbSource.SelectedText.Length > 0)
                    e.CanExecute = true;
                else
                    e.CanExecute = false;
            } else if (Name == "Paste")
            {
                if(Clipboard.ContainsText() == true)
                {
                    e.CanExecute = true;
                }
                else
                {
                    e.CanExecute = false;
                }
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            String Name = ((RoutedCommand)e.Command).Name;
            if(Name == "Copy")
            {
                Clipboard.SetText(tbSource.SelectedText);
            }
            else if (Name == "Paste")
            {
                tbDestination.Text = tbDestination.Text + Clipboard.GetText();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbDestination.Clear();
        }
    }
}
