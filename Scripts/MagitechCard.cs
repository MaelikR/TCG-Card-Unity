using UnityEngine;

[System.Serializable]
public class MagitechCard : Card
{
    public MagitechCard(string name, string desc, int attack, int defense, int mana)
        : base(name, desc, attack, defense, mana)
    {
    }
    public string cardName = "Mage Technomancien";
    public string description = "Un puissant mage combinant des arts magiques anciens et des technologies oubliées.";
    public int attackPoints = 8;
    public int defensePoints = 7;
    public int manaCost = 9;

    // Méthode d'initialisation à la place du constructeur
    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    // Capacité spéciale : Sort Technologique (augmente l'attaque ou la défense)
    public void CastTechSpell(bool increaseAttack)
    {
        if (increaseAttack)
        {
            attackPoints += 4;
            Debug.Log($"{cardName} utilise la technologie pour augmenter ses points d'attaque à {attackPoints} !");
        }
        else
        {
            defensePoints += 4;
            Debug.Log($"{cardName} utilise la technologie pour augmenter ses points de défense à {defensePoints} !");
        }
    }

    // Attaquer une autre carte
    public void Attack(MagitechCard target)
    {
        target.defensePoints -= attackPoints;
        Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} dégâts !");
    }

    // Réinitialiser la puissance après utilisation d'un sort
    public void ResetPower()
    {
        attackPoints = 8;  // Réinitialiser les points d'attaque
        defensePoints = 7;  // Réinitialiser les points de défense
        Debug.Log($"{cardName} réinitialise sa puissance technologique.");
    }
}
