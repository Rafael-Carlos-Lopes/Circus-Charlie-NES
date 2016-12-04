using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	[SerializeField]
	GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player.transform.position.x >= 0) 
		{
			transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
		}
	}
}
