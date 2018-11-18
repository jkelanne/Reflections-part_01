using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    // Use this for initialization
    private void Awake() {
        Injector.InjectProperty<Rigidbody>(this.gameObject, this.GetComponent<Rigidbody>());
    }
}
