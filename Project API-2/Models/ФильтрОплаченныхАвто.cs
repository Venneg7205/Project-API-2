using System;
using System.Collections.Generic;

namespace Project_API_2.Models;

public partial class ФильтрОплаченныхАвто
{
    public string? Наименование { get; set; }

    public bool? ОтметкаОплате { get; set; }

    public string? ГосНомер { get; set; }
}
