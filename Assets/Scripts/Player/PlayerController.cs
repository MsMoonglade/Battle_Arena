using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Player[] players;


    void Awake()
    {
        players = new Player[4];
        AssignPlayers();
       
    }
	
	void FixedUpdate () {
        //player 1
        if (GetAxis(0,"LeftRotationH") != 0 || GetAxis(0, "LeftRotationV") != 0 || GetAxis(0, "RightRotationH") != 0 || GetAxis(0, "RightRotationV") != 0 || GetAxis(0,"Shoot") != 0)
        {
            players[0].Move(GetAxis(0, "LeftRotationH"), GetAxis(0, "LeftRotationV"));
            players[0].Rotate(GetAxis(0, "RightRotationH"), GetAxis(0, "RightRotationV") * -1);
        }

        if (GetAxis(0, "Shoot") > 0.1)
            players[0].Shoot();

        if (GetAxis(0, "SuperShoot") > 0.5f)
            players[0].SuperShoot();

        if (GetAxis(0, "SuperShoot") < 0.4f)        
            players[0].RelaseSuperShoot();

        if (GetButton(0, "Dash") && GetButton(0, "Wall") && !players[0].onSuperDash)
            players[0].SuperDash();

        if (GetButtonDown(0, "Dash") && !players[0].onDash && !GetButton(0, "Wall"))
            players[0].Dash() ;

        if (GetButtonDown(0, "Wall") && !players[0].onDash && !GetButton(0, "Dash"))
            players[0].CreateWall();

        //player 2
        if (GetAxis(1, "LeftRotationH") != 0 || GetAxis(1, "LeftRotationV") != 0 || GetAxis(1, "RightRotationH") != 0 || GetAxis(1, "RightRotationV") != 0)
        {
            players[1].Move(GetAxis(1, "LeftRotationH"), GetAxis(1, "LeftRotationV"));
            players[1].Rotate(GetAxis(1, "RightRotationH"), GetAxis(1, "RightRotationV") * -1);
        }

        if (GetAxis(1, "Shoot") > 0.1)
            players[1].Shoot();

        if (GetAxis(1, "SuperShoot") > 0.5f)
            players[1].SuperShoot();

        if (GetAxis(1, "SuperShoot") < 0.4f)        
            players[1].RelaseSuperShoot();

        if (GetButtonDown(1, "Dash") && GetButtonDown(1, "Wall"))
            players[1].SuperDash();

        if (GetButtonDown(1, "Dash") && !players[1].onDash && !GetButton(1, "Wall"))
            players[1].Dash();

        if (GetButtonDown(1, "Wall") && !players[1].onDash && !GetButton(1, "Dash"))
            players[1].CreateWall();

        //player 3
        if (GetAxis(2, "LeftRotationH") != 0 || GetAxis(2, "LeftRotationV") != 0 || GetAxis(2, "RightRotationH") != 0 || GetAxis(2, "RightRotationV") != 0)
        {
            players[2].Move(GetAxis(2, "LeftRotationH"), GetAxis(2, "LeftRotationV"));
            players[2].Rotate(GetAxis(2, "RightRotationH"), GetAxis(2, "RightRotationV") * -1);
        }

        if (GetAxis(2, "Shoot") > 0.1)
            players[2].Shoot();

        if (GetAxis(2, "SuperShoot") > 0.5f)
            players[2].SuperShoot();

        if (GetAxis(2, "SuperShoot") < 0.4f)
            players[2].RelaseSuperShoot();

        if (GetButtonDown(2, "Dash") && GetButtonDown(2, "Wall"))
            players[2].SuperDash();

        if (GetButtonDown(2, "Dash") && !players[2].onDash && !GetButton(2, "Wall"))
            players[2].Dash();

        if (GetButtonDown(2, "Wall") && !players[2].onDash && !GetButton(2, "Dash"))
            players[2].CreateWall();

        //player 4
        if (GetAxis(3, "LeftRotationH") != 0 || GetAxis(3, "LeftRotationV") != 0 || GetAxis(3, "RightRotationH") != 0 || GetAxis(3, "RightRotationV") != 0)
        {
            players[3].Move(GetAxis(3, "LeftRotationH"), GetAxis(3, "LeftRotationV"));
            players[3].Rotate(GetAxis(3, "RightRotationH"), GetAxis(3, "RightRotationV") * -1);
        }

        if (GetAxis(3, "Shoot") > 0.1)
            players[3].Shoot();

        if (GetAxis(3, "SuperShoot") > 0.5f)
            players[3].SuperShoot();

        if (GetAxis(3, "SuperShoot") < 0.4f)
            players[3].RelaseSuperShoot();

        if (GetButtonDown(3, "Dash") && GetButtonDown(3, "Wall"))
            players[3].SuperDash();

        if (GetButtonDown(3, "Dash") && !players[3].onDash && !GetButton(3, "Wall"))
            players[3].Dash();

        if (GetButtonDown(3, "Wall") && !players[3].onDash && !GetButton(3, "Dash"))
            players[3].CreateWall();

    }

    private void AssignPlayers()
    {
        players[0] = GameObject.Find("Player1").GetComponent<Player>();
        players[1] = GameObject.Find("Player2").GetComponent<Player>();
        players[2] = GameObject.Find("Player3").GetComponent<Player>();
        players[3] = GameObject.Find("Player4").GetComponent<Player>();
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
