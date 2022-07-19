using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovementScript : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
	float maxSpeed = 1f;

    [SerializeField, Range(0f, 10f)]
	float maxAcceleration = 1f;

    [SerializeField, Range(0f, 10f)]
	float mouseSensitivity = 3f;

    Vector3 velocity;

    float xMouse;
    float yMouse;

	void Awake ()
    {
		//Initalise 
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();

        UpdateRotation();

    }

    private void UpdatePosition()
    {
        //Max difference calculated beforehand
        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        Vector2 playerInput;
	    playerInput.x = Input.GetAxis("Horizontal");
	    playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        Vector3 desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;

        //Rotate to match facing
        desiredVelocity = gameObject.transform.localRotation * desiredVelocity;

        //X axis
        if (velocity.x < desiredVelocity.x) {
			velocity.x =
				Mathf.Min(velocity.x + maxSpeedChange, desiredVelocity.x);
		}
		else if (velocity.x > desiredVelocity.x) {
			velocity.x =
				Mathf.Max(velocity.x - maxSpeedChange, desiredVelocity.x);
		}

        //Z axis
        if (velocity.z < desiredVelocity.z) {
			velocity.z = Mathf.Min(velocity.z + maxSpeedChange, desiredVelocity.z);
		}
		else if (velocity.z > desiredVelocity.z) {
			velocity.z = Mathf.Max(velocity.z - maxSpeedChange, desiredVelocity.z);
		}

	    //transform.localPosition += (velocity * Time.deltaTime); 
        gameObject.transform.position += velocity;
    }

    private void UpdateRotation()
    {
        if (Input.GetMouseButton(1))
        {
            xMouse += Input.GetAxis("Mouse X") * mouseSensitivity;// * Time.deltaTime;
            yMouse += Input.GetAxis("Mouse Y") * mouseSensitivity;// * Time.deltaTime;

            gameObject.transform.localRotation = (Quaternion.Euler(-yMouse, xMouse, 0));
        }

    }

}
