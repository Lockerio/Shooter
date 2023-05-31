using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Look : MonoBehaviour
{
    public float mouse_sensitivity = 100f;
    public Transform player_body;
    float x_rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouse_Y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        x_rotation -= mouse_Y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
            
        player_body.Rotate(Vector3.up * mouse_X);    
    
    }
}
