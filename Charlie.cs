using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Charlie: MonoBehaviour {

	Animator anim;
	Rigidbody2D rb2d;

	[SerializeField]
	Animator animLion;

	bool OnGround = false;

	BoxCollider2D bc;

	bool canMove = true;
	bool lost = false;
	bool pause = false;

	[SerializeField]
	TextMesh scoreTXT, bonusTXT, highTxt;
	
	int bonus = 5000;
	int score = 0;
	int highScore = 20000;
	float contador;

	bool fireCirlePoint;
	bool firePotPoint;

	[SerializeField]
	AudioSource jump,point,lose,background, win;

	[SerializeField]
	GameObject[] lives;

	[SerializeField]
	GameObject jogo, stage1, gameOver, stageText;

	Vector3 checkPoint;

	int lifeCount = 2;

	// Use this for initialization
	void Start () 
	{
		bc = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();	
		InvokeRepeating ("DiminuirBonus", 0.3f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		bonusTXT.text = "-" + bonus.ToString ();
		scoreTXT.text = "1P-" + score.ToString ();
		highTxt.text = "HI-" + highScore.ToString ();

		if (score > highScore) 
		{
			highScore = score;
		}

		if (lost == false) {	
			if (canMove == true)
				rb2d.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * 2.5f, rb2d.velocity.y);
		}

		if (lost == true) 
		{
			rb2d.velocity = new Vector2 (0, 0);
			rb2d.gravityScale = 0;
			contador += Time.deltaTime;
			anim.SetBool ("Stop", false);
		}

		if (contador > 3f) 
		{
			jogo.SetActive (false);
			stage1.SetActive (true);
			bonus = 5000;
			if (lifeCount < 0) 
			{
				gameOver.SetActive (true);
				stageText.SetActive (false);
			}
		}

		if (contador > 6) 
		{
			if (lifeCount < 0) 
			{
				SceneManager.LoadScene ("Menu");
			}

			stage1.SetActive (false);
			jogo.SetActive (true);
			lost = false;
			contador = 0;
			transform.position = checkPoint;
			rb2d.gravityScale = 1.2f;
			animLion.SetBool ("Idle", true);
			animLion.SetBool ("CanChange", true);
			anim.SetBool ("Stop", true);
			background.Play ();
			anim.SetBool ("CanChange", true);
		}

		if (OnGround == true) {
			if (Input.GetAxisRaw ("Horizontal") != 0 ) {
				animLion.SetBool ("Walking", true);
				animLion.SetBool ("Idle", false);
				anim.SetBool ("Walking", true);
				anim.SetBool ("Stop", false);
			}
			else
			{
				animLion.SetBool ("Idle", true);
				animLion.SetBool ("Walking", false);
				anim.SetBool ("Walking", false);
				anim.SetBool ("Stop", true);
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if(OnGround == true)
			{
			jump.Play ();
			OnGround = false;
			canMove = false;
			animLion.SetBool ("Walking", false);
			animLion.SetBool ("Idle", false);
			animLion.SetBool ("Jumping", true);
			anim.SetBool("Walking", false);
			anim.SetBool("Stop", true);
			rb2d.velocity = new Vector2(rb2d.velocity.x, 7.8f);
			bc.offset = new Vector2 (0, -0.3f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Ground")) 
		{
			if (fireCirlePoint == true) {
				score += 100;
				fireCirlePoint = false;
			}

			if (firePotPoint == true) 
			{
				score += 200;
				firePotPoint = false;
			}

			animLion.SetBool ("Jumping", false);
			OnGround = true;
			canMove = true;
			bc.offset = new Vector2 (0, -0.34f);
		}

		if (col.gameObject.tag.Equals ("Podium")) 
		{
			pause = true;
			score += bonus;
			bonus = 0;
			win.Play ();
			background.Stop ();
			anim.SetTrigger ("Win");
			animLion.SetBool ("Idle", true);
			animLion.SetBool ("Walking", false);
			animLion.SetBool ("Jumping", false);
			Invoke ("ReturnToMenu", 4f);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("Fire")) 
		{
			if (lifeCount >= 0) {
				lives [lifeCount].SetActive (false);
				lifeCount--;
			}
			animLion.SetBool("CanChange", false);
			animLion.SetTrigger ("Lose");
			anim.SetBool ("CanChange", false);
			anim.SetTrigger ("Lose");
			lost = true;
			lose.Play ();
			background.Stop ();
		}

		if (col.tag.Equals ("Point")) 
		{
			fireCirlePoint = true;

		}

		if (col.tag.Equals ("Point2")) 
		{
			firePotPoint = true;
		}

		if (col.tag.Equals ("Money")) 
		{
			point.Play ();
			score += 500;
			Destroy (col.gameObject);
		}

		if (col.tag.Equals ("Seed")) 
		{
			point.Play ();
			score += 5000;
			Destroy (col.gameObject);
		}

		if (col.tag.Equals ("Meter")) 
		{
			checkPoint = new Vector3 (col.transform.position.x, col.transform.position.y + 1, col.transform.position.z);
		}
	}

	void DiminuirBonus()
	{
		if (lost == false) 
		{
			if(pause == false)
			bonus -= 10;
		}
	}

	public bool GetLost()
	{
		return lost;
	}

	void ReturnToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
