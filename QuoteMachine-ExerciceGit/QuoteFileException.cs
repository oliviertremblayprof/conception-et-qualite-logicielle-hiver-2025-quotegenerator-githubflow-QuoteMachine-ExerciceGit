using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteMachine_ExerciceGit
{
    public class QuoteFileException : Exception
    {
        public QuoteFileException(string message, Exception inner = null) : base(message, inner) { }
    }
}
