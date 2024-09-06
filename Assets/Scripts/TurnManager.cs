using UnityEngine;
using Photon.Pun;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public DeckManager deckManager;
    public PlayerStatsUI playerStatsUI;
    public FieldUI fieldUI;
    public GameLogUI gameLogUI;
    public bool isPlayerTurn = true;
    public int playerMana = 10;
    public int opponentMana = 10;
    public GameBoard gameBoard;
    public void EndTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        gameLogUI.AddMessageToLog(isPlayerTurn ? "Tour du joueur" : "Tour de l'adversaire");

        if (isPlayerTurn)
        {
            playerMana += 2;
            deckManager.DrawCardWithLimit(true);
        }
        else
        {
            opponentMana += 2;
            deckManager.DrawCardWithLimit(false);
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        playerStatsUI.UpdatePlayerStats(30, playerMana, 30, opponentMana);
        fieldUI.UpdateFieldUI(gameBoard.playerField, gameBoard.opponentField);  // Corrige l'accès ici
    }

    public void DrawCard(bool isPlayer)
    {
        if (isPlayer)
        {
            Card drawnCard = deckManager.DrawCardWithLimit(isPlayer);
            if (drawnCard != null)
            {
                Debug.Log($"{(isPlayer ? "Le joueur" : "L'adversaire")} pioche {drawnCard.cardName}");
            }
        }
        else
        {
            Card drawnCard = deckManager.DrawCardWithLimit(isPlayer);
            if (drawnCard != null)
            {
                Debug.Log($"L'adversaire pioche {drawnCard.cardName}");
            }
        }
    }
}
