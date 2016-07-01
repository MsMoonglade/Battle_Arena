using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("ss");
           gameObject.GetComponent<UISprite>().enabled = true;
        }
    }

}
