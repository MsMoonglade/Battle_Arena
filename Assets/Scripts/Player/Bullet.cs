using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float deactivationTime = 1;

    [HideInInspector]
    public float Damage;
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public GameObject ThisPlayer;

    private Player player;

    //stats PowerUP
    [HideInInspector]
    public int numberOfBounce;
    [HideInInspector]
    public float bounceRange;
    [HideInInspector]
    public float explosionRange;
    [HideInInspector]
    public float explosionDamage;

    void Start()
    {
        //StartCoroutine(Deactivate());
        player = ThisPlayer.GetComponent<Player>();
    }

    void FixedUpdate()
    {
        if (transform.gameObject.activeInHierarchy)        
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            StartCoroutine(Deactivate());
    }
  
    void OnTriggerEnter(Collider col)
    {

        if (!player.penetrationPuP && !player.explosionPuP && !player.bouncePuP)
        {
            if (col.transform.CompareTag("PlayerWall"))            
                gameObject.SetActive(false);            

            if (col.transform.CompareTag("Player"))
            {
                col.SendMessage("TakeDamage", Damage);
                ThisPlayer.SendMessage("HitScore", col.name);

                gameObject.SetActive(false);
            }
        }

        else if (player.penetrationPuP)
        {
            if (col.transform.CompareTag("Player"))
            {
                col.SendMessage("TakeDamage", Damage);
                ThisPlayer.SendMessage("HitScore", col.name);
            }
        }

        else if(player.explosionPuP)
        {
            if (col.transform.CompareTag("PlayerWall"))
                gameObject.SetActive(false);

            if (col.transform.CompareTag("Player"))
            {
                Explosion();
            }
        }

        else if (player.bouncePuP)
        {
            if (col.transform.CompareTag("PlayerWall"))
                gameObject.SetActive(false);

            if (col.transform.CompareTag("Player"))
            {
                col.SendMessage("TakeDamage", Damage);
                ThisPlayer.SendMessage("HitScore", col.name);

                Bounce();
            }
        }
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(deactivationTime);

        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);

     //   StopAllCoroutines();
    }

    private void Bounce()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, bounceRange);

        for (int i = 0; i < collider.Length; i++)
        {
            if (collider[i] != player.GetComponent<Collider>() && collider[i].transform.CompareTag("Player") && collider[i].GetComponent<Player>().isGrunded)
            {
                transform.LookAt(collider[i].transform);
                numberOfBounce--;
                break;
            }
        }    

        if (numberOfBounce == 0)
            gameObject.SetActive(false);
    }

    private void Explosion()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, explosionRange);

        for (int i = 0; i < collider.Length; i++)
        {
            if (collider[i] != transform.GetComponent<Collider>() && collider[i].transform.CompareTag("Player"))
            {
                collider[i].SendMessage("TakeDamage", explosionDamage);
                ThisPlayer.SendMessage("HitScore", collider[i].name);
            }
        }

        gameObject.SetActive(false);
    }
}