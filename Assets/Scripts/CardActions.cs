using Photon.Pun;
using System.Diagnostics;
using UnityEngine;

public class CardActions : MonoBehaviourPunCallbacks
{
    public void PlayCard(int cardID, bool isPlayer)
    {
        // Appeler l'action r�seau pour jouer une carte
        photonView.RPC("OnPlayCard", RpcTarget.All, cardID, isPlayer);
    }

    [PunRPC]
    public void OnPlayCard(int cardID, bool isPlayer)
    {
        // Ex�cuter la logique de placement de carte sur le terrain ici
        if (isPlayer)
        {
            // Ajouter la carte au terrain du joueur
        }
        else
        {
            // Ajouter la carte au terrain de l'adversaire
        }
    }

    public void Attack(int attackerCardID, int targetCardID)
    {
        // Synchroniser l'attaque entre les joueurs
        photonView.RPC("OnAttack", RpcTarget.All, attackerCardID, targetCardID);
    }

    [PunRPC]
    public void OnAttack(int attackerCardID, int targetCardID)
    {
        // G�rer l'attaque entre deux cartes ici
        UnityEngine.Debug.Log($"Carte {attackerCardID} attaque la carte {targetCardID}");
    }
}
