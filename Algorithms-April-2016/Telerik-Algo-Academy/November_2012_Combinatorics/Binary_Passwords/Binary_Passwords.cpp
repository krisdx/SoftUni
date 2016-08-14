#include <iostream>
#include <string>

using namespace std;

long long getResult(int n)
{
    long long result = 1;
    for(int i = 0; i < n; i++)
    {
        result *= 2;
    }

    return result;
}

int getStarsCount(string str)
{
    int startCount = 0;
    for(int i = 0; i < str.size(); i++)
    {
        if  (str[i] == '*')
        {
            startCount++;
        }
    }

    return startCount;
}

int main()
{
    string input;
    cin >> input;

    int startCount = getStarsCount(input);
    long long result = getResult(startCount);

    cout << result;

    return 0;
}
