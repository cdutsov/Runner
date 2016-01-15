using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public PlayerController playerController;
	public float BackOffWhenFast = 0.05f;
	private Vector3 offset;
	public float smoothTime = 0.3f;
	private float prevPlayerSpeed = 0f;
	private float playerSpeed = 0f;
	private float currentVel = 0f;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void Update ()
	{
		float cameraZ = Mathf.SmoothDamp (prevPlayerSpeed, playerSpeed, ref currentVel, 200.0f);
		Vector3 cameraVelocity = playerController.getVectorSpeed();

		transform.position = new Vector3(player.transform.position.x + offset.x + 6.0f,
			player.transform.position.y + offset.y,
			- cameraZ * BackOffWhenFast - 15.0f);
		
		prevPlayerSpeed = playerSpeed;
		playerSpeed = playerController.getPlayerSpeed();
	}
}