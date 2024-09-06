using UnityEngine;
using UnityEngine.UI;

public class TurnManagerUI : MonoBehaviour
{
    public Button endTurnButton;
    public TurnManager turnManager;

    void Start()
    {
        // Ajouter une fonction au bouton de fin de tour
        endTurnButton.onClick.AddListener(EndPlayerTurn);
    }

    public void EndPlayerTurn()
    {
        turnManager.EndTurn();
    }
}
