using UnityEngine;
using System.Collections;

public class PlayerPowerUpGui : MonoBehaviour {
	
	public GameObject[] icon;

	//private GameObject playerGO;
	//private GameObject allplayer;
	private Player player;

	void Awake()
	{
		icon = new GameObject[transform.childCount];

		for (int i = 0; i < icon.Length; i ++) 
		{
			icon[i] = gameObject.transform.GetChild(i).gameObject;
			icon[i].SetActive (false);
		}

		//allplayer = GameObject.Find;
		//playerGO = GameObject.Find (transform.name);
		//player = playerGO.GetComponent<Player> ();
	}

	public void Change(string name , float timer)
	{
		for (int i = 0; i < icon.Length; i ++) 
		{ 
			if(icon[i].name == name)
			{			
				icon[i].SetActive(true);
				break;
			}
		    else 
				icon[i].SetActive(false);
		}

		StartCoroutine ("ResetIcon", timer);
	}

	private IEnumerator ResetIcon(float time)
	{
		yield return new WaitForSeconds (time);

		for (int i = 0; i < icon.Length; i ++) 
		{ 
	     	icon[i].SetActive(false);
		}
	}
}
