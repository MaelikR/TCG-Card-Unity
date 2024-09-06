using System.Diagnostics;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
	public void Combat(Card attacker, Card defender)
	{
		defender.defensePoints -= attacker.attackPoints;
        UnityEngine.Debug.Log($"{attacker.cardName} attaque {defender.cardName}, infligeant {attacker.attackPoints} points de d�g�ts.");

		if (defender.defensePoints <= 0)
		{
            UnityEngine.Debug.Log($"{defender.cardName} est d�truite !");
		}
	}
}
