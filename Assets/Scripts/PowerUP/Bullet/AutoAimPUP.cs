using UnityEngine;
using System.Collections;

public class AutoAimPUP : BulletPUP {

    public float MaxRange;

    private string[] value = new string[4];

    void Awake()
    {
        value[0] = Duration.ToString();
        value[1] = transform.name;
        value[2] = MaxRange.ToString();

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            //passo al player il nome del buff e la durata

            col.SendMessage("BulletPowerUp", value);
            transform.gameObject.SetActive(false);
        }
    }
}
