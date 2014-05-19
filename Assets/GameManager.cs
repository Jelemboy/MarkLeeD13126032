using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public GameObject ammobin;
	public GameObject bot;

	private Vector3 Spawnposition;

	void Start () {
        GameObject bluebot = GameObject.FindGameObjectWithTag("bluebot");
        GameObject ammopickup = GameObject.FindGameObjectWithTag("ammopickup");

        bluebot.renderer.material.color = Color.blue;
        ammopickup.renderer.material.color = Color.red;

		for(int i = 1; i <= 10; i++)
		{
			Spawnposition = new Vector3(Random.Range(-30.0f,30.0f),0,Random.Range(-30.0f,30.0f));
			ammobin = Instantiate(ammopickup, Spawnposition, Quaternion.identity) as GameObject;
			//ammopickup.y = 0;
		}
		for(int i = 1; i <= 5; i++)
		{
			Spawnposition = new Vector3(Random.Range(-30.0f,30.0f),0,Random.Range(-30.0f,30.0f));
			bot = Instantiate(bluebot, Spawnposition, Quaternion.identity) as GameObject;
		}

		bot.GetComponent<StateMachine>().SwitchState(new IdleState(bluebot, bot));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
