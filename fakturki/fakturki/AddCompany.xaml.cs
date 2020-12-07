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

        const string pathdir = @"C:\Users\Filip\Documents\companies.xml";


        public AddCompany()
        {
            InitializeComponent();
            
        }

      

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try { doc.Load(pathdir); }
            catch (FileNotFoundException)
            {

            }
          
           


            Company firma1 = new Company();
            firma1.addCompany( "asdkjh", 12091823, "Poznan", 124341, "papacz");
            

          


        }
    }
}
