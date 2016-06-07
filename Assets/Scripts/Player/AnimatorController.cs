using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {
    [HideInInspector]
    public Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
