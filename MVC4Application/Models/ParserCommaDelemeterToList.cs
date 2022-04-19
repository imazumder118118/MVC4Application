using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

namespace MVC4Application.Models
{
    public  class ParserCommaDelemeterToList
    {
        public List<ParseCommaCompanyDetails>  ReadFileContent()
        {
            string[] lines = File.ReadAllLines(@"C:\LetsProgram\code_exercise_inputs\comma.txt");
            List<ParseCommaCompanyDetails> CommanCompanyDetails = new List<ParseCommaCompanyDetails>();
            for (int i = 0; i < lines.Length; i++)
            {
                ParseCommaCompanyDetails obj = new ParseCommaCompanyDetails();
                string[] CompanyList = lines[i].Split(',');
                obj.CompanyName = CompanyList[0];
                obj.ContactName = CompanyList[1];
                obj.PhoneNumber = CompanyList[2];
                obj.YearsInBusiness = CompanyList[3];
                obj.EmailId = CompanyList[4];
                CommanCompanyDetails.Add(obj);

            }
            return CommanCompanyDetails;
        }
      

    }
}