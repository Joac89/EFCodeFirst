using EFCommon;
using EFWCF.Contracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace EFWCF
{
	[ServiceContract]
	public interface ICustomer
	{
		[OperationContract]
		ResponseBase<long> CreateCustomer(CustomerContract data);

		[OperationContract]
		ResponseBase<List<CustomerContract>> ReadCustomers();

		[OperationContract]
		ResponseBase<CustomerContract> ReadCustomerByIdOrName(long id = 0, string name = "");

		[OperationContract]
		ResponseBase<bool> UpdateCustomer(CustomerContract data);

		[OperationContract]
		ResponseBase<bool> DeleteCustomer(long id);
	}
}
