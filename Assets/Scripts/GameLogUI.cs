using UnityEngine;
using UnityEngine.UI;


public class GameLogUI : MonoBehaviour
{
    public Text gameLogText;  // R�f�rence � la zone de texte du log

    // Ajouter un message au log
    public void AddMessageToLog(string message)
    {
        gameLogText.text += message + "\n";  // Ajouter le message avec un saut de ligne
    }
}
