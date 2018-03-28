using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour {

    #region Variables
    public Animator Pillar;
    private BoxCollider Collider;
    #endregion

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pillar.SetBool("Pulled", true);
            Collider = transform.GetComponent<BoxCollider>();
            Collider.isTrigger = false;
            Collider.size = new Vector3(5, 1, 1);
            Collider.center = new Vector3(0.25f, -4.18f, -0.5f);
        }
    }
}
