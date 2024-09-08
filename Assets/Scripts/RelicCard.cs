using UnityEngine;

public class RelicCard : Card  // Hérite de Card
{
    public RelicCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Appel du constructeur de la classe parente Card
    {
    }

    public string cardName = "Relique";
    public string description = "Une relique ancienne avec un pouvoir mystérieux.";
    public int manaCost = 3;

    public void PlayRelic(GameBoard gameBoard, bool isPlayer)
    {
        // Appeler la méthode PlaceCard avec l'objet RelicCard qui est maintenant une Card
        gameBoard.PlaceCard(this, isPlayer);

        // Effet spécifique de la relique peut être appliqué ici
        Debug.Log($"{cardName} a été placée sur le terrain.");
    }

    public void RemoveRelic(GameBoard gameBoard)
    {
        // Retirer la carte relique du terrain
        gameBoard.playerField.Remove(this);
        Debug.Log($"{cardName} a été retirée du terrain.");
    }
}
