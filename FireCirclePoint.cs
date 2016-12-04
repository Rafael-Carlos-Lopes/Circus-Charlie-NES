using UnityEngine;
using System.Collections;

public class FireCirclePoint: MonoBehaviour {
	[SerializeField]
	GameObject Points500;
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col)
	{
			if (col.tag.Equals ("Charlie")) {
				Instantiate (Points500, transform.position, Quaternion.identity);
			}
	}
}
