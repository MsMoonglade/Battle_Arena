using UnityEngine;
using System.Collections;
using Rewired;

public class CharacterSelection : MonoBehaviour {
	
	//variables
	public GameObject[] icon=new GameObject[5];
	public GameObject[] roboModels=new GameObject[5];

	public GameObject[] Selector=new GameObject[4];


	public int[] counter = new int[4];
    [HideInInspector]
    public Rewired.Controller[] control;
	int[] index = new int[4];
	float delay = 0.1f;
	bool[] ready;
	float[] timer;

	void Awake()
	{
		if (GameObject.FindGameObjectWithTag ("CharacterController") != this.gameObject)
			Destroy (this.gameObject);

       


        DontDestroyOnLoad (this);
		if(Application.loadedLevelName.Equals("CharacterSelection"))
		{
            control = ReInput.controllers.GetControllers(Rewired.ControllerType.Joystick);
            AbilitySelector ();
		ready = new bool[control.Length];
		timer = new float[control.Length];
		for (int i =0; i< timer.Length; i++)
			timer [i] = delay;
		}


	}

	void Start() 
	{


	}

	void Update() 
	{
			if(Application.loadedLevelName.Equals("CharacterSelection"))
			   {

		
				for (int i =0; i< timer.Length; i++)
			
					timer [i] += Time.deltaTime;

		
				StartGame ();
		
				for (int i = 0; i<control.Length; i++) {

		
					if (control [i] != null && GetAxis (i, "LeftRotationH") != 0 && !ready[i] && timer[i]>=delay) 
		
					{
			
						SelectRobot (i, GetAxis (i, "LeftRotationH"));
				
						timer[i] = 0;
			
					}

			
					if(GetButtonDown(i, "SelectA"))
				
						CheckRobot(i);

			
					if(GetButtonDown(i, "DeselectB"))
				
						ready[i] = false;
		
				}
			
			}

	}

	void AbilitySelector()
	{
		for (int i = 0; i<control.Length; i++) {
			Selector[i].transform.position = icon[0].transform.position;
			Selector [i].SetActive(true);
		}
	}

	public void SelectRobot(int sel, float control)
	{
		if (control > 0.5f) {
			if (index [sel] + 1 == icon.Length)
				index [sel] = 0;
			else
				index [sel] += 1;
		}
		else if (control < -0.5f) {
			if (index [sel]  <= 0)
				index [sel] = icon.Length -1;
			else
				index [sel] -= 1;
		}

		Selector [sel].transform.position = icon [index [sel]].transform.position;


	}

	public void CheckRobot(int player)
	{
		counter [player] = index [player];
		ready [player] = true;
	}



	public void StartGame()
	{
		bool go = true;
		for (int i = 0; i < ready.Length; i++) 		
			if(!ready[i])
				go = false;
		if (go)
			Application.LoadLevel ("GameScene");
	
	}

	public void SetTime()
	{
	}

	//rewird part
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
