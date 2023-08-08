using System;
using System.Collections.Generic;

namespace Pract20;

public partial class DirectoryOfPerformersOfWork
{
    public int IdArtists { get; set; }

    public string FullName { get; set; } = null!;

    public virtual ICollection<InformationAboutPerformer> InformationAboutPerformers { get; set; } = new List<InformationAboutPerformer>();

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
