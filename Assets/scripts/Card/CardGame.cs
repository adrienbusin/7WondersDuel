using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CardGame : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private int _cardState;
    [SerializeField] private bool _cardPlayable;
    public bool _cardPlayed;
    private GameManager _gameManager;
    private PlayerManager _playerManager;
    private ZonePlayableManager _zonePlayableManager;
    private DragDropManager _dragDropManager;
    private DefausseManager _defausseManager;
    private Player _player;
    public int AgeEnCours;
    private static GameObject _itemBeingDragged;
    private Vector3 _startPosition;
    private int _sortingOrderInit;
    private Transform _startParent;
    private GameObject _defausseZone;
    private GameObject _playZoneJoueur1;
    private GameObject _playZoneJoueur2;
    private Vector3 _vector3Original;
    private DefausseCardManager _defausseCardManger;

    public int CardDropNumber { get; set; }

    private void Start()

    {
        _sortingOrderInit = GetComponent<Canvas>().sortingOrder;
        _startPosition = transform.position;
        _playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        _zonePlayableManager =
            GameObject.FindGameObjectWithTag("ZonePlayableManager").GetComponent<ZonePlayableManager>();
        _dragDropManager = GameObject.FindGameObjectWithTag("DragDropManager").GetComponent<DragDropManager>();
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        _defausseCardManger = GameObject.FindGameObjectWithTag("DefausseCardManager").GetComponent<DefausseCardManager>();
       
        if (AgeEnCours == 1)
        {
            CardEffectAge4 = GameObject.FindGameObjectWithTag("CardEffectAge1");
        }
        else if (AgeEnCours == 2)
        {
            CardEffectAge5 = GameObject.FindGameObjectWithTag("CardEffectAge2");
        }
        else
        {
            CardEffectAge6 = GameObject.FindGameObjectWithTag("CardEffectAge3");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _player = _playerManager.Player;
        if (_cardPlayable  && !_player.Defausse 
            && !_player.HasDoubleSymboleSciences 
            && !_defausseCardManger.ShowDefausseOnly 
            && _playerManager.HasSelectPlayerStartAge || Defausse || ToDestroy)
        {
            GameObject.FindGameObjectWithTag("Settings").GetComponent<SettingsManager>().Quit = false;
            _itemBeingDragged = gameObject;
            _vector3Original = _itemBeingDragged.transform.localScale;
            GetComponent<Canvas>().sortingOrder = 10;
            if (!_player.DestroyRessourcePrimaire && !_player.DestroyRessourceSecondaire)
            {
                _zonePlayableManager.ShowZonePlayable(GetCardEffect(false), _playerManager.Player);
            }
            _itemBeingDragged.transform.localScale += new Vector3(1.05f, 1.05f, 1.05f);
            _dragDropManager.onDragCardAudio();
            _itemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            if (_startPosition != transform.position)
            {
                StartCoroutine(StartAnimate());
                transform.localScale = _vector3Original;
                _zonePlayableManager.HideShowZonePlayable(false);
                _cardPlayable = false;
                _dragDropManager.onDropCardAudio();
            }
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            _itemBeingDragged = null;
            transform.position = _startPosition;
        }
    }

    IEnumerator StartAnimate()
    {
        var pointA = transform.position;
        yield return StartCoroutine(MoveObject(transform, pointA, _startPosition, 0.3f));
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        _cardPlayable = true;
        GetComponent<Canvas>().sortingOrder = _sortingOrderInit;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_cardPlayable  && !_player.Defausse 
            && !_player.HasDoubleSymboleSciences 
            && !_defausseCardManger.ShowDefausseOnly && _playerManager.HasSelectPlayerStartAge 
            || Defausse|| ToDestroy)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_cardPlayable  && !_player.Defausse && !_player.HasDoubleSymboleSciences 
            && !_defausseCardManger.ShowDefausseOnly && _playerManager.HasSelectPlayerStartAge 
            || Defausse|| ToDestroy)
        {
            StartCoroutine(StartAnimate());
            transform.localScale = _vector3Original;
            _zonePlayableManager.HideShowZonePlayable(false);
            _cardPlayable = false;
            _dragDropManager.onDropCardAudio();
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            _itemBeingDragged = null;
        }
        
    }


    public GameObject ItemBeingDragged
    {
        get { return _itemBeingDragged; }
        set { _itemBeingDragged = value; }
    }

    public void SelectCard()
    {
        if (_cardPlayable)
        {
            GetCardEffect(true);
        }
    }

    private bool CheckIfEndAge()
    {
        switch (AgeEnCours)
        {
            case 1:
                return _gameManager.CheckIfEndAge1();
            case 2:
               return  _gameManager.CheckIfEndAge2();
            case 3:
                return _gameManager.CheckIfEndAge3();
        }
        return false;
    }

    private bool CheckIfStartAge()
    {
        switch (GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().AgeEnCours1)
        {
            case 2:
                return  GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().CheckIfStartAge2();
            case 3:
                return GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().CheckIfStartAge3();
        }
        return false;
    }

    public void SetCardPlayed()
    {
        if (Defausse)
        {
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(true, true);
            _defausseManager = GameObject.FindGameObjectWithTag("DefausseManager").GetComponent<DefausseManager>();
            foreach (var card in _defausseCardManger.DefausseCards)
            {
                if (card.GetComponent<CardGame>().CardValue == gameObject.GetComponent<CardGame>().CardValue)
                {
                    _defausseCardManger.DefausseCards.Remove(card);
                    _defausseCardManger.NbCarteDefausseText();
                    break;
                }
            }
            
            GameObject.FindGameObjectWithTag("DefausseScreen").SetActive(false);
            _defausseManager.HideAllGameObject();
            _player.Defausse = false;
            
            if (CheckIfStartAge())
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().NextPlayerEndAge();
                SceneManager.LoadScene("SelectionAvatar"); 
            }
        }

        if (ToDestroy)
        {
            if (!CheckIfStartAge())
            {
                GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                    .hideShowAllCards(true, true); 
            }
            GameObject.FindGameObjectWithTag("DestroyScreen").SetActive(false);
            GameObject.FindGameObjectWithTag("DestroyRessourceManager").GetComponent<DestroyRessourceManager>().HideAllGameObject();
            _player.DestroyRessourcePrimaire = false;
            _player.DestroyRessourceSecondaire = false;
            if (!_player.BonusMerveilleReplayToken)
            {
                _player.IsPlaying = false;
                _player.PlayerAdverse.IsPlaying = true;
            }
           
        }
        _player.SetText();
        _cardPlayed = true;
        gameObject.SetActive(false);
        _player = _playerManager.Player;
        if (!CheckIfEndAge() && !_player.IsPlaying)
        {
            _playerManager.nextPlayer(_player.PlayerNumber);
        }
        switch (AgeEnCours)
        {
            case 1:
                _gameManager.CheckIsPlayable(AgeEnCours, CardEffectAge4);
                break;
            case 2:
                _gameManager.CheckIsPlayable(AgeEnCours, CardEffectAge5);

                break;
            case 3:
                _gameManager.CheckIsPlayable(AgeEnCours, CardEffectAge6);
                break;
        }
    }

    int GetCardEffect(bool addCard)
    {
        Card card = new Card();

        switch (AgeEnCours)
        {
            case 1:
                card = CardEffectAge4.GetComponent<CardEffectAge1>().getCardEffectAge(CardValue);
                break;
            case 2:
                card = CardEffectAge5.GetComponent<CardEffectAge2>().getCardEffectAge(CardValue);
                break;
            case 3:
                if (!Guilde)
                {
                    card = CardEffectAge3.getCardEffectAge(CardValue);
                }
                else
                {
                    card = CardEffectAge3.GetCardEffectAgeGuilde(CardValue);
                }
                break;
        }
        card.Defausse = Defausse;
        card.Number = CardValue;
        card.CardGame = gameObject;
        if (addCard)
        {
            if (_playerManager.Player.AddCarte(card))
            {
                SetCardPlayed();
            }
            return 0;
        }
        return _playerManager.Player.CoutTotalCarteDrop(card);
    }

    public Card GetCardEffect()
    {
        Card card = new Card();

        switch (AgeEnCours)
        {
            case 1:
                card = CardEffectAge4.GetComponent<CardEffectAge1>().getCardEffectAge(CardValue);
                break;
            case 2:
                card = CardEffectAge5.GetComponent<CardEffectAge2>().getCardEffectAge(CardValue);
                break;
            case 3:
                if (!Guilde)
                {
                    card = CardEffectAge3.getCardEffectAge(CardValue);
                }
                else
                {
                    card = CardEffectAge3.GetCardEffectAgeGuilde(CardValue);
                }
                break;
        }
        card.Defausse = Defausse;
        card.ToDestroy = ToDestroy;
        return card;
    }


    public int CardValue { get; set; }

    public bool CardPlayed
    {
        get { return _cardPlayed; }
        set { _cardPlayed = value; }
    }

    public bool CardPlayable
    {
        get { return _cardPlayable; }
        set { _cardPlayable = value; }
    }

    public Sprite CardFace { get; set; }

    public Sprite CardBack { get; set; }

    public int CardState
    {
        get { return _cardState; }
        set { _cardState = value; }
    }

    public bool Guilde { get; set; }

    public GameObject CardEffectAge4 { get; set; }

    public GameObject CardEffectAge5 { get; set; }

    public GameObject CardEffectAge6 { get; set; }

    public int AgeEnCours1
    {
        get { return AgeEnCours; }
        set { AgeEnCours = value; }
    }

    public bool Defausse { get; set; }
    public bool ToDestroy { get; set; }
}