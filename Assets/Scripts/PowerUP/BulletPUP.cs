using UnityEngine;
using System.Collections;

public class BulletPUP : StatsPUP
{
    private string[] value = new string[2];

    void Awake()
    {
        value[0] = Duration.ToString();
        value[1] = transform.name;
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
