using System.Diagnostics;
using UnityEngine;


[System.Serializable]
public class NeoFuturisticCard : Card
{
    public NeoFuturisticCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Fix the constructor call
    {
    }
    public new string cardName;  // This will hide the base class field
    public new string description;
    public new int attackPoints;
    public new int defensePoints;
    public new int manaCost;
 
    // Capacit� sp�ciale : Attaque laser
    public void LaserAttack()
    {
        attackPoints += 3;  // Augmente temporairement l'attaque
        UnityEngine.Debug.Log($"{cardName} utilise une attaque laser, augmentant son attaque � {attackPoints} !");
    }

    // Attaquer une autre carte
    public void Attack(NeoFuturisticCard target)
    {
        target.defensePoints -= attackPoints;
        UnityEngine.Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} d�g�ts !");
    }

    // R�initialiser apr�s un tour
    public void ResetAttack()
    {
        attackPoints = 10;
    }
}
