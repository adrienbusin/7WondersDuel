using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WonderCard : MonoBehaviour, IDropHandler
{
    private int _cardValue;
    [SerializeField] private int _cardState;
    private bool _cardPlayed;
    public int wonderPlayer;

    private Sprite _cardFace;
    public WonderEffect _wonderEffect;
    public ZonePlayableManager ZonePlayableManager;
    public GameObject cardConstruction;

    public GameObject CoutPiece;
    public GameObject CoutPieceText;

    private WonderManager _wonderManager;
    private DragDropManager _dragDropManager;
    private CardEffectAge1 _cardEffectAge1;
    private CardGame _cardDrop;


    [SerializeField] private PlayerManager _playerManager;


    private PlayerNameManager _playerNameManager;

    private void Start()
    {
        _wonderManager = GameObject.FindGameObjectWithTag("WonderManager").GetComponent<WonderManager>();
        _dragDropManager = GameObject.FindGameObjectWithTag("DragDropManager").GetComponent<DragDropManager>();


        if (CoutPiece != null)
        {
            CoutPiece.SetActive(false);
            CoutPieceText.SetActive(false);
        }

        if (_cardState == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void getWonderEffect(bool active)
    {
        if (active && !_cardPlayed && _wonderManager.NbMerveilleConstruite < 7)
        {
            CoutPiece.SetActive(true);
            CoutPieceText.SetActive(true);

            int cout = CoutCard();

            CoutPieceText.GetComponent<Text>().text = cout.ToString();
        }
        else
        {
            CoutPiece.SetActive(false);
            CoutPieceText.SetActive(false);
        }
    }

    public int CoutCard()
    {
        Card card = new Card();
        card = _wonderEffect.GetComponent<WonderEffect>().getWonderEffect(cardValue);
        return _playerManager.Player.CoutTotalCarteDrop(card);
    }

    public void OnDrop(PointerEventData eventData)
    {
        _dragDropManager.onDropCardAudio();
        if (!_cardPlayed && _playerManager.Player.PlayerNumber == wonderPlayer &&
            _wonderManager.NbMerveilleConstruite < 7)
        {
            gameObject.GetComponent<Outline>().effectDistance = new Vector2(0, 0);

            ZonePlayableManager.HideShowZonePlayable(false);
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<CardGame>().ItemBeingDragged = null;
                Card wonder = _wonderEffect.getWonderEffect(cardValue);
                CardGame cardGame = eventData.pointerDrag.GetComponent<CardGame>();

                wonder.CardDropNumber = cardGame.CardDropNumber;
                if (_playerManager.Player.AddCarte(wonder))
                {
                    _cardDrop = eventData.pointerDrag.GetComponent<CardGame>();
                    _cardPlayed = true;
                    cardConstruction.GetComponent<Image>().sprite =
                        eventData.pointerDrag.GetComponent<CardGame>().CardBack;
                    cardConstruction.SetActive(true);
                    _wonderManager.NbMerveilleConstruite++;
                    eventData.pointerDrag.GetComponent<CardGame>().SetCardPlayed();
                }
            }
        }
        if (_wonderManager.NbMerveilleConstruite == 7)
        {
            _cardEffectAge1 = GameObject.FindGameObjectWithTag("CardEffectAge1").GetComponent<CardEffectAge1>();
            List<GameObject> wonders = _cardEffectAge1.GetComponent<CardEffectAge1>().Wonders1;
            foreach (GameObject wonder in wonders)
            {
                if (!wonder.GetComponent<WonderCard>()._cardPlayed)
                {
                    wonder.SetActive(false);
                }
            }
        }
    }

    public void SelectMerveille()
    {
        _playerNameManager = GameObject.FindGameObjectWithTag("PlayerNameManager").GetComponent<PlayerNameManager>();

        gameObject.SetActive(false);
        int tourDeJeu = _wonderManager.GetComponent<WonderManager>().getTourDeJeu;
        List<GameObject> cardSelected = _wonderManager.GetComponent<WonderManager>().getCardSelected;
        String player1Name = _playerNameManager.Player1Name;
        String player2Name = _playerNameManager.Player2Name;


        switch (tourDeJeu)
        {
            case 0:
                cardSelected[0].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[0].GetComponent<Image>().sprite = _cardFace;
                cardSelected[0].GetComponent<WonderCard>().setActive(cardSelected[0], true);
                cardSelected[0].GetComponent<WonderCard>().cardValue = cardValue;
                isPlayed = true;
                _wonderManager.TextPlayerNames.text = player2Name + " selectionner 2 merveilles";
                _wonderManager.MerveillesSelected.Add(cardSelected[0].GetComponent<WonderCard>());
                CheckIfSecondTour();
                break;
            case 1:
                cardSelected[4].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[4].GetComponent<Image>().sprite = _cardFace;
                cardSelected[4].GetComponent<WonderCard>().setActive(cardSelected[4], true);
                cardSelected[4].GetComponent<WonderCard>().cardValue = cardValue;
                _wonderManager.TextPlayerNames.text = player2Name + ", encore 1...";
                isPlayed = true;
                _wonderManager.MerveillesSelected.Add(cardSelected[1].GetComponent<WonderCard>());
                CheckIfSecondTour();
                break;
            case 2:
                cardSelected[5].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[5].GetComponent<Image>().sprite = _cardFace;
                cardSelected[5].GetComponent<WonderCard>().setActive(cardSelected[5], true);
                cardSelected[5].GetComponent<WonderCard>().cardValue = cardValue;
                _wonderManager.TextPlayerNames.text = player1Name + " a ton tour !";
                isPlayed = true;
                _wonderManager.MerveillesSelected.Add(cardSelected[2].GetComponent<WonderCard>());
                CheckIfSecondTour();
                break;
            case 3:
                cardSelected[1].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[1].GetComponent<Image>().sprite = _cardFace;
                cardSelected[1].GetComponent<WonderCard>().setActive(cardSelected[1], true);
                cardSelected[1].GetComponent<WonderCard>().cardValue = cardValue;
                _wonderManager.TextPlayerNames.text = player2Name + " selectionne une merveille";
                _wonderManager.MerveillesSelected.Add(cardSelected[3].GetComponent<WonderCard>());
                isPlayed = true;
                CheckIfSecondTour();
                break;
            case 4:
                cardSelected[6].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[6].GetComponent<Image>().sprite = _cardFace;
                cardSelected[6].GetComponent<WonderCard>().setActive(cardSelected[6], true);
                cardSelected[6].GetComponent<WonderCard>().cardValue = cardValue;
                _wonderManager.TextPlayerNames.text = player1Name + " selectionner 2 merveilles";
                isPlayed = true;
                _wonderManager.MerveillesSelected.Add(cardSelected[4].GetComponent<WonderCard>());
                CheckIfEndSelectionMerveille();
                break;
            case 5:
                cardSelected[2].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[2].GetComponent<Image>().sprite = _cardFace;
                cardSelected[2].GetComponent<WonderCard>().setActive(cardSelected[2], true);
                cardSelected[2].GetComponent<WonderCard>().cardValue = cardValue;
                _wonderManager.TextPlayerNames.text = player1Name + ", encore 1...";
                isPlayed = true;
                _wonderManager.MerveillesSelected.Add(cardSelected[5].GetComponent<WonderCard>());
                CheckIfEndSelectionMerveille();
                break;
            case 6:
                cardSelected[3].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[3].GetComponent<Image>().sprite = _cardFace;
                cardSelected[3].GetComponent<WonderCard>().setActive(cardSelected[3], true);
                cardSelected[3].GetComponent<WonderCard>().cardValue = cardValue;
                _wonderManager.TextPlayerNames.text = player2Name + " a ton tour !";
                isPlayed = true;
                _wonderManager.MerveillesSelected.Add(cardSelected[6].GetComponent<WonderCard>());
                CheckIfEndSelectionMerveille();
                break;
            case 7:
                cardSelected[7].GetComponent<WonderCard>()._cardFace = _cardFace;
                cardSelected[7].GetComponent<Image>().sprite = _cardFace;
                cardSelected[7].GetComponent<WonderCard>().setActive(cardSelected[7], true);
                cardSelected[7].GetComponent<WonderCard>().cardValue = cardValue;
                _wonderManager.TextPlayerNames.text = "Que la bataille commence !";
                isPlayed = true;
                _wonderManager.MerveillesSelected.Add(cardSelected[7].GetComponent<WonderCard>());
                CheckIfEndSelectionMerveille();
                break;
        }

        _wonderManager.GetComponent<WonderManager>().getTourDeJeu = tourDeJeu + 1;
    }


    void CheckIfSecondTour()
    {
        List<GameObject> wonders = _wonderManager.GetComponent<WonderManager>().getWonders;
        if (wonders[0].GetComponent<WonderCard>().isPlayed
            && wonders[1].GetComponent<WonderCard>().isPlayed
            && wonders[2].GetComponent<WonderCard>().isPlayed
            && wonders[3].GetComponent<WonderCard>().isPlayed)
        {
            for (int i = 4; i < 8; i++)
            {
                wonders[i].GetComponent<WonderCard>().setActive(wonders[i], true);
            }
        }
    }

    void CheckIfEndSelectionMerveille()
    {
        List<GameObject> wonders = _wonderManager.GetComponent<WonderManager>().getWonders;
        if (wonders[4].GetComponent<WonderCard>().isPlayed
            && wonders[5].GetComponent<WonderCard>().isPlayed
            && wonders[6].GetComponent<WonderCard>().isPlayed
            && wonders[7].GetComponent<WonderCard>().isPlayed)
        {
            _wonderManager.loadScene();
        }
    }


    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public bool isPlayed
    {
        get { return _cardPlayed; }
        set { _cardPlayed = value; }
    }


    public Sprite cardFace
    {
        get { return _cardFace; }
        set { _cardFace = value; }
    }

    public CardGame CardDrop
    {
        get { return _cardDrop; }
        set { _cardDrop = value; }
    }

    public void setActive(GameObject g, bool active)
    {
        g.SetActive(active);
    }
}