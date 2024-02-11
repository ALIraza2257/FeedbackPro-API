using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FeedbackPro.Models;

public partial class FeedbackDetail
{
    [Key]
    public long Id { get; set; }

    public long? FeedbackId { get; set; }

    public long? FormFieldId { get; set; }

    public string? FormFieldName { get; set; }

    public string? FormFieldCaptionToShow { get; set; }

    public short? RefFieldTypeId { get; set; }

    public string? FormFieldValue { get; set; }

    public long CompanyId { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool IsActive { get; set; }
}
