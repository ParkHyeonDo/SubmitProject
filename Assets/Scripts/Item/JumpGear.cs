using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class JumpGear : MonoBehaviour
{
    public float JumpPower;
    Rigidbody rigidbody;

    private void OnCollisionEnter(Collision other)
    {
        rigidbody = other.collider.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.up * JumpPower, ForceMode.Impulse);
    }

}

