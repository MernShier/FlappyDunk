using Collision.Data;
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
        [SerializeField] private int shieldForRing;
        private CollisionConfig _collisionConfig;
        private Score _score;
        private RingScore _ringScore;
        private BallShield _ballShield;
        private Rigidbody2D _rb;
        private bool _frozen;

        [Inject]
        private void Construct(CollisionConfig collisionConfig, 
            Score score, RingScore ringScore, BallShield ballShield)
        {
            _collisionConfig = collisionConfig;
            _score = score;
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
                _score.ChangeScore(_ringScore.ScoreForRing);
                _ringScore.AddScoreForRing();
                Debug.Log(_score.Value);
            }

            if (_collisionConfig.RingBottomLayer.Contains(col.gameObject.layer))
            {
                if (_ballShield.Shield > 0)
                {
                    _ballShield.ChangeShield(-shieldForRing);
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

        private void MoveHorizontal()
        {
            var position = transform.position;
            transform.position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
        }

        public void MoveUp()
        {
            _rb.velocity = Vector2.zero;

            var force = Vector2.up * upForce;
            if (_rb.gravityScale <= 0)
            {
                force *= -1;
            }

            _rb.AddForce(force, ForceMode2D.Impulse);
        }

        public void ChangeGravity()
        {
            _rb.gravityScale *= -1;
        }

        public void Freeze(bool value)
        {
            _frozen = value;
            _rb.bodyType = _frozen ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        }
    }
}