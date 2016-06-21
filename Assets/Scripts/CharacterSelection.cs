using UnityEngine;
using System.Collections;
using Rewired;

public class CharacterSelection : MonoBehaviour {
	
	
	public GameObject[] CursorSelect=new GameObject[4];
	public UIButton[] ModelButton=new UIButton[4];
	public int[] counter = new int[4];    
	public float[] SelectionTimer = new float[4];
	public bool[] PlayerIsSelected = new bool[4];
	public int PlayersInGame;

	public UISprite[] PlayerModelSprite = new UISprite[4];
	public string[] ModelsSprite = new string[4];


	private float deadZone = 0.15f;


	private Player player;

	void Awake() {
//		fosr (int i =0; i<CursorSelect.Length; i++) {
//			CursorSelect[i].transform.position=ModelButton[0].transform.position;
//		}
		DontDestroyOnLoad (this);
	}

	void Update(){

		if(!Application.loadedLevelName.Equals("GameScene")){


            if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel("GameScene");

            }
		
			if(GetButtonDown(0,"StartButton")){
				Debug.Log("ciao");
				CursorSelect[0].SetActive(true);
			}


			if(GetButtonDown(0,"SelectA")){
				PlayerIsSelected[0]=true;
			}
			if(GetButtonDown(1,"SelectA")){
				PlayerIsSelected[1]=true;
			}
			if(GetButtonDown(2,"SelectA")){
				PlayerIsSelected[2]=true;
			}
			if(GetButtonDown(3,"SelectA")){
				PlayerIsSelected[3]=true;
			}


			if(GetButtonDown(0,"DeselectB")){
				PlayerIsSelected[0]=false;
			}
			if(GetButtonDown(1,"DeselectB")){
				PlayerIsSelected[1]=false;
			}
			if(GetButtonDown(2,"DeselectB")){
				PlayerIsSelected[2]=false;
			}
			if(GetButtonDown(3,"DeselectB")){
				PlayerIsSelected[3]=false;
			}

	
		
		
		
		
		if (GetAxis (0, "LeftRotationH") < 0 ) {
			SelectionTimer[0] += Time.deltaTime;
			if (SelectionTimer[0] > deadZone) {
				selectionLeft (0);
			}
		}
		
		else if (GetAxis (0, "LeftRotationH") > 0) {
			SelectionTimer[0] += Time.deltaTime;
			if (SelectionTimer[0] > deadZone) {
				selectionRight (0); 
			}
		}

            if (GetAxis(1, "LeftRotationH") < 0)
            {
                SelectionTimer[1] += Time.deltaTime;
                if (SelectionTimer[1] > deadZone)
                {
                    Debug.Log("sinistra");
                    selectionLeft(1);
                }
            }

            else if (GetAxis(1, "LeftRotationH") > 0)
            {
                SelectionTimer[1] += Time.deltaTime;
                if (SelectionTimer[1] > deadZone)
                {
                    selectionRight(1);
                }
            }
		}
		
		
		
		
		
		
		
	}
	public void selectionRight(int playerId){
		if(PlayerIsSelected[playerId]!=true){
		
		if (counter[playerId] < 3) {
			CursorSelect[playerId].transform.position = ModelButton[counter[playerId] + 1].transform.position;
			counter[playerId]++;
			SelectionTimer[playerId]=0;
			PlayerModelSprite[playerId].spriteName=ModelsSprite[counter[playerId]];
			
		} else if (counter[playerId] == 3) {
			counter[playerId] = 0; 
			CursorSelect[playerId].transform.position = ModelButton [counter[playerId]].transform.position;
			SelectionTimer[playerId]=0;
			PlayerModelSprite[playerId].spriteName=ModelsSprite[counter[0]];
			}
		}
	}
	public void selectionLeft(int playerId){

		if(PlayerIsSelected[playerId]!=true){
		if (counter[playerId] != 0) {
			CursorSelect[playerId].transform.position = ModelButton [counter[playerId] - 1].transform.position;
			counter[playerId]--;
			SelectionTimer[playerId]=0;
			PlayerModelSprite[playerId].spriteName=ModelsSprite[counter[playerId]];
			
			
		} 
			else if (counter[playerId] == 0) {
			counter[playerId] = 3;
			CursorSelect[playerId].transform.position = ModelButton [counter[playerId]].transform.position;
			Debug.Log ("workmnA");
			SelectionTimer[playerId]=0;
			PlayerModelSprite[playerId].spriteName=ModelsSprite[counter[3]];

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
