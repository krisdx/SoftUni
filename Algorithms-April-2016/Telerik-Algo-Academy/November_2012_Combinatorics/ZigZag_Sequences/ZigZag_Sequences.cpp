#include <iostream>

using namespace std;

void putBigger(int index, int last, bool used[], int n, int k);
void putSmaller(int index, int last, bool used[], int n, int k);

int zigzagCount;

void putSmaller(int index, int last, bool used[], int n, int k)
{
    if  (index == k)
    {
        zigzagCount++;
        return;
    }

    for(int i = last - 1; i >= 0; i--)
    {
        if (!used[i])
        {
            used[i] = true;
            putBigger(index + 1, i, used, n, k);
            used[i] = false;
        }
    }
}

void putBigger(int index, int last, bool used[], int n, int k)
{
    if  (index == k)
    {
        zigzagCount++;
        return;
    }

    for(int i = last + 1; i < n; i++)
    {
        if (!used[i])
        {
            used[i] = true;
            putSmaller(index + 1, i, used, n, k);
            used[i] = false;
        }
    }
}

int main()
{
    int n;
    cin >> n;

    int k;
    cin >> k;

    bool used[n];
    for(int i = 0; i < n; i++)
    {
        used[i] = false;
    }

    putBigger(0, -1, used, n, k);
    cout << zigzagCount;

    return 0;
}
