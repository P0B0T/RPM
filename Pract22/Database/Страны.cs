using System;
using System.Collections.Generic;
using System.IO;

namespace Pract22;

public partial class Страны
{
    public int Код { get; set; }

    public string Название { get; set; } = null!;

    public string? Материк { get; set; }

    public string МатерикCheck
    {
        get
        {
            if (Материк == null)
            {
                return "Не указано";
            }
            else
            {
                return Материк;
            }
        }
    }

    public string? Столица { get; set; }

    public string СтолицаCheck
    {
        get
        {
            if (Столица == null)
            {
                return "Не указано";
            }
            else
            {
                return Столица;
            }
        }
    }

    public int КоличествоЖителей { get; set; }

    public string? ФотоСтраны { get; set; }

    public string ФотоСтраныJPG
    {
        get
        {
            if (ФотоСтраны == null)
            {
                return null;
            }
            else
            {
                string namePhoto = Directory.GetCurrentDirectory() + "\\images\\" + ФотоСтраны;
                return namePhoto;
            }
        }
    }

    public virtual ICollection<ЭтническийСостав> ЭтническийСостав { get; set; } = new List<ЭтническийСостав>();
}
