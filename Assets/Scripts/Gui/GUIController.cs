using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public UISlider[] HealthBar=new UISlider[4];
	public UISlider[] EnergyBar = new UISlider[4];
	
	private Player[] players;
	
	
	
	void Awake()
	{
		players = new Player[4];
		AssignPlayers ();

	}

	private void AssignPlayers()
	{
		players [0] = GameObject.Find ("Player1").GetComponent<Player> ();
		players [1] = GameObject.Find ("Player2").GetComponent<Player> ();
		players [2] = GameObject.Find ("Player3").GetComponent<Player> ();
		players [3] = GameObject.Find ("Player4").GetComponent<Player> ();
	}
	
	void Update () 
	{
		HealthBar[0].value = players[0].currentHealth/players[0].MaxHealth;
		HealthBar[1].value = players[1].currentHealth/players[1].MaxHealth;
		HealthBar[2].value = players[2].currentHealth/players[2].MaxHealth;
		HealthBar[3].value = players[3].currentHealth/players[3].MaxHealth;
		
		EnergyBar[0].value = players[0].currentEnergy/players[0].MaxEnergy;
		EnergyBar[1].value = players[1].currentEnergy/players[1].MaxEnergy;
		EnergyBar[2].value = players[2].currentEnergy/players[2].MaxEnergy;	
		EnergyBar[3].value = players[3].currentEnergy/players[3].MaxEnergy;
	}



}
