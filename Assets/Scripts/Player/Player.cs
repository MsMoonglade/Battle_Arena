﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {	
	
	//prefabs
	public GameObject ChargedBulletPrefab;
	public GameObject BulletPrefab;
    public GameObject WallPrefab;
    public GameObject MirinoPrefab;

    //spawnpoint
	public GameObject[] BulletSpawnPoint;
    public GameObject WallSpawnPoint;

    //variabili statistiche
    public float RotationSpeed;
    public float ShootForce;  
    public float SuperShootEnergyCost;
    public float SuperShootCD;
    public float DashCost;
    public float DashSpeed;
    public float DashTime;
    public float SuperDashSpeed;
    public float SuperDashTime;
    public float FallDownTime;
    public float RespawnFallTime;
    public float RangeExplosion;

    [HideInInspector]
    public float currentHealth;
	[HideInInspector]
	public float currentEnergy;    

    //Variabili per Dash
    [HideInInspector]
    public bool onDash;
    [HideInInspector]
    public bool onSuperDash;
    [HideInInspector]
    public bool onFly;
    private GameObject inAirAim;
    private bool isFalling;

    //components
    private Rigidbody rb;
	private Collider col;
    [HideInInspector]
    public bool imDied;
    [HideInInspector]
    public ModelStat stat;
    private AnimatorController anim;

    //variabili shoot  
    private SuperBullet chargedBullet;
    private GameObject[] bulletPool; 
    private bool canShoot;
    private bool isChargingShoot;
    private float shootTimer;
    private float superShootTimer;	
	private int bulletIndex;
    private int spawnpointIndex;
    [HideInInspector]
    public float shootCharge;

	//variabili wall
	private GameObject wall;
  
    //limiti mappa
    private GameObject[] mapLimit = new GameObject[4];

    //variabili particellari
    private ParticleController particellari;

    void Awake()
	{        
		//components
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        stat = transform.GetComponentInChildren<ModelStat>();
        anim = GetComponent<AnimatorController>();
        

        //limitatori di movimento
        for (int i = 0; i < 4; i++)
        {
            mapLimit[i] = GameObject.FindGameObjectWithTag("EnvironmentLimit").transform.GetChild(i).gameObject;
        }

        //shoot     
        bulletPool = new GameObject[30];
        for (int i = 0; i < 30; i++)
        {
			bulletPool[i] = Instantiate(BulletPrefab , Vector3.zero , BulletPrefab.transform.rotation) as GameObject;
			bulletPool[i].GetComponent<Bullet>().Damage = stat.Damage;
			bulletPool[i].GetComponent<Bullet>().Speed = ShootForce;
			bulletPool[i].GetComponent<Bullet>().ThisPlayer = this.gameObject;
			bulletPool[i].SetActive(false);
        }

		//super shoot
        GameObject superBul = Instantiate(ChargedBulletPrefab, Vector3.zero, ChargedBulletPrefab.transform.rotation) as GameObject;
        chargedBullet = superBul.GetComponent<SuperBullet>();
        chargedBullet.ThisPlayer = this.gameObject;

		inAirAim = Instantiate(MirinoPrefab , Vector3.zero, MirinoPrefab.transform.rotation) as GameObject;
		inAirAim.SetActive (false);

        //wall
        wall = Instantiate(WallPrefab, Vector3.zero, WallPrefab.transform.rotation) as GameObject;
        wall.SetActive (false);

        //particellari
        particellari = GetComponent<ParticleController>();
    }

    void Start()
    {
		

		//Assegnazione Stat
        currentHealth = stat.MaxHealth;
        currentEnergy = stat.MaxEnergy;
        superShootTimer = SuperShootCD;

        //bool varie
        onFly = false;
        canShoot = true;
        isChargingShoot = false;
        imDied = false;
        isFalling = false;

        //Assegnazioni indici per sparo
        bulletIndex = 0;
        spawnpointIndex = 0;
    }

    void Update()
    {
        //Timer per lo sparo
        shootTimer += Time.deltaTime;
        superShootTimer += Time.deltaTime;
        shootCharge += Time.deltaTime;

        //Metodo per il recupero dell'energy
        RechargeEnergy();
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag ("Player") && onSuperDash)                
            col.transform.GetComponent<Player>().TakeDamage(stat.Damage , this.gameObject);
        if (col.transform.CompareTag("EnvironmentWall") && onSuperDash)
            EndSuperDash();       
    }

    void OnCollisionEnter(Collision col)
    {
        /*if (col.transform.CompareTag("PlayerWall") && onSuperDash)
        {
            rb.useGravity = false;
            inAirAim.transform.position = transform.position;
            inAirAim.SetActive(true);
            StartCoroutine (WallHit());
            onFly = true;
            Invoke("FallDown", FallDownTime);
        }*/

        if (col.transform.CompareTag("Arena") && isFalling)
        {
        
            FallDownDamage();
            isFalling = false;
            onFly = false;

            if (imDied)
                imDied = false;
        }
        
        if (col.transform.CompareTag("Player") && isFalling)
        {
            FallDownDamage();
            isFalling = false;
            onFly = false;

            if (imDied)
                imDied = false;
        }

        if (col.transform.CompareTag("PlayerWall") && isFalling)
        {
            FallDownDamage();
            isFalling = false;
            onFly = false;

            if (imDied)
                imDied = false;
        }
    }

    public void Move(float horizontal, float vertical)
    {
        
        //move base
        if (!onDash && !onSuperDash && !onFly && !imDied)
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical) * stat.Speed * Time.deltaTime;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.MovePosition(transform.position + movement);
        }

        //limite del movimento
        Vector3 clampedPositionX = transform.position;
        clampedPositionX.x = Mathf.Clamp(transform.position.x, mapLimit[1].transform.position.x, mapLimit[0].transform.position.x);
        transform.position = new Vector3 (clampedPositionX.x , transform.position.y , transform.position.z);

        Vector3 clampedPositionZ = transform.position;
        clampedPositionZ.z = Mathf.Clamp(transform.position.z, mapLimit[3].transform.position.z, mapLimit[2].transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedPositionZ.z);

        //movimento mirino
        if (inAirAim.transform.gameObject.activeInHierarchy)
        {
            AimMove(horizontal, vertical);
            transform.position = new Vector3(inAirAim.transform.position.x, transform.position.y, inAirAim.transform.position.z);
        }
    }

    public void Rotate(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(new Vector3(horizontal, 0, - vertical));

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
        }   
    }

    public void Shoot()
    {
        if (!onFly && !imDied && !isChargingShoot)
        {
            if (shootTimer > stat.FireRate && canShoot)
            {     
                bulletPool[bulletIndex].transform.position = BulletSpawnPoint[spawnpointIndex].transform.position;
				bulletPool[bulletIndex].transform.rotation = transform.rotation;
				bulletPool[bulletIndex].SetActive(true);
                particellari.Play("shoot" + spawnpointIndex);
                anim.Play("shoot" + spawnpointIndex);

                spawnpointIndex++;
                bulletIndex++;
                shootTimer = 0;
            }

            if (spawnpointIndex == BulletSpawnPoint.Length)
                spawnpointIndex = 0;

			if (bulletIndex == bulletPool.Length)
                bulletIndex = 0;
        }
       
    }

    public void SuperShoot()
    {
        if (!imDied && !onFly && !imDied && superShootTimer > SuperShootCD && currentEnergy >= SuperShootEnergyCost)
        {
            if (isChargingShoot)
            {
                ChargeBullet();
                currentEnergy -= SuperShootEnergyCost;
            }
            else
            {
                isChargingShoot = true;
                shootCharge = 0;
            }       
        }
    }

    private void ChargeBullet()
    {       
        chargedBullet.transform.rotation = transform.rotation;
        chargedBullet.transform.position = WallSpawnPoint.transform.position;
        particellari.Play("charge");

        if (shootCharge < 1)
        {
            particellari.Play("charge1");
            chargedBullet.Charge(0);
        }

        if (shootCharge < 2 && shootCharge > 1)
        {
            particellari.Play("charge2");
            chargedBullet.Charge(1);
        }

        if (shootCharge < 3 && shootCharge > 2)
        {
            particellari.Play("charge3");
            chargedBullet.Charge(2);
        }
    }

    public void RelaseSuperShoot()
    {
        if (isChargingShoot)
        {
            for (int i = 0; i < chargedBullet.partc.Length; i++)
                chargedBullet.partc[i].Play();
            chargedBullet.col.SetActive(true);    
            superShootTimer = 0;
            isChargingShoot = false;
            particellari.Stop("charge");
        }
    }

	public void CreateWall()
	{
		if (!onFly && !imDied && currentEnergy >=2)
		{
			currentEnergy -= 2; 
			wall.transform.position = WallSpawnPoint.transform.position;
			wall.transform.rotation = transform.rotation;
			wall.transform.SetParent (null);
			wall.SetActive (true);
		}
	}

	public void Dash(float horizontal , float vertical)
	{
		if (currentEnergy >= DashCost && !imDied && !onFly)
		{
			currentEnergy -= DashCost;
			onDash = true;
			Vector3 direction = new Vector3(horizontal, 0, vertical);
			
			if (horizontal == 0 && vertical == 0)
				direction = transform.forward;
			
			rb.AddForce(direction * DashSpeed, ForceMode.Impulse);
			Invoke("EndDash", DashTime);
		}        
	}

    public void EndDash()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        onDash = false;
    }

    public void SuperDash(float horizontal, float vertical)
    {
        if (!onFly && !onDash && !imDied  && currentEnergy >= 4)
        {
			currentEnergy -= 4;
            onSuperDash = true;
            col.isTrigger = true;
            rb.useGravity = false;
            particellari.Play("superDash");
        
            Vector3 direction = new Vector3(horizontal, 0, vertical);

            if (horizontal == 0 && vertical == 0)
                direction = transform.forward;

            rb.AddForce(direction * SuperDashSpeed, ForceMode.Impulse);

            inAirAim.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            inAirAim.SetActive(false);
            Invoke("EndSuperDash", SuperDashTime);
        }
    }

    public void EndSuperDash()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        onSuperDash = false;
        col.isTrigger = false;
        rb.useGravity = true;
        particellari.Stop("superDash");
    }

    private void FallDown()
    {
        
        //metodo per la caduta
        if (onFly)
        {
           
            rb.useGravity = true;
            isFalling = true;
            StartCoroutine(FallDownAnimation());
            inAirAim.SetActive(false);
        }
    }

    private void FallDownDamage()
    {
        //quando cade overlappa
        Collider[] col = Physics.OverlapSphere(transform.position, RangeExplosion);
        particellari.Play("impact");

        for(int i = 0; i < col.Length; i++)
        {
            if(col[i] != transform.GetComponent<Collider>() && col[i].transform.CompareTag("Player") && !imDied)
                col[i].GetComponent<Player>().TakeDamage(stat.MaxHealth , this.gameObject);

            else if (col[i] != transform.GetComponent<Collider>() && col[i].transform.CompareTag("Player") && imDied)
                col[i].GetComponent<Player>().TakeDamage(stat.MaxHealth /2 , this.gameObject);
        } 
    }

    private IEnumerator FallDownAnimation()
    {
        //il player cade
        if(isFalling)
        {
            transform.Translate(Vector3.down * 30 * Time.deltaTime);
            
            yield return null;
        }
    }

    private IEnumerator WallHit()
    {
        //il player va verso l'alto
        while (transform.position.y < 20)
        {
            transform.Translate(transform.up * 30 * Time.deltaTime);
            yield return null;
        }
    }

    private void AimMove(float horizontal, float vertical)
    {
        Vector3 position = new Vector3(horizontal, 0, vertical) * stat.Speed * Time.deltaTime;

        inAirAim.transform.position = inAirAim.transform.position + position;
    }

    public void TakeDamage(float amount , GameObject playerkill)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            particellari.Play("explosion");
            Respawn(playerkill);
        }
    }

    private void RechargeEnergy()
	{
		if ( currentEnergy < stat.MaxEnergy ) 
			currentEnergy += stat.EnergyRegen * Time.deltaTime;
	}

    private void Respawn(GameObject playerkill)
    {
        imDied = true;
        GameController.instance.AssignScore(playerkill, 100);

        transform.position = new Vector3(0, 20, 0);
        onFly = true;
        rb.useGravity = false;

        currentHealth = stat.MaxHealth;

        inAirAim.transform.position = Vector3.zero;
        inAirAim.SetActive(true);         

        Invoke("FallDown", RespawnFallTime);
    }
}