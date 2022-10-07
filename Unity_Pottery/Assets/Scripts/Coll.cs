using UnityEngine ;

public class Coll : MonoBehaviour {
   public int index ;

   BoxCollider _boxCollider ;

   private void Awake () {
      _boxCollider = GetComponent<BoxCollider> () ;
      index = transform.GetSiblingIndex () ;
   }

   public void HitCollider (float damage) {
      // Resize the collider's height(Y) depends on "damage" 
      if (_boxCollider.size.y - damage > 0.0f)
         _boxCollider.size = new Vector3 (_boxCollider.size.x, _boxCollider.size.y - damage, _boxCollider.size.z) ;
      else
         Destroy (this) ; // Remove Coll Component from this gameobject
   }
}
