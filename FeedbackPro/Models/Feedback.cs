using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackPro.Models;

public partial class Feedback
{
    [Key]
    public long Id { get; set; }

    public long? FormId { get; set; }

    public long? QrcodeId { get; set; }

    public string? SubmitterName { get; set; }

    public string? SubmitterEmail { get; set; }

    public string? SubmitterPhone { get; set; }

    public string? SubmitterIpaddress { get; set; }

    public string? SubmitterLocationLatitude { get; set; }

    public string? SubmitterLocationLongitude { get; set; }

    public string? SubmitterDeviceType { get; set; }

    public long CompanyId { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool IsActive { get; set; }

    [NotMapped]
    public IList<FeedbackDetail> FeedbackDetail { get; set; }
}



