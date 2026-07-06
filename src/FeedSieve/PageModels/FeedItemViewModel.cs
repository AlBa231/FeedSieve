using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FeedSieve.Models;

namespace FeedSieve.PageModels;

public sealed partial class FeedItemViewModel : ObservableObject
{
    private readonly FeedItemModel _model;

    public string Id => _model.Id;
    public string Title => _model.Title;
    public string Source => _model.Source;
    public string Favicon => _model.Favicon;
    public string Summary => _model.Summary;
    public string Timestamp => _model.Timestamp;
    public string? Tag => _model.Tag;
    public string? ImageUrl => _model.ImageUrl;
    public string? ImageAlt => _model.ImageAlt;
    public bool Featured => _model.Featured;

    [ObservableProperty]
    private bool _isRead;

    [ObservableProperty]
    private bool _isSaved;

    public FeedItemViewModel(FeedItemModel model)
    {
        _model = model;
        _isRead = model.IsRead;
    }

    [RelayCommand]
    private void Open() => IsRead = true;

    [RelayCommand]
    private void ToggleSaved() => IsSaved = !IsSaved;
}
