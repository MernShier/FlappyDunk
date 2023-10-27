using System;
using BallSystem.Data;
using Extensions;
using Unity.Collections;
using UnityEngine;
using Utils;
using Zenject;

namespace BallSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private CollisionConfig collisionConfig;
        [SerializeField] private float upForce;
        [SerializeField] private float speed;
        [Inject] private BallScorer _ballScorer;
        private int _scoreForRing;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _scoreForRing = 1;
        }

        private void Update()
        {
            MoveHorizontal();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (collisionConfig.RingLayer.Contains(col.gameObject.layer))
            {
                _scoreForRing = 1;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (collisionConfig.RingCenterLayer.Contains(col.gameObject.layer))
            {
                _ballScorer.AddScore(_scoreForRing);
                _scoreForRing++;
                Debug.Log(_ballScorer.Score);
            }
            
            if (collisionConfig.RingBottomLayer.Contains(col.gameObject.layer))
            {
                SceneChanger.ReloadScene();
            }
            
            if (collisionConfig.WallLayer.Contains(col.gameObject.layer))
            {
                SceneChanger.ReloadScene();
            }
        }

        public void MoveHorizontal()
        {
            var position = transform.position;
            transform.position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
        }
        
        public void MoveUp()
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
        }
    }
}