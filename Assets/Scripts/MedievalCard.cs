using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[System.Serializable]
public class MedievalCard : Card
{
    public MedievalCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)
    {
    }

    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    public void ShieldDefense()
    {
        defensePoints += 4;
        Debug.Log($"{cardName} uses Shield, defense increased to {defensePoints}!");
    }

    public void CheckForCombo(List<Card> playerField)
    {
        if (playerField.Exists(card => card.cardName == "Chevalier") && playerField.Exists(card => card.cardName == "Écuyer"))
        {
            foreach (Card card in playerField)
            {
                if (card.cardName == "Chevalier")
                {
                    card.attackPoints += 2;
                    Debug.Log($"Le Chevalier is empowered by the presence of the Écuyer!");
                }
            }
        }
    }
}
