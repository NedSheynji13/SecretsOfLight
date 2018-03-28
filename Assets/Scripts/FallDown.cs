using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour {

    #region Variables
    public Animator Pillar;
    public Animator E;
    private BoxCollider Collider;
    public static bool felt = false;
    #endregion

    private void OnTriggerStay(Collider other)
    {
        E.SetBool("Entered", true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            AnimationControler.pull = true;
            E.SetBool("Entered", false);
            Pillar.SetBool("Pulled", true);
            Collider = transform.GetComponent<BoxCollider>();
            Collider.isTrigger = false;
            Collider.size = new Vector3(5, 1, 1);
            Collider.center = new Vector3(0.25f, -4.18f, -0.5f);
            felt = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        E.SetBool("Entered", false);
    }
}
