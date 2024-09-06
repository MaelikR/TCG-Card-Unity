using UnityEngine;
using UnityEngine.UI;  // Spécifie l'utilisation de UnityEngine.UI.Text

public class UIManager : MonoBehaviour
{
    public UnityEngine.UI.Text playerHealthText;  // Spécifie l'utilisation du bon Text
    public UnityEngine.UI.Text playerManaText;

    public void UpdatePlayerStats(int health, int mana)
    {
        playerHealthText.text = $"Santé: {health}";
        playerManaText.text = $"Mana: {mana}";
    }
}
