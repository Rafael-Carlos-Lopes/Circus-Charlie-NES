using UnityEngine;
using System.Collections;

public class InstantiateFireCircle: MonoBehaviour {

	[SerializeField]
	GameObject [] circles;
	int sort;

	[SerializeField]
	Transform player;

	bool canInstantiate = true;

	bool lost;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("CreateCircles", 3f, 3f);	
	}
	
	// Update is called once per frame
	void Update () {
		lost = player.GetComponent<Charlie> ().GetLost ();

		if (lost == false) {
			if (transform.position.x < 130) {
				transform.Translate (1 * Time.deltaTime, 0, 0);

				if (Vector3.Distance (transform.position, player.position) < 7.5f) {
					transform.Translate (2 * Time.deltaTime, 0, 0);
				}
			}
		}

		if (player.position.x >= 122) 
		{
			canInstantiate = false;
		}

		if (player.position.x < 122) 
		{
			canInstantiate = true;
		}
	}

	void CreateCircles()
	{
		if (lost == false) {
			if (canInstantiate == true) {
				sort = Random.Range (0, 5);
				if (sort == 0) {
					transform.position = new Vector2 (transform.position.x, -0.73f);
					GameObject g = (GameObject)Instantiate (circles [0], transform.position, Quaternion.identity);
				} else if (sort > 0) {
					transform.position = new Vector2 (transform.position.x, -0.99f);
					GameObject g = (GameObject)Instantiate (circles [1], transform.position, Quaternion.identity);
				}
			}
		}

	}

}
