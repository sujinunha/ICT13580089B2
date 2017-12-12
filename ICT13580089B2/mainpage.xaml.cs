using System;
using System.Collections.Generic;
using ICT13580089B2.Models;
using Xamarin.Forms;

namespace ICT13580089B2
{
    public partial class mainpage : ContentPage
    {
        public mainpage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;
        }

        protected override void OnAppearing()
        {
            LoadData();
        }


        void LoadData()
        {
            productListView.ItemsSource = App.DbHelper.GetProducts();
        }

        void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewPage());
        }

        void Edit_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductNewPage(product));
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;

            var isyes = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");

            if(isyes)
            {
                App.DbHelper.DeleteProduct(product);
                LoadData();
            }
        }
    }
}
