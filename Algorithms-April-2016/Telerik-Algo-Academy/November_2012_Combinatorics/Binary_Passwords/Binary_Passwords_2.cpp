#include <iostream>

using namespace std;

int getStarsCount(string str)
{
    int starsCount = 0;
    for(int i = 0; i < str.size(); i++)
    {
        if  (str[i] == '*')
        {
            starsCount++;
        }
    }

    return starsCount;
}

long long getCombinationsCount(int n)
{
    long long combinationsCount = 1;
    for(int i = 0; i < n; i++)
    {
        combinationsCount <<= 1;
    }

    return combinationsCount;
}

int main()
{
    string input;
    cin >> input;

    int startCount = getStarsCount(input);
    long long combinationsCount = getCombinationsCount(startCount);

    cout << combinationsCount;

    return 0;
}
