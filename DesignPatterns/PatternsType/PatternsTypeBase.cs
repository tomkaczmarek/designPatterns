﻿using System;
using System.Collections.Generic;

namespace DesignPatterns.PatternsType
{
    public abstract class PatternsTypeBase
    {

        private const string BACK = "B";
        private string _choose;
        private IDictionary<int, string> _idAndNamesOfClasses;

        public IDictionary<int, string> IdsAndNamesOfClasses
        {
            get { return _idAndNamesOfClasses;}
            set { _idAndNamesOfClasses = value;}
        }

        public string Choose
        {
            get { return _choose; }
            set { _choose = value; }
        }

        public string BackChar
        {
            get { return BACK; }
        }

        protected void ClearConsole()
        {
            Console.Clear();
        }

        protected virtual void DrawList()
        {
            Console.WriteLine("[B]. Back");
        }

        protected void TryExecutePattern(string choose)
        {
            int _number;

            if (Int32.TryParse(choose, out _number))
            {
                ExecuteBuilder(PatternExecutorFactory(_number));
            }
            else
                Console.WriteLine("Wrong format");
        }

        private void ExecuteBuilder(IPatternExecutor pattern)
        {
            if (pattern != null)
            {
                Console.WriteLine(pattern.Description());
                pattern.Execute();
                Console.WriteLine();
            }

        }

        //Factory for specific executer
        protected abstract IPatternExecutor PatternExecutorFactory(int index);
        public abstract void Execute();


    }
}
