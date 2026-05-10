using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Northwind_DbModels;

public partial class SummaryOfSalesByQuarter
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
