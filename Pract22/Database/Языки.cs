using System;
using System.Collections.Generic;

namespace Pract22;

public partial class Языки
{
    public int Код { get; set; }

    public string Название { get; set; } = null!;

    public string ЯзыковаяГруппа { get; set; } = null!;

    public string? ВидЗнаковойСистемы { get; set; }

    public virtual ICollection<ЭтническийСостав> ЭтническийСостав { get; set; } = new List<ЭтническийСостав>();
}
