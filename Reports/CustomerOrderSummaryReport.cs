using CustomerOrders.Models;
using DevExpress.XtraReports.UI;
using DevExpress.Xpo;
using System.Linq;

namespace CustomerOrders.Reports
{
    public class CustomerOrderSummaryReport : XtraReport
    {
        public CustomerOrderSummaryReport()
        {
            InitializeReport();
        }

        private void InitializeReport()
        {
            this.ReportUnit = ReportUnit.TenthsOfAMillimeter;
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 100);

            var detailBand = new DetailBand { HeightF = 100 };
            var reportHeader = new ReportHeaderBand { HeightF = 100 };
            var groupHeader = new GroupHeaderBand { HeightF = 120 };
            var groupFooter = new GroupFooterBand { HeightF = 60 };

            var titleLabel = new XRLabel
            {
                Text = "Customer Order Summary",
                LocationF = new System.Drawing.PointF(0, 0),
                SizeF = new System.Drawing.SizeF(650, 50),
                Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold)
            };
            reportHeader.Controls.Add(titleLabel);

            var customerNameLabel = new XRLabel
            {
                Text = "Customer:",
                LocationF = new System.Drawing.PointF(0, 0),
                SizeF = new System.Drawing.SizeF(100, 25),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };
            groupHeader.Controls.Add(customerNameLabel);

            var customerName = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "Name") },
                LocationF = new System.Drawing.PointF(100, 0),
                SizeF = new System.Drawing.SizeF(550, 25),
                Font = new System.Drawing.Font("Arial", 12)
            };
            groupHeader.Controls.Add(customerName);

            var customerIdLabel = new XRLabel
            {
                Text = "Customer ID:",
                LocationF = new System.Drawing.PointF(0, 25),
                SizeF = new System.Drawing.SizeF(100, 25),
                Font = new System.Drawing.Font("Arial", 10)
            };
            groupHeader.Controls.Add(customerIdLabel);

            var customerId = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "CustomerId") },
                LocationF = new System.Drawing.PointF(100, 25),
                SizeF = new System.Drawing.SizeF(200, 25),
                Font = new System.Drawing.Font("Arial", 10)
            };
            groupHeader.Controls.Add(customerId);

            var emailLabel = new XRLabel
            {
                Text = "Email:",
                LocationF = new System.Drawing.PointF(0, 50),
                SizeF = new System.Drawing.SizeF(100, 25),
                Font = new System.Drawing.Font("Arial", 10)
            };
            groupHeader.Controls.Add(emailLabel);

            var email = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "Email") },
                LocationF = new System.Drawing.PointF(100, 50),
                SizeF = new System.Drawing.SizeF(300, 25),
                Font = new System.Drawing.Font("Arial", 10)
            };
            groupHeader.Controls.Add(email);

            var orderDateHeader = new XRLabel
            {
                Text = "Order Date",
                LocationF = new System.Drawing.PointF(0, 85),
                SizeF = new System.Drawing.SizeF(120, 25),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            groupHeader.Controls.Add(orderDateHeader);

            var orderNumberHeader = new XRLabel
            {
                Text = "Order Number",
                LocationF = new System.Drawing.PointF(120, 85),
                SizeF = new System.Drawing.SizeF(120, 25),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            groupHeader.Controls.Add(orderNumberHeader);

            var descriptionHeader = new XRLabel
            {
                Text = "Description",
                LocationF = new System.Drawing.PointF(240, 85),
                SizeF = new System.Drawing.SizeF(280, 25),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            groupHeader.Controls.Add(descriptionHeader);

            var amountHeader = new XRLabel
            {
                Text = "Amount",
                LocationF = new System.Drawing.PointF(520, 85),
                SizeF = new System.Drawing.SizeF(130, 25),
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            groupHeader.Controls.Add(amountHeader);

            var orderDateField = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "Orders.OrderDate", "{0:MM/dd/yyyy}") },
                LocationF = new System.Drawing.PointF(0, 0),
                SizeF = new System.Drawing.SizeF(120, 25),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            detailBand.Controls.Add(orderDateField);

            var orderNumberField = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "Orders.OrderNumber") },
                LocationF = new System.Drawing.PointF(120, 0),
                SizeF = new System.Drawing.SizeF(120, 25),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            detailBand.Controls.Add(orderNumberField);

            var descriptionField = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "Orders.Description") },
                LocationF = new System.Drawing.PointF(240, 0),
                SizeF = new System.Drawing.SizeF(280, 25),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            detailBand.Controls.Add(descriptionField);

            var amountField = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "Orders.Amount", "{0:C}") },
                LocationF = new System.Drawing.PointF(520, 0),
                SizeF = new System.Drawing.SizeF(130, 25),
                Borders = DevExpress.XtraPrinting.BorderSide.All
            };
            detailBand.Controls.Add(amountField);

            var totalLabel = new XRLabel
            {
                Text = "Total:",
                LocationF = new System.Drawing.PointF(400, 10),
                SizeF = new System.Drawing.SizeF(120, 25),
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold)
            };
            groupFooter.Controls.Add(totalLabel);

            var totalAmount = new XRLabel
            {
                DataBindings = { new XRBinding("Text", null, "Orders.Amount") },
                LocationF = new System.Drawing.PointF(520, 10),
                SizeF = new System.Drawing.SizeF(130, 25),
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                Summary = new XRSummary
                {
                    Running = SummaryRunning.Group,
                    Func = SummaryFunc.Sum,
                    FormatString = "{0:C}"
                }
            };
            groupFooter.Controls.Add(totalAmount);

            this.Bands.Add(reportHeader);
            this.Bands.Add(groupHeader);
            this.Bands.Add(detailBand);
            this.Bands.Add(groupFooter);

            using (var uow = new UnitOfWork())
            {
                var customers = new XPQuery<Customer>(uow).ToList();
                this.DataSource = customers;
                this.DataMember = "Orders";

                var groupField = new GroupField("Name", XRColumnSortOrder.Ascending);
                groupHeader.GroupFields.Add(groupField);
            }
        }
    }
}
