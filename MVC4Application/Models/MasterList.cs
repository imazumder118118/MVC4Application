using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC4Application.Models
{
    public class MasterList : IComparable<MasterList>
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string YearsInBusiness { get; set; }
        public string EmailId { get; set; }
        


        public string YearFounded { get; set; }

        public int CompareTo(MasterList other)
        {
            if((string.IsNullOrEmpty(this.YearsInBusiness) && (string.IsNullOrEmpty(other.YearsInBusiness))))
            {
                if (Convert.ToInt32(this.YearsInBusiness) > Convert.ToInt32(other.YearsInBusiness))
                    return 1;
                else if (Convert.ToInt32(this.YearsInBusiness) < Convert.ToInt32(other.YearsInBusiness))
                    return -1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
            
            throw new NotImplementedException();
        }





        //public string ContactPhoneNumber { get; set; }

        //public string ContactEmail { get; set; }
        //public string ContactFirstName { get; set; }
        //public string ContactLastName { get; set; }
    }
    public class SortByCompanyName : IComparer<MasterList>
    {
        public int Compare(MasterList x, MasterList y)
        {
            return x.CompanyName.CompareTo(y.CompanyName);
            throw new NotImplementedException();
        }
    }
   
    public class SortByContactName : IComparer<MasterList>
    {
        public int Compare(MasterList x, MasterList y)
        {
            return x.ContactName.CompareTo(y.ContactName);
            throw new NotImplementedException();
        }
    }

    


}