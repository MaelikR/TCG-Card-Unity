using UnityEngine;

public class RelicCard : Card  // H�rite de Card
{
    public RelicCard(int id, string name, string desc, int attack, int defense, int mana)
        : base(id, name, desc, attack, defense, mana)  // Appel du constructeur de la classe parente Card
    {
    }

    public string cardName = "Relique";
    public string description = "Une relique ancienne avec un pouvoir myst�rieux.";
    public int manaCost = 3;

    public void PlayRelic(GameBoard gameBoard, bool isPlayer)
    {
        // Appeler la m�thode PlaceCard avec l'objet RelicCard qui est maintenant une Card
        gameBoard.PlaceCard(this, isPlayer);

        // Effet sp�cifique de la relique peut �tre appliqu� ici
        Debug.Log($"{cardName} a �t� plac�e sur le terrain.");
    }

    public void RemoveRelic(GameBoard gameBoard)
    {
        // Retirer la carte relique du terrain
        gameBoard.playerField.Remove(this);
        Debug.Log($"{cardName} a �t� retir�e du terrain.");
    }
}
