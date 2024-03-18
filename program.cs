// zad 1
using System.Collections;

List<int> T = new List<int>();
Random random = new Random();
for (int i = 0; i < 5; i++) {
    T.Add(random.Next(10, 100));
}
foreach (int n in T) { Console.Write(n + " "); }
List<int> W = new List<int>();
for (int i = T.Min(); i <= T.Max(); i++) {
    if (i % 2 == 0) {
        W.Add(i);
        i += 2;
    }
}
Console.WriteLine();
foreach (int n in W) { Console.Write(n + " "); }
Console.WriteLine();
// zad 2
ArrayList A = new ArrayList();
string letters = "abcdefghijklmnopqrstuvwxyz";
for (int i = 0; i < 10; i++) {
    string word = "";
    for (int j = 0; j < 3; j++) {
        word += letters[random.Next(0, letters.Length)];
    }
    A.Add(word);
}
int maxLength = 0;
string wordResult = "";
foreach (string item in A) {
    Console.Write(item + " ");
    if (lengthOfASCII(item) >= maxLength) {
        maxLength = lengthOfASCII(item);
        wordResult = item;
    }
}
Console.WriteLine();
Console.WriteLine($"slowo o najwiekszej sumie kodow ascii {maxLength} i to jest slowo - {wordResult}");

// zad 3
List<List<int> > L = new List<List<int> >();

for (int i = 0; i < 10; i++) {
    List<int> R = new List<int>();
    for (int j = 0; j < 10; j++) {
        R.Add(random.Next (0, 10));
    }
    L.Add(R);
}
List<int> sumOfDigits = new List<int> ();
int INTsumOfDigits;
foreach (List<int> R in L) {
    INTsumOfDigits = 0;
    for (int i = 0; i < R.Count; i++) {
        INTsumOfDigits += R[i];
    }
    if (moreThan3x(R, 3)) {
        Console.Write("Jest taka lista - ");
        foreach (int n in R) { Console.Write(n + " "); }
        Console.WriteLine();
    }
    sumOfDigits.Add(INTsumOfDigits);
}
Console.WriteLine($"max sum of digits in Lists in list is {sumOfDigits.Max()}");

// zad 4
Dictionary<int, List<int> > D = new Dictionary<int, List<int> > ();
Console.Write("Wpisz ilosc elementow w Dictionary: ");
int ilosc = int.Parse (Console.ReadLine());
for (int i = 1; i <= ilosc; i++) {
    List<int> dzielniki = GetDivisors((int)Math.Pow(10, i));
    D.Add(i, dzielniki);
}
foreach (var item in D) {
    Console.Write($"{item.Key}: ");
    foreach (var dzielnik in item.Value) {
        Console.Write($"{dzielnik} ");
    }
    Console.WriteLine();
}

// zad 5
Dictionary<int, List<int>> graf = new Dictionary<int, List<int>>();
int n2 = int.Parse(Console.ReadLine());
for (int i = 1; i <= n2; i++) {
    graf.Add(i, new List<int>());
}
int k = int.Parse(Console.ReadLine());

string[] Liczby;
int a, b;
for (int i = 0; i < k; i++) {
    Liczby = Console.ReadLine().Split();
    a = int.Parse(Liczby[0]);
    b = int.Parse(Liczby[1]);
    graf[a].Add(b);
    graf[b].Add(a);
}

int noNeighborCount = 0;
foreach (var item in graf) {
    if (item.Value.ToList().Count == 0) {
        Console.WriteLine($"Wierzcholek {item.Key} nie ma sasiadow");
        noNeighborCount++;
    }
}
Console.WriteLine($"{noNeighborCount} wierzcolkow nie ma sasiada");
int lengthOfASCII (string s) {
int max = 0;
foreach (char c in s) {
    max += (int)c;
}
    return max;
}

bool moreThan3x(List<int> list, int digit) {
    Dictionary<int, int> D = new Dictionary<int, int>();
    foreach (int n in list) {
        if (!(D.ContainsKey (n))) {
            D.Add(n, 0);
        }
        if (D.ContainsKey (n)) {
            D[n]++;
        }
    }
    foreach (var item in D) {
        if (item.Value == digit) {
            return true;
        }
    }
    return false;
}

List<int> GetDivisors(int number) {
    List<int> dzielniki = new List<int>();
    for (int i = 1; i < Math.Sqrt(number); i++) {
        if (number % i == 0) {
            dzielniki.Add(i);
            if (number / i != i) {
                dzielniki.Add(number / i);
            }
        }
    }
    return dzielniki;
}
