using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestBody
{
    public class EmployeeRequest
    {
        /// <summary>
        /// Employee name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Employee EmailID
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Employee Age
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Employee PhoneNumber
        /// </summary>
        public long? PhoneNumber { get; set; }
    }
}
