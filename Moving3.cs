using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving2 : MonoBehaviour
{
    void Update()
    {
        float dx, dz;
        dx = Input.GetAxis("Horizontal");
        dz = Input.GetAxis("Vertical");
        gameObject.transform.position+=new Vector3(dx, 0, dz);
    }
}
