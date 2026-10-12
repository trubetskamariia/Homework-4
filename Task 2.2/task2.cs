using System;
using System.Collections.Generic;
using System.Data;

namespace Task2_Company
{
    public abstract class Worker
    {
        private string _name;
        private string _position;
        private string _workDay;
        public Worker(string name)
        {
            _name = name;
            _position = string.Empty;
            _workDay = string.Empty;
        }
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        public string Position
        {
            get => _position;
            protected set => _position = value;
        }
        public string WorkDay
        {
            get => _workDay;
            private set => _workDay = value;
        }
        public void Call ()
        {
            _workDay += "call";
        }
        public void WriteCode()
        {
            _workDay += "write code";
        }
        public void Relax()
        {
            _workDay += "relax";
        }
        public abstract void FillWorkDay();
    }
}
