using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDodgeCharacterMovement : MonoBehaviour
{
    #region Variables

    // Public Variables

    // Private Variables
    [SerializeField] private LayerMask laserLayer;

    private TargetPointsManager _targetPointsManager;

    private float _moveSpeed = 8f;

    private const float NormalSpeed = 8f;
    private const float SlowSpeed = 3f;

    #endregion Variables

    private void Awake()
    {
        _targetPointsManager = GetComponentInChildren<TargetPointsManager>();
    }

    public void Move()
    {
        transform.position += Vector3.forward * (Time.deltaTime * _moveSpeed);
    }

    public bool CheckAllPointsPassed() => _targetPointsManager.CheckAllPointPassed();

    public bool CheckCanSlowDown()
    {
        if (_targetPointsManager.CheckAllPointPassed())
        {
            return false;
        }
        
        return Physics.Raycast(transform.position, Vector3.forward, 6f, laserLayer);
    }

    public void SetSlowSpeed() => _moveSpeed = SlowSpeed;
    public void SetNormalSpeed() => _moveSpeed = NormalSpeed;
}