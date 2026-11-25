# FLANK

**Unity - C# - Solo university project - 4 weeks**

An endless 2D arcade shooter where enemies approach from both sides. Move left or right to face them, shoot, and survive for as long as you can. One hit ends the run.

**[Play FLANK on itch.io](https://apexgenesis.itch.io/flank)**

## My role

**Solo developer - game design and programming.**

## Technical highlights

- **Directional shooting:** Moving left or right changes the player's facing direction, which stays the same when standing still. Bullets fire in that direction (`PlayerController.cs`, `Bullet.cs`).
- **Enemy types:** Three enemy types with different speeds and health values chase the player. Each can have its own score value (`Enemy.cs`).
- **Random spawning:** `EnemySpawner.cs` randomly picks an enemy type, which side to spawn it on, and the time until the next spawn.
- **Game flow:** `LogicManager.cs` handles starting the game, scoring, game over, and restarting after a short delay.

## Controls

| Input | Action |
| --- | --- |
| A / D or Left / Right arrows | Move and change direction |
| Space | Start game / Shoot / Restart |

## Project scope

Developed over **four weeks** for a university assignment. This was my first project using Unity and C#, and my goal was to make a simple, replayable arcade shooter.
