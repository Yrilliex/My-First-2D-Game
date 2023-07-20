using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator anim;
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.gotHit)
        {
            PlayDeathAnim();
        }
    }

    public void PlayIdleAnim()
    {
        anim.Play("Player_Idle");
    }
    public void PlayMoveAnim()
    {
        anim.Play("Player_Walk");
    }
    public void PlayDeathAnim()
    {
        anim.Play("Player_Death");
    }
}
