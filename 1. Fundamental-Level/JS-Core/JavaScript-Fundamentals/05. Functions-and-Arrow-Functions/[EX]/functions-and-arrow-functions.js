function insideVolume(arr) {
    function inVolume(x, y, z) {
        let x1 = 10, x2 = 50;
        let y1 = 20, y2 = 80;
        let z1 = 15, z2 = 50;

        if (x >= x1 && x <= x2) 
            if (y >= y1 && y <= y2)
                if (z >= z1 && z <= z2) 
                    return true;
        return false;
    }

    for (let i = 0; i < arr.length; i += 3) {
        let [x, y, z] = [Number(arr[i]), Number(arr[i + 1]), Number(arr[i + 2])];
        console.log(inVolume(x, y, z) ? 'inside' : 'outside');
    }
}

function roadRadar([currentSpeed, area]) {
    function getSpeedLimit(area) {
        switch (area) {
            case 'motorway': return 130;
            case 'interstate': return 90;
            case 'city': return 50;
            case 'residential': return 20;
        }
    }

    function getMessage(speedDiff) {
        if (speedDiff <= 20)
            return 'speeding';
        else if (speedDiff <= 40) 
            return 'excessive speeding';
        else 
            return 'reckless driving';
    }

    let limit = getSpeedLimit(area);
    if (currentSpeed > limit) 
        console.log(getMessage(currentSpeed - limit));
}

function cooking(arr) {
    function execute(num, action) {
        return action(num);
    }

    function getFuncByName(name) {
        switch (name) {
            case 'chop': return chop;
            case 'dice': return dice;
            case 'spice': return spice;
            case 'bake': return bake;
            case 'fillet': return fillet;
        }
    }

    let chop = function(num) { return num / 2; };
    let dice = function(num) { return Math.sqrt(num); };
    let spice = function(num) { return num + 1; };
    let bake = function(num) { return num * 3; };
    let fillet = function(num) { return num - (num * 0.20); };

    let result = Number(arr[0]);
    for (let i = 1; i < arr.length; i++) {
        result = execute(result, getFuncByName(arr[i]));
        console.log(result);
    }
}

function modifyAvg([num]) {
    function getAvg(str) {
        let sum = 0;
        for (var digit of str) 
            sum += Number(digit);
        return sum / str.length;
    }

    num = num.toString();
    let avg = getAvg(num);
    while (avg <= 5) {
        num += '9';
        avg = getAvg(num);
    }
    return num;
}

function validityChecker([x1, y1, x2, y2]) {
    let distance = function (x1, y1, x2, y2) { 
    	return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2)) 
    }

    let valid = function (num) { return num % 1 === 0 };

    [x1, y1, x2, y2] = [x1, y1, x2, y2].map(Number);
    let pointAToZero = valid(distance(x1, y1, 0, 0)) ? 'valid' : 'invalid';
    let pointBtoZero = valid(distance(x2, y2, 0, 0)) ? 'valid' : 'invalid';
    let PointAToPointB = valid(distance(x1, y1, x2, y2)) ? 'valid' : 'invalid';

    console.log(`{${x1}, ${y1}} to {0, 0} is ${pointAToZero}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${pointBtoZero}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${PointAToPointB}`);
}

function tresureLocator(arr) {
    let location = function (x1, y1) {
        if (x1 >= 8 && x1 <= 9 && y1 >= 0 && y1 <= 1) 
            return 'Tokelau';
        else if (x1 >= 1 && x1 <= 3 && y1 >= 1 && y1 <= 3) 
            return 'Tuvalu';
        else if (x1 >= 5 && x1 <= 7 && y1 >= 3 && y1 <= 6) 	
            return 'Samoa';
        else if (x1 >= 0 && x1 <= 2 && y1 >= 6 && y1 <= 8) 
            return 'Tonga';
        else if (x1 >= 4 && x1 <= 9 && y1 >= 7 && y1 <= 8) 
            return 'Cook';
        else 
            return 'On the bottom of the ocean';
    }

    arr = arr.map(Number);
    for (let i = 0; i < arr.length; i += 2) {
        let x = arr[i];
        let y = arr[i + 1];
        console.log(location(x, y));
    }
}

function tripLength([x1, y1, x2, y2, x3, y3]) {			
    let distance = function (x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    };

    [x1, y1, x2, y2, x3, y3] = [x1, y1, x2, y2, x3, y3].map(Number);	
    let points = [{x: x1, y: y1}, {x: x2, y: y2}, {x: x3, y: y3}];
    
    let str = '';
    let tempDist = 0;
    let shortestDistance = 100000000000000;

    for (let f = 1; f <= 3; f++) {
        for (let s = 1; s <= 3; s++) {
            if (f !== s) {
                tempDist = distance(points[f - 1].x, points[f - 1].y, points[s - 1].x, points[s - 1].y);
                for (let t = 1; t <= 3; t++) {
                    if (f !== s && s !== t && t !== f) {
                        tempDist += distance(points[s - 1].x, points[s - 1].y, points[t - 1].x, points[t - 1].y);
                        let tempStr = `${f}->${s}->${t}: ${tempDist}`;
                        if (tempDist < shortestDistance) {
                            shortestDistance = tempDist;
                            str = tempStr;
                        }
                    }
                }
            }
        }
    }

    console.log(str);
}
