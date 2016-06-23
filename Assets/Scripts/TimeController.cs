using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	public UILabel TimerText;

	public float Timer;


void Update(){

		TimerText.text ="Timer: "+Timer.ToString ()+" Minutes";

		if (GetButtonDown (0, "ArrowUp")){
			Timer+=1f;	
		}
		if (GetButtonDown (0, "ArrowDown")) {
			Timer-=1f;		
			if (Timer < 1) {
				Timer=1;
			}
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
