Game Structure
HandUI.cs
This script is responsible for managing and displaying the player’s hand. It dynamically creates UI elements for each card in the player’s hand and updates when cards are added or removed.

Methods:
UpdateHandUI(List<Card> hand): Clears the current hand UI and regenerates it with the current cards.
FieldUI.cs
Handles the display and placement of cards on the game field for both the player and the opponent.

Methods:
UpdateFieldUI(List<Card> playerField, List<Card> opponentField): Updates the cards visible on the field for both the player and opponent.
Card.cs
The base class for all cards in the game. This script defines the common properties (name, description, attack points, defense points, etc.) and handles networked actions like attacking using Photon.

Methods:
Attack(Card target): Deals damage to the target card and syncs this action over the network.
ResetStats(): Resets the card's stats after a turn.
MedievalCard.cs
An extension of Card.cs, this class represents a specific type of card (Medieval) with a special shield defense ability.

Methods:
ShieldDefense(): Increases the defense points of the card.
CheckForCombo(List<Card> playerField): Checks if a combo of "Chevalier" and "Écuyer" cards are on the field, and boosts the "Chevalier’s" stats.
TurnManager.cs
Controls the game flow, switching between player turns and managing mana, health, and card drawing. This script ensures each player gets a turn to play cards and execute actions.

Methods:
EndTurn(): Switches between player and opponent turns.
DrawCard(bool isPlayer): Draws a card for the respective player and updates the UI.
DeckManager.cs
This script manages the player's deck, allowing cards to be shuffled and drawn. It also ensures the hand does not exceed the maximum number of cards.

Methods:
ShuffleDeck(): Randomly shuffles the player's deck.
DrawCardWithLimit(bool isPlayer): Draws a card, ensuring the hand size does not exceed the limit.
PlayerManager.cs
Synchronizes the player’s health and mana values and handles drawing cards and casting spells. It ensures the player's stats are correctly updated across the network.

Methods:
DrawInitialHand(): Draws the starting hand for the player at the beginning of the game.
ApplyDamage(int damage): Reduces the player’s health when they take damage.
CombatManager.cs
Manages combat between cards, applying damage to target cards and destroying them if their defense points reach zero.

Methods:
Combat(Card attacker, Card defender): Resolves the attack by calculating damage and updating the card states.
Photon Integration
The entire game is networked using Photon, which allows two players to compete in real-time. The PhotonView component is extensively used to sync actions like drawing cards, attacking, and updating player stats.

Photon Network Callbacks:
OnJoinedRoom(): Called when a player joins a room and begins the game.
OnPlayCard(int cardID, bool isPlayer): Syncs card placement between players.
OnAttack(int attackerCardID, int targetCardID): Handles attacks between player cards and syncs them in real-time.
How to Play
Create/Join Room: Players can create or join a room through the multiplayer lobby.
Draw Initial Cards: Each player draws 5 cards at the start of the game.
Player Turns: Players take turns drawing cards, playing cards, and attacking the opponent.
Winning the Game: The game ends when one player reduces their opponent’s health to zero, or when specific victory conditions (e.g., collecting 5 Relic cards) are met.
License
This project is licensed under the MIT License. See the LICENSE file for details.
