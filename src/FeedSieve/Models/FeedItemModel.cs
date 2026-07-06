namespace FeedSieve.Models;

/// <summary>
/// UI-facing feed item shown in the feed list. Distinct from
/// FeedAggregator.Core.Providers.RawItem: this carries display-only fields
/// (favicon glyph, tag color key, formatted timestamp) already resolved,
/// so the view has zero formatting logic.
/// </summary>
public sealed class FeedItemModel
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Source { get; init; }

    /// <summary>Short glyph shown in the favicon badge, e.g. "TV", "RE".</summary>
    public required string Favicon { get; init; }

    public required string Summary { get; init; }

    /// <summary>Pre-formatted relative time, e.g. "6m ago".</summary>
    public required string Timestamp { get; init; }

    public bool IsRead { get; set; }

    /// <summary>Optional tag label, e.g. "AI", "Policy". Null = no chip shown.</summary>
    public string? Tag { get; init; }

    public string? ImageUrl { get; init; }

    public string? ImageAlt { get; init; }

    /// <summary>When true and ImageUrl is set, renders as the large hero-style row.</summary>
    public bool Featured { get; init; }
}
