using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D physix;
    private Vector2 Physix2Move;
    [HideInInspector]
    public float speed = 10;

    // Use this for initialization
    void Start()
    {
        physix = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physix2Move.x = Input.GetAxisRaw("Horizontal") * speed;
        Physix2Move.y = physix.velocity.y;
        physix.velocity = Physix2Move;
    }
}
