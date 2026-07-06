namespace FeedSieve;

public partial class App : Application
{
    private readonly IFeedSeedDataService _feedSeed;

    public App(IFeedSeedDataService feedSeed)
    {
        _feedSeed = feedSeed;
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell(_feedSeed));
    }
}