using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    void Start()
    {
        // Initialiser la sant� du joueur avec la valeur maximale au d�but du jeu
        currentHealth = maxHealth;
    }

    // M�thode pour infliger des d�g�ts au joueur
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Le joueur subit {damage} points de d�g�ts ! Sant� restante : {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�thode pour g�rer la mort du joueur
    void Die()
    {
        Debug.Log("Le joueur a perdu !");
        // Ajoute ici la logique pour quand le joueur perd (fin du jeu, r�initialisation, etc.)
    }

    // M�thode pour soigner le joueur
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // S'assurer que la sant� ne d�passe pas la limite
        }
        Debug.Log($"Le joueur est soign� de {amount} points ! Sant� actuelle : {currentHealth}");
    }
}
