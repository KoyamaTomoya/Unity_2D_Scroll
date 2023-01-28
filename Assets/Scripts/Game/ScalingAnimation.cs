using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingAnimation : MonoBehaviour
{
    private Vector3 size;
    private bool once;

    [SerializeField]
    private float scalingSpeed;

    [SerializeField]
    private float minSize;

    [SerializeField]
    private float maxSize;

    // Start is called before the first frame update
    void Start()
    {
        once = false;
        size = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (size.x < maxSize && !once)
        {
            size.x += (Time.deltaTime * scalingSpeed);
        }
        else { once = true; }

        if (size.x > minSize &&once)
        {
            size.x -= (Time.deltaTime * scalingSpeed);
        }
        else { once = false; }

        transform.localScale = new Vector3(size.x, size.x, size.x);
    }
}
