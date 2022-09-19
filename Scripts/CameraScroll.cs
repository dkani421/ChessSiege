using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [Header("Zoom Options")]
    [SerializeField] float zoomAmount;
    [SerializeField] float zoomSpeed;
    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;

    [Header("Assignables")]
    [SerializeField] Camera mainCamera;

    float currentZoom;

    void Start()
    {
        currentZoom = 50;
        mainCamera.fieldOfView = currentZoom;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f && currentZoom < maxZoom) currentZoom += zoomAmount;
        else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f && currentZoom > minZoom) currentZoom -= zoomAmount;

        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, currentZoom, zoomSpeed * Time.deltaTime);
    }
}