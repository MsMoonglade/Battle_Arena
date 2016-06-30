using UnityEngine;
using System.Collections;
using Rewired;

public class CharacterSelection : MonoBehaviour {
	
	//variables
	public GameObject[] icon=new GameObject[5];

	public GameObject[] roboModels=new GameObject[5];
	public GameObject[] roboModelsOne=new GameObject[5];
	public GameObject[] roboModelsTwo=new GameObject[5];
	public GameObject[] roboModelsThree=new GameObject[5];


	public GameObject[] Selector=new GameObject[4];
	public int rotationSpeed;

	public int[] counter = new int[4];
	[HideInInspector]
	public Rewired.Controller[] control;
	int[] index = new int[4];
	float delay = 0.1f;
	bool[] ready;
	float[] timer;
	public int[] modelIndex=new int[4];

	void Awake()
	{

		if (GameObject.FindGameObjectWithTag ("CharacterController") != this.gameObject)
			Destroy (this.gameObject);

		DontDestroyOnLoad (this);
		if(Application.loadedLevelName.Equals("CharacterSelection"))
		{


		control = Rewired.ReInput.controllers.GetControllers(Rewired.ControllerType.Joystick);
//		AbilitySelector ();
		ready = new bool[control.Length];
		timer = new float[control.Length];
		for (int i =0; i< timer.Length; i++)
			timer [i] = delay;
		}else
			control = Rewired.ReInput.controllers.GetControllers(Rewired.ControllerType.Joystick);


	}

	void Start() 
	{
		
	}

	void Update() 
	{


			if(Application.loadedLevelName.Equals("CharacterSelection"))
			   {
					RotateRobot ();

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
			if (index [sel] + 1 == icon.Length) {
				index [sel] = 0;
					if (sel == 0) {
						roboModels [modelIndex[0]].SetActive (false);
						roboModels [0].SetActive (true);
						modelIndex [0] = 0;
					}
					if (sel == 1) {
					roboModelsOne [modelIndex[1]].SetActive (false);
					roboModelsOne [0].SetActive (true);
					modelIndex [1] = 0;
				}
				if (sel == 2) {
					roboModelsTwo [modelIndex[2]].SetActive (false);
					roboModelsTwo [0].SetActive (true);
					modelIndex [2] = 0;
				}
				if (sel == 3) {
					roboModelsThree [modelIndex[3]].SetActive (false);
					roboModelsThree [0].SetActive (true);
					modelIndex [3] = 0;
				}

			} else {
				index [sel] += 1;
					if (sel == 0) {
						roboModels [modelIndex[0]].SetActive (false);
						roboModels [modelIndex [0] + 1].SetActive (true);
						modelIndex[0] += 1;
					}
				if (sel == 1) {
					roboModelsOne [modelIndex[1]].SetActive (false);
					roboModelsOne [modelIndex [1] + 1].SetActive (true);
					modelIndex[1] += 1;

				}
				if (sel == 2) {
					roboModelsTwo [modelIndex[2]].SetActive (false);
					roboModelsTwo [modelIndex [2] + 1].SetActive (true);
					modelIndex[2] += 1;

				}
				if (sel == 3) {
					roboModelsThree [modelIndex[3]].SetActive (false);
					roboModelsThree [modelIndex [3] + 1].SetActive (true);
					modelIndex[3] += 1;

				}

			}
		} else if (control < -0.5f) {
			if (index [sel] <= 0) {
					if (sel == 0) {
					index [sel] = icon.Length - 1;			
					roboModels [modelIndex[0]].SetActive (false);
					roboModels [modelIndex[0]+modelIndex.Length].SetActive (true);
					modelIndex [0] =modelIndex.Length;
					}
				if (sel == 1) {
					index [sel] = icon.Length - 1;			
					roboModelsOne [modelIndex[1]].SetActive (false);
					roboModelsOne [modelIndex[1]+modelIndex.Length].SetActive (true);
					modelIndex [1] =modelIndex.Length;
				}
				if (sel == 2) {
					index [sel] = icon.Length - 1;			
					roboModelsTwo [modelIndex[2]].SetActive (false);
					roboModelsTwo [modelIndex[2]+modelIndex.Length].SetActive (true);
					modelIndex [2] =modelIndex.Length;
				}
				if (sel == 3) {
					index [sel] = icon.Length - 1;			
					roboModelsThree [modelIndex[3]].SetActive (false);
					roboModelsThree [modelIndex[3]+modelIndex.Length].SetActive (true);
					modelIndex [3] =modelIndex.Length;
				}

			} else{
			index [sel] -= 1;
				if (sel == 0) {
					roboModels [modelIndex [0]].SetActive (false);
					roboModels [modelIndex [0] - 1].SetActive (true);
					modelIndex [0] -= 1;
				}
				if (sel == 1) {
					roboModelsOne [modelIndex [1]].SetActive (false);
					roboModelsOne [modelIndex [1] - 1].SetActive (true);
					modelIndex [1] -= 1;
				}
				if (sel == 2) {
					roboModelsTwo [modelIndex [2]].SetActive (false);
					roboModelsTwo [modelIndex [2] - 1].SetActive (true);
					modelIndex [2] -= 1;
				}
				if (sel == 3) {
					roboModelsThree [modelIndex [3]].SetActive (false);
					roboModelsThree [modelIndex [3] - 1].SetActive (true);
					modelIndex [3] -= 1;
				}
			
					}
				}

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
	public void RotateRobot(){
		for (int i = 0; i < control.Length; i++) {

			for(int j=0;j<roboModels.Length;j++){

			if (GetAxis (0, "RightRotationH") > 0)
			{
					roboModels [j].transform.GetChild(1).Rotate (-Vector3.up * Time.deltaTime * rotationSpeed);
			}
			if (GetAxis (1, "RightRotationH") > 0)
			{
					roboModelsOne [j].transform.GetChild(1).Rotate (-Vector3.up * Time.deltaTime * rotationSpeed);
			}
			if (GetAxis (2, "RightRotationH") > 0)
			{
					roboModelsTwo [j].transform.GetChild(1).Rotate (-Vector3.up * Time.deltaTime * rotationSpeed);
			}
			if (GetAxis (3, "RightRotationH") > 0)
			{
					roboModelsThree [j].transform.GetChild(1).Rotate (-Vector3.up * Time.deltaTime * rotationSpeed);
			}

			if (GetAxis (0, "RightRotationH") < 0)
			{
					roboModels [j].transform.GetChild(1).Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
			}
			if (GetAxis (1, "RightRotationH") < 0)
			{
					roboModelsOne [j].transform.GetChild(1).Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
			}
			if (GetAxis (2, "RightRotationH") < 0)
			{
					roboModelsTwo [j].transform.GetChild(1).Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
			}
			if (GetAxis (3, "RightRotationH") < 0)
			{
					roboModelsThree [j].transform.GetChild(1).Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
			}
		}
	}
	}


	//rewired part
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
