# All In!

A 2D turn-based RPG that blends classic combat with high-risk, high-reward gambling mechanics.

---

## Inspiration
*All In!* was inspired by RPGs, roguelikes, and gacha games. We wanted to combine strategic combat with unpredictable, chance-based elements to create a unique gameplay experience.

---

## Gameplay
At its core, *All In!* is a turn-based battle system where every decision involves risk.

### Key Mechanic: Gambling Combat
- Players can **parry enemy attacks** by predicting attack types (close-range or ranged)
- A correct prediction:
  - Reflects damage back to the enemy  
  - Deals bonus damage  
- An incorrect prediction results in taking the hit  

This creates a dynamic system where players must balance **strategy and risk**.

---

## Built With
- **Engine:** Unity  
- **Language:** C#  
- **Art & UI:** Procreate → Unity  

---

## Features
- Turn-based combat system  
- Gambling-based parry mechanic  
- Status effect system  
- Modular design for:
  - Attacks  
  - Items  
  - Effects  

---

## Challenges

### Merge Conflicts
Working in a team led to integration issues, which helped us learn better version control practices.

### Status Effects
We wanted attacks to apply specific effects.  
**Solution:**
- Created a `StatusEffect` class  
- Built a manager system to handle active effects per unit  

### Turn System Timing
Turns initially switched instantly, making gameplay feel unnatural.  
**Solution:**
- Used Unity coroutines to introduce delays between actions  

---

## Accomplishments
- Developed a complete game as a team  
- Built a functional turn-based combat system  
- Designed scalable systems using object-oriented programming  
- Integrated custom-made assets into Unity  

---

## What We Learned
- C# and Unity development  
- Structuring game systems using classes  
- Debugging and collaboration in a shared project  
- Implementing gameplay mechanics from concept to execution  

---

## Future Plans
- Add roguelike progression systems  
- Introduce new enemies, items, and status effects  
- Expand combat mechanics  
- Add sound effects and music  
- Improve balancing and overall polish  

---
## Try It Out
- Open the Repository through the Unity Engine
- Press Files -> Build and Run
