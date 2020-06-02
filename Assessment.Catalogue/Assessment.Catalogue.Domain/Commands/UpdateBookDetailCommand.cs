using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Catalogue.Domain.Commands
{
    public class UpdateBookDetailCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
