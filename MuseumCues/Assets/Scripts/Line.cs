using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    private LineRenderer lineRenderer;

    public Transform origin;
    public Transform dest;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        //Vector3 offset = origin.up * (origin.localScale.y / 2f) * -1f;
        //Vector3 posOr = origin.position + offset; //This is the position

        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, dest.position);
    }

    void Update()
    {

    }

}
