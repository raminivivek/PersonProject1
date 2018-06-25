using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
		public class Person
		{
			public int Person_IDNO { get; set; }
			public int Address_IDNO { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public Nullable<System.DateTime> CreatedDate { get; set; }
			public Nullable<System.DateTime> UpdatedDate { get; set; }

			public virtual Address_T Address_T { get; set; }
		}

		public class Address_T		{
			public int Address_IDNO { get; set; }
			public Nullable<System.DateTime> CreatedDate { get; set; }
			public Nullable<System.DateTime> UpdatedDate { get; set; }
			public string AddressLine1 { get; set; }
			public string AddressLine2 { get; set; }
			public string City { get; set; }
			public string State { get; set; }
			public string ZipCode { get; set; }

			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
			public virtual ICollection<Person> Person { get; set; }
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
			public virtual ICollection<Phone_T> Phone_T { get; set; }
		}
		public class Phone_T
		{
			public int Phone_IDNO { get; set; }
			public string PhoneNumber { get; set; }
			public string PhoneType { get; set; }
			public Nullable<System.DateTime> CreatedDate { get; set; }
			public Nullable<int> Address_IDNO { get; set; }
			public Nullable<System.DateTime> UpdatedDate { get; set; }

			public virtual Address_T Address_T { get; set; }
		}
	public class WholeClass
	{
		public int Person_IDNO { get; set; }
		public int Address_IDNO { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Nullable<System.DateTime> CreatedDate { get; set; }
		public Nullable<System.DateTime> UpdatedDate { get; set; }

		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public int Phone_IDNO { get; set; }
		public string PhoneNumber { get; set; }
		public string PhoneType { get; set; }


	}

}