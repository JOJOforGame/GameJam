using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector2 windDirection = Vector2.right; // 风的方向，默认为右边
    public float windStrength = 10f; // 风的强度

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 将风力应用到物体上
        rb.AddForce(windDirection * windStrength, ForceMode2D.Force);
    }
}
