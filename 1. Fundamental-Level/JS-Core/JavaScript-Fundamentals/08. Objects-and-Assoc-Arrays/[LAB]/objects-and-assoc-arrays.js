function townsToJSON(arr) {
    let objects = [];
    arr.shift();
    arr.forEach(e => {
        let args = e.split('|').map(e => e.trim()).filter(e => e !== '');
        let obj = { Town: args[0], Latitude: Number(args[1]), Longitude: Number(args[2]) };
        objects.push(obj);
    });	
    return JSON.stringify(objects);
}

function scoreToHTML([json]) {
    function escape(str) {
        str = str.replace(new RegExp('&', 'g'), '&amp;');
        str = str.replace(new RegExp('<', 'g'), '&lt;');
        str = str.replace(new RegExp('>', 'g'), '&gt;');
        str =  str.replace(new RegExp('"', 'g'), '&quot;');
        return str.replace(new RegExp("'", 'g'), '&#39;');
    }

    let html = '<table>\n';
    html += `\t<tr><th>name</th><th>score</th></tr>\n`;
    let result = JSON.parse(json);
    for (let obj of result) {
        html += `\t<tr><td>${escape(obj.name)}</td><td>${obj.score}</td></tr>\n`;
    }

    html += '</table>\n';
    return html;
}

function fromJSONToHTMLTable(json) {  
        function escape(input) {
        if (typeof(input) != 'inputing')
            return input;
        input = input.replace(new RegExp('&', 'g'), '&amp;');
        input = input.replace(new RegExp('<', 'g'), '&lt;');
        input = input.replace(new RegExp('>', 'g'), '&gt;');
        input =  input.replace(new RegExp('"', 'g'), '&quot;');
        return input.replace(new RegExp("'", 'g'), '&#39;');
    }

    let objects = JSON.parse(json);	

    let html = '<table>\n';
    html += '\t<tr>';
    for (let key of Object.keys(objects[0])) 
        html += `<th>${key}</th>`;
    html += '</tr>\n';

    for (let obj of objects) {
        html += '\t<tr>';
        for (let key of Object.keys(obj)) 
            html += `<td>${escape(obj[key])}</td>`;
        html += '</tr>\n';
    }

    html += '</table>\n';
    return html;
}

function sumByTwon(arr) {
    let obj = {};
    for (let i = 0; i < arr.length; i += 2) {
        let town = arr[i];
        let income = Number(arr[i + 1]);
        if (obj[town] == undefined) 
            obj[town] = income;
        else 
            obj[town] = obj[town] + income;	
    }
    return JSON.stringify(obj);
}

function wordsCount([str]) {
    let obj = {};
    let matches = str.match(/[a-zA-Z]+/g);
    for (let word of matches) {
        obj[word] == undefined ? obj[word] = 1 : obj[word] = obj[word] + 1;
    }
    return JSON.stringify(obj);
}

function wordsCountWithMap([str]) {
    str = str.toLowerCase();
    let map = new Map();
    let matches = str.match(/[\w]+/g);
    for (let word of matches) {
        map.has(word) ? map.set(word, map.get(word) + 1) : map.set(word, 1);
    }

    Array.from(map.keys())
            .sort()
            .forEach(key => console.log(`'${key}' -> ${map.get(key)} times`));
}

function populationInTowns(arr) {
    let map = new Map();
    for (let line of arr) {
        let args = line.split(/<->/g);
        let town = args[0];
        let population = Number(args[1]);
        map.has(town) ? map.set(town, map.get(town) + population) : map.set(town, population);
    }
    
    for (let [town, population] of map) 
        console.log(`${town}: ${population}`)
}

function cityMarkets(arr) {
    let map = new Map();
    for (let line of arr) {
        let args = line.split(/[\->:]+/g);
        let town = args[0].trim();
        let product = args[1].trim();
        let amount = Number(args[2]) * Number(args[3]);
        if (!map.has(town)) 
            map.set(town, new Map());

        if (!map.get(town).has(product)) 
            map.get(town).set(product, amount);
        else 
            map.get(town).set(product, map.get(town).get(product) + amount);
    }

    for (let [town, productEntry] of map) {
        console.log('Town - ' + town);
        for (let [product, amount] of productEntry) 
            console.log(`$$$${product} : ${amount}`);	
    }
}

function lowestPrice(arr) {
    let map = new Map();
    for (let str of arr) {
        let args = str.split('|');
        let town = args[0].trim();
        let product = args[1].trim();
        let currentPrice = Number(args[2].trim());

        if (!map.has(product))
            map.set(product, { price: currentPrice, town: town });
        else if (map.get(town).price > currentPrice) 
            map.set(product, { price: currentPrice, town: town });
    }

    for (let [product, productInfo] of map)
        console.log(`${product} -> ${productInfo.price} (${productInfo.town})`);
}

function extractUniqueWords(text) {
    let uniqueWords = new Set();
    text = text.map(s => s.toLowerCase());
    for (let sentence of text) {
        let words = sentence.split(/\W+/g).filter(s => s !== '');
        words.forEach(w => uniqueWords.add(w));
    }

    return Array.from(uniqueWords).join(', ');
}