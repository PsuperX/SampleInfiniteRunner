using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem : Unit
    {
        private ICollisionSideChecker _collisionChecker = null;

        public override void OnFixedUpdate()
        {
            iStateController.OnFixedUpdate();
            unitData.spriteAnimations.OnFixedUpdate();

            //CollisionReaction reactionData = unitData.collisionEnters.GetReactionData();
            //
            //if (reactionData.reactionType == CollisionReactionType.TAKE_DAMAGE)
            //{
            //    Debugger.Log("take damage!");
            //    unitData.listNextStates.Add(new Runner_Death(this));
            //}
            //else if (reactionData.reactionType == CollisionReactionType.DEAL_DAMAGE)
            //{
            //    reactionData.collidingUnit.unitData.listDamageData.Add(new DamageData(1f, this));
            //    unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_JumpUp_StartForce;
            //}

            //only clear after updating states
            unitData.collisionStays.Clear();
            unitData.collisionEnters.Clear();
        }

        public override void InitCollisionChecker()
        {
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            _collisionChecker = new CollisionChecker(collider);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);
                unitData.collisionEnters.Add(collisionData);
            }
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);

                unitData.collisionStays.AddCollisionStay(collisionData);
            }
        }
    }
}