using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public InputField playerNameInput;
    public Text connectionStatusText;
    public Button connectButton;
    public Button createRoomButton;
    public Button joinRoomButton;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;  // Permet la synchronisation des scènes entre joueurs
        connectButton.interactable = true;
        createRoomButton.interactable = false;
        joinRoomButton.interactable = false;
        connectionStatusText.text = "Enter your name and connect.";
    }

    public void ConnectToPhoton()
    {
        if (playerNameInput.text.Length >= 3)
        {
            connectButton.interactable = false;
            connectionStatusText.text = "Connecting to Photon PUN...";
            PhotonNetwork.NickName = playerNameInput.text;
            PhotonNetwork.ConnectUsingSettings();  // Utiliser les paramètres de connexion de Photon PUN
        }
        else
        {
            connectionStatusText.text = "Please enter a name with at least 3 characters.";
        }
    }

    public override void OnConnectedToMaster()
    {
        connectionStatusText.text = "Connected to Photon PUN. Ready to create or join a room.";
        connectButton.gameObject.SetActive(false);
        createRoomButton.interactable = true;  // Activer les boutons après la connexion
        joinRoomButton.interactable = true;
        Debug.Log("Connected to Photon PUN.");
    }


    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        connectionStatusText.text = "Disconnected: " + cause.ToString();
        connectButton.interactable = true;
        createRoomButton.interactable = false;
        joinRoomButton.interactable = false;
        Debug.LogError("Disconnected from Photon PUN: " + cause.ToString());
    }

    void Update()
    {
        connectionStatusText.text = "Status: " + PhotonNetwork.NetworkClientState; // Afficher l'état réseau
    }
}
