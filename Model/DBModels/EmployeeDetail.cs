using System;
using System.Collections.Generic;

namespace Model.DBModels;

public partial class EmployeeDetail
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
