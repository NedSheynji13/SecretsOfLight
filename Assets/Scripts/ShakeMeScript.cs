using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMeScript : MonoBehaviour, IInteractable {

    public Animator Pillar;
    private Component[] scripts;



    public void Interact()
    {
        Pillar.SetBool("Pulled", true);
        Invoke("Sachte", 0.5f);


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    private void Sachte()
    {
        scripts = GetComponentsInChildren<AIController>();
        for (int i = 0; i < scripts.Length; i++)
        {
            scripts[i].GetComponent<AIController>().enabled = true;
        }
    }
}
