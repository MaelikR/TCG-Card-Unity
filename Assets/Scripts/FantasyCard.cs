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
        if (this.manaCost > 0)
        {
            // Vérifie si la carte cible est déjà détruite
            if (target.defensePoints <= 0)
            {
                Debug.Log($"{target.cardName} est déjà détruite.");
                return;
            }

            // Effectue l'attaque
            target.defensePoints -= attackPoints;
            Debug.Log($"{cardName} attaque {target.cardName}, infligeant {attackPoints} dégâts !");

            // Vérifie si la carte cible est détruite après l'attaque
            if (target.defensePoints <= 0)
            {
                Debug.Log($"{target.cardName} a été détruite !");
                // Ajouter la logique pour retirer la carte du plateau, etc.
            }

            // Optionnel : La cible riposte si elle a des points d'attaque
            if (target.attackPoints > 0)
            {
                this.defensePoints -= target.attackPoints;
                Debug.Log($"{target.cardName} riposte et inflige {target.attackPoints} dégâts à {cardName} !");

                if (this.defensePoints <= 0)
                {
                    Debug.Log($"{cardName} a été détruite lors de la riposte !");
                    // Logique pour retirer cette carte du plateau, etc.
                }
            }

            // Réduire le mana après l'attaque
            this.manaCost--;
            Debug.Log($"{cardName} utilise 1 mana pour attaquer. Il reste {this.manaCost} mana.");
        }
        else
        {
            Debug.Log($"{cardName} n'a plus assez de mana pour attaquer !");
        }
    }
}
