using Menu.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {

        private List<ItemPair> itemList;
        public List<ItemPair> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged();

            }
        }

        List<ItemPair> _item = new List<ItemPair>();
        List<Item> _itemcategorie = new List<Item>();
        List<Item> _itemSearch = new List<Item>();

        List<ItemPair> _listFiltered = new List<ItemPair>();


        public List<ItemPair> LoadTheListOfItems()
        {
            _item.Add(new ItemPair(new Item() { Id = "1", Image = "handbag.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true, Categorie="Shoes" },
                                   new Item() { Id = "1", Image = "holder.png", Name = "Gucci Browni holder", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true,Categorie = "Bags" }));

            _item.Add(new ItemPair(new Item() { Id = "1", Image = "handbag.png", Name = "Sun glasses", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true,Categorie = "Bags" },
                                   new Item() { Id = "1", Image = "holder.png", Name = "Gucci hand bag light brown", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true, Categorie = "Bags" }));

            _item.Add(new ItemPair(new Item() { Id = "1", Image = "handbag.png", Name = "hand bag Natural leather", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true, Categorie = "Accessories" },
                                   new Item() { Id = "1", Image = "holder.png", Name = "Evening shoes hight heels", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true , Categorie = "Bags" }));

            _item.Add(new ItemPair(new Item() { Id = "1", Image = "handbag.png", Name = "Concord hand watch", Description = "Almost new", Price = "3000.00 SAR", IsVisible = true , Categorie = "Travel" },
                null));

            return _item;
        }



        public ShopPage()
        {
            InitializeComponent();
            ItemList = LoadTheListOfItems();
            ListItems1.ItemsSource = ItemList;

        }


        #region for the scroll tap item
        void Settings_Clicked(object sender, EventArgs e)
        {

            //ShoesPart.TextColor = Color.White;
            //TravelPart.TextColor = Color.Gray;
            //BagsPart.TextColor = Color.Gray;
            //AccessoriesPart.TextColor = Color.Gray;


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
                    if (pp.Item1.Categorie =="Shoes")
                    {
                        _itemcategorie.Add(pp.Item1);
                    }
                    if (pp.Item2.Categorie == "Shoes")
                    {
                        _itemcategorie.Add(pp.Item2);
                    }
                }
                // adding the item list to aN ITEM PAIR LIST
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

                ListItems1.ItemsSource = _listFiltered;

            }


            // For the travel categorie
            else if (sender.Equals(TravelPart))
            {
                _itemcategorie = new List<Item>();
                ShoesPart.TextColor = Color.Gray;
                TravelPart.TextColor = Color.White;
                BagsPart.TextColor = Color.Gray;
                AccessoriesPart.TextColor = Color.Gray;

                TravelPart.FontSize = 24;
                ShoesPart.FontSize = 18;
                BagsPart.FontSize = 18;
                AccessoriesPart.FontSize = 18;


                // filter the pair list and add it to an Itel list
                foreach (ItemPair pp in ItemList)
                {
                    if (pp.Item1.Categorie == "Travel")
                    {
                        _itemcategorie.Add(pp.Item1);
                    }
                    if (pp.Item2.Categorie == "Travel")
                    {
                        _itemcategorie.Add(pp.Item2);
                    }
                }
                // adding the item list to aN ITEM PAIR LIST
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

                ListItems1.ItemsSource = _listFiltered;

            }

            // For the Bags categorie Bags
            else if (sender.Equals(BagsPart))
            {
                _itemcategorie = new List<Item>();
                ShoesPart.TextColor = Color.Gray;
                TravelPart.TextColor = Color.Gray;
                BagsPart.TextColor = Color.White;
                AccessoriesPart.TextColor = Color.Gray;

                TravelPart.FontSize = 18;
                ShoesPart.FontSize = 18;
                BagsPart.FontSize = 24;
                AccessoriesPart.FontSize = 18;


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
                // adding the item list to aN ITEM PAIR LIST
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

                ListItems1.ItemsSource = _listFiltered;

            }

            // For the Bags categorie Accessories
            else 
            {
                _itemcategorie = new List<Item>();
                ShoesPart.TextColor = Color.Gray;
                TravelPart.TextColor = Color.Gray;
                BagsPart.TextColor = Color.Gray;
                AccessoriesPart.TextColor = Color.White;

                TravelPart.FontSize = 18;
                ShoesPart.FontSize = 18;
                BagsPart.FontSize = 24;
                AccessoriesPart.FontSize = 18;


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
                // adding the item list to aN ITEM PAIR LIST
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

                ListItems1.ItemsSource = _listFiltered;

            }

        }
        #endregion

        #region for the search bar 

        private void OnSearch(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ListItems1.ItemsSource = ItemList;
            }

            else
            {

                _itemSearch = new List<Item>();

                foreach (var prod in ItemList)
                {


                    if (prod.Item1.Name.ToLower().Contains(e.NewTextValue.ToLower()))
                    {
                        _itemSearch.Add(prod.Item1);
                        prod.Item2.IsVisible = false;
                    }

                    if (prod.Item2.Name.ToLower().Contains(e.NewTextValue.ToLower()))
                    {
                        _itemSearch.Add(prod.Item2);
                        prod.Item1.IsVisible = false;
                    }

                }
                ItemList = new List<ItemPair>();
                for (int i = 0; i <= _itemSearch.Count; i = i + 2)
                {
                    if (i < _itemSearch.Count - 1)
                    {
                        ItemPair pp = new ItemPair(_itemSearch[i], _itemSearch[i + 1]);
                        ItemList.Add(pp);
                    }
                    else if (i == _itemSearch.Count - 1)
                    {
                        ItemPair pp = new ItemPair(_itemSearch[i], null);
                        ItemList.Add(pp);
                    }
                }

                ListItems1.ItemsSource = ItemList;

            }

        }
        #endregion




    }
    
}