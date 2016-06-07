using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    GameObject ps;
    GameObject psModel;

    ParticleSystem impact;
    ParticleSystem[] shoot;
    ParticleSystem[] charge;



    void Awake()
    {
        ps = transform.FindChild("PS").gameObject;

        impact = ps.transform.FindChild("PS_Impact").GetComponent<ParticleSystem>();

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
        Debug.Log(Particle);

        if (Particle.Equals("impact"))
            impact.Play();             

        if (Particle.Equals("shoot0"))
            shoot[1].Play();
        if (Particle.Equals("shoot1"))
            shoot[0].Play();

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
