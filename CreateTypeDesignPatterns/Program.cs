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
            //Console.WriteLine("********** 单例模式 *********");
            //Console.WriteLine("********** 单例模式-非线程安全 *********");
            //Singleton singleton1 = Singleton.GetInstance();
            //Singleton singleton2 = Singleton.GetInstance();
            //Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
            //Console.WriteLine("********** 单例模式-线程安全 *********");
            //SingletonThreadSafe singleton3 = SingletonThreadSafe.GetInstance();
            //SingletonThreadSafe singleton4 = SingletonThreadSafe.GetInstance();
            //Console.WriteLine(object.ReferenceEquals(singleton3, singleton4));
            #endregion


            #region 简单工厂
            //IProduct product1 = SimpleFactory.CreateProduct("1");
            //product1.Show();
            //IProduct product2 = SimpleFactory.CreateProduct("2");
            //product2.Show();
            //IProduct product3 = SimpleFactory.CreateProduct("3");
            //product3.Show();
            #endregion

            #region 工厂方法
            //IProduct_FM productFM;
            ////产品1工厂
            //Factory factory1 = new Product1_FM_Factory();
            ////创建对象调用方法
            //productFM = FactoryMethord.CreateProcut_FM(factory1);
            //productFM.Show();
            //Factory factory2 = new Product2_FM_Factory();
            //productFM = FactoryMethord.CreateProcut_FM(factory2);
            //productFM.Show();
            //Factory factory3 = new Product3_FM_Factory();
            //productFM =FactoryMethord.CreateProcut_FM(factory3);
            //productFM.Show();
            #endregion


            #region 抽象工厂
            //AbstractFactoryMethod iosFactory = new IOSFactory();
            //iosFactory.CreatProductA().Show();
            //iosFactory.CreatProductB().Show();
            //AbstractFactoryMethod androidFactory = new AndroidFactory();
            //androidFactory.CreatProductA().Show();
            //androidFactory.CreatProductB().Show();

            #endregion


            #region 原型模式

            //Prototype.Show();
            Prototype.ShowDeepCloneBySerialize();
            Prototype.ShowDeepCloneByReflect();

            #endregion



            Console.ReadLine();

        }

        
    }
   
}
