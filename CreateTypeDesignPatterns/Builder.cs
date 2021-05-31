using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 建造者设计模式
    /// 创建复杂对象 一个商品可能有多个部分组分
    /// 建造者模式和抽象工厂有什么区别
    /// </summary>
    /// 


    public class Director
    {
        public static Product GetProductor(Builder builder)
        {
            builder.CreatPartA();
            builder.CreatPartB();
            return builder.Build();

        }
    }

    public abstract class Builder
    {
        public Product Product = new Product { };
        public abstract void CreatPartA();
        public abstract void CreatPartB();
        public Product Build()
        {
            return this.Product;
        }
    }
    public class BuilderA : Builder
    {

        Product product = new Product();
        public override void CreatPartA()
        {
            product.PartA = new Product1PartA();
        }

        public override void CreatPartB()
        {
            product.PartB = new Product1PartB();
        }


    }


    public class BuilderB
    {
        Product product = new Product();
        public void CreatPartA()
        {
            product.PartA = new Product2PartA();
        }

        public void CreatePartB()
        {
            product.PartB = new Product2PartB();
        }


    }



    /// <summary>
    /// 一个对象有两个部分组成
    /// </summary>
    public class Product
    {
        public IProductPartA PartA { get; set; }
        public IProductPartB PartB { get; set; }

    }

    public interface IProductPartA
    {
        void Show();
    }

    public interface IProductPartB
    {
        void Show();
    }



    public class Product1PartA : IProductPartA
    {
        public void Show()
        {
            Console.WriteLine("Product1 PartA");
        }
    }


    public class Product1PartB : IProductPartB
    {
        public void Show()
        {
            Console.WriteLine("Prodcut1 PartB");
        }
    }


    public class Product2PartA : IProductPartA
    {
        public void Show()
        {
            Console.WriteLine("Product2 PartA");
        }
    }

    public class Product2PartB : IProductPartB
    {
        public void Show()
        {
            Console.WriteLine("Product2 PartA");
        }
    }





}
