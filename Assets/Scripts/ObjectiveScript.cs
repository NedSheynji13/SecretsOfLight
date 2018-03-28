using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour ,IInteractable{

    public Animator Wusli;

    public void Interact ()
    {
        Wusli.SetBool("Triggerd", true);
       
        
    }
    private void Update()
    {


    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interact();

            Wusli.SetFloat("Distancce", Vector3.Distance(transform.position, other.transform.position));
        }
        }
        
    }


