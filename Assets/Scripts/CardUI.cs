using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text cardNameText;
    public Image cardImage;
    public Button playCardButton; // Bouton pour jouer la carte

    private Card cardData;
    private PlaceCard placeCardScript;

    // Fonction pour initialiser les donn�es de la carte
    public void SetCardData(Card card, PlaceCard placeCard)
    {
        cardData = card;
        placeCardScript = placeCard;

        // Mise � jour des �l�ments UI
        cardNameText.text = card.cardName;
        cardImage.sprite = card.cardSprite;

        // Ajouter l'action du bouton pour jouer la carte
        playCardButton.onClick.AddListener(() => placeCardScript.PlaceCardOnField(cardData, true)); // true = joueur
    }
}
