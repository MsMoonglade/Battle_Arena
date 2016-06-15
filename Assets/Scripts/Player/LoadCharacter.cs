using UnityEngine;
using System.Collections;

public class LoadCharacter : MonoBehaviour {
	
	
	public GameObject[] Models;
	public int playerModelIndex;

	public int testIndex;

	GameObject model;
	private MeshRenderer[] mesh;
	
	private GameObject ModelSelected;

	void Awake()
	{
		if (this.gameObject.name == "Player1") {
			playerModelIndex=0;
		}
		if (this.gameObject.name == "Player2") {
			playerModelIndex=1;
		}
		if (this.gameObject.name == "Player3") {
			playerModelIndex=2;
		}
		if (this.gameObject.name == "Player4") {
			playerModelIndex=3;
		}



		ModelSelected = GameObject.FindGameObjectWithTag ("CharacterController");
//		Debug.Log (ModelSelected.name);
//		Debug.Log (ModelSelected.GetComponent<CharacterSelection> ().counter [playerModelIndex]);
//		Debug.Log ("index"+playerModelIndex);



		model = Instantiate (Models [ModelSelected.GetComponent<CharacterSelection> ().counter [playerModelIndex]], transform.position, Quaternion.identity ) as GameObject;
		model.transform.SetParent (transform);
		model.name = "Model";
		
		
		//mesh = model.transform.GetComponentsInChildren<MeshRenderer> ();
		//model.transform.position =;
		
		/*if (transform.name.Equals ("Player1")) 
			for (int i = 0; i > mesh.Length; i ++)			
				mesh [i].sharedMaterial.color  = Color.blue;


		if (transform.name.Equals ("Player2")) 		
			for (int i = 0 ; i > mesh.Length ; i ++)			
				mesh[i].sharedMaterial.color= Color.green;

		if (transform.name.Equals ("Player3")) 		
			for (int i = 0 ; i > mesh.Length ; i ++)			
				mesh[i].sharedMaterial.color = Color.red;

		if (transform.name.Equals ("Player4")) 		
			for (int i = 0 ; i > mesh.Length ; i ++)			
				mesh[i].sharedMaterial.color = Color.yellow;*/
	}
}
