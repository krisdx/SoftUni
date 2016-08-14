#include <iostream>
#include <math.h>

using namespace std;

const long MAXCOUNT = 1000001;
int cache[MAXCOUNT + 1];

int main()
{
    int askedCount;
    cin >> askedCount;
    for (int i = 0; i < askedCount; i++)
    {
        int rabbitsCount;
        cin >> rabbitsCount;
        cache[rabbitsCount + 1]++;
    }

    long long result = 0;
    for (int i = 0; i <= MAXCOUNT; i++)
    {
        if  (cache[i] > 0)
        {
            result += ceil((double)cache[i] / i) * i;
        }
    }

    cout << result;
    return 0;
}
