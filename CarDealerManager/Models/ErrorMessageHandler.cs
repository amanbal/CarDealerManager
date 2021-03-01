using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealerManager.Models
{
    public class ErrorMessageHandler
    {
        public static string ISThereError { get; set; }

        public static string ErrorMessage { get; set; }

        public static string CustomErrorMessagePart1 { get; set; }

        public static string CustomErrorMessagePart2 { get; set; }
    }
}
