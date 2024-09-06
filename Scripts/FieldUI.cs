using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FieldUI : MonoBehaviour
{
	public GameObject cardPrefab;  // Préfabriqué de carte pour le terrain
	public Transform playerFieldPanel;  // Panel du joueur
	public Transform opponentFieldPanel;  // Panel de l'adversaire

	public void UpdateFieldUI(List<Card> playerField, List<Card> opponentField)
	{
		// Vider les deux panels avant de les remplir
		foreach (Transform child in playerFieldPanel)
		{
			Destroy(child.gameObject);
		}

		foreach (Transform child in opponentFieldPanel)
		{
			Destroy(child.gameObject);
		}

		// Afficher les cartes du joueur
		foreach (Card card in playerField)
		{
			GameObject cardUI = Instantiate(cardPrefab, playerFieldPanel);
			cardUI.GetComponentInChildren<Text>().text = card.cardName;
			cardUI.GetComponentInChildren<Image>().sprite = card.cardSprite;  // Image de la carte
		}

		// Afficher les cartes de l'adversaire
		foreach (Card card in opponentField)
		{
			GameObject cardUI = Instantiate(cardPrefab, opponentFieldPanel);
			cardUI.GetComponentInChildren<Text>().text = card.cardName;
			cardUI.GetComponentInChildren<Image>().sprite = card.cardSprite;  // Image de la carte
		}
	}
}
