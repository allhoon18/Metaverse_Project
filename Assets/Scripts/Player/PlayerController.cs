using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rigidbody;

    AnimationController animationController;

    FollowCamera followCamera;

    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
        followCamera = GetComponent<FollowCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = MoveInput();
        JumpPlayer();
        followCamera.MoveCamera(transform.position);
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    Vector2 MoveInput()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 velocity = rigidbody.velocity;
        velocity = new Vector2(inputX, inputY).normalized * speed;

        animationController.Flip(inputX);

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
