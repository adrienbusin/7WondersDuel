using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DefausseArgentManager : MonoBehaviour, IDropHandler
{
    public PlayerManager _playerManager;
    public ZonePlayableManager _zonePlayableManager;
    private DragDropManager _dragDropManager;
    private DefausseCardManager _defausseCardManager;

    public void OnDrop(PointerEventData eventData)
    {
        _dragDropManager = GameObject.FindGameObjectWithTag("DragDropManager").GetComponent<DragDropManager>();
        _defausseCardManager =
            GameObject.FindGameObjectWithTag("DefausseCardManager").GetComponent<DefausseCardManager>();

        if (eventData.pointerDrag != null && !eventData.pointerDrag.GetComponent<CardGame>().Defausse && eventData.pointerDrag.GetComponent<CardGame>().CardPlayable && !eventData.pointerDrag.GetComponent<CardGame>().ToDestroy)
        {
            _playerManager.Player.Argent += 2 + _playerManager.Player.NbCarteJaune;

            _playerManager.Player.SetText();
            _dragDropManager.onDropCardAudio();
            _defausseCardManager.DefausseCards.Add(eventData.pointerDrag);
            _defausseCardManager.NbCarteDefausseText();
            _playerManager.Player.IsPlaying = false;
            _playerManager.Player.PlayerAdverse.IsPlaying = true;
            eventData.pointerDrag.GetComponent<CardGame>().SetCardPlayed();
            GameObject.Find("DefausseAudio").GetComponent<AudioSource>().Play();
            _zonePlayableManager.GetComponent<ZonePlayableManager>().HideShowZonePlayable(false);
        }
        
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<CardGame>().ToDestroy)
        {
            if (_playerManager.Player.DestroyRessourcePrimaire)
            {
                _playerManager.Player.PlayerAdverse.Argile -=
                    eventData.pointerDrag.GetComponent<CardGame>().GetCardEffect().BonusArgile;
                _playerManager.Player.PlayerAdverse.Bois -=
                    eventData.pointerDrag.GetComponent<CardGame>().GetCardEffect().BonusBois;
                _playerManager.Player.PlayerAdverse.Pierre -=
                    eventData.pointerDrag.GetComponent<CardGame>().GetCardEffect().BonusPierre;
            }
            if (_playerManager.Player.DestroyRessourceSecondaire)
            {
                _playerManager.Player.PlayerAdverse.Verre -=
                    eventData.pointerDrag.GetComponent<CardGame>().GetCardEffect().BonusVerre;
                _playerManager.Player.PlayerAdverse.Papyrus -=
                    eventData.pointerDrag.GetComponent<CardGame>().GetCardEffect().BonusPapyrus;
            
            }
            _defausseCardManager.DefausseCards.Add(eventData.pointerDrag);
            _dragDropManager.onDropCardAudio();
            _defausseCardManager.NbCarteDefausseText();
            _playerManager.Player.PlayerAdverse.SetText();
            eventData.pointerDrag.GetComponent<CardGame>().SetCardPlayed();
           
            if (CheckIfStartAge())
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().NextPlayerEndAge();
                SceneManager.LoadScene("SelectionAvatar"); 
            }
        }
    }
    
    public bool CheckIfStartAge()
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

    public void ShowDefausse()
    {
        _defausseCardManager =
            GameObject.FindGameObjectWithTag("DefausseCardManager").GetComponent<DefausseCardManager>();
        
        if (_defausseCardManager.DefausseCards.Count > 0 && 
            !_playerManager.Player.Defausse && 
            !_playerManager.Player.HasDoubleSymboleSciences &&
            _playerManager.HasSelectPlayerStartAge && 
            !_playerManager.Player.DestroyRessourcePrimaire && 
            !_playerManager.Player.DestroyRessourceSecondaire)
        {
            _defausseCardManager.ShowDefausseOnly = true;
            SceneManager.LoadScene("Defausse");
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(false, true);
        }
    }

}