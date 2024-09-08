using UnityEngine;

public class EventCard : Card  // H�rite de Card
{
    public EventCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Appel du constructeur de la classe parente Card
    {
    }

    public void ApplyEvent(GameBoard gameBoard)
    {
        Debug.Log($"{cardName} est activ� : {description}");
        // Applique l'effet � toutes les cartes
        foreach (Card card in gameBoard.playerField)
        {
            card.defensePoints -= 2;  // Exemple : Temp�te, toutes les cartes perdent 2 points de d�fense
            Debug.Log($"{card.cardName} perd 2 points de d�fense.");
        }
        foreach (Card card in gameBoard.opponentField)
        {
            card.defensePoints -= 2;
            Debug.Log($"{card.cardName} perd 2 points de d�fense.");
        }
    }
}
