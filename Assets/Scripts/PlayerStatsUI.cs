using UnityEngine;
using UnityEngine.UI;


public class PlayerStatsUI : MonoBehaviour
{
	public Text playerHealthText;
	public Text playerManaText;
	public Text opponentHealthText;
	public Text opponentManaText;

	public void UpdatePlayerStats(int playerHealth, int playerMana, int opponentHealth, int opponentMana)
	{
		playerHealthText.text = "Vie : " + playerHealth;
		playerManaText.text = "Mana : " + playerMana;

		opponentHealthText.text = "Vie Adversaire : " + opponentHealth;
		opponentManaText.text = "Mana Adversaire : " + opponentMana;
	}
}
