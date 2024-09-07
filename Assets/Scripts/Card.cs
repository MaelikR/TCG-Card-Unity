using UnityEngine;
using Photon.Pun;

[System.Serializable]
public class Card : MonoBehaviourPun
{
    public int cardID;
    public string cardName;
    public string description;
    public int attackPoints;
    public int defensePoints;
    public int manaCost;
    public Sprite cardSprite;
    public string cardType;

    // Constructor with parameters
    public Card(int id, string name, string desc, int attack, int defense, int mana)
    {
        cardID = id;
        cardName = name;
        description = desc;
        attackPoints = attack;
        defensePoints = defense;
        manaCost = mana;
    }

    [PunRPC]
    public void Attack(Card target)
    {
        target.TakeDamage(attackPoints);
        Debug.Log($"{cardName} attacks {target.cardName}, dealing {attackPoints} damage!");
    }

    public void TakeDamage(int damage)
    {
        defensePoints -= damage;
        if (defensePoints <= 0)
        {
            photonView.RPC("OnDestroyed", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void OnDestroyed()
    {
        Debug.Log($"{cardName} is destroyed.");
        PhotonNetwork.Destroy(gameObject);
    }
}
