using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    // This is the property we'll be setting with Injector.PropertyInject<>()
    public Rigidbody GravityRigidbody {
        get; set;
    }

    public float gravityForce = -9.81f;

    private void FixedUpdate() {
        // Just to be sure, check if GravityRigidbody was set correctly
        if(GravityRigidbody != null) {
            GravityRigidbody.AddForce(Vector3.up * gravityForce, ForceMode.Acceleration);
        }
    }
}
