using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director=new Director();
            Builder b1=new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            var product1 = b1.GetResult();
            product1.Show();

            director.Construct(b2);
            var product2 = b2.GetResult();
            product2.Show();
        }
    }


    /// <summary>

    /// The 'Director' class

    /// </summary>

    class Director
    {

        // Builder uses a complex series of steps

        public void Construct(Builder builder)
        {

            builder.BuildPartA();

            builder.BuildPartB();

        }

    }



    /// <summary>

    /// The 'Builder' abstract class

    /// </summary>

    abstract class Builder
    {

        public abstract void BuildPartA();

        public abstract void BuildPartB();

        public abstract Product GetResult();

    }



    /// <summary>

    /// The 'ConcreteBuilder1' class

    /// </summary>

    class ConcreteBuilder1 : Builder
    {

        private Product _product = new Product();



        public override void BuildPartA()
        {

            _product.Add("PartA");

        }



        public override void BuildPartB()
        {

            _product.Add("PartB");

        }



        public override Product GetResult()
        {

            return _product;

        }

    }



    /// <summary>

    /// The 'ConcreteBuilder2' class

    /// </summary>

    class ConcreteBuilder2 : Builder
    {

        private Product _product = new Product();



        public override void BuildPartA()
        {

            _product.Add("PartX");

        }



        public override void BuildPartB()
        {

            _product.Add("PartY");

        }



        public override Product GetResult()
        {

            return _product;

        }

    }



    /// <summary>

    /// The 'Product' class

    /// </summary>

    class Product
    {

        private List<string> _parts = new List<string>();



        public void Add(string part)
        {

            _parts.Add(part);

        }



        public void Show()
        {

            Console.WriteLine("\nProduct Parts -------");

            foreach (string part in _parts)

                Console.WriteLine(part);

        }

    }
}
