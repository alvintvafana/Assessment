using Assessment.Catalogue.Domain.Exceptions;
using System;

namespace Assessment.Catalogue.Domain.Entities
{
    public class Book 
    {
        public Guid Id { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }

        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(value == null || value == string.Empty)
                     throw new ValidateException("Name cannot be null");
                name = value;
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            private set
            {
                if (value == null || value == string.Empty)
                    throw new ValidateException("Text cannot be null");
                text = value;
            }
        }

        private double purchasePrice;
        public double PurchasePrice
        {
            get { return purchasePrice; }
            private set
            {
                if(value < 0)
                    throw new ValidateException("Purchase price cannot be less than zero");
                purchasePrice = value; 
            }
        }

        public Book(string name, string text, double purchasePrice)
        {
            Id = Guid.NewGuid();
            Name = name;
            Text = text;
            PurchasePrice = purchasePrice;
            CreatedOn = DateTime.Now;
        }
        public void UpdateBookDetail(string name, string text)
        {
            Name = name;
            Text = text;
            UpdatedOn = DateTime.Now;
        }
        public void AdjustPurchasePrice(double purchasePrice) 
        {
            PurchasePrice = purchasePrice;
            UpdatedOn = DateTime.Now;
        }
    }
}
