using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRotator : MonoBehaviour
{
    public float ratateSpeed = 180.0f;
    public float moveSpeed = 2.0f;

    public float minHeight = 0.5f;
    public float maxHeight = 1.5f;
    float timeElapsed = 0.0f;
    private void Update()
    {
        timeElapsed += Time.deltaTime * moveSpeed;
        Vector3 pos;
        pos.x = transform.parent.position.x;
        pos.z = transform.parent.position.z;
        pos.y = minHeight + (1 - Mathf.Cos(timeElapsed)) * 0.5f * (maxHeight - minHeight);

        transform.position = pos;
        transform.Rotate(0, Time.deltaTime * ratateSpeed, 0);

    }
}
