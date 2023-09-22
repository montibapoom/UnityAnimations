using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicAnimationBehaviour : MonoBehaviour
{
    public Animator animator;
    [Range(0.01f, 10f)]
    public float acceleration = 0.1f;
    [Range(0.01f, 10f)]
    public float deceleration = 1.0f;

    private float velocity = 0.0f;
    private int isWalkingHash;
    private int isRunningHash;
    private int velocityHash;
    private void Start()
    {
        isWalkingHash = Animator.StringToHash("isWalkingForward");
        isRunningHash = Animator.StringToHash("isRunning");
        velocityHash = Animator.StringToHash("Velocity");
    }

    void Update()
    {
        //var isRunning = animator.GetBool(isRunningHash);
        //var isWalking = animator.GetBool(isWalkingHash);
        var forwardPressed = Input.GetKey(KeyCode.W);
        var runPressed = Input.GetKey(KeyCode.LeftShift);

        if(forwardPressed)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if(!forwardPressed)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        velocity = Mathf.Clamp01(velocity);

        animator.SetFloat(velocityHash, velocity);

        //if(!isWalking && forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, true);
        //}

        //if(isWalking && !forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, false);
        //}

        //if(!isRunning & (forwardPressed && runPressed))
        //{
        //    animator.SetBool(isRunningHash, true);
        //}

        //if (isRunning & (!forwardPressed || !runPressed))
        //{
        //    animator.SetBool(isRunningHash, false);
        //}
    }
}
