using UnityEngine;
using System.Collections;

public class FireCircle: MonoBehaviour {

	GameObject player;

	bool lost = false;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Charlie");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player == null) 
		{
			player = GameObject.FindGameObjectWithTag ("Charlie");
		}
			
		lost = player.GetComponent<Charlie> ().GetLost ();

		if (lost == true) 
		{
			Destroy (gameObject);
		}

		transform.Translate (-1.5f * Time.deltaTime, 0, 0);

		if (transform.position.x < -9) 
		{
			Destroy (gameObject);
		}
	}
}
