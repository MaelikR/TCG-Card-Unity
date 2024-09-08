using System;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text cardNameText;
    public Text descriptionText; // Ajouté pour afficher la description
    public Image cardImage;
    public Button playCardButton;

    private Card cardData;            // Référence à l'objet carte
    private CardActions cardActions;  // Référence à l'objet CardActions

    // Fonction pour initialiser la carte avec CardActions
    public void SetCardDataWithActions(Card card, CardActions actions)
    {
        cardData = card;
        cardActions = actions;

        // Mettre à jour l'interface avec les données de la carte
        cardNameText.text = card.cardName;
        cardImage.sprite = card.cardSprite;

        // Associer le bouton à l'action "PlayCard"
        playCardButton.onClick.RemoveAllListeners();  // Pour éviter les doubles listeners
        playCardButton.onClick.AddListener(() => cardActions.PlayCard(cardData.cardID, true));  // true = joueur
    }

    // Méthode pour définir les données de la carte dans l'UI avec PlaceCard
    public void SetCardData(Card card, PlaceCard placeCardScript)
    {
        if (card != null)
        {
            cardNameText.text = card.cardName;
            descriptionText.text = card.description; // Met à jour la description si nécessaire
            cardImage.sprite = card.cardSprite;

            Debug.Log($"Carte {card.cardName} mise à jour dans l'interface utilisateur.");
        }
        else
        {
            Debug.LogError("La carte est null, impossible de mettre à jour l'interface.");
        }
    }
}
