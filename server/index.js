var express = require('express');
var app = express();

var users = {'admin': '12345678'};

app.post('/', function (req, res) {
  console.log("login info: ", req.headers.username, req.headers.password);
  if (users[req.headers.username] == undefined) {
    res.send('no user');
    console.log("no user");
  } else {
    if (users[req.headers.username] == req.headers.password) {
      res.send('success');
      console.log("success");
    } else {
      res.send('wrong password');
      console.log("wrong password");
    }
  }
});

app.post('/register', function(req, res) {
  console.log("register info: ", req.headers.username, req.headers.password);
  if (users[req.headers.username] != undefined) {
    res.send('already exists');
    console.log("already exists");
  } else {
    users[req.headers.username] = req.headers.password;
    res.send('success');
    console.log(users);
  }
});

app.get('*', function (req, res) {
  res.send('非法访问!');
});

app.post('*', function (req, res) {
  res.send('非法访问!');
});

var server = app.listen(3000, function () {
  var host = server.address().address;
  var port = server.address().port;

  console.log('Example app listening at ', port);
});