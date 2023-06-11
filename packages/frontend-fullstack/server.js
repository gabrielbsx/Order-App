//Dotenv
require("dotenv/config")

//Mocks
const content = require("./mocks.js")

//App
const express = require("express")
const app = express()
const path = require('path')
const axios = require('axios');
app.use(express.json())
app.use("/public", express.static('public'))
app.use(express.urlencoded({ extended: true }));

//Mustache
const mustacheExpress = require("mustache-express")
app.engine("mustache", mustacheExpress())
app.set("views", path.join(__dirname, "src/views"))
app.set("view engine", "mustache")

//Rotas
app.get("/", async (req, res) => {
    const data = await getItemsListFromGabriel();
    console.log(data);
    const renderContent = { data: data };
    return res.render("page", renderContent);
});

//Erro 404 - Página não encontrada
app.use(function (req, res, next) {
    const renderContent = { ...content, render404: true }
    return res.render(content.app.defaultPage, renderContent)
});

//Bora servir :P
app.listen(process.env.PORT || 3000)
console.log(`\nPorta: ${process.env.PORT || 3000}\n`)
