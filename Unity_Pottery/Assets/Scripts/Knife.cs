﻿using UnityEngine ;

public class Knife : MonoBehaviour {
   [SerializeField] private float _movementSpeed ;
   [SerializeField] private float _hitDamage ;
   [SerializeField] private Wood _wood ;

   [SerializeField] private ParticleSystem _woodFx ;

   private ParticleSystem.EmissionModule _woodFxEmission ;

   private Rigidbody _knifeRb ;
   private Vector3 _movementVector ;
   private bool _isMoving = false ;

   private void Start () {
      _knifeRb = GetComponent<Rigidbody> () ;

      _woodFxEmission = _woodFx.emission ;
   }

   private void Update () {
      _isMoving = Input.GetMouseButton (0) ;

      if (_isMoving)
         _movementVector = new Vector3 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0f) * _movementSpeed * Time.deltaTime ;
   }

   private void FixedUpdate () {
      if (_isMoving)
         _knifeRb.position += _movementVector ;
   }

   private void OnCollisionExit (Collision collision) {
      _woodFxEmission.enabled = false ;
   }

   private void OnCollisionStay (Collision collision) {
      Coll coll = collision.collider.GetComponent <Coll> () ;
      if (coll != null) {
         // hit Collider:
         _woodFxEmission.enabled = true ;
         _woodFx.transform.position = collision.contacts [ 0 ].point ;

         coll.HitCollider (_hitDamage) ;
         _wood.Hit (coll.index, _hitDamage) ;
      }
   }
}
