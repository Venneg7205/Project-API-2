using System;
using System.Collections.Generic;

namespace Project_API_2.Models;

public partial class ФильтрНеоплаченныхАвто
{
    public string? Наименование { get; set; }

    public string? ГосНомер { get; set; }

    public bool? ОтметкаОплате { get; set; }
}
