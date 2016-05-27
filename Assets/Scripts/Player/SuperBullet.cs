using UnityEngine;
using System.Collections;

public class SuperBullet : MonoBehaviour {
    public float[] Speed = new float[3];
    public float[] Damage = new float[3];
    public float[] Scale = new float[3];
    public float DeactivationTime;

    [HideInInspector]
    public GameObject col;
    [HideInInspector]
    public ParticleSystem[] partc;
    private GameObject particle;
    private float speed;
    private float damage;
    [HideInInspector]
    public float scale;

    void Awake()
    {
        col = transform.FindChild("Collider").gameObject;
        particle = transform.FindChild("Particle").gameObject;
        partc = new ParticleSystem[3];
        for(int i = 0; i < partc.Length; i++)
            partc[i] = particle.transform.GetChild(i).GetComponent<ParticleSystem>();
        
        
    }

    void Start()
    {
        col.SetActive(false);
    }
  
    void FixedUpdate()
    {
        Move();
        ScaleMetod();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void ScaleMetod()
    {
        Debug.Log("Scale  : " + scale);
        for (int i = 0; i < partc.Length; i++)
            partc[i].startSize = scale;
    }

    public void Charge(int charge)
    {
        switch (charge)
        {
            case 0:
                speed = Speed[0];
                scale = Scale[0];
                damage = Damage[0];
                Debug.Log(0);
                break;
            case 1:
                speed = Speed[1];
                scale = Scale[1];
                damage = Damage[1];
                Debug.Log(1);
                break;
            case 2:
                speed = Speed[2];
                scale = Scale[2];
                damage = Damage[2];
                Debug.Log(2);
                break;


        }
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(DeactivationTime);
        col.SetActive(false);
        for (int i = 0; i < partc.Length; i++)
            partc[i].Stop();
    }
}
