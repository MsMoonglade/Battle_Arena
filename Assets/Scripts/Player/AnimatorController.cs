using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

    private Animator fire;

    void Awake()
    {
        fire = transform.FindChild("Model").transform.FindChild("Cannons").GetComponent<Animator>();
    }



   public void Play(string anim)
    {
        if (anim.Equals("shoot0"))
            fire.SetBool("FireLeft", true);
        if (anim.Equals("shoot1"))
            fire.SetBool("FireRight", true);

        
        StartCoroutine("Stop");
    }

    IEnumerator Stop()
    {
        yield return new WaitForEndOfFrame();
        fire.SetBool("FireLeft", false);
        fire.SetBool("FireRight", false);
    }

    
}
