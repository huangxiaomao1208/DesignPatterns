using System;

/// <summary>
/// 创建型设计模式
/// </summary>
namespace CreateTypeDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 单例模式
            Console.WriteLine("********** 单例模式 *********");
            Console.WriteLine("********** 单例模式-非线程安全 *********");
            Singleton singleton1 = Singleton.GetInstance();
            Singleton singleton2 = Singleton.GetInstance();
            Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
            Console.WriteLine("********** 单例模式-线程安全 *********");
            SingletonThreadSafe singleton3 = SingletonThreadSafe.GetInstance();
            SingletonThreadSafe singleton4 = SingletonThreadSafe.GetInstance();
            Console.WriteLine(object.ReferenceEquals(singleton3, singleton4));



            #endregion

            Console.ReadLine();

        }
    }
}
