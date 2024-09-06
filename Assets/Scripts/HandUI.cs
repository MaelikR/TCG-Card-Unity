using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class HandUI : MonoBehaviour
{
	public GameObject cardPrefab;  // Pr�fabriqu� de carte � afficher dans la main
	public Transform handPanel;  // Panel o� les cartes seront affich�es

	// Mettre � jour l'UI avec les cartes actuelles dans la main
	public void UpdateHandUI(List<Card> hand)
	{
		// Vider le panel avant de le remplir
		foreach (Transform child in handPanel)
		{
			Destroy(child.gameObject);
		}

		// Afficher chaque carte dans la main
		foreach (Card card in hand)
		{
			GameObject cardUI = Instantiate(cardPrefab, handPanel);
			cardUI.GetComponentInChildren<Text>().text = card.cardName;
			cardUI.GetComponentInChildren<Image>().sprite = card.cardSprite;  // Afficher l'image de la carte
		}
	}
}
