using AudioSystem;
using Collision.Data;
using UnityEngine;
using Utils.Extensions;
using Zenject;

namespace CollectiblesSystem
{
    public abstract class Collectible : MonoBehaviour
    {
        private CollisionConfig _collisionConfig;
        private AudioController _audioController;

        [Inject]
        private void Construct(CollisionConfig collisionConfig, AudioController audioController)
        {
            _collisionConfig = collisionConfig;
            _audioController = audioController;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                PickUp(col);
            }
        }

        protected virtual void PickUp(Collider2D collector)
        {
            _audioController.PlayOneShot(_audioController.GameAudio.CollectiblePickup);
            gameObject.SetActive(false);
        }
    }
}