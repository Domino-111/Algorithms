using UnityEngine;
using UnityEngine.Animations;

public class AnimatorCall : MonoBehaviour
{
    public Animator anim;
    private int hash;

    void Awake()
    {
        anim = GetComponent<Animator>();
        hash = Animator.StringToHash("Base Layer.Walking");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.Play(hash);
            print(hash);
        }
    }
}
