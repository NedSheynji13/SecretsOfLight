using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(-0.6f, 6, 1);
    }
}
