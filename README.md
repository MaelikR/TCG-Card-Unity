TCG Card Base Framework
Welcome to the TCG Card Base Framework, a versatile and customizable framework designed for creating Trading Card Games (TCG) from scratch using Unity and Photon Networking. Whether you're building a competitive online multiplayer TCG or an offline 
collectible card game, this framework provides the core functionalities needed to manage cards, decks, gameplay, and online multiplayer features.

![image](https://github.com/user-attachments/assets/64b2da36-1c11-4252-a4a5-508356f1cd0d)


Features
Dynamic Card Creation: Easily create and manage various card types (monsters, spells, relics) with customizable properties like attack points, defense points, and special abilities.
Card Categories: Support for multiple card themes and types, including fantasy, medieval, neo-futuristic, and modern cards.
Multiplayer Integration: Powered by Photon, the framework supports real-time multiplayer gameplay, enabling players to battle against each other online.
Deck Management: Built-in deck and hand management system that allows players to shuffle, draw, and play cards with smooth UI integration.
Turn-Based Gameplay: Fully functional turn manager that handles player turns, mana generation, and resetting player stats.
Event Cards and Special Conditions: Includes support for event cards, relics, and special victory conditions, such as collecting specific card sets to win the game.
Networking with Photon: Seamless integration with Photon for player matchmaking, room creation, and syncing card interactions across clients in real-time.
Framework Components
1. Card System
The framework comes with a flexible card system where each card can have unique attributes such as:

Name and Description
Attack Points, Defense Points, and Mana Cost
Special abilities that can be triggered during gameplay
Card templates include:

Fantasy Card: Magic-based abilities with spell casting.
Medieval Card: Knights and warriors with strong defensive skills.
Neo-Futuristic Card: Cybernetic soldiers with powerful technology-based abilities.
Magitech Card: A hybrid of magic and technology, offering versatility in attacks and defense.
2. Deck Management
Players can create decks and manage hands of cards. The system handles:

Drawing and Shuffling: Players can draw cards from their deck, with limits set on hand size.
Field Management: Cards can be played onto the field, with UI updates to reflect the current state of the player's and opponent's field.
3. Turn-Based Gameplay
The TurnManager class controls the flow of the game, including:

Switching between player and opponent turns.
Updating mana resources at the start of each turn.
Resetting card stats or special effects after turns.
4. Photon Networking
The framework utilizes Photon PUN for multiplayer networking, offering:

Room Creation and Joining: Players can create or join rooms to challenge each other.
Real-Time Syncing: Card plays, attacks, and special effects are synchronized in real-time between all players.
Player Matchmaking: Automatically match players in a competitive multiplayer environment.
5. UI Components
The framework includes basic UI templates for:

Player and Opponent Health and Mana display.
Card Display: Visual representation of cards in hand, field, and deck.
Game Log: Display of game events (e.g., attacks, damage dealt, and special effects triggered).
How to Get Started
Clone the repository:

bash
Copier le code
git clone https://github.com/MaelikR/TCG-Card-Unity.git
Install Unity: Make sure you have Unity installed (recommended version 2020.x or later).

Photon Setup:

Sign up for a Photon account at Photon Engine.
Obtain your App ID and add it to the PhotonServerSettings in Unity (Window > Photon Unity Networking > PhotonServerSettings).
Build and Run:

Open the project in Unity.
Run the Connection Scene to connect to Photon and start playing.
Future Plans
AI Integration: Implementing AI-driven opponents for single-player modes.
Card Expansion Packs: Supporting customizable card packs to expand game content.
Customizable Game Modes: Allowing for different game rules and victory conditions.
