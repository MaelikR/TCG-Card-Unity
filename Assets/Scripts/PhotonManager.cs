using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

/// <summary>
/// Manages the player's connection to Photon PUN, and room creation/joining in a single script.
/// </summary>
public class PhotonManager : MonoBehaviourPunCallbacks
{
    public InputField playerNameInput;  // Input field for the player's name
    public InputField roomNameInput;    // Input field for the room name
    public Text connectionStatusText;   // Text UI to show the current connection status
    public Text roomStatusText;         // Text UI to show room status messages
    public Button connectButton;        // Button to initiate connection
    public Button createRoomButton;     // Button to create a new room (disabled until connected)
    public Button joinRoomButton;       // Button to join an existing room (disabled until connected)

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;  // Allow scene synchronization across players
        connectButton.interactable = true;
        createRoomButton.interactable = false;
        joinRoomButton.interactable = false;
        connectionStatusText.text = "Enter your name and connect.";
    }

    /// <summary>
    /// Initiates connection to Photon PUN using the player name.
    /// </summary>
    public void ConnectToPhoton()
    {
        if (playerNameInput.text.Length >= 3)
        {
            connectButton.interactable = false;
            connectionStatusText.text = "Connecting to Photon PUN...";
            PhotonNetwork.NickName = playerNameInput.text;
            PhotonNetwork.ConnectUsingSettings();  // Use Photon PUN settings to connect
        }
        else
        {
            connectionStatusText.text = "Please enter a name with at least 3 characters.";
        }
    }

    /// <summary>
    /// Creates a room using the name entered by the player.
    /// </summary>
    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)  // Ensure that the player is connected
        {
            if (roomNameInput.text.Length >= 3)
            {
                RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };  // Set room options (e.g., max players)
                roomStatusText.text = "Creating room...";
                PhotonNetwork.CreateRoom(roomNameInput.text, roomOptions);  // Create a room with the specified name
            }
            else
            {
                roomStatusText.text = "Please enter a valid room name (at least 3 characters).";
            }
        }
        else
        {
            roomStatusText.text = "Not connected to Photon PUN. Please wait.";
            Debug.LogError("Not connected to Photon PUN.");
        }
    }

    /// <summary>
    /// Joins an existing room using the name entered by the player.
    /// </summary>
    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)  // Ensure that the player is connected
        {
            if (roomNameInput.text.Length >= 3)
            {
                roomStatusText.text = "Joining room...";
                PhotonNetwork.JoinRoom(roomNameInput.text);  // Join a room with the specified name
            }
            else
            {
                roomStatusText.text = "Please enter a valid room name (at least 3 characters).";
            }
        }
        else
        {
            roomStatusText.text = "Not connected to Photon PUN. Please wait.";
            Debug.LogError("Not connected to Photon PUN.");
        }
    }

    /// <summary>
    /// Callback when the player successfully connects to the Photon master server.
    /// </summary>
    public override void OnConnectedToMaster()
    {
        connectionStatusText.text = "Connected to Photon PUN. Ready to create or join a room.";
        connectButton.gameObject.SetActive(false);  // Désactiver le bouton "Connect"
        createRoomButton.interactable = true;  // Activer les autres boutons
        joinRoomButton.interactable = true;
        Debug.Log("Connected to Photon PUN.");
    }

    void Update()
    {
        connectionStatusText.text = "Status: " + PhotonNetwork.NetworkClientState;
    }

    /// <summary>
    /// Callback when the room is successfully created.
    /// </summary>
    public override void OnCreatedRoom()
    {
        roomStatusText.text = "Room created successfully!";
        Debug.Log("Room created successfully!");
        PhotonNetwork.LoadLevel("ConnectGameScene");  // Load the game scene when the room is created
    }

    /// <summary>
    /// Callback when room creation fails.
    /// </summary>
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Room creation failed: " + message;
        Debug.LogError("Room creation failed: " + message);
    }

    /// <summary>
    /// Callback when joining a room fails.
    /// </summary>
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Join room failed: " + message;
        Debug.LogError("Join room failed: " + message);
    }

    /// <summary>
    /// Callback when a player joins the room.
    /// </summary>
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        roomStatusText.text = newPlayer.NickName + " joined the room.";

        // Check if the room is full, and start the game when all players have joined
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.LoadLevel("ConnectGameScene");  // Load the game scene when all players are in the room
        }
    }

    /// <summary>
    /// Callback when the player disconnects from Photon.
    /// </summary>
    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        connectionStatusText.text = "Disconnected: " + cause.ToString();
        connectButton.interactable = true;
        createRoomButton.interactable = false;
        joinRoomButton.interactable = false;
        Debug.LogError("Disconnected from Photon PUN: " + cause.ToString());
    }
}
