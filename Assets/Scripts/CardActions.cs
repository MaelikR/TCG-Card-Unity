using Photon.Pun;
using System.Diagnostics;
using UnityEngine;

public class CardActions : MonoBehaviourPunCallbacks
{
    public GameBoard gameBoard; // Reference to the GameBoard where cards will be placed
    public CombatManager combatManager; // Reference to manage combat between cards

    // Play a card and sync it across all players
    public void PlayCard(int cardID, bool isPlayer)
    {
        // Call the network action to play a card
        photonView.RPC("OnPlayCard", RpcTarget.All, cardID, isPlayer);
    }

    // Network method called when a card is played
    [PunRPC]
    public void OnPlayCard(int cardID, bool isPlayer)
    {
        // Simulate getting the card from the card ID
        Card card = GetCardByID(cardID);

        if (card != null)
        {
            if (isPlayer)
            {
                // Add the card to the player's field
                gameBoard.PlaceCard(card, true);
                UnityEngine.Debug.Log($"Le joueur a placé {card.cardName} sur le terrain.");
            }
            else
            {
                // Add the card to the opponent's field
                gameBoard.PlaceCard(card, false);
                UnityEngine.Debug.Log($"L'adversaire a placé {card.cardName} sur le terrain.");
            }
        }
        else
        {
            UnityEngine.Debug.LogError($"Carte avec l'ID {cardID} introuvable.");
        }
    }

    // Attack and sync the attack across all players
    public void Attack(int attackerCardID, int targetCardID)
    {
        // Synchronize the attack between players
        photonView.RPC("OnAttack", RpcTarget.All, attackerCardID, targetCardID);
    }

    // Network method to manage the attack logic
    [PunRPC]
    public void OnAttack(int attackerCardID, int targetCardID)
    {
        // Simulate getting the attacker and target cards from their IDs
        Card attacker = GetCardByID(attackerCardID);
        Card target = GetCardByID(targetCardID);

        if (attacker != null && target != null)
        {
            // Execute the combat logic between the two cards
            combatManager.Combat(attacker, target);
            UnityEngine.Debug.Log($"Carte {attacker.cardName} attaque la carte {target.cardName}.");
        }
        else
        {
            UnityEngine.Debug.LogError($"Attaque échouée : Attaquant ou cible introuvable.");
        }
    }

    // Simulated method to retrieve a card object based on its ID
    private Card GetCardByID(int cardID)
    {
        // This method would look up a card by its ID
        // You need to implement a system that assigns unique IDs to cards
        // This is just a placeholder
        return null; // Replace with actual logic
    }
}
