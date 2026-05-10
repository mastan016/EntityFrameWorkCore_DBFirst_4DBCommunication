using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.MidLandModels;

public partial class ErrorDetail
{
    public int TxnId { get; set; }

    public string? Message { get; set; }

    public string? ProcedureName { get; set; }

    public DateTime? Timestamp { get; set; }
}
