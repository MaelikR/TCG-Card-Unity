using Photon.Pun;
using Photon.Realtime;
using System.Diagnostics;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public DeckManager deckManager;
    public FieldUI fieldUI;
    public HandUI handUI;

    // Synchroniser l'�tat du joueur
    public int playerHealth = 30;
    public int playerMana = 10;

    void Start()
    {
        // Si ce joueur est le local player
        if (photonView.IsMine)
        {
            // Initialiser la main et le terrain pour le joueur local
            InitPlayer();
        }
    }

    void InitPlayer()
    {
        deckManager.ShuffleDeck();
        DrawInitialHand();
    }

    // Piocher les cartes initiales pour le joueur
    void DrawInitialHand()
    {
        for (int i = 0; i < 5; i++)
        {
            deckManager.DrawCardWithLimit(true);
        }
        handUI.UpdateHandUI(deckManager.hand);
    }

    // Appel r�seau pour piocher une carte
    [PunRPC]
    public void DrawCard()
    {
        if (photonView.IsMine)
        {
            deckManager.DrawCardWithLimit(true);
            handUI.UpdateHandUI(deckManager.hand);
        }
    }

    // Appliquer des d�g�ts (multijoueur)
    [PunRPC]
    public void ApplyDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            UnityEngine.Debug.Log("Le joueur a perdu !");
        }
        else
        {
            UnityEngine.Debug.Log($"Le joueur subit {damage} points de d�g�ts, sant� restante : {playerHealth}");
        }
    }

    // Utiliser un sort (multijoueur)
    [PunRPC]
    public void CastSpell(int cardID)
    {
        // Utiliser une carte dans la main (identifier par ID) et appliquer son effet
    }
}
