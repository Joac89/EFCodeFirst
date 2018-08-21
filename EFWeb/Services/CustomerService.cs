using EFCommon;
using EFWeb.CustomerSoap;
using EFWeb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFWeb.Services
{
	public class CustomerService
	{
		public async Task<ResponseBase<long>> CreateCustomer(CustomerModel data)
		{
			var response = new ResponseBase<long>();
			var service = new CustomerClient();

			try
			{
				var callback = await service.CreateCustomerAsync(new CustomerContract()
				{
					Name = data.Name,
					Address = data.Address,
					BirthDate = data.BirthDate,
					CityId = data.CityId,
					CityName = data.CityName,
					CountryId = data.CountryId,
					CountryName = data.CountryName,
					DepartmentId = data.DepartmentId,
					DepartmentName = data.DepartmentName,
					DocumentId = data.DocumentId,
					DocumentType = data.DocumentType,
					DocumentTypeName = data.DocumentTypeName,
				});

				response.Code = callback.Code;
				response.Data = callback.Data;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudo crear el usuario: {ex.Message}";
			}

			service.Close();
			return response;
		}

		public async Task<ResponseBase<List<CustomerModel>>> ReadCustomers()
		{
			var response = new ResponseBase<List<CustomerModel>>();
			var list = new List<CustomerModel>();
			var service = new CustomerClient();

			try
			{
				var callback = await service.ReadCustomersAsync();
				var data = callback.Data;

				foreach (var item in data)
				{
					list.Add(new CustomerModel()
					{
						Id = item.Id,
						Name = item.Name,
						Address = item.Address,
						BirthDate = item.BirthDate,
						CityId = item.CityId,
						CityName = item.CityName,
						CountryId = item.CountryId,
						CountryName = item.CountryName,
						DepartmentId = item.DepartmentId,
						DepartmentName = item.DepartmentName,
						DocumentId = item.DocumentId,
						DocumentType = item.DocumentType,
						DocumentTypeName = item.DocumentTypeName,
					});
				}

				response.Code = callback.Code;
				response.Data = list;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudieron listar los usuario: {ex.Message}";
			}

			service.Close();
			return response;
		}

		public async Task<ResponseBase<CustomerModel>> ReadCustomerByIdOrName(long id = 0, string name = "")
		{
			var response = new ResponseBase<CustomerModel>();
			var service = new CustomerClient();

			try
			{
				var callback = await service.ReadCustomerByIdOrNameAsync(id, !string.IsNullOrWhiteSpace(name) ? name : null);
				var data = callback.Data;
				var customer = new CustomerModel()
				{
					Id = data.Id,
					Name = data.Name,
					Address = data.Address,
					BirthDate = data.BirthDate,
					CityId = data.CityId,
					CityName = data.CityName,
					CountryId = data.CountryId,
					CountryName = data.CountryName,
					DepartmentId = data.DepartmentId,
					DepartmentName = data.DepartmentName,
					DocumentId = data.DocumentId,
					DocumentType = data.DocumentType,
					DocumentTypeName = data.DocumentTypeName,
				};

				response.Code = callback.Code;
				response.Data = customer;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudieron listar los usuario: {ex.Message}";
			}

			service.Close();
			return response;
		}

		public async Task<ResponseBase<bool>> UpdateCustomer(CustomerModel data)
		{
			var response = new ResponseBase<bool>();
			var service = new CustomerClient();

			try
			{
				var callback = await service.UpdateCustomerAsync(new CustomerContract()
				{
					Id = data.Id,
					Name = data.Name,
					Address = data.Address,
					BirthDate = data.BirthDate,
					CityId = data.CityId,
					CityName = data.CityName,
					CountryId = data.CountryId,
					CountryName = data.CountryName,
					DepartmentId = data.DepartmentId,
					DepartmentName = data.DepartmentName,
					DocumentId = data.DocumentId,
					DocumentType = data.DocumentType,
					DocumentTypeName = data.DocumentTypeName,
				});

				response.Code = callback.Code;
				response.Data = callback.Data;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudo crear el usuario: {ex.Message}";
			}

			service.Close();
			return response;
		}

		public async Task<ResponseBase<bool>> DeleteCustomer(long id)
		{
			var response = new ResponseBase<bool>();
			var service = new CustomerClient();

			try
			{
				var callback = await service.DeleteCustomerAsync(id);

				response.Code = callback.Code;
				response.Data = callback.Data;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudo crear el usuario: {ex.Message}";
			}

			service.Close();
			return response;
		}
	}
}