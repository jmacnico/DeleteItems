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
using forms = System.Windows.Forms;
using System.IO;
using Micael.Directorias;
namespace DeleteItems
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            forms.FolderBrowserDialog fbd = new forms.FolderBrowserDialog();
            
            forms.DialogResult result = fbd.ShowDialog();
            if(result == forms.DialogResult.OK)
                txtPath.Text = fbd.SelectedPath;
            
        }

      
       private void Button_Click_1(object sender, RoutedEventArgs e)
       {
           if (Directory.Exists(txtPath.Text) && (((bool)chkContains.IsChecked && string.IsNullOrEmpty(txtTextContains.Text)) || !(bool)chkContains.IsChecked))
           {
               List<string> lstFolders = new List<string>();
              Diretorias.GetAllFoldersAndSubFolders(lstFolders, txtPath.Text);
               List<string> lstFilesPath = new List<string>();
               Diretorias.GetFilesFromListPaths(lstFolders, lstFilesPath, txtTextContains.Text,(bool)chkContains.IsChecked);
               lstFiles.ItemsSource = lstFilesPath;
               txtCountItems.Text = lstFilesPath.Count.ToString();
               MessageBox.Show("Concluído");
           }
           else
               MessageBox.Show("Selecione um diretório ou adicione o texto que contenha no nome do ficheiro");
       }

       private void Button_Click_2(object sender, RoutedEventArgs e)
       {
           foreach (string pathFile in lstFiles.Items)
              File.Delete(pathFile);
       }
    }
}
