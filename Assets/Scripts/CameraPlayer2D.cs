using UnityEngine;

public class CameraPlayer2D : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 3;

    public Vector3 targetOffset;
    private Vector3 currPos;
  
    private void FixedUpdate()
    {

        if (target != null)
        {
            currPos = target.position + targetOffset;
            //currPos.y = Mathf.Max(currPos.y, 8);
            Vector3 smooth = Vector3.Lerp(transform.position, currPos, lerpSpeed * Time.fixedDeltaTime);
            transform.position = smooth;
        }
    }
}

