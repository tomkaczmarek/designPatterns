﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DesignPatterns.Common.Base;
using DesignPatterns.Common.Helpers;
using System;
using System.Collections.Generic;
using Castle.MicroKernel.SubSystems.Configuration;

namespace DesignPatterns
{
    class Program
    {
        static IDictionary<int, string> Menu { get; set; }
        const string ASSEMBLY_NAME = "DesignPatterns.Patterns.PatternsType";

        static void Main(string[] args)
        {
            #region const
            const string END = "E";
            const string MENU_CACHE_NAME = "MainMenu";
            #endregion

            string choose;
            int number;       
            MenuBuilder menu = new MenuBuilder();

            do
            {
                Console.WriteLine("Select design pattern to show");

                var cache = LocalCache.Instance.Get<IDictionary<int, string>>(MENU_CACHE_NAME);

                if (cache != null)
                {
                    Menu = cache;
                }
                else
                {
                    Menu = menu.BuildMenu<PatternsTypeBase>();
                    LocalCache.Instance.Add<IDictionary<int, string>>(Menu, MENU_CACHE_NAME);
                }            
                foreach (var item in Menu)
                {
                    Console.WriteLine("[{0}]. {1}.", item.Key, item.Value);
                }
                Console.WriteLine("[E]. Exit");

                choose = Console.ReadLine();

                if (Int32.TryParse(choose, out number))
                {
                    SelectPattern(number);
                }
                else
                {
                    Console.WriteLine("Incorect format");
                }                  
            }
            while (choose.ToUpper() != END);                
        }
              
        static void SelectPattern(int number)
        {
            if(Menu.Count >= number)
            {               
                string className = Menu[number];
                var container = new WindsorContainer();
                container.Register(Component.For<PatternSelector>().Instance(new PatternSelector(className, ASSEMBLY_NAME)));
                var patternSelector = container.Resolve<PatternSelector>();
                patternSelector.SelectPatterns();
            }
        }
    }
}
