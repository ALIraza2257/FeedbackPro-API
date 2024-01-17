using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefCurrency
{
    public long Id { get; set; }

    public string? CurrencySymbol { get; set; }

    public string? CurrencyName { get; set; }

    public int? FrequencyChange { get; set; }

    public string? Description { get; set; }

    public long? CompanyId { get; set; }

    public DateTime? EntryDate { get; set; }

    public long? EntryUserId { get; set; }

    public bool? IsActive { get; set; }
}
