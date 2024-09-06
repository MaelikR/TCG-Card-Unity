using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text cardNameText;
    public Text attackPointsText;
    public Text defensePointsText;
    public Image cardArt;

    public void SetCardData(Card card)
    {
        cardNameText.text = card.cardName;
        attackPointsText.text = "ATK: " + card.attackPoints.ToString();
        defensePointsText.text = "DEF: " + card.defensePoints.ToString();
        // Optionally, set the card art image here:
        // cardArt.sprite = card.cardSprite;
    }
}
