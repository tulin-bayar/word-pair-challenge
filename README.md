# Word Pair Challenge

A local WPF memory game for Project 03. Find all eight English software term–definition pairs. A move is counted when you reveal a second, distinct card. Matched cards remain visible. Start Game begins a timed round. Home ends it. New Game resets the clock, moves and board. The eighth match opens a results card showing the frozen time, move count and three star slots. Up to 10 moves earns three stars, 11–20 earns two, 21–30 earns one, and 31 or more earns zero. Choose Restart for a fresh round or Home to return to the start screen.

## Run on Windows

1. Install the .NET 10 SDK. Run `dotnet --list-sdks` and look for a 10.0 release.
2. Clone the repository or extract the entire ZIP. Open a terminal in the folder containing WordPairChallenge.csproj.
3. Run `dotnet run --project WordPairChallenge.csproj`.
4. Alternatively, open the .csproj in Visual Studio with .NET 10 WPF support and the .NET desktop development workload, then press F5.

## Team responsibilities

| Team member | Project responsibilities | Live presentation |
| --- | --- | --- |
| Tülin Bayar | Review the screen layout, check navigation and verify the player instructions against the game. | Introduce the goal and play a few turns. |
| Aygül | Review the eight term–definition pairs, trace the card IDs and check how selections count as moves. | Walk through one pair and demonstrate a repeated click. |
| Gökhan Perçem | Check the mismatch delay, test restarting during a turn and verify the final time and star rating. | Demonstrate input validation and explain the result screen. |

Each team member has two and a half minutes, including the live actions. See [the presentation script](DEMO.md).

## Implementation

MainWindow.xaml defines the 4 × 4 board, keyboard focus style and counters. MainWindow.xaml.cs builds the deck, connects all buttons to Card_Click, and tracks moves, the first card and matched keys. A dictionary entry generates two cards with one key and different text. During a mismatch the handler awaits a 1.1-second delay. The round number prevents an old callback from changing a new game.

## Scope and verification

Windows desktop only. Scores last for one game. The Windows screenshots show a completed round in 18 moves and 46 seconds, earning two stars. See screenshots/ and ACCEPTANCE.md.
