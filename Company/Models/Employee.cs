using System;
using System.Collections.Generic;

namespace Company.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();
}
