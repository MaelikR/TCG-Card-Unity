using UnityEngine;

public class OpponentHealth : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    void Start()
    {
        // Initialiser la santé de l'adversaire avec la valeur maximale
        currentHealth = maxHealth;
    }

    // Méthode pour infliger des dégâts à l'adversaire
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"L'adversaire subit {damage} points de dégâts ! Santé restante : {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Méthode pour gérer la défaite de l'adversaire
    void Die()
    {
        Debug.Log("L'adversaire a perdu !");
        // Ajoute ici la logique pour quand l'adversaire perd
    }

    // Méthode pour soigner l'adversaire
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // S'assurer que la santé ne dépasse pas la limite
        }
        Debug.Log($"L'adversaire est soigné de {amount} points ! Santé actuelle : {currentHealth}");
    }
}
