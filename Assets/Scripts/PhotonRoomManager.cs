using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonRoomManager : MonoBehaviourPunCallbacks
{
    public InputField roomNameInput;
    public Text roomStatusText;
    public Button createRoomButton;
    public Button joinRoomButton;

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (roomNameInput.text.Length >= 3)
            {
                RoomOptions roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 2;
                roomStatusText.text = "Creating room...";
                PhotonNetwork.CreateRoom(roomNameInput.text, roomOptions);
            }
            else
            {
                roomStatusText.text = "Please enter a valid room name (at least 3 characters).";
            }
        }
        else
        {
            roomStatusText.text = "Not connected to Photon.";
            Debug.LogError("Not connected to Photon.");
        }
    }

    // Callback called when the room is created successfully
    public override void OnCreatedRoom()
    {
        roomStatusText.text = "Room created successfully!";
        Debug.Log("Room created successfully!");
        PhotonNetwork.LoadLevel("GameScene");
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (roomNameInput.text.Length >= 3)
            {
                roomStatusText.text = "Joining room...";
                PhotonNetwork.JoinRoom(roomNameInput.text);
            }
            else
            {
                roomStatusText.text = "Please enter a valid room name (at least 3 characters).";
            }
        }
        else
        {
            roomStatusText.text = "Not connected to Photon.";
            Debug.LogError("Not connected to Photon.");
        }
    }

    public override void OnJoinedRoom()
    {
        roomStatusText.text = "Joined room: " + PhotonNetwork.CurrentRoom.Name;

        // Check if both players are in the room before loading the scene
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.LoadLevel("GameScene"); // Load the game scene only when all players have joined
        }
        else
        {
            roomStatusText.text += "\nWaiting for the other player to join...";
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        roomStatusText.text = newPlayer.NickName + " joined the room.";

        // When another player joins, check again if the room is full
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.LoadLevel("GameScene"); // Now load the game scene
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Room creation failed: " + message;
        Debug.LogError("Room creation failed: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Join room failed: " + message;
        Debug.LogError("Join room failed: " + message);
    }
}
