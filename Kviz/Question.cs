using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kviz
{
    internal class Question
    {
            public string Text { get; set; }
            public string[] Answers { get; set; }
            public int CorrectAnswer { get; set; }
    }
}
