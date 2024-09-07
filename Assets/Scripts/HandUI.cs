using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform handPanel;
    public PlaceCard placeCardScript;

    public void UpdateHandUI(List<Card> hand)
    {
        foreach (Transform child in handPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in hand)
        {
            GameObject cardUI = Instantiate(cardPrefab, handPanel);
            cardUI.GetComponent<CardUI>().SetCardData(card, placeCardScript);
        }
    }
}
