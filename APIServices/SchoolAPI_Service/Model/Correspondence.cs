using System;
namespace SchoolAPI_Service.Model
{
	public class Correspondence
	{
        public Guid CorrespondenceId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string ContactNo { get; set; }

        public Correspondence()
		{
		}
	}
}

