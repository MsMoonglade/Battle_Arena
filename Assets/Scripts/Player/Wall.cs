using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public float ActiveTime = 3f;

    

    void Awake()
    {
        
    }
    
    void OnEnable()
    {
        StartCoroutine("Deactive");
        StartCoroutine("Up");
        StartCoroutine("Down");
    }

    void OnDisable()
    {
        transform.localScale = new Vector3(1, 0, 1);
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(ActiveTime);
        gameObject.SetActive(false);       
    }

    IEnumerator Up()
    {
        while (transform.localScale.y < 1)
        {
           
            transform.localScale = transform.localScale + new Vector3(0,1,0) * Time.deltaTime;
            yield return null;
        }
        
    }

    IEnumerator Down()
    {
        yield return new WaitForSeconds(ActiveTime - 1);
        while (transform.localScale.y > 0)
        {
            transform.localScale = transform.localScale - new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null;
        }
    }
	
}
