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
        PhotonNetwork.AutomaticallySyncScene = true; // Pour synchroniser la scène
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
            PhotonNetwork.ConnectUsingSettings(); // Connexion à Photon
        }
        else
        {
            connectionStatusText.text = "Please enter a name with at least 3 characters.";
        }
    }

    // Callback lorsque la connexion à Photon est réussie
    public override void OnConnectedToMaster()
    {
        connectionStatusText.text = "Connected to Photon. Ready to join or create a room.";
        connectButton.gameObject.SetActive(false); // Cache le bouton de connexion après réussite
    }

    // Callback lorsque la connexion échoue
    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        connectionStatusText.text = "Disconnected: " + cause.ToString();
        connectButton.interactable = true; // Réactiver le bouton si la connexion échoue
    }
}
