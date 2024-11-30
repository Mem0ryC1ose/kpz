using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationDateString
        {
            get { return RegistrationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); }
            set { RegistrationDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture); }
        }
    }
}
