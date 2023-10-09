package com.financail.moneymanagement.view_coin;

import java.util.Comparator;

public class Coin{
    private String name;
    private String price_d;
    private String price_v;
    private String price_24;

    public Coin(String name, String price_d, String price_v, String price_24) {
        this.name = name;
        this.price_d = price_d;
        this.price_v = price_v;
        this.price_24 = price_24;
    }


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPrice_d() {
        return price_d;
    }

    public void setPrice_d(String price_d) {
        this.price_d = price_d;
    }

    public String getPrice_v() {
        return price_v;
    }

    public void setPrice_v(String price_v) {
        this.price_v = price_v;
    }

    public String getPrice_24() {
        return price_24;
    }

    public void setPrice_24(String price_24) {
        this.price_24 = price_24;
    }

}

class SortByPrice implements Comparator<Coin> {
    @Override
    public int compare(Coin o1, Coin o2) {
        float coin_price1 = Float.parseFloat(o1.getPrice_d());
        float coin_price2 = Float.parseFloat(o2.getPrice_d());
        if(coin_price1 < coin_price2){
            return 1;
        }
        else if(coin_price1 > coin_price2){
            return -1;
        }
        else return 0;
    }
}

class SortByPriceIncrease implements Comparator<Coin> {
    @Override
    public int compare(Coin o1, Coin o2) {
        float coin_price1 = Float.parseFloat(o1.getPrice_24());
        float coin_price2 = Float.parseFloat(o2.getPrice_24());
        if(coin_price1 < coin_price2){
            return 1;
        }
        else if(coin_price1 > coin_price2){
            return -1;
        }
        else return 0;
    }
}

class SortByPriceDecrease implements Comparator<Coin> {
    @Override
    public int compare(Coin o1, Coin o2) {
        float coin_price1 = Float.parseFloat(o1.getPrice_24());
        float coin_price2 = Float.parseFloat(o2.getPrice_24());
        if(coin_price1 > coin_price2){
            return 1;
        }
        else if(coin_price1 < coin_price2){
            return -1;
        }
        else return 0;
    }
}
