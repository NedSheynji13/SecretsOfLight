using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public Transform pos;

    int mcs;
    private void Start()
    {
        
    }
    public void StartGame()
    {

        SceneManager.LoadScene("MainMenuFinal");
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            
            other.GetComponent<AIController>().enabled = false;
            other.gameObject.transform.position = Vector3.Lerp(transform.position, pos.position, 0.005f);
        }
       
    }

   
}
