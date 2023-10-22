using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECS.GameEngineAPI
{
    public partial class EngineApiObjectBehaviour : StaticEngineApiObjectBehaviour, IEngineApiObjectBehaviour, IEngineApiCallableMethods //: ENGINEGAMEOBJECT, IEngineApiObjectBehaviour, IEngineApiCallableMethods
    {

        public EngineApiObjectBehaviour() : base()
        {
        }

        public EngineApiObjectBehaviour(string name) : base()
        {
            this.Name = name;
        }

        #region Realization Unity

        private List<EngineApiObjectBehaviour> components = new List<EngineApiObjectBehaviour>();

        private IEngineApiObjectBehaviour AddComponentImpl(Type type)
        {
            var newComponent = Activator.CreateInstance(type) as EngineApiObjectBehaviour;
            this.AddChild(newComponent);
            components.Add(newComponent);
            return newComponent;
        }

        private IEngineApiObjectBehaviour GetComponentImpl(Type type)
        {
            return components.Where(x => x.GetType() == type && x.IsInsideTree()).FirstOrDefault();
        }

        private List<IEngineApiObjectBehaviour> GetComponentsImpl(Type type)
        {
            return components.Where(x => x.GetType() == type && x.IsInsideTree()).Cast<IEngineApiObjectBehaviour>().ToList();
        }

        private IEngineApiObjectBehaviour GetComponentInChildrenImpl(Type type)
        {
            if (this.GetType() == type)
            {
                return this;
            }
            if (components.Count == 0)
            {
                if(!(this.GetType() == type))
                {
                    return null;
                }
                else
                {
                    return this;
                }
            }
            else
            {
                foreach(var component in components)
                {
                    return component.GetComponentInChildrenImpl(type);
                }
            }
            return null;
        }

        private List<IEngineApiObjectBehaviour> GetComponentsInChildrenImpl(Type type)
        {
            if (components.Count == 0)
            {
                if (!(this.GetType() == type))
                {
                    return null;
                }
                else
                {
                    return new List<IEngineApiObjectBehaviour>() { this };
                }
            }
            else
            {
                List<IEngineApiObjectBehaviour> result = new List<IEngineApiObjectBehaviour>();
                foreach (var component in components)
                {
                    var compRes = component.GetComponentsInChildrenImpl(type);
                    if (compRes != null)
                        result.AddRange(compRes);
                }
                return result;
            }
        }

        #endregion

        #region ComponentRealization
        public EngineApiObjectBehaviour gameObject { get => this; set => value = value; }
        public bool enabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEngineApiObjectBehaviour IEngineApiObjectBehaviour.gameObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEngineApiObjectBehaviour AddComponent(Type componentType)
        {
            return AddComponentImpl(componentType);
        }

        public T AddComponent<T>() where T : IEngineApiObjectBehaviour
        {
            return (T)AddComponentImpl(typeof(T));
        }

        public T GetComponent<T>() where T : IEngineApiObjectBehaviour
        {
            return (T)GetComponentImpl(typeof(T));
        }

        public IEngineApiObjectBehaviour GetComponent(Type type)
        {
            return AddComponentImpl(type);
        }

        public IEngineApiObjectBehaviour GetComponentInChildren(Type type, bool includeInactive)
        {
            return GetComponentInChildrenImpl(type);
        }

        public T GetComponentInChildren<T>() where T : IEngineApiObjectBehaviour
        {
            return (T)GetComponentInChildrenImpl(typeof(T));
        }

        public IEngineApiObjectBehaviour GetComponentInChildren(Type type)
        {
            return GetComponentInChildrenImpl(type);
        }

        

        public void GetComponents<T>(List<T> results) where T : IEngineApiObjectBehaviour
        {
            if(results != null)
                results.AddRange((IEnumerable<T>)GetComponentsImpl(typeof(T)));
        }

        public IEngineApiObjectBehaviour[] GetComponents(Type type)
        {
            return GetComponentsImpl(type).ToArray();
        }

        public T[] GetComponents<T>() where T : IEngineApiObjectBehaviour
        {
            return ((IEnumerable<T>)GetComponentsImpl(typeof(T))).ToArray();
        }

        public void GetComponents(Type type, List<IEngineApiObjectBehaviour> results)
        {
            if (results != null)
                results.AddRange(GetComponentsImpl(type));
        }

        public void GetComponentsInChildren<T>(List<T> results) where T : IEngineApiObjectBehaviour
        {
            throw new NotImplementedException();
        }

        public T[] GetComponentsInChildren<T>() where T : IEngineApiObjectBehaviour
        {
            throw new NotImplementedException();
        }

        public void GetComponentsInChildren<T>(bool includeInactive, List<T> results) where T : IEngineApiObjectBehaviour
        {
            throw new NotImplementedException();
        }

        public T[] GetComponentsInChildren<T>(bool includeInactive) where T : IEngineApiObjectBehaviour
        {
            throw new NotImplementedException();
        }

        public IEngineApiObjectBehaviour[] GetComponentsInChildren(Type type)
        {
            throw new NotImplementedException();
        }

        

        

        public virtual void SetActive(bool value)
        {
            throw new NotImplementedException();
        }

        public virtual bool TryGetComponent(Type type, out IEngineApiObjectBehaviour component)
        {
            throw new NotImplementedException();
        }

        public virtual bool TryGetComponent<T>(out T component) where T : IEngineApiObjectBehaviour
        {
            throw new NotImplementedException();
        }

        public virtual new void Destroy(object obj)
        {
            if(obj is EngineApiObjectBehaviour)
            {
                (obj as EngineApiObjectBehaviour).QueueFree();
            }
        }

        public virtual void DestroyImmediate(object obj)
        {
            if (obj is EngineApiObjectBehaviour)
            {
                (obj as EngineApiObjectBehaviour).QueueFree();
            }
        }


        #region null

        public IEngineApiObjectBehaviour GetComponent(string type)
        {
            throw new NotImplementedException();
        }

        public T[] GetComponentsInParent<T>() where T : IEngineApiObjectBehaviour
        {
            return null;
        }

        public void GetComponentsInParent<T>(bool includeInactive, List<T> results) where T : IEngineApiObjectBehaviour
        {

        }

        public T[] GetComponentsInParent<T>(bool includeInactive) where T : IEngineApiObjectBehaviour
        {
            return null;
        }

        public IEngineApiObjectBehaviour[] GetComponentsInParent(Type type)
        {
            return null;
        }

        public IEngineApiObjectBehaviour GetComponentInParent(Type type, bool includeInactive)
        {
            return null;
        }

        public IEngineApiObjectBehaviour GetComponentInParent(Type type)
        {
            return null;
        }

        public T GetComponentInParent<T>() where T : IEngineApiObjectBehaviour
        {
            return default;
        }

        #endregion


        #endregion

        #region BehaviourRealization

        private bool Initialized = false;

        public override void _EnterTree()
        {
            base._EnterTree();
            if(!Initialized)
            {
                Awake();
                Initialized = true;
            }
            else
            {
                OnEnable();
            }
        }

        public virtual void Awake()
        {
            
        }

        public virtual void OnEnable()
        {
            
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }



        public override void _Ready()
        {
            base._Ready();
            Start();
        }

        public virtual void Start()
        {
            
        }




        public override void _PhysicsProcess(float delta)
        {
            base._PhysicsProcess(delta);
            FixedUpdate();
            FixedUpdate(delta);
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void FixedUpdate(double delta)
        {
            
        }



        public virtual void OnTriggerEnter(CollisionObject other)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTriggerStay(CollisionObject other)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTriggerExit(CollisionObject other)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTriggerEnter2D(CollisionObject2D other)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTriggerStay2D(CollisionObject2D other)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTriggerExit2D(CollisionObject2D other)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionEnter(CollisionObject collision)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionStay(CollisionObject collision)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionExit(CollisionObject collision)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionEnter2D(CollisionObject2D collision)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionStay2D(CollisionObject2D collision)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionExit2D(CollisionObject2D collision)
        {
            throw new NotImplementedException();
        }


        public override void _Process(float delta)
        {
            base._Process(delta);
            Update();
            Update(delta);
            CallDeferred("LateUpdate");
        }

        public virtual void Update(double delta)
        {
            
        }

        public virtual void Update()
        {
            
        }

        public virtual void LateUpdate()
        {
            
        }

        public void LateUpdate(double delta)
        {
            throw new NotImplementedException();
        }


        public override void _Notification(int what)
        {
            base._Notification(what);
            switch(what)
            {
                case NotificationAppPaused:
                    OnApplicationPause(true);
                    break;
                case NotificationAppResumed:
                    OnApplicationPause(false);
                    break;
                case NotificationWmQuitRequest:
                    OnApplicationQuit();
                    break;
                case NotificationWmFocusIn:
                    OnApplicationFocus(true);
                    break;
                case NotificationWmFocusOut:
                    OnApplicationFocus(false);
                    break;
                case NotificationPredelete:
                    OnDestroy();
                    break;
                case NotificationUnparented:
                    OnDisable();
                    break;
                case NotificationInternalProcess:
                    OnRenderObject();
                    break;
            }

        }


        public virtual void OnRenderObject()
        {
            
        }

        public virtual void OnApplicationPause(bool pause)
        {
            
        }

        public virtual void OnApplicationQuit()
        {
            
        }

        public virtual void OnApplicationFocus(bool focus)
        {
            
        }

        public virtual void OnDisable()
        {
            
        }

        public virtual void OnDestroy()
        {
            
        }

        #endregion
    }

    public partial class StaticEngineApiObjectBehaviour : Node
    {
        public static void Destroy(object obj)
        {
            //Destroy(obj.GetType());
        }

        public static void DontDestroyOnLoad(object obj)
        {

        }
    }
}
