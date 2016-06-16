using UnityEngine;
using System.Collections;

public class PlayerGui : MonoBehaviour {

    public UISlider HealthBar;
    public UISlider EnergyBar;

    private Player player;
	private Quaternion rotation;
	private GameObject root;

    void Awake()
    {       
        player = transform.parent.gameObject.transform.parent.GetComponent<Player>();

		rotation = transform.rotation;
    }

    void Update()
    {

		transform.rotation = rotation;

        HealthBar.value = player.currentHealth / player.stat.MaxHealth;
        EnergyBar.value = player.currentEnergy / player.stat.MaxEnergy;
    }   
}
