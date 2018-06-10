using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float turnSpeed=1;
    public bool isScreen;

    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    // Update is called once per frame
    void Update () {
        
        var h = Input.GetAxis("Mouse X");
        var v = Input.GetAxis("Mouse Y");

        if (!isScreen)
        {
            Screen.lockCursor = true;
            transform.RotateAround(transform.position, transform.right, -v * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, h * turnSpeed);

            //tremenda xapuza hulio
            Quaternion rotacion = transform.rotation;

            rotacion.y = Mathf.Clamp(transform.rotation.y, -0.7f, 0.7f);
            rotacion.x = Mathf.Clamp(transform.rotation.x, -0.2f, 0.3f);
            rotacion.z = 0;

            transform.rotation = rotacion;
        }
        else
        {
            Screen.lockCursor = false;
            
        }
    }

    public void changeState()
    {
        isScreen= !isScreen;
    }
}
