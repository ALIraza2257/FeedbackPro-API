using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class FormField
{
    public long Id { get; set; }

    public long? FormId { get; set; }

    public string? FieldName { get; set; }

    public string? FieldCaptionToShow { get; set; }

    public short? RefFieldTypeId { get; set; }

    public bool? IsMandatory { get; set; }

    public long CompanyId { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool IsActive { get; set; }
}
