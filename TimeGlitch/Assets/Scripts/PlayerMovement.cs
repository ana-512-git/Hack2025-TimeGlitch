using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool idle = true, walk_back = false, walk_front = false;
    private Animator animation;

    void Awake() {
        animation = GetComponent<Animator>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal"), vertical = Input.GetAxis("Vertical");
        float moveX = horizontal * speed * Time.deltaTime;
        float moveY = vertical * speed * Time.deltaTime;
        transform.Translate(new Vector2(moveX, moveY));

        if(horizontal == 0 && vertical == 0 && !idle) {
            animation.ResetTrigger("isWalkingBack");
            animation.ResetTrigger("isWalkingFront");
            animation.SetTrigger("isIdle");
            idle = true;
            walk_back = walk_front = false;
        }

        if(vertical > 0 && !walk_back) {
            animation.ResetTrigger("isWalkingFront");
            animation.ResetTrigger("isIdle");
            animation.SetTrigger("isWalkingBack");
            walk_back = true;
            idle = walk_front = false;
        }
        else    if(vertical < 0 && !walk_front) {
            animation.ResetTrigger("isWalkingBack");
            animation.ResetTrigger("isIdle");
            animation.SetTrigger("isWalkingFront");
            walk_front = true;
            idle = walk_back = false;
        }
    }
}
