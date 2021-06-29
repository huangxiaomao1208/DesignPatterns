using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 单例模式-非线程安全
    /// 懒汉式 - 如果非线程安全不要使用
    /// 饿汉式 - 没有线程不安全的问题
    /// 既然饿汉式没有线程安全问题，为什么不使用饿汉式？应该是延迟加载的问题
    /// </summary>
    public class Singleton
    {
        private Singleton()
        { 
        }

        //懒汉式
        private static Singleton _instance = null;

        //饿汉式 (直接实例化对象)
        //private static Singleton _instance = new Singleton();

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
