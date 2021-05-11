using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class Singleton
    {
        private Singleton()
        { 
        }
        public static Singleton _instance = null;
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
       
    }
}
