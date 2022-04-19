using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MVC4Application.Models
{
    public class ParseHashDelemeterToList
    {
        public List<ParseHashCompanyDetails>  ReadFileContent()
        {
            string[] lines = File.ReadAllLines(@"C:\LetsProgram\code_exercise_inputs\hash.txt");
            List<ParseHashCompanyDetails> HashCompanyDetails = new List<ParseHashCompanyDetails>();
            for (int i = 0; i < lines.Length; i++)
            {
                ParseHashCompanyDetails obj = new ParseHashCompanyDetails();
                string[] CompanyList = lines[i].Split('#');
                obj.CompanyName = CompanyList[0];
                obj.YearFounded = CompanyList[1];
                obj.ContactName = CompanyList[2];
                obj.ContactPhoneNumber = CompanyList[3];
                HashCompanyDetails.Add(obj);

            }
            return HashCompanyDetails;
        }
    }
}