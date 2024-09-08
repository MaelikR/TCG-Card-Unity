using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Ma�treSorcierTemp�te : Card
{
    public Ma�treSorcierTemp�te(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)
    {
    }

    // M�thode d'initialisation � la place du constructeur
    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    // Capacit� sp�ciale : Invocation de Temp�te
    public void InvokeStorm(GameBoard gameBoard)
    {
        Debug.Log($"{cardName} invoque une temp�te d�vastatrice !");

        foreach (Card enemyCard in gameBoard.opponentField)
        {
            enemyCard.defensePoints -= 5;
            Debug.Log($"{enemyCard.cardName} est frapp�e par la temp�te et perd 5 points de d�fense.");
        }
    }

    // Capacit� sp�ciale : Foudre Concentr�e (attaque de cible unique)
    public void LightningStrike(Card target)
    {
        Debug.Log($"{cardName} utilise Foudre Concentr�e sur {target.cardName} !");
        target.defensePoints -= attackPoints * 2; // D�g�ts doubles pour Foudre Concentr�e
        Debug.Log($"{target.cardName} re�oit {attackPoints * 2} points de d�g�ts !");
    }

    // Attaquer une autre carte
    public new void Attack(Card target)
    {
        target.defensePoints -= attackPoints;
        Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} d�g�ts !");
    }

    // Effet d�clench� au d�but du tour
    public void OnTurnStart(GameBoard gameBoard)
    {
        Debug.Log($"D�but du tour : {cardName} invoque automatiquement une temp�te !");
        InvokeStorm(gameBoard);  // Invoque la temp�te � chaque d�but de tour
    }
}
