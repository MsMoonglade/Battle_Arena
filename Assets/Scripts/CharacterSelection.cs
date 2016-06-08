using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {


	public GameObject Selector;
	public UIButton[] ModelButton=new UIButton[4];
	public int counter = 0;
	public float[] SelectionTimer = new float[4];

	private float deadZone = 0.15f;

	void Awake()
	{ 
		 
	}

	void Update(){

		Debug.Log(GetAxis(0,"LeftRotationH"));


		if (GetAxis (0, "LeftRotationH") < 0 ) {
			SelectionTimer[0] += Time.deltaTime;
			if (SelectionTimer[0] > deadZone) {
				Debug.Log ("sinistra");
				selectionLeft (0);
			}
		}
			
		else if (GetAxis (0, "LeftRotationH") > 0) {
			SelectionTimer[0] += Time.deltaTime;
			if (SelectionTimer[0] > deadZone) {
				selectionRight (0); 
			}
		}

		if (GetAxis (1, "LeftRotationH") < 0 ) {
			SelectionTimer[1] += Time.deltaTime;
			if (SelectionTimer[1] > deadZone) {
				Debug.Log ("sinistra");
				selectionLeft (1);
			}
		}
		
		else if (GetAxis (1, "LeftRotationH") > 0) {
			SelectionTimer[1] += Time.deltaTime;
			if (SelectionTimer[1] > deadZone) {
				selectionRight (1); 
			}
		}
		






	}
	public void selectionRight(int playerId){


		if (counter < 3) {
			Selector.transform.position = ModelButton [counter + 1].transform.position;
			counter++;
			SelectionTimer[playerId]=0;
		
		} else if (counter == 3) {
			counter = 0; 
			Selector.transform.position = ModelButton [counter].transform.position;
			SelectionTimer[playerId]=0;

		}
	}
	public void selectionLeft(int playerId){
		if (counter != 0) {
			Selector.transform.position = ModelButton [counter - 1].transform.position;
			counter--;
			SelectionTimer[playerId]=0;

		} else if (counter == 0) {
			counter = 3;
			Selector.transform.position = ModelButton [counter].transform.position;
			Debug.Log ("workmnA");
			SelectionTimer[playerId]=0;

		}
	}


	 bool GetButton(int player, string name)
	{
		return Rewired.ReInput.players.GetPlayer(player).GetButton(name);
	}
	
	 bool GetButtonDown(int player, string name)
	{
		return Rewired.ReInput.players.GetPlayer(player).GetButtonDown(name);
	}
	
	 float GetAxis(int player, string name)
	{
		return Rewired.ReInput.players.GetPlayer(player).GetAxis(name);
	}


}
