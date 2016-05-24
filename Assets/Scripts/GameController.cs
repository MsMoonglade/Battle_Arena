using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	
	void Update () {
        if (Input.GetKey(KeyCode.Space))
            Application.LoadLevel(Application.loadedLevel);
	}
}
