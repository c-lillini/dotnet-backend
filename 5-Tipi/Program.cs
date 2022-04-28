// See https://aka.ms/new-console-template for more information

// Tipo intero
int a = 5;
int b = a + 2;

// Tipo booleano
bool test = true;

// Espressione errata
int c = a + test;

// Espressione corretta
int c = a + Convert.ToInt16(test);

// Tipo float, stringa e classe:
float temperature;
string name;
MyClass myClass;

// Dichiarazione con inizializzazione:
char firstLetter = 'C';
var limit = 3;
int[] source = { 0, 1, 2, 3, 4, 5 };

// Leggere il tipo
Type type = source.GetType();
Console.WriteLine(type);

// Tipi generici
List<string> stringList = new List<string>();
stringList.Add("String example");
// Errore di compilazione
stringList.Add(4);

class MyClass
{
    private string[] names = { "Spencer", "Sally", "Doug" };

    public string GetName(int ID)
    {
        if (ID < names.Length)
            return names[ID];
        else
            return String.Empty;
    }

}






