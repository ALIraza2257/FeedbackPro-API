﻿using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefCity
{
    public long Id { get; set; }

    public string? Description { get; set; }

    public long? RefProvinceId { get; set; }

    public long CompanyId { get; set; }

    public long? EntryUserId { get; set; }

    public DateTime? EntryDate { get; set; }

    public bool? IsActive { get; set; }
}
