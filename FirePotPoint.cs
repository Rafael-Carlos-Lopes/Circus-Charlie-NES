using UnityEngine;
using System.Collections;

public class FirePotPoint: MonoBehaviour {
	[SerializeField]
	GameObject seed;

	int count;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerExit2D(Collider2D col)
	{
			if (col.tag.Equals ("Charlie")) {
			count += 1;

			if (count == 8) 
			{
				Instantiate (seed, transform.position, Quaternion.identity);
			}
			}
	}
}
