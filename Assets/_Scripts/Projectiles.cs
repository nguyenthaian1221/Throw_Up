using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (hasHit == false)
        {
            TrackMovement();  
        }

    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(CoreGameplay.Instance.windForce, 0));
    }

    private void TrackMovement()
    {
        Vector2 dir = rb.velocity;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }

}
