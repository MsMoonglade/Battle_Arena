using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public float Damage;
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public GameObject ThisPlayer;

	public float deactivationTime =1;

    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), ThisPlayer.GetComponent<Collider>(), true);
    }

    void FixedUpdate()
    {
        if (transform.gameObject.activeInHierarchy)
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
		StartCoroutine (Deactivate ());
    }
  
    void OnTriggerEnter(Collider col)
    {    
        if (col.transform.CompareTag ("PlayerWall")) {
			gameObject.SetActive (false);
			StopAllCoroutines ();
		}

        if (col.transform.CompareTag("Player"))
        {
			ThisPlayer.SendMessage("HitScore", col.name);
			col.SendMessage("TakeDamage", Damage);
            gameObject.SetActive(false);            
			StopAllCoroutines();
        }

    }

	IEnumerator Deactivate(){

		yield return new WaitForSeconds (deactivationTime);

			if(this.gameObject.activeSelf)
				this.gameObject.SetActive(false);

		StopAllCoroutines();

	}
}