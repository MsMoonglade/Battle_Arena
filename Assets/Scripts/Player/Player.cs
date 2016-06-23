using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {	
	
	//prefabs
	public GameObject ChargedBulletPrefab;
    public GameObject WallPrefab;
    public GameObject MirinoPrefab;

     public string shotSound = "S_Shot";
     public string dashSound = "S_Dash";
    public string explosionSound = "S_Explosion";
    public string crackSound = "S_Crack";
    public string SuperShotSound = "S_SuperShot";

    int shotID;


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
    public float SuperDashDamage;
    public float SuperDashCost;
    public float SuperDashSpeed;
    public float SuperDashTime;
    public float RespawnFallTime;
    public float RangeExplosion;
    public float fallDownSpeed;
    public float FallDownDmg;
    public float WallCost;
    public float AssisTime;


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
  //  public bool onFly;
    private GameObject inAirAim;
    //private bool isFalling;
    public bool isGrunded;

    //components
    private Rigidbody rb;
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

    //variabili score
    private GameObject[] playersGO;
    private Player[] players;
    private float[] percDmg;

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
        stat = transform.GetComponentInChildren<ModelStat>();
        anim = GetComponent<AnimatorController>();




        //shoot     
        bulletPool = new GameObject[30];
        for (int i = 0; i < 30; i++)
        {
            bulletPool[i] = Instantiate(stat.BulletPrefab, Vector3.zero, stat.BulletPrefab.transform.rotation) as GameObject;
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

        //score
        GameObject[] playersTemp = GameObject.FindGameObjectsWithTag("Player");
        playersGO = new GameObject[playersTemp.Length - 1];
        players = new Player[playersGO.Length];
        percDmg = new float[playersGO.Length];

        int index = 0;
        for (int i = 0; i < playersTemp.Length; i++)
        {
            if (playersTemp[i] != this.gameObject)
            {
                playersGO[index] = playersTemp[i];
                players[index] = playersGO[index].GetComponent<Player>();
                index++;
            }
        }

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
        //onFly = false;
        canShoot = true;
        isChargingShoot = false;
        imDied = false;
        isGrunded = true;
       // isFalling = false;

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
        if (col.transform.CompareTag("PlayerCollider") && onSuperDash)
        {
            HitScore(col.name);
            col.SendMessageUpwards("TakeDamage", SuperDashDamage);
        }

      /*  if (col.transform.CompareTag("PlayerCollider") && !isGrunded)
        {

            FallDownDamage();
            isGrunded = true;
            inAirAim.SetActive(false);
            // isFalling = false;
            //onFly = false;

            if (imDied)
                imDied = false;
        }*/
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
            Invoke("FallDown", RespawnFallDown);
        }*/

        if (col.transform.CompareTag("Arena") && !isGrunded)
        {

            FallDownDamage();
            isGrunded = true;
            inAirAim.SetActive(false);
            // isFalling = false;
            //onFly = false;

            if (imDied)
                imDied = false;
        }

       


        /*if (col.transform.CompareTag("Player") && isFalling)
                {
                    FallDownDamage();
                    isFalling = false;
                    onFly = false;

                    if (imDied)
                        imDied = false;
                }*/

        if (col.transform.CompareTag("PlayerWall") && !isGrunded)
        {
            FallDownDamage();
            // isFalling = false;
            //onFly = false;
            inAirAim.SetActive(false);
            isGrunded = true;

            if (imDied)
                imDied = false;
        }
    }

    public void Move(float horizontal, float vertical)
    {
        
        //move base
        if (!onDash && !onSuperDash && isGrunded)
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical) * stat.Speed * Time.deltaTime;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.MovePosition(transform.position + movement);
        }

        //limite del movimento
        Vector3 clampedPositionX = transform.position;
      //  clampedPositionX.x = Mathf.Clamp(transform.position.x, mapLimit[1].transform.position.x, mapLimit[0].transform.position.x);
        transform.position = new Vector3 (clampedPositionX.x , transform.position.y , transform.position.z);

        Vector3 clampedPositionZ = transform.position;
      //  clampedPositionZ.z = Mathf.Clamp(transform.position.z, mapLimit[3].transform.position.z, mapLimit[2].transform.position.z);
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
        if (isGrunded && !isChargingShoot)
        {
            if (shootTimer > stat.FireRate && canShoot)
            {     
                bulletPool[bulletIndex].transform.position = BulletSpawnPoint[spawnpointIndex].transform.position;
				bulletPool[bulletIndex].transform.rotation = transform.rotation;
				bulletPool[bulletIndex].SetActive(true);
                particellari.Play("shoot" + spawnpointIndex);
                anim.Play("shoot" + spawnpointIndex);
                AudioManager.instance.PlaySound(shotSound);
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
        if (isGrunded &&  !imDied && superShootTimer > SuperShootCD && currentEnergy >= SuperShootEnergyCost)
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
            chargedBullet.SendMessage("Relase");
            particellari.Stop("charge");

            if(chargedBullet.isFull)
            {
                AudioManager.instance.StopSound(chargedBullet.FullSound, chargedBullet.fullID);
                chargedBullet.fullID = -1;
                chargedBullet.isFull = false;
            }

            chargedBullet.isShot = true;

            chargedBullet.shotID = AudioManager.instance.PlaySoundWithID(SuperShotSound);
            if (chargedBullet.isAbsorbing)
            {
                AudioManager.instance.StopSound(chargedBullet.AbsorbSound, chargedBullet.absorbID);
                chargedBullet.isAbsorbing = false;
                chargedBullet.absorbID = -1;


            }
            Debug.Log("ID " + chargedBullet.shotID);
        }
    }

	public void CreateWall()
	{
		if (isGrunded && !imDied && currentEnergy >= WallCost)
		{
			currentEnergy -= WallCost; 
			wall.transform.position = WallSpawnPoint.transform.position;
			wall.transform.rotation = transform.rotation;
			wall.transform.SetParent (null);
			wall.SetActive (true);
            AudioManager.instance.PlaySound(crackSound);
        }
	}

	public void Dash(float horizontal , float vertical)
	{
		if (currentEnergy >= DashCost && !imDied && isGrunded)
		{
            particellari.Play("dash");
			currentEnergy -= DashCost;
			onDash = true;
			Vector3 direction = new Vector3(horizontal, 0, vertical);
			
			if (horizontal == 0 && vertical == 0)
				direction = transform.forward;
            AudioManager.instance.PlaySound(dashSound);
            rb.AddForce(direction * DashSpeed, ForceMode.Impulse);
			Invoke("EndDash", DashTime);
		}        
	}

    public void EndDash()
    {
        particellari.Stop("dash");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        onDash = false;
    }

    public void SuperDash(float horizontal, float vertical)
    {
        if (isGrunded && !onDash && !imDied  && currentEnergy >= SuperDashCost)
        {
			currentEnergy -= SuperDashCost;
            onSuperDash = true;                    
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
        particellari.Stop("superDash");
    }

    private void FallDown()
    {     
        //metodo per la caduta
        if (!isGrunded)
        {  
            rb.useGravity = true;
           // isFalling = true;
            StartCoroutine(FallDownAnimation());
           // inAirAim.SetActive(false);
        }
    }

    private void FallDownDamage()
    {
        //quando cade overlappa
        Collider[] col = Physics.OverlapSphere(transform.position, RangeExplosion);
        AudioManager.instance.PlaySound(crackSound);
        particellari.Play("impact");

        for (int i = 0; i < col.Length; i++)
        {
            if (col[i] != transform.GetComponent<Collider>() && col[i].transform.CompareTag("Player") && imDied)
            {
                col[i].SendMessage("TakeDamage", FallDownDmg);
                HitScore(col[i].name);
            }
        }
    }

    private IEnumerator FallDownAnimation()
    {
        yield return new WaitForSeconds(RespawnFallTime);
        //il player cade
        while(!isGrunded)
        {
            transform.Translate(Vector3.down * fallDownSpeed * Time.deltaTime);
            
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

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();   
        }
    }

     void Die()
    {
        imDied = true;
        AudioManager.instance.PlaySound(explosionSound);
        particellari.Play("explosion");
        RelaseSuperShoot();
        Respawn();
        AudioManager.instance.PlaySound(explosionSound);
    }

    private void RechargeEnergy()
	{
		if ( currentEnergy < stat.MaxEnergy ) 
			currentEnergy += stat.EnergyRegen * Time.deltaTime;
	}

    private void Respawn()
    {
        
   

        //sposto il player in aria
        transform.position = new Vector3(0, 20, 0);
        isGrunded = false;
        rb.useGravity = false;
        

        inAirAim.transform.position = Vector3.zero;
        inAirAim.SetActive(true);

        currentHealth = stat.MaxHealth;
        currentEnergy = stat.MaxEnergy;
        shootCharge = 0;
        FallDown(); 
    }

    private void HitScore(string name)
    {
        for (int i = 0; i < playersGO.Length; i++)
        {
            if (name.Equals(playersGO[i].name))
            {
                if (stat.Damage > players[i].currentHealth)
                    percDmg[i] += ((players[i].currentHealth * 100) / players[i].stat.MaxHealth);
                else
                    percDmg[i] += ((stat.Damage * 100) / players[i].stat.MaxHealth);

                StartCoroutine("ScoreCorutine", i);
            }
        }       
    }

    private IEnumerator ScoreCorutine(int i)
    {
        float timer = 0;
        while (timer <= AssisTime)
        {
            timer += Time.deltaTime;

            if (players[i].imDied)
            {
                GameController.instance.AssignScore(gameObject.name, percDmg[i]);
                percDmg[i] = 0;
                StopCoroutine("ScoreCorutine");

            }
            yield return null;
        }
        percDmg[i] = 0;
    }

    private void DamagePUP(float[] value)
    {
        for (int i = 0; i < 30; i++)
        {
            bulletPool[i].GetComponent<Bullet>().Damage += ((stat.Damage * value[0]) / 100);
        }

        StartCoroutine("DamageReset", value[1]);
    }

    private IEnumerator DamageReset(float time)
    {
        yield return new WaitForSeconds(time);

        for (int i = 0; i < 30; i++)
        {
            bulletPool[i].GetComponent<Bullet>().Damage = stat.Damage;
        }
    }

    private void HealthRegen(float[] value)
    {
        StartCoroutine("HealthRegenPowerUP", value);
    }

    private IEnumerator HealthRegenPowerUP(float[] value)
    {
        float timer = 0;
        float hotTime = 0;

        while (timer <= value[2])
        {
            timer += Time.deltaTime;

            hotTime += Time.deltaTime;

            if (hotTime >= value[1])
            {
                if ((stat.MaxHealth - currentHealth) <= value[0])
                    currentHealth += (stat.MaxHealth - currentHealth);


                if ((stat.MaxHealth - currentHealth) > value[0])
                    currentHealth += value[0];

                hotTime = 0;
            }
            yield return null;
        }
    }

    private void EnergyRegen(float[] value)
    {
        StartCoroutine("EnergyRegenPowerUP", value);
    }

    private IEnumerator EnergyRegenPowerUP(float[] value)
    {
        float timer = 0;
        float hotTime = 0;

        while (timer <= value[2])
        {
            timer += Time.deltaTime;

            hotTime += Time.deltaTime;

            if (hotTime >= value[1])
            {
                if ((stat.MaxEnergy - currentEnergy) <= value[0])
                    currentEnergy += (stat.MaxEnergy - currentEnergy);


                if ((stat.MaxEnergy - currentEnergy) > value[0])
                    currentEnergy += value[0];

                hotTime = 0;
            }
            yield return null;
        }
    }
}