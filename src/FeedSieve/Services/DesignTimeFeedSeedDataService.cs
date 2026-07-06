using FeedSieve.Models;

namespace FeedSieve.Services;

public enum FeedTab { Today, New, All, Saved }

public interface IFeedSeedDataService
{
    FeedTabViewModel CreateTabViewModel(FeedTab tab);
}

/// <summary>
/// Design-time / placeholder data, ported verbatim from INITIAL_FOLDERS in the
/// Figma Make export (App.tsx). Replace with a real ISourceRepository /
/// IItemRepository-backed implementation once local storage (Architecture.md
/// §9, Epic 4) lands — the FeedTabViewModel shape won't need to change.
/// </summary>
public sealed class DesignTimeFeedSeedDataService : IFeedSeedDataService
{
    public FeedTabViewModel CreateTabViewModel(FeedTab tab) => tab switch
    {
        FeedTab.Today => BuildToday(),
        FeedTab.New => BuildNew(),
        FeedTab.All => BuildAll(),
        FeedTab.Saved => BuildSaved(),
        _ => throw new ArgumentOutOfRangeException(nameof(tab)),
    };

    private static FeedTabViewModel BuildAll() => new(new[]
    {
        new FolderViewModel("f1", "Morning Briefing", new[]
        {
            new FeedItemModel
            {
                Id = "a1", Title = "AI-assisted code review is changing how teams ship software",
                Source = "The Verge", Favicon = "TV",
                Summary = "A growing number of engineering teams are adopting AI review tools, compressing feedback loops that once took days into minutes.",
                Timestamp = "6m ago", IsRead = false, Tag = "AI",
                ImageUrl = "https://images.unsplash.com/photo-1674027444485-cec3da58eef4?w=600&h=300&fit=crop&auto=format",
                ImageAlt = "Abstract sphere of connected dots representing AI networks", Featured = true,
            },
            new FeedItemModel
            {
                Id = "a2", Title = "EU tech regulators fine Meta €1.2B over data transfer violations",
                Source = "Reuters", Favicon = "RE",
                Summary = "The Irish Data Protection Commission issued the largest GDPR fine to date, citing unlawful transfers of EU user data to US servers.",
                Timestamp = "31m ago", IsRead = false, Tag = "Policy",
            },
            new FeedItemModel
            {
                Id = "a3", Title = "Apple's Vision Pro: six months later, where does it stand?",
                Source = "9to5Mac", Favicon = "9M",
                Summary = "Reviewers and early adopters weigh in on whether spatial computing has crossed the chasm from novelty to utility.",
                Timestamp = "1h ago", IsRead = true,
                ImageUrl = "https://images.unsplash.com/photo-1706990769341-d450bb0c52b7?w=120&h=120&fit=crop&auto=format",
                ImageAlt = "Apple Vision Pro headset on a wooden table",
            },
        }, isExpanded: true),

        new FolderViewModel("f2", "World Affairs", new[]
        {
            new FeedItemModel
            {
                Id = "a4", Title = "G7 summit reaches agreement on AI governance framework",
                Source = "FT", Favicon = "FT",
                Summary = "Leaders signed a non-binding declaration establishing shared principles for regulating frontier AI models.",
                Timestamp = "2h ago", IsRead = false, Tag = "Geopolitics",
            },
            new FeedItemModel
            {
                Id = "a5", Title = "Japan raises rates for the third time in 2025",
                Source = "Bloomberg", Favicon = "BL",
                Summary = "The Bank of Japan cited sustained wage growth and CPI above target as justification for another 25bps hike.",
                Timestamp = "3h ago", IsRead = true,
            },
        }, isExpanded: false),
    });

