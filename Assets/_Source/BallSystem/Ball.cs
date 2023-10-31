using System.Collections;
using BallSystem.Data;
using Extensions;
using UnityEngine;
using Utils;
using Zenject;

namespace BallSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        private const int BASE_SCORE_FOR_RING = 1;
        [SerializeField] private float upForce;
        [SerializeField] private float speed;
        [SerializeField] private int maxShield;
        private CollisionConfig _collisionConfig;
        private BallScore _ballScore;
        private BallShield _ballShield;
        private Rigidbody2D _rb;
        private float _scoreForRing;
        private float _scoreMult = 1;
        
        [Inject]
        private void Init(CollisionConfig collisionConfig, BallScore ballScore, BallShield ballShield)
        {
            _collisionConfig = collisionConfig;
            _ballScore = ballScore;
            _ballShield = ballShield;
        }
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _scoreForRing = BASE_SCORE_FOR_RING;
            _ballShield.SetMaxShield(maxShield);
        }

        private void Update()
        {
            MoveHorizontal();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (_collisionConfig.RingLayer.Contains(col.gameObject.layer))
            {
                _scoreForRing = BASE_SCORE_FOR_RING * _scoreMult;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.RingCenterLayer.Contains(col.gameObject.layer))
            {
                _ballScore.AddScore(_scoreForRing);
                _scoreForRing += BASE_SCORE_FOR_RING * _scoreMult;
                Debug.Log(_ballScore.Score);
            }
            
            if (_collisionConfig.RingBottomLayer.Contains(col.gameObject.layer))
            {
                if (_ballShield.Shield > 0)
                {
                    _ballShield.AddShield(-1);
                    return;
                }
                
                Death();
            }
            
            if (_collisionConfig.WallLayer.Contains(col.gameObject.layer))
            {
                Death();
            }
        }

        private void Death()
        {
            SceneChanger.ReloadScene();
        }

        public void MoveHorizontal()
        {
            var position = transform.position;
            transform.position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
        }
        
        public void MoveUp()
        {
            _rb.velocity = Vector2.zero;
            if (_rb.gravityScale > 0)
            {
                _rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
            }
            else
            {
                _rb.AddForce(Vector2.up * -upForce, ForceMode2D.Impulse);
            }
        }

        public void ChangeGravity()
        {
            _rb.gravityScale = -_rb.gravityScale;
        }

        public void StartMultiplyScore(float duration, float mult)
        {
            StartCoroutine(MultiplyScore(duration, mult));
        }

        private IEnumerator MultiplyScore(float duration, float mult)
        {
            _scoreMult += mult - 1;
            _scoreForRing *= _scoreMult;
            yield return new WaitForSeconds(duration);
            _scoreForRing /= _scoreMult;
            _scoreMult -= mult - 1;
        }
    }
}