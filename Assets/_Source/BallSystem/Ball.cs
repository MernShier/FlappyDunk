using System.Collections;
using AudioSystem;
using Collision.Data;
using ScoreSystem;
using UnityEngine;
using Utils;
using Utils.Extensions;
using Zenject;

namespace BallSystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class Ball : MonoBehaviour
    {
        private static readonly int JumpTrigger = Animator.StringToHash("Jump");
        [SerializeField] private ParticleSystem deathParticles;
        [SerializeField] private float deathTime;
        [SerializeField] private float upForce;
        [SerializeField] private float speed;
        [SerializeField] private int maxShield;
        [SerializeField] private int shieldForRing;
        private CollisionConfig _collisionConfig;
        private AudioController _audioController;
        private RingScore _ringScore;
        private BallShield _ballShield;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private bool _frozen;

        [Inject]
        private void Construct(CollisionConfig collisionConfig, AudioController audioController,
            RingScore ringScore, BallShield ballShield)
        {
            _collisionConfig = collisionConfig;
            _audioController = audioController;
            _ringScore = ringScore;
            _ballShield = ballShield;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
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
            if (_collisionConfig.RingBottomLayer.Contains(col.gameObject.layer))
            {
                if (_ballShield.Shield > 0)
                {
                    _ballShield.ChangeShield(-shieldForRing);
                    return;
                }

                StartCoroutine(Death(deathTime));
            }

            if (_collisionConfig.WallLayer.Contains(col.gameObject.layer))
            {
                StartCoroutine(Death(deathTime));
            }
        }

        private IEnumerator Death(float time)
        {
            Freeze(true);
            deathParticles.gameObject.SetActive(true);
            _audioController.PlayOneShot(_audioController.GameAudio.Death);

            yield return new WaitForSeconds(time);
            SceneChanger.ReloadScene();
        }

        private void MoveHorizontal()
        {
            var position = transform.position;
            transform.position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
        }

        public void MoveUp()
        {
            if (_frozen) return;

            _rigidbody2D.velocity = Vector2.zero;
            var force = Vector2.up * upForce;
            if (_rigidbody2D.gravityScale <= 0)
            {
                force *= -1;
            }

            _rigidbody2D.AddForce(force, ForceMode2D.Impulse);
            _animator.SetTrigger(JumpTrigger);
            _audioController.PlayOneShot(_audioController.GameAudio.Tap);
        }

        public void ChangeGravity()
        {
            _rigidbody2D.gravityScale *= -1;
        }

        public void Freeze(bool value)
        {
            _frozen = value;
            _rigidbody2D.bodyType = _frozen ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        }
    }
}