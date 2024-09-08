using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class AuraCard : Card  // Hérite de Card
{
    public AuraCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Appel du constructeur de la classe parente Card
    {
    }

    public string cardName = "Aura de Protection Mystique";
    public string cardDescription = "Augmente la défense de toutes les unités alliées de +3 et réduit les effets des sorts ennemis de moitié.";

    public int defenseBoost = 3;
    public float spellResistance = 0.5f;

    // Liste des unités alliées affectées par l'aura
    private List<Card> affectedAlliedUnits = new List<Card>();

    // Appelé lorsqu'on joue l'aura
    public void PlayAura(GameBoard gameBoard, bool isPlayer)
    {
        // Appeler la méthode PlaceCard avec l'objet AuraCard qui est maintenant une Card
        gameBoard.PlaceCard(this, isPlayer);

        // Appliquer l'aura à toutes les unités alliées
        ApplyAuraEffect(gameBoard.playerField);

        // Synchroniser l'effet de l'aura sur tous les joueurs
        photonView.RPC("ApplyAuraEffect", RpcTarget.All, gameBoard.playerField);
    }

    [PunRPC]
    public void ApplyAuraEffect(List<Card> alliedUnits)
    {
        foreach (Card unit in alliedUnits)
        {
            // Augmenter la défense des unités
            unit.defensePoints += defenseBoost;
            affectedAlliedUnits.Add(unit);
            Debug.Log($"{unit.cardName} reçoit un bonus de défense de {defenseBoost} points grâce à l'aura.");
        }
    }

    public void RemoveAura(GameBoard gameBoard)
    {
        foreach (Card unit in affectedAlliedUnits)
        {
            unit.defensePoints -= defenseBoost;
            Debug.Log($"{unit.cardName} perd le bonus de défense de {defenseBoost} points.");
        }

        // Supprimer l'aura du terrain
        gameBoard.playerField.Remove(this);
        affectedAlliedUnits.Clear();
    }
}
