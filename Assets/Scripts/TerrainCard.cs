using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class TerrainCard : MonoBehaviour
{
	public string terrainName = "Montagne";
	public string terrainEffectDescription = "Augmente la d�fense des cr�atures terrestres de 2 points.";

	public void ApplyTerrainEffect(List<Card> playerField, List<Card> opponentField)
	{
        UnityEngine.Debug.Log($"{terrainName} est activ� : {terrainEffectDescription}");

		foreach (Card card in playerField)
		{
			if (card.cardType == "Terrestre")
			{
				card.defensePoints += 2;
			}
		}

		foreach (Card card in opponentField)
		{
			if (card.cardType == "Terrestre")
			{
				card.defensePoints += 2;
			}
		}
	}
}
