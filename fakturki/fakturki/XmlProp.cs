using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Windows;
using System.IO;

namespace fakturki
{
    public class XmlProp
    {
        const string pathdir = @"C:\Users\Filip\Documents\invoices\fakturki\companies.xml";
        public XmlDocument LoadDocumentWithSchemaValidation(bool generateXML, bool generateSchema)
        {
            XmlReader reader;

            XmlReaderSettings settings = new XmlReaderSettings();

            // Helper method to retrieve schema.
            XmlSchema schema = getSchema(generateSchema);

            if (schema == null)
            {
                return null;
            }

            settings.Schemas.Add(schema);

            settings.ValidationEventHandler += settings_ValidationEventHandler;
            settings.ValidationFlags =
                settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;

            try
            {
                reader = XmlReader.Create(pathdir, settings);
            }
            catch (System.IO.FileNotFoundException)
            {
                if (generateXML)
                {
                    string xml = generateXMLSchema();
                    byte[] byteArray = Encoding.UTF8.GetBytes(xml);
                    MemoryStream stream = new MemoryStream(byteArray);
                    reader = XmlReader.Create(stream, settings);
                }
                else
                {
                    return null;
                }
            }

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(reader);
            reader.Close();

            return doc;
        }



        private string generateXMLSchema()
        {
            string xmlSchema =
            "<?xml version=\"1.0\" encoding=\"utf - 8\"?> " +
            "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"  " +
            "  attributeFormDefault=\"unqualified\"   " +
            "  elementFormDefault=\"qualified\"  " +
            "  targetNamespace=\"CompaniesSchema\"> " +
            "  <xs:element name=\"Companies\">  " +
            "    <xs:complexType>  " +
            "      <xs:sequence>  " +
            "        <xs:element maxOccurs=\"unbounded\" name=\"Company\">  " +
            "          <xs:complexType>  " +
            "            <xs:sequence>  " +
            "              <xs:element name=\"name\" type=\"xs: string\" />  " +
            "              <xs:element name=\"city\" type=\"xs: string\" />  " +
            "               <xs:element name=\"post_code\" type=\"xs: int\" />  " +
            "              <xs:element name=\"street\" type=\"xs: string\" />  " +
            "            </xs:sequence>  " +
            "            <xs:attribute name=\"NIP\" type=\"xs: int\" use=\"required\" />  " +
            "          </xs:complexType>  " +
            "        </xs:element>  " +
            "      </xs:sequence>  " +
            "    </xs:complexType>  " +
            "  </xs:element>  " +
            "</xs:schema>  ";
            return xmlSchema;
        }




        private XmlSchema getSchema(bool generateSchema)
        {
            XmlSchemaSet xs = new XmlSchemaSet();
            XmlSchema schema;
            try
            {
                schema = xs.Add("http://www.contoso.com/books", "booksData.xsd");
            }
            catch (System.IO.FileNotFoundException)
            {
                if (generateSchema)
                {
                    string xmlSchemaString = generateXMLSchema();
                    byte[] byteArray = Encoding.UTF8.GetBytes(xmlSchemaString);
                    MemoryStream stream = new MemoryStream(byteArray);
                    XmlReader reader = XmlReader.Create(stream);
                    schema = xs.Add("http://www.contoso.com/books", reader);
                }
                else
                {
                    return null;
                }
            }
            return schema;
        }




        private void validateXML(bool generateSchema, XmlDocument doc)
        {
            if (doc.Schemas.Count == 0)
            {
                // Helper method to retrieve schema.
                XmlSchema schema = getSchema(generateSchema);
                doc.Schemas.Add(schema);
            }

            // Use an event handler to validate the XML node against the schema.
            doc.Validate(settings_ValidationEventHandler);
        }

        void settings_ValidationEventHandler(object sender,
    System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                MessageBox.Show
                    ("The following validation warning occurred: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                MessageBox.Show
                    ("The following critical validation errors occurred: " + e.Message);
                Type objectType = sender.GetType();
            }
        }
        public XmlElement AddNewCompany(string nip, string name, string city, string post_Code, string street, XmlDocument docCompany)
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
            companyElement.AppendChild(streetElement); ;






            return companyElement;


        }
      

    }
}
