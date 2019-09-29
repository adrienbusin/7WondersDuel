using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RessourcesManager : MonoBehaviour, IPointerDownHandler
{
    private PlayerManager _playerManager;
    public String ressourceName;
    private bool destroyDone;

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        if (_playerManager.Player.DestroyRessourcePrimaire)
        {
            switch (ressourceName)
            {
                case "bois":
                    if (_playerManager.Player.PlayerAdverse.Bois > 0)
                    {
                        _playerManager.Player.PlayerAdverse.Bois += -1;
                        destroyDone = true;
                        _playerManager.Player.DestroyRessourcePrimaire = false;
                    }
                    break;
                case "pierre":
                    if (_playerManager.Player.PlayerAdverse.Pierre > 0)
                    {
                        _playerManager.Player.PlayerAdverse.Pierre += -1;
                        _playerManager.Player.DestroyRessourcePrimaire = false;
                        destroyDone = true;
                    }
                    break;
                case "argile":
                    if (_playerManager.Player.PlayerAdverse.Argile > 0)
                    {
                        _playerManager.Player.PlayerAdverse.Argile += -1;
                        _playerManager.Player.DestroyRessourcePrimaire = false;
                        destroyDone = true;
                    }
                    break;
            }
            if (_playerManager.Player.PlayerAdverse.Bois > 0 && _playerManager.Player.PlayerAdverse.Pierre > 0 &&
                _playerManager.Player.PlayerAdverse.Argile > 0)
            {
                destroyDone = true;
            }
        }

        if (_playerManager.Player.DestroyRessourceSecondaire)
        {
            switch (ressourceName)
            {
                case "papyrus":
                    if (_playerManager.Player.PlayerAdverse.Papyrus > 0)
                    {
                        _playerManager.Player.PlayerAdverse.Papyrus += -1;
                        destroyDone = true;
                        _playerManager.Player.DestroyRessourceSecondaire = false;
                    }
                    break;
                case "verre":
                    if (_playerManager.Player.PlayerAdverse.Verre > 0)
                    {
                        _playerManager.Player.PlayerAdverse.Verre += -1;
                        destroyDone = true;
                        _playerManager.Player.DestroyRessourceSecondaire = false;
                    }
                    break;
            }
            if (_playerManager.Player.PlayerAdverse.Verre == 0 && _playerManager.Player.PlayerAdverse.Papyrus == 0)
            {
                destroyDone = true;
            }
        }

        if (destroyDone)
        {
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(true, true);

            _playerManager.Player.PlayerAdverse.SetText();
            if (!_playerManager.Player.BonusMerveilleReplayToken)
            {
                _playerManager.Player.IsPlaying = false;
                _playerManager.Player.PlayerAdverse.IsPlaying = true;

                if (!_playerManager.Player.IsPlaying)
                {
                    _playerManager.nextPlayer(_playerManager.Player.PlayerNumber);
                }
            }
            
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
}

