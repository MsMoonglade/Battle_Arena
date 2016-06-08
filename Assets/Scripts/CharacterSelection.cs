using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {


	public GameObject Selector;
	public UIButton[] ModelButton=new UIButton[4];
	public int counter = 0;
	public float SelectionTimer;

	void Awake()
	{ 
		 
	}

	void Update(){

		Debug.Log(GetAxis(0,"LeftRotationH"));
		SelectionTimer += Time.deltaTime;

		if (GetAxis (0, "LeftRotationH") >0 ) {
			Debug.Log ("dio");
		}
			if (SelectionTimer > 0.5f) {
			selectionRight ();
			Debug.Log ("DESTRAAAA");
		} 
		else if 
		(GetAxis (0, "RightRotationH") < 0) {

			Debug.Log ("jesu");
			if (SelectionTimer > 0.5f) {
				selectionLeft ();
			}
		}





		if (GetAxis (1, "LeftRotationH")>0) 
		{
			Debug.Log ("dio");
			if(SelectionTimer>0.5f){
				selectionLeft ();
				Debug.Log ("?DESTRAAAA");
			}
		} else if (GetAxis (1, "LeftRotationH")<0)
		if(SelectionTimer>0.5f){
			selectionRight ();
		}

		if (GetAxis (2, "LeftRotationH") > 0) {
			if (SelectionTimer > 0.5f) {
				selectionLeft ();
			}
		} else if (GetAxis (2, "LeftRotationH") < 0)
		if (SelectionTimer > 0.5f) {
			selectionRight ();
		}

		if (GetAxis (3, "LeftRotationH")>0) 
		{
			if(SelectionTimer>0.5f){
				selectionRight ();
			}
		} else if (GetAxis (3, "LeftRotationH")<0)
		
		if(SelectionTimer>0.5f){
			selectionLeft ();
		}

	}
	public void selectionRight(){


		if (counter < 3) {
			Selector.transform.position = ModelButton [counter + 1].transform.position;
			counter++;
			SelectionTimer=0;
		
		} else if (counter == 3) {
			counter = 0; 
			Selector.transform.position = ModelButton [counter].transform.position;
			SelectionTimer=0;

		}
	}
	public void selectionLeft(){
		if (counter != 0) {
			Selector.transform.position = ModelButton [counter - 1].transform.position;
			counter--;
			SelectionTimer=0;

		} else if (counter == 0) {
			counter = 3;
			Selector.transform.position = ModelButton [counter].transform.position;
			Debug.Log ("workmnA");
			SelectionTimer=0;

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
