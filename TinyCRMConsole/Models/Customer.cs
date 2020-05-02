using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole.Models
{
	public class Customer
	{
		public int CustomerID { get; set; }
		public DateTime Created { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }

		public string Email { get; set; }
		public string VatNumber { get; set; }
		public string Phone { get; set; }
		public decimal TotalGross { get; set; }
		public bool IsActive { get; set; }
		public DateTime DateOfBirth { get; set; }
		public List<Order> Orders { get; set; }

		public Customer(string vatNumber)
		{
			if(!IsValidVatNumber(vatNumber))
			{
				throw new Exception("Invalid VatNumber");
			}

			VatNumber = vatNumber;
			Created = DateTime.Now;
		}
		public Customer()
		{

		}

		public Customer(string firstName, string lastName, string email, string vatNumber, string phone, decimal totalGross, bool isActive, DateTime dateofbirth)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			VatNumber = vatNumber;
			Phone = phone;
			TotalGross = totalGross;
			IsActive = isActive;
			DateOfBirth = dateofbirth;
			Created = DateTime.Now;

			Orders = new List<Order>();
		}

		public bool IsValidVatNumber(string vatNumber)
		{
			return
				!string.IsNullOrWhiteSpace(vatNumber) && vatNumber.Length == 9;
		}
		public bool IsAdutlt()
		{
			return DateOfBirth.Year - DateTime.Now.Year  >= 18;
		}
		public static Customer MostValuable(Customer customerA, Customer customerB)
		{
			decimal totalSpendingsA = 0;
			decimal totalSpengingsB = 0;

			customerA.Orders.ForEach(o => totalSpendingsA += o.TotalAmmount);
			customerB.Orders.ForEach(o => totalSpengingsB += o.TotalAmmount);

			return totalSpendingsA > totalSpengingsB ? customerA : customerB;
		}
		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
	}
}
