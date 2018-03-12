using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour {

        //empty GameObject notwendig, script wird auf dieses gelegt. beim ausrichten der Ebenen: wenn man eine Ebene näher an der Kamera platziert bewegt sie sich schneller und umgekehrt

    public Transform[] backgrounds; //array für die ebenen
    private float[] parallaxScales;
    public float parallaxAmount = 1f; //muss über 0 sein damit Parallax scrolling angewand wird

    private Transform cam;
    private Vector3 previousCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    // Use this for initialization
    void Start ()
    {
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade zwischen currPos und targetPos
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, parallaxAmount * Time.deltaTime);

        }

        previousCamPos = cam.position;
	}
}
