const express = require("express");
const app = express();

app.set("view engine", "ejs");

app.get("/", (req, res) => {
  res.render("lotto");
});
app.get("/report.html", (req, res) => {
    res.render("lotto");
  });
app.use(express.static("public"));

app.listen(1337);
