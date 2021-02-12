var object = { property1: { property2: { property4: { property5: { property6: "Apple"}}} , property3: 'Orange'}};
let p = "property1.property2.property4.property5.property6";
lookup(object, p);

function lookup(obj, path) {
    var paths = splitPath(path);
    var errorMessage = "The path is not correct!";
    if (paths.length == 0) {
        console.log(errorMessage);
        return;
    }
    // incorrect first path part, no need to go further
    if (!obj.hasOwnProperty(paths[0])) {
        console.log(errorMessage);
        return;
    }
    var newObject = obj[paths[0]];
    for (let i = 1; i < paths.length; i++) {
        let temp = paths[i];
        if (!newObject.hasOwnProperty(temp)) {
            console.log(errorMessage);
            return;
        }
        newObject = newObject[temp];
    } 
    console.log("Value of the last property in the path: " + JSON.stringify(newObject));
}

// Assuming that the object path is divided by .(dot) in this example
// but this can be modified to use any other separator
function splitPath(path) {
    var results = [];
    if (!path || path.length === 0 || path.trim().length === 0) {
        return results;
    }
    results = path.trim().split(".");

    for (let i = 0; i < results.length; i++) {
        results[i] = results[i].trim();
        if (results[i] === '' || !alphaNumeric(results[i])) {
            results.splice(i, 1);
            i--;
        }               
    }
    return results;
}

function alphaNumeric(string) {
    var letterOrNumber = /^[0-9a-zA-Z]+$/;
    if(string.match(letterOrNumber)){
        return true;
    }
    return false;
}