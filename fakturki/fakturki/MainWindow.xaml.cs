using System;
using System.Collections.Generic;
using System.Data;
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
using System.IO;

namespace fakturki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string pathdir = @"C:\Users\Filip\Documents\invoices\fakturki\companies.xml";
        double NIPtest;
        DataView dataView;
        public MainWindow()
        {
            InitializeComponent();
            //Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight;
            //Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth;
            Application.Current.MainWindow.Height = 1080;
            Application.Current.MainWindow.Width = 1920;


            string sampleXmlFile = pathdir;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(sampleXmlFile);
            dataView = new DataView(dataSet.Tables[0]);
            datatest.ItemsSource = dataView;


        }

        private void add_company_Click(object sender, RoutedEventArgs e)
        {
            var addcom = new AddCompany();
            addcom.Show();
            
           
            
           
        }
       

        private void datatest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView testindex = (DataRowView)datatest.SelectedItem;
            NIPtest = Convert.ToDouble(testindex.Row[4]);

            testowylabel.Content = NIPtest;

            Company test = new Company();

            test.delCompany(NIPtest);

            test.RefreshCompany(pathdir, datatest);
           
            
        }

        
    }
    }


