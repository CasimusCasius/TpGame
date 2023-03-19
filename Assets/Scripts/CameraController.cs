using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private float mouseSensivity = 100;
   Transform playerBody;

   float xRotation = 0f;

   private void Awake() {
    playerBody = transform.parent;
    //Cursor.lockState = CursorLockMode.Locked; // kursor znika
   }

    private void Update() {
    CameraRotation();
   }

   private void CameraRotation()
   {
    float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

    xRotation -= mouseY;

    xRotation = Mathf.Clamp(xRotation, -90f, 80f);

    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    playerBody.Rotate(Vector3.up * mouseX);
   }
}
