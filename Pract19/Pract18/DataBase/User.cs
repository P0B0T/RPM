using System;
using System.Collections.Generic;

namespace Pract18.DataBase;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; }

    public string Name { get; set; }

    public string Patronymic { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public int Role { get; set; }

    public virtual Role RoleNavigation { get; set; }
}
