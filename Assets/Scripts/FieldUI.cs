using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldUI : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform playerFieldPanel;
    public Transform opponentFieldPanel;

    public void UpdateFieldUI(List<Card> playerField, List<Card> opponentField)
    {
        // Clear both panels before updating
        foreach (Transform child in playerFieldPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in opponentFieldPanel)
        {
            Destroy(child.gameObject);
        }

        // Display player cards
        foreach (Card card in playerField)
        {
            GameObject cardUI = Instantiate(cardPrefab, playerFieldPanel);
            cardUI.GetComponentInChildren<Text>().text = card.cardName;
            cardUI.GetComponentInChildren<Image>().sprite = card.cardSprite;
        }

        // Display opponent cards
        foreach (Card card in opponentField)
        {
            GameObject cardUI = Instantiate(cardPrefab, opponentFieldPanel);
            cardUI.GetComponentInChildren<Text>().text = card.cardName;
            cardUI.GetComponentInChildren<Image>().sprite = card.cardSprite;
        }
    }
}
