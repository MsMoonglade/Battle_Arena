using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//variabili statistiche
    public float MaxHealth;
	public float MaxStamina;
	public float MaxEnergy;
	public float StaminaRegen;
    public float Speed;
	public float RotationSpeed;
    public float ShootForce;
    public float FireRate;
    public float Damage;     
    public float DashSpeed;
    public float DashTime;
    public float SuperDashSpeed;
	public float RangeExplosion;

    [HideInInspector]
    public float currentHealth;
	[HideInInspector]
	public float currentStamina;
	[HideInInspector]
	public float currentDefEnergy;    
    
    private bool canShoot;
    private bool onFly;
    //Variabili per Dash
    [HideInInspector]
    public bool onDash;
    private bool onSuperDash;
	private bool onTurbo;

	//prefabs pubblici
	private GameObject prefabs;
	private GameObject chargedBulletPrefab;
	private GameObject bulletPrefab;
	private GameObject mirinoPrefab;
	private GameObject inAirAim; 
	private GameObject spawn;

	//components
	private Rigidbody rb;
	private Collider col;
	private Animator anim;

	//variabili shoot
	private float shootTimer;
	private GameObject[] bulletPool;
	private int bulletIndex;
	private SuperBullet chargedBullet; 

	//variabili wall
	private GameObject wall;
	

    void Awake()
    {
		currentHealth = MaxHealth;

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



		//components
        rb = GetComponent<Rigidbody>();
        
		//bool varie
        onFly = false;
        onSuperDash = false;       
        canShoot = true;			     

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
        chargedBullet.ThisPlayer = this.gameObject;
        superBul.SetActive(false);

    }

    void Update()
    {
        shootTimer += Time.deltaTime;   

		/*
        if (onFly)
        {
            WallDash(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetButtonDown(buttonName: ("Fire1")))
            {
                transform.position = inAirAim.transform.position;
                inAirAim.SetActive(false);
                onFly = false;
            }
        } 
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
            transform.position = new Vector3(transform.position.x, 50, transform.position.z);
            inAirAim.transform.position = Vector3.zero;
            onFly = true;
        }
    }

    public void Move(float horizontal, float vertical)
    {
        if (!onDash && !onFly)
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.MovePosition(transform.position + movement);
        }
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
        if (!onFly)
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

    public void SuperShoot(float buttonPression)
    {
      
            chargedBullet.gameObject.transform.position = spawn.transform.position;
            chargedBullet.gameObject.transform.rotation = spawn.transform.rotation;
            chargedBullet.gameObject.SetActive(true);
            ChargeSuperShoot();
               
    }

    public void RelaseSuperShoot()
    {
        if(chargedBullet.charging)
            chargedBullet.Relase();
    }

    private void ChargeSuperShoot()
    {
        chargedBullet.Charge();
    }

    public void CreateWall()
    {
		if (!onFly)
		{
			wall.transform.position = spawn.transform.position;
			wall.transform.rotation = transform.rotation;
			wall.transform.SetParent (null);
			wall.SetActive (true);
		}
    }

    /*public void ChargedShoot()
    {
        if (!onFly)
        {
            charging = true;
            canShoot = false;
            currentShootCharge += Time.deltaTime;

            Debug.Log("cazzo");
            chargedBullet.transform.position = spawn.transform.position;
            chargedBullet.GetComponent<Bullet>().Damage = currentShootCharge * 5;
            chargedBullet.transform.localScale = new Vector3(currentShootCharge / 2, currentShootCharge / 2, currentShootCharge / 2);

            if (currentShootCharge >= 3)
            {
                chargedBullet.gameObject.SetActive(true);

                currentShootCharge = 0;
                canShoot = true;
            }
        }
    }
	*/

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


    public void SuperDash(float horizontal , float vertical)
    {

        Vector3 Direction = new Vector3(horizontal, 0, -vertical) * SuperDashSpeed;

        if (horizontal != 0 || vertical != 0 && onFly ==false)
        {
            StartCoroutine("DashDamage");
           
            transform.position = Vector3.Lerp(transform.position, Direction, Time.deltaTime /3);
        }

    }

    private IEnumerator DashDamage()
    {
        onSuperDash = true;     
        yield return new WaitForSeconds(1);
        onSuperDash = false;
    }

    public void WallDash(float horizontal, float vertical)
    {
        
        inAirAim.SetActive(true);

        Vector3 position = new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime;

        inAirAim.transform.position = inAirAim.transform.position + position;
    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            gameObject.SetActive(false);
    }
}