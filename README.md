# Word Pair Challenge

A Windows memory game for Project 03. Flip two cards per move and match all eight software terms to their definitions.

## Run on Windows

Install the .NET 10 SDK and run this command from the project folder.

```powershell
dotnet run --project WordPairChallenge.csproj
```

In Visual Studio with .NET 10 WPF support, open the project and press F5.

## Scoring

Up to 10 moves earns three stars, 11–20 earns two, 21–30 earns one, and 31 or more earns zero.

## Team responsibilities

| Team member | Project responsibilities |
| --- | --- |
| Tülin Bayar | Review the screen layout, navigation and player instructions. |
| Aygül | Review the term–definition pairs, card IDs and move counting. |
| Gökhan Perçem | Check the mismatch delay, restart behavior, final time and star rating. |

## Implementation

Both cards in a pair share an ID. A mismatch leaves the two cards visible for 1.1 seconds. Starting over or going Home changes the round number so the pending turn can tell that its cards belong to an earlier round.

## Verification

See the [acceptance record](ACCEPTANCE.md) for the Windows gameplay checks.
