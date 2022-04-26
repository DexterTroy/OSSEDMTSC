function dynamicTimeWarping (s1, s2) {
    var n = s1.length + 1;
    var m = s2.length + 1;
    var d = new Array(n);
    for (var i = 0; i < n; i++) {
        d[i] = new Array(m);
        for (var j = 0; j < m; j++) {
            d[i][j] = 0;
        }
    }
    for (var i = 0; i < n; i++) {
        d[i][0] = Infinity;
    }
    for (var j = 0; j < m; j++) {
        d[0][j] = Infinity;
    }
    
    d[0][0] = 0;

    for (var i = 1; i < n; i++) {
        for (var j = 1; j < m; j++) {
            d[i][j] = Math.abs(s1[i-1] - s2[j-1]) 
            + Math.min(d[i-1][j], d[i][j-1], d[i-1][j-1]);
        }
    }
    return d[n-1][m-1];
}

a = [0,2,0,1,0,0]

b = [0,0,0.5,2,0,1,0]

// $.get("textFile.txt", function(data) {
//     var items = data.split("\r\n").map(function(el){ return el.split(",");});
// });

testValue = dynamicTimeWarping(a,b)

console.log(testValue)