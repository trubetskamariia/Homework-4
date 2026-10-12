using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Task_5
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string OriginCountry { get; set; } = string.Empty;
        public DateTime PackagingDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;

        public virtual string ProductType => "Товар";
        public virtual string ExtraDetails => "-";
    }

    public class FoodProduct : Product
    {
        public int ExpirationDays { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;

        public override string ProductType => "Продукт";
        public override string ExtraDetails => $"Термін: {ExpirationDays} дн., К-ть: {Quantity} {Unit}";
    }

    public class BookProduct : Product
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new List<string>();

        public override string ProductType => "Книга";
        public override string ExtraDetails => $"Стор: {PageCount}, Вид-во: {Publisher}";
    }

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private int _foodCounter = 1;
        private int _bookCounter = 1;

        public MainPage()
        {
            InitializeComponent();
            SeedInitialData();
            ProductsGrid.ItemsSource = Products;
        }

        private void SeedInitialData()
        {
            Products.Add(new FoodProduct
            {
                Name = "Молоко 2.5%",
                Price = 42.50m,
                OriginCountry = "Україна",
                PackagingDate = DateTime.Now.AddDays(-2),
                Description = "Пастеризоване молоко",
                ExpirationDays = 10,
                Quantity = 1,
                Unit = "л"
            });

            Products.Add(new BookProduct
            {
                Name = "Кобзар",
                Price = 350.00m,
                OriginCountry = "Україна",
                PackagingDate = DateTime.Now.AddMonths(-1),
                Description = "Збірка творів",
                PageCount = 480,
                Publisher = "А-БА-БА-ГА-ЛА-МА-ГА",
                Authors = new List<string> { "Тарас Шевченко" }
            });
        }

        private void OnAddFoodClicked(object sender, EventArgs e)
        {
            Products.Add(new FoodProduct
            {
                Name = $"Яблука {_foodCounter}",
                Price = 30.00m + _foodCounter,
                OriginCountry = "Україна",
                PackagingDate = DateTime.Now,
                Description = "Свіжі яблука",
                ExpirationDays = 20,
                Quantity = 1.5,
                Unit = "кг"
            });

            _foodCounter++;
        }

        private void OnAddBookClicked(object sender, EventArgs e)
        {
            Products.Add(new BookProduct
            {
                Name = $"Книга #{_bookCounter}",
                Price = 200.00m + (_bookCounter * 10),
                OriginCountry = "Україна",
                PackagingDate = DateTime.Now,
                Description = "Художня література",
                PageCount = 200 + (_bookCounter * 5),
                Publisher = "Видавництво",
                Authors = new List<string> { "Автор" }
            });

            _bookCounter++;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (ProductsGrid.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
            }
            else
            {
                await DisplayAlertAsync("Помилка", "Будь ласка, оберіть товар у таблиці для видалення.", "OK");
            }
        }
    }
}