package com.financail.moneymanagement.model;

public class Coin {
    private String name;
    private float quantity;
    private String date;
    private float price;
    private float percent;

    public Coin(){

    }

    public Coin(String name, float quantity, String date, float price, float percent) {
        this.name = name;
        this.quantity = quantity;
        this.date = date;
        this.price = price;
        this.percent = percent;

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public float getQuantity() {
        return quantity;
    }

    public void setQuantity(float quantity) {
        this.quantity = quantity;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public float getPrice() {
        return price;
    }

    public void setPrice(float price) {
        this.price = price;
    }

    public float getPercent() {
        return percent;
    }

    public void setPercent(float percent) {
        this.percent = percent;
    }
}
