using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Coroutine JumpisActive;

    private void FixedUpdate()
    {
        if (Mathf.Abs(AnimationControler.speed) > 0.05f)
            transform.Translate(new Vector3(AnimationControler.speed / 10, 0, 0));

        if (Input.GetKeyDown(KeyCode.Space))
            JumpisActive = StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        transform.GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(1.5f);
        transform.GetComponent<Rigidbody>().useGravity = true;
    }
}
