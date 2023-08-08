using System;
using System.Collections.Generic;

namespace Pract20;

public partial class InformationAboutPerformer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public int IdArtists { get; set; }

    public virtual DirectoryOfPerformersOfWork IdArtistsNavigation { get; set; } = null!;
}
