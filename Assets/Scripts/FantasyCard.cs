using UnityEngine;

[System.Serializable]
public class FantasyCard : Card
{
    public FantasyCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Passes to the base class (Card) constructor
    {
    }

    public new string cardName;  // This will hide the base class field
    public new string description;
    public new int attackPoints;
    public new int defensePoints;
    public new int manaCost;

    // Méthode d'initialisation à la place du constructeur
    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    // Capacité spéciale : Sort de zone
    public void CastAreaSpell(GameBoard gameBoard)
    {
        Debug.Log($"{cardName} lance un sort de zone !");

        foreach (Card enemyCard in gameBoard.opponentField)
        {
            enemyCard.defensePoints -= 3;
            Debug.Log($"{enemyCard.cardName} est touchée par le sort de zone et perd 3 points de défense.");
        }
    }

    // Attaquer une autre carte
    public void Attack(FantasyCard target)
    {
        target.defensePoints -= attackPoints;
        Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} dégâts !");
    }
}
