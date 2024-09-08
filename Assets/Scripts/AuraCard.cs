using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class AuraCard : Card  // H�rite de Card
{
    public AuraCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Appel du constructeur de la classe parente Card
    {
    }

    public string cardName = "Aura de Protection Mystique";
    public string cardDescription = "Augmente la d�fense de toutes les unit�s alli�es de +3 et r�duit les effets des sorts ennemis de moiti�.";

    public int defenseBoost = 3;
    public float spellResistance = 0.5f;

    // Liste des unit�s alli�es affect�es par l'aura
    private List<Card> affectedAlliedUnits = new List<Card>();

    // Appel� lorsqu'on joue l'aura
    public void PlayAura(GameBoard gameBoard, bool isPlayer)
    {
        // Appeler la m�thode PlaceCard avec l'objet AuraCard qui est maintenant une Card
        gameBoard.PlaceCard(this, isPlayer);

        // Appliquer l'aura � toutes les unit�s alli�es
        ApplyAuraEffect(gameBoard.playerField);

        // Synchroniser l'effet de l'aura sur tous les joueurs
        photonView.RPC("ApplyAuraEffect", RpcTarget.All, gameBoard.playerField);
    }

    [PunRPC]
    public void ApplyAuraEffect(List<Card> alliedUnits)
    {
        foreach (Card unit in alliedUnits)
        {
            // Augmenter la d�fense des unit�s
            unit.defensePoints += defenseBoost;
            affectedAlliedUnits.Add(unit);
            Debug.Log($"{unit.cardName} re�oit un bonus de d�fense de {defenseBoost} points gr�ce � l'aura.");
        }
    }

    public void RemoveAura(GameBoard gameBoard)
    {
        foreach (Card unit in affectedAlliedUnits)
        {
            unit.defensePoints -= defenseBoost;
            Debug.Log($"{unit.cardName} perd le bonus de d�fense de {defenseBoost} points.");
        }

        // Supprimer l'aura du terrain
        gameBoard.playerField.Remove(this);
        affectedAlliedUnits.Clear();
    }
}
