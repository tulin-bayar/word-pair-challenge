# Word Pair Challenge • live presentation
Target 7 minutes 30 seconds including live actions. Aygül prepares a matching walkthrough. Gökhan prepares the timing and validation demonstration. Tülin developed the application and introduces and plays it. Rehearse the actions and use your actual contributions in the final remarks.

## 0:00–2:30 • Tülin • introduction and gameplay
“Hi everyone. Our project is called Word Pair Challenge. I built this game in C# using WPF. The goal is simple. There are sixteen cards and eight pairs. Each pair has a software term and its English definition. I’ll show you how to play. Then my teammates will explain how the cards work and test what happens when a player clicks too quickly.”

[Show Home. Press Start Game. Point out the counters. Read the first two cards aloud, whether they match or not.]

“Here is my first card. I need to remember where it is. Now I’ll turn over a second card. Two different cards count as one move. If the meanings match, both cards stay open. If they don’t, they turn back over.”

[Play several turns until you find a pair. Read out the term and definition and point to the pair counter.]

“The timer shows how long I’ve been playing. In this completed round, I found all eight pairs in forty-six seconds. I used eighteen moves and earned two stars.”

[Show screenshots/04-results.png. Return to the live game for Aygül.]

## 2:30–5:00 • Aygül • cards and matching
[Open MainWindow.xaml.cs at Vocabulary. Point to Queue and Stack, then to StartGame.]

“Queue and Stack are a good example of why the definitions matter. A queue removes the earliest item first. A stack removes the most recent one first. In the game, each dictionary entry becomes two cards. Look at the two places where the program creates a Card. One card displays the term. The other displays its definition. Both receive the same pair ID.”

[Show where Tag is set, then Card_Click. Read one dictionary entry and trace both cards through the comparison.]

“The player sees different words on the two buttons. The program checks their IDs. Every button uses the same click handler, so the rule is the same at every position. New Game shuffles the sixteen cards. The pair IDs stay together with their cards even when the positions change.”

[Press New Game, turn over one card and click that same card again. Point to Moves.]

“We still have one open card and zero moves. A move starts counting when we pick a second, different card. That keeps the score fair.”

## 5:00–7:30 • Gökhan • timing, validation and conclusion
[Choose a mismatching pair. Immediately click a third card. Repeat if needed to make the behavior visible.]

“Watch the third card. It stays closed while the first two are visible. The waiting flag blocks extra card selections. The handler uses an asynchronous delay, so the window stays responsive. After the delay, the two cards turn back over.”

[Show the round check after Task.Delay. Start a mismatch, press New Game during the delay, then flip one card on the new board.]

“This new card stays open even when the old wait finishes. Each game has a round number. The old handler checks that number before it changes the board.”

[Show the results screenshot and point to the time, moves and stars.]

“The timer stops at the eighth match. Stars depend on moves. Ten or fewer earns three stars. Eighteen earns two, as we see here. Restart begins a fresh round, and Home takes us to the start screen. Tülin developed the game. Our walkthrough covered matching and input validation. The main lesson was that even a small game needs clear rules for every click. Thank you.”
