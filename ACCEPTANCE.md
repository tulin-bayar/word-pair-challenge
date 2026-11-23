# Acceptance record

Tülin confirmed the gameplay checks on Windows. The linked screenshots show the earlier window styling and document the recorded scores.

| Action | Observed result |
| --- | --- |
| Press Start Game | All 16 cards were face down, with 0 moves and 0 of 8 pairs at 00:01. [Screenshot](screenshots/02-board.png) |
| Click the same card twice | The card stayed face up and the move count stayed at 0. |
| Pick two unrelated cards | Both faces appeared and turned face down after about a second. The move count went up by one. |
| Click a third card during a mismatch | The third card stayed face down. Both counters held their values. |
| Match Variable with its definition | Both cards stayed face up and stopped accepting clicks. The board showed 1 of 8 pairs after 3 moves. [Screenshot](screenshots/03-match.png) |
| Press New Game during a mismatch, then reveal a card | The counters reset. The new card stayed face up after the old delay expired. |
| Wait on Home before starting | The timer began at 00:00 when Start Game was pressed. |
| Press Home during a mismatch, then start again | The new round started at zero and the old turn left the new board alone. |
| Press New Game after playing | A shuffled board appeared with 16 face-down cards. The timer and counters returned to zero. |
| Find the eighth pair and inspect the results | All eight pairs stayed face up. The board and results showed 18 moves and a frozen time of 00:46. Two stars were filled and one was outlined. [Screenshot](screenshots/04-results.png) |
| Select Restart or Home on the results card | Restart opened a fresh timed board. Home returned to Start Game. |
