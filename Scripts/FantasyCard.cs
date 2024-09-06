using UnityEngine;

[System.Serializable]
public class FantasyCard : Card
{
    public FantasyCard(string name, string desc, int attack, int defense, int mana)
        : base(name, desc, attack, defense, mana)
    {
    }
    public string cardName = "Mage Mystique";
    public string description = "Un mage puissant maîtrisant la magie des arcanes.";
    public int attackPoints = 5;
    public int defensePoints = 4;
    public int manaCost = 7;

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
