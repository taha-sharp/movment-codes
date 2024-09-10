 jgusing System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movements : MonoBehaviour
{
	public float Speed = 3f;

	public float jump;

	private float moveVelocity;

	public int Score = 1;

	private bool grounded = true;

	public AudioClip CoinCollect;

	public GameObject obj;

	private Rigidbody2D stoprotate;
    
	private void Start()
	{
		for (int i = 1; i <= 5; i++)
		{
			this.obj = GameObject.FindGameObjectWithTag("Score" + i);
			this.obj.GetComponent<Renderer>().enabled = false;
		}
	}

	private void Update()
	{
		this.Moving();
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && this.grounded)
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.jump = 6f);
		}
		this.moveVelocity = 0f;
	}

	private void Awake()
	{
		this.stoprotate = base.GetComponent<Rigidbody2D>();
		this.stoprotate.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	private void Moving()
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			base.gameObject.GetComponent<Transform>().Translate(-1f * this.Speed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			base.gameObject.GetComponent<Transform>().Translate(1f * this.Speed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync(0);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Coins"))
		{
			other.gameObject.GetComponent<AudioSource>().Play();
			Object.Destroy(other.gameObject, 0.2f);
			this.Score++;
			this.obj = GameObject.FindGameObjectWithTag("Score" + this.Score);
			this.obj.GetComponent<Renderer>().enabled = true;
		}
	}
}
