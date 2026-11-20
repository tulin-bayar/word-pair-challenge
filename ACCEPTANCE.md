# Acceptance record

Static checks passed for XML structure, startup window, event wiring and the eight distinct vocabulary entries. The table records observed Windows results. Tülin confirmed the interactive checks on Windows. Detailed numeric results below come from the screenshots.

| Action | Expected observation | Actual outcome |
| --- | --- | --- |
| Press Start Game | 4 × 4 hidden cards, Moves 0, Pairs 0 / 8 | Observed at 00:01 (02-board.png) |
| Reveal one card twice | Same card stays open, Moves remains 0 | Passed (reported by Tülin) |
| Pick two unrelated cards | Moves increases once. Both faces appear, then hide after about one second | Passed (reported by Tülin) |
| Quickly click a third card during a mismatch | Third card stays hidden. Moves and Pairs stay unchanged | Passed (reported by Tülin) |
| Select Variable and A name that holds a value | Both stay open, become disabled and Pairs increases once | Matching faces visible at 1 / 8 after 3 moves (03-match.png). Disabled input passed per Tülin. |
| Click New Game during a mismatch, then immediately reveal one new card | Counters reset and the new card stays open after the old delay expires | Passed (reported by Tülin) |
| Find the eighth pair | All cards remain open, Pairs reads 8 / 8 and the completion message reports the move total | Observed 8 / 8 pairs and 18 moves on the board and result card. |
| Start another round | All cards turn face down, counters reset. Reveal some known positions to compare layouts | Passed (reported by Tülin) |
| Launch and wait on Home | Start Game is visible. Starting after a wait still begins at 00:00 | Passed (reported by Tülin) |
| Press Home during a mismatch and start again | Start screen appears. The new round begins at zero and the old callback has no effect | Passed (reported by Tülin) |
| Press New Game after playing | Time and counters return to zero and a shuffled round starts | Passed (reported by Tülin) |
| Finish and inspect results | Frozen time and moves match the board. Earned stars are filled, with three slots in total | Board and result both show 00:46 and 18 moves. Two filled stars and one outline observed. Timer freeze confirmed by Tülin. |
| Select Restart or Home on the results card | Restart opens a fresh timed board. Home returns to Start Game | Passed (reported by Tülin) |

Screenshots in the screenshots folder show the home screen, fresh board, first matched pair and completed round.
