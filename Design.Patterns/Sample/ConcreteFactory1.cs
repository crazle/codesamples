using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class ConcreteFactory1 : AbstractFactory
    {

        public override AbstractProductA CreateProductA()
        {

            return new ProductA1();

        }

        public override AbstractProductB CreateProductB()
        {

            return new ProductB1();

        }

    }
}
