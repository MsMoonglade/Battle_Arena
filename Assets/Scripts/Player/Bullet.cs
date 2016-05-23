using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public float Damage;
    [HideInInspector]
    public float Speed;
    


    void FixedUpdate()
    {
        if (transform.gameObject.activeInHierarchy)
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void Update()
    {
        if (transform.gameObject.activeInHierarchy)
        {
            Debug.Log("SononAttivo");
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag ("EnvironmentWall"))
            gameObject.SetActive(false);

        if (col.transform.CompareTag("Shield"))
            gameObject.SetActive(false);

        if (col.transform.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            col.transform.GetComponent<Player>().TakeDamage(Damage);
        }

    }
}
