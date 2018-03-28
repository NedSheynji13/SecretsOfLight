using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    public Animator anim;

    private bool jump, rand1, rand2, stop, turn;
    public static float Hspeed, speed;
    private float maxSpeed = 1;
    private Vector3 facedirection = new Vector3(0, 90, 0);
    private float yPosition = 6f;
    private float scaling = 20;

    void Update()
    {
        if (!jump && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            anim.SetBool("Jump", true);
            Invoke("ResetJump", 1.5f);
        }

        speed = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
        Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        if (Input.GetAxis("Horizontal") < 0)
            facedirection = new Vector3(0, -90, 0);
        else
            facedirection = new Vector3(0, 90, 0);

        if (Input.GetKey(KeyCode.W))
        {
            yPosition += 0.01f;
            scaling -= 0.05f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yPosition -= 0.01f;
            scaling += 0.05f;
        }

        if (!stop && speed > 0 && !Input.anyKey)
        {
            stop = true;
            anim.SetBool("StopBool", true);
            speed /= 4;
            if (speed < 0.2)
                speed = 0;
            Invoke("ResetStop", 0.2f);
        }

        if (!Input.anyKey)
        {

        }

        if (yPosition > 6.5f)
            yPosition = 6.5f;
        else if (yPosition < 4f)
            yPosition = 4f;

        if (scaling > 25)
            scaling = 25;
        else if (scaling < 15)
            scaling = 15;
        
        anim.SetFloat("WalkSpeed", speed);
    }

    void FixedUpdate()
    {
        transform.eulerAngles = facedirection;
        Debug.Log(Hspeed);
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, yPosition, transform.position.z), Time.deltaTime * 10);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * scaling, Time.deltaTime * 10);
    }

    void ResetStop()
    {
        anim.SetBool("StopBool", false);
        stop = false;
    }

    void ResetJump()
    {
        anim.SetBool("Jump", false);
        jump = false;
    }

    void PlayRandom1()
    {
        anim.SetBool("Random1", true);
        Invoke("ResetRandom", 2.1f);
    }

    void PlayRandom2()
    {
        anim.SetBool("Random2", true);
        Invoke("ResetRandom", 4.3f);
    }

    void ResetRandom()
    {
        anim.SetBool("Random1", false);
        anim.SetBool("Random2", false);
        rand1 = false;
        rand2 = false;
    }
}
