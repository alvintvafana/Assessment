using System;

namespace Assessment.Catalogue.Domain.Commands
{
    public class AdjustBookPriceCommand : ICommand
    {
        public Guid Id { get; set; }
        public double PurchasePrice { get; set; }
    }
}
