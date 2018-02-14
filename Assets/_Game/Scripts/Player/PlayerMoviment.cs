using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {

    public float speed;
    private bool isWalk;
    private Vector2 stopping;
    private Animator anim;    
    public AudioSource audioBlock;
    public AudioSource audioWalking;
    public bool collision = false;
    //public float distanciaEntreSaidaGuerreiro;

    public GameObject target;
    private Vector3 positionTarget;

    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        if (isWalk == false)
        {
            audioWalking.Play();           
        }
        if (GameController.getCurrentState() != GAME_STATE.IN_EXPLORATION)
        {
            anim.SetBool("Walk", false);
            audioWalking.Stop();
        }
    }

    void Moviment()
    {
        if (GameController.getCurrentState() != GAME_STATE.IN_EXPLORATION)
            return;        
        
        isWalk = false;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");        
        if (horizontal > 0 || horizontal < 0)
        {
            transform.Translate(horizontal * Time.deltaTime * speed, 0, 0);
            isWalk = true;
            stopping = new Vector2(horizontal, transform.position.x);
        }

        if (vertical > 0 || vertical < 0)
        {            
            transform.Translate(0, vertical * Time.deltaTime * speed, 0);
            isWalk = true;
            stopping = new Vector2(transform.position.y, vertical);
        }        

        anim.SetFloat("PositionX", horizontal);
        anim.SetFloat("PositionY", vertical);
        anim.SetBool("Walk", isWalk);
        anim.SetFloat("StopX", stopping.y);
        anim.SetFloat("StopY", stopping.x);        
    }   

    void OnCollisionEnter2D(Collision2D outro) // cria o audio de colisão em objetos.
    {
        if (outro.transform.tag == "Block" && collision == false)
        {
            collision = true;
            audioBlock.Play();
            audioWalking.Stop();            
        }        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Block")
        {
            collision = false;
            audioWalking.Play();            
        }
    }

}
