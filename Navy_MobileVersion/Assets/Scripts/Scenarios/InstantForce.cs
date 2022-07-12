using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InstantForce : MonoBehaviour
{
    [SerializeField, Tooltip("Force applied to GameObject")]
    Vector2 force;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(force);
        Destroy(this);
    }
}
