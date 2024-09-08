AnimationManager.cs for Unity Card Game
This script handles various animations for card interactions in a collectible card game built in Unity. The AnimationManager class enables smooth and engaging visual feedback when a player interacts with cards, such as drawing a card, playing it on the field, or destroying it.

Features
Card Draw Animation: Simulates the movement of a card from the deck to the player's hand.
Card Entry Animation: Animates the card as it enters the battlefield.
Card Attack Animation: Animates an attack from one card to another, including visual feedback for the attack target.
Card Destruction Animation: Handles the destruction of a card and its removal from the game.
Turn-Based Animations: Allows animations for the start and end of turns, such as highlighting playable cards or fading out inactive ones.
Setup Instructions
Create an Animator Controller:

First, create an Animator Controller for the card prefab in Unity.
Add animation states for the following actions:
Draw: When the card is drawn from the deck.
EnterField: When the card is placed on the battlefield.
Attack: When the card attacks another card.
Destroy: When the card is destroyed.
Hover: (Optional) for hovering or focusing on a card in hand.
StartTurn: Visual effect for the start of the player's turn.
EndTurn: Visual effect for the end of the player's turn.
Attach Animator to Card Prefabs:

Ensure each card prefab has an Animator component.
Link the Animator component to the Animator Controller you created.
Integrate the AnimationManager.cs Script:

Add the AnimationManager.cs script to a GameObject in the scene (preferably a dedicated Game Manager).
Assign references for the deck position and player field positions using Transform objects.
Ensure your card prefab has the following components:
Animator: To play the animations.
CardUI: A custom script to manage the card's UI representation (e.g., showing card name, image).

How to Use
1. Draw a Card
To animate the drawing of a card from the deck to the player's hand:


// Assuming 'card' is the GameObject of the drawn card
animationManager.AnimateDrawCard(card);
2. Play a Card on the Field
To animate a card being placed on the battlefield:


// Assuming 'card' is the GameObject of the played card
// isPlayer = true if it's the player's card, false if it's the opponent's
animationManager.AnimateCardEntry(card, true);
3. Animate an Attack
When a card attacks another card:

// Assuming 'attacker' is the attacking card GameObject, and 'target' is the card being attacked
animationManager.AnimateCardAttack(attacker, target);
4. Card Destruction
To animate the destruction of a card and remove it from the game:

// Assuming 'card' is the GameObject of the card being destroyed
animationManager.AnimateCardDestruction(card);
5. Turn Start & End Effects
To animate cards in the player's hand when it's their turn:

// Assuming 'handCards' is an array of GameObjects representing cards in hand
animationManager.AnimateStartOfTurn(handCards);

Key Components
Animator Controller:
You will need to set up animation states and transitions in Unity's Animator window. The triggers used in this script are:

Draw: Animation when drawing a card.
EnterField: When the card is placed on the battlefield.
Attack: When the card attacks another card.
Destroy: When the card is destroyed.
Hover: For UI hover animations (optional).
StartTurn: Highlight cards at the beginning of the turn.
EndTurn: Deactivate cards at the end of the turn.
CardUI.cs:
Make sure your card prefab is equipped with a script (e.g., CardUI.cs) that updates the card's visual components like name, image, and button events.

AnimationManager.cs:
This is the core script that manages all card-related animations. It's flexible enough to be extended with more effects and animations as your game grows.