using UnityEngine;
using System.Collections;

public class SuperBullet : MonoBehaviour {
    public float[] Speed = new float[3];
    public float[] Damage = new float[3];
    public float[] Scale = new float[3];
    public float DeactivationTime;

    [HideInInspector]
    public string SuperShotSound = "S_SuperShot";


    [HideInInspector]
    public GameObject col;
    [HideInInspector]
    public GameObject ThisPlayer;
    [HideInInspector]
    public ParticleSystem[] partc;
    private GameObject particle;
    private float speed;
    private float damage;
    [HideInInspector]
    public float scale;
    [HideInInspector]
    public int shotID;

    void Awake()
    {
        col = transform.FindChild("Collider").gameObject;
        partc = GetComponentsInChildren<ParticleSystem>();       
    }

    void Start()
    {
        col.SetActive(false);

    }

    void FixedUpdate()
    {
        Move();
        ScaleMetod();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.SendMessage("TakeDamage", damage);
            ThisPlayer.SendMessage("HitScore", collider.name);          
        }

        if (collider.CompareTag("PlayerWall") && scale == Scale[3])
        {
            collider.gameObject.SetActive(false);
            Disable();
        }
        else if (collider.CompareTag("PlayerWall") && scale != Scale[3])
            Disable();

        if (collider.CompareTag("EnvironmentWall"))
            Disable();
    }

    void Move()
    {
        //metodo del movimento      
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void ScaleMetod()
    {
        //la scala del paricellare
       
        for (int i = 0; i < partc.Length; i++)
            partc[i].startSize = scale;

    }

    public void Charge(int charge)
    {
        //in base alla carica ho stats diverse
        switch (charge)
        {
            case 0:
                speed = Speed[0];
                scale = Scale[0];
                damage = Damage[0];
                
                break;
            case 1:
                speed = Speed[1];
                scale = Scale[1];
                damage = Damage[1];
                
                break;
            case 2:
                speed = Speed[2];
                scale = Scale[2];
                damage = Damage[2];

                break;
        }
        StartCoroutine(DisableCor());
    }

    IEnumerator DisableCor()
    {

        yield return new WaitForSeconds(DeactivationTime);
        Disable();

    }

    void Disable()
    {
        AudioManager.instance.StopSound(SuperShotSound, shotID);
        shotID = -1;
        col.SetActive(false);
        for (int i = 0; i < partc.Length; i++)
            partc[i].Stop();
        StopAllCoroutines();
    }
}
