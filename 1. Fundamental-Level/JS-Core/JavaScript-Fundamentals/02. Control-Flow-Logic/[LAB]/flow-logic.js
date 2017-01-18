function multipyNumbers([firstNum, secondNum]) {
    let result = firstNum * secondNum;
    return result;
}

function boxesAndBottles([bottlesCount, boxCapacity]) {
    let boxesCount = Math.ceil(bottlesCount / boxCapacity);
    return boxesCount;
}

function isLeapYear([year]) {
    let isLeap = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    return isLeap ? 'yes' : 'no';
}

function circleArea([radius]) {
    let circleArea = Math.PI * (radius * radius);
    console.log(circleArea);
    console.log(circleArea.toFixed(2));
}

function triangleArea([a, b, c]) {
    [a, b, c] = [a, b, c].map(Number);
    let p = (a + b + c) / 2;
    let triangleArea = Math.sqrt(p * ((p - a) * (p - b) * (p - c)));
    return triangleArea;
}

function cone([radius, height]) {
    [radius, height] = [radius, height].map(Number);

    let volume = (Math.PI * radius * radius * height) / 3;
    let slant = Math.sqrt(Math.pow(radius, 2) + Math.pow(height, 2));
    let area = Math.PI * radius * (radius + slant);
    console.log(volume);
    console.log(area);
}

function oddEven(arr) {
    let num = Number(arr[0]);
    if (Math.round(num) !== num) {
        console.log('invalid');
        return;
    }

    if (num % 2 === 0) 
        console.log('even');
    else if (num % 2 === 1)
        console.log('odd')
}

function fruitOrVegetable([str]) {
    switch (str) {
        case 'banana':
        case 'apple':
        case 'kiwi':
        case 'cherry':
        case 'lemon':
        case 'grapes':
        case 'peach':
            console.log('fruit');
            break;
        case 'tomato':
        case 'cucumber':
        case 'pepper':
        case 'onion':
        case 'garlic':
        case 'parsley':
            console.log('vegetable');
            break;  
        default: 
            console.log('unknown');
    }
}

function colorfulNumbers([n]) {
    console.log('<ul>');
    for (let i = 1; i <= n; i++) {
        let color = ((i - 1) % 2 === 0) ? 'green' : 'blue';
        console.log(`    <li><span style="color:${color}">${i}</span></li>`);
    }
    console.log('</ul>');
}

function chessboard([n]) {
    let chessboard = '';
    chessboard += '<div class="chessboard">\n';
    for (let i = 0; i < n; i++) {
        chessboard += '\t<div>\n'
        for (let j = 0; j < n; j++) {
        let isBlack = (i %  2 === 0 && j % 2 === 0) || (i % 2 === 1 && j % 2 === 1);
        let color = isBlack ? 'black' : 'white';
            chessboard += `\t\t<span class="${color}"></span>\n`;
        }
        chessboard += '\t</div>\n'
    }
    chessboard += '</div>\n';

    return chessboard;
}

function binaryLogarithm(arr) {
    for (let i = 0; i < arr.length; i++) {
        let log2Base = Math.log2(Number(arr[i]));
        console.log(log2Base);
    }
}

function isPrime([num]) {
    for (let i = 2; i < Math.sqrt(num); i++) {
        if (num % i === 0) {
            return false;
        }
    }

    return true && (num > 1);
}