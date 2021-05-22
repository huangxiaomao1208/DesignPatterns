using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 工厂方法设计模式
    /// 如果新增一个对象，只需要新增一个对象和他相对应的工厂，不需要修改原本的工厂方法，便于扩展
    /// </summary>
    public class FactoryMethord
    {
        /// <summary>
        /// 上端需要传递一个需要创建某个对象的工厂
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static IProduct_FM CreateProcut_FM(Factory factory)
        {
            return factory.CreateProcut_FM();
        }
    }

    /// <summary>
    /// IProduct Factory Methord
    /// </summary>
    public interface IProduct_FM
    {
        void Show();
    }

    public class Product1_FM : IProduct_FM
    {
        public void Show()
        {
            Console.WriteLine("Product1_FM - Show");
        }
    }

    public class Product2_FM : IProduct_FM
    {
        public void Show()
        {
            Console.WriteLine("Product2_FM - Show");
        }
    }

    public class Product3_FM : IProduct_FM
    {
        public void Show()
        {
            Console.WriteLine("Product3_FM - Show");
        }
    }

    public abstract class Factory
    {
        //创建对象的抽象方法
        public abstract IProduct_FM CreateProcut_FM();
    }

    /// <summary>
    /// 创建产品1的工厂
    /// </summary>
    public class Product1_FM_Factory : Factory
    {
        public override IProduct_FM CreateProcut_FM()
        {
            return new Product1_FM();
        }
    }

    public class Product2_FM_Factory : Factory
    {
        public override IProduct_FM CreateProcut_FM()
        {
            return new Product2_FM();
        }
    }

    public class Product3_FM_Factory : Factory
    {
        public override IProduct_FM CreateProcut_FM()
        {
            return new Product3_FM();
        }
    }
}
