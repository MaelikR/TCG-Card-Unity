using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public InputField playerNameInput;
    public Text connectionStatusText;
    public Button connectButton;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true; // Pour synchroniser la sc�ne
        connectButton.interactable = true;
        connectionStatusText.text = "Enter your name and connect.";
    }

    public void ConnectToPhoton()
    {
        if (playerNameInput.text.Length >= 3)
        {
            connectButton.interactable = false;
            connectionStatusText.text = "Connecting to Photon...";
            PhotonNetwork.NickName = playerNameInput.text; // Attribuer le pseudo
            PhotonNetwork.ConnectUsingSettings(); // Connexion � Photon
        }
        else
        {
            connectionStatusText.text = "Please enter a name with at least 3 characters.";
        }
    }

    // Callback lorsque la connexion � Photon est r�ussie
    public override void OnConnectedToMaster()
    {
        connectionStatusText.text = "Connected to Photon. Ready to join or create a room.";
        connectButton.gameObject.SetActive(false); // Cache le bouton de connexion apr�s r�ussite
    }

    // Callback lorsque la connexion �choue
    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        connectionStatusText.text = "Disconnected: " + cause.ToString();
        connectButton.interactable = true; // R�activer le bouton si la connexion �choue
    }
}
