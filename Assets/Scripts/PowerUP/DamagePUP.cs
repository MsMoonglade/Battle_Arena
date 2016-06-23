using UnityEngine;
using System.Collections;

public class DamagePUP : StatsPUP{

    public float IncreasedDamage;

    private float[] value = new float[2];

    void Awake()
    {
        value[0] = IncreasedDamage;
        value[1] = Duration;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.SendMessage("DamagePUP", value);
            transform.gameObject.SetActive(false); 
        }
    }
}
