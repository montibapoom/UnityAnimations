using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SmoothFollower : MonoBehaviour
{
    public Transform follower;
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity;

    private void OnValidate()
    {
        if (follower != null)
        {
            if (follower.position != offset)
            {
                follower.position = offset;
            }
        }
    }

    private void Update()
    {
        if (target != null)
        {
                var smoothPosition = Vector3.SmoothDamp(follower.position, target.position + offset, ref velocity, smoothTime);

                follower.position = smoothPosition;
        }
    }
}
