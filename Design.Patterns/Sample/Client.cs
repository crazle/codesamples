﻿namespace Sample
{
    internal class Client
    {
        private readonly AbstractProductA _abstractProductA;

        private readonly AbstractProductB _abstractProductB;


        // Constructor

        public Client(AbstractFactory factory)

        {
            _abstractProductB = factory.CreateProductB();

            _abstractProductA = factory.CreateProductA();
        }


        public void Run()

        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}