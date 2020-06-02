using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Catalogue.Domain.Commands
{
    public class AddBookCommand : ICommand
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public double PurchasePrice { get; set; }
    }
}
