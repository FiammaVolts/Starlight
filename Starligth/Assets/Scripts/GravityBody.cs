using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour
{
    private GravityAtractor moon;

    private void Awake()
    {
        moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<GravityAtractor>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        moon.Attract(transform);
    }
}
