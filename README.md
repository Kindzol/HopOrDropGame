# Hop or Drop

A 3D physics-based platformer built in Unity where you control a ball rolling and jumping across floating platforms above a void. One goal: reach the finish without falling.

---

## How to Play

| Key | Action |
|-----|--------|
| `W` / `↑` | Move forward |
| `S` / `↓` | Move backward |
| `A` / `←` | Move left |
| `D` / `→` | Move right |
| `Space` | Jump |

---

## Platform Types

| Platform | Effect |
|----------|--------|
| Normal | Safe to stand on |
| Hazard |Lose a life on contact |
| Disappearing |Vanishes shortly after touch |
| Moving | Moves between two points |

---

## Life System

- You start with **3 lives**
- A life is lost when you **fall** below the level or **touch a hazard** platform
- Lose all lives → **Game Over**
- Reach the finish → **You Win!**

---

## Features

- Ball skin selection (color variants) on the main menu
- Background music that changes between scenes
- Sound effects for losing a life and completing the level
- Physics-based movement with natural rolling
- Persistent game state managed by a singleton GameManager

---

## Built With

- **Unity 6**
- **C#**
- **Unity Physics (Rigidbody)**
- **TextMeshPro**
- **Universal Render Pipeline (URP)**
