using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;

    GameObject[] players;
    Player[] playersScript;
    Vector3 pos;
    //Variabili per Zoom
    public float MaxZoom;
    float maxDist;
    float minZoom;


    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playersScript = new Player[4];
        for (int i = 0; i < playersScript.Length; i++)
            playersScript[i] = players[i].GetComponent<Player>();

        LookFollow();

        maxDist = Vector3.Distance(players[0].transform.position, pos);
        minZoom = Camera.main.fieldOfView;
    }

    void Update()
    {
        LookFollow();
        Zoom();      
    }

    void LookFollow()
    {
        float x = (players[0].transform.position.x + players[1].transform.position.x + players[2].transform.position.x + players[3].transform.position.x) / 4;
        float z = (players[0].transform.position.z + players[1].transform.position.z + players[2].transform.position.z + players[3].transform.position.z) / 4;
        
        pos = new Vector3(x, 0, z);
       // transform.LookAt(look);
        transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0,transform.position.y,0), Time.deltaTime);                       
    }

    void Zoom()
    {
        float currentDistance = MaxDistPlayers();

        float currentZoom = (minZoom * currentDistance) / maxDist;
        if (currentZoom >= MaxZoom)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, currentZoom, Time.deltaTime);
    }

    float MaxDistPlayers()
    {
        float distance;
        //Assegno la distanza di un player a caso
        if (!playersScript[0].imDied)
            distance = Mathf.Abs(Vector3.Distance(players[0].transform.position, pos));
        else
            distance = 0f;

        //controllo quale è la più grande
        if(Mathf.Abs(Vector3.Distance(players[1].transform.position, pos)) > distance && !playersScript[1].imDied)
            distance = Vector3.Distance(players[1].transform.position, pos);

        if (Mathf.Abs(Vector3.Distance(players[2].transform.position, pos)) > distance && !playersScript[2].imDied)
            distance = Vector3.Distance(players[2].transform.position, pos);

        if (Mathf.Abs(Vector3.Distance(players[3].transform.position, pos)) > distance && !playersScript[2].imDied)
            distance = Vector3.Distance(players[3].transform.position, pos);


        return distance;
    }
}
