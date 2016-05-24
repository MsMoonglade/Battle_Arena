using UnityEngine;
using System.Collections;

public class SuperBullet : MonoBehaviour {
    public float Speed;
    public float ScaleValue;
    public float Damage;
    public float DeactivationTime = 5f;
    public float MaxScaleValue= 3;
    [HideInInspector]
    public bool fire;
    [HideInInspector]
    public GameObject ThisPlayer;
    [HideInInspector]
    public GameObject playerSpawn;

    private Collider thisCol;

    void Awake()
    {
        fire = false;
    }

    void Start()
    {
        thisCol = ThisPlayer.GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        if(fire)
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    void OnEnable()
    {
         StartCoroutine("Disable");
    }

    void OnDisable()
    {
        Restore();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && col != thisCol )
        {
            col.SendMessage("TakeDamage", Damage);

            transform.gameObject.SetActive(false);           
            Restore();
            fire = false;
        }
    }
    public void Charge()
    {
        if (transform.localScale.x < MaxScaleValue) 
        {         
           // transform.position += transform.forward * ScaleValue/2;         
            playerSpawn.transform.position += transform.forward * ScaleValue / 2;
            transform.localScale += new Vector3(ScaleValue, ScaleValue, ScaleValue);
        }


    }

    public void ShootStart()
    {
        fire = true;
    }

    public void Restore()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(DeactivationTime);
        Restore();
        gameObject.SetActive(false);
        fire = false;
    }
	
}
