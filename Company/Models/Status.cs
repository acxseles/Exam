using System;
using System.Collections.Generic;

namespace Company.Models;

public partial class Status
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int PostId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
