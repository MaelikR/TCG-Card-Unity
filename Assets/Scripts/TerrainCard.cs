using System.Collections.Generic;
using UnityEngine;

public class TerrainCard : Card  // H�rite de Card
{
    public TerrainCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Appel du constructeur de la classe parente Card
    {
    }

    public string terrainEffectDescription = "Augmente la d�fense des cr�atures terrestres de 2 points.";

    public void ApplyTerrainEffect(List<Card> playerField, List<Card> opponentField)
    {
        Debug.Log($"{cardName} est activ� : {terrainEffectDescription}");

        foreach (Card card in playerField)
        {
            if (card.cardType == "Terrestre")
            {
                card.defensePoints += 2;
                Debug.Log($"{card.cardName} gagne +2 en d�fense.");
            }
        }

        foreach (Card card in opponentField)
        {
            if (card.cardType == "Terrestre")
            {
                card.defensePoints += 2;
                Debug.Log($"{card.cardName} gagne +2 en d�fense.");
            }
        }
    }
}
