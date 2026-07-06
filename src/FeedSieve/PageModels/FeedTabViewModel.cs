using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FeedSieve.Models;
using System.Collections.ObjectModel;

namespace FeedSieve.PageModels;

/// <summary>
/// Backs a single Shell tab (Today / New / All / Saved). Each tab page binds
/// its own instance, seeded by a design-time or real data source — swap
/// SeedFolders for a real repository call once Story 4.2 (repository layer)
/// lands.
/// </summary>
public sealed partial class FeedTabViewModel : ObservableObject
{
    public ObservableCollection<FolderViewModel> Folders { get; }

    public int TotalUnread => Folders.Sum(f => f.UnreadCount);

    [ObservableProperty]
    private bool _isRefreshing;

    public FeedTabViewModel(IEnumerable<FolderViewModel> folders)
    {
        Folders = new ObservableCollection<FolderViewModel>(folders);

        foreach (var folder in Folders)
            folder.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(FolderViewModel.UnreadCount))
                    OnPropertyChanged(nameof(TotalUnread));
            };
    }

    [RelayCommand]
    private async Task RefreshAsync()
    {
        IsRefreshing = true;
        try
        {
            // TODO: replace with ISyncEngine / per-source FetchAsync calls (Architecture.md §6/§9).
            await Task.Delay(800);
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    private void AddFolder()
    {
        var folder = new FolderViewModel(
            id: $"new-{DateTime.UtcNow.Ticks}",
            name: "New Folder",
            feeds: Enumerable.Empty<FeedItemModel>(),
            isExpanded: true);

        folder.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(FolderViewModel.UnreadCount))
                OnPropertyChanged(nameof(TotalUnread));
        };

        Folders.Add(folder);
    }

    [RelayCommand]
    private void DeleteFolder(FolderViewModel folder) => Folders.Remove(folder);
}
