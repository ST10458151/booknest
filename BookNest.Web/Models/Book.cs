using System.ComponentModel.DataAnnotations;

namespace BookNest.Web.Models;

public enum ReadingStatus
{
    [Display(Name = "Want to Read")] WantToRead,
    [Display(Name = "Currently Reading")] Reading,
    [Display(Name = "Finished")] Finished
}

public class Book : IValidatableObject
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Title { get; set; } = "";

    [Required, StringLength(120)]
    public string Author { get; set; } = "";

    [StringLength(60)]
    public string Genre { get; set; } = "";

    [Display(Name="Reading status")]
    public ReadingStatus Status { get; set; } = ReadingStatus.WantToRead;

    [Display(Name="Total pages")]
    [Range(1,100000)]
    public int? TotalPages { get; set; }

    [Display(Name="Pages read")]
    [Range(0,100000)]
    public int PagesRead { get; set; }

    [Display(Name="Your rating")]
    [Range(1,5)]
    public int? Rating { get; set; }

    [Display(Name="Cover image URL")]
    [StringLength(1000)]
    public string? CoverUrl { get; set; }

    [Display(Name="Personal notes")]
    [StringLength(1500)]
    public string? Notes { get; set; }

    public DateTime AddedOn { get; set; } = DateTime.UtcNow;

    public int Progress => TotalPages is > 0
        ? (int)Math.Clamp((double)PagesRead * 100 / TotalPages.Value,0,100)
        : Status == ReadingStatus.Finished ? 100 : 0;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (TotalPages is > 0 && PagesRead > TotalPages)
            yield return new ValidationResult("Pages read cannot exceed total pages.",
                [nameof(PagesRead)]);

        if (!string.IsNullOrWhiteSpace(CoverUrl) &&
            (!Uri.TryCreate(CoverUrl,UriKind.Absolute,out var url) ||
             url.Scheme != Uri.UriSchemeHttps))
            yield return new ValidationResult("Use a full HTTPS URL for the cover image.",
                [nameof(CoverUrl)]);
    }
}
