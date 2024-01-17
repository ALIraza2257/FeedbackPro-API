using System;
using System.Collections.Generic;

namespace FeedbackPro.Models;

public partial class RefCompany
{
    public long Id { get; set; }

    public string? LegalName { get; set; }

    public string? ShortName { get; set; }

    public string Phone { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? ZipCodePobox { get; set; }

    public long? StateId { get; set; }

    public long? CityId { get; set; }

    public long? CountryId { get; set; }

    public short? RefTimeZoneId { get; set; }

    public short? TimeDifferenceFromServer { get; set; }

    public short? RefBaseCurrencyId { get; set; }

    public string? LogoUrl { get; set; }

    public long EntryUserId { get; set; }

    public DateTime EntryDate { get; set; }

    public bool IsActive { get; set; }
}
