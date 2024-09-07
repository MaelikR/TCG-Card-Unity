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

CardUI: Adding Buttons for Card Actions
You will first need to set up the user interface (UI) for each card. Each card in the player's hand or on the board should have a button or clickable area to initiate actions (like playing a card or attacking).

The card interface can be represented by a Prefab containing the following elements:

A "Play" button (to play a card on the field).
A "Attack" button (if the card is on the field and can attack).
Other buttons for specific actions as needed (e.g. using a special ability).
2. Creating a Card UI in Unity
Card Prefab:

Create a Prefab in Unity representing a card.
Add a Canvas to this prefab to hold UI elements like buttons.
Add two Button components for actions: one for "Play Card" and another for "Attack".
Adds UI elements like an Image to display the card illustration and a Text for the name and characteristics.
CardUI Script :

Creates a CardUI script to handle button interactions on the card interface.

3. Card Actions Management with CardActions
The CardActions script must be attached to a game management object, such as the GameBoard.
This script handles all network and logic actions of cards, such as playing a card or attacking. It is responsible for network logic throughout Photon.
4. Configuration in the Unity Editor
Assigning the Card Prefab to the Deck:

You need to generate cards in the player's hand using Card Prefabs. When a card is added to the hand or placed on the field, you instantiate this Prefab and call the SetCardData method to associate the card with the right actions.
Interaction with buttons:

In your script that manages the player's hand or the board, each time a card is placed, it must be associated with the UI action buttons. You use the SetCardData method to link the actual card (Card) with its GUI elements.
Button Management in Unity:

You need to make sure that the buttons (like "Play" or "Attack") are properly configured in Unity and that the corresponding actions are called when these buttons are pressed.

6. Example flow in Unity:
Adding cards to the hand:

When a card is drawn, the HandManager script adds the card to the hand and instantiates the corresponding UI with AddCardToHand().
Interaction with the UI:

When the player clicks "Play", the button calls the PlayCard() method from the CardActions script.
When the player clicks "Attack", the button calls the Attack() method from CardActions, passing the ID of the attacking card and optionally the ID of the target.
Conditional buttons:

Depending on the game state (e.g. is the card on the field, or can it attack?), you can disable or enable certain buttons in the UI.
7. Process summary:
CardUI:

Manages the UI for each card, including the "Play" and "Attack" buttons.
Is linked to the CardActions class which contains the game logic.
CardActions :

Handles the logic of playing a card or attacking, and uses Photon to synchronize these actions in multiplayer.
Card Prefab :

Creates a Prefab containing a button for each card action and a CardUI script to handle these interactions.
