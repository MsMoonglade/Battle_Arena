using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    GameObject ps;

    ParticleSystem impact;



    void Awake()
    {
        ps = transform.FindChild("PS").gameObject;

        impact = ps.transform.FindChild("PS_Impact").GetComponent<ParticleSystem>();
    }


    public void Play(string Particle)
    {
        if (Particle.Equals("impact"))
        {
            impact.Play();
            Debug.Log("qua");
        }
    }

    public void Stop(string Particle)
    {
        if (Particle.Equals("impact"))
            impact.Stop();
    }
}
