using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    private float horizontal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();  
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
    }
}
