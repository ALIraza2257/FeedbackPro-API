using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefDeviceType
{
    public short Id { get; set; }

    public string? Description { get; set; }

    public long CompanyId { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool IsActive { get; set; }
}
