using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


    [SerializeField]
    private float vertical;

    [SerializeField]
    private float horizontal;

    [SerializeField]
    private float speed;

    [SerializeField]
    public Vector2 mouseInput;

    private Vector2 mouseVelocity;

    private float damping;

    private float sensitivity;


    void Start ()
    {
        speed = 5;
        damping = 5;
        sensitivity = 2;
    }
	
	void Update ()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Vector2 direction = new Vector2(vertical, horizontal);

        transform.position += (transform.forward * direction.x * Time.deltaTime) + (transform.right * direction.y * Time.deltaTime);

        mouseVelocity.x = Mathf.Lerp(mouseVelocity.x, mouseInput.x, 1f / damping);
        transform.Rotate(Vector3.up * mouseInput.x * sensitivity);
    }
}
