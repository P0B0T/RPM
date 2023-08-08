using System;
using System.Collections.Generic;

namespace Pract20;

public partial class Orders
{
    public DateTime Date { get; set; }

    public int OrderNumber { get; set; }

    public string Client { get; set; } = null!;

    public string CarBrand { get; set; } = null!;

    public int IdOfTheTypeOfWork { get; set; }

    public int IdArtists { get; set; }

    public virtual DirectoryOfPerformersOfWork IdArtistsNavigation { get; set; } = null!;

    public virtual DirectoryOfTypesOfWork IdOfTheTypeOfWorkNavigation { get; set; } = null!;
}
