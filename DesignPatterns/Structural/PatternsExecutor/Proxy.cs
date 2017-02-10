﻿using System;
using DesignPatterns.Structural.Proxy;

namespace DesignPatterns.Structural.PatternsExecutor
{
    public class Proxy : IPatternExecutor
    {
        public string Description()
        {
            return string.Format("Provide a surrogate or placeholder for another object to control access to it. ");
        }

        public void Execute()
        {
            MathProxy proxy = new MathProxy();

            Console.WriteLine("4 + 2 = {0}", proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = {0}", proxy.Sub(4, 2));
            Console.WriteLine("4 / 2 = {0}", proxy.Div(4, 2));
            Console.WriteLine("4 * 2 = {0}", proxy.Mul(4, 2));
        }

        public void Message(string message)
        {
            throw new NotImplementedException();
        }
    }
}