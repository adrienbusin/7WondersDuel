using UnityEngine;

public class HideShowAllCards : MonoBehaviour
{
    private GameObject CardListGameObject;
    public int ageEnCours;

    // Use this for initialization
    public void hideShowAllCards(bool active, bool interactable)
    {
        CardListGameObject = GameObject.FindGameObjectWithTag("cardAge" + ageEnCours);
        if (CardListGameObject != null)
        {
            if (interactable)
            {
                CardListGameObject.GetComponent<CanvasGroup>().interactable = active;
                CardListGameObject.GetComponent<CanvasGroup>().blocksRaycasts = active;
            }
            else
            {
                CardListGameObject.SetActive(active);
            }
        }
        
    }
}