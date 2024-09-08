using System;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text cardNameText;
    public Text descriptionText; // Ajout� pour afficher la description
    public Image cardImage;
    public Button playCardButton;

    private Card cardData;            // R�f�rence � l'objet carte
    private CardActions cardActions;  // R�f�rence � l'objet CardActions

    // Fonction pour initialiser la carte avec CardActions
    public void SetCardDataWithActions(Card card, CardActions actions)
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

    // M�thode pour d�finir les donn�es de la carte dans l'UI avec PlaceCard
    public void SetCardData(Card card, PlaceCard placeCardScript)
    {
        if (card != null)
        {
            cardNameText.text = card.cardName;
            descriptionText.text = card.description; // Met � jour la description si n�cessaire
            cardImage.sprite = card.cardSprite;

            Debug.Log($"Carte {card.cardName} mise � jour dans l'interface utilisateur.");
        }
        else
        {
            Debug.LogError("La carte est null, impossible de mettre � jour l'interface.");
        }
    }
}
