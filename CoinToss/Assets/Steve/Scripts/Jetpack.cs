using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    #region Variables
    [Header("Shared Movement Variables")]
    [SerializeField] private float moveSpeed;

    [Header("Player 1 Movement")]
    [SerializeField] private Rigidbody rb1;
    [SerializeField] private float thrust;
    [SerializeField] private float turnThrust;
    [SerializeField] private float thrustInput;
    [SerializeField] private Quaternion turnInput;



    private Vector3 moveInput1;

    [Header("Player 2 Movement")]
    [SerializeField] private Rigidbody rb2;
    private Vector3 moveInput2;

    #endregion
    #region Main Functions
    private void Update()
    {
        //Check to see if there is input from the keyboard
        CheckP2Movement();
    }

    private void FixedUpdate()
    {
        CheckP1Movement();
    }

    #endregion
    #region Movement Functions
    private void CheckP1Movement()
    {
        rb1.AddRelativeForce(Vector3.forward * thrustInput);
        thrustInput = Input.GetAxis("Vertical");

        rb1.AddTorque(turnInput);
        turnInput = Input.GetAxis("Horizontal");
    }

    private void CheckP2Movement()
    {
        moveInput2.x = Input.GetAxisRaw("Horizontal");
        moveInput2.z = Input.GetAxisRaw("Vertical");
        moveInput2.Normalize();
        rb2.velocity = moveInput1 * moveSpeed;
    }

    #endregion

}