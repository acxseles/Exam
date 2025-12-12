using System;
using System.Collections.Generic;

namespace Company.Models;

public partial class Post
{
    public int Id { get; set; }

    public string PostEmployee { get; set; } = null!;

    public decimal Wages { get; set; }

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();
}
