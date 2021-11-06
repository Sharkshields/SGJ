using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform _pointStart;
    [SerializeField] private Transform _pointFinish;
    [SerializeField] public float animDuration;
    private float _yPose;

    private void Start()
    {
        _yPose = gameObject.transform.position.y;
        gameObject.transform.DOMove( _pointFinish.position, animDuration).From(_pointStart.position).SetLoops(-1, LoopType.Restart);
        gameObject.transform.DOMoveY(_yPose + 0.01f, 0.1f).From(_yPose - 0.1f).SetLoops(-1, LoopType.Yoyo); //(_yPose + d, t).From(_yPose - h ) d=расто€ние по y, на которое перемещаетс€ обьект за t времени, h = до какой точки по оси y перемещаетс€ обьект (???)
    }
}
