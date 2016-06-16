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

    void Start()
    {
        StartCoroutine(Deactivate());
    }

    void FixedUpdate()
    {
        if (transform.gameObject.activeInHierarchy)
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
  
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("PlayerWall"))
        {
            gameObject.SetActive(false);
         //   StopAllCoroutines();
        }

        if (col.transform.CompareTag("Player"))
        {
            col.SendMessage("TakeDamage", Damage);
            ThisPlayer.SendMessage("HitScore", col.name);

           // StopAllCoroutines();
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