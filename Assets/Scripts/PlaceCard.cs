using UnityEngine;

public class PlaceCard : MonoBehaviour
{
    public GameObject cardPrefab;  // Drag your card prefab here
    public Transform playerFieldUI;  // UI panel for player field
    public Transform opponentFieldUI;  // UI panel for opponent field

    // Method to place the card
    public void PlaceCardOnField(Card card, bool isPlayer)
    {
        if (isPlayer)
        {
            // Instantiate a card prefab for player field
            GameObject cardGO = Instantiate(cardPrefab, playerFieldUI);

            // Update the card prefab’s UI with the card data
            cardGO.GetComponent<CardUI>().SetCardData(card, this);  // Assuming CardUI script has SetCardData method
            Debug.Log($"Le joueur place {card.cardName} sur le terrain.");
        }
        else
        {
            // Instantiate a card prefab for opponent field
            GameObject cardGO = Instantiate(cardPrefab, opponentFieldUI);

            // Update the card prefab’s UI with the card data
            cardGO.GetComponent<CardUI>().SetCardData(card, this);  // Assuming CardUI script has SetCardData method
            Debug.Log($"L'adversaire place {card.cardName} sur le terrain.");
        }
    }
}
