using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public GameObject Head;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        Head.transform.eulerAngles = new Vector3(y, Head.transform.eulerAngles.y + y, 0);
    }
}
