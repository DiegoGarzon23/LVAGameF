using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float vel = 0;
    bool voltear = true; // Voltear a la derecha es verdadero, false izquierda
    SpriteRenderer playerRenderer;
    Animator playerAnimator;
    public float powerSalto;
    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
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
