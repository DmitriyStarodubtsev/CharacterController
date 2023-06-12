using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowingCamera : MonoBehaviour
{
    [Header("Object for following")]
    [SerializeField] private GameObject _mainCamera;
    
    [Header("Camera propertys")]
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _height;
    [SerializeField] private float _rearDistance;

    private Vector3 currentVector;
    void Start()
    {
        transform.position = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y + _height, _mainCamera.transform.position.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(_mainCamera.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }
    void CameraMove()
    {
        currentVector = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y + _height, _mainCamera.transform.position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position, currentVector,_returnSpeed * Time.deltaTime);
    }
}
