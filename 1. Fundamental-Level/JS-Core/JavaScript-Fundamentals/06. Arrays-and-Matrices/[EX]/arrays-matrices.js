function printWithDelimiter(arr) {
    let delimiter = arr[arr.length - 1];
    return arr.slice(0, arr.length - 1).join(delimiter);
}

function printNthElement(arr) {
    let step = Number(arr[arr.length - 1]);
    arr = arr.filter((num, index) => index !== arr.length - 1);
    for (let i = 0; i < arr.length; i += step) 
        console.log(arr[i]);
}	    

function manipulateArr(arr) {
    function add(num) { nums.push(num); };
    function remove(num) { nums.pop(); }

    let num = 1;
    let nums = [];
    for (var action of arr) {
        action == 'add' ? add(num) : remove(num);
        num++;
    }

    if (nums.length <= 0) {
        console.log('Empty');
        return;
    }

    nums.forEach(x => console.log(x));
}

function rotateArr(arr) {
    let count = Number(arr[arr.length - 1]) % (arr.length - 1);
    arr = arr.filter((n, index) => index !== arr.length - 1);
    for (let i = 0; i < count; i++)
        arr.unshift(arr.pop());
    return arr.join(' ');
}

function rotateArr(arr) {
    arr = arr.map(Number);
    
    let max = arr[0];
    arr.filter(function(x) {
        if (x >= max) {
            max = x;
            return true;
        }
        return false;
    }).forEach(x => console.log(x));
}

function sortArr(arr) {
    arr.sort(function(a,b) {
        let lengthCompare = a.length < b.length ? -1 : 1;
        lengthCompare = a.length === b.length ? 0 : lengthCompare;

        if (lengthCompare === 0) 
            return a > b;
            
        return lengthCompare;
    }).forEach(x => console.log(x));
}

function magicMatrix(matrix) {
    matrix = matrix.map(row => row.split(' ').map(Number));

    let sum = Number.NEGATIVE_INFINITY;
    for (let row = 0; row < matrix.length; row++) {
        let currentSum = matrix[row].reduce((a, b) => a + b);
        if (sum == Number.NEGATIVE_INFINITY)
            sum = currentSum;
        if (currentSum != sum) 
            return false;
    }

    let currentSum = 0;
    for (let col = 0; col < matrix.length; col++) {
        for (let row = 0; row < matrix.length; row++) {
            currentSum += matrix[row][col];
        }

        if (currentSum != sum) 
            return false;

        currentSum = 0;
    }				

    return true;
}

// 0/100 in judge
function orbit(input) {
    function bfs() {
        function addNeigbors(cell) {
            for (let row = cell.row - 1; row <= cell.row + 1; row++) {
                for (let col = cell.col - 1; col <= cell.col + 1; col++) {
                    if (matrix[row] != undefined && matrix[row][col] != undefined && matrix[row][col] == 0) {
                        matrix[row][col] = cell.cellValue + 1;
                        queue.push({ row: row, col: col, cellValue: matrix[row][col] });								
                    }
                }
            }
        }

        let queue = [];

        queue.push({ row: startRow, col: startCol, cellValue: matrix[startRow][startCol] });	
        while (queue.length > 0) {
            let currentCell = queue.shift();
            addNeigbors(currentCell);
        }
    }

    let [rows, cols] = [input[0].split(' ')[0], input[0].split(' ')[0]].map(Number);
    let [startRow, startCol] = [input[1].split(' ')[0], input[1].split(' ')[0]].map(Number);

    if (startRow < 0 || startRow > rows || startCol < 0 || startCol > cols)
        return;

    let matrix = [];
    for (let i = 0; i < rows; i++) {
        matrix.push([]);
        for (let j = 0; j < cols; j++) {
            if (i === startRow && j === startCol)
                matrix[i].push(1); 
            else 	
                matrix[i].push(0);
        }
    }

    bfs();		

    for (let row = 0; row < matrix.length; row++) 
        console.log(matrix[row].join(' '));
}