using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefUser
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? IdentityNo { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string? Password { get; set; }

    public string? UserProfileImage { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsSuperAdmin { get; set; }

    public bool? IsExternal { get; set; }

    public long? CompanyId { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool? IsActive { get; set; }

    public long LastSelectedRoleId { get; set; }
}
