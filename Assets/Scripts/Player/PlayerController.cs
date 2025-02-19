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
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 velocity;

        if (inputX == 0 && inputY == 0)
            return velocity = Vector2.zero;

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

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animationController.Jump();
    }
}
