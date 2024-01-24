using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : NetworkBehaviour
{
    Rigidbody rb;
    [SerializeField] private float movementSpeed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y));
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        Move();
    }

    private void Move()
    {
        Vector2 move = InputManager.mouvementInput;
        rb.velocity = new Vector3(move.x * movementSpeed, rb.velocity.y, move.y * movementSpeed);
    }
}
