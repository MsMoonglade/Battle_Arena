using UnityEngine;
using System.Collections;

public class BulletPUP : MonoBehaviour
{
    public float StayOnFloor;
    public float Duration;
    public float RotSpeed;
 

    void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(StayOnFloor);

        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);
    } 

    void Update()
    {
        if (transform.position.y <= -5)
            transform.Rotate (Vector3.up , RotSpeed);
    }
}
