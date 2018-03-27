using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    public Animator anim;

    private bool jump, rand1, rand2;
    private float Hspeed, speed;
    private float maxSpeed = 1;
    private Vector3 facedirection = new Vector3(0, 90, 0);
    private float yPosition = 6f;
    private float scaling = 20;

    void Update()
    {
        if (!jump && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Random1", false);
            anim.SetBool("Random2", false);
            anim.SetBool("Jump", true);
            Invoke("ResetJump", 1.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Random1", false);
            anim.SetBool("Random2", false);
            facedirection = new Vector3(0, 90, 0);
            if (speed <= maxSpeed)
                speed += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Random1", false);
            anim.SetBool("Random2", false);
            facedirection = new Vector3(0, -90, 0);
            if (speed <= maxSpeed)
                speed += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Random1", false);
            anim.SetBool("Random2", false);
            yPosition += 0.1f;
            scaling -= 0.5f;
            if (Hspeed <= maxSpeed)
                Hspeed += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Random1", false);
            anim.SetBool("Random2", false);
            yPosition -= 0.1f;
            scaling += 0.5f;
            if (Hspeed <= maxSpeed)
                Hspeed += Time.deltaTime;
        }
        if (!rand1)
        {
            if (Random.value > 0.5f && !rand2)
            {
                rand1 = true;
                PlayRandom1();
            }
        }
        if (!rand2)
        {
            if (Random.value > 0.5f && !rand1)
            {
                rand2 = true;
                PlayRandom1();
            }
        }

        if (speed > 0)
            speed -= Time.deltaTime * 0.4f;

        if (Hspeed > 0)
            Hspeed -= Time.deltaTime * 0.4f;

        if (yPosition > 6.5f)
            yPosition = 6.5f;
        else if (yPosition < 4f)
            yPosition = 4f;

        if (scaling > 25)
            scaling = 25;
        else if (scaling < 15)
            scaling = 15;

        anim.SetFloat("WalkSpeed", Hspeed * 4);
        anim.SetFloat("WalkSpeed", speed * 4);
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(speed) > 0.05f)
            transform.Translate(new Vector3(0, 0, speed / 10));

        transform.eulerAngles = facedirection;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, yPosition, transform.position.z), Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * scaling, Time.deltaTime);
    }

    void ResetJump()
    {
        anim.SetBool("Jump", false);
        jump = false;
    }

    void PlayRandom1()
    {
        anim.SetBool("Random1", true);
        Invoke("ResetRandom1", 3.3f);
    }

    void PlayRandom2()
    {
        anim.SetBool("Random2", true);
        Invoke("ResetRandom2", 4.3f);
    }

    void ResetRandom1()
    {
        anim.SetBool("Random1", false);
        rand1 = false;
    }

    void ResetRandom2()
    {
        anim.SetBool("Random2", false);
        rand2 = false;
    }
}
