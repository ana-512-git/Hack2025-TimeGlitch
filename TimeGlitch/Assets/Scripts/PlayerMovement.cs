using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool idle = true, walk_back = false, walk_front = false, walk_left = false, walk_right = false;
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
            animation.ResetTrigger("isWalkingLeft");
            animation.ResetTrigger("isWalkingRight");
            animation.SetTrigger("isIdle");
            idle = true;
            walk_back = walk_front = walk_left = walk_right = false;
        }
        
        // walk up or down
        if(vertical > 0 && !walk_back) {
            animation.ResetTrigger("isWalkingFront");
            animation.ResetTrigger("isIdle");
            animation.ResetTrigger("isWalkingLeft");
            animation.ResetTrigger("isWalkingRight");
            animation.SetTrigger("isWalkingBack");
            walk_back = true;
            idle = walk_front = walk_left = walk_right = false;
        }
        else    if(vertical < 0 && !walk_front) {
            animation.ResetTrigger("isWalkingBack");
            animation.ResetTrigger("isIdle");
            animation.ResetTrigger("isWalkingLeft");
            animation.ResetTrigger("isWalkingRight");
            animation.SetTrigger("isWalkingFront");
            walk_front = true;
            idle = walk_back = walk_left = walk_right = false;
        }

        // walk left or right
        if(horizontal > 0 && !walk_right) {
            animation.ResetTrigger("isIdle");
            animation.ResetTrigger("isWalkingLeft");
            animation.ResetTrigger("isWalkingFront");
            animation.ResetTrigger("isWalkingBack");
            animation.SetTrigger("isWalkingRight");
            walk_right = true;
            idle = walk_back = walk_left = walk_front = false;
        }
        else    if(horizontal < 0 && !walk_left) {
            animation.ResetTrigger("isIdle");
            animation.ResetTrigger("isWalkingRight");
            animation.ResetTrigger("isWalkingFront");
            animation.ResetTrigger("isWalkingBack");
            animation.SetTrigger("isWalkingLeft");
            walk_left = true;
            idle = walk_back = walk_right = walk_front = false;
        }
    }
}
