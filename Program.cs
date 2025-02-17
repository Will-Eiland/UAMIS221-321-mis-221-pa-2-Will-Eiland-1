// start main


using System.Security.Authentication.ExtendedProtection;

string userChoice = GetUserChoice();
while(userChoice != "3"){
    routeEm(userChoice);
    userChoice = GetUserChoice();
}
Goodbye();
//end main



static string GetUserChoice(){
    MenuDisplay();
    return Console.ReadLine();
}

static void routeEm(string userChoice){
    switch(userChoice){
        case "1":
            CurrencyConversion();
            Pause();
            break;
        case "2":
            ShippingInvoice();
            Pause();
            break;
        case "3":
            Goodbye();
            break;
        default:
            System.Console.WriteLine("Inpropper Input");
            Pause();
            break;
    }
}
//-------------------------------------------------------------
static void MenuDisplay(){
    Console.Clear();
    System.Console.WriteLine("  1.) Convert Currency");
    System.Console.WriteLine("  2.) Shipping Invoice");
    System.Console.WriteLine("  3.) Exit");
}

static void Goodbye(){
    System.Console.WriteLine("Have a good day! Goodbye");
}

static void Pause(){
    System.Console.WriteLine("Press any key to continue:\n");
    Console.ReadKey();
}
//-------------------------------------------------------------
static void CurrencyConversion(){
    string toCurrency = GetToCurrency();
    string fromCurrency = GetFromCurrency();
    System.Console.WriteLine($"What is the amount of {fromCurrency} do you want to see converted?");
    double currencyAmount = double.Parse(Console.ReadLine());
    ConversionSenario(toCurrency, fromCurrency, currencyAmount);   //prints end conversion
}

static string GetToCurrency(){
    System.Console.WriteLine("What currency are you converting to?");
    DisplayCurrencyMenu();
    bool validChoice = false;
    string userCurrency = "";
    while(!validChoice){
        userCurrency = Console.ReadLine();
        if ((userCurrency.ToUpper() == "YEN")||(userCurrency.ToUpper() == "YUAN")||(userCurrency.ToUpper() == "POUND")||(userCurrency.ToUpper() == "DOUBLOONS")||(userCurrency.ToUpper() == "DINAR")||(userCurrency.ToUpper() == "USD")||(userCurrency.ToUpper() == "DOLLAR")){
            validChoice = true;
        }
        else{
            System.Console.WriteLine("\tYou have entered an invalid currency");
            System.Console.WriteLine("\tPlease try agian");
        }
    }

    return userCurrency;
}

static string GetFromCurrency(){
    System.Console.WriteLine("What currency are you converting from?");
    DisplayCurrencyMenu();
    bool validChoice = false;
    string userCurrency = "";
    while(!validChoice){
        userCurrency = Console.ReadLine();
        if ((userCurrency.ToUpper() == "YEN")||(userCurrency.ToUpper() == "YUAN")||(userCurrency.ToUpper() == "POUND")||(userCurrency.ToUpper() == "DOUBLOONS")||(userCurrency.ToUpper() == "DINAR")||(userCurrency.ToUpper() == "USD")||(userCurrency.ToUpper() == "DOLLAR")){
            validChoice = true;
        }
        else{
            System.Console.WriteLine("\tYou have entered an invalid currency");
            System.Console.WriteLine("\tPlease try agian");
        }
    }

    return userCurrency;
}

static void DisplayCurrencyMenu(){
    System.Console.WriteLine(" - USD");
    System.Console.WriteLine(" - Yen");
    System.Console.WriteLine(" - Yuan");
    System.Console.WriteLine(" - Pound");
    System.Console.WriteLine(" - Dabloon");
    System.Console.WriteLine(" - Dinar");
}

