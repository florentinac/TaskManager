using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Parsing;

namespace TaskManager
{
    public class MainOptions
    {
        [Option('a', "add")]
        public string Add { get; set; }

        [Option('m', "message")]
        public string Message { get; set; }

        [Option('d', "date")]
        public string Date { get; set; }

        [Option('u', "update")]
        public string Update { get; set; }

        [Option('f', "fileName")]
        public string FileName { get; set;}

        [Option("id")]
        public string GetId { get; set; }

    }
}
