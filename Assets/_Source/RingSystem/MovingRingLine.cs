using UnityEngine;

namespace RingSystem
{
    public class MovingRingLine : MonoBehaviour
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private Transform finalPosition;
        [SerializeField] private Ring ring;
        [SerializeField] private float ringSpeed;
        private Vector3 _movePosition;

        private void Start()
        {
            ring.transform.parent.position = startPosition.position;
            _movePosition = finalPosition.position;

            ring.OnRingDestroy += Destroy;
        }

        private void Update()
        {
            MoveRing();
        }

        private void MoveRing()
        {
            var ringParent = ring.transform.parent;

            if (ringParent.position == _movePosition)
            {
                SetMovePosition();
            }

            ringParent.position =
                Vector2.MoveTowards(ringParent.position, _movePosition, ringSpeed * Time.deltaTime);
        }

        private void SetMovePosition()
        {
            _movePosition = _movePosition == startPosition.position ? finalPosition.position : startPosition.position;
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}