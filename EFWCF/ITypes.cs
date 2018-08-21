using EFCommon;
using EFWCF.Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace EFWCF
{
	[ServiceContract]
	public interface ITypes
	{
		[OperationContract]
		ResponseBase<IEnumerable<TypesContract>> GetCities(long departmentId, long countryId);

		[OperationContract]
		ResponseBase<List<TypesContract>> GetDepartments(long countryId);

		[OperationContract]
		ResponseBase<List<TypesContract>> GetCountries();

		[OperationContract]
		ResponseBase<List<TypesContract>> GetDocumentTypes();
	}
}
