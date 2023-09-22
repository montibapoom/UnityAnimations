using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TwoDimensionalAnimationStateController : MonoBehaviour
{
    private Animator animator;

    private float velocityZ = 0;
    private float velocityX = 0;

    public float acceleration = 2f;
    public float deceleration = 2f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    private int velocityZHash;
    private int velocityXHash;

    private void Start()
    {
        animator = GetComponent<Animator>();

        velocityZHash = Animator.StringToHash("Velocity Z");
        velocityXHash = Animator.StringToHash("Velocity X");
    }

    private void Update()
    {
        var forwardPressed = Input.GetKey(KeyCode.W);
        var leftPressed = Input.GetKey(KeyCode.A);
        var rightPressed = Input.GetKey(KeyCode.D);
        var runPressed = Input.GetKey(KeyCode.LeftShift);

        var currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;
        ChangeVelocity(forwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);
        LockOrResetVelocity(forwardPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);

        animator.SetFloat(velocityZHash, velocityZ);
        animator.SetFloat(velocityXHash, velocityX);
    }

    private void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocityZ > 0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        if (!leftPressed && velocityX < 0)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        if (!rightPressed && velocityX > 0)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
    }

    private void LockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        if (!forwardPressed && velocityZ < 0f)
        {
            velocityZ = 0;
        }

        if (!leftPressed && !rightPressed && velocityX != 0 && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0;
        }

        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;

            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;

            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity + 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity - 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }


        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;

            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
    }
}
