using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace fakturki
{
    public class Company
    {


        const string pathdir = @"C:\Users\Filip\Documents\invoices\fakturki\companies.xml";
        public string Name;
        public double NIP;
        public string City;
        public string Post_code;
        public string Street;

        DataView dataView;
       
        public void addCompany(string name, double NIP, string city, string post_code, string street)
        {
           
            
            this.Name = name;
            this.NIP = NIP;
            this.City = city;
            this.Post_code = post_code;
            this.Street = street;


        }

        public XmlElement AddNewCompanyToXml(string nip, string name, string city, string post_Code, string street, XmlDocument docCompany)
        {
            XmlElement companyElement = docCompany.CreateElement("Company");
            docCompany.DocumentElement.AppendChild(companyElement);

            XmlAttribute attribute = docCompany.CreateAttribute("NIP");
            attribute.Value = nip;
            companyElement.Attributes.Append(attribute);

            XmlElement nameElement = docCompany.CreateElement("name");
            nameElement.InnerText = name;
            companyElement.AppendChild(nameElement);

            XmlElement cityElement = docCompany.CreateElement("city");
            cityElement.InnerText = city;
            companyElement.AppendChild(cityElement);

            XmlElement postCodeElement = docCompany.CreateElement("post_code");
            postCodeElement.InnerText = post_Code;
            companyElement.AppendChild(postCodeElement);

            XmlElement streetElement = docCompany.CreateElement("street");
            streetElement.InnerText = street;
            companyElement.AppendChild(streetElement);
           
            return companyElement;
            
        }

        public void delCompany(double NIP)
        {
            XDocument docCompany1 = XDocument.Load(pathdir);
            var deleteQuery = from r in docCompany1.Descendants("Company") where r.Attribute("NIP").Value == Convert.ToString(NIP) select r;
            foreach (var query in deleteQuery)
            {
                query.Element("name").Remove();
                query.Element("city").Remove();
                query.Element("post_code").Remove();
                query.Element("street").Remove();

            }
            deleteQuery.Remove();
            
            docCompany1.Save(pathdir);
            
        }

        public void RefreshCompany(string path, DataGrid dataGrid)
        {
            string sampleXmlFile = path;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(sampleXmlFile);
            dataView = new DataView(dataSet.Tables[0]);
            dataGrid.ItemsSource = dataView;
        }



    }
}
