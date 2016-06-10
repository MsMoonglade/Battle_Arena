using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    GameObject ps;
    GameObject psModel;

    GameObject impactGo;
    ParticleSystem impact;

    ParticleSystem[] shoot;
    ParticleSystem[] charge;

    GameObject explosionGo;
    ParticleSystem explosion;



    void Awake()
    {
        ps = transform.FindChild("PS").gameObject;

        impactGo = ps.transform.FindChild("PS_Impact").gameObject;
        impact = ps.transform.FindChild("PS_Impact").GetComponent<ParticleSystem>();
        impactGo.transform.SetParent(null);

        explosionGo = ps.transform.FindChild("Ps_Explosion").gameObject;
        explosion = ps.transform.FindChild("Ps_Explosion").GetComponent<ParticleSystem>();
        explosionGo.transform.SetParent(null);
       

        shoot = new ParticleSystem[2];
        shoot[0] = ps.transform.FindChild("PS_ShootDX").GetComponent<ParticleSystem>();
        shoot[1] = ps.transform.FindChild("PS_ShootSX").GetComponent<ParticleSystem>();
        //Particellari Modelli
        psModel = transform.FindChild("Model").transform.FindChild("Particellari").gameObject;
        charge = psModel.transform.FindChild("Ps_Glow").GetComponentsInChildren<ParticleSystem>();
    } 

    void Start()
    {
        
    }

    public void Play(string Particle)
    {


        if (Particle.Equals("impact"))
        {
            impactGo.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            impact.Play();
        }
        //effetto sparo
        if (Particle.Equals("shoot0"))
            shoot[1].Play();
        if (Particle.Equals("shoot1"))
            shoot[0].Play();

        if (Particle.Equals("explosion"))
        {
            explosionGo.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            explosion.Play();
        }



        //Caricamento super colpo
        if (Particle.Equals("charge1"))
            charge[2].Play();
        if(Particle.Equals("charge2"))
            charge[1].Play();
        if (Particle.Equals("charge3"))
            charge[0].Play();


    }

    public void Stop(string Particle)
    {
        if (Particle.Equals("impact"))
            impact.Stop();

        if(Particle.Equals("charge"))
            for (int i = 0; i < charge.Length; i++)
                charge[i].Stop();
    }
}
