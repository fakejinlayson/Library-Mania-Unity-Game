using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupAnimation : MonoBehaviour
{
    [SerializeField] private float offset = 0.0f;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float maxHeight = 1.0f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        offset += speed * Time.deltaTime;
        float sinValue = Mathf.Sin(offset);
        float yOffset = Mathf.Clamp(sinValue, -1f, 1f) * maxHeight;
        transform.position = startPos + Vector3.up * yOffset;
    }

    // private float dotp(Vector3 a, Vector3 b)
    // {
    //     return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
    // }
}
