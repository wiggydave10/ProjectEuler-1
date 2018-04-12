
function Stepper() {
    var currPrime = { id: 2 };
    var currIdx = -1;
    var prevLinkValid = true;

    this.step = function (nodes, links) {
        if (!prevLinkValid) {
            links.pop();
            prevLinkValid = true;
        }

        if (currIdx < 0) {
            nodes.push(currPrime);
            currIdx = 0;

        } else if (currIdx >= nodes.length - 1) {
            currPrime = { id: nextPrime(currPrime.id) };
            currIdx = -1;
            return true;

        } else {
            prevLinkValid = addLink(currPrime, nodes[currIdx], links);
            currIdx++;
        }
    };
}

function addLink(p1, p2, links) {
    var p1Str = p1.id.toString();
    var p2Str = p2.id.toString();
    var valid = isPrime(parseInt(p1Str + p2Str)) && isPrime(parseInt(p2Str + p1Str));

    links.push({ source: p1, target: p2, valid: true });

    return valid;
}

function nextPrime(n) {
    while (!isPrime(++n)) {
    }

    return n;
}

function isPrime(n) {
    for (var i = 2; i <= Math.sqrt(n); i++) {
        if (n % i === 0) return false;
    }

    return true;
}