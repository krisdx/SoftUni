#include <iostream>

using namespace std;

int n = 3;
const int k = 3;

int arr[k];
bool used[k + 1];

void generatePermutations(int index = 0)
{
    if  (index >= k)
    {
        for (int i = 0; i < k; i++)
        {
            cout << arr[i] << " ";
        }

        cout << endl;
        return;
    }

    for(int number = 1; number <= n; number++)
    {
        if  (!used[number])
        {
            arr[index] = number;
            used[number] = true;
            generatePermutations(index + 1);
            used[number] = false;
        }
    }
}

int main()
{
    generatePermutations();
    return 0;
}
