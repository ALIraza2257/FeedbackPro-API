using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefCountry
{
    public long Id { get; set; }

    public string? Iso { get; set; }

    public string? Description { get; set; }

    public string? CountryCode { get; set; }

    public short? NumberCode { get; set; }

    public short? PhoneCode { get; set; }

    public long? RefRegionId { get; set; }

    public long CompanyId { get; set; }

    public long? EntryUserId { get; set; }

    public DateTime? EntryDate { get; set; }

    public bool? IsActive { get; set; }
}
