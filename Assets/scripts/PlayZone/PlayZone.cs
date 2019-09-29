using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private ZonePlayableManager _zonePlayableManager;
    private DragDropManager _dragDropManager;


    private void Start()
    {
        _zonePlayableManager =
            GameObject.FindGameObjectWithTag("ZonePlayableManager").GetComponent<ZonePlayableManager>();
        _dragDropManager = GameObject.FindGameObjectWithTag("DragDropManager").GetComponent<DragDropManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        _dragDropManager.onDropCardAudio();

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<CardGame>().SelectCard();
        }

        _zonePlayableManager.GetComponent<ZonePlayableManager>().HideShowZonePlayable(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 80);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
    }
}