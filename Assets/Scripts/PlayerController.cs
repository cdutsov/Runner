using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float playerFuel;
	public Boundary boundary; 
	private float playerSpeed;
	public float speed;
	public float playerJumpForce;
	public Vector3 movement;
	public int playerJumpBoosts;
	public float tilt;
	public Text fuelText;
	public Text jumpBoostsText;

	private Rigidbody rigidBody;
	public EnemieController enemyController;
	public static PlayerController player;

	private bool isGrounded = true;

	void Start ()
	{
		playerSpeed = speed;
		player = this;
		rigidBody = GetComponent<Rigidbody>();
		fuelText.text = "Fuel " + playerFuel.ToString();
		jumpBoostsText.text = "Jump Boosts " + playerJumpBoosts.ToString();
	}

	void FixedUpdate ()
	{
		//Acceleration & movement of player. Fuel managing.
		float moveHorizontal = Input.GetAxis ("Horizontal");
		movement = new Vector3 (moveHorizontal, 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
		rigidBody.AddForce (movement * playerSpeed);



		if ((moveHorizontal != 0)&(playerFuel!=0) && isGrounded)
		{
			playerFuel--;
			playerSpeed = speed;
			fuelText.text = "Fuel " + playerFuel.ToString();
		}
		if (playerFuel == 0)
		{
			playerSpeed = 0;
			fuelText.text = "Out of Fuel! ";
		}
		if (!isGrounded)
			playerSpeed = 0;

		//Debug.Log("Fuel " + playerFuel);
	}

	void Update()
	{
		if(Input.GetKeyUp("up")&(playerJumpBoosts!=0))
		{

			rigidBody.AddForce(new Vector3(5.0f, 0.0f, 0.0f)*playerJumpForce);
			playerJumpBoosts--;
			jumpBoostsText.text = "Jump Boosts " + playerJumpBoosts.ToString();
			Debug.Log ("IN DA WOODS");
		}

	}
	//Killing zombuls on collision with a wait subroutine
	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "enemy")
		{
			Destroy (collider.gameObject, 1.5f);

		}

		if (collider.gameObject.tag == "Ground") {
			isGrounded = true;
			Debug.Log ("Hit something");
		}
	}

	void OnCollisionExit(Collision collider)
	{
		if (collider.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

	void OnCollisionStay(Collision collider) {
		if (collider.gameObject.tag == "Ground")
			isGrounded = true;
	}
}

