using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookLineController : MonoBehaviour
{
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    public void Play(Vector3 from, Vector3 to)
    {
        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, from);
        lineRenderer.SetPosition(1, to);
    }

    public void Active()
    {
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
    }

    public void Stop()
    {
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
