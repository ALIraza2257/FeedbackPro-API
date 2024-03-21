using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class Qrcode
{
    public long Id { get; set; }

    public long? FormId { get; set; }

    public string? RefData1Caption { get; set; }

    public string? RefData1Value { get; set; }

    public string? RefData2Caption { get; set; }

    public string? RefData2Value { get; set; }

    public string? RefData3Caption { get; set; }

    public string? RefData3Value { get; set; }

    public string? QrcodeData { get; set; }

    public long CompanyId { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool IsActive { get; set; }

    public string Registration
    {
        get
        {
            return string.Format("{0} {1}",RefData1Caption,RefData1Value);
        }
    }
}