    private static FeedTabViewModel BuildNew() => new(new[]
    {
        new FolderViewModel("t1", "Engineering", new[]
        {
            new FeedItemModel
            {
                Id = "t1a", Title = "Rust 2.0 roadmap: what's coming in the next edition",
                Source = "blog.rust-lang.org", Favicon = "RL",
                Summary = "The core team outlines async traits, const generics improvements, and a streamlined borrow checker error experience.",
                Timestamp = "14m ago", IsRead = false, Tag = "Rust",
            },
            new FeedItemModel
            {
                Id = "t1b", Title = "How Cloudflare rebuilt their edge network on eBPF",
                Source = "blog.cloudflare.com", Favicon = "CF",
                Summary = "A deep dive into the five-year migration from iptables to XDP-based packet processing, halving latency at the edge.",
                Timestamp = "2h ago", IsRead = false, Tag = "Infra",
                ImageUrl = "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?w=120&h=120&fit=crop&auto=format",
                ImageAlt = "Dense cable network in a data center",
            },
            new FeedItemModel
            {
                Id = "t1c", Title = "SQLite's WASM port hits 1.0 — what can you build with it?",
                Source = "The New Stack", Favicon = "NS",
                Summary = "sqlite-wasm ships with official bindings for Node, Deno, and browsers, opening new possibilities for local-first apps.",
                Timestamp = "4h ago", IsRead = true,
            },
        }, isExpanded: true),

        new FolderViewModel("t2", "Hardware", new[]
        {
            new FeedItemModel
            {
                Id = "t2a", Title = "TSMC 2nm risk production reportedly ahead of schedule",
                Source = "AnandTech", Favicon = "AT",
                Summary = "Sources close to Apple's supply chain suggest TSMC's N2 process yields are tracking above expectations for H2 tapeouts.",
                Timestamp = "5h ago", IsRead = false,
            },
            new FeedItemModel
            {
                Id = "t2b", Title = "Qualcomm Snapdragon X Elite: thermal benchmarks under load",
                Source = "Tom's Hardware", Favicon = "TH",
                Summary = "The new ARM chip sustains impressive peak performance, but sustained workloads reveal throttling above 35W.",
                Timestamp = "7h ago", IsRead = true,
            },
        }, isExpanded: false),
    });

    private static FeedTabViewModel BuildToday() => new(new[]
    {
        new FolderViewModel("d1", "Industry", new[]
        {
            new FeedItemModel
            {
                Id = "d1a", Title = "Figma AI: inside the autocomplete model trained on design patterns",
                Source = "Figma Blog", Favicon = "FG",
                Summary = "The team explains how they trained a model on anonymised component hierarchies to suggest layout alternatives in real time.",
                Timestamp = "1h ago", IsRead = false, Tag = "Tools",
            },
            new FeedItemModel
            {
                Id = "d1b", Title = "The resurgence of editorial type on the web",
                Source = "Eye Magazine", Favicon = "EM",
                Summary = "Variable fonts and improved hinting have made expressive display typography practical at scale, and designers are taking notice.",
                Timestamp = "3h ago", IsRead = false,
                ImageUrl = "https://images.unsplash.com/photo-1658863025658-4a259cc68fc9?w=600&h=280&fit=crop&auto=format",
                ImageAlt = "Close-up of editorial typography on paper", Featured = true,
            },
            new FeedItemModel
            {
                Id = "d1c", Title = "Dieter Rams at 91: an interview about the future of objects",
                Source = "Dezeen", Favicon = "DZ",
                Summary = "The father of \"less but better\" reflects on AI-generated design, throwaway culture, and what good design means now.",
                Timestamp = "6h ago", IsRead = true, Tag = "Interview",
                ImageUrl = "https://images.unsplash.com/photo-1755910182072-1eaa78c71a4b?w=120&h=120&fit=crop&auto=format",
                ImageAlt = "Orange Dieter Rams book on a stack of design books",
            },
        }, isExpanded: true),

        new FolderViewModel("d2", "Craft", new[]
        {
            new FeedItemModel
            {
                Id = "d2a", Title = "Optical kerning vs. metric kerning: a practical guide",
                Source = "Fonts In Use", Favicon = "FU",
                Summary = "When to trust the designer's intent and when to override it — a walkthrough of real-world editorial settings.",
                Timestamp = "8h ago", IsRead = false,
            },
            new FeedItemModel
            {
                Id = "d2b", Title = "Building a design system that survives a reorg",
                Source = "UX Collective", Favicon = "UC",
                Summary = "Governance structures, ownership models, and documentation patterns that keep systems alive when teams change.",
                Timestamp = "1d ago", IsRead = true,
            },
        }, isExpanded: false),
    });

    private static FeedTabViewModel BuildSaved() => new(new[]
    {
        new FolderViewModel("s1", "Read Later", new[]
        {
            new FeedItemModel
            {
                Id = "s1a", Title = "The economics of open-source: who funds the infrastructure?",
                Source = "ACM Queue", Favicon = "AQ",
                Summary = "A look at how FOSS foundations, corporate sponsors, and individual maintainers share the burden of critical shared infrastructure.",
                Timestamp = "2d ago", IsRead = false, Tag = "Essay",
            },
            new FeedItemModel
            {
                Id = "s1b", Title = "Understanding transformer attention: a visual deep dive",
                Source = "distill.pub", Favicon = "DP",
                Summary = "An interactive explainer that walks through self-attention, multi-head patterns, and how representations form across layers.",
                Timestamp = "3d ago", IsRead = false, Tag = "ML",
            },
        }, isExpanded: true),
    });
}
