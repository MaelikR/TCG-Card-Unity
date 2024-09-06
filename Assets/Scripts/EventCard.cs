using UnityEngine;

public class EventCard : MonoBehaviour
{
    public string eventName;
    public string eventDescription;

    public void ApplyEvent(GameBoard gameBoard)
    {
        Debug.Log($"{eventName} est activ� : {eventDescription}");
        // Applique l'effet � toutes les cartes
        foreach (Card card in gameBoard.playerField)
        {
            card.defensePoints -= 2;  // Exemple : Temp�te, toutes les cartes perdent 2 points de d�fense
        }
        foreach (Card card in gameBoard.opponentField)
        {
            card.defensePoints -= 2;
        }
    }
}
