function printLetters([str]) {
    for (let index in str) 
        console.log(`str[${index}] -> ${str[index]}`);
}

function concatReversed(arr) {
    let str = arr.join('');
    return Array.from(str).reverse().join('');
}

function concatReversed(arr) {
    let [target, text] = [arr[0], arr[1]];

    let count = 0;
    let index = text.indexOf(target);
    while(index > -1) {
        count++;
        index = text.indexOf(target, index + 1);
    }
    return count;
}

function extractText([str]) {
    let result = [];
    let openIndex = str.indexOf('(');
    let closeIndex = str.indexOf(')', openIndex + 1);
    while (openIndex !== -1 && closeIndex !== -1) {
        result.push(str.slice(openIndex + 1, closeIndex));
        openIndex = str.indexOf('(', openIndex + 1);
        closeIndex = str.indexOf(')', openIndex + 1);
    }
    return result.join(', ');
}

function aggregateTable(arr) {
    let cities = [];
    let sum = 0;
    for (let pair of arr) {
    let line = pair.split('|').filter(s => s != '');
    cities.push(line[0].trim());
    sum += Number(line[1].trim());
    }
    console.log(cities.join(', '));
    console.log(sum);
}

function restaurantBill(arr) {
    let products = [];
    let sum = 0;
    for (let i = 0; i < arr.length - 1; i += 2) {
        products.push(arr[i]);
        sum += Number(arr[i + 1]);
    }
    return `You purchased ${products.join(', ')} for a total sum of ${sum}`;
}

function usernames(arr) {
    let usernames = [];
    for (let email of arr) {
        let args = email.split('@');
        let username = args[0] + '.';
        let domain = args[1];
        domain.split('.').forEach(s => username += s[0]);
        usernames.push(username);
    }
    return usernames.join(', ');
}

function censorship(arr) {
    let text = arr[0];
    for (let i = 1; i < arr.length; i++) {
        text = text.replace(new RegExp(arr[i], 'g'), '-'.repeat(arr[i].length));
    }
    return text;
}

function htmlEscape(input) {
    let escapeHTML = '<ul>\n';
    for (let str of input) {
        str = str.replace(new RegExp('&', 'g'), '&amp;');
        str = str.replace(new RegExp('<', 'g'), '&lt;');
        str = str.replace(new RegExp('>', 'g'), '&gt;');
        str = str.replace(new RegExp('"', 'g'), '&quot;');
        escapeHTML += `\t<li>${str}</li>\n`;
    }
    
    escapeHTML += '</ul>\n';
    return escapeHTML;
}

function matchAllWords([str]) {
    return str.match(/\w+/g).join('|');
}

function emailValidation([email]) {
    return (email.match(/^[a-zA-Z0-9]+@[a-z]+\.[a-z]+$/)) == null ? 'Invalid' : 'Valid';
}

function expressionSplit([expression]) {
    expression.split(/[\s.();,]+/).forEach(s => console.log(s));
}

function matchDates(arr) {
    let date = [];
    for (let str of arr) {
        let regex = new RegExp(/\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/g);
        while (date = regex.exec(str)) {
            console.log(`${date[0]} (Day: ${date[1]}, Month: ${date[2]}, Year: ${date[3]})`);
        }
    }
}

function matchDates(arr) {
    let employee = [];
    for (let line of arr) {
        let regex = new RegExp(/^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9 -]+)$/g);
        while (employee = regex.exec(line)) {
            console.log('Name: ' + employee[1]);
            console.log('Position: ' + employee[3]);
            console.log('Salary: ' + employee[2]);
        }
    }
}

function parseEmployees(arr) {
    let employee = [];
    for (let line of arr) {
        let regex = new RegExp(/^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9 -]+)$/g);
        while (employee = regex.exec(line)) {
            console.log('Name: ' + employee[1]);
            console.log('Position: ' + employee[3]);
            console.log('Salary: ' + employee[2]);
        }
    }
}

function fillForm (data) {
    let [username, email, phone] =
        [data.shift(), data.shift(), data.shift()];
    data.forEach(line => {
        line = line.replace(/<![a-zA-Z]+!>/g, username);
        line = line.replace(/<@[a-zA-Z]+@>/g, email);
        line = line.replace(/<\+[a-zA-Z]+\+>/g, phone);
        console.log(line);
    });
} 

function performMultiplications ([text]) {
    return text = text.replace(/(-?\d+)\s*\*\s*(-?\d+(\.\d+)?)/g,
        (match, num1, num2) => Number(num1) * Number(num2));
}