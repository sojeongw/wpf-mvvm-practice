﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRM_data_manager_wpf.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set 
            { 
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set 
            { 
                _cart = value; 
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string SubTotal
        {
            get 
            { 
                return "%0.00"; 
            }
        }

        public string Tax
        {
            get
            {
                return "%0.00";
            }
        }

        public string Total
        {
            get
            {
                return "%0.00";
            }
        }

        private string _itemQuantity;

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set
            { 
                _itemQuantity = value;
                NotifyOfPropertyChange(() => Products);
            }
        }
        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                
                // make sure something is selected
                // make sure there is an item quantity

                return output;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                // make sure something is selected
                // make sure there is an item quantity

                return output;
            }
        }

        public void RemoveFromCart()
        {

        }
        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                // make sure something is selected
                // make sure there is an item quantity

                return output;
            }
        }

        public void CheckOut()
        {

        }
    }
}
