using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AvatarSelection : MonoBehaviour, IPointerClickHandler
{

	public GameObject avatar1;
	public GameObject avatar2;
	public GameObject avatar1Txt;
	public GameObject avatar2Txt;
	public GameObject playerTxt;
	private PlayerManager PlayerManager;


	private void Start()
	{
		PlayerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
		avatar1Txt.GetComponent<Text>().text = PlayerManager.Player1.PlayerName;
		avatar2Txt.GetComponent<Text>().text = PlayerManager.Player2.PlayerName;
		playerTxt.GetComponent<Text>().text = PlayerManager.Player.PlayerName + " selectionne qui commence a jouer cet age !";
		
		avatar1.SetActive(true);
		avatar2.SetActive(true);
		avatar1Txt.SetActive(true);
		avatar2Txt.SetActive(true);
		playerTxt.SetActive(true);
	}

	public void OnPointerClick(PointerEventData eventData)
	{

		PlayerManager.HasSelectPlayerStartAge = true;
		if (gameObject == avatar1)
		{
			PlayerManager.Player1.IsPlaying = true;
			PlayerManager.Player2.IsPlaying = false;
			PlayerManager.nextPlayer(1);
		}
		else
		{
			PlayerManager.Player1.IsPlaying = false;
			PlayerManager.Player2.IsPlaying = true;
			PlayerManager.nextPlayer(0);
		}
		
		avatar1Txt.SetActive(false);
		avatar2Txt.SetActive(false);
		playerTxt.SetActive(false);
		
		GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
			.hideShowAllCards(true, true);
		
		avatar1.SetActive(false);
		avatar2.SetActive(false);
	}
}
