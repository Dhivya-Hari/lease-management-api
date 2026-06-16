namespace LeaseManagement.API.Models
{
    public class Lease
    {
        public int Id { get; set; }

        public string LeaseNo { get; set; }

        public string Property { get; set; }

        public string Tenant { get; set; }

        public decimal Rent { get; set; }

        public string Status { get; set; }
    }
}