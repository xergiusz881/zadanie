using System;
using System.Globalization; //<--twój kod obsługuję formaty dat,godzin,liczb
                            //-porównywanie i sortowanie ciągów znaków
                            //-informacje o języku i regionie użytkownika
using ShopCsharp;

// Lista przechowująca produkty w magazynie
List<Product> storage = new List<Product>();

// Funkcja dodająca nowy produkt do magazynu
void AddProduct()          //nazywa się: AddProduct,

                        //nie przyjmuje argumentów (puste nawiasy ()),

                    //nie zwraca żadnej wartości (typ void oznacza brak zwracanej wartości),
{
    Console.WriteLine("Podaj nazwę produktu: ");
    string name = Console.ReadLine();
    Console.WriteLine("Podaj kod kreskowy: ");
    string barcode = Console.ReadLine();
    Console.WriteLine("Podaj cenę: ");
    if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
    {
        Console.WriteLine("Nieprawidłowy format ceny.");
        return;
    }
    Console.WriteLine("Podaj ilość: ");
    if (!float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out float amount))
    {
        Console.WriteLine("Nieprawidłowy format ilości.");
        return;
    }

    // Tworzenie nowego produktu i dodanie go do listy
    Product newProduct = new Product(barcode, name, price, amount);
    storage.Add(newProduct);
}

// Funkcja usuwająca produkt z magazynu
void RemoveProduct()
{
    Console.WriteLine("Podaj nazwę produktu do usunięcia: ");
    string name = Console.ReadLine();
    // Znalezienie produktu do usunięcia
    Product productToRemove = storage.Find(product => product.Name == name);
    if (productToRemove != null)
    {
        storage.Remove(productToRemove);
        Console.WriteLine("Produkt usunięty.");
    }
    else
    {
        Console.WriteLine("Produkt nie znaleziony.");
    }
}

// Funkcja wyświetlająca listę produktów w magazynie
void DisplayProducts()
{
    foreach (Product prod in storage)
    {
        Console.WriteLine("produkt o nazwie: " + prod.Name +
            " o kodzie kreskowym: " + prod.Barcode +
            " kosztuje: " + prod.Price + "zł");
    }
}

// Funkcja aktualizująca dane produktu w magazynie
void UpdateProduct()
{
    Console.WriteLine("Podaj nazwę produktu do aktualizacji: ");
    string name = Console.ReadLine();
    // Znalezienie produktu do aktualizacji
    Product productToUpdate = storage.Find(product => product.Name == name);
    if (productToUpdate != null)
    {
        Console.WriteLine("Podaj nową cenę: ");
        productToUpdate.Price = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Podaj nową ilość: ");
        productToUpdate.Amount = Convert.ToSingle(Console.ReadLine());
        Console.WriteLine("Produkt zaktualizowany.");
    }
    else
    {
        Console.WriteLine("Produkt nie znaleziony.");
    }
}

// Funkcja obliczająca całkowitą wartość produktów w magazynie
void CalculateTotalValue()
{
    double totalValue = 0;
    foreach (Product prod in storage)
    {
        totalValue += prod.Price * prod.Amount;
    }
    Console.WriteLine("Wartość całego magazynu: " + totalValue + "zł");
}

// Pętla główna programu
bool exit = false;
while (!exit)
{
    Console.WriteLine("Wybierz opcję:");
    Console.WriteLine("1. Dodaj produkt");
    Console.WriteLine("2. Usuń produkt");
    Console.WriteLine("3. Wyświetl listę produktów");
    Console.WriteLine("4. Aktualizuj produkt");
    Console.WriteLine("5. Oblicz wartość magazynu");
    Console.WriteLine("6. Wyjście");

    // Wybór opcji przez użytkownika
    int choice = Convert.ToInt32(Console.ReadLine());   //Console.ReadLine() – odczytuje tekst wpisany przez użytkownika w konsoli (zwraca string).

                            //Convert.ToInt32(...) – konwertuje ten tekst na liczbę całkowitą(int).

                            //int choice = – przypisuje wynik do zmiennej choice typu int.
    switch (choice)
    {
        case 1:
            AddProduct();
            break;
        case 2:
            RemoveProduct();
            break;
        case 3:
            DisplayProducts();
            break;
        case 4:
            UpdateProduct();
            break;
        case 5:
            CalculateTotalValue();
            break;
        case 6:
            exit = true;
            break;
        default:
            Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie.");
            break;
    }
}