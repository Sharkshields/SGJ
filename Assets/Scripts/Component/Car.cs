using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform _pointStart;
    [SerializeField] private Transform _pointFinish;
    [SerializeField] private float _timeAAnimations;
    private float _yPose;

    private void Start()
    {
        _yPose = gameObject.transform.position.y;
        gameObject.transform.DOMove( _pointFinish.position, _timeAAnimations).From(_pointStart.position).SetLoops(-1, LoopType.Restart);
        gameObject.transform.DOMoveY(_yPose + 0.1f, 1f).From(_yPose - 0.1f).SetLoops(-1, LoopType.Yoyo);
    }
}
