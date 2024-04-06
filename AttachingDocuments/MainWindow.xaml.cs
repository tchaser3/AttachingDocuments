/* Title:           Attaching Document
 * Date:            7-16-18
 * Author:          Terry Holmes
 * 
 * Description:     This is to see how the document is to be attached */

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
using Microsoft.Win32;

namespace AttachingDocuments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();

        string gstrNewLocation;
        string gstrFileNaume;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCopyPath_Click(object sender, RoutedEventArgs e)
        {
            //Setting path to save
            DateTime dateDate = DateTime.Now;
            long intresult = dateDate.Year * 10000000000 + dateDate.Month * 100000000 + dateDate.Day * 1000000 + dateDate.Hour * 10000 + dateDate.Minute * 100 + dateDate.Second;
            string strTransactionName = Convert.ToString(intresult);
            gstrNewLocation = "\\\\bjc\\shares\\Documents\\WAREHOUSE\\WhseTrac\\Debug\\" + strTransactionName +".pdf";

            try
            {
                

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name
                
                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    gstrFileNaume = dlg.FileName;
                }

                System.IO.File.Copy(gstrFileNaume,gstrNewLocation);

                TheMessagesClass.InformationMessage(gstrFileNaume);
            }
            catch (Exception Ex)
            {
                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }

        private void btnDisplayFile_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(gstrNewLocation);
        }
    }
}
