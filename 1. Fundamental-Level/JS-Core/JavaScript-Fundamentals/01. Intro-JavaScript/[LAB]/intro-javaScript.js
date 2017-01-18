function sum3Numbers(inputArr) {
	let a = Number(inputArr[0]);
	let b = Number(inputArr[1]);
	let c = Number(inputArr[2]);
	
	return a + b + c;
}

function sumAndVat(inputArr) {
	let sum = 0.0;
	for (let i = 0; i < inputArr.length; i++) {
		sum += Number(inputArr[i]);
	}
	console.log('sum = ' + sum);
	
	let vat = sum * 0.20;
	console.log('VAT = ' + vat);
	
	let total = sum * 1.20;
	console.log('total = ' + total);
}

function letterOccurrencesCount(inputArr) {
	let str = inputArr[0];
	let targetLetter = inputArr[1];
	
	let count = 0;
	for (var i = 0; i < str.length; i++) {
		if (str[i] === targetLetter) {
			count++;
		}		
	}
	
	return count;
}

function filterByAge(inputArr) {
	let minAge = Number(inputArr[0]);

	let firstPerson = { name: inputArr[1], age: Number(inputArr[2]) };
	if (firstPerson.age >= minAge) {
		console.log(firstPerson);
	}
	
	let secondPerson = { name: inputArr[3], age: Number(inputArr[4]) };
	if (secondPerson.age >= minAge) {
		console.log(secondPerson);
	}
}

function stringOfNumbers(inputArr) {
	let num = Number(inputArr[0]);

	let str = '';
	for (var i = 1; i <= num; i++) {
		str += i;
	}

	return str;
}

function figureArea(inputArr) {
	let w1 = Number(inputArr[0]);
	let h1 = Number(inputArr[1]);
	let w2 = Number(inputArr[2]);
	let h2 = Number(inputArr[3]);

	let area = ((w1 * h1) + (w2 * h2)) - (Math.min(w1, w2) * Math.min(h1, h2));
	return area;
}

function nextDay (inputArr) {
	let year = Number(inputArr[0]);
	let month = Number(inputArr[1]) - 1;
	let day = Number(inputArr[2]);

 	let date = new Date(year, month, day);
  	let oneDay = 24 * 60 * 60 * 1000; // milliseconds in 1 day
  	let nextDate = new Date(date.getTime() + oneDay);
	 
	return nextDate.getFullYear() + '-' + (nextDate.getMonth() + 1) + '-' + nextDate.getDate();
}

function distanceBetweenPoints(inputArr) {
	let x1 = Number(inputArr[0]);
	let y1 = Number(inputArr[1]);
	let x2 = Number(inputArr[2]);
	let y2 = Number(inputArr[3]);

	let pointA = { x: x1, y: y1 };
	let pointB = { x: x2, y: y2 };

	let xDistance = Math.pow(pointA.x - pointB.x, 2);
	let yDistance = Math.pow(pointA.y - pointB.y, 2);

  	return Math.sqrt(xDistance + yDistance);
}