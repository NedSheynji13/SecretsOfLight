using UnityEngine;

public class CameraPlayer2D : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 3;

    public Vector2 targetOffset;
    private Vector3 currPos;
  
    private void FixedUpdate()
    {   
        if(target != null)
        {
			currPos = target.position + new Vector3(0 , 0 , -10);
            currPos.y = Mathf.Max(currPos.y, 8);

            transform.position = Vector3.Lerp(transform.position, currPos, lerpSpeed * Time.deltaTime);
        }
    }
}

