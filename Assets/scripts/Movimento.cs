using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private Rigidbody2D myRigidbody;

    private float horizontal;
    [SerializeField]
    private float movimentoSpeed;

        private bool facingRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
     myRigidbody = GetComponent<Rigidbody2D>();
    movimentoSpeed = 10;

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        HandMovimento(horizontal);




    }

    private void FixedUpdate()
    {
        HandMovimento(horizontal);

        Flip(horizontal);
    }

    void HandMovimento(float horizontal)
    {
        myRigidbody.linearVelocity = new Vector2(horizontal * movimentoSpeed, myRigidbody.linearVelocity.y);
        Debug.Log(horizontal);
    }
    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 TheScale = transform.localScale;
            TheScale.x *= -1;
            transform.localScale = TheScale;
        }
    }
}
