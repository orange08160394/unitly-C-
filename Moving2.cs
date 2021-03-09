using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving3 : MonoBehaviour
{
    void Update()
    {
        float dx, dz;
        Vector3 oldPosition = gameObject.transform.position;
        dx = Input.GetAxis("Horizontal");
        dz = Input.GetAxis("Vertical");
        Vector3 newPosition = oldPosition + new Vector3(dx, 0, dz);
        gameObject.transform.position = newPosition;
    }
}
