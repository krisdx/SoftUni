function heroicInventory(input) {
    let objects = [];
    for (let line of input) {
        let args = line.split(/\W+/g).filter(s => s !== '');
        let obj = { name: args[0], level: Number(args[1]), items: [] };
        for (let i = 2; i < args.length; i++)
            obj.items.push(args[i]);
        objects.push(obj);
    }
    return JSON.stringify(objects);
}

function JSONTable(json) {
    let html = '<table>\n'
    for (let element of json) {
        html += '\t<tr>\n';
        let obj = JSON.parse(element);
        html += `\t\t<td>${obj.name}</td>\n`;
        html += `\t\t<td>${obj.position}</td>\n`;
        html += `\t\t<td>${obj.salary}</td>\n`;
        html += '\t</tr>\n';
    } 

    html += '</table>\n';
    return html;
}

function cappyJuice(input) {
    let totalJuice = new Map();
    let totalBottles = new Map();

    for (let line of input) {
        let args = line.split(/\W+/g).filter(s => s !== '');
        let [type, quantity] = [args[0].trim(), Number(args[1].trim())];
        if (!totalJuice.has(type)) 
            totalJuice.set(type, 0);

        let currentQuantity = totalJuice.get(type);
        currentQuantity += quantity;

        if (currentQuantity >= 1000) {
            let juiceLeft = currentQuantity % 1000;
            let bottlesToStore = (currentQuantity - juiceLeft) / 1000;

            if (!totalBottles.has(type)) 
                totalBottles.set(type, 0);

            totalBottles.set(type, totalBottles.get(type) + bottlesToStore);
            quantity = juiceLeft;
        }

        totalJuice.set(type, totalJuice.get(type) + quantity);
    }

    for (let [juice, bottles] of totalBottles) 
        console.log(`${juice} => ${bottles}`);
}

function storeCatalogue(arr) {
    let map = new Map();
    for (let line of arr) {
        let args = line.split(/:/g).filter(s => s !== '');
        let [product, price] = [args[0].trim(), Number(args[1].trim())];
        if (!map.has(product[0])) 
            map.set(product[0], []);
        map.get(product[0]).push({ name: product, price: price });
    }

    Array.from(map.keys())
         .sort()
         .forEach(l => {
            console.log(l);
            map.get(l).sort((o1, o2) => o1.name > o2.name)
                        .forEach(p => console.log(`  ${p.name}: ${p.price}`));
         });
}

function engineerCompany(arr) {
    let map = new Map();
    for (let line of arr) {
        let args = line.split(/\|/g).filter(s => s !== '');
        let [brand, model, carsCount] = [args[0].trim(), args[1].trim(), Number(args[2].trim())];
        if (!map.has(brand))	
            map.set(brand, new Map());

        if (!map.get(brand).has(model))
            map.get(brand).set(model, carsCount);
        else 
            map.get(brand).set(model, map.get(brand).get(model) + carsCount);
    }

    for (let [brand, info] of map) {
        console.log(brand);
        for (let [model, carsCount] of info)
            console.log(`###${model} -> ${carsCount}`);
    }
}

function systemComonents(arr) {
    function sortCompareFunc(a, b) {
        if (map.get(a).size === map.get(b).size) 
            return a.toLowerCase().localeCompare(b.toLowerCase());
        return (map.get(a).size > map.get(b).size) ? -1 : 1;
    }

    let map = new Map();
    for (let line of arr) {
        let args = line.split(/\|/g).filter(s => s !== '');
        let [system, component, subcomponent] = [args[0].trim(), args[1].trim(), args[2].trim()];
        if (!map.has(system))	
            map.set(system, new Map());
        if (!map.get(system).has(component))
            map.get(system).set(component, []); 
            
        map.get(system).get(component).push(subcomponent);
    }

    [...map.keys()].sort((a,b) => sortCompareFunc(a,b))
                   .forEach(sys => {
                       console.log(sys);
                       [...map.get(sys).keys()]
                           .sort((a,b) => map.get(sys).get(b).length - map.get(sys).get(a).length)
                           .forEach(com => {
                            console.log('|||' + com);
                                for (let subcomponent of map.get(sys).get(com)) 
                                    console.log('||||||' + subcomponent);
                            });
                   });
}

function usernames(arr) {
    let result = new Set();
    arr.forEach(s => result.add(s));
    return [...result.keys()].sort((a,b) => {
                                 if (a.length === b.length) 
                                     return a.toLowerCase().localeCompare(b.toLowerCase());
                                 return a.length - b.length;
                              }).forEach(s => console.log(s));
}

function uniqueSequences(input) {
    let arrays = new Map();
    for (let line of input) {
        let arr = JSON.parse(line).map(Number).sort((a,b) => b - a);
        arrays.set(arr.toString(), arr);
    }

    [...arrays.values()].sort((a,b) => a.length - b.length)
                        .forEach(a => console.log('[' + a.join(', ') + ']'));
}