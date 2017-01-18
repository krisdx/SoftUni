function main() {
    let result = figureOfSquares(['1']);
    result = figureOfSquares(['2']);
    result = figureOfSquares(['3']);
    result = figureOfSquares(['4']);
    result = figureOfSquares(['5']);
    result = figureOfSquares(['6']);
    // console.log(result);
    // document.body.innerHTML = result;
}

function biggestOf3Numbers([a, b, c]) {
    let tempMax = Math.max(a, b);
    return Math.max(tempMax, c);
}

function pointInRect([x, y, minX, maxX, minY, maxY]) {
    [x, y, minX, maxX, minY, maxY] = [x, y, minX, maxX, minY, maxY].map(Number);
    return (x >= minX && x <= maxX && y >= minY && y <= maxY) ? 'inside' : 'outside';
}

function oddNumbersToN([n]) {
    for (let i = 1; i <= n; i++)
        if (i % 2 === 1) console.log(i);
}

function triangleOfDollars([n]) {
    let triangle = '';
    for (let i = 1; i <= n; i++) 
        triangle += '$'.repeat(i) + '\n';
    return triangle;
}

function moviePrice([movieTitle, dayOfWeek]) {
    movieTitle = movieTitle.toLowerCase();
    dayOfWeek = dayOfWeek.toLowerCase();
    if (movieTitle == 'the godfather'){
        switch (dayOfWeek) {
            case 'monday': return 12;
            case 'tuesday': return 10;
            case 'wednesday': return 15;
            case 'thursday': return 12.50;
            case 'friday': return 15;
            case 'saturday': return 25;
            case 'sunday': return 30;
            default: return 'error';
        }
    } else if (movieTitle == "schindler's list") {
        switch (dayOfWeek) {
            case 'monday':
            case 'tuesday': 
            case 'wednesday':
            case 'thursday':
            case 'friday': return 8.50;
            case 'saturday':
            case 'sunday': return 15;
            default: return 'error';
        }
    } else if (movieTitle == 'casablanca') {
        switch (dayOfWeek) {
            case 'monday':
            case 'tuesday': 
            case 'wednesday':
            case 'thursday':
            case 'friday': return 8;
            case 'saturday':
            case 'sunday': return 10;
            default: return 'error';
        }
    } else if (movieTitle == 'the wizard of oz') {
        switch (dayOfWeek) {
            case 'monday':
            case 'tuesday': 
            case 'wednesday':
            case 'thursday':
            case 'friday': return 10;
            case 'saturday':
            case 'sunday': return 15;
            default: return 'error';
        }
    } 
    return 'error';
}

function quadraticEquation([a, b, c]) {
    let discriminant = (b * b) - (4 * a * c);
    if (discriminant > 0) {
        let x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
        let x2 = (-b - Math.sqrt(discriminant)) / (2 * a);
        console.log(x2);
        console.log(x1);
    } else if (discriminant === 0) {
        let x = -b / (2 * a);
        console.log(x);
    } else if (discriminant < 0) {
        console.log('No');
    }
}

function htmlTable([n]) {
    let htmlTable = '<table border="1">\n';

    htmlTable += '\t<tr>\n';
    htmlTable += '\t\t<th>x</th>\n';
    for (let i = 1; i <= n; i++) {
        htmlTable += `\t\t<th>${i}</th>\n`;
    }
    htmlTable += '\t</tr>\n';

    for (let i = 1; i <= n; i++) {
        htmlTable += '\t<tr>\n'; 
        htmlTable += `\t\t<th>${i}</th>\n`;
        let value = i;
        for (let j = 1; j <= n; j++) {
            htmlTable += `\t\t<td>${value}</td>\n`;
            value += i;
        }
        htmlTable += '\t</tr>\n';
    }

    htmlTable += '</table>'
    return htmlTable;
}

function figureOfSquares([n]) {
    if (n <= 2) {    
        console.log('+++');
        return;
    }

    let dashesCount = ((2 * n - 1) - 3) / 2;
    let dashes = '-'.repeat(dashesCount);
    let border = `+${dashes}+${dashes}+`;
    console.log(border);

    let count = (n % 2 === 0) ? (n - 1 - 3) / 2 : (n - 3) / 2; 
    let spacesCount = dashesCount;
    let spaces = ' '.repeat(spacesCount);
    let content = `|${spaces}|${spaces}|`;
    for (let i = 0; i < count; i++) {
        console.log(content);
    }

    console.log(border);
    for (let i = 0; i < count; i++) {
        console.log(content);
    }

    console.log(border);
}

function calendar([day, month, year]) {
    function addCalendarHeaders() {
        calendar += '\t<tr>\n';
        calendar += '\t\t<th>Sun</th>\r\n';
        calendar += '\t\t<th>Mon</th>\n';
        calendar += '\t\t<th>Tue</th>\n';
        calendar += '\t\t<th>Wed</th>\n';
        calendar += '\t\t<th>Thu</th>\n';
        calendar += '\t\t<th>Fri</th>\n';
        calendar += '\t\t<th>Sat</th>\n';
        calendar += '\t</tr>\n'
    }

    function addDays(year, month, day) {
        function appendDay() {
            if (thisMonthDay == day) 
                calendar += `\t\t<td class="today">${thisMonthDay}</td>\n`;	
            else 
                calendar += `\t\t<td>${thisMonthDay}</td>\n`;
        }	

        let firstDayPosition = new Date(year, month - 1, 1).getDay();
        let lastMonthLastDate = new Date(year, month - 1, 0); 
        let lastMonthDay = lastMonthLastDate.getDate() - firstDayPosition + 1; 
        calendar += '\t<tr>\n';
        for (let i = 0; i < firstDayPosition; i++) {
            calendar += `\t\t<td class="prev-month">${lastMonthDay}</td>\n`;
            lastMonthDay++;
        }

        let thisMonthDay = 1;
        for (let i = firstDayPosition; i < 7; i++) {
            appendDay();
            thisMonthDay++;
        }
        calendar += '\t</tr>\n';

        let daysCount = new Date(year, month, 0).getDate();
        let i = 0;
        while (thisMonthDay <= daysCount) {
            calendar += '\t<tr>\n';
            for (i = 0; i < 7 && thisMonthDay <= daysCount; i++) {
                appendDay();
                thisMonthDay++;
            }

            if (i == 6) 
                calendar += '\t</tr>\n';
        }

        let nextMonthDate = 1;
        for (let j = i; j < 7; j++) {
            calendar += `\t\t<td class="next-month">${nextMonthDate}</td>\n`;
            nextMonthDate++;
        }
        calendar += '\t</tr>\n';
    }

    [day, month, year] = [day, month, year].map(Number);

    // Validation
    if (day < 0 || day > 31) 
        return 'Incorrect day!';
        else if (month < 0 || month > 12) 
        return 'Incorrect month!';			

    let calendar = '<table>\n';
    addCalendarHeaders();
    addDays(year, month, day);
    calendar += '</table>\n';
    return calendar;
}