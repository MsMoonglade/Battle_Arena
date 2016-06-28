using UnityEngine;
using System.Collections;

public class BouncePUP : BulletPUP {

    public int MaxBounce;
    public float BounceRange;

    private string[] value = new string[4];

    void Awake()
    {
        value[0] = Duration.ToString();
        value[1] = transform.name;
        value[2] = MaxBounce.ToString();
        value[3] = BounceRange.ToString();

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
