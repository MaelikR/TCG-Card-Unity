using UnityEngine;
using UnityEngine.UI;  // Sp�cifie l'utilisation de UnityEngine.UI.Text

public class UIManager : MonoBehaviour
{
    public UnityEngine.UI.Text playerHealthText;  // Sp�cifie l'utilisation du bon Text
    public UnityEngine.UI.Text playerManaText;

    public void UpdatePlayerStats(int health, int mana)
    {
        playerHealthText.text = $"Sant�: {health}";
        playerManaText.text = $"Mana: {mana}";
    }
}
