using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.UIElements;
using UnityEngine;


using System.Linq;  // Importe LINQ pour utiliser All()

public class GameBoard : MonoBehaviour
{
    public List<Card> playerField = new List<Card>();
    public List<Card> opponentField = new List<Card>();

    // Placer une carte sur le terrain
    public void PlaceCard(Card card, bool isPlayer)
    {
        if (isPlayer)
        {
            playerField.Add(card);
            UnityEngine.Debug.Log($"Le joueur place {card.cardName} sur le terrain.");
        }
        else
        {
            opponentField.Add(card);
            UnityEngine.Debug.Log($"L'adversaire place {card.cardName} sur le terrain.");
        }
    }
    public void CheckSpecialVictoryCondition()
    {
        if (playerField.Count >= 5 && playerField.All(card => card.cardName == "Relique"))
        {
            UnityEngine.Debug.Log("Le joueur a collecté 5 Reliques et gagne la partie !");
        }
    }
}
