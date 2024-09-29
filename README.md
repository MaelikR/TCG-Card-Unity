#TCG Card Base Framework
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
Getting Started
Prerequisites
To work with this project, you will need:

Unity: Version 2020.3 or later.
Photon Unity Networking (PUN): This project uses PUN 2. Make sure you have installed Photon PUN 2 from the Unity Asset Store.
Photon Account: You will need an App ID from Photon. You can create an account and get a free App ID from the Photon Engine Dashboard.
How to Get the App ID for Photon PUN
Go to the Photon Dashboard.
Log in with your account or create a new account.
Create a new Photon PUN project in the Photon Realtime tab.
Copy the App ID provided for the project.

Recommended Tools & Best Practices for Text, Assets, UI, and Card Creation
In addition to the core gameplay and animation setup, here are some best practices and recommended tools to enhance the visual and text elements of your card game.

1. Text Rendering with TextMesh Pro
For high-quality text rendering in your game, TextMesh Pro is the recommended solution. It provides advanced text formatting, effects, and high-definition text rendering that works great for card descriptions, player stats, and other in-game UI text.

Why Use TextMesh Pro?
High-quality text rendering: Better than Unity’s default text, especially on different screen sizes and resolutions.
Rich text support: Allows you to use custom fonts, colors, bold, italic, and other text effects.
Text effects: Supports glow, shadow, and outline effects, making your text stand out.
Efficient rendering: Optimized for performance, even with complex layouts.
How to Integrate TextMesh Pro
Import TextMesh Pro into your Unity project via the Unity Asset Store.
Replace your existing Text components with TextMeshProUGUI for UI text or TextMeshPro for 3D text in the scene.
Use the TextMeshProUGUI inspector to customize fonts, sizes, alignment, and effects like shadows, outlines, and gradients.
For in-game text (e.g., card descriptions, attack stats), bind the text values in scripts by referencing the TextMeshProUGUI component.

Example Integration:

using TMPro;

public class CardUI : MonoBehaviour
{
    public TextMeshProUGUI cardNameText;  // TextMeshPro for card name
    public TextMeshProUGUI cardDescriptionText;  // TextMeshPro for description

    public void SetCardData(Card card)
    {
        cardNameText.text = card.cardName;
        cardDescriptionText.text = card.description;
    }
}

Card Creation and Free Image Generation Tools
For generating card illustrations, there are a few free tools that can help you create custom, high-quality images:

Artbreeder
Artbreeder allows you to create unique character portraits and fantasy landscapes by blending different images.

Easy-to-use interface: Adjust sliders to generate unique artwork for your cards.
Fantasy themes: Ideal for creating characters or landscapes for fantasy or sci-fi cards.
Export as PNG: Download images and use them as card illustrations.
DeepAI’s Image Generator
DeepAI provides an AI-driven image generator that creates images based on text prompts.

Text-to-image generation: Type a description of the card, and the AI will generate an image to match.
Free to use: Limited free use with high-quality results for character, item, or scene illustrations.
Unsplash
For free, high-quality stock images, Unsplash provides a vast library of photos and artwork.

Royalty-free: All images are free to use, including for commercial purposes.
Wide variety: Search for fantasy, sci-fi, or any theme to find images that match your cards.
Workflow for Card Creation
Generate or design your card image using Artbreeder, DeepAI, or Unsplash.
Use GIMP or Canva to add borders, text, and additional design elements.
Import the final card design into Unity as a Sprite for use in the game.
Attach the sprite to your card prefab and use the CardUI.cs script to display the card image and information in the game.

(Under development...)
M.RenDev
