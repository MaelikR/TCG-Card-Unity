using UnityEngine;
using Photon.Pun;  // Pour Photon

[System.Serializable]
public class Card : MonoBehaviourPun  // Hérite de MonoBehaviourPun pour accéder à photonView
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

    // Méthode d'attaque en réseau
    [PunRPC]
    public void Attack(Card target)
    {
        target.defensePoints -= attackPoints;
        Debug.Log($"{cardName} attaque {target.cardName} et inflige {attackPoints} points de dégâts !");
        photonView.RPC("OnDamage", RpcTarget.AllBuffered, target.cardName, attackPoints);  // Synchronisation en réseau
    }

    // Méthode de gestion des dégâts en réseau
    [PunRPC]
    public void OnDamage(string cardName, int damage)
    {
        Debug.Log($"La carte {cardName} subit {damage} points de dégâts.");
        // Mise à jour des stats de la carte
    }

    // Réinitialiser après un tour (réseau)
    [PunRPC]
    public void ResetStats()
    {
        // Réinitialiser les stats (attaque, défense)
    }
}
