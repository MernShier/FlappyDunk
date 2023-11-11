using System;
using AudioSystem;
using Collision.Data;
using ScoreSystem;
using UnityEngine;
using Utils;
using Utils.Extensions;
using Zenject;

namespace RingSystem
{
    public abstract class Ring : MonoBehaviour
    {
        [SerializeField] private GameObject ringScorePopup;
        private CollisionConfig _collisionConfig;
        private AudioController _audioController;
        private UniversalParent _universalParent;
        private DiContainer _diContainer;
        private RingScore _ringScore;
        private Score _score;
        public event Action OnRingDestroy;

        [Inject]
        private void Construct(CollisionConfig collisionConfig, AudioController audioController,
            UniversalParent universalParent, DiContainer diContainer, RingScore ringScore, Score score)
        {
            _collisionConfig = collisionConfig;
            _audioController = audioController;
            _universalParent = universalParent;
            _diContainer = diContainer;
            _ringScore = ringScore;
            _score = score;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                Pass(col);
            }
        }

        protected virtual void Pass(Collider2D passer)
        {
            _diContainer.InstantiatePrefab(ringScorePopup, transform.position, Quaternion.identity,
                _universalParent.transform);
            _audioController.PlayOneShot(_audioController.GameAudio.RingPass);
            
            _score.ChangeScore(_ringScore.ScoreForRing);
            _ringScore.AddScoreForRing();
            Debug.Log(_score.Value);

            DestroyRing();
        }

        public void DestroyRing()
        {
            OnRingDestroy?.Invoke();
            transform.parent.gameObject.SetActive(false);
        }
    }
}