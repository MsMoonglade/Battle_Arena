using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//variabili statistiche
    public float MaxHealth;
	public float MaxEnergy;
	public float EnergyRegen;
    public float Speed;
	public float RotationSpeed;
    public float ShootForce;
    public float FireRate;
    public float SuperShootCD;
    public float Damage;     
    public float DashSpeed;
    public float DashTime;
    public float SuperDashSpeed;
    public float SuperDashTime;
    public float FallDownTime;
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
	private bool onTurbo;
    private bool imDied;

    //prefabs
    private GameObject prefabs;
	private GameObject chargedBulletPrefab;
	private GameObject bulletPrefab;
	private GameObject mirinoPrefab;
	private GameObject inAirAim;

    //components
    private Rigidbody rb;
	private Collider col;
	private Animator anim;

    //variabili shoot
    private GameObject spawn;
    private GameObject[] bulletPool;
    private SuperBullet chargedBullet;
    private bool canShoot;
    private bool isChargingShoot;
    private float shootTimer;
    private float superShootTimer;	
	private int bulletIndex;
    private GameObject spawnStartPos;
	
	//variabili wall
	private GameObject wall;

    //limiti mappa
    private GameObject[] mapLimit = new GameObject[4];
    


    void Awake()
    {
		currentHealth = MaxHealth;
		currentEnergy = MaxEnergy;
		//prefabs
		prefabs = transform.FindChild ("Prefabs").gameObject;

        wall = prefabs.transform.FindChild("Wall").gameObject;
        wall.SetActive(false);
        
		mirinoPrefab = prefabs.transform.FindChild ("InAirAim").gameObject;
		inAirAim = Instantiate(mirinoPrefab, Vector3.zero, mirinoPrefab.transform.rotation) as GameObject;
		inAirAim.SetActive(false);

		bulletPrefab = prefabs.transform.FindChild ("Bullet").gameObject;
		chargedBulletPrefab = prefabs.transform.FindChild ("SuperBullet").gameObject;

        spawn = transform.FindChild("Spawnpoint").gameObject;
        spawnStartPos = transform.FindChild("SpawnpointLocalPos").gameObject;


        //components
        rb = GetComponent<Rigidbody>();

        //limitatori di movimento
        for (int i = 0; i < 4; i++)
        {
            mapLimit[i] = GameObject.FindGameObjectWithTag("EnvironmentLimit").transform.GetChild(i).gameObject;
        }

        //bool varie
        onFly = false;       
        canShoot = true;
        isChargingShoot = false;

        //shoot      
        bulletIndex = 0;
        bulletPool = new GameObject[30];
        for (int i = 0; i < 30; i++)
        {
			bulletPool[i] = Instantiate(bulletPrefab , Vector3.zero , bulletPrefab.transform.rotation) as GameObject;
			bulletPool[i].GetComponent<Bullet>().Damage = Damage;
			bulletPool[i].GetComponent<Bullet>().Speed = ShootForce;
			bulletPool[i].GetComponent<Bullet>().ThisPlayer = this.gameObject;
			bulletPool[i].GetComponent<MeshRenderer>().material.color = transform.FindChild("Model").GetComponent<MeshRenderer>().material.color;
			bulletPool[i].SetActive(false);
        }

		//super shoot
        GameObject superBul = Instantiate(chargedBulletPrefab, Vector3.zero, chargedBulletPrefab.transform.rotation) as GameObject;
        chargedBullet = superBul.GetComponent<SuperBullet>();
        chargedBullet.GetComponent<MeshRenderer>().material.color = transform.FindChild("Model").GetComponent<MeshRenderer>().material.color;
        chargedBullet.ThisPlayer = this.gameObject;
        chargedBullet.playerSpawn = spawn.gameObject;
        superBul.SetActive(false);

    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        superShootTimer += Time.deltaTime;

		RechargeEnergy();
        /*
        //test super dash su muro e caduta;
        if (Input.GetButtonDown(buttonName: ("Fire1")) && !onSuperDash)
            SuperDash();
        if(Input.GetButtonDown(buttonName: ("Fire2")))
            FallDown();
            */
    }


    void OnCollisionExit(Collision col)
    {
        if (col.transform.CompareTag ("Player") && onSuperDash)                
            col.transform.GetComponent<Player>().TakeDamage(Damage);        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("PlayerWall") && onSuperDash)
        {
            StartCoroutine (WallHit());
            onFly = true;
            Invoke("FallDown", FallDownTime);
        }
    }

    public void Move(float horizontal, float vertical)
    {
        if (!onDash && !onFly && !imDied)
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime;
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

        //movimento mirino quando si salta su un muro
        if (onFly)           
            AimMove(horizontal, vertical);

        if (inAirAim.transform.gameObject.activeInHierarchy)
            transform.position = new Vector3(inAirAim.transform.position.x, transform.position.y, inAirAim.transform.position.z);
    }

    public void Rotate(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(new Vector3(horizontal, 0, - vertical));

            transform.rotation = rotation;
        }   
    }

    public void Shoot()
    {
        if (!onFly && !imDied)
        {
            if (shootTimer > FireRate && canShoot)
            {
                bulletPool[bulletIndex].transform.position = spawn.transform.position;
				bulletPool[bulletIndex].transform.rotation = transform.rotation;
				bulletPool[bulletIndex].SetActive(true);

                shootTimer = 0;
            }

			if (bulletIndex == bulletPool.Length)
                bulletIndex = 0;
        }
    }

    public void SuperShoot()
    {
        if (!imDied && !onFly && superShootTimer > SuperShootCD){
            isChargingShoot = true;
            chargedBullet.gameObject.transform.position = spawn.transform.position;
            chargedBullet.gameObject.transform.rotation = spawn.transform.rotation;
            chargedBullet.gameObject.SetActive(true);

            ChargeSuperShoot();
        }
    }

    public void RelaseSuperShoot()
    {
        if (isChargingShoot)
        {
            superShootTimer = 0;
            chargedBullet.ShootStart();
            spawn.transform.position = spawnStartPos.transform.position;
            isChargingShoot = false;
        }
    }

    private void ChargeSuperShoot()
    {
        chargedBullet.Charge();
    }

	public void CreateWall()
	{
		if (!onFly && currentEnergy >=2)
		{
			currentEnergy -= 2; // da controllare
			wall.transform.position = spawn.transform.position;
			wall.transform.rotation = transform.rotation;
			wall.transform.SetParent (null);
			wall.SetActive (true);
		}
	}

    public void Dash()
    {            
        onDash = true;
        rb.AddForce(transform.forward * DashSpeed, ForceMode.Impulse);
        Invoke("EndDash", DashTime);        
    }

    public void EndDash()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        onDash = false;
    }

    public void SuperDash()
    {
        if (!onFly)
        {
            onSuperDash = true;
            rb.AddForce(transform.forward * SuperDashSpeed, ForceMode.Impulse);
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
    }

    public void AimMove(float horizontal, float vertical)
    {        
        inAirAim.SetActive(true);

        Vector3 position = new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime;

        inAirAim.transform.position = inAirAim.transform.position + position;
    }

    public void FallDown()
    {
        if (onFly)
        {  
            StartCoroutine(FallDownAnimation());                    
            inAirAim.SetActive(false);
            onFly = false;
        }
    }

    public IEnumerator FallDownAnimation()
    {
        while (transform.position.y > 1)
        {
            transform.Translate(Vector3.down * 30 * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator WallHit()
    {
        while (transform.position.y < 20)
        {
            transform.Translate(transform.up * 20 * Time.deltaTime);
            yield return null;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            gameObject.SetActive(false);
    }
	void RechargeEnergy()
	{
		if ( currentEnergy < MaxEnergy ) 
			currentEnergy += EnergyRegen * Time.deltaTime;
	}

    void Die()
    {
        imDied = true;
        gameObject.SetActive(false);
    }
}