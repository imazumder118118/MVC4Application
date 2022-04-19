using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace MVC4Application.Models
{
    public class ParseHyphenDelemeterToList
    {
        public List<ParseHyhpenCompanyDetails>  ReadFileContent()
        {
            string[] lines = File.ReadAllLines(@"C:\LetsProgram\code_exercise_inputs\hyphen.txt");
            List<ParseHyhpenCompanyDetails> HyphenCompanyDetails = new List<ParseHyhpenCompanyDetails>();
            for (int i = 0; i < lines.Length; i++)
            {
                ParseHyhpenCompanyDetails obj = new ParseHyhpenCompanyDetails();
                string[] CompanyList = lines[i].Split('-');
                obj.CompanyName = CompanyList[0];
                obj.YearFounded = CompanyList[1];
                obj.ContactPhoneNumber = CompanyList[2];
                obj.ContactEmail = CompanyList[3];
                obj.ContactFirstName = CompanyList[4];
                obj.ContactLastName = CompanyList[5];

                HyphenCompanyDetails.Add(obj);

            }
            return HyphenCompanyDetails;
        }
    }
}