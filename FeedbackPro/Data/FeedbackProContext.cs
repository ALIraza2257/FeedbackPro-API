using FeedbackPro.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace FeedbackPro.Data;

public partial class FeedbackProContext : DbContext
{
    public FeedbackProContext()
    {

    }

    public FeedbackProContext(DbContextOptions<FeedbackProContext> options)
        : base(options)
    {
    }

    public DbConnection GetConnection()
    {
        return Database.GetDbConnection();
    }
        
    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackDetail> FeedbackDetails { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FormField> FormFields { get; set; }

    public virtual DbSet<Qrcode> Qrcodes { get; set; }

    public virtual DbSet<RefCity> RefCities { get; set; }

    public virtual DbSet<RefCompany> RefCompanies { get; set; }

    public virtual DbSet<RefCountry> RefCountries { get; set; }

    public virtual DbSet<RefCurrency> RefCurrencies { get; set; }

    public virtual DbSet<RefCurrencyConversionRate> RefCurrencyConversionRates { get; set; }

    public virtual DbSet<RefDeviceType> RefDeviceTypes { get; set; }

    public virtual DbSet<RefFieldType> RefFieldTypes { get; set; }

    public virtual DbSet<RefTimeZone> RefTimeZones { get; set; }

    public virtual DbSet<RefUser> RefUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-B74JVH0;Database=FeedbackPro;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Feedback");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.FormId).HasColumnName("FormID");
            //entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.QrcodeId).HasColumnName("QRCodeID");
            entity.Property(e => e.SubmitterDeviceType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubmitterEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubmitterIpaddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SubmitterIPAddress");
            entity.Property(e => e.SubmitterLocationLatitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SubmitterLocation-Latitude");
            entity.Property(e => e.SubmitterLocationLongitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SubmitterLocation-Longitude");
            entity.Property(e => e.SubmitterName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubmitterPhone)
                .HasMaxLength(100)
                .IsUnicode(false);



        });

        modelBuilder.Entity<FeedbackDetail>(entity =>
        {
            entity.HasNoKey();

            entity.HasKey(e => e.Id);

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.FormFieldCaptionToShow)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FormFieldId).HasColumnName("FormFieldID");
            entity.Property(e => e.FormFieldName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FormFieldValue)
                .HasMaxLength(200)
                .IsUnicode(false);
            //entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RefFieldTypeId).HasColumnName("RefFieldTypeID");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Form");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.FeedbackErrorMessage)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackSubmissionMessage)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FormName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FormTitleToShow)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MessageToShow)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FormField>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FormField");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.FieldCaptionToShow)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FieldName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FormId).HasColumnName("FormID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RefFieldTypeId).HasColumnName("RefFieldTypeID");
        });

        modelBuilder.Entity<Qrcode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("QRCode");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.FormId).HasColumnName("FormID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.QrcodeData)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("QRCodeData");
            entity.Property(e => e.RefData1Caption)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RefData1-Caption");
            entity.Property(e => e.RefData1Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RefData1-Value");
            entity.Property(e => e.RefData2Caption)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RefData2-Caption");
            entity.Property(e => e.RefData2Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RefData2-Value");
            entity.Property(e => e.RefData3Caption)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RefData3-Caption");
            entity.Property(e => e.RefData3Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RefData3-Value");
        });

        modelBuilder.Entity<RefCity>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefCity");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RefProvinceId).HasColumnName("RefProvinceID");
        });

        modelBuilder.Entity<RefCompany>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefCompany");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LegalName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LogoUrl).IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RefBaseCurrencyId).HasColumnName("RefBaseCurrencyID");
            entity.Property(e => e.RefTimeZoneId).HasColumnName("RefTimeZoneID");
            entity.Property(e => e.ShortName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.ZipCodePobox)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZipCodePOBox");
        });

        modelBuilder.Entity<RefCountry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefCountry");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Iso)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO");
            entity.Property(e => e.RefRegionId).HasColumnName("RefRegionID");
        });

        modelBuilder.Entity<RefCurrency>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefCurrency");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<RefCurrencyConversionRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefCurrencyConversionRate");

            entity.Property(e => e.BaseCurrencyId).HasColumnName("BaseCurrencyID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.TransactionCurrencyId).HasColumnName("TransactionCurrencyID");
        });

        modelBuilder.Entity<RefDeviceType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefDeviceType");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<RefFieldType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefFieldType");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<RefTimeZone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefTimeZone");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Value)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RefUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefUser");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.EntryUserId).HasColumnName("EntryUserID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdentityNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastSelectedRoleId).HasColumnName("LastSelectedRoleID");
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserProfileImage)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
