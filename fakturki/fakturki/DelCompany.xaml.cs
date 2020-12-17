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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace fakturki
{
    /// <summary>
    /// Interaction logic for DelCompany.xaml
    /// </summary>
    public partial class DelCompany : Window
    {
        const string pathdir = @"C:\Users\Filip\Documents\invoices\fakturki\companies.xml";
        double NIPtest = 0;
        public DelCompany()
        {
            InitializeComponent();
            string sampleXmlFile = pathdir;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(sampleXmlFile);
            DataView dataView = new DataView(dataSet.Tables[0]);
            DelCompanyDataView.ItemsSource = dataView;
            
        }

        private void DelCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (NIPtest != 0)
            {
                DataRowView testindex = (DataRowView)DelCompanyDataView.SelectedItem;
                NIPtest = Convert.ToDouble(testindex.Row[4]);
                Company test = new Company();
                test.delCompany(NIPtest);
                test.RefreshCompany(pathdir, DelCompanyDataView);
            }
            else
            {
                Company test = new Company();
                test.delCompany(Convert.ToDouble(DelCompanyTextSearch.Text));
                test.RefreshCompany(pathdir, DelCompanyDataView);
                

            }
           
            
            

           

        }

       
    }
}
