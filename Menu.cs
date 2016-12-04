using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour {

	[SerializeField]
	GameObject startTxt;

	[SerializeField]
	AudioSource startSound;

	bool pressed;
	float contador;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		Debug.Log (contador);
		Debug.Log (startTxt.activeInHierarchy);

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			pressed = true;
			startSound.Play ();
		}

		if (pressed == true) 
		{
			contador += Time.deltaTime;
			Invoke ("Iniciar", 3f);
		}

		if (contador >= 0.2f) 
		{
			if (startTxt.activeInHierarchy == false) 
			{
				startTxt.SetActive (true);
			}

			else if (startTxt.activeInHierarchy == true) 
			{
				startTxt.SetActive (false);
			}

			contador = 0;
		}
	}

	void Iniciar()
	{
		SceneManager.LoadScene("Fase1");
	}

}
