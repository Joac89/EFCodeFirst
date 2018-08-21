using EFCommon;
using EFWeb.Models;
using EFWeb.TypesSoap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFWeb.Services
{
	public class TypesService
	{	
		public async Task<ResponseBase<List<TypesModel>>> GetCities(long departmentId, long countryId)
		{
			var response = new ResponseBase<List<TypesModel>>();
			var list = new List<TypesModel>();
			var service = new TypesClient();

			try
			{
				var callback = await service.GetCitiesAsync(departmentId, countryId);
				var data = callback.Data;

				foreach (var item in data)
				{
					list.Add(new TypesModel()
					{
						Id = item.Id,
						Description = item.Description
					});
				}

				response.Code = callback.Code;
				response.Data = list;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudieron listar las ciudades: {ex.Message}";
			}

			service.Close();
			return response;
		}

		public async Task<ResponseBase<List<TypesModel>>> GetDepartments(long countryId)
		{
			var response = new ResponseBase<List<TypesModel>>();
			var list = new List<TypesModel>();
			var service = new TypesClient();

			try
			{
				var callback = await service.GetDepartmentsAsync(countryId);
				var data = callback.Data;

				foreach (var item in data)
				{
					list.Add(new TypesModel()
					{
						Id = item.Id,
						Description = item.Description
					});
				}

				response.Code = callback.Code;
				response.Data = list;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudieron listar los departamentos: {ex.Message}";
			}

			service.Close();
			return response;
		}

		public async Task<ResponseBase<List<TypesModel>>> GetCountries()
		{
			var response = new ResponseBase<List<TypesModel>>();
			var list = new List<TypesModel>();
			var service = new TypesClient();

			try
			{
				var callback = await service.GetCountriesAsync();
				var data = callback.Data;

				foreach (var item in data)
				{
					list.Add(new TypesModel()
					{
						Id = item.Id,
						Description = item.Description
					});
				}

				response.Code = callback.Code;
				response.Data = list;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudieron listar los paises: {ex.Message}";
			}

			service.Close();
			return response;
		}

		public async Task<ResponseBase<List<TypesModel>>> GetDocumentTypes()
		{
			var response = new ResponseBase<List<TypesModel>>();
			var list = new List<TypesModel>();
			var service = new TypesClient();

			try
			{
				var callback = await service.GetDocumentTypesAsync();
				var data = callback.Data;

				foreach (var item in data)
				{
					list.Add(new TypesModel()
					{
						Id = item.Id,
						Description = item.Description
					});
				}

				response.Code = callback.Code;
				response.Data = list;
				response.Message = callback.Message;
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.ServiceUnavailable;
				response.Message = $"Ups! no se pudieron listar los tipos de documentos: {ex.Message}";
			}

			service.Close();
			return response;
		}
	}
}