﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command
{
    public enum ActionList
    {
        ADD,
        SUB,
        MUL
    }
    public interface IReciever
    {
        void SetAction(ActionList action);
        int GetResult();
    }
}
