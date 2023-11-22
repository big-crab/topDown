using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private float horizontalMove, verticalMove;
    private Vector2 direction;

    [SerializeField] private Animator animator;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        direction.x = horizontalMove;
        direction.y = verticalMove;

        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }

        if(horizontalMove> 0)
        {
            Flip(1);
        }
        else if(horizontalMove < 0)
        {
            Flip(-1);
        }

        if(direction.magnitude > 0)
        {
            animator.SetBool("Running", true);
        }
        else if(direction.magnitude == 0)
        {
            animator.SetBool("Running", false);
        }
       
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    private void Flip(float flipDirection)
    {
        Vector2 scale = transform.localScale;
        scale.x = flipDirection;
        transform.localScale = scale;
    }
}
