function stars([n]) {
    let stars = '';
    for (let i = 1; i <= n; i++) 
        stars += '*'.repeat(i) + '\n';
    for (let i = n - 1; i >= 0; i--) 
        stars += '*'.repeat(i) + '\n';
    return stars;
}

function rectOfStars([n]) {
    let rect = '';
    for (let i = 1; i <= n; i++) 
        rect += '*' + ' *'.repeat(n - 1) + '\n';
    return rect;
}

function isPalindrome([str]) {
    for (let i = 0; i < str.length / 2; i++) 
        if (str[i] !== str[str.length - i - 1]) return false;
    return true;
}

function dayOfWeek([day]) {
    switch (day.toLowerCase()) {
        case 'monday': return 1;
        case 'tuesday': return 2;
        case 'wednesday': return 3;
        case 'thursday': return 4;
        case 'friday': return 5;
        case 'saturday': return 6;
        case 'sunday': return 7;
        default: return 'error';
    }
}

function functionalCalc([a, b, action]) {
    function calc(a, b, action) {
        return action(a, b);
    }

    let addFunc = function(a, b) { return a + b };
    let subtractFunc = function(a, b) { return a - b };
    let multiplyFunc = function(a, b) { return a * b };
    let divideFunc = function(a, b) { return a / b };

    [a, b] = [a, b].map(Number);
    switch (action) {
        case '+': return calc(a, b, addFunc);
        case '-': return calc(a, b, subtractFunc);
        case '*': return calc(a, b, multiplyFunc);
        case '/': return calc(a, b, divideFunc);
    }
}

function aggregateElements(arr) {
    let sumFunc = function (arr) {
        let sum = 0;
        for (let i = 0; i < arr.length; i++)
            sum += Number(arr[i]);
        return sum;
    }

    let inverseSumFunc = function (arr) {
        let inverseSum = 0;
        for (let i = 0; i < arr.length; i++)
            inverseSum += 1 / arr[i];
        return inverseSum;
    } 

    let concatFunc = function (arr) {
        let str = '';
        for (let i = 0; i < arr.length; i++)
            str += arr[i];
        return str;
    } 

    console.log(sumFunc(arr));
    console.log(inverseSumFunc(arr));
    console.log(concatFunc(arr));
}

function wordsUppercase([str]) {
    let regex = new RegExp('\\W+');
    return str.split(regex)
        .filter(str => str != '')
        .map(str => str.toUpperCase())
        .join(', ');			
}