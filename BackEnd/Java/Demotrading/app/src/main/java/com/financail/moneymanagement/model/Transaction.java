package com.financail.moneymanagement.model;

public class Transaction {
    private String buy;
    private String sell;

    public Transaction(){

    }

    public Transaction(String buy , String sell) {
        this.buy = buy;
        this.sell = sell;
    }

    public String getBuy() {
        return buy;
    }

    public void setBuy(String buy) {
        this.buy = buy;
    }

    public String getSell() {
        return sell;
    }

    public void setSell(String sell) {
        this.sell = sell;
    }

}
