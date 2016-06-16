using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public float Damage;
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public GameObject ThisPlayer;


    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), ThisPlayer.GetComponent<Collider>(), true);
    }

    void FixedUpdate()
    {
        if (transform.gameObject.activeInHierarchy)
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
  
    void OnTriggerEnter(Collider col)
    {    
        if (col.transform.CompareTag("PlayerWall"))
            gameObject.SetActive(false);

        if (col.transform.CompareTag("Player"))
        {
            col.GetComponent<Player>().TakeDamage(Damage , ThisPlayer) ; 
            gameObject.SetActive(false);            
        }

    }
}