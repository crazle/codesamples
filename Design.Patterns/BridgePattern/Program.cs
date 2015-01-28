using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Customers customers=new Customers("Chicaco");
            customers.Data = new CustomerData();
            for (int i = 0; i < 100; i++)
            {
                customers.Next();
                customers.Show();
            }
            customers.Add("Henry Velazqsd");
            customers.ShowAll();
            Console.ReadLine();
        }
    }

    class CustomerData:DataObject
    {
        private List<string> _customers = new List<string>();
        private int _currentIndex;


        public CustomerData()
        {
            _customers.Add("Jim Jones");
            _customers.Add("Jim Harden");
            _customers.Add("James LBron");
            _customers.Add("Cury");

        }
        public override void PriorRecord()
        {
            if (_currentIndex>0)
            {
                _currentIndex--;
            }
        }

        public override void NextRecord()
        {
            if (_customers.Count>_currentIndex+1)
            {
                _currentIndex++;
            }
            else
            {
                _currentIndex = 0;
            }
        }
        public override void AddRecord(string name)
        {
            _customers.Add(name);
        }

        public override void DeleteRecord(string name)
        {
            _customers.Remove(name);
        }

        public override void ShowRecord()
        {
            Console.WriteLine(_customers[_currentIndex]);
        }

        public override void ShowAllRecords()
        {
            _customers.ForEach(Console.WriteLine);
        }
    }

    class Customers:CustomerBase
    {
        public Customers(string group) : base(group)
        {
        }

        public override void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------");

            base.ShowAll();
            Console.WriteLine("---------------------------------");

        }
    }

    class CustomerBase
    {
        private DataObject _dataObject;
        protected string group;

        public CustomerBase(string group)
        {
            this.group = group;
        }

        public DataObject Data
        {
            get { return _dataObject; }
            set { _dataObject = value; }
        }

        public virtual void Next()
        {
            Data.NextRecord();
        }
        public virtual void Prior()
        {
            Data.PriorRecord();
        }
        public virtual void Add(string customer)
        {
            Data.AddRecord(customer);
        }
        public virtual void Delete(string customer)
        {
            Data.DeleteRecord(customer);
        }
        public virtual void Show()
        {
            Data.ShowRecord();
        }
        public virtual void ShowAll()
        {
            Console.WriteLine("Customer group: "+group);
            Data.ShowAllRecords();
        }


    }

    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();

    }

}
