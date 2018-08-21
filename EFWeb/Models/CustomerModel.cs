using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFWeb.Models
{
	public class CustomerModel
	{
		public long Id { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public string Name { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public string Address { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public string BirthDate { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public string DocumentId { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public int DocumentType { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public long CityId { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public long CountryId { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public long DepartmentId { get; set; }
		[Required(ErrorMessage = "El campo es obligatorio")]
		public string DocumentTypeName { get; set; }
		public string CityName { get; set; }
		public string DepartmentName { get; set; }
		public string CountryName { get; set; }

		public IEnumerable<TypesModel> DocumentTypes { get; set; } = new List<TypesModel>();
		public IEnumerable<TypesModel> Countries { get; set; } = new List<TypesModel>();
		public IEnumerable<TypesModel> Departments { get; set; } = new List<TypesModel>();
		public IEnumerable<TypesModel> Cities { get; set; } = new List<TypesModel>();
	}

	//public class CustomerModelRead : CustomerModel
	//{
	//	[Required(ErrorMessage = "El campo es obligatorio")]
	//	public string DocumentTypeName { get; set; }
	//	public string CityName { get; set; }
	//	public string DepartmentName { get; set; }
	//	public string CountryName { get; set; }
	//}
}