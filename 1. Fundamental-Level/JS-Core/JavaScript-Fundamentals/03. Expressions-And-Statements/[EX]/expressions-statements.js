function helloJs([str]) {
    return `Hello, ${str}, I am JavaScript!`;
}

function areaAndPerimeter([a, b]) {
    [a, b] = [a, b].map(Number);
    console.log(a * b);
    console.log((a + b) * 2);
}

function distanceOverTime([v1, v2, t]) {
    [v1, v2, t] = [v1, v2, t].map(Number);
    let d1 = v1 * (t / 60 / 60);
    let d2 = v2 * (t / 60 / 60);
    return Math.abs(d1 - d2) * 1000;
}

function distanceBetweenPoints (arr) {
  let pointA = { x: Number(arr[0]), y: Number(arr[1]), z: Number(arr[2]) };
  let pointB = { x: Number(arr[3]), y: Number(arr[4]), z: Number(arr[5]) };

  let distance = Math.sqrt(
          Math.pow(pointB.x - pointA.x, 2) +
          Math.pow(pointB.y - pointA.y, 2) +
          Math.pow(pointB.z - pointA.z, 2));
  console.log(distance);
}

function gradToDegree(arr) {
    let grads = Number(arr[0]);
    grads %= 400;
    grads += 400;
    grads %= 400;
    let degrees = grads * 0.9;
    console.log(degrees);
}

function compoundInterest([capital, interestRate, frequencyTake, period]) {
    [capital, interestRate, frequencyTake, period] = 
        [capital, interestRate, frequencyTake, period].map(Number);
    interestRate /= 100;
    frequencyTake = 12 / frequencyTake;

    let total = 
        capital * Math.pow(1 + interestRate / frequencyTake, frequencyTake * period);
    return total.toFixed(2);
}

function rounding([num, precision]) {
    num = Number(num);
    precision = (precision > 15) ? 15 : Number(precision);
    return Number(num.toFixed(precision));
}

function convertToFootsAndInches(arr) {
  let num = Number(arr[0]);
  let foots = Math.floor(num / 12);
  let inches = num % 12;
  let result = '' + foots + '\'-' + inches + '"';
  return result;
}

function nowPlaying([title, artist, duration]) {
  return `Now Playing: ${artist} - ${title} [${duration}]`;
}

function composeTag([fileLocation, alternateText]) {
    return `<img src="${fileLocation}" alt="${alternateText}">`;
}

function assignProperties(arr) {
    return { [arr[0]]: arr[1], [arr[2]]: arr[3], [arr[4]]: arr[5] };
}

function lastMonth([date, month, year]) {
    return new Date(year, month - 1, 0).getDate();
}