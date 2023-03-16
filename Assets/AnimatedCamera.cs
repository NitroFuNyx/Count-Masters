using System;
using System.Diagnostics.Contracts;
using Cinemachine;
using UnityEngine;

public class AnimatedCamera : MonoBehaviour
{
    private bool _moveTheCamera;
    private CinemachineTransposer _cinemachineTransposer;
    private CinemachineComposer _cinemachineComposer;

    [SerializeField] private Transform playerTransform;

    private static AnimatedCamera _instance;

    public static AnimatedCamera Instance => _instance;


    private void OnEnable()
    {
        if (Instance == null)
        {
            _instance = this;
            
        }
    }

    private void OnDisable()
    {
        _instance = null;
    }

    private void Start()
    {
        _cinemachineTransposer = GetComponent<CinemachineVirtualCamera>()
            .GetCinemachineComponent<CinemachineTransposer>();

        _cinemachineComposer =GetComponent<CinemachineVirtualCamera>()
            .GetCinemachineComponent<CinemachineComposer>();
    }

    public void StartFinalView()
    {
        _moveTheCamera = true;
    }

    public bool GetCameraStatus()
    {
        return _moveTheCamera;
    }
    private void Update()
    {
        if(_moveTheCamera && playerTransform.childCount > 1)
        {
            _cinemachineTransposer.m_FollowOffset = new Vector3(4.5f, Mathf.Lerp(_cinemachineTransposer.m_FollowOffset.y,
                playerTransform.GetChild(1).position.y + 1.2f, Time.deltaTime * 1f), -5f);

            _cinemachineComposer.m_TrackedObjectOffset = new Vector3(0f,
                Mathf.Lerp(_cinemachineComposer.m_TrackedObjectOffset.y,
                    2f, Time.deltaTime * 1f), 0f);
        }
    }
}