using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public float velocityx = 10;
    public float velocityY = 10;
    public float Salto = 25; 
    public int VecesSalta = 0;
    public int  totalvidas=3;

    public bool tocarEscalera=false;

    private SpriteRenderer sr;    
    private Animator animator;
    private Rigidbody2D rb;

    private Contador contador;

    private const string VidasJugador = "VidasJugador";
    private const string Puntaje = "Puntaje";


    public GameObject  KunaiA;
    public GameObject  KunaiB;


    private const int TREPAR= -1;
    
    private const int INICIAL= 0;

    private const int CORRER= 1;
    private const int AGACHAR= 2;
    private const int SALTAR= 3;    
    private const int KUNAI= 4;
    private const int VOLAR = 5;

    private const int MORIR = 8;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
      contador= FindObjectOfType<Contador>();

    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(INICIAL);  
        
        //SALTAR
        if(Input.GetKeyUp(KeyCode.Space))
        {   
            changeAnimation(SALTAR);
            if(VecesSalta < 2)
            {            
             rb.AddForce(Vector2.up * Salto, ForceMode2D.Impulse); //Salto              
             VecesSalta +=1;              
            }
        }

        //CORRER
         if(Input.GetKey(KeyCode.A))
        {
              rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
              sr.flipX = true;
              changeAnimation(CORRER);
         }
        if(Input.GetKey(KeyCode.D))
        {
              rb.velocity = new Vector2(velocityx, rb.velocity.y); 
              sr.flipX = false;
              changeAnimation(CORRER);
        }

        //AGACHAR
        if( Input.GetKey(KeyCode.S))
        { 
            if(sr.flipX == true )
            {
              rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
              sr.flipX = true;
             
              changeAnimation(AGACHAR);
            }
            else
            {
               rb.velocity = new Vector2(velocityx, rb.velocity.y); 
              sr.flipX = false;
              
              changeAnimation(AGACHAR); 
            }
        }   
        //PLANEAR

        if( Input.GetKey(KeyCode.C))
        { 
            if(sr.flipX == true )
            {
               rb.velocity = new Vector2(rb.velocity.x,-5); 
            sr.flipX = true;
            changeAnimation(VOLAR);
            }
            else
            {
            rb.velocity = new Vector2(rb.velocity.x,-5); 
            sr.flipX = false;
            changeAnimation(VOLAR);
            }
        } 
       
        if(Input.GetKey(KeyCode.W))
        {
            if(tocarEscalera==true)
            {
            rb.velocity = new Vector2(rb.velocity.x, velocityY); 
            sr.flipX = true;
            changeAnimation(TREPAR);
            }
            
        }
        
        //Dispara Kunai
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bullet = sr.flipX ? KunaiB : KunaiA;
            var position = new Vector2(transform.position.x,transform.position.y);
            var rotation = KunaiA.transform.rotation;
            Instantiate(bullet,position,rotation);           
        }          

    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("subir"))
        {            
            tocarEscalera = true;                                     
        }         

    }   
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("subir"))
        {            
            tocarEscalera = false;                                   
        }       
    } 

    private void OnCollisionEnter2D(Collision2D other)
    {        
        
        if(other.gameObject.CompareTag("Suelo"))
        {            
            if(VecesSalta == 2)
            {
                VecesSalta =0;
            }                        
        }
        
        if(other.gameObject.CompareTag("Zombi"))
        {            
           Destroy(other.gameObject);
            contador.paraVidas(-1);
            totalvidas -=1;   
            if(totalvidas==0)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }                 
        } 
    }   

     
    
}
