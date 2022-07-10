﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ComboBoxEdit_CreatingCheckedComboBox
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public static List<Customer> GetList() {
            var customers = new List<Customer>();
            customers.Add(new Customer() { ID = 0, Name = "David Miles" });
            customers.Add(new Customer() { ID = 1, Name = "John Spor" });
            customers.Add(new Customer() { ID = 2, Name = "Nick Jackson" });
            customers.Add(new Customer() { ID = 3, Name = "Linda Parsons" });
            return customers;
        }
    }
}
