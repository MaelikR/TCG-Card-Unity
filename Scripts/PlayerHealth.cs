using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    void Start()
    {
        // Initialiser la santé du joueur avec la valeur maximale au début du jeu
        currentHealth = maxHealth;
    }

    // Méthode pour infliger des dégâts au joueur
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Le joueur subit {damage} points de dégâts ! Santé restante : {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Méthode pour gérer la mort du joueur
    void Die()
    {
        Debug.Log("Le joueur a perdu !");
        // Ajoute ici la logique pour quand le joueur perd (fin du jeu, réinitialisation, etc.)
    }

    // Méthode pour soigner le joueur
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // S'assurer que la santé ne dépasse pas la limite
        }
        Debug.Log($"Le joueur est soigné de {amount} points ! Santé actuelle : {currentHealth}");
    }
}
