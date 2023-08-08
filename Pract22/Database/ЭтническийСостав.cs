using System;
using System.Collections.Generic;

namespace Pract22;

public partial class ЭтническийСостав
{
    public int Страна { get; set; }

    public int Язык { get; set; }

    public short Год { get; set; }

    public int Численность { get; set; }

    public virtual Страны СтранаNavigation { get; set; } = null!;

    public virtual Языки ЯзыкNavigation { get; set; } = null!;
}
