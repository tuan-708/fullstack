package com.financail.moneymanagement.model;

import android.content.SharedPreferences;
import com.google.gson.Gson;

public class User {
    public String fullName, email, favourite="";

    public User(){

    }

    public User(String fullName, String email){
        this.fullName = fullName;
        this.email = email;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getFavourite() {
        return favourite;
    }

    public void setFavourite(String favourite) {
        this.favourite = favourite;
    }

    public User getUser(SharedPreferences prefs) {
        Gson gson = new Gson();
        String json = prefs.getString("user", null);
        return gson.fromJson(json, User.class);
    }

}
