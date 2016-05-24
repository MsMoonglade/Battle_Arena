using UnityEngine;
using System.Collections;

public class SuperBullet : MonoBehaviour {
    public float Speed;
    public float ScaleValue;
    public float Damage;
    public float DeactivationTime = 5f;
    public float MaxScaleValue= 3;
    [HideInInspector]
    public bool charging;
    [HideInInspector]
    public GameObject ThisPlayer;

    private Collider thisCol;

    void Start()
    {
        thisCol = ThisPlayer.GetComponent<Collider>();
    }

   


    void FixedUpdate()
    {
        if(!charging)
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
        }
    }
    public void Charge()
    {
        if (transform.localScale.x < MaxScaleValue)
        {
            charging = true;
            transform.position += transform.forward * ScaleValue;
            transform.localScale += new Vector3(ScaleValue, ScaleValue, ScaleValue);
        }
    }

    public void Relase()
    {
        charging = false;
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
        charging = true;
    }
	
}
