using UnityEngine;
using System.Collections;

public class b_Camera : MonoBehaviour
{

    Camera m_Camera;
    float Distance;
    void Start()
    {
        m_Camera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                         m_Camera.transform.rotation * Vector3.up);
    }
}
