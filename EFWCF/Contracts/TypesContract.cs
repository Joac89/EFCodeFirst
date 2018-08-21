using System.Runtime.Serialization;

namespace EFWCF.Contracts
{
	[DataContract]
	public class TypesContract
	{
		[DataMember]
		public long Id { get; set; }
		[DataMember]
		public string Description { get; set; }
	}
}