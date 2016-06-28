using UnityEngine;
using System.Collections;

public class SuperBullet : MonoBehaviour {
    public float[] Speed = new float[3];
    public float[] Damage = new float[3];
    public float[] Scale = new float[3];
    public float DeactivationTime;

    [HideInInspector]
    public string SuperShotSound = "S_SuperShot";
    public string AbsorbSound = "S_Absorb";
    public string FullSound = "S_Full";

    [HideInInspector]
    public bool isAbsorbing;
    [HideInInspector]
    public bool isFull;
    [HideInInspector]
    public bool isShot;

    [HideInInspector]
    public GameObject col;
    [HideInInspector]
    public GameObject ThisPlayer;
    [HideInInspector]
    public ParticleSystem partc;
    private GameObject particle;
    private float speed;
    private float damage;
    [HideInInspector]
    public float scale;
    [HideInInspector]
    public int shotID, absorbID, fullID;

    void Awake()
    {
        col = transform.FindChild("Collider").gameObject;
        partc = GetComponentInChildren<ParticleSystem>();       
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

        else if (collider.CompareTag("PlayerWall") && scale == 3)
        {
            Debug.Log("jeses");
            collider.gameObject.SetActive(false);
            partc.Stop();
            Disable();
        }
        else if (collider.CompareTag("PlayerWall") && scale != 3) { 
                    
                    Disable();
        }

        else if (collider.CompareTag("EnvironmentWall"))
        {
            Disable();
          
        }
            
    }

    void Move()
    {
        //metodo del movimento      
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void ScaleMetod()
    {
        //la scala del paricellare
            partc.startSize = scale;

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
                if (!isAbsorbing)
                {
                    absorbID = AudioManager.instance.PlaySoundWithID(AbsorbSound);
                    isAbsorbing = true;
                }
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
                if (!isFull)
                {
                    AudioManager.instance.StopSound(AbsorbSound, absorbID);
                    absorbID = -1;
                    fullID = AudioManager.instance.PlaySoundWithID(FullSound);
                    isAbsorbing = false;
                    isFull = true;
                }
                break;
        }
        
    }

    void Relase()
    {
        StartCoroutine(DisableCor());
    }

    IEnumerator DisableCor()
    {

        yield return new WaitForSeconds(DeactivationTime);
        Disable();

    }

    void Disable()
    {
        if (isShot)
        {

            AudioManager.instance.StopSound(SuperShotSound, shotID);
            shotID = -1;
            isShot = false;

        }

        col.SetActive(false);
        partc.gameObject.SetActive(false);
        partc.gameObject.SetActive(true);
        StopAllCoroutines();
    }
}
