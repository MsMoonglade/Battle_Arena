using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    public float RangeExplosion;
    public float FallDownDmg;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Arena"))
        {
            Debug.Log("Fuggite, sciocchi");
            Damage();
            gameObject.SetActive(false);
        }
            
    }

    private void Damage()
    { 
        Collider[] col = Physics.OverlapSphere(transform.position, RangeExplosion);

        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].transform.CompareTag("Player") && !col[i].gameObject.GetComponent<Player>().imDied)            
                col[i].SendMessage("TakeDamage", FallDownDmg);          
        }
    }
}
