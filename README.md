# FLANK

**Unity · C# · Solo university project · 4 weeks · First Unity/C# game**

*FLANK* is an endless 2D arcade shooter about surviving enemies approaching from both sides. Move to turn toward a threat, fire in the direction you're facing, and try to beat your score. One hit ends the run.

**[Play FLANK on itch.io](https://apexgenesis.itch.io/flank)**

## My role

**Solo developer — game design and programming.** I designed the arcade gameplay loop and implemented player movement and shooting, enemy behaviour and spawning, scoring, and game-over/restart flow.

## Technical highlights

- **Movement-based facing:** The character faces left or right based on horizontal input and keeps that direction when stationary. Projectiles travel toward the direction the player is facing (`PlayerController.cs`, `Bullet.cs`).
- **Three enemy types:** Fast/low-health, balanced, and slow/high-health enemies create different threats. Enemies move toward the player and have configurable health, speed, and score values (`Enemy.cs`).
- **Random spawning:** `EnemySpawner.cs` randomly selects an enemy prefab, a spawn side, and the delay before the next spawn.
- **Arcade game flow:** `LogicManager.cs` tracks score, starts the game, handles death, and enables restarting after a short delay.

## Controls

| Input | Action |
| --- | --- |
| A / D or Left / Right arrows | Move and change facing direction |
| Space | Start / shoot / restart when prompted |

You **do not** need to be moving to shoot; the last horizontal movement determines which way you face.

## Project scope

Built in **four weeks** as a university assignment, *FLANK* was my **first game made with Unity and C#**. It uses simple shapes and colours to keep the emphasis on quick reactions and replaying for a higher score.

The randomized enemy combinations were intentionally meant to create occasionally brutal situations—what I call **“the spawn rotation from hell.”** That unpredictability was part of my experiment with old-school arcade difficulty, not a claim of balanced encounters.

## What this project demonstrates

**Foundational C# programming · Unity 2D physics · input and projectile logic · randomized spawning · game-state management**

It also serves as a starting point for comparing my later Unity work with my first attempt at building a standalone game.

## Media and links

- **[Play on itch.io](https://apexgenesis.itch.io/flank)**
- **[Add your portfolio page link]** — technical overview and *The Making of FLANK* development video (**needs your input**).

> **Asset attribution:** Add credits for any third-party assets used, if applicable (**needs your input**).
