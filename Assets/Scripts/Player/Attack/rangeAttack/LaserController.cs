using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
        StartCoroutine(StartStop());
    }

    public void Play(Vector3 from, Vector3 to)
    {
        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, from);
        lineRenderer.SetPosition(1, to);
    }

    IEnumerator StartStop()
    {
        yield return new WaitForSeconds(0.1f);
        Stop();
    }
    public void Stop()
    {
        lineRenderer.enabled = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
