﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastraAlunos.Exceptions
{
    public class DataBaseException : Exception
    {
        public DataBaseException(string msg):base(msg) 
        {
                
        }
    }
}
