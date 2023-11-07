using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour
{
    Rigidbody2D rb;
    float velocidade = 12f;
    [SerializeField] Transform limiteEsq;
    [SerializeField] Transform limiteDir;
    int aleatorio;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        aleatorio = Random.Range(1, 2);
        if(aleatorio == 1)
        {
            rb.velocity = Vector2.right * velocidade;
        }
        else
        {
            rb.velocity = Vector2.left * velocidade;
        }
    }
    void Update()
    {
        if(transform.position.x >= limiteDir.position.x)
        {
            rb.velocity = Vector2.left * velocidade;
        }

        if (transform.position.x <= limiteEsq.position.x)
        {
            rb.velocity = Vector2.right * velocidade;
        }       
    }
}
