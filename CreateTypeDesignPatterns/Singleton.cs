using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 单例模式-非线程安全
    /// </summary>
    public class Singleton
    {
        private Singleton()
        { 
        }
        private static Singleton _instance = null;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
       
    }

    
    /// <summary>
    /// 单例模式-线程安全
    /// </summary>
    public class SingletonThreadSafe
    {
        private SingletonThreadSafe()
        { 
        }

        private static SingletonThreadSafe _instance = null;

        private static readonly object obj = new object();

        public static SingletonThreadSafe GetInstance()
        {
            //双IF加锁  IF-LOCK-IF

            //第一个IF判断该对象有没有被实例化
            if (_instance == null)
            {
                //如果没有被实例化，加锁，这个时刻只允许一个用户进去实例化,其他的用户等待
                lock (obj)
                {
                    //判断有没有用户已经实例化了，因为在lock等待的时候，排在前面的肯定已经实例化成功了，所以这里也要加上IF二次判断一下
                    if (_instance == null)
                    {
                        _instance = new SingletonThreadSafe();
                    }
                }
            }
            return _instance;
        }

        
    }
}
