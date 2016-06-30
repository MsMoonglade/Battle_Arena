using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public float ActiveTime = 3f;
    public float WallSpeed;

    private BoxCollider col;
    


    void Awake()
    {
        col = GetComponent<BoxCollider>();
    }
    void OnEnable()
    {
        col.enabled = true;
        StartCoroutine("Deactive");
        StartCoroutine("Up");
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(ActiveTime);
        col.enabled = false;
        StartCoroutine("Down");
    }

    IEnumerator Up()
    {
        while(transform.localScale.y < 2)
        {
            transform.localScale = transform.localScale + new Vector3(0, 0.5f, 0) * Time.deltaTime * WallSpeed;
            yield return null;
        }
    }

    IEnumerator Down()
    {
        while(transform.localScale.y > 0)
        {
            transform.localScale = transform.localScale - new Vector3(0, 0.5f, 0) * Time.deltaTime * WallSpeed;
            yield return null;
        }
        gameObject.SetActive(false);

    }
	
}
