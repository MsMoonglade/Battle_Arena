using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public UISlider[] HealthBar=new UISlider[4];
	public UISlider[] EnergyBar = new UISlider[4];
	
	private GameObject[] gameObjPlayer;
	private Player[] players = new Player[4];
	
	
	
	void Awake()
	{
		gameObjPlayer = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i< gameObjPlayer.Length; i++) {
			players[i] = gameObjPlayer[i].GetComponent<Player>();
		}
	}
	
	
	
	void Update () 
	{
		HealthBar [0].value = players[0].currentHealth/5;
		HealthBar [1].value = players[1].currentHealth/5;
//		HealthBar [2].value = players[2].currentHealth/5;
//		HealthBar [3].value = players[3].currentHealth/5;
		
		EnergyBar [0].value = players[0].currentEnergy/4;
		EnergyBar [1].value = players[1].currentEnergy/4;
//		EnergyBar [2].value = players[2].currentEnergy/4;
//		EnergyBar [3].value = players[3].currentEnergy/4;
	}
}
