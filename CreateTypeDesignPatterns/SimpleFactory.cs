using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 简单工厂模式 - 它不属于23种设计模式之一
    /// 用一个工厂创建不同类型的对象
    /// 优点：上端传递一个对象类型，就可以得到相对应的对象
    /// 缺点：如果新增一个对象，需要修改工厂创建对象的方法
    /// </summary>
    public class SimpleFactory
    {
        public static IProduct CreateProduct(string type)
        {
            IProduct product = null;
            switch (type)
            {
                case "1":
                    product = new Product1();
                    break;
                case "2":
                    product = new Product2();
                    break;
                case "3":
                    product = new Product3();
                    break;
            }
            return product;
        }
    }
    /// <summary>
    /// 接口  这里可以使用抽象类代替
    /// </summary>
    public interface IProduct
    {
        void Show();
    }

    public class Product1 : IProduct
    {
        public void Show()
        {
            Console.WriteLine("Product1 - Show");
        }
    }

    public class Product2 : IProduct
    {
        public void Show()
        {
            Console.WriteLine("Product2 - Show");
        }
    }

    public class Product3 : IProduct
    {
        public void Show()
        {
            Console.WriteLine("Product3 - Show");
        }
    }
}
