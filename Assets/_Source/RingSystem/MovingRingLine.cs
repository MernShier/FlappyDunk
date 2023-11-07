using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public class MovingRingLine : MonoBehaviour
    {
        [SerializeField] private List<Transform> points;
        [SerializeField] private GameObject ring;
        [SerializeField] private float ringSpeed;
        private Ring _ring;
        private Vector3 _movePosition;
        private int _movePointIndex;
        
        private void Awake()
        {
            _ring = ring.transform.GetComponentInChildren<Ring>();
            
            if (_ring == null) 
                throw new NullReferenceException("Ring Script not found in Ring GameObject children");
        }
        
        private void Start()
        {
            ring.transform.position = points[0].position;
            _movePosition = points[1].position;
            _movePointIndex = 1;
            
            _ring.OnRingDestroy += Destroy;
        }

        private void Update()
        {
            MoveRing();
        }

        private void MoveRing()
        {
            if (ring.transform.position == _movePosition)
            {
                SetMovePosition();
            }

            ring.transform.position =
                Vector2.MoveTowards(ring.transform.position, _movePosition, ringSpeed * Time.deltaTime);
        }

        private void SetMovePosition()
        {
            _movePointIndex++;
            
            if (_movePointIndex >= points.Count)
            {
                _movePointIndex = 0;
                _movePosition = points[0].position;
            }
            else
            {
                _movePosition = points[_movePointIndex].position;
            }
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}