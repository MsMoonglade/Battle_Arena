using UnityEngine;
using System.Collections;

public class EnergyRegenPUP : StatsPUP
{
    public float EnergyRegen;
    public float EnergyTime;

    private float[] value = new float[3];

    void Awake()
    {
        value[0] = EnergyRegen;
        value[1] = EnergyTime;
        value[2] = Duration;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.SendMessage("EnergyRegen", value);
            transform.gameObject.SetActive(false);
        }
    }
}