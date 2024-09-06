using System.Diagnostics;
using UnityEngine;

public class ApplyDamageToPlayer : MonoBehaviour
{
    public int playerHealth = 30;
    public int opponentHealth = 30;

    public void ApplyDamage(bool isPlayer, int damage)
    {
        if (isPlayer)
        {
            playerHealth -= damage;
            UnityEngine.Debug.Log($"Le joueur subit {damage} points de dégâts ! Points de vie restants : {playerHealth}");
        }
        else
        {
            opponentHealth -= damage;
            UnityEngine.Debug.Log($"L'adversaire subit {damage} points de dégâts ! Points de vie restants : {opponentHealth}");
        }

        if (playerHealth <= 0)
        {
            UnityEngine.Debug.Log("Le joueur a perdu !");
        }

        if (opponentHealth <= 0)
        {
            UnityEngine.Debug.Log("L'adversaire a perdu !");
        }
    }
}
