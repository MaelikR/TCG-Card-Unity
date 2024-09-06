using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;
using Photon.Pun;
public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public int maxHandSize = 5;

    void Start()
    {   // Instancier une carte avec un PhotonView
        MedievalCard medievalCard = new GameObject("MedievalCard").AddComponent<MedievalCard>();
        medievalCard.gameObject.AddComponent<PhotonView>();  // Ajout de PhotonView
        medievalCard.Initialize("Chevalier", "Un noble chevalier", 6, 8, 5);
        // Faire la même chose pour d'autres cartes
        FantasyCard fantasyCard = new GameObject("FantasyCard").AddComponent<FantasyCard>();
        fantasyCard.gameObject.AddComponent<PhotonView>();
        fantasyCard.Initialize("Mage Mystique", "Un mage puissant", 5, 4, 7);

        MagitechCard magitechCard = new GameObject("MagitechCard").AddComponent<MagitechCard>();
        magitechCard.Initialize("Technomancien", "Un mage combinant la magie et la technologie", 8, 7, 9);
        magitechCard.gameObject.AddComponent<PhotonView>();
        // Ajouter les cartes au deck
        deck.Add(medievalCard);
        deck.Add(fantasyCard);
        deck.Add(magitechCard);

        ShuffleDeck();
    }


    // Mélanger le deck
    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = UnityEngine.Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
        UnityEngine.Debug.Log("Deck mélangé !");
    }

    // Piocher une carte avec une limite
    public Card DrawCardWithLimit(bool isPlayer)
    {
        if (hand.Count >= maxHandSize)
        {
            UnityEngine.Debug.Log("La main est pleine !");
            return null;
        }

        return DrawCard(isPlayer);  // Retourne la carte piochée
    }

    // Piocher une carte standard
    public Card DrawCard(bool isPlayer)
    {
        if (deck.Count == 0)
        {
            UnityEngine.Debug.Log("Le deck est vide !");
            return null;
        }
        Card drawnCard = deck[0];
        hand.Add(drawnCard);
        deck.RemoveAt(0);
        return drawnCard;
    }
}
