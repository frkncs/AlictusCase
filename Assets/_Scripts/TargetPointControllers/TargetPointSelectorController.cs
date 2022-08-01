using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TargetPointSelectorController : MonoBehaviour
{
    #region Variables

    // Public Variables

    // Private Variables
    [SerializeField] private LayerMask pointLayer;

    private Camera _mainCam;

    // selected point informations
    private TargetPointController _selectedPointController;
    private Transform _selectedPointTrans;

    #endregion Variables

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (_selectedPointTrans != null)
        {
            SetSelectedPointPos(out Vector3 pos);

            _selectedPointTrans.position = pos;

            if (Input.GetMouseButtonUp(0))
            {
                _selectedPointTrans.position = _selectedPointController.connectedRigTransform.position;
                ResetSelectedPointInfo();
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                var ray = _mainCam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, pointLayer))
                {
                    _selectedPointTrans = hitInfo.transform;
                    
                    _selectedPointController = _selectedPointTrans.GetComponent<TargetPointController>();
                    _selectedPointController.PlaySelectParticle();
                    _selectedPointController.PlaySelectedAnimation();
                }
            }
        }
    }

    private void ResetSelectedPointInfo()
    {
        _selectedPointTrans = null;
        _selectedPointController = null;
    }

    private void SetSelectedPointPos(out Vector3 pos)
    {
        pos = Input.mousePosition;
        pos.z = _mainCam.WorldToScreenPoint(_selectedPointTrans.position).z;

        pos = _mainCam.ScreenToWorldPoint(pos);
        pos.z = _selectedPointTrans.position.z;
    }
}