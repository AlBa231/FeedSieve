namespace FeedSieve.Pages;

public partial class FeedListPage : ContentPage
{
    public FeedListPage(FeedTabViewModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}