using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System;

namespace CustomerOrders.Models
{
    public class Customer : XPObject
    {
        public Customer(Session session) : base(session) { }

        private string _customerId;
        public string CustomerId
        {
            get => _customerId;
            set => SetPropertyValue(nameof(CustomerId), ref _customerId, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetPropertyValue(nameof(Email), ref _email, value);
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber), ref _phoneNumber, value);
        }

        [Association("Customer-Orders")]
        public XPCollection<Order> Orders
        {
            get => GetCollection<Order>(nameof(Orders));
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidOperationException("Customer Name is required.");
            }

            if (!string.IsNullOrWhiteSpace(CustomerId))
            {
                var existingCustomer = Session.FindObject<Customer>(
                    CriteriaOperator.Parse("CustomerId = ? AND Oid != ?", CustomerId, Oid));
                if (existingCustomer != null)
                {
                    throw new InvalidOperationException($"Customer ID '{CustomerId}' already exists.");
                }
            }
        }
    }
}
