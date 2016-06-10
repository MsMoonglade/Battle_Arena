using UnityEngine;
using System.Collections;

public class LoadCharacter : MonoBehaviour {


	public GameObject[] Models;
	public int Model;

	GameObject model;
	private MeshRenderer[] mesh;

	void Awake()
	{
		model = Instantiate (Models [Model], transform.position, Quaternion.identity ) as GameObject;
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
