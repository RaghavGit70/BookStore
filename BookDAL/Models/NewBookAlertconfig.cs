using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// model to give alert whenever a new book is added
/// </summary>
namespace BookWebApp.Models
{
    public class NewBookAlertConfig
    {
        public bool DisplayNewBookAlert { get; set; }
        public string BookName { get; set; }
    }
}