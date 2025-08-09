
using UnityEngine;

namespace Demo.Tool.Singleton
{
    public abstract class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        private static T _instance;
        private static object _lock = new object();

        public static T MainInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = FindObjectOfType<T>() as T; //��ȥ����������û�������

                        if (_instance == null)//���û�У���ô�����Լ�����һ��GameobjectȻ�������һ��T������͵Ľű�������ֵ��instance;
                        {
                            GameObject go = new GameObject(typeof(T).Name);
                            _instance = go.AddComponent<T>();
                        }
                    }
                }

                return _instance;
            }
        }


        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        private void OnApplicationQuit()//�����˳�ʱ����instance���
        {
            _instance = null;
        }
    }

}
