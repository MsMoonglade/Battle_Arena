using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject BulletPrefab;
    public float MaxHealth;
    public float MoveSpeed;
    public float ShootForce;
    public float FireRate;
    public float Damage;
    public float ShieldDeactive;
    public float DashDistance;

    [HideInInspector]
    public float CurrentHealth;

    private GameObject shield;
    private Rigidbody rb;
    
    private GameObject[] bulletArray;
    private GameObject spawn;    
    private float shootTimer;
    private int bulletIndex;
    private bool canShoot;

    void Awake()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody>();
        shield = transform.FindChild("Shield").gameObject;
        shield.SetActive(false);

        canShoot = true;

        bulletArray = new GameObject[30];
        for (int i = 0; i < 30; i++)
        {
            bulletArray[i] = Instantiate(BulletPrefab , Vector3.zero , BulletPrefab.transform.rotation) as GameObject;
            bulletArray[i].GetComponent<Bullet>().Damage = Damage;
            bulletArray[i].GetComponent<Bullet>().Speed = ShootForce;
            bulletArray[i].GetComponent<MeshRenderer>().material.color = transform.FindChild("Model").GetComponent<MeshRenderer>().material.color;
            bulletArray[i].SetActive(false);
        }
        spawn = transform.FindChild("Spawnpoint").gameObject;
        bulletIndex = 0;

    }

    void Update()
    {
        shootTimer += Time.deltaTime;     
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

    public void Shoot1()
    {
        if(shootTimer > FireRate && canShoot)
        {
            bulletArray[bulletIndex].transform.position = spawn.transform.position;
            bulletArray[bulletIndex].transform.rotation = transform.rotation;
            bulletArray[bulletIndex].SetActive(true);
            Debug.Log("Shoot");
            shootTimer = 0;
        }

        if (bulletIndex == bulletArray.Length)
            bulletIndex = 0;
    }

    public void Wall()
    {
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

        if (horizontal != 0 || vertical != 0)
            transform.position = Vector3.Lerp(transform.position, Direction, Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
            gameObject.SetActive(false);
    }
}
