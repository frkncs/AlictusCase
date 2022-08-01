using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RingController : MonoBehaviour
{
    #region Enum

    public enum RingColor
    {
        Pink,
        Yellow,
        Green,
        Blue
    }

    #endregion

    #region Variables

    // Public Variables

    // Private Variables
    [SerializeField] private RingColor ringColor;

    private Rigidbody _rb;

    #endregion Variables

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    private void Start()
    {
        GameEvents.WinEvent += ThrowRing;
    }

    public RingColor GetRingColor() => ringColor;

    private void ThrowRing()
    {
        _rb.isKinematic = false;

        var force = new Vector3(Random.Range(-1f, 1f), 1, Random.Range(.5f, 1f)) * 500;
        var forcePosition = transform.position + (new Vector3(Random.Range(-1f, 1f), -.5f, Random.Range(-1f, 1f)));
        
        _rb.AddForceAtPosition(force, forcePosition);
        
        Destroy(_rb.gameObject, 2f);
    }
}