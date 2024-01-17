using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class Form
{
    public long Id { get; set; }

    public long CompanyId { get; set; }

    public string FormName { get; set; } = null!;

    public string? FormTitleToShow { get; set; }

    public string? MessageToShow { get; set; }

    public string? FeedbackSubmissionMessage { get; set; }

    public string? FeedbackErrorMessage { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool IsActive { get; set; }
}
