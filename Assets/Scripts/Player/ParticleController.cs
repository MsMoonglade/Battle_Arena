using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    GameObject ps;
    GameObject psModel;
    //Particellare impatto
    GameObject impactGo;
    ParticleSystem impact;
    //Particellare sparo e carica
    ParticleSystem[] shoot;
    ParticleSystem charge;
    //Particellare Morte
    GameObject explosionGo;
    ParticleSystem explosion;
    //Particellare SuperDash
    GameObject superDashGo;
    ParticleSystem superDash;
    //Particellare Dash
    GameObject dashGo;
    ParticleSystem dash;



    void Awake()
    {
        ps = transform.FindChild("PS").gameObject;

        impactGo = ps.transform.FindChild("PS_Impact").gameObject;
        impact = ps.transform.FindChild("PS_Impact").GetComponent<ParticleSystem>();
        impactGo.transform.SetParent(null);

        explosionGo = ps.transform.FindChild("Ps_Explosion").gameObject;
        explosion = ps.transform.FindChild("Ps_Explosion").GetComponent<ParticleSystem>();
        explosionGo.transform.SetParent(null);

        superDashGo = ps.transform.FindChild("Ps_SuperDash").gameObject;
        superDash = superDashGo.GetComponent<ParticleSystem>();

        dashGo = ps.transform.FindChild("Ps_Dash").gameObject;
        dash = dashGo.GetComponent<ParticleSystem>();


        shoot = new ParticleSystem[2];
        shoot[0] = ps.transform.FindChild("PS_ShootDX").GetComponent<ParticleSystem>();
        shoot[1] = ps.transform.FindChild("PS_ShootSX").GetComponent<ParticleSystem>();
        //Particellari Modelli
        psModel = transform.FindChild("Model").transform.FindChild("Particellari").gameObject;
        charge = psModel.transform.FindChild("Ps_Glow").GetComponentInChildren<ParticleSystem>();
    } 

    void Start()
    {
        
    }

    public void Play(string Particle)
    {


        if (Particle.Equals("impact"))
        {
            impactGo.transform.position = new Vector3(transform.position.x, -6.5f, transform.position.z);
            impact.Play();
        }
        //effetto sparo
        if (Particle.Equals("shoot0"))
            shoot[1].Play();
        if (Particle.Equals("shoot1"))
            shoot[0].Play();
        //effetto morte
        if (Particle.Equals("explosion"))
        {
            explosionGo.transform.position = new Vector3(transform.position.x, -6.5f, transform.position.z);
            explosion.Play();
        }
        //effetto super dash
        if (Particle.Equals("superDash"))
        {
            superDashGo.transform.rotation = Quaternion.Inverse(transform.rotation);
            superDash.Play();
        }

        if (Particle.Equals("dash"))
        {
            dashGo.transform.rotation = Quaternion.Inverse(transform.rotation);
            dash.Play();
        }




        //Caricamento super colpo
        if (Particle.Equals("charge") && !charge.isPlaying)
            charge.Play();
       



    }

    public void Stop(string Particle)
    {
        if (Particle.Equals("impact"))
            impact.Stop();

        if(Particle.Equals("charge"))
           charge.Stop();


        if (Particle.Equals("superDash"))
            superDash.Stop();

        if (Particle.Equals("dash"))
            dash.Stop();
    }
}
