using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole.Options
{
    public class CustomerOptions
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string VatNumber { get;  set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
