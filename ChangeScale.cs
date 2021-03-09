using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float s = Input.GetAxis("Mouse ScrollWheel"); Debug.Log(s); transform.localScale += new Vector3(s, s, s);
    }
}
