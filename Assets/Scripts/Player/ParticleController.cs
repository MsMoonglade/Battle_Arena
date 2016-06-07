using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    GameObject ps;

    ParticleSystem impact;
    ParticleSystem[] shoot;



    void Awake()
    {
        ps = transform.FindChild("PS").gameObject;

        impact = ps.transform.FindChild("PS_Impact").GetComponent<ParticleSystem>();

        shoot = new ParticleSystem[2];
        shoot[0] = ps.transform.FindChild("PS_ShootDX").GetComponent<ParticleSystem>();
        shoot[1] = ps.transform.FindChild("PS_ShootSX").GetComponent<ParticleSystem>();
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


    }

    public void Stop(string Particle)
    {
        if (Particle.Equals("impact"))
            impact.Stop();
    }
}
