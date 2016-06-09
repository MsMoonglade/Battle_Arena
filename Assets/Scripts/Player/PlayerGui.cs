using UnityEngine;
using System.Collections;

public class PlayerGui : MonoBehaviour {

    public UISlider HealthBar;
    public UISlider EnergyBar;

    private Player player;

    void Awake()
    {       
        player = transform.parent.gameObject.GetComponent<Player>();
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;

        HealthBar.value = player.currentHealth / player.MaxHealth;
        EnergyBar.value = player.currentEnergy / player.MaxEnergy;
    }   
}
