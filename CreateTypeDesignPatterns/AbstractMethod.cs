using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 抽象工厂
    /// 抽象工厂和工厂方法差不多，只是抽象方法适用于创建一组对象（不同的组里面的对象方法都不相同）
    /// </summary>
    public class AbstractMethod
    {
        
    }

    public abstract class IProductA
    {
        public abstract void Show();
    }

 

    public abstract class IProductB
    {
        public abstract void Show();
    }

    //IOS组-产品A
    public class IosProductA : IProductA
    {
        public override void Show()
        {
            Console.WriteLine("IOS ProductA - Show");
        }
    }

    //IOS组-产品B
    public class IosProductB : IProductB
    {
        public override void Show()
        {
            Console.WriteLine("IOS ProductB - Show");
        }
    }

    //Android组-产品A
    public class AndroidProductA : IProductA
    {
        public override void Show()
        {
            Console.WriteLine("Android ProductA - Show");
        }
    }

    //Android组-产品B
    public class AndroidProductB : IProductB
    {
        public override void Show()
        {
            Console.WriteLine("Android ProductB - Show");
        }
    }

    public abstract class AbstractFactory 
    {
        public abstract IProductA CreatProductA();
        public abstract IProductB CreatProductB();
    }

    public class IOSFactory : AbstractFactory
    {
        public override IProductA CreatProductA()
        {
            return new IosProductA();
        }

        public override IProductB CreatProductB()
        {
            return new IosProductB();
        }
    }

    public class AndroidFactory : AbstractFactory
    {
        public override IProductA CreatProductA()
        {
            return new AndroidProductA();
        }
        public override IProductB CreatProductB()
        {
            return new AndroidProductB();
        }
    }


}
