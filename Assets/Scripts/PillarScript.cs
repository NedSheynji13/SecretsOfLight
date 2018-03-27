using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour , IInteractable{

    public SpriteRenderer Renderer;
    public Sprite[] sprites;
    private Sprite please;

	void Start()
	{
        Fill();
	}
    private void Fill(  )
    {
		sprites = new Sprite[20];
		for (int i = 0; i < sprites.Length; i++)
		{
            
            sprites[i] = please;
		}

	}

	public void Interact ()
    {

       

    }



	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
			Interact();


		}
	}


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        
        
        }
    }
}
