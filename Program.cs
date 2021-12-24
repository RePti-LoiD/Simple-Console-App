using System;
//using System.IO.Packaging;
using System.Collections.Generic;
using System.Linq;

namespace LogicsSS
{

    public class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.White;
            //Console.ResetColor(); // сбрасываем в стандартный
            User user = new User(11f, "Valera Bebris", "160216038307Se");
            user.DebugLog();

            
            UXs ui = new UXs();
            ui.Main(user);
            //Script PRODUCT

            //Vibrator vibrator = new Vibrator("gogziga", "ANAL LIZAL");
            //vibrator.DebugLogItem();
            Product catalog = new Product();
            catalog.MainProductVoid(user);
            //Script PRODUCT
            
            Console.ReadLine();
            //end
        }
        class UXs
        {
            List<string> commands = new List<string>();
            Random rand = new Random();

            User ReturnUser(User user) => user;
            User _USER = new User();

            int BankMoney = 0;

            public void Main(User user)
            {
                BankMoney = rand.Next(15532);
                Cmd(user, true);
            }
            private void UserCommands()
            {
                commands.Add("Refill");
                commands.Add("Bin");
                commands.Add("Wallet");
                commands.Add("Buy History");
                commands.Add("Catalog");
                commands.Add("Account");
                commands.Add("History");
                commands.Add("Change Password");
                commands.Add("Buy");
                commands.Add("Exit");
                Console.WriteLine($"HELLO {_USER._UserName} IN SEX SHOP:");
                for (int i = 0; i < commands.Count; i++)
                {
                    Console.WriteLine($"--{commands[i]}--");
                }
            }
            private void DebugHistory()
            {
                List<string> l = new List<string>();
                foreach (string elem in _USER.Hisory)
                {
                    if (_USER.Hisory.Count() > 0)
                    {
                        Console.WriteLine(elem);
                    }
                    else
                    {
                        Console.WriteLine("History is empty");
                    }
                }
            }
            private void Refill()
            {
                Console.WriteLine($"Choose wallet:
Qiwi
Visa
WebMoney
Tinkoff");
                string Wallet = Console.ReadLine();
                Console.WriteLine($"On your account({BankMoney}), to refill:");
                int Refill = Convert.ToInt32(Console.ReadLine());
                if (Refill <= BankMoney)
                {
                    _USER._OnCard += Refill;
                    BankMoney -= Refill;
                    Saver("Bank", Wallet);
                    Saver("Sum", Refill.ToString());
                    Console.WriteLine($"Success, your current Balance({_USER._OnCard})");
                }
                else
                {
                    Console.WriteLine($"Bank rejected the request (uncorrect value)
Bank({BankMoney})" +
                        $"
Your request({Refill})");
                }
            }
            Product InsideProduct = new Product();
            public Product ProductInitialize(Product product)
            {
                return product;
            }
            private void Saver(string name, string info)
            {
                var time = DateTime.UtcNow;
                switch (name)
                {
                    case "Bank":
                        _USER.History($"Bank:{info}    " +
                            $"({DateTime.Now.ToString("HH:mm:ss")})");
                        break;
                    case "Sum":
                        _USER.History($"Operation:{info}    " +
                            $"({DateTime.Now.ToString("HH:mm:ss")})");
                        break;
                    case "Password":
                        _USER.History($"Password:{info}    " +
                            $"({DateTime.Now.ToString("HH:mm:ss")})");
                        break;
                    case "Json":
                        //string jsonString = JsonSerializer.Serialize(weatherForecast);
                        break;
                }
            }
            private void ChangePassword()
            {
                Console.WriteLine($"Curret Password:{_USER._Password}
If u wanna change it(Y)(N)");
                string Change = Console.ReadLine();
                if (Change == "Y")
                {
                    Change = Console.ReadLine();
                    _USER._Password = Change;
                    Saver("Password", Change);
                }
            }
            private void CommandManager(string input)
            {
                switch (input)
                {
                    case "Refill":
                        Refill();
                        break;
                    case "Bin":
                        _USER.WriteUserBin();
                        break;
                    case "Info":
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"__________________________________________________________________
" +
                            $"      Hello {_USER._UserName}
       For refill your balance: Refill
" +
                            $"          For Show yout item bin: Bin
" +
                            $"          For Check your Balance: Wallet
" +
                            $"          For Check all history: Buy History
" +
                            $"          For go to Catalog: Catalog
" +
                            $"          For check all account info: Account
" +
                            $"          For Change Password: Change Password
" +
                            $"          For Buy all in Bin: Buy
" +
                            $"          For Exit: Exit" +
                            $"
__________________________________________________________________");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case "Wallet":
                        Console.WriteLine($"Your current balance: {_USER._OnCard}");
                        break;
                    case "Buy History":
                        Console.WriteLine("In Develop");
                        break;
                    case "Catalog":
                        Product temp = new Product();
                        temp.MainProductVoid(_USER);
                        //Console.WriteLine("In Develop");
                        break;
                    case "Account":
                        _USER.DebugLog();
                        break;
                    case "History":
                        DebugHistory();
                        break;
                    case "Change Password":
                        ChangePassword();
                        break;
                    case "Buy":
                        _USER.BuyProduct();
                        break;
                    case "Exit":
                        Environment.Exit(0);
                        break;
                }
            }
            private void Cmd(User user, bool IsBreak)
            {
                _USER = ReturnUser(user);
                UserCommands();
                while (IsBreak)
                {
                    Console.WriteLine("Command");
                    string Command = Console.ReadLine();
                    Console.WriteLine("----------------");
                    CommandManager(Command);
                }
            }
        }


        class User
        {
            public float _OnCard { get; set; }
            public string _UserName { get; set; }
            public string _Password { get; set; }
            public User() { }
            public User(float OnCard, string UName, string Password)
            {
                _OnCard = OnCard;
                _UserName = UName;
                _Password = Password;
            }
            public List<Product> _UserBin = new List<Product>();

            public void WriteUserBin()
            {
                foreach (Product product in _UserBin)
                {
                    Console.WriteLine((product._ProductName, product._ProductCost,
                        product._ProductID, product._Description));
                }
            }
            public float TotalCost()
            {
                float TempCost = 0f;
                foreach (Product product in _UserBin)
                {
                    TempCost += product._ProductCost;
                    Console.WriteLine(TempCost);
                }
                //Console.WriteLine($"Total Cost: {TempCost}");
                return TempCost;
            }
            public void BuyProduct()
            {
                float TempCost = 0f;
                TempCost = TotalCost();
                if (TempCost <= _OnCard)
                {
                    _OnCard -= TempCost;
                    _UserBin.Clear();
                }
                else
                {
                    Console.WriteLine("Bin empty | Not enough money on balance");
                }
            }
            public void DebugLog()
            {
                Console.WriteLine($"NAME: { _UserName }
Balance: { _OnCard }$
Password: { _Password }");
            }
            public List<string> Hisory = new List<string>();
            public void History(string AnyMove)
            {
                Hisory.Add(AnyMove);
            }
        }
        class Product
        {
            public string _ProductName { get; set; }
            public string _ProductID { get; set; }
            public float _ProductCost { get; set; }
            public string _Description { get; set; }
            List<Product> _Products = new List<Product>();
            public Product() { }
            public User ReturnUser(User user) => user;
            User UserBin = new User();
            private void CreatorCatalog()
            {
                Product Dildo = new Product("Dildo", "15135", 1005f, "GOOD DILDO");
                Product Condom = new Product("Condom", "1543", 100f, "GOOD CONDOM");
                Product Semen = new Product("Semen", "16546", 1f, "GOOD SEMEN");
                Product Vagina = new Product("Vagina", "5445", 10000f, "GOOD Vagina");
                Product Balls = new Product("Balls", "14504", 550f, "GOOD Balls");
                Product AnalBall = new Product("AnalBall", "4504", 350f, "GOOD Ball");
                Product Govogen = new Product("Govogen", "45707", 560f, "GOOD Govogen");
                Product SilkAnal = new Product("SilkAnal", "4570", 5000f, "GOOD Anal");
                Product SilkVagine = new Product("SilkVagine", "45704", 7000f, "GOOD Vagine");
                _Products.Add(Dildo);
                _Products.Add(Condom);
                _Products.Add(Semen);
                _Products.Add(Vagina);
                _Products.Add(Balls);
                _Products.Add(AnalBall);
                _Products.Add(Govogen);
                _Products.Add(SilkAnal);
                _Products.Add(Vagina);
            }
            private void CatalogManager(string input)
            {
                switch (input)
                {
                    case "Show Catalog":
                        foreach (Product product in _Products)
                        {
                            Console.WriteLine($"    
{product._ProductName}" +
                                $"
Cost: {product._ProductCost}" +
                                $"
ID: {product._ProductID}" +
                                $"
Description: {product._Description}");
                        }
                        break;
                    case "Add to bin":
                        AddToBin();
                        Console.WriteLine($"Total Cost: {UserBin.TotalCost()}");
                        break;
                }
            }
            private void AddToBin()
            {
                string Input = "";
                Console.WriteLine("You can add items on your bin(use index)");
                while(true)
                {
                    Input = Console.ReadLine();
                    try
                    {
                        int InputIndex = int.Parse(Input);
                        if (InputIndex <= _Products.Count())
                        {
                            UserBin._UserBin.Add(_Products[InputIndex]);
                            Console.WriteLine($"Added: {_Products[InputIndex]._ProductName}");
                        }
                    }
                    catch
                    {
                        if (Input == "Exit") 
                        { 
                            Console.WriteLine("All items added in BIN");
                            break; 
                        }
                        Console.WriteLine("Uncorrect Value | Index out of range");
                    }   
                }
            }
            public Product(string name, string id, float cost, string descr)
            {
                _ProductName = name;
                _ProductID = id;
                _ProductCost = cost;
                _Description = descr;
            }
            public void MainProductVoid(User user)
            {
                UserBin = ReturnUser(user);
                Console.WriteLine($"{UserBin._UserName}, YOU IN CATALOG");
                Console.WriteLine("Command");
                bool IsDo = true;
                CreatorCatalog();
                while (IsDo)
                {
                    string Input = Console.ReadLine();
                    CatalogManager(Input);
                    if (Input == "Exit")
                    {
                        UXs ui = new UXs();
                        ui.Main(user);
                        Console.WriteLine("Return to main");
                        IsDo = false;
                        break;
                    }
                }  
            }
        }
    }
}
