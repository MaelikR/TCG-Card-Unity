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
        if (PhotonNetwork.IsConnectedAndReady) // Make sure we are connected to the Photon Master Server
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
            roomStatusText.text = "Not connected to Photon. Please wait.";
            Debug.LogError("Not connected to Photon.");
        }
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady) // Make sure we are connected to the Photon Master Server
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
            roomStatusText.text = "Not connected to Photon. Please wait.";
            Debug.LogError("Not connected to Photon.");
        }
    }

    // Callback when a room is successfully created
    public override void OnCreatedRoom()
    {
        roomStatusText.text = "Room created successfully!";
        Debug.Log("Room created successfully!");
        PhotonNetwork.LoadLevel("ConnectGameScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        roomStatusText.text = newPlayer.NickName + " joined the room.";

        // Check again if the room is full before loading the game scene
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.LoadLevel("ConnectGameScene");
        }
    }

    // Handle room creation failure
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Room creation failed: " + message;
        Debug.LogError("Room creation failed: " + message);
    }

    // Handle join room failure
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Join room failed: " + message;
        Debug.LogError("Join room failed: " + message);
    }
}
