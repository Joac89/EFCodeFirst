using System.Runtime.Serialization;

namespace EFWCF.Contracts
{
	[DataContract]
	public class CustomerContract
	{
		[DataMember]
		public long Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Address { get; set; }
		[DataMember]
		public string BirthDate { get; set; }
		[DataMember]
		public string DocumentId { get; set; }
		[DataMember]
		public int DocumentType { get; set; }
		[DataMember]
		public long CityId { get; set; }
		[DataMember]
		public long CountryId { get; set; }
		[DataMember]
		public long DepartmentId { get; set; }
		[DataMember]
		public string DocumentTypeName { get; set; }
		[DataMember]
		public string CityName { get; set; }
		[DataMember]
		public string DepartmentName { get; set; }
		[DataMember]
		public string CountryName { get; set; }
	}
}