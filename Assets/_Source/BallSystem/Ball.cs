using BallSystem.Data;
using ScoreSystem;
using UnityEngine;
using Utils;
using Utils.Extensions;
using Zenject;

namespace BallSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float upForce;
        [SerializeField] private float speed;
        [SerializeField] private int maxShield;
        private CollisionConfig _collisionConfig;
        private SceneChanger _sceneChanger;
        private Scorer _scorer;
        private RingScore _ringScore;
        private BallShield _ballShield;
        private Rigidbody2D _rb;
        private bool _frozen;

        [Inject]
        private void Construct(CollisionConfig collisionConfig, SceneChanger sceneChanger,
            Scorer scorer, RingScore ringScore, BallShield ballShield)
        {
            _collisionConfig = collisionConfig;
            _sceneChanger = sceneChanger;
            _scorer = scorer;
            _ringScore = ringScore;
            _ballShield = ballShield;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _ballShield.SetMaxShield(maxShield);
        }

        private void Update()
        {
            if (!_frozen)
            {
                MoveHorizontal();
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (_collisionConfig.RingLayer.Contains(col.gameObject.layer))
            {
                _ringScore.ResetScoreForRing();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.RingCenterLayer.Contains(col.gameObject.layer))
            {
                _scorer.AddScore(_ringScore.ScoreForRing);
                _ringScore.AddScoreForRing();
                Debug.Log(_scorer.Score);
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
            _sceneChanger.ReloadScene();
        }

        private void MoveHorizontal()
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

        public void Freeze(bool value)
        {
            if (value)
            {
                _frozen = true;
                _rb.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                _frozen = false;
                _rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}