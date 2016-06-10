using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public UISlider[] HealthBar=new UISlider[4];
	public UISlider[] EnergyBar = new UISlider[4];
    public UILabel [] Score = new UILabel[4];

    private Player[] players;
	
	
	
	void Awake()
	{
		players = new Player[4];
		AssignPlayers ();

        for (int i = 0; i < Score.Length; i++)
        {
            Score[i].GetComponent<UILabel>();
        }
	}

	private void AssignPlayers()
	{
		players [0] = GameObject.Find ("Player1").GetComponent<Player> ();
		players [1] = GameObject.Find ("Player2").GetComponent<Player> ();
		players [2] = GameObject.Find ("Player3").GetComponent<Player> ();
		players [3] = GameObject.Find ("Player4").GetComponent<Player> ();
	}
	
	void Update () 
	{
		ScreenBarsUpdate();
        ScoreView();
	}


	void ScreenBarsUpdate()
	{
		HealthBar[0].value = players[0].currentHealth/players[0].stat.MaxHealth;
		HealthBar[1].value = players[1].currentHealth/players[1].stat.MaxHealth;
		HealthBar[2].value = players[2].currentHealth/players[2].stat.MaxHealth;
		HealthBar[3].value = players[3].currentHealth/players[3].stat.MaxHealth;
		
		EnergyBar[0].value = players[0].currentEnergy/players[0].stat.MaxEnergy;
		EnergyBar[1].value = players[1].currentEnergy/players[1].stat.MaxEnergy;
		EnergyBar[2].value = players[2].currentEnergy/players[2].stat.MaxEnergy;	
		EnergyBar[3].value = players[3].currentEnergy/players[3].stat.MaxEnergy;
	}

    void ScoreView()
    {
        Score[0].text = GameController.instance.Score[0].ToString();
        Score[1].text = GameController.instance.Score[1].ToString();
        Score[2].text = GameController.instance.Score[2].ToString();
        Score[3].text = GameController.instance.Score[3].ToString();
    }




}
