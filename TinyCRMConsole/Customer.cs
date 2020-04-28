using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole
{
	class Customer
	{
		public DateTime Created { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string VatNumber { get; private set; }
		public string Phone { get; set; }
		public decimal TotalGross { get; private set; }
		public bool IsActive { get; set; }
		public int Age { get; set; }

		public Customer(string vatNumber)
		{
			if(!IsValidVatNumber(vatNumber))
			{
				throw new Exception("Invalid VatNumber");
			}

			VatNumber = vatNumber;
			Created = DateTime.Now;
		}
		public bool IsValidVatNumber(string vatNumber)
		{
			return
				!string.IsNullOrWhiteSpace(vatNumber) && vatNumber.Length == 0;
		}
		public bool IsAdutlt()
		{
			return Age >= 18;
		}
	}
}
