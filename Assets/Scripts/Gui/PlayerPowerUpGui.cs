using UnityEngine;
using System.Collections;

public class PlayerPowerUpGui : MonoBehaviour {
	
	public UISprite[] icon;


    private bool deactive;
    private float timer;
    private float deactiveAfter;

	void Awake()
	{
		icon = new UISprite[transform.childCount];

		for (int i = 0; i < icon.Length; i ++) 
		{
			icon[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<UISprite>();
			icon[i].enabled = false;
		}
	}

    void Start()
    {
        deactive = false;

    }


    void Update()
    {
        DeactiveIcon();       
    }

	public void Change(string name , float timer)
	{
        Debug.Log(icon.Length);

		for (int i = 0; i < transform.childCount ; i ++) 
		{ 
			if(icon[i].name == name)
			{
                Debug.Log("comparo");
                icon[i].enabled = true;
                deactive = true;
                deactiveAfter = timer;
                break;
			}
		}
	}

    private void DeactiveIcon()
    {
        if (deactive)
            timer += Time.deltaTime;

        if (timer >= deactiveAfter)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                icon[i].enabled = false;                
            }

            deactive = false;
            timer = 0;
            deactiveAfter = 0;
        }


    }
}
