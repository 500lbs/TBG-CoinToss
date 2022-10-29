using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _kickBack;

    [Header("Thrust")]
    [SerializeField] private float _thrustSpeed = 1.0f;
    private Vector3 _thrust;
    [SerializeField] private bool _thrusting;

    [Header("Rotation")]
    [SerializeField] private float _turnSpeed;
    private Vector3 _rotation;


    private void Update()
    {
        CheckRotation();
    }

    private void FixedUpdate()
    {
        CheckThrust();
    }

    private void CheckRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rotation = Vector3.down;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            _rotation = Vector3.up;
        }

        else
        {
            _rotation = Vector3.zero;
        }

        transform.Rotate(_rotation * _turnSpeed * Time.deltaTime);
    }

    private void CheckThrust()
    {
        _thrusting = (Input.GetKey(KeyCode.W));

        if (_thrusting)
        {
            _rigidBody.AddForce(transform.forward * _thrustSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            Debug.Log("YOU TOUCHED THE WALLL");
            _rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            _rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;

            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            _rigidBody.AddForce(dir * _kickBack);
            _rigidBody.AddForce(transform.position * -_thrustSpeed);
        }
    }
}
