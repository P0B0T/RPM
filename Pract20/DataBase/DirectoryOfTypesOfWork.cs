using System;
using System.Collections.Generic;

namespace Pract20;

public partial class DirectoryOfTypesOfWork
{
    public int IdWork { get; set; }

    public string CarBrand { get; set; } = null!;

    public string NameOfTheWork { get; set; } = null!;

    public decimal CostOfWork { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
