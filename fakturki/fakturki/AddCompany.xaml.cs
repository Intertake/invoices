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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Data;

namespace fakturki
{
    /// <summary>
    /// Interaction logic for AddCompany.xaml
    /// </summary>
    public partial class AddCompany : Window
    { 

        const string pathdir = @"C:\Users\Filip\Documents\invoices\fakturki\companies.xml";
        public AddCompany()
        {
            InitializeComponent();


            string sampleXmlFile = pathdir;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(sampleXmlFile);
            DataView dataView = new DataView(dataSet.Tables[0]);
            AddCompanyDataView.ItemsSource = dataView;
        }
        private void AddCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument docCompany = new XmlDocument();
            try { docCompany.Load(pathdir); }
            catch (FileNotFoundException)
            {
                docCompany.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<Companies xmlns=\"CompanySchema\">\n" +
                 "  <Company NIP=\"9876543\">\n" +
                 "    <name>Testowa</name>\n" +
                 "    <city>Poznan</city>\n" +
                 "    <post_code>61000</postcode>\n" +
                 "    <street>Palacza</street>\n" +
                 "  </company>\n" +
                 "  <Company NIP=\"12345678\">\n" +
                 "    <name>FUBaba</name>\n" +
                 "    <city>Poznan</city>\n" +
                 "    <post_code>62000</postcode>\n" +
                 "    <street>Ratajczaka</street>\n" +
                 "  </company>\n" +
                 "  <Company NIP=\"5436758\">\n" +
                 "    <name>Isam</name>\n" +
                 "    <city>Poznan</city>\n" +
                 "    <post_code>61000</postcode>\n" +
                 "    <street>Browar</street>\n" +
                 "  </company>\n" +
                 "  </companies>\n");
            }

            Company Company1 = new Company();
            Company1.AddNewCompanyToXml(CompanyNipBox.Text, CompanyNameBox.Text, CompanyCityBox.Text, CompanyPostCodeBox.Text, CompanyStreetBox.Text, docCompany);


            docCompany.Save(pathdir);
            Company1.RefreshCompany(pathdir, AddCompanyDataView);


        }

        
    }
}
