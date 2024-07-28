
#include <iostream>
#include <ctime>

constexpr int MAX_SIZE { 20 };

void creaArray(int array[MAX_SIZE]);
void controllaValoreArray(int& numero);
void trovaValoriTramiteSomma(int array[MAX_SIZE], int numero);

int main()
{
    int array[MAX_SIZE];
    srand(time(NULL));
    int numero { 0 };

    creaArray(array);
    controllaValoreArray(numero);
    trovaValoriTramiteSomma(array, numero);

    return EXIT_SUCCESS;
}

void creaArray(int array[MAX_SIZE])
{
    // Generazione e stampa di un array di numeri interi casuali compresi tra 1 e 100.
    for (int i { 0 }; i < MAX_SIZE; i++)
        array[i] = 1 + rand() % 100;

    std::cout << "Array Casuale Generato : { ";
    for (int i { 0 }; i < MAX_SIZE; i++)
        std::cout << array[i] << ' ';
    std::cout << "}\n";
}

void controllaValoreArray(int& numero)
{
    // Controllo del numero inserito da parte dell'utente.
    do
    {
        std::cout << "\n\nInserisci un numero (MiN 1, MAX 90): ";
        std::cin >> numero;

        if (numero < 1 || numero > 90)
            std::cerr << "\nIl numero deve essere compreso tra 1 e 90.\n";
    }
    while (numero < 1 || numero > 90);
}

void trovaValoriTramiteSomma(int array[MAX_SIZE], int numero)
{
    // Ricerca e stampa delle coppie di valori nell'array la cui somma è pari al numero inserito dall'utente.
    bool checker { false };
    std::cout << "\nValori Sommati uguali:\n";
    for (int i { 0 }; i < MAX_SIZE; i++)
    {
        for (int j { i + 1 }; j < MAX_SIZE; j++)
        {
            if (array[i] + array[j] == numero)
            {
                checker = true;
                printf_s("%2d + %2d = %2d (posizione: %2d, %2d)\n", array[i], array[j], numero, i, j);
            }
        }
    }
    if (!checker)
        std::cout << "Non sono presenti valori.\n";
}
