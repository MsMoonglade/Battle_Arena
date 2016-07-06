using UnityEngine;
using System.Collections;

public class PowerUpGenerator : MonoBehaviour {

	public GameObject[] PowerUPPref;
	public float FirstPowerUPIn;
	public float NextPupIn;
	public float FallDownSpeed;

    public GameObject DxLimit;
    public GameObject SxLimit;
    public GameObject TopLimit;
    public GameObject BotLimit;

	private GameObject[] PowerUP;
	private float spawnTimer;
	private bool startSpawn;

	void Awake()
	{
		PowerUP = new GameObject[PowerUPPref.Length];

		for (int i = 0; i < PowerUP.Length; i ++)
		{
			PowerUP[i] = Instantiate(PowerUPPref[i] , Vector3.zero , PowerUPPref[i].transform.rotation) as GameObject;
			PowerUP[i].SetActive (false);
		}
	}

	void Start()
	{
		startSpawn = false;

		Invoke ("RandomPuP", FirstPowerUPIn);
	}

	void Update()
	{
		if(startSpawn)		
			SpawnPuP ();
	}

	private void SpawnPuP()
	{
		spawnTimer += Time.deltaTime;

		if (spawnTimer >= NextPupIn)
		{
			RandomPuP();
			spawnTimer = 0;
		}
	}

	private void RandomPuP()
	{
		int randomTemp = Random.Range (0, PowerUP.Length - 1);

		while (PowerUP[randomTemp].activeInHierarchy)
			randomTemp = Random.Range (0, PowerUP.Length - 1);

		float randomX = Random.Range( SxLimit.transform.position.x +5, DxLimit.transform.position.x -5) ;
		float randomZ = Random.Range( BotLimit.transform.position.z +6 , TopLimit.transform.position.z -4) ;
		Vector3 randomPos = new Vector3( randomX , 20 ,randomZ);

		PowerUP [randomTemp].transform.position = randomPos ;
		PowerUP [randomTemp].SetActive (true);

		StartCoroutine ("FallDownAnimation", randomTemp);


		if (!startSpawn) 
		{
			startSpawn = true;	
		}
	}

	private IEnumerator FallDownAnimation(int index)
	{
		while (PowerUP[index].transform.position.y > -5.5f) 
		{
			PowerUP [index].transform.Translate (Vector3.down * FallDownSpeed * Time.deltaTime);
			yield return null;
		}
	}
}
