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
                Collider[] collider = Physics.OverlapSphere(transform.position, 1);

                for (int i = 0; i < collider.Length; i++)
                {
                    if (collider[i] != transform.GetComponent<Collider>() && collider[i].transform.CompareTag("Player"))
                    {
                        collider[i].SendMessage("TakeDamage", Damage);
                        ThisPlayer.SendMessage("HitScore", collider[i].name);
                    }
                }

                gameObject.SetActive(false);
            }
        }

        else if (player.bouncePuP)
        {
            int numberOfBounce = 3;

            if (col.transform.CompareTag("PlayerWall"))
                gameObject.SetActive(false);

            if (col.transform.CompareTag("Player"))
            {
                col.SendMessage("TakeDamage", Damage);
                ThisPlayer.SendMessage("HitScore", col.name);

                Collider[] collider = Physics.OverlapSphere(transform.position, 6);

                transform.LookAt(collider[0].transform);
                numberOfBounce--;
            }

            if (numberOfBounce == 0)
                gameObject.SetActive(false);
        }
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(deactivationTime);

        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);

     //   StopAllCoroutines();
    }
}