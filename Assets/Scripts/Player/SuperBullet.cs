using UnityEngine;
using System.Collections;

public class SuperBullet : MonoBehaviour {

    //Variabili pubbliche carica
    public float[] Speed = new float[3];
    public float[] Scale = new float[3];
    public float[] Damage = new float[3];
    public float[] DeactivationTime = new float[3];

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject playerSpawnPoint;

    private Player ThisPlayer;

    //Variabili Carica
    private float chargeValue;
    private float moveSpeed;
    private float scale;
    private float damage;
    private float deactivationTime;

    void Awake()
    {
        ThisPlayer = player.GetComponent <Player>();
    }
 
    void OnEnable()
    {
        //quando il proiettile viene attivato controlla la carica passata dal player e modifica i suoi valori
        if(chargeValue <= (ThisPlayer.SuperShootMaxTimeCharge / 3))
        {
            Debug.Log("1");
            moveSpeed = Speed[0];
            scale = Scale[0];
            damage = Damage[0];
            deactivationTime = DeactivationTime[0];
        }
        else if(chargeValue >= (ThisPlayer.SuperShootMaxTimeCharge / 3) && chargeValue < ThisPlayer.SuperShootMaxTimeCharge)
        {
            Debug.Log("2");
            moveSpeed = Speed[1];
            scale = Scale[1];
            damage = Damage[1];
            deactivationTime = DeactivationTime[1];
        }
        else if (chargeValue >= ThisPlayer.SuperShootMaxTimeCharge)
        {
            Debug.Log("3");
            moveSpeed = Speed[2];
            scale = Scale[2];
            damage = Damage[2];
            deactivationTime = DeactivationTime[2];
        }

        //lo posiziono nello spawnpoint 
        transform.position = playerSpawnPoint.transform.position + (playerSpawnPoint.transform.forward * scale)/2 ;
        transform.rotation = playerSpawnPoint.transform.rotation;
        transform.localScale = new Vector3(scale, scale, scale);
        StartCoroutine("Disable");
    }

    void FixedUpdate()
    {
        if(transform.gameObject.activeInHierarchy)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.SendMessage("TakeDamage", damage);          
        }
    }

    public void ShootStart(float charge)
    {
        chargeValue = charge;     

        //lo attivo e quindi richiamo l'onEnable
        transform.gameObject.SetActive(true);     
       // Debug.Log("charge" + charge);
       // Debug.Log(chargeValue);
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(deactivationTime);
        gameObject.SetActive(false);
    }
	
}
