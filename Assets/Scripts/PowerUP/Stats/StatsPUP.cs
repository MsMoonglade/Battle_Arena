using UnityEngine;
using System.Collections;

public class StatsPUP : MonoBehaviour {

    public float StayOnFloor;
    public float Duration;

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

}
