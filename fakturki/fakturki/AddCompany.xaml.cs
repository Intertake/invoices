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
using System.Xml;

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
            
        }

      

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument docCompany = new XmlDocument();
            docCompany.Load(pathdir);
            //try { docCompany.Load(pathdir); }
            //catch (FileNotFoundException)
            //{
            //    docCompany.LoadXml( "<?xml version=\"1.0\"?> \n" +
            //    "<Companies xmlns=\"CompanySchema\">\n" +
            //     "  <Company NIP=\"9876543\">\n" +
            //     "    <name>Testowa</name>\n" +
            //     "    <city>Poznan</city>\n" +
            //     "    <post_code>61000</postcode>\n" +
            //     "    <street>Palacza</street>\n" +
            //     "  </company>\n" +
            //     "  <Company NIP=\"12345678\">\n" +
            //     "    <name>FUBaba</name>\n" +
            //     "    <city>Poznan</city>\n" +
            //     "    <post_code>62000</postcode>\n" +
            //     "    <street>Ratajczaka</street>\n" +
            //     "  </company>\n" +
            //     "  <Company NIP=\"5436758\">\n" +
            //     "    <name>Isam</name>\n" +
            //     "    <city>Poznan</city>\n" +
            //     "    <post_code>61000</postcode>\n" +
            //     "    <street>Browar</street>\n" +
            //     "  </company>\n" +
            //     "  </companies>\n"  );
            //}
            
          
           


            Company firma1 = new Company();
            firma1.addCompany( "asdkjh", 12091823, "Poznan", 124341, "papacz");

            XmlProp test = new XmlProp();
            test.AddNewCompany(firma1.Name, Convert.ToString(firma1.NIP), firma1.City, Convert.ToString(firma1.Post_code), firma1.Street, docCompany);


            docCompany.Save(pathdir);
        }

       
    }
}
