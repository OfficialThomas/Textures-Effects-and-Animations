using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float _moveSpeed = 1;
    public GameObject _bullet;
    private CharacterController _characterController;
    private Camera _currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        //https://docs.unity3d.com/ScriptReference/Cursor-lockState.html
        Cursor.lockState = CursorLockMode.Confined;

        _characterController = GetComponent<CharacterController>();

        _currentCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, transform.position + transform.forward*2f, transform.rotation);

        }

        if (Input.GetButton("Fire2"))
        {
            Ray ray = new Ray(transform.position + transform.up, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Wall"))
                {
                    hit.collider.gameObject.transform.localScale *= 0.99f;

                }
            }
        }

        //rotate
        Vector3 cameraDirection = _currentCamera.transform.forward;
        cameraDirection.y = 0;
        transform.LookAt(transform.position + cameraDirection);

        //movement
        Vector3 movement = _currentCamera.transform.right * Input.GetAxis("Horizontal") + _currentCamera.transform.forward * Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1);
        movement *= _moveSpeed * Time.deltaTime;
        _characterController.SimpleMove(movement);

    }

}
