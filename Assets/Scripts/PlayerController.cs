using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rigidbody;

    AnimationController animationController;

    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = MoveInput();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    Vector2 MoveInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 velocity = rigidbody.velocity;
        velocity = new Vector2(inputX, inputY).normalized * speed * Time.deltaTime;

        return velocity;
    }

    void MovePlayer()
    {
        if (rigidbody == null)
            return;
            
        rigidbody.velocity = velocity;
        animationController.Move(velocity);

    }
}
