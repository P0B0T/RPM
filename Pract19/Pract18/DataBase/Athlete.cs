using System;
using System.Collections.Generic;

namespace Pract18;

public partial class Athlete
{
    public int Id { get; set; }

    public string Hotel { get; set; } = null!;

    public int RoomNumber { get; set; }

    public int NumberOfSeats { get; set; }

    public string AthleteSFullName { get; set; } = null!;

    public string AgeGroup { get; set; } = null!;

    public string City { get; set; } = null!;

    public string SportTipe { get; set; } = null!;
}
