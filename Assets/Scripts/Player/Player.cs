using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject ChargedBulletPrefab;
    public GameObject BulletPrefab;
    public GameObject MirinoPrefab;
    public float MaxHealth;
    public float MoveSpeed;
    public float ShootForce;
    public float FireRate;
    public float Damage;  
    public float ShieldDeactive;
    public float DashDistance;
    public float SuperDashDistance;

    [HideInInspector]
    public float CurrentHealth;

    private GameObject shield;
    private Rigidbody rb;

    private bool canShoot;
    private bool inAir;
    private bool inSuperDash;
    private bool charging;
    private float currentShootCharge;
    private GameObject chargedBullet;
    private GameObject[] bulletArray;
    private GameObject spawn;    
    private float shootTimer;
    private int bulletIndex;
    private GameObject inAirAim;
    private GameObject dashTail;


    void Awake()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody>();
        shield = transform.FindChild("Shield").gameObject;
        shield.SetActive(false);
        inAirAim = Instantiate(MirinoPrefab, Vector3.zero, MirinoPrefab.transform.rotation) as GameObject;
        inAirAim.SetActive(false); 


        inAir = false;
        inSuperDash = false;
        charging = false;
        canShoot = true;
        currentShootCharge = 0;        

        bulletArray = new GameObject[30];
        for (int i = 0; i < 30; i++)
        {
            bulletArray[i] = Instantiate(BulletPrefab , Vector3.zero , BulletPrefab.transform.rotation) as GameObject;
            bulletArray[i].GetComponent<Bullet>().Damage = Damage;
            bulletArray[i].GetComponent<Bullet>().Speed = ShootForce;
            bulletArray[i].GetComponent<Bullet>().ThisPlayer = this.gameObject;
            bulletArray[i].GetComponent<MeshRenderer>().material.color = transform.FindChild("Model").GetComponent<MeshRenderer>().material.color;
            bulletArray[i].SetActive(false);
        }
        spawn = transform.FindChild("Spawnpoint").gameObject;
        bulletIndex = 0;

        chargedBullet = Instantiate(ChargedBulletPrefab, Vector3.zero, ChargedBulletPrefab.transform.rotation) as GameObject;
        chargedBullet.GetComponent<Bullet>().Speed = ShootForce;
        chargedBullet.GetComponent<Bullet>().ThisPlayer = this.gameObject;
        chargedBullet.GetComponent<MeshRenderer>().material.color = transform.FindChild("Model").GetComponent<MeshRenderer>().material.color;
        chargedBullet.SetActive(false);

    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        

        //test sparo caricato
      /*  if (Input.GetAxis("Shoot2") != 0)        
            ChargedShoot();


        if (Input.GetAxis("Shoot2") == 0)
        {
            if (charging)
            {
                chargedBullet.SetActive(true);

                currentShootCharge = 0;
                canShoot = true;
            }
        }
        */

        //test dash su muro
       /* if (Input.GetButtonDown(buttonName: ("Fire1")))
            SuperDash(1 , 1);*/



        if (inAir)
        {
            WallDash(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetButtonDown(buttonName: ("Fire1")))
            {
                transform.position = inAirAim.transform.position;
                inAirAim.SetActive(false);
                inAir = false;
            }

        } 
    } 


    void OnCollisionExit(Collision col)
    {
        if (col.transform.CompareTag ("Player") && inSuperDash)                
            col.transform.GetComponent<Player>().TakeDamage(Damage);        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("EnvironmentWall") && inSuperDash)
        {
            transform.position = new Vector3(transform.position.x, 50, transform.position.z);
            inAirAim.transform.position = Vector3.zero;
            inAir = true;
        }
    }

    public void Move(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical) * MoveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
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
        if (!inAir)
        {
            if (shootTimer > FireRate && canShoot)
            {
                bulletArray[bulletIndex].transform.position = spawn.transform.position;
                bulletArray[bulletIndex].transform.rotation = transform.rotation;
                bulletArray[bulletIndex].SetActive(true);

                shootTimer = 0;
            }

            if (bulletIndex == bulletArray.Length)
                bulletIndex = 0;
        }
    }

    public void ChargedShoot()
    {
        if (!inAir)
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
                chargedBullet.SetActive(true);

                currentShootCharge = 0;
                canShoot = true;
            }
        }
    }


    public void Wall()
    {
        if(!inAir)
            StartCoroutine("ShieldBuff");
    }

    public IEnumerator ShieldBuff()
    {
        shield.SetActive(true);
        canShoot = false;
        yield return new WaitForSeconds(ShieldDeactive);
        shield.SetActive(false);
        canShoot = true;
    }

    public void Dash(float horizontal , float vertical)
    {
        Vector3 Direction = new Vector3(horizontal, 0, - vertical) * DashDistance;

        if (horizontal != 0 || vertical != 0 && inAir == false)
            rb.position = Vector3.Lerp(transform.position, Direction, Time.deltaTime);
    }

    public void SuperDash(float horizontal, float vertical)
    {

        Vector3 Direction = new Vector3(horizontal, 0, -vertical) * SuperDashDistance;

        if (horizontal != 0 || vertical != 0 && inAir ==false)
        {
            StartCoroutine("DashDamage");
           
            transform.position = Vector3.Lerp(transform.position, Direction, Time.deltaTime /3);
        }

    }

    private IEnumerator DashDamage()
    {
        inSuperDash = true;     
        yield return new WaitForSeconds(1);
        inSuperDash = false;
    }

    public void WallDash(float horizontal, float vertical)
    {
        
        inAirAim.SetActive(true);

        Vector3 position = new Vector3(horizontal, 0, vertical) * MoveSpeed * Time.deltaTime;

        inAirAim.transform.position = inAirAim.transform.position + position;
    }


    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
            gameObject.SetActive(false);
    }
}