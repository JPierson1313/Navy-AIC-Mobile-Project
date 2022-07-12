using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class MomentumIndicator : MonoBehaviour
{
    LineRenderer lr;

    [SerializeField, Range(0.1f, 3.0f)]
    float LineLength = 1.0f;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Draw momentum indictar
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, (Vector2)transform.position /*+ GetComponent<EntityInfo>().velocity.normalized*/ * transform.localScale * LineLength);
    }
}
