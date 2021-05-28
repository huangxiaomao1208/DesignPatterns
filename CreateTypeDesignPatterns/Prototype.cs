using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CreateTypeDesignPatterns
{
    /// <summary>
    /// 原型模式 - 克隆出一个新对象
    /// 浅克隆： 自带的MemberwiseClone方法。（只能克隆值类型，引用类型还是指向同一块地址）
    /// 深克隆： 可以使用序列化、反射递归实现
    /// 
    /// </summary>
    public class Prototype
    {

        /// <summary>
        /// 浅拷贝
        /// </summary>
        public static void Show()
        {
            PrototypeProduct product = new PrototypeProduct
            {
                Name = "product1",
                Num = 1,
                type = new Type() { TypeId = 1 }
            };
            var product2 = product.ShallowClone();
            product2.Num = 2;
            product2.Name = "product2";
            product2.type.TypeId = 2;

            //值类型完全拷贝
            Console.WriteLine(product.Num);//1
            Console.WriteLine(product2.Num);//2

            //不是说引用类型只拷贝地址吗？为什么修改了produtct2的Name值，Product1的值还是原来的呢？
            //引用类型拷贝地址是对的，但是字符串类型有的特殊，因为字符串类型是不可变的。修改product2的Name值相当于新创建了一个string类型的值
            Console.WriteLine(product.Name);//product1
            Console.WriteLine(product2.Name);//product2

            //引用类型的浅拷贝，这里就体现出来了
            //修改了product2的type,product1中的type也随着改变
            Console.WriteLine(product.type.TypeId); //2
            Console.WriteLine(product2.type.TypeId); //2  


            product2.type = new Type() { TypeId = 3 };
            //这里修改了product2中的type值，为什么product中的type没有发生改变呢？
            //因为product2重新创建了一个type,和product中的type指向的不是同一个堆内存空间了
            //上面所提到的字符串可以参考这一条
            Console.WriteLine(product.type.TypeId); //2
            Console.WriteLine(product2.type.TypeId); //3

        }

 
        public static void ShowDeepCloneBySerialize()
        {
            PrototypeProduct prototype = new PrototypeProduct();
            prototype.type = new Type() { TypeId = 1 };
            var prototype2 = (PrototypeProduct)prototype.DeepCloneBySerialize();
            prototype2.type.TypeId = 2;
            Console.WriteLine(prototype.type.TypeId);
            Console.WriteLine(prototype2.type.TypeId);
        }

        public static void ShowDeepCloneByReflect()
        {
            PrototypeProduct prototype = new PrototypeProduct();
            prototype.type = new Type() { TypeId = 1};
            var prototype2 = (PrototypeProduct)prototype.DeepCloneByReflect();
            prototype2.type.TypeId = 3;
            Console.WriteLine(prototype.type.TypeId);
            Console.WriteLine(prototype2.type.TypeId);
        }
    }

    [Serializable]
    public class PrototypeProduct
    {

        public int Num { get; set; }
        public string Name { get; set; }

        public Type type { get; set; }

        //浅拷贝
        public PrototypeProduct ShallowClone()
        {
            return (PrototypeProduct)this.MemberwiseClone();
        }
    }

    [Serializable]
    public class Type
    {
        public int TypeId { get; set; }
    }

    public static class DeepClone
    {

        /// <summary>
        /// 通过序列化+二进制  实现深拷贝
        /// 原对象相关的类必须添加Serializable
        /// </summary>
        public static object DeepCloneBySerialize(this object obj)
        {
            if (obj == null || obj is string || obj.GetType().IsValueType)
            {
                return obj;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                //二进制序列化器
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                //将对象写入内存流
                binaryFormatter.Serialize(ms, obj);
                //将当前流中的位置设置为指定值
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                object result = binaryFormatter.Deserialize(ms);
                return result;
            }
        }


        /// <summary>
        /// 通过反射 + 递归   实现深拷贝
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object DeepCloneByReflect(this object obj)
        {
            //如果是值类型或者是字符串类型返回原值
            //递归出口
            if (obj == null || obj is string || obj.GetType().IsValueType)
            {
                return obj;
            }

            var type = obj.GetType();
            //根据对象的type类型，创建一个新的空对象
            //构造函数模式是公开的
            object result = Activator.CreateInstance(type);
            //根据type值可以获取类中所有的属性和字段
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fieldInfos)
            {
                //这里用到了递归
                //将原对象的属性值一一赋值到新对象中，因为原对象的属性值有可能是多层引用值，所以要用到递归
                //递归的出口就是这个属性的值是值类型或者是字符串类型
                field.SetValue(result,field.GetValue(obj).DeepCloneByReflect());
            }
            return result;
        }
    }
}
