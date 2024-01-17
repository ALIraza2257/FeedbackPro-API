using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefCurrencyConversionRate
{
    public long Id { get; set; }

    public long? BaseCurrencyId { get; set; }

    public long? TransactionCurrencyId { get; set; }

    public double? ExchangeRate { get; set; }

    public long? CompanyId { get; set; }

    public long? ProjectId { get; set; }

    public DateTime? EntryDate { get; set; }

    public long? EntryUserId { get; set; }

    public bool? IsActive { get; set; }
}
