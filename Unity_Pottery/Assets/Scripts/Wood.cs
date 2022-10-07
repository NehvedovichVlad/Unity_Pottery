using UnityEngine ;
using DG.Tweening ;

public class Wood : MonoBehaviour {
   [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer ;
   [SerializeField] private Transform _woodTransform ;
   [SerializeField] private Vector3 _rotationVector ;
   [SerializeField] private float _rotationDuration ;

   private void Start () {
      _woodTransform
         .DOLocalRotate (_rotationVector, _rotationDuration, RotateMode.FastBeyond360)
         .SetLoops (-1, LoopType.Restart)
         .SetEase (Ease.Linear) ;
   }

   public void Hit (int keyIndex, float damage) {
      float colliderHeight = 2.39705f ;
      //Skinned mesh renderer key's value is clamped between 0 & 100
      float newWeight = _skinnedMeshRenderer.GetBlendShapeWeight (keyIndex) + damage * (100f / colliderHeight) ;
      _skinnedMeshRenderer.SetBlendShapeWeight (keyIndex, newWeight) ;
   }
}
