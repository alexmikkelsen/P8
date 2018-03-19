using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousebased : MonoBehaviour {

    private LineRenderer lineRenderer;

    public Transform origin;
    public Transform dest;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, dest.position);
    }

    void Update()
    {

    }

}