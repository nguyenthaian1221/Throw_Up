using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFalling : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().grounded = true;
    }
}
