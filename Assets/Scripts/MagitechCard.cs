using UnityEngine;

[System.Serializable]
public class MagitechCard : Card
{
    public MagitechCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Fix the constructor call
    {
    }
    public new string cardName;  // This will hide the base class field
    public new string description;
    public new int attackPoints;
    public new int defensePoints;
    public new int manaCost;

    // M�thode d'initialisation � la place du constructeur
    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    // Capacit� sp�ciale : Sort Technologique (augmente l'attaque ou la d�fense)
    public void CastTechSpell(bool increaseAttack)
    {
        if (increaseAttack)
        {
            attackPoints += 4;
            Debug.Log($"{cardName} utilise la technologie pour augmenter ses points d'attaque � {attackPoints} !");
        }
        else
        {
            defensePoints += 4;
            Debug.Log($"{cardName} utilise la technologie pour augmenter ses points de d�fense � {defensePoints} !");
        }
    }

    // Attaquer une autre carte
    public void Attack(MagitechCard target)
    {
        target.defensePoints -= attackPoints;
        Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} d�g�ts !");
    }

    // R�initialiser la puissance apr�s utilisation d'un sort
    public void ResetPower()
    {
        attackPoints = 8;  // R�initialiser les points d'attaque
        defensePoints = 7;  // R�initialiser les points de d�fense
        Debug.Log($"{cardName} r�initialise sa puissance technologique.");
    }
}
