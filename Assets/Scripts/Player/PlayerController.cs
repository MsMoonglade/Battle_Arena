using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Player[] players;


    void Awake()
    {
        players = new Player[2];
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i< temp.Length; i++)
        {
            players[i] = temp[i].GetComponent<Player>();
        }
    }
	
	void FixedUpdate () {
        
       if (GetAxis(1,"LeftRotationH") != 0 || GetAxis(1, "LeftRotationV") != 0 || GetAxis(1, "RightRotationH") != 0 || GetAxis(1, "RightRotationV") != 0 || GetAxis(1,"Shoot") != 0)
        {
            players[0].Move(GetAxis(1, "LeftRotationH"), GetAxis(1, "LeftRotationV"));
            players[0].Rotate(GetAxis(1, "RightRotationH"), GetAxis(1, "RightRotationV") * -1);
        }
        if (GetAxis(1, "Shoot") > 0.1)
            players[0].Shoot();
        if (GetAxis(1, "SuperShoot") > 0.1)
            players[0].SuperShoot(GetAxis(1, "SuperShoot"));
        if (GetButton(1, "Dash"))
            players[0].Dash();
        if (GetButtonDown(1, "Wall"))
            players[0].CreateWall();


        if (GetAxis(0, "LeftRotationH") != 0 || GetAxis(0, "LeftRotationV") != 0 || GetAxis(0, "RightRotationH") != 0 || GetAxis(0, "RightRotationV") != 0)
        {
            players[1].Move(GetAxis(0, "LeftRotationH"), GetAxis(0, "LeftRotationV"));
            players[1].Rotate(GetAxis(0, "RightRotationH"), GetAxis(0, "RightRotationV") * -1);
        }
        if (GetAxis(0, "Shoot") > 0.1)
            players[1].Shoot();
        if (GetAxis(0, "SuperShoot") > 0.1)
            players[1].SuperShoot(GetAxis(0, "SuperShoot"));
        if (GetButton(0, "Dash"))
            players[1].Dash();
        if (GetButtonDown(0, "Wall"))
            players[1].CreateWall();


    }

    bool GetButton(int player, string name)
    {
        return Rewired.ReInput.players.GetPlayer(player).GetButton(name);
    }

    bool GetButtonDown(int player, string name)
    {
        return Rewired.ReInput.players.GetPlayer(player).GetButtonDown(name);
    }

    float GetAxis(int player, string name)
    {
        return Rewired.ReInput.players.GetPlayer(player).GetAxis(name);
    }

}
