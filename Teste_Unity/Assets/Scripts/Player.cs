using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float horizontal = 0;
    [SerializeField] float velocidade = 9f;
    [SerializeField] float forcaPulo = 0.003f;
    float vertical = 0;
    Animator anim;
    bool noChao = false;
    bool pulou = false;
    //[SerializeField] GameObject mensagem;
    bool entrou = false;
    int lado = 0;
    bool morreu = false;
    [SerializeField] Vector2 spawn;
    [SerializeField] GameObject prefabRobo;
    CinemachineVirtualCamera cineCamera;

       private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cineCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(horizontal * velocidade, rb.velocity.y);
    }

    private void Update()
    {
        anim.SetFloat("posicaoY", rb.velocity.y);
        vertical = transform.position.y;
        if(Input.GetButtonDown("Jump") && noChao)
        {
            rb.AddForce(Vector2.up * forcaPulo);
            
            anim.SetBool("pulou", true);

            noChao = false;

        }
        else
        {
            if(Input.GetButtonDown("Jump") && noChao == false && pulou == false)
            {
                rb.AddForce(Vector2.up * forcaPulo);

                anim.SetBool("pulou", true);

                pulou = true;
            }
        }

        if(horizontal >0)
        {
            lado = 1;
        }
        if(horizontal < 0)
        {
            lado = -1;
        }

        if(lado != 0)
        {
            transform.localScale = new Vector2(lado, transform.localScale.y);
        }

        //if (Input.GetKeyDown(KeyCode.E) && entrou)
        //{
        //    mensagem.SetActive(true);
        //}
        

            horizontal = Input.GetAxisRaw("Horizontal");

       
         anim.SetFloat("posicaoX", Mathf.Abs(rb.velocity.x));
        
        
        if(morreu)
        {
            GameObject roboInstanciado = Instantiate(prefabRobo, spawn, Quaternion.identity);
            Destroy(gameObject);
            morreu = false;
            cineCamera.Follow = roboInstanciado.transform;
            
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.tag == "chao")
        {
            anim.SetBool("pulou", false);

            noChao = true;

            pulou = false;
            
        }

        if (collision.gameObject.tag == "serra")
        {    
            morreu = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.CompareTag("placa"))
        //{
        //    entrou = true;

        //}

        if (collision.CompareTag("acido"))
        {
            morreu = true;
        }

        
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        entrou = false;

        //mensagem.SetActive(false);
    }


}
