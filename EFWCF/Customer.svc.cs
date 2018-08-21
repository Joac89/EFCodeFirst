using EFCommon;
using EFWCF.Contracts;
using EFWCF.ORMS;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Threading.Tasks;

namespace EFWCF
{
	public class Customer : ICustomer
	{
		public ResponseBase<long> CreateCustomer(CustomerContract data)
		{
			var response = new ResponseBase<long>();

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					var id = new ObjectParameter("id", typeof(long));
					context.USP_CUSTOMER_CREATE(data.Name, data.Address, data.BirthDate.ToDateTime(), data.DocumentId, data.DocumentType, data.CityId, id);
					context.SaveChanges();

					response.Code = StatusCode.Ok;
					response.Data = long.Parse(id.Value.ToString());
					response.Message = $"Usuario creado correctamente con ID {response.Data}";
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = $"Ups! no se pudo crear el usuario: {ex.Message}";
			}

			return response;
		}

		public ResponseBase<bool> DeleteCustomer(long id)
		{
			var response = new ResponseBase<bool>() { Data = false };

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					context.USP_CUSTOMER_DELETE(id);
					context.SaveChanges();

					response.Code = StatusCode.Ok;
					response.Data = true;
					response.Message = $"Usuario con ID {id} fue eliminado correctamente";
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = ex.Message;
				response.Message = $"Ups! no se pudo eliminar el usuario {id}: {ex.Message}";
			}

			return response;
		}

		public ResponseBase<CustomerContract> ReadCustomerByIdOrName(long id = 0, string name = "")
		{
			var response = new ResponseBase<CustomerContract>();
			var customer = new CustomerContract();

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					var result = context.USP_CUSTOMER_READ(id, !string.IsNullOrWhiteSpace(name) ? name : null);

					foreach (var item in result)
					{
						customer.Name = item.Name;
						customer.Address = item.Address;
						customer.BirthDate = item.BirthDate.ToDateString();
						customer.Id = item.CustomerId;
						customer.DocumentId = item.DocumentId;
						customer.DocumentType = item.DocumentType;
						customer.DocumentTypeName = item.DocumentTypeName;
						customer.CityId = item.CityId;
						customer.CityName = item.CityName;
						customer.DepartmentName = item.DepartmentName;
						customer.CountryName = item.CountryName;
						customer.DepartmentId = item.DepartmentId;
						customer.CountryId = item.CountryId;
					}

					response.Code = StatusCode.Ok;
					response.Data = customer;
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = ex.Message;
			}

			return response;
		}

		public ResponseBase<List<CustomerContract>> ReadCustomers()
		{
			var response = new ResponseBase<List<CustomerContract>>();
			var list = new List<CustomerContract>();

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					var result = context.USP_CUSTOMER_READ(0, null);

					foreach (var item in result)
					{
						var customer = new CustomerContract()
						{
							Name = item.Name,
							Address = item.Address,
							BirthDate = item.BirthDate.ToDateString(),
							Id = item.CustomerId,
							DocumentId = item.DocumentId,
							DocumentType = item.DocumentType,
							DocumentTypeName = item.DocumentTypeName,
							CityId = item.CityId,
							CityName = item.CityName,
							DepartmentName = item.DepartmentName,
							CountryName = item.CountryName,
							DepartmentId = item.DepartmentId,
							CountryId = item.CountryId
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

		public ResponseBase<bool> UpdateCustomer(CustomerContract data)
		{
			var response = new ResponseBase<bool>() { Data = false };

			try
			{
				using (var context = new EF_DataBaseEntities())
				{
					context.USP_CUSTOMER_UPDATE(data.Id, data.Name, data.Address, data.BirthDate.ToDateTime(), data.DocumentId, data.DocumentType, data.CityId);
					context.SaveChanges();

					response.Code = StatusCode.Ok;
					response.Data = true;
					response.Message = $"Usuario con ID {data.Id} fue actualizado correctamente";
				}
			}
			catch (Exception ex)
			{
				response.Code = StatusCode.InternalError;
				response.Message = ex.Message;
				response.Message = $"Ups! no se pudo actualizar el usuario {data.Id}: {ex.Message}";
			}

			return response;
		}
	}
}
