using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velX = 10f;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movX;
        movX = Input.GetAxis("Horizontal");
        anim.SetFloat("Correr", Mathf.Abs(movX));
        rb.velocity = new Vector2(velX * movX, rb.velocity.y);

        if (Input.GetButtonDown("Fire2")) anim.SetTrigger("Apunta");

        if (movX < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (movX > 0) transform.localScale = new Vector3(1, 1, 1);

    }
}
