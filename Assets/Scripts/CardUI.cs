using System;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text cardNameText;
    public Image cardImage;
    public Button playCardButton;

    private Card cardData;            // R�f�rence � l'objet carte
    private CardActions cardActions;  // R�f�rence � l'objet CardActions

    // Fonction pour initialiser la carte
    public void SetCardData(Card card, CardActions actions)
    {
        cardData = card;
        cardActions = actions;

        // Mettre � jour l'interface avec les donn�es de la carte
        cardNameText.text = card.cardName;
        cardImage.sprite = card.cardSprite;

        // Associer le bouton � l'action "PlayCard"
        playCardButton.onClick.RemoveAllListeners();  // Pour �viter les doubles listeners
        playCardButton.onClick.AddListener(() => cardActions.PlayCard(cardData.cardID, true));  // true = joueur
    }

    internal void SetCardData(Card card, PlaceCard placeCardScript)
    {
        throw new NotImplementedException();
    }
}
