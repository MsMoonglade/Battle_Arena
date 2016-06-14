using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;
    public float Speed;

    GameObject[] players;
    Player[] playersScript;
    Vector3 pos;
    //Variabili per Zoom
    public float MaxZoom;
    float maxDist;
    float minZoom;
    Vector3 offSet;


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

    void FixedUpdate()
    {
        LookFollow();
        Zoom();      
    }

    void LookFollow()
    {
        float x = (players[0].transform.position.x + players[1].transform.position.x + players[2].transform.position.x + players[3].transform.position.x) / 4;
        float z = (players[0].transform.position.z + players[1].transform.position.z + players[2].transform.position.z + players[3].transform.position.z) / 4;
        
        pos = new Vector3(x, 0, z);
        if (offSet == Vector3.zero)
            offSet = transform.position - pos;


        // transform.LookAt(look);
       // target.transform.position = pos;
        transform.position = Vector3.Lerp(transform.position, pos  + offSet, Time.deltaTime * Speed);                       
    }

    void Zoom()
    {
        float currentDistance = MaxDistPlayers();

        float currentZoom = (minZoom * currentDistance) / maxDist;
        if (currentZoom >= MaxZoom)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, currentZoom, Time.deltaTime * Speed);
    }

    float MaxDistPlayers()
    {
        float distance;
        //converto le pos con y a 0
        Vector3 posPl1 = new Vector3(players[0].transform.position.x, 0, players[0].transform.position.z);
        Vector3 posPl2 = new Vector3(players[1].transform.position.x, 0, players[1].transform.position.z);
        Vector3 posPl3 = new Vector3(players[2].transform.position.x, 0, players[2].transform.position.z);
        Vector3 posPl4 = new Vector3(players[3].transform.position.x, 0, players[3].transform.position.z);


        //Assegno la distanza di un player a caso
            distance = Mathf.Abs(Vector3.Distance(posPl4, pos));
       

        //controllo quale è la più grande
        if(Mathf.Abs(Vector3.Distance(posPl1, pos)) > distance)
            distance = Vector3.Distance(posPl1, pos);

        if (Mathf.Abs(Vector3.Distance(posPl2, pos)) > distance)
            distance = Vector3.Distance(posPl2, pos);

        if (Mathf.Abs(Vector3.Distance(posPl3, pos)) > distance)
            distance = Vector3.Distance(posPl3, pos);


        return distance;
    }
}
