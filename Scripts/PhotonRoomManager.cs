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
        if (roomNameInput.text.Length >= 3)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2; // Par exemple, une partie à deux joueurs
            PhotonNetwork.CreateRoom(roomNameInput.text, roomOptions);
        }
        else
        {
            roomStatusText.text = "Please enter a valid room name.";
        }
    }

    public void JoinRoom()
    {
        if (roomNameInput.text.Length >= 3)
        {
            PhotonNetwork.JoinRoom(roomNameInput.text);
        }
        else
        {
            roomStatusText.text = "Please enter a valid room name.";
        }
    }

    public override void OnJoinedRoom()
    {
        roomStatusText.text = "Joined room: " + PhotonNetwork.CurrentRoom.Name;
        PhotonNetwork.LoadLevel("GameScene"); // Charger la scène principale du jeu après avoir rejoint une salle
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Room creation failed: " + message;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomStatusText.text = "Join room failed: " + message;
    }
}
