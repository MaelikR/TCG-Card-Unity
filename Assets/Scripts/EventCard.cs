using UnityEngine;

public class EventCard : MonoBehaviour
{
    public string eventName;
    public string eventDescription;

    public void ApplyEvent(GameBoard gameBoard)
    {
        Debug.Log($"{eventName} est activé : {eventDescription}");
        // Applique l'effet à toutes les cartes
        foreach (Card card in gameBoard.playerField)
        {
            card.defensePoints -= 2;  // Exemple : Tempête, toutes les cartes perdent 2 points de défense
        }
        foreach (Card card in gameBoard.opponentField)
        {
            card.defensePoints -= 2;
        }
    }
}
