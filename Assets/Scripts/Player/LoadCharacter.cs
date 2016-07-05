using UnityEngine;
using System.Collections;

public class LoadCharacter : MonoBehaviour {
	
	
	public GameObject[] Models;
	public int playerModelIndex;

	public int testIndex;

	[HideInInspector]
	public Color MyColor;

	GameObject model;
	private MeshRenderer[] mesh;	
	private GameObject ModelSelected;


	void Awake()
	{
	/*	if (this.gameObject.name == "Player1") {
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
		}*/



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
	void Start()
	{
		ColorModel();
	}

	private void ColorModel()
	{
		string name = gameObject.name;
		if(name.Equals("Player1"))
		{		
		
			Renderer rendBody =  model.GetComponent<Renderer> ();
			rendBody.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendBody.material.SetColor ("_Player_color", Color.green);
			
			Renderer rendLeft = model.transform.GetChild (0).GetChild (0).GetComponent<Renderer> ();
			rendLeft.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendLeft.material.SetColor ("_Player_color", Color.green);
			
			Renderer rendRight = model.transform.GetChild (0).GetChild (1).GetComponent<Renderer> ();
			rendRight.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendRight.material.SetColor ("_Player_color", Color.green);

			MyColor = Color.green;
		}
		else if(name.Equals("Player2"))
		{

			Renderer rendBody = model.GetComponent<Renderer> ();
			rendBody.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendBody.material.SetColor ("_Player_color", Color.red);
			
			Renderer rendLeft = model.transform.GetChild (0).GetChild (0).GetComponent<Renderer> ();
			rendLeft.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendLeft.material.SetColor ("_Player_color", Color.red);
			
			Renderer rendRight =model.transform.GetChild (0).GetChild (1).GetComponent<Renderer> ();
			rendRight.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendRight.material.SetColor ("_Player_color", Color.red);

			MyColor = Color.red;
		}
		else if(name.Equals("Player3"))
		{
			
			Renderer rendBody = model.GetComponent<Renderer> ();
			rendBody.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendBody.material.SetColor ("_Player_color", Color.cyan);
			
			Renderer rendLeft = model.transform.GetChild (0).GetChild (0).GetComponent<Renderer> ();
			rendLeft.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendLeft.material.SetColor ("_Player_color", Color.cyan);
			
			Renderer rendRight =model.transform.GetChild (0).GetChild (1).GetComponent<Renderer> ();
			rendRight.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendRight.material.SetColor ("_Player_color", Color.cyan);

			MyColor = Color.cyan;
		}
		else if(name.Equals("Player4"))
		{
			
			Renderer rendBody = model.GetComponent<Renderer> ();
			rendBody.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendBody.material.SetColor ("_Player_color", new Color(244,146,0,255));
			
			Renderer rendLeft = model.transform.GetChild (0).GetChild (0).GetComponent<Renderer> ();
			rendLeft.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendLeft.material.SetColor ("_Player_color", new Color(244,146,0,255));
			
			Renderer rendRight =model.transform.GetChild (0).GetChild (1).GetComponent<Renderer> ();
			rendRight.material.shader = Shader.Find ("Shader Forge/sh_robots");
			rendRight.material.SetColor ("_Player_color", new Color(244,146,0,255));

			MyColor = new Color(244,146,0,255);
		}



	}
		
}

