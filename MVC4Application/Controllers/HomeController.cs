using MVC4Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC4Application.Controllers
{
    public class HomeController : Controller
    {
       //MasterList objMasterlist = new MasterList();
        List<MasterList> MasterList = new List<MasterList>();

        

        public ActionResult Index(string sortBy)
        {
            

            ParserCommaDelemeterToList objCommaList = new ParserCommaDelemeterToList();
            List<ParseCommaCompanyDetails> CommaCompanyList = objCommaList.ReadFileContent();

            ParseHashDelemeterToList objHashList = new ParseHashDelemeterToList();
            List<ParseHashCompanyDetails> HashCompanyList = objHashList.ReadFileContent();


            ParseHyphenDelemeterToList objHyphenList = new ParseHyphenDelemeterToList();
            List<ParseHyhpenCompanyDetails> HyphenCompanyList = objHyphenList.ReadFileContent();

           
            foreach(var obj in CommaCompanyList)
            {
                MasterList objMasterlist = new MasterList();
                objMasterlist.CompanyName = obj.CompanyName;
                objMasterlist.ContactName = obj.ContactName;
                objMasterlist.PhoneNumber = obj.PhoneNumber;
                objMasterlist.YearsInBusiness = obj.YearsInBusiness;
                objMasterlist.EmailId = obj.EmailId;
                MasterList.Add(objMasterlist);
            }
            foreach (var obj in HashCompanyList)
            {
                MasterList objMasterlist = new MasterList();
                objMasterlist.CompanyName = obj.CompanyName;
                objMasterlist.ContactName = obj.ContactName;
                objMasterlist.YearFounded = obj.YearFounded;
                objMasterlist.PhoneNumber = obj.ContactPhoneNumber;
                MasterList.Add(objMasterlist);
            };

            foreach (var obj in HyphenCompanyList)
            {
                MasterList objMasterlist = new MasterList();
                objMasterlist.CompanyName = obj.CompanyName;
                objMasterlist.ContactName =  obj.ContactFirstName + " " + obj.ContactLastName ;
                objMasterlist.YearFounded = obj.YearFounded;
                objMasterlist.PhoneNumber = obj.ContactPhoneNumber;
                objMasterlist.EmailId = obj.ContactEmail;
                MasterList.Add(objMasterlist);
            };
            ViewBag.SortCompanyName = string.IsNullOrEmpty(sortBy) ? "CompanyName desc" : "";
            ViewBag.SortContactName = sortBy == "ContactName" ? "ContactName desc" : "ContactName";
            ViewBag.SortYearsInBusiness = sortBy == "YearsInBusiness" ? "YearsInBusiness desc" : "YearsInBusiness";

           


            switch (sortBy)
            {
                case "CompanyName desc":
                    SortByCompanyName sortByCompanyName = new SortByCompanyName();

                    MasterList.Sort(sortByCompanyName);
                    break;
                case "ContactName":

                    SortByContactName sortByContactName = new SortByContactName();
                    //MasterList.Sort
                    MasterList.Sort(sortByContactName);
                    break;
                case "ContactName desc":
                    MasterList.Reverse();
                    break;
                case "YearsInBusiness":
                    MasterList.Sort();
                    break;
                 case "YearsInBusiness desc":
                    MasterList.Sort();
                    break;
                default:
                    //MasterList.Sort(sortByCompanyName);
                    MasterList.Reverse();
                    break;


            }
            Session["MasterList"] = MasterList;

            return View(MasterList);
        }
        public void DownloadExcel()
        {
            var grid = new GridView();
            ExportCsv((List<MasterList>)Session["MasterList"], "list");
        }

        public static void ExportCsv<T>(List<T> genericList, string fileName)
        {
            var sb = new StringBuilder();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var finalPath = Path.Combine(basePath, fileName + ".csv");
            var header = "";
            var info = typeof(T).GetProperties();
            if (!System.IO.File.Exists(finalPath))
            {
                var file = System.IO.File.Create(finalPath);
                file.Close();
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + "; ";
                }
                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + "; ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
    


    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}