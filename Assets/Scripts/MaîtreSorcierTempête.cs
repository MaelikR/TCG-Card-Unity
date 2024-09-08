using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class MaîtreSorcierTempête : Card
{
    public MaîtreSorcierTempête(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)
    {
    }

    // Méthode d'initialisation à la place du constructeur
    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    // Capacité spéciale : Invocation de Tempête
    public void InvokeStorm(GameBoard gameBoard)
    {
        Debug.Log($"{cardName} invoque une tempête dévastatrice !");

        foreach (Card enemyCard in gameBoard.opponentField)
        {
            enemyCard.defensePoints -= 5;
            Debug.Log($"{enemyCard.cardName} est frappée par la tempête et perd 5 points de défense.");
        }
    }

    // Capacité spéciale : Foudre Concentrée (attaque de cible unique)
    public void LightningStrike(Card target)
    {
        Debug.Log($"{cardName} utilise Foudre Concentrée sur {target.cardName} !");
        target.defensePoints -= attackPoints * 2; // Dégâts doubles pour Foudre Concentrée
        Debug.Log($"{target.cardName} reçoit {attackPoints * 2} points de dégâts !");
    }

    // Attaquer une autre carte
    public new void Attack(Card target)
    {
        target.defensePoints -= attackPoints;
        Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} dégâts !");
    }

    // Effet déclenché au début du tour
    public void OnTurnStart(GameBoard gameBoard)
    {
        Debug.Log($"Début du tour : {cardName} invoque automatiquement une tempête !");
        InvokeStorm(gameBoard);  // Invoque la tempête à chaque début de tour
    }
}
