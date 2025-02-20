using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed;

    Rigidbody2D rigidbody;

    [HideInInspector] public AnimationController animationController;

    FollowCamera followCamera;

    [HideInInspector] public Vector2 velocity;

    public Vector2[] returnPoint;

    PlayerInWater playerWaterEffect;

    [HideInInspector] public bool isLeft;

    RidableObject ridableObject;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
        followCamera = GetComponent<FollowCamera>();
        playerWaterEffect = GetComponent<PlayerInWater>();
        ridableObject = GetComponentInChildren<RidableObject>();

        PlayerReturn(SceneLoader.currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = MoveInput();
        JumpPlayer();
        followCamera.MoveCamera(transform.position);
        playerWaterEffect.OnWaterEffect();
        ridableObject.Riding();
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

        if (inputX != 0)
            isLeft = inputX < 0;

        animationController.Flip(isLeft);
        playerWaterEffect.Flip(isLeft);

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

    void PlayerReturn(SceneState scene)
    {
        switch(scene)
        {
            case SceneState.Main:
                transform.position = returnPoint[((int)SceneState.Main)];
                SceneLoader.currentScene = SceneState.Main;
                break;

            case SceneState.FlappyPlane:
                transform.position = returnPoint[((int)SceneState.FlappyPlane)];
                SceneLoader.currentScene = SceneState.Main;
                break;
        }
    }

}
