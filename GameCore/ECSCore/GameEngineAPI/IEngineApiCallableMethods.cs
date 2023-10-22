using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECS.GameEngineAPI
{
    public interface IEngineApiCallableMethods
    {
        void Awake();

        void OnEnable();

        void Reset();

        void Start();

        void FixedUpdate();
        void FixedUpdate(double delta);

        void OnTriggerEnter(CollisionObject other);

        void OnTriggerStay(CollisionObject other);

        void OnTriggerExit(CollisionObject other);

        void OnTriggerEnter2D(CollisionObject2D other);

        void OnTriggerStay2D(CollisionObject2D other);

        void OnTriggerExit2D(CollisionObject2D other);

        void OnCollisionEnter(CollisionObject collision);

        void OnCollisionStay(CollisionObject collision);

        void OnCollisionExit(CollisionObject collision);

        void OnCollisionEnter2D(CollisionObject2D collision);

        void OnCollisionStay2D(CollisionObject2D collision);

        void OnCollisionExit2D(CollisionObject2D collision);

        void Update(double delta);
        void Update();

        void LateUpdate();
        void LateUpdate(double delta);

        void OnRenderObject();

        void OnApplicationPause(bool pause);

        void OnApplicationQuit();

        void OnApplicationFocus(bool focus);

        void OnDisable();

        void OnDestroy();
    }
}
