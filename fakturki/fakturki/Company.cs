using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace fakturki
{
    public class Company
    {


        const string pathdir = @"C:\Users\Filip\Documents\companies.xml";      
        public string Name;
        public int NIP;
        public string City;
        public int Post_code;
        public string Street;


       
        public void addCompany(string name, int NIP, string city, int post_code, string street)
        {
           
            
            this.Name = name;
            this.NIP = NIP;
            this.City = city;
            this.Post_code = post_code;
            this.Street = street;


        }
       
      
    }
}
