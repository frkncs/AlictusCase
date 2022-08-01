using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RingSelectorController : MonoBehaviour
{
    #region Variables

    // Public Variables
    [SerializeField] public int ringCount;
    [SerializeField] public int totalColorCount;

    // Private Variables
    [SerializeField] private LayerMask ringCharacterLayer;
    
    private GhostRingController _ghostRingController;
    private Camera _mainCam;
    private RingSelectorBaseState _currentState;
    private int _correctMatchedRingCount;

    // selected ring informations
    private RingManController _selectedRingManController;
    private RingsManager _selectedRingManager;
    private Vector3 _selectedRingDefPos;
    private RingController _selectedRing;
    private Transform _selectedRingTrans;
    private Transform _selectedRingManTrans;

    #endregion Variables

    private void Start()
    {
        _mainCam = Camera.main;
        _ghostRingController = GameObject.FindGameObjectWithTag("GhostRing").GetComponent<GhostRingController>();

        GameEvents.GameStartedEvent += SelectRingState;

        GameEvents.WinEvent += IdleState;
        GameEvents.LoseEvent += IdleState;

        IdleState();
    }

    private void Update()
    {
        _currentState.Update();
    }

    public void SelectRing()
    {
        var ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, ringCharacterLayer))
        {
            _selectedRingManager = hitInfo.transform.GetComponent<RingManController>().ringsManager;

            var topRing = _selectedRingManager.GetTopRing();

            if (topRing == null)
            {
                _selectedRingManager = null;
                return;
            }

            _selectedRing = topRing;
            _selectedRingTrans = topRing.transform;
            _selectedRingDefPos = _selectedRingTrans.position;

            _selectedRingTrans.PlayScaleUpDownAnim(1.4f, .15f);

            SelectRingCharacterState();
        }
    }

    public void MoveRingAndSelectCharacter()
    {
        SetRingPosition(out Vector3 ringPos);

        _selectedRingTrans.position = ringPos;

        var ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, ringCharacterLayer))
        {
            if (_selectedRingManTrans == hitInfo.transform) return;
            
            _selectedRingManController = hitInfo.transform.GetComponent<RingManController>();

            _selectedRingManTrans = _selectedRingManController.transform;

            if (_selectedRingManager == _selectedRingManController.ringsManager)
            {
                _ghostRingController.HideGhostRing();
                return;
            }
            
            var selectedManTopRing = _selectedRingManController.ringsManager.GetTopRing();

            Vector3 ghostRingPos;

            if (selectedManTopRing != null)
            {
                ghostRingPos = selectedManTopRing.transform.position;
                ghostRingPos.y += .2f;
            }
            else
            {
                ghostRingPos = _selectedRingManController.transform.position;
                ghostRingPos.y += .3f;
            }

            _ghostRingController.SetPosition(ghostRingPos, _selectedRing.GetRingColor());
        }
    }

    public void IncreaseCorrectMatchedRingCount()
    {
        _correctMatchedRingCount++;

        if (_correctMatchedRingCount >= totalColorCount)
        {
            GameEvents.WinEvent?.Invoke();
        }
    }

    public void DecreaseCorrectMatchedRingCount()
    {
        _correctMatchedRingCount--;
    }

    public void MouseUpped()
    {
        if (_selectedRingManController != null &&
            _selectedRingManager.GetRingManController() != _selectedRingManController)
        {
            var selectedManTopRing = _selectedRingManController.ringsManager.GetTopRing();
            var topRing = _selectedRingManager.GetTopRing();

            Vector3 ringPos;

            if (selectedManTopRing != null)
            {
                ringPos = selectedManTopRing.transform.position;
                ringPos.y += .7f;
            }
            else
            {
                ringPos = _selectedRingManController.transform.position;
                ringPos.y += .3f;
            }

            _selectedRingTrans.DOMove(ringPos, .15f)
                .SetEase(Ease.OutBounce);

            _selectedRingManController.ringsManager.AddTopRing(topRing);

            _selectedRingManager.RemoveTopRingFromList();
        }
        else
        {
            _selectedRingTrans.DOMove(_selectedRingDefPos, .15f)
                .SetEase(Ease.OutBounce);
        }

        ResetSelectedRingInformation();

        if (_currentState.GetType() == typeof(RingSelectorSelectRingCharacterState))
        {
            SelectRingState();
        }
    }

    private void IdleState() => _currentState = new RingSelectorIdleState(this);
    private void SelectRingState() => _currentState = new RingSelectorSelectRingState(this);
    private void SelectRingCharacterState() => _currentState = new RingSelectorSelectRingCharacterState(this);

    private void ResetSelectedRingInformation()
    {
        _selectedRing = null;
        _selectedRingTrans = null;
        _selectedRingManTrans = null;
        _selectedRingManager = null;
        _selectedRingManController = null;

        _ghostRingController.HideGhostRing();
    }

    private void SetRingPosition(out Vector3 ringPos)
    {
        Vector3 selectedRingPosition = _selectedRingTrans.position;
        ringPos = Input.mousePosition;

        ringPos.z = _mainCam.WorldToScreenPoint(selectedRingPosition).z;

        ringPos = _mainCam.ScreenToWorldPoint(ringPos);
        ringPos.z = selectedRingPosition.z;

        ringPos.x = Mathf.Clamp(ringPos.x, -3, 3);
        ringPos.y = Mathf.Clamp(ringPos.y, _selectedRingDefPos.y, 4);
    }
}