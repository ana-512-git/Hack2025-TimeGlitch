using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool idle = true;
    private bool[] walk = new bool[8];
    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    private int getDirection(float horizontal, float vertical) {
        if(horizontal < 0 && vertical > 0)  return 1;
        if(horizontal == 0 && vertical > 0) return 2;
        if(horizontal > 0 && vertical > 0)  return 3;
        if(horizontal < 0 && vertical == 0) return 4;
        if(horizontal > 0 && vertical == 0) return 5;
        if(horizontal < 0 && vertical < 0)  return 6;
        if(horizontal == 0 && vertical < 0) return 7;
        if(horizontal > 0 && vertical < 0)  return 8;
        return 0;
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal"), vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime));

        int direction = getDirection(horizontal, vertical);
        if(direction == 0 && !idle) {
            for(int i = 0; i < 8; i++) {
                anim.ResetTrigger("isWalk" + (i + 1));
                walk[i] = false;
            }

            anim.SetTrigger("isIdle");
            idle = true;
            return;
        }

        if(direction == 0)  return;

        if(!walk[direction - 1]) {
            for(int i = 0; i < 8; i++) {
                if(i != direction - 1) {
                    anim.ResetTrigger("isWalk" + (i + 1));
                    walk[i] = false;
                }
            }

            anim.ResetTrigger("isIdle");
            anim.SetTrigger("isWalk" + direction);
            walk[direction - 1] = true;
            idle = false;
        }
    }
}
