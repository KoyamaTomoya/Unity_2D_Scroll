using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
    private const float ROT_SPEED = 60.0f;

    private float rot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rot -= Time.deltaTime * ROT_SPEED;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot);
    }
}
