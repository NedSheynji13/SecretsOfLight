using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {


    public float backgroundSize;
    public float parallaxSpeed;
    public bool parallax,scrolling;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCamPosX;
    
	// Use this for initialization
	void Start ()
    {
        
        cameraTransform = Camera.main.transform;
        lastCamPosX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);

            leftIndex = 0;
            rightIndex = layers.Length - 1;
        }

	}

    private void Update()
    {
        if (parallax)
        {
            float deltaX = cameraTransform.position.x - lastCamPosX;            //objekt mit der Delta der Kamera bewegen?? recherche nötig
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCamPosX = cameraTransform.position.x;

        if(scrolling)
        {
            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollingLeft();
            }
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollingRight();
            }
        }
    }


    private void ScrollingLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollingRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
