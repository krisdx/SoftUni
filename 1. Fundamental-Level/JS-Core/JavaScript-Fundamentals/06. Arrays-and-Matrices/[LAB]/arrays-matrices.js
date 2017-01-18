function sumFirstLast(arr) {	
    return Number(arr[0]) + Number(arr[arr.length - 1]);
}

function evenPositionElement(arr) {	
    return arr.filter((num, index) => index % 2 === 0).join(' ');
}

function negativePositiveNums(arr) {	
    let newArr = [];
    arr.forEach(x => (x < 0) ? newArr.unshift(x) : newArr.push(x));
    newArr.forEach(x => console.log(x));
}

function firstAndLastNums(arr) {	
    let k = Number(arr[0]);
    console.log(arr.slice(1, k + 1).join(' '));
    console.log(arr.slice(-k).join(' '));
}

function firstAndLastNums([n, k]) {	
    function sum(arr) {
        let sum = 0;
        for (let num of arr)
            sum += num;
        return sum;
    }

    let sequence = [1];
    for (let i = 1; i < n; i++) {
        let start = Math.max(0, i - k);
        let end = start + k;
        let currentSum = sum(sequence.slice(start, end));
        sequence.push(currentSum);
    }
    return sequence;
}

function processOddNumbers(arr) {	
  return arr.filter((num, index) => index % 2 === 1)
    .map(x => x * 2)
    .reverse()
    .join(' ');
}

function processOddNumbers(matrix) {
    let rowMaxes = [];
    for (let i = 0; i < matrix.length; i++) {
        let rowMax = matrix[i]
                        .split(' ')
                        .map(Number)
                        .reduce((a,b) => Math.max(a,b));  
        rowMaxes.push(rowMax);
    }

    return rowMaxes.reduce((a,b) => Math.max(a,b));	
}

function diagonalSums(matrix) {
    matrix = matrix.map(r => r.split(' ').map(Number));
    let leftToRightDiagonal = 0, rightToLeftDiagonal = 0;
    for	(let row = 0; row < matrix.length; row++) {
        leftToRightDiagonal += matrix[row][row];
        rightToLeftDiagonal += matrix[row][matrix.length - row - 1];
    }

    console.log(leftToRightDiagonal + ' ' + rightToLeftDiagonal);
}

function equalNeighbors(matrix) {
    matrix = matrix.map(r => r.split(' '));

    let neighbors = 0;
    for (let row = 0; row < matrix.length - 1; row++) {
        for (let col = 0; col < matrix[row].length - 1; col++){
            if (matrix[row][col] === matrix[row + 1][col])
                neighbors++;
            if (matrix[row][col] === matrix[row][col + 1])
                neighbors++;
        }
    }

    for (let row = 0; row < matrix.length - 1; row++) {
        let col = matrix[row].length - 1;
        if (matrix[row][col] === matrix[row + 1][col])
                neighbors++;
    }

    let row = matrix.length - 1;
    for (let col = 0; col < matrix[row].length - 1; col++) {
        if (matrix[row][col] === matrix[row][col + 1])
                neighbors++;
    } 

    return neighbors;
}