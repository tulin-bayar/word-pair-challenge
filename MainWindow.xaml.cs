using System.Diagnostics;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media;

namespace WordPairChallenge;

public partial class MainWindow : Window
{
    private sealed record Card(string PairId, string Text, bool IsWord);
    private static readonly Dictionary<string, string> Vocabulary = new()
    {
        ["Loop"] = "Repeats a block of code",
        ["Variable"] = "A name that holds a value",
        ["Compiler"] = "Translates source code into target code",
        ["Debugger"] = "Lets you pause and inspect a running program",
        ["Stack"] = "Removes the most recently added item first",
        ["Queue"] = "Removes the earliest added item first",
        ["Boolean"] = "A type with only true or false values",
        ["Commit"] = "A saved snapshot in Git history"
    };

    
    private readonly HashSet<string> matched = new();
    private Button? first;
    private bool waiting;
    private int moves;
    private int round;
    private readonly Stopwatch elapsed = new();
    private readonly DispatcherTimer clock = new() { Interval = TimeSpan.FromMilliseconds(200) };

    private string TimeText
    {
        get
        {
            var time = elapsed.Elapsed;
            return $"{(long)time.TotalMinutes:00}:{time.Seconds:00}";
        }
    }

    private void RefreshTime() => TimeLabel.Text = $"Time  {TimeText}";

    private void Home_Click(object sender, RoutedEventArgs e)
    {
        ResultsOverlay.Visibility = Visibility.Collapsed;
        round++;
        clock.Stop();
        elapsed.Reset();
        GameScreen.Visibility = Visibility.Collapsed;
        HomeScreen.Visibility = Visibility.Visible;
    }

    public MainWindow()
    {
        InitializeComponent();
        clock.Tick += (_, _) => RefreshTime();
        Closed += (_, _) => clock.Stop();
    }

    private void NewGame_Click(object sender, RoutedEventArgs e) => StartGame();

    private void StartGame()
    {
        ResultsOverlay.Visibility = Visibility.Collapsed;
        round++;
        first = null;
        waiting = false;
        moves = 0;
        matched.Clear();
        Board.Children.Clear();
        var deck = new List<Card>();
        foreach (var (word, definition) in Vocabulary)
        {
            deck.Add(new Card(word, word, true));
            deck.Add(new Card(word, definition, false));
        }

        var cards = deck.ToArray();
        Random.Shared.Shuffle(cards);
        foreach (Card card in cards)
        {
            var button = new Button
            {
                Tag = card.PairId,
                DataContext = card,
                Margin = new Thickness(4),
                Padding = new Thickness(0),
                Style = (Style)FindResource("RoundedButton")
            };
            button.Click += Card_Click;
            Board.Children.Add(button);
            HideCard(button);
        }
        HomeScreen.Visibility = Visibility.Collapsed;
        GameScreen.IsEnabled = true;
        GameScreen.Visibility = Visibility.Visible;
        elapsed.Restart();
        RefreshTime();
        clock.Start();
        UpdateCounters();
        Feedback.Text = "Choose your first card.";
    }

    private async void Card_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var key = (string)button.Tag;
        if (waiting || first == button || matched.Contains(key)) return;

        RevealCard(button);
        if (first is null)
        {
            first = button;
            Feedback.Text = "Choose a second card.";
            return;
        }

        var previous = first;
        first = null;
        moves++;
        if ((string)previous.Tag == key)
        {
            matched.Add(key);
            ShowMatch(previous);
            ShowMatch(button);
            UpdateCounters();
            if (matched.Count == Vocabulary.Count)
            {
                ShowResults();
            }
            else
            {
                Feedback.Text = "Match found! Choose your next card.";
            }
            return;
        }

        waiting = true;
        UpdateCounters();
        Feedback.Text = "Different pairs. Take a look before they turn back.";
        int turnRound = round;
        await Task.Delay(1100);
        // A reset may have replaced the entire board while this turn was waiting.
        if (round != turnRound) return;
        HideCard(previous);
        HideCard(button);
        waiting = false;
        Feedback.Text = "Try another pair.";
    }

    private void ShowResults()
    {
        elapsed.Stop();
        clock.Stop();
        RefreshTime();
        int stars = moves switch
        {
            <= 10 => 3,
            <= 20 => 2,
            <= 30 => 1,
            _ => 0
        };
        ResultStars.Text = new string('★', stars) + new string('☆', 3 - stars);
        AutomationProperties.SetName(ResultStars, $"{stars} out of 3 stars");
        ResultTime.Text = TimeText;
        ResultMoves.Text = moves.ToString();
        Feedback.Text = "Board complete!";
        GameScreen.IsEnabled = false;
        ResultsOverlay.Visibility = Visibility.Visible;
        ResultRestart.Focus();
    }

    private void UpdateCounters()
    {
        Progress.Value = matched.Count;
        MovesLabel.Text = $"Moves   {moves}";
        PairsLabel.Text = $"Pairs   {matched.Count} / {Vocabulary.Count}";
    }

    private void HideCard(Button button)
    {
        button.Background = (Brush)FindResource("Back");
        button.ContentTemplate = (DataTemplate)FindResource("BackDesign");
        button.Content = "?";
        AutomationProperties.SetName(button, $"Hidden card {Board.Children.IndexOf(button) + 1}");
    }

    private void RevealCard(Button button) => DisplayFace(button, false);

    private void ShowMatch(Button button)
    {
        DisplayFace(button, true);
        button.IsEnabled = false;
    }

    private void DisplayFace(Button button, bool solved)
    {
        var card = (Card)button.DataContext;
        button.ContentTemplate = null;
        button.Background = (Brush)FindResource(solved ? "Solved" : "Open");
        var face = new StackPanel { VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(7, 2, 7, 2) };
        string label = card.IsWord ? "TERM" : "DEFINITION";
        face.Children.Add(new TextBlock
        {
            Text = solved ? $"✓  {label}" : label,
            FontFamily = new FontFamily("Consolas"),
            FontSize = 11,
            Foreground = Brushes.DarkSlateGray,
            TextAlignment = TextAlignment.Center,
            Margin = new Thickness(0, 0, 0, 3)
        });
        face.Children.Add(new TextBlock
        {
            Text = card.Text,
            TextWrapping = TextWrapping.Wrap,
            TextAlignment = TextAlignment.Center,
            FontSize = card.IsWord ? 21 : 15,
            Foreground = Brushes.MidnightBlue,
            FontWeight = card.IsWord ? FontWeights.Bold : FontWeights.Normal
        });
        button.Content = face;
        AutomationProperties.SetName(button, solved ? $"Matched: {card.Text}" : card.Text);
    }
}
