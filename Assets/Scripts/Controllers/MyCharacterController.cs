using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyCharacterController : MonoBehaviour
{
    [SerializeField] private CharacterController player;

    float speed = 10.0f;
    float gravity = -20f;

    [SerializeField] private Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public float jumpHeight = 2.0f;
    
    Vector3 velocity;
    Vector3 move = Vector3.zero;

	public float health = 100f;
	private float timer = 0;
	[SerializeField] private GameObject death;
	[SerializeField] private Scrollbar healthBar;

	void Start()
    {
        //hide the mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
		if (!MenuManager.pauseActive)
		{
			Cursor.lockState = CursorLockMode.Locked;
			if (health <= 0)
			{
				if (timer == 0)
				{
					death.SetActive(true);
				}
				timer += Time.deltaTime;
				if (timer >= 3)
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				}
			}

			//running
			if (Input.GetButton("Fire3") == true)
			{
				Debug.Log("Running");
				speed = 20f;
			}
			else
			{
				speed = 10f;
			}

			//ground check
			isGrounded = (Physics.CheckBox(new Vector3(groundCheck.position.x - 1f, groundCheck.position.y, groundCheck.position.z), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask) &&
					Physics.CheckBox(new Vector3(groundCheck.position.x, groundCheck.position.y, groundCheck.position.z - 1f), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask) &&
					Physics.CheckBox(new Vector3(groundCheck.position.x + 1f, groundCheck.position.y, groundCheck.position.z), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask) &&
					Physics.CheckBox(new Vector3(groundCheck.position.x, groundCheck.position.y, groundCheck.position.z + 1f), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask));

			//reset gravity if grounded
			if (isGrounded && velocity.y < 0)
			{
				velocity.y = -2f;
			}

			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			//movement
			move = transform.right * x + transform.forward * z;
			move.Normalize();
			player.Move(move * speed * Time.deltaTime);

			//gravity
			if (Input.GetButtonDown("Jump") && isGrounded)
			{
				velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
			}

			velocity.y += gravity * Time.deltaTime;

			player.Move(velocity * Time.deltaTime);

			/*if (Input.GetButton("Fire2") == true && isGrounded)
			{ //crouching
				Debug.Log("Crouching");
				//movement
				move = transform.right * x + transform.forward * z;
				move.Normalize();
				player.Move(move * speed * Time.deltaTime);

				velocity.y = 0;

				
				{
					Debug.Log("next step is safe");
					player.Move(velocity * Time.deltaTime);
				}
			}*/
		}

		//update health bar
		healthBar.size = health / 100f;
    }
}
