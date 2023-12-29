using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public string compensationId {  get; set; }
        public string employeeId { get; set; }
        public decimal salary { get; set; }
        public DateTime effectiveDate { get; set; }
    }
}
