using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    public class ServiceRequest
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // Example statuses: "Pending", "In Progress", "Completed"
    }
}
