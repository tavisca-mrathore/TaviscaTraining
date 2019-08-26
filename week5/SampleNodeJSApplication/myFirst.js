let http = require('http');
let url = require('url');
let fs = require('fs');
let date = require('./dateModule');

http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/html' });

    var urlQuery = url.parse(req.url, true).query;
    var txt = urlQuery.year + " " + urlQuery.month + "<br>";
    res.write(txt);

    res.write("The date " + date.myDateTime() + "<br>");

    fs.readFile('static/index.html', function (err, data) {
        if (err) throw err;
        res.write(data);
    });
    res.end();

}).listen(8080);