using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]float baseMoveSpeed = 12;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform groundChecker;
    CharacterController characterController;

    float moveSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        RaycastHit hit;
        Debug.DrawRay(groundChecker.position, transform.TransformDirection(Vector3.down)*0.4f);  // po odpaleni gry na scenie poka¿e siê zielona kreska 
                                                                                                // pokazuje jaki jest RayCast
        if (Physics.Raycast(groundChecker.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, layerMask))

        {
            string terraintType = hit.collider.gameObject.tag;

            switch (terraintType)
            {
                case "LowSpeed":
                    moveSpeed = baseMoveSpeed * 0.25f;
                    break;
                case "HighSpeed":
                 moveSpeed = baseMoveSpeed * 1.66f;
                    break;
                default:
                    moveSpeed = baseMoveSpeed;
                    break;
            }


        };

        Vector3 forward = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 strafe = transform.right * Input.GetAxis("Horizontal") * Time.deltaTime;

        Vector3 move = forward + strafe;
        characterController.Move(move *moveSpeed);
    }
}
