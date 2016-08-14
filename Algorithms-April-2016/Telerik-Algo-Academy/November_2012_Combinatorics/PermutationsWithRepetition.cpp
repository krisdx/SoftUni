#include <iostream>

using namespace std;

int n = 3;
const int k = 3;

int arr[k];

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
        arr[index] = number;
        generatePermutations(index + 1);
    }
}

int main()
{
    generatePermutations();
    return 0;
}
