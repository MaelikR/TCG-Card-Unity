using UnityEngine;
using Photon.Pun;  // Pour Photon

[System.Serializable]
public class Card : MonoBehaviourPun  // H�rite de MonoBehaviourPun pour acc�der � photonView
{
    public string cardName;
    public string description;
    public int attackPoints;
    public int defensePoints;
    public int manaCost;
    public Sprite cardSprite;
    public string cardType;

    // Constructeur de carte
    public Card(string name, string desc, int attack, int defense, int mana)
    {
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    // M�thode d'attaque en r�seau
    [PunRPC]
    public void Attack(Card target)
    {
        target.defensePoints -= attackPoints;
        Debug.Log($"{cardName} attaque {target.cardName} et inflige {attackPoints} points de d�g�ts !");
        photonView.RPC("OnDamage", RpcTarget.AllBuffered, target.cardName, attackPoints);  // Synchronisation en r�seau
    }

    // M�thode de gestion des d�g�ts en r�seau
    [PunRPC]
    public void OnDamage(string cardName, int damage)
    {
        Debug.Log($"La carte {cardName} subit {damage} points de d�g�ts.");
        // Mise � jour des stats de la carte
    }

    // R�initialiser apr�s un tour (r�seau)
    [PunRPC]
    public void ResetStats()
    {
        // R�initialiser les stats (attaque, d�fense)
    }
}
