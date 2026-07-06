namespace FeedSieve.Pages;

public sealed class FeedItemTemplateSelector : DataTemplateSelector
{
    public required DataTemplate FeaturedTemplate { get; set; }
    public required DataTemplate StandardTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var feed = (FeedItemViewModel)item;
        return feed.Featured && !string.IsNullOrEmpty(feed.ImageUrl)
            ? FeaturedTemplate
            : StandardTemplate;
    }
}
