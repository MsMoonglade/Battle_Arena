using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public float NextKillTimer;

    private int consecutiveKill;
    private float killtimer;

    void Awake()
    {
        consecutiveKill = 0; 
    }

    public void KillTimerStart()
    {
        StartCoroutine(StartKillTimer());
    }

    private IEnumerator StartKillTimer()
    {
        killtimer += Time.deltaTime;

        yield return new WaitForSeconds(NextKillTimer);

        killtimer = 0;

    }



}
