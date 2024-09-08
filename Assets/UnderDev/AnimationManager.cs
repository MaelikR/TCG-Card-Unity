using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator cardAnimator; // R�f�rence � l'Animator pour les cartes
    public Transform playerField; // Position des cartes du joueur
    public Transform deckPosition; // Position du deck pour les animations de pioche

    // Animation lors de l'entr�e d'une carte sur le terrain
    public void AnimateCardEntry(GameObject card, bool isPlayer)
    {
        card.transform.SetParent(isPlayer ? playerField : null);
        cardAnimator = card.GetComponent<Animator>();
        cardAnimator.SetTrigger("EnterField"); // Assure-toi qu'un Trigger "EnterField" existe dans l'Animator
    }

    // Animation d'attaque d'une carte
    public void AnimateCardAttack(GameObject attacker, GameObject target)
    {
        attacker.GetComponent<Animator>().SetTrigger("Attack");
        StartCoroutine(ShakeCard(target));  // Effet de secousse sur la carte cible
    }

    // Animation de destruction d'une carte
    public void AnimateCardDestruction(GameObject card)
    {
        cardAnimator = card.GetComponent<Animator>();
        cardAnimator.SetTrigger("Destroy");
        StartCoroutine(DestroyAfterAnimation(card, 1.0f)); // D�lai avant de supprimer l'objet apr�s l'animation
    }

    // Animation pour la pioche de carte
    public void AnimateDrawCard(GameObject card)
    {
        card.transform.position = deckPosition.position; // La carte d�marre depuis la position du deck
        card.GetComponent<Animator>().SetTrigger("Draw");
    }

    // Animation pour les cartes en main (par exemple, hover ou glow)
    public void AnimateCardInHand(GameObject card)
    {
        cardAnimator = card.GetComponent<Animator>();
        cardAnimator.SetTrigger("Hover"); // Utiliser un Trigger pour l'animation de hover
    }

    // Animation de d�but de tour (glow autour des cartes jouables)
    public void AnimateStartOfTurn(GameObject[] handCards)
    {
        foreach (GameObject card in handCards)
        {
            card.GetComponent<Animator>().SetTrigger("StartTurn");
        }
    }

    // Animation de fin de tour (d�sactiver les cartes jouables)
    public void AnimateEndOfTurn(GameObject[] handCards)
    {
        foreach (GameObject card in handCards)
        {
            card.GetComponent<Animator>().SetTrigger("EndTurn");
        }
    }

    // Animation helper functions

    // D�truire la carte apr�s l'animation
    private IEnumerator DestroyAfterAnimation(GameObject card, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(card);
    }

    // Effet de secousse pour simuler un impact
    private IEnumerator ShakeCard(GameObject card)
    {
        Vector3 originalPosition = card.transform.position;
        float elapsedTime = 0f;
        float duration = 0.3f; // Dur�e de la secousse

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.1f, 0.1f);
            float yOffset = Random.Range(-0.1f, 0.1f);
            card.transform.position = new Vector3(originalPosition.x + xOffset, originalPosition.y + yOffset, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        card.transform.position = originalPosition; // Remet la carte � sa position initiale
    }
}
