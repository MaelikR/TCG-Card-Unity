using System.Diagnostics;
using UnityEngine;

[System.Serializable]
public class NeoFuturisticCard : Card  // Hérite maintenant de Card
{
    public string cardName = "Cyber Soldat";
    public string description = "Un soldat augmenté avec des implants cybernétiques et une armure futuriste.";
    public int attackPoints = 10;
    public int defensePoints = 5;
    public int manaCost = 8;

    public NeoFuturisticCard(string name, string desc, int attack, int defense, int mana) : base(name, desc, attack, defense, mana)
    {
    }

    // Capacité spéciale : Attaque laser
    public void LaserAttack()
    {
        attackPoints += 3;  // Augmente temporairement l'attaque
        UnityEngine.Debug.Log($"{cardName} utilise une attaque laser, augmentant son attaque à {attackPoints} !");
    }

    // Attaquer une autre carte
    public void Attack(NeoFuturisticCard target)
    {
        target.defensePoints -= attackPoints;
        UnityEngine.Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} dégâts !");
    }

    // Réinitialiser après un tour
    public void ResetAttack()
    {
        attackPoints = 10;
    }
}
