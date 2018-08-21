using EFWeb.Models;
using EFWeb.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EFWeb.Controllers
{
	public class CustomerController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<ActionResult> CreateIndex()
		{
			var service = new TypesService();
			var model = new CustomerModel();

			var documentsTypes = await service.GetDocumentTypes();
			var countries = await service.GetCountries();

			model.DocumentTypes = documentsTypes.Data;
			model.Countries = countries.Data;

			return View(model);
		}

		[HttpPost]
		public async Task<ActionResult> CreateResult(CustomerModel data)
		{
			var service = new CustomerService();
			var result = await service.CreateCustomer(data);

			return Json(result, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public async Task<ActionResult> ReadIndex()
		{
			var service = new CustomerService();
			var model = new List<CustomerModel>();

			var result = await service.ReadCustomers();
			if (result.Code == 200) model = result.Data.OrderBy(m => m.Id).ToList();

			return View(model);
		}

		[HttpGet]
		public async Task<ActionResult> UpdateIndex(long id)
		{
			var service = new CustomerService();
			var types = new TypesService();
			var model = new CustomerModel();

			var result = await service.ReadCustomerByIdOrName(id);
			if (result.Code == 200)
			{
				var documentTypes = await types.GetDocumentTypes();
				var countries = await types.GetCountries();
				var departments = await types.GetDepartments(result.Data.CountryId);
				var cities = await types.GetCities(result.Data.DepartmentId, result.Data.CountryId);

				model = result.Data;
				model.DocumentTypes = documentTypes.Data;
				model.Countries = countries.Data;
				model.Departments = departments.Data;
				model.Cities = cities.Data;
			}

			return View(model);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateResult(CustomerModel data)
		{
			var service = new CustomerService();
			var result = await service.UpdateCustomer(data);
			
			var nresult = await service.ReadCustomerByIdOrName(data.Id);
			nresult.Message = result.Message;

			return Json(nresult, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public async Task<ActionResult> DeleteIndex(long id)
		{
			var service = new CustomerService();
			var types = new TypesService();
			var model = new CustomerModel();

			var result = await service.ReadCustomerByIdOrName(id);
			if (result.Code == 200)
			{
				model = result.Data;
			}

			return View(model);
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteResult(CustomerModel data)
		{
			var service = new CustomerService();
			var result = await service.DeleteCustomer(data.Id);

			return Json(result, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public async Task<ActionResult> GetDepartments(long countryId)
		{
			var service = new TypesService();
			var deps = await service.GetDepartments(countryId);

			return Json(deps, JsonRequestBehavior.AllowGet);			
		}

		[HttpGet]
		public async Task<ActionResult> GetCities(long countryId, long departmentId)
		{
			var service = new TypesService();
			var deps = await service.GetCities(departmentId, countryId);

			return Json(deps, JsonRequestBehavior.AllowGet);
		}
	}
}