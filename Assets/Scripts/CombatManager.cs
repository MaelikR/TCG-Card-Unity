using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public void Combat(Card attacker, Card defender)
    {
        defender.TakeDamage(attacker.attackPoints);
        Debug.Log($"{attacker.cardName} attacks {defender.cardName}, dealing {attacker.attackPoints} damage.");

        if (defender.defensePoints <= 0)
        {
            Debug.Log($"{defender.cardName} is destroyed!");
        }
    }
}