static void ConversionSenario (string toCurrency,string fromCurrency, double currencyAmount){
    double displayAmount = 0.0;
    if (toCurrency.ToUpper() == "USD"){         //End at USD
        if (fromCurrency.ToUpper() == "YEN"){
            displayAmount = YenToUSD(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n Yen to USD\n ¥{currencyAmount} → ${displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YUAN"){
            displayAmount = YuanToUSD(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n Yuan to USD\n ¥{currencyAmount} → ${displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "POUND"){
            displayAmount = PoundToUSD(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n Pound to USD\n £{currencyAmount} → ${displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "DABLOON"){
            displayAmount = DabloonToUSD(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n Dabloon to USD\n {currencyAmount} → ${displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "DINAR"){
            displayAmount = DinarToUSD(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n Dinar to USD\n {currencyAmount} → ${displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "USD"){
            System.Console.WriteLine("You have entered the same 'to' and 'from' currency");
            System.Console.WriteLine($"Your conversion is :\n USD to USD\n ${currencyAmount} → ${currencyAmount}");
        }
    }
    else if(toCurrency.ToUpper() == "YEN"){      //End at Yen
        if (fromCurrency.ToUpper() == "USD"){
            displayAmount = USDToYen(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n USD to Yen\n ${currencyAmount} → ¥{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YUAN"){
            displayAmount = YuanToUSD(currencyAmount);
            displayAmount = USDToYen(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yuan to Yen\n ¥{currencyAmount} → ¥{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "POUND"){
            displayAmount = PoundToUSD(currencyAmount);
            displayAmount = USDToYen(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Pound to Yen\n c{currencyAmount} → ¥{displayAmount}");            
        }
        else if (fromCurrency.ToUpper() == "DABLOON"){
            displayAmount = DabloonToUSD(currencyAmount);
            displayAmount = USDToYen(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dabloon to Yen\n {currencyAmount} → ¥{displayAmount}");               
        }
        else if (fromCurrency.ToUpper() == "DINAR"){
            displayAmount = DinarToUSD(currencyAmount);
            displayAmount = USDToYen(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dinar to Yen\n {currencyAmount} → ¥{displayAmount}");   
        }
        else if (fromCurrency.ToUpper() == "YEN"){
            System.Console.WriteLine("You have entered the same 'to' and 'from' currency");
            System.Console.WriteLine($"Your conversion is :\n Yen to Yen\n ¥{currencyAmount} → ¥{currencyAmount}");
        }
    }
    else if(toCurrency.ToUpper() == "YUAN"){    //End at Yuan
        if (fromCurrency.ToUpper() == "USD"){
            displayAmount = USDToYuan(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n USD to Yuan\n ${currencyAmount} → ¥{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YEN"){
            displayAmount = YenToUSD(currencyAmount);
            displayAmount = USDToYuan(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yen to Yuan\n ¥{currencyAmount} → ¥{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "POUND"){
            displayAmount = PoundToUSD(currencyAmount);
            displayAmount = USDToYuan(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Pound to Yuan\n £{currencyAmount} → ¥{displayAmount}");            
        }
        else if (fromCurrency.ToUpper() == "DABLOON"){
            displayAmount = DabloonToUSD(currencyAmount);
            displayAmount = USDToYuan(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dabloon to Yuan\n {currencyAmount} → ¥{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "DINAR"){
            displayAmount = DinarToUSD(currencyAmount);
            displayAmount = USDToYuan(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dinar to Yuan\n {currencyAmount} → ¥{displayAmount}"); 
        }
        else if (fromCurrency.ToUpper() == "YUAN"){
            System.Console.WriteLine("You have entered the same 'to' and 'from' currency");
            System.Console.WriteLine($"Your conversion is :\n Yuan to Yuan\n ¥{currencyAmount} → ¥{currencyAmount}");
        }
    }
    else if(toCurrency.ToUpper() == "POUND"){    //End at Pound
        if (fromCurrency.ToUpper() == "USD"){
            displayAmount = USDToPound(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n USD to Pound\n ${currencyAmount} → £{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YEN"){
            displayAmount = YenToUSD(currencyAmount);
            displayAmount = USDToPound(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yen to Pound\n ¥{currencyAmount} → £{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YUAN"){
            displayAmount = YuanToUSD(currencyAmount);
            displayAmount = USDToPound(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yuan to Pound\n ¥{currencyAmount} → £{displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "DABLOON"){
            displayAmount = DabloonToUSD(currencyAmount);
            displayAmount = USDToPound(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dabloon to Pound\n {currencyAmount} → £{displayAmount}");            
        }
        else if (fromCurrency.ToUpper() == "DINAR"){
            displayAmount = DinarToUSD(currencyAmount);
            displayAmount = USDToPound(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dinar to Pound\n {currencyAmount} → £{displayAmount}"); 
        }
        else if (fromCurrency.ToUpper() == "POUND"){
            System.Console.WriteLine("You have entered the same 'to' and 'from' currency");
            System.Console.WriteLine($"Your conversion is :\n Pound to Pound\n £{currencyAmount} → £{currencyAmount}");
        }
    } 
    else if(toCurrency.ToUpper() == "DABLOON"){   //End at Dabloon
        if (fromCurrency.ToUpper() == "USD"){
            displayAmount = USDToDabloon(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n USD to Dabloon\n ${currencyAmount} → {displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YEN"){
            displayAmount = YenToUSD(currencyAmount);
            displayAmount = USDToDabloon(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yen to Dabloon\n ¥{currencyAmount} → {displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YUAN"){
            displayAmount = YuanToUSD(currencyAmount);
            displayAmount = USDToDabloon(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yuan to Dabloon\n ¥{currencyAmount} → {displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "POUND"){
            displayAmount = PoundToUSD(currencyAmount);
            displayAmount = USDToDabloon(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Pound to Dabloon\n £{currencyAmount} → {displayAmount}");            
        }
        else if (fromCurrency.ToUpper() == "DINAR"){
            displayAmount = DinarToUSD(currencyAmount);
            displayAmount = USDToDabloon(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dinar to Dabloon\n {currencyAmount} → {displayAmount}"); 
        }
        else if (fromCurrency.ToUpper() == "DABLOON"){
            System.Console.WriteLine("You have entered the same 'to' and 'from' currency");
            System.Console.WriteLine($"Your conversion is :\n Dabloon to Dabloon\n {currencyAmount} → {currencyAmount}");
        }
    }
    else if(toCurrency.ToUpper() == "DINAR"){       //End at Dinar
        if (fromCurrency.ToUpper() == "USD"){
            displayAmount = USDToDinar(currencyAmount);
            System.Console.WriteLine($"Your conversion is :\n USD to Dinar\n ${currencyAmount} → {displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YEN"){
            displayAmount = YenToUSD(currencyAmount);
            displayAmount = USDToDinar(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yen to Dinar\n ¥{currencyAmount} → {displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "YUAN"){
            displayAmount = YuanToUSD(currencyAmount);
            displayAmount = USDToDinar(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Yuan to Dinar\n ¥{currencyAmount} → {displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "POUND"){
            displayAmount = PoundToUSD(currencyAmount);
            displayAmount = USDToDabloon(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Pound to Dabloon\n £{currencyAmount} → {displayAmount}");            
        }
        else if (fromCurrency.ToUpper() == "DABLOON"){
            displayAmount = DabloonToUSD(currencyAmount);
            displayAmount = USDToDinar(displayAmount);
            System.Console.WriteLine($"Your conversion is :\n Dabloon to Dinar\n {currencyAmount} → {displayAmount}");
        }
        else if (fromCurrency.ToUpper() == "DINAR"){
            System.Console.WriteLine("You have entered the same 'to' and 'from' currency");
            System.Console.WriteLine($"Your conversion is :\n Dinar to Dinar\n {currencyAmount} → {currencyAmount}");
        }
    }
}


static double USDToYen(double input){
    return input / 0.0064;    // ex)  1 usd = 152 yen
}
static double YenToUSD(double input){
    return input * 0.0064;
}
static double USDToYuan(double input){
    return input / 0.14;      // ex)  1 usd = ~7.2 yuan
}
static double YuanToUSD(double input){
    return input * 0.14;
}
static double USDToPound(double input){
    return input / 1.22;      // ex)  1 usd = 0.82 Pound 
}
static double PoundToUSD(double input){
    return input * 1.22;
}
static double USDToDabloon(double input){
    return input / 8.40;      // ex)  1 usd = 0.12 Dabloon
}
static double DabloonToUSD(double input){
    return input * 8.40;
}
static double USDToDinar(double input){
    return input / 0.0074;      // ex)  1 usd = 135.14 Dinar
}
static double DinarToUSD(double input){
    return input * 0.0074;
}


//-------------------------------------------------------------
static void ShippingInvoice(){
    int weight = GetWeight();
    bool isPerishable = GetIsPerishable();
    bool hasExpressShipping = GetExpressShipping();
    double totalOwed = GetTotalOwed(weight, isPerishable, hasExpressShipping);
    System.Console.WriteLine($"You owe ${totalOwed}.  Please input the amount you would like to pay.");
    double amountPaid = double.Parse(Console.ReadLine());
    while (amountPaid < totalOwed){
        System.Console.WriteLine("Error: The amount you paid is less than Amout Owed");
        System.Console.WriteLine($"You owe ${totalOwed}.  Please input the amount you would like to pay.");
        amountPaid = double.Parse(Console.ReadLine());
    }
    System.Console.WriteLine($"Thank you for your patronage!  You are owed ${amountPaid - totalOwed} in change");

}

static int GetWeight(){
    int weightInTons = 0;
    System.Console.WriteLine("How many tons is your item/container?");
    double userInput = double.Parse(Console.ReadLine());
    while (userInput < 0){
        System.Console.WriteLine("Invlaid Input");
        System.Console.WriteLine("How many tons is your item/container?");
        userInput = double.Parse(Console.ReadLine());
    }
    double temp = userInput;
    while (temp >=1){
        weightInTons++;
        temp--;
    }
    return weightInTons;
}
static bool GetIsPerishable(){
    bool isPerishable = true;
    System.Console.WriteLine("Is your item perishable? Type '1' for YES,  '2' for NO");
    string userInput = Console.ReadLine();
    while (userInput != "1" && userInput != "2" && userInput.ToUpper() == "YES" && userInput.ToUpper() == "NO"){
        System.Console.WriteLine("Invalid input");
        System.Console.WriteLine("Is your item perishable? Type '1' for YES,  '2' for NO");
        userInput = Console.ReadLine();
    }
    if (userInput == "1" || userInput.ToUpper() == "YES"){
        return isPerishable = true;
    }
    else if (userInput == "2" || userInput.ToUpper() == "NO"){
        return isPerishable == false;
    }
    else{
        return isPerishable == false;
    }

}
static bool GetExpressShipping(){
    bool hasExpressShipping = true;
    System.Console.WriteLine("Do you want Express Shipping? Type '1' for YES,  '2' for NO");
    string userInput = Console.ReadLine();
    while (userInput != "1" && userInput != "2" && userInput.ToUpper() == "YES" && userInput.ToUpper() == "NO"){
        System.Console.WriteLine("Invalid input");
        System.Console.WriteLine("Do you want Express Shipping? Type '1' for YES,  '2' for NO");
        userInput = Console.ReadLine();
    }
    if (userInput == "1" || userInput.ToUpper() == "YES"){
        return hasExpressShipping = true;
    }
    else if (userInput == "2" || userInput.ToUpper() == "NO"){
        return hasExpressShipping == false;
    }
    else{
        return hasExpressShipping == false;
    }
}
static double GetTotalOwed(double weight, bool isPerishable, bool hasExpressShipping){
    double totalOwed = 0.0;
    totalOwed = weight * 220.40;
    if (isPerishable == true){
        totalOwed += 230 * weight;
    }
    if (hasExpressShipping == true){
        totalOwed = totalOwed * 1.25;
    }

    return totalOwed;
}

