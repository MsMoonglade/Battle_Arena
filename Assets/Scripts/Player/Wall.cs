using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public float ActiveTime = 3f;

    void OnEnable()
    {
        StartCoroutine("Deactive");
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(ActiveTime);
        gameObject.SetActive(false);
    }
	
}
