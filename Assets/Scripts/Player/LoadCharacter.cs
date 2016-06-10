using UnityEngine;
using System.Collections;

public class LoadCharacter : MonoBehaviour {


	public GameObject[] Models;
	//	public int Model;
	public int IndexModel;

	GameObject model;
	private MeshRenderer[] mesh;

	private GameObject ModelSelected;

	void Awake()
	{

		if (this.gameObject.name == "Player1") {
			IndexModel = 0;
		}
		if (this.gameObject.name == "Player2") {
			IndexModel = 1;
		}
		if (this.gameObject.name == "Player3") {
			IndexModel = 2;
		}
		if (this.gameObject.name == "Player4") {
			IndexModel = 3;
		}
			
		ModelSelected = GameObject.FindGameObjectWithTag ("CharacterController");

		Debug.Log (ModelSelected.name);
		Debug.Log (ModelSelected.GetComponent<CharacterSelection> ().counter [0]);

		model = Instantiate (Models [ModelSelected.GetComponent<CharacterSelection>().counter[IndexModel]], transform.position, Quaternion.identity ) as GameObject;
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
