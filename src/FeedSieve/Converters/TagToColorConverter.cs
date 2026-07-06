using System.Globalization;

namespace FeedSieve.Converters;

/// <summary>Maps a feed's Tag string to its chip color, mirroring TAG_COLORS in App.tsx.</summary>
public sealed class TagToColorConverter : IValueConverter
{
    private static readonly Dictionary<string, string> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["AI"] = "TagAI",
        ["Policy"] = "TagPolicy",
        ["Geopolitics"] = "TagGeopolitics",
        ["Rust"] = "TagRust",
        ["Infra"] = "TagInfra",
        ["Tools"] = "TagTools",
        ["Interview"] = "TagInterview",
        ["Essay"] = "TagEssay",
        ["ML"] = "TagML",
    };

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var key = value is string tag && Map.TryGetValue(tag, out var resourceKey)
            ? resourceKey
            : "TagDefault";

        return Application.Current!.Resources[key];
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
