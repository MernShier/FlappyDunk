using UnityEngine;

namespace BallSystem.Data
{
    [CreateAssetMenu(fileName = "CollisionConfigSO", menuName = "SO/BallSystem/CollisionConfigSO")]
    public class CollisionConfig : ScriptableObject
    {
        [field:SerializeField] public LayerMask RingLayer { get; private set; }
        [field:SerializeField] public LayerMask RingCenterLayer { get; private set;}
        [field:SerializeField] public LayerMask RingBottomLayer { get; private set;}
        [field:SerializeField] public LayerMask WallLayer { get; private set;}
    }
}