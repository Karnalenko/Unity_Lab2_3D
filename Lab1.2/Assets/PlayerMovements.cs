using System;
using UnityEngine;
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [NonSerialized] public float rotationSpeed = 90f;
    private float gravity = -20f;
    public float jumpHeight = 15f;
    public CharacterController characterController;
    Vector3 movementVector;
    Vector3 rotationVector;
    void Start() { }
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        if (characterController.isGrounded)
        {
            movementVector = transform.forward * movementSpeed * verticalInput;
            rotationVector = transform.up * rotationSpeed * horizontalInput;
            if (Input.GetButtonDown("Jump")) { movementVector.y = jumpHeight; }
        }
        movementVector.y += gravity * Time.deltaTime;
        characterController.Move(movementVector * Time.deltaTime);
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}