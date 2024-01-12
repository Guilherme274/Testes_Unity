using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    [SerializeField] float velocidadeTiro;
    float horizontal;
    [SerializeField] Rigidbody2D rb;
    Player player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();

    }

   
    void FixedUpdate()
    {
        
    }

    private void Update()
    {
        horizontal = transform.position.x;
    }


    public void TiroSaiu()
    {
        if (player.lado == 1)
        {

            rb.velocity = new Vector2(horizontal * 2, rb.velocity.y);
        }

        if (player.lado == -1)
        {

            rb.velocity = new Vector2(horizontal * -2, rb.velocity.y);
        }
    }
}
