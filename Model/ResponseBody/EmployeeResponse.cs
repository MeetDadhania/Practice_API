using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ResponseBody
{
    public class EmployeeResponse
    {

        /// <summary>
        /// Employee ID
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string Name { get; set; } = null!;

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
