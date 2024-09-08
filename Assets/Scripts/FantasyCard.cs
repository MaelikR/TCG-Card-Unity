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

    // M�thode d'initialisation � la place du constructeur
    public void Initialize(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    // Capacit� sp�ciale : Sort de zone
    public void CastAreaSpell(GameBoard gameBoard)
    {
        Debug.Log($"{cardName} lance un sort de zone !");

        foreach (Card enemyCard in gameBoard.opponentField)
        {
            enemyCard.defensePoints -= 3;
            Debug.Log($"{enemyCard.cardName} est touch�e par le sort de zone et perd 3 points de d�fense.");
        }
    }
    // Attaquer une autre carte
    public void Attack(FantasyCard target)
    {
        if (this.manaCost > 0)
        {
            // V�rifie si la carte cible est d�j� d�truite
            if (target.defensePoints <= 0)
            {
                Debug.Log($"{target.cardName} est d�j� d�truite.");
                return;
            }

            // Effectue l'attaque
            target.defensePoints -= attackPoints;
            Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} d�g�ts !");

            // V�rifie si la carte cible est d�truite apr�s l'attaque
            if (target.defensePoints <= 0)
            {
                Debug.Log($"{target.cardName} a �t� d�truite !");
                // Ajouter la logique pour retirer la carte du plateau, etc.
            }

            // Optionnel : La cible riposte si elle a des points d'attaque
            if (target.attackPoints > 0)
            {
                this.defensePoints -= target.attackPoints;
                Debug.Log($"{target.cardName} riposte et inflige {target.attackPoints} d�g�ts � {cardName} !");

                if (this.defensePoints <= 0)
                {
                    Debug.Log($"{cardName} a �t� d�truite lors de la riposte !");
                    // Logique pour retirer cette carte du plateau, etc.
                }
            }

            // R�duire le mana apr�s l'attaque
            this.manaCost--;
            Debug.Log($"{cardName} utilise 1 mana pour attaquer. Il reste {this.manaCost} mana.");
        }
        else
        {
            Debug.Log($"{cardName} n'a plus assez de mana pour attaquer !");
        }
    }
}
