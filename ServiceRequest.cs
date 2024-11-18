using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    public class ServiceRequest
    {
        public int RequestID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Pending"; // Default status

        public ServiceRequest(int requestId, string description)
        {
            RequestID = requestId;
            Description = description;
        }
    }
}
