using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicsSS
{
    abstract class Item
    {
        string _Name { get; set; }
        string _Description { get; set; }
        float _Cost { get; set; }
        public Item(string name, string description)
        {
            _Name = name;
            _Description = description;
        }
        public abstract void ItemType();
        public abstract void DebugLogItem();

    }
    class Vibrator : Item
    {
        private string _name;
        private string _description;
        public Vibrator(string name, string description):base(name, description)
        {
            _name = name;
            _description = description;
        }
        public override void ItemType()
        {
            Console.WriteLine("Empty Field");
        }
        public override void DebugLogItem()
        {
            Console.WriteLine((_name, _description));
        }
    }
}
