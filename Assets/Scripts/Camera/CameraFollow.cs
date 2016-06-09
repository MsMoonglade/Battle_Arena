using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;

    GameObject[] players;
    Vector3 pos;
    //Variabili per Zoom
    public float MaxZoom;
    float maxDist;
    float minZoom;


    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
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
        transform.position = pos + new Vector3(0,transform.position.y,0);                       
    }

    void Zoom()
    {
        float currentDistance = MaxDistPlayers();

        float currentZoom = (minZoom * currentDistance) / maxDist;
        if (currentZoom >= MaxZoom)
            Camera.main.fieldOfView = currentZoom;
    }

    float MaxDistPlayers()
    {
        float distance;
        //Assegno la distanza di un player a caso
        distance = Mathf.Abs( Vector3.Distance(players[0].transform.position, pos));
        //controllo quale è la più grande
        if(Mathf.Abs(Vector3.Distance(players[1].transform.position, pos)) > distance)
            distance = Vector3.Distance(players[1].transform.position, pos);

        if (Mathf.Abs(Vector3.Distance(players[2].transform.position, pos)) > distance)
            distance = Vector3.Distance(players[2].transform.position, pos);

        if (Mathf.Abs(Vector3.Distance(players[3].transform.position, pos)) > distance)
            distance = Vector3.Distance(players[3].transform.position, pos);


        return distance;
    }
}
