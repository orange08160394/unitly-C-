using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz; dx = Input.GetAxis("Horizontal"); 
        dz = Input.GetAxis("Vertical"); 
        gameObject.transform.Translate(new Vector3(dx, 0, dz));
    }
}
