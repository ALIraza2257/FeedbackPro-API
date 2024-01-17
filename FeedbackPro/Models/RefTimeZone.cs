using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefTimeZone
{
    public short Id { get; set; }

    public string? Description { get; set; }

    public string? Value { get; set; }

    public long? CompanyId { get; set; }

    public long? ProjectId { get; set; }

    public long? EntryUserId { get; set; }

    public DateTime? EntryDate { get; set; }

    public bool? IsActive { get; set; }
}
