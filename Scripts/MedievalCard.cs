using System.Diagnostics;
using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class MedievalCard : Card
{
    public string cardName = "Chevalier";
    public string description = "Un chevalier noble, arm� d'une �p�e, prot�geant le royaume.";
    public int attackPoints = 6;
    public int defensePoints = 8;
    public int manaCost = 5;

    // M�thode pour initialiser les valeurs
    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }
    // Capacit� sp�ciale : Bouclier d�fensif
    public void ShieldDefense()
    {
        defensePoints += 4;
        UnityEngine.Debug.Log($"{cardName} utilise son bouclier, augmentant sa d�fense � {defensePoints} !");
    }
    public MedievalCard(string name, string desc, int attack, int defense, int mana) : base(name, desc, attack, defense, mana)
    {
        // Logique sp�cifique de MedievalCard (si n�cessaire)
    }
    // Attaquer une autre carte
    public void Attack(MedievalCard target)
    {
        target.defensePoints -= attackPoints;
        UnityEngine.Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} d�g�ts !");
    }
    public void CheckForCombo(List<Card> playerField)
{
    if (playerField.Exists(card => card.cardName == "Chevalier") && playerField.Exists(card => card.cardName == "�cuyer"))
    {
        foreach (Card card in playerField)
        {
            if (card.cardName == "Chevalier")
            {
                card.attackPoints += 2;
                UnityEngine.Debug.Log($"Le Chevalier est renforc� par la pr�sence de l'�cuyer !");
            }
        }
    }
}
}
