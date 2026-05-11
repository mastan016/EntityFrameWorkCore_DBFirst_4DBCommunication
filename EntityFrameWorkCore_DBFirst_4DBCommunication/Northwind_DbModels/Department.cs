using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Northwind_DbModels;

public partial class Department
{
    public int Deptid { get; set; }

    public string? Deptname { get; set; }

    public string? Deptlocation { get; set; }
}
