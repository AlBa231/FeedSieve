using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FeedSieve.Models;
using System.Collections.ObjectModel;

namespace FeedSieve.PageModels;

public sealed partial class FolderViewModel : ObservableObject
{
    public string Id { get; }

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private bool _isExpanded;

    public ObservableCollection<FeedItemViewModel> Feeds { get; }

    /// <summary>Count of unread feeds; recalculated whenever a feed's read state changes.</summary>
    public int UnreadCount => Feeds.Count(f => !f.IsRead);

    public FolderViewModel(string id, string name, IEnumerable<FeedItemModel> feeds, bool isExpanded)
    {
        Id = id;
        _name = name;
        _isExpanded = isExpanded;

        Feeds = new ObservableCollection<FeedItemViewModel>(
            feeds.Select(f => new FeedItemViewModel(f)));

        foreach (var feed in Feeds)
            feed.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(FeedItemViewModel.IsRead))
                    OnPropertyChanged(nameof(UnreadCount));
            };
    }

    [RelayCommand]
    private void ToggleExpanded() => IsExpanded = !IsExpanded;

    [RelayCommand]
    private void Rename(string newName)
    {
        if (!string.IsNullOrWhiteSpace(newName))
            Name = newName.Trim();
    }
}
