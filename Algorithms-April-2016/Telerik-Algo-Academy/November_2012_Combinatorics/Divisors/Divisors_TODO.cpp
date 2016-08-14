#include <iostream>
#include <limits.h>
#include <vector>

using namespace std;

int minDivisorsCount = INT_MAX;
int resultNumber = INT_MIN;

int makeNumber(vector<int> digits)
{
    int number = 0;
    int power = 1;
    for (int i = digits.size() - 1; i >= 0; i--)
    {
        number += digits[i] * power;
        power *= 10;
    }

    return number;
}

int getDivisorsCount(int number)
{
    int divisorsCount = 0;
    for (int i = 1; i <= number; i++)
    {
        if (number % i == 0)
        {
            divisorsCount++;
        }
    }

    return divisorsCount;
}

void checkForResult(vector <int> digits)
{
    int currentNumber = makeNumber(digits);
    int divisorsCount = getDivisorsCount(currentNumber);
    if (divisorsCount < minDivisorsCount)
    {
        minDivisorsCount = divisorsCount;
        resultNumber = currentNumber;
    }
    else if (divisorsCount == minDivisorsCount &&
             currentNumber < resultNumber)
    {
        resultNumber = currentNumber;
    }
}

void generatePermutations(
    vector <int> digits,vector <int> digitsCopy, vector <bool> used, int index = 0)
{
    if (index >= digits.size())
    {
        checkForResult(digitsCopy);
        return;
    }

    for (int i = 0; i < digits.size(); i++)
    {
        if (!used[i])
        {
            digitsCopy[index] = digits[i];
            used[i] = true;
            generatePermutations(digits, digitsCopy, used, index + 1);
            used[i] = false;
        }
    }
}

int main()
{
    int n;
    cin >> n;

    vector <int> digits;
    vector <int> digitsCopy;
    for (int i = 0; i < n; i++)
    {
        int digit;
        cin >> digit;
        digits.push_back(digit);
        digitsCopy.push_back(digit);
    }

    vector <bool> used;
    generatePermutations(digits, digitsCopy, used);

    cout << resultNumber;
    return 0;
}
