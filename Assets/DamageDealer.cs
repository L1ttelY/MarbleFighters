using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat {
	public class DamageDealer:MonoBehaviour {
		Collider2D collider;

		public Vector2Int damageRange;
		public DamageType damageType;
		public Vector2 relativeKnockback;
		public Vector2 velocity;

		void Start() {
			collider=GetComponent<Collider2D>();
		}
		private void OnTriggerEnter2D(Collider2D collision) {
			for(var t = transform;t!=null;t=t.parent)
				if(collision.transform==t) return;
			if(!collision.GetComponent<DamageTarget>()) return;

			DamageTarget target = collision.GetComponent<DamageTarget>();

		}

		public DamageModel GetDamage() {
			DamageModel result = new DamageModel();
			result.damageRange=damageRange;
			result.damageType=damageType;
			result.knockback=Utility.Product(relativeKnockback,velocity);
			return result;
		}
	}

}