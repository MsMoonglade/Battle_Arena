using UnityEngine;
using System.Collections;

public class HealthRegenPUP : StatsPUP {

    public float HPRegen;
    public float HPTime;

    private float[] value = new float[3];

    void Awake()
    {
        value[0] = HPRegen;
        value[1] = HPTime;
        value[2] = Duration;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.SendMessage("HealthRegen", value);
            transform.gameObject.SetActive(false);
        }
    }
}
