using UnityEngine;

public class OpponentHealth : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    void Start()
    {
        // Initialiser la sant� de l'adversaire avec la valeur maximale
        currentHealth = maxHealth;
    }

    // M�thode pour infliger des d�g�ts � l'adversaire
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"L'adversaire subit {damage} points de d�g�ts ! Sant� restante : {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�thode pour g�rer la d�faite de l'adversaire
    void Die()
    {
        Debug.Log("L'adversaire a perdu !");
        // Ajoute ici la logique pour quand l'adversaire perd
    }

    // M�thode pour soigner l'adversaire
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // S'assurer que la sant� ne d�passe pas la limite
        }
        Debug.Log($"L'adversaire est soign� de {amount} points ! Sant� actuelle : {currentHealth}");
    }
}
