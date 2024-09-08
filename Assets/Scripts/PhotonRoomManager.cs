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
        if (PhotonNetwork.IsConnectedAndReady)  // Vérifier si la connexion est prête
        {
            if (roomNameInput.text.Length >= 3)
            {
                RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
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
            roomStatusText.text = "Not connected to Photon PUN. Please wait.";
            Debug.LogError("Not connected to Photon PUN.");
        }
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)  // Vérifier si la connexion est prête
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
            roomStatusText.text = "Not connected to Photon PUN. Please wait.";
            Debug.LogError("Not connected to Photon PUN.");
        }
    }


    public override void OnCreatedRoom()
    {
        roomStatusText.text = "Room created successfully!";
        Debug.Log("Room created successfully!");
        PhotonNetwork.LoadLevel("ConnectGameScene");  // Charger la scène du jeu lorsque la salle est créée
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

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        roomStatusText.text = newPlayer.NickName + " joined the room.";

        // Vérifier si la salle est pleine et commencer la partie
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.LoadLevel("ConnectGameScene");  // Charger la scène lorsque tous les joueurs sont dans la salle
        }
    }
}
