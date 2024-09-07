using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public List<Card> playerField = new List<Card>();  // Cards on the player's field
    public List<Card> opponentField = new List<Card>();  // Cards on the opponent's field

    public void PlaceCard(Card card, bool isPlayer)
    {
        if (isPlayer)
        {
            playerField.Add(card);
            Debug.Log($"Player placed {card.cardName} on the field.");
        }
        else
        {
            opponentField.Add(card);
            Debug.Log($"Opponent placed {card.cardName} on the field.");
        }
    }

    public void CheckSpecialVictoryCondition()
    {
        if (playerField.Count >= 5 && playerField.TrueForAll(card => card.cardName == "Relique"))
        {
            Debug.Log("Player has collected 5 Relics and wins the game!");
        }
    }
}
