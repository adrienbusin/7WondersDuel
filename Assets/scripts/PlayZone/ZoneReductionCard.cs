using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoneReductionCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CardGame _itemBeingDragged;
    private Vector3 _vector3Original;
    public int ZoneJoueur;
    private PlayerManager _playerManager;
    private WonderManager _wonderManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        _wonderManager = GameObject.FindGameObjectWithTag("WonderManager").GetComponent<WonderManager>();
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<CardGame>().CardPlayable)
        {
            _itemBeingDragged = eventData.pointerDrag.GetComponent<CardGame>();
            if (_playerManager.Player.PlayerNumber == ZoneJoueur || ZoneJoueur == 2)
            {
                _vector3Original = _itemBeingDragged.transform.localScale;
                _itemBeingDragged.transform.localScale -= new Vector3(1.5f, 1.5f, 1.5f);
                if (gameObject.GetComponent<Outline>() != null)
                {
                    gameObject.GetComponent<Outline>().effectDistance = new Vector2(-5, -5);
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<CardGame>().CardPlayable)
        {
            _wonderManager = GameObject.FindGameObjectWithTag("WonderManager").GetComponent<WonderManager>();

            if (_playerManager.Player.PlayerNumber == ZoneJoueur || ZoneJoueur == 2)
            {
                _itemBeingDragged = eventData.pointerDrag.GetComponent<CardGame>();
                _itemBeingDragged.transform.localScale = _vector3Original;
                if (gameObject.GetComponent<Outline>() != null)
                {
                    gameObject.GetComponent<Outline>().effectDistance = new Vector2(0, 0);
                }
            }
        }
    }
}