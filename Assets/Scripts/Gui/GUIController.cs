using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public UISlider[] HealthBar=new UISlider[4];
	public UISlider[] StaminaBar = new UISlider[4];
	
	private GameObject[] gameObjPlayer;
	private Player[] players = new Player[4];



	void Awake(){
		gameObjPlayer = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i< gameObjPlayer.Length; i++) {
			players[i] = gameObjPlayer[i].GetComponent<Player>();

		}
//		StaminaBar [0].value = 0.7f;
//		StaminaBar [1].value = 0.7f;
//		StaminaBar [2].value = 0.7f;
//		StaminaBar [3].value = 0.7f;
	}



	void Update () {

		HealthBar [0].value = players[0].currentHealth/5;
		HealthBar [1].value = players[1].currentHealth/5;
//		HealthBar [1].value =0.2f;
//		HealthBar [2].value =0.2f;
//		HealthBar [3].value =0.2f; 


		RechargeStamina ();
		RechargeSpecial ();


	}

	void RechargeStamina()
	{
//		if (StaminaBar [0].value != 1f)
//			StaminaBar [0].value += staminaRecharge * Time.deltaTime;
//		if (StaminaBar [1].value != 1f) 
//			StaminaBar [1].value += staminaRecharge * Time.deltaTime;
//		if (StaminaBar [2].value != 1f)
//			StaminaBar [2].value += staminaRecharge * Time.deltaTime;
//		if (StaminaBar [3].value != 1f)
//			StaminaBar [3].value += staminaRecharge * Time.deltaTime;
	}

	void RechargeSpecial()
	{
		//specialBar value like stamina 
	}
}
