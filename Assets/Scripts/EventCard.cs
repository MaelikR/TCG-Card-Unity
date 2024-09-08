using UnityEngine;

public class EventCard : Card  // Hérite de Card
{
    public EventCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Appel du constructeur de la classe parente Card
    {
    }

    public void ApplyEvent(GameBoard gameBoard)
    {
        Debug.Log($"{cardName} est activé : {description}");
        // Applique l'effet à toutes les cartes
        foreach (Card card in gameBoard.playerField)
        {
            card.defensePoints -= 2;  // Exemple : Tempête, toutes les cartes perdent 2 points de défense
            Debug.Log($"{card.cardName} perd 2 points de défense.");
        }
        foreach (Card card in gameBoard.opponentField)
        {
            card.defensePoints -= 2;
            Debug.Log($"{card.cardName} perd 2 points de défense.");
        }
    }
}
