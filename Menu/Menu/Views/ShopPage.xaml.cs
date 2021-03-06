﻿using Menu.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {

        #region the property used for the tap on the scroll

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        bool tab1Visible = true;
        public bool Tab1Visible
        {
            get { return tab1Visible; }
            set { SetProperty(ref tab1Visible, value); }
        }


        bool tab2Visible = false;
        public bool Tab2Visible
        {
            get { return tab2Visible; }
            set { SetProperty(ref tab2Visible, value); }
        }


        bool tab3Visible = false;
        public bool Tab3Visible
        {
            get { return tab3Visible; }
            set { SetProperty(ref tab3Visible, value); }
        }

        bool tab4Visible = false;
        public bool Tab4Visible
        {
            get { return tab4Visible; }
            set { SetProperty(ref tab4Visible, value); }
        }


        #endregion


        public List<ItemPair> ItemList;
        List<ItemPair> _item = new List<ItemPair>();



        #region methods tol load the list 

        public List<ItemPair> LoadTheListOfItems()
        {
            _item.Add(new ItemPair(new Item() { Id = "1", Image = "glasses.png", Name = "Brownie hip sun glasses", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true, Categorie= "Travel" },
                                   new Item() { Id = "2", Image = "holder.png", Name = "Brownie glasses holder", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true,Categorie = "Bags" }));

            _item.Add(new ItemPair(new Item() { Id = "3", Image = "handbag.png", Name = "hand bag Natural leather", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true,Categorie = "Bags" },
                                   new Item() { Id = "4", Image = "handwatch.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true, Categorie = "Accessories" }));

            _item.Add(new ItemPair(new Item() { Id = "5", Image = "shoes.png", Name = "Evening shoes hight heels", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true, Categorie = "Shoes" },
                                   new Item() { Id = "6", Image = "Leather.png", Name = "Belt Natural leather", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true , Categorie = "Accessories" }));

            _item.Add(new ItemPair(new Item() { Id = "7", Image = "holder.png", Name = "Concord hand watch", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true , Categorie = "Travel" },
                null));

            return _item;
        }

        #endregion

        public ShopPage()
        {
            InitializeComponent();
            BindingContext = this;
            ItemList = LoadTheListOfItems();
            ListItems1.ItemsSource = ItemList;

        }


        #region for the scroll tap item
        void Settings_Clicked(object sender, EventArgs e)
        {
           
            List<ItemPair> _listFiltered = new List<ItemPair>();
            List<Item> _itemcategorie = new List<Item>();

            if (sender.Equals(ShoesPart))
            {
               
                _itemcategorie = new List<Item>();
                ShoesPart.TextColor = Color.White;
                TravelPart.TextColor = Color.Gray;
                BagsPart.TextColor = Color.Gray;
                AccessoriesPart.TextColor = Color.Gray;

                TravelPart.FontSize = 18;
                ShoesPart.FontSize = 24;
                BagsPart.FontSize = 18;
                AccessoriesPart.FontSize = 18;


                // filter the pair list and add it to an Itel list
                foreach (ItemPair pp in ItemList)
                {
                    if (pp.Item1.Categorie == "Shoes")
                    {
                        _itemcategorie.Add(pp.Item1);
                        //pp.Item2.IsVisible = false;
                    }
                    if (pp.Item2.Categorie == "Shoes")
                    {
                        _itemcategorie.Add(pp.Item2);
                        //pp.Item1.IsVisible = false;
                    }
                }

                #region adding the item list to aN ITEM PAIR LIST
                if (_itemcategorie.Count % 2 == 0)
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                        else if (i == _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], null);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                #endregion

                ListItems1.ItemsSource = _listFiltered;

            }


            // For the travel categorie
            else if (sender.Equals(TravelPart))
            {
               
                #region changement de font of the text in the scroll
                ShoesPart.TextColor = Color.Gray;
                TravelPart.TextColor = Color.White;
                BagsPart.TextColor = Color.Gray;
                AccessoriesPart.TextColor = Color.Gray;

                TravelPart.FontSize = 24;
                ShoesPart.FontSize = 18;
                BagsPart.FontSize = 18;
                AccessoriesPart.FontSize = 18;
                #endregion
                _itemcategorie = new List<Item>();

                // filter the pair list and add it to an Itel list
                foreach (ItemPair pp in ItemList)
                {
                    if (pp.Item1.Categorie == "Travel")
                    {
                        _itemcategorie.Add(pp.Item1);
                      //  pp.Item2.IsVisible = false;
                    }
                    if (pp.Item2.Categorie == "Travel")
                    {
                        _itemcategorie.Add(pp.Item2);
                        //pp.Item1.IsVisible = false;
                    }
                }

                #region adding the item list to aN ITEM PAIR LIST
                if (_itemcategorie.Count % 2 == 0)
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                        else if (i == _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], null);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                #endregion

                ListItems1.ItemsSource = _listFiltered;

            }

           
            // For the Bags categorie Bags
            else if (sender.Equals(BagsPart))
            {               
              
                ShoesPart.TextColor = Color.Gray;
                TravelPart.TextColor = Color.Gray;
                BagsPart.TextColor = Color.White;
                AccessoriesPart.TextColor = Color.Gray;

                TravelPart.FontSize = 18;
                ShoesPart.FontSize = 18;
                BagsPart.FontSize = 24;
                AccessoriesPart.FontSize = 18;

                _itemcategorie = new List<Item>();
                // filter the pair list and add it to an Itel list
                foreach (ItemPair pp in ItemList)
                {
                    if (pp.Item1.Categorie == "Bags")
                    {
                        _itemcategorie.Add(pp.Item1);
                    }
                    if (pp.Item2.Categorie == "Bags")
                    {
                        _itemcategorie.Add(pp.Item2);
                    }
                }

                #region adding the item list to aN ITEM PAIR LIST
                if (_itemcategorie.Count % 2 == 0)
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                        else if (i == _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], null);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                #endregion

                ListItems1.ItemsSource = _listFiltered;

            }

            // For the Bags categorie Accessories
            else if (sender.Equals(AccessoriesPart))
            {
               
                ShoesPart.TextColor = Color.Gray;
                TravelPart.TextColor = Color.Gray;
                BagsPart.TextColor = Color.Gray;
                AccessoriesPart.TextColor = Color.White;

                TravelPart.FontSize = 18;
                ShoesPart.FontSize = 18;
                BagsPart.FontSize = 18;
                AccessoriesPart.FontSize = 24;

                _itemcategorie = new List<Item>();
                // filter the pair list and add it to an Itel list
                foreach (ItemPair pp in ItemList)
                {
                    if (pp.Item1.Categorie == "Accessories")
                    {
                        _itemcategorie.Add(pp.Item1);
                    }
                    if (pp.Item2.Categorie == "Accessories")
                    {
                        _itemcategorie.Add(pp.Item2);
                    }
                }

                #region adding the item list to aN ITEM PAIR LIST
                if (_itemcategorie.Count % 2 == 0)
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                    {
                        if (i < _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                            _listFiltered.Add(pp);
                        }
                        else if (i == _itemcategorie.Count - 1)
                        {
                            ItemPair pp = new ItemPair(_itemcategorie[i], null);
                            _listFiltered.Add(pp);
                        }
                    }
                }
                #endregion

                ListItems1.ItemsSource = _listFiltered;

            }
            else
            {
               // ItemList = LoadTheListOfItems();
                ListItems1.ItemsSource = ItemList;
            }
        }
        #endregion

        #region using the converter for the scroll tap
        public ICommand TabTappedCommand
        {
            get
            {
                return new Command((e) =>
                {
                    List<ItemPair> _listFiltered = new List<ItemPair>();
                    List<Item> _itemcategorie = new List<Item>();

                    if (int.Parse(e.ToString()) == 1)
                    {
                        #region for the list search
                        _itemcategorie = new List<Item>();
                        // filter the pair list and add it to an Itel list
                        foreach (ItemPair pp in ItemList)
                        {
                            if (pp.Item1.Categorie == "Shoes")
                            {
                                _itemcategorie.Add(pp.Item1);                     
                            }
                            if (pp.Item2.Categorie == "Shoes")
                            {
                                _itemcategorie.Add(pp.Item2);
                            }
                        }
                        #region adding the item list to aN ITEM PAIR LIST
                        if (_itemcategorie.Count % 2 == 0)
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                                else if (i == _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], null);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        #endregion

                        ListItems1.ItemsSource = _listFiltered;
                        #endregion

                        Tab1Visible = true;
                        Tab2Visible = false;
                        Tab3Visible = false;
                        Tab4Visible = false;
                    }
                    else if (int.Parse(e.ToString()) == 2)
                    {
                        #region for the list search
                        _itemcategorie = new List<Item>();

                        // filter the pair list and add it to an Itel list
                        foreach (ItemPair pp in ItemList)
                        {
                            if (pp.Item1.Categorie == "Travel")
                            {
                                _itemcategorie.Add(pp.Item1);
                                //  pp.Item2.IsVisible = false;
                            }
                            if (pp.Item2.Categorie == "Travel")
                            {
                                _itemcategorie.Add(pp.Item2);
                                //pp.Item1.IsVisible = false;
                            }
                        }
                        #region adding the item list to aN ITEM PAIR LIST
                        if (_itemcategorie.Count % 2 == 0)
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                                else if (i == _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], null);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        #endregion

                        ListItems1.ItemsSource = _listFiltered;
                        #endregion

                        Tab1Visible = false;
                        Tab2Visible = true;
                        Tab3Visible = false;
                        Tab4Visible = false;
                    }
                    else if (int.Parse(e.ToString()) == 3)
                    {
                        #region for the list search
                        _itemcategorie = new List<Item>();
                        // filter the pair list and add it to an Itel list
                        foreach (ItemPair pp in ItemList)
                        {
                            if (pp.Item1.Categorie == "Bags")
                            {
                                _itemcategorie.Add(pp.Item1);
                            }
                            if (pp.Item2.Categorie == "Bags")
                            {
                                _itemcategorie.Add(pp.Item2);
                            }
                        }

                        #region adding the item list to aN ITEM PAIR LIST
                        if (_itemcategorie.Count % 2 == 0)
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                                else if (i == _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], null);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        #endregion

                        ListItems1.ItemsSource = _listFiltered;
                        #endregion

                        Tab1Visible = false;
                        Tab2Visible = false;
                        Tab3Visible = true;
                        Tab4Visible = false;
                    }
                    else if (int.Parse(e.ToString()) == 4)
                    {

                        #region for the list serach
                        _itemcategorie = new List<Item>();
                        // filter the pair list and add it to an Itel list
                        foreach (ItemPair pp in ItemList)
                        {
                            if (pp.Item1.Categorie == "Accessories")
                            {
                                _itemcategorie.Add(pp.Item1);
                            }
                            if (pp.Item2.Categorie == "Accessories")
                            {
                                _itemcategorie.Add(pp.Item2);
                            }
                        }

                        #region adding the item list to aN ITEM PAIR LIST
                        if (_itemcategorie.Count % 2 == 0)
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _itemcategorie.Count; i = i + 1)
                            {
                                if (i < _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], _itemcategorie[i + 1]);
                                    _listFiltered.Add(pp);
                                }
                                else if (i == _itemcategorie.Count - 1)
                                {
                                    ItemPair pp = new ItemPair(_itemcategorie[i], null);
                                    _listFiltered.Add(pp);
                                }
                            }
                        }
                        #endregion

                        ListItems1.ItemsSource = _listFiltered;

                        #endregion

                        Tab1Visible = false;
                        Tab2Visible = false;
                        Tab3Visible = false;
                        Tab4Visible = true;
                    }
                });
            }

        }
        #endregion


        #region for the search bar 

        private void OnSearch(object sender, TextChangedEventArgs e)
        {

            List<ItemPair> _listFiltered = new List<ItemPair>();
           

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ListItems1.ItemsSource = ItemList;
            }

            else
            {
                List<Item> _itemSearch = new List<Item>();

                foreach (var prod in ItemList)
                {


                    if (prod.Item1.Name.ToLower().Contains(e.NewTextValue))
                    {
                        _itemSearch.Add(prod.Item1);
                    }

                    try
                    {

                        if (prod.Item2.Name.ToLower().StartsWith(e.NewTextValue))
                        {
                            _itemSearch.Add(prod.Item2);
                            //prod.Item1.IsVisible = false;
                        }

                    }
                    catch 
                    {
                       
                    }
                   
                }

                
                for (int i = 0; i <= _itemSearch.Count; i = i + 1)
                {
                    if (i < _itemSearch.Count - 1)
                    {
                        ItemPair pp = new ItemPair(_itemSearch[i], _itemSearch[i + 1]);
                        _listFiltered.Add(pp);
                    }
                    else if (i == _itemSearch.Count - 1)
                    {
                        ItemPair pp = new ItemPair(_itemSearch[i], null);
                        _listFiltered.Add(pp);
                    }
                }

                ListItems1.ItemsSource = _listFiltered;

            }

        }
        #endregion




    }
    
}