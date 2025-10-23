using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System;

namespace CustomerOrders.Models
{
    public class Order : XPObject
    {
        public Order(Session session) : base(session)
        {
            _orderDate = DateTime.Now;
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get => _orderDate;
            set => SetPropertyValue(nameof(OrderDate), ref _orderDate, value);
        }

        private string _orderNumber;
        public string OrderNumber
        {
            get => _orderNumber;
            set => SetPropertyValue(nameof(OrderNumber), ref _orderNumber, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetPropertyValue(nameof(Description), ref _description, value);
        }

        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set => SetPropertyValue(nameof(Amount), ref _amount, value);
        }

        private Customer _customer;
        [Association("Customer-Orders")]
        public Customer Customer
        {
            get => _customer;
            set => SetPropertyValue(nameof(Customer), ref _customer, value);
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (Amount <= 0)
            {
                throw new InvalidOperationException("Order Amount must be greater than 0.");
            }

            if (OrderDate > DateTime.Now)
            {
                throw new InvalidOperationException("Order date cannot be in the future.");
            }

            if (Customer == null)
            {
                throw new InvalidOperationException("Order must be linked to a customer.");
            }

            if (!string.IsNullOrWhiteSpace(OrderNumber))
            {
                var existingOrder = Session.FindObject<Order>(
                    CriteriaOperator.Parse("OrderNumber = ? AND Oid != ?", OrderNumber, Oid));
                if (existingOrder != null)
                {
                    throw new InvalidOperationException($"Order Number '{OrderNumber}' already exists.");
                }
            }
        }
    }
}
