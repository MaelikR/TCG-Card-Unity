using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public int maxHandSize = 5;
    public HandUI handUI;  // Link to hand UI script

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
        Debug.Log("Deck shuffled!");
    }

    void Start()
    {
        ShuffleDeck();
        DrawInitialHand();
    }

    void DrawInitialHand()
    {
        for (int i = 0; i < maxHandSize; i++)
        {
            if (hand.Count < maxHandSize)
            {
                Card drawnCard = DrawCard(true);
                if (drawnCard == null)
                {
                    break;
                }
            }
        }
        handUI.UpdateHandUI(hand);  // Update hand UI after drawing cards
    }

    public Card DrawCard(bool isPlayer)
    {
        if (deck.Count == 0)
        {
            Debug.Log("Deck is empty!");
            return null;
        }

        Card drawnCard = deck[0];
        hand.Add(drawnCard);
        deck.RemoveAt(0);
        return drawnCard;
    }

    public Card DrawCardWithLimit(bool isPlayer)
    {
        if (hand.Count >= maxHandSize)
        {
            Debug.Log("Hand is full!");
            return null;
        }

        return DrawCard(isPlayer);  // Return the drawn card
    }
}