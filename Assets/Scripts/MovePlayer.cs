using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    BoxCollider2D mBoxCollider;
    Rigidbody2D rb;
    public float vel = 0;
    bool voltear = true; // Voltear a la derecha es verdadero, false izquierda
    SpriteRenderer playerRenderer;
    Animator playerAnimator;
    public float powerSalto;
    public bool mIsGrounded; // Boolean para ser seguro que tocamos el suelo

    // La metod que llamamos para saltar
    public void Jump()
    {
        mIsGrounded = false;
        rb.AddForce(Vector2.up * vel, ForceMode2D.Impulse);
    }

    // Verificamos las colisiones
    void OnCollisionEnter(Collision other)
    {
        // Hemos puesto un tag "Ground" sobre el suelo
        if (other.gameObject.CompareTag("Ground"))
        mIsGrounded = true;
    }




    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        mBoxCollider = GetComponent<BoxCollider2D>();
        mIsGrounded = true; // Si empezamos tocando al suelo


    }

    // Update is called once per frame
    void Update()
    {
        // Aquí es importante de verificar también si estamos tocando el suelo,
        // sino, el Game Object puede saltar a cualquier momento !
        if (Input.GetKeyDown(KeyCode.Space) && mIsGrounded == true)
            Jump();


        if (Input.GetAxis("Jump") > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0, powerSalto), ForceMode2D.Impulse);
        }
        float movehorizontal = Input.GetAxis("Horizontal");
        if (movehorizontal > 0 && !voltear)// si fue tecla derecha y player esta viendo a la izquierda voltear
        {
            Voltealo();
        } else if (movehorizontal < 0 && voltear)// si fue tecla izauierda Y player esta viendo a la derecha voltear
        {
            Voltealo();
        }
        rb.velocity = new Vector2(movehorizontal * vel, rb.velocity.y);
        playerAnimator.SetFloat("VelMov", Mathf.Abs(movehorizontal));



    }
    public void Voltealo()
    {
        voltear = !voltear;
        playerRenderer.flipX = !playerRenderer.flipX;
    }

}
