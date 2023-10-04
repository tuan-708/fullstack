"use strict";


var connection = new signalR.HubConnectionBuilder().withUrl("/ProductOrder").build();


connection.on("UpdateUnitInStock", function (pid, unitInStock, UnitsOnOrder) {
    if (document.getElementById("pId").textContent == pid) {
        document.getElementById("UnitInStock").innerHTML = unitInStock;
    }
});


function newWindownLoadedOnClient() {
    connection.send("OrderRealTime");
}

function fulfilled() {
    console.log("Connection to Product Successfully");
    newWindownLoadedOnClient();
}

function rejected() {

} 

connection.start().then(fulfilled,rejected);