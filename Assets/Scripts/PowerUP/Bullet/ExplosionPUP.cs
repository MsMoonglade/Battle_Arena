using UnityEngine;
using System.Collections;

public class ExplosionPUP : BulletPUP
{
    public float ExplosionDamage;
    public float ExplosionRange;

    private string[] value = new string[4];

    void Awake()
    {
        value[0] = Duration.ToString();
        value[1] = transform.name;
        value[2] = ExplosionDamage.ToString();
        value[3] = ExplosionRange.ToString();

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
