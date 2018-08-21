using EFCommon;
using EFWCF.Contracts;
using EFWCF.ORMS;
using System;
using System.Collections.Generic;

namespace EFWCF
{
	public class Types : ITypes
	{
		public ResponseBase<IEnumerable<TypesContract>> GetCities(long departmentId, long countryId)
		{
			var response = new ResponseBase<IEnumerable<TypesContract>>();
			var list = new List<TypesContract>();

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					var result = context.USP_GET_CITY(departmentId, countryId);

					foreach (var item in result)
					{
						var customer = new TypesContract()
						{
							Id = item.CityId,
							Description = item.Description
						};
						list.Add(customer);
					}

					response.Code = StatusCode.Ok;
					response.Data = list;
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = ex.Message;
			}

			return response;
		}

		public ResponseBase<List<TypesContract>> GetDepartments(long countryId)
		{
			var response = new ResponseBase<List<TypesContract>>();
			var list = new List<TypesContract>();

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					var result = context.USP_GET_DEPARTMENT(countryId);

					foreach (var item in result)
					{
						var customer = new TypesContract()
						{
							Id = item.DepartmentId,
							Description = item.Description
						};
						list.Add(customer);
					}

					response.Code = StatusCode.Ok;
					response.Data = list;
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = ex.Message;
			}

			return response;
		}

		public ResponseBase<List<TypesContract>> GetCountries()
		{
			var response = new ResponseBase<List<TypesContract>>();
			var list = new List<TypesContract>();

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					var result = context.USP_GET_COUNTRY();

					foreach (var item in result)
					{
						var customer = new TypesContract()
						{
							Id = item.CountryId,
							Description = item.Description
						};
						list.Add(customer);
					}

					response.Code = StatusCode.Ok;
					response.Data = list;
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = ex.Message;
			}

			return response;
		}

		public ResponseBase<List<TypesContract>> GetDocumentTypes()
		{
			var response = new ResponseBase<List<TypesContract>>();
			var list = new List<TypesContract>();

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					var result = context.USP_GET_DOCUMENT_TYPES();

					foreach (var item in result)
					{
						var customer = new TypesContract()
						{
							Id = item.DocumentTypeId,
							Description = item.Description
						};
						list.Add(customer);
					}

					response.Code = StatusCode.Ok;
					response.Data = list;
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = ex.Message;
			}

			return response;
		}
	}
}
