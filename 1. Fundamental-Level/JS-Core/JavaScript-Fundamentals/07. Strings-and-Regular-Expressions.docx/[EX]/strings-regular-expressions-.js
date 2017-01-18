function splitByDelimiter([str, delimiter]) {
    str.split(delimiter).forEach(s => console.log(s));
}

function repeatStr([str, count]) {
    return str.repeat(count);
}

function startsWith([str, subStr]) {
    return str.startsWith(subStr);
}   

function endsWith([str, subStr]) {
    return str.endsWith(subStr);
}    

function capitalize([str]) {
    return str.toLowerCase().replace(/([a-z])([a-z]*)/g, 
        (word, firstLetter, remainingWord) => firstLetter.toUpperCase() + remainingWord);
}

function captureNums(arr) {
    let nums = [];
    for (let str of arr) {
        let matches = str.match(/[0-9]+/g);
        if (matches != null) 
            matches.forEach(n => nums.push(n));
    }
    return nums.join(' ');
}

function findVariables([str]) {
    let variables = [];
    let regex = new RegExp(/\b_([a-zA-Z0-9]+)\b/g);
    let variable = regex.exec(str);
    while (variable != null && c < 20) {
        variables.push(variable[1]);
        variable = regex.exec(str);
    }
    return variables.join(',');
}

function findVariables([text, targetWord]) {
    [text, targetWord] = [text, targetWord].map(s => s.toLowerCase());
    let occurrences = 0;
    let regex = new RegExp(`\\b${targetWord}\\b`, 'g');
    let match = regex.exec(text);
    while (match != null) {
        occurrences++;
        match = regex.exec(text);
    }
    return occurrences;
}

function extractLinks(arr) {
    for (let str of arr) {
        let matches = str.match(/www\.([a-zA-Z0-9\-]+)(\.[a-z]+)+/g);
        if (matches != null)
            matches.forEach(l => console.log(l));
    }
}