package com.learn.APISpringDemo.model;

public class ResponeObject {
    private String status;
    private String massage;

    private int lenght;

    private Object data;

    public ResponeObject(){};

    public ResponeObject(String status, String massage, int lenght, Object data) {
        this.status = status;
        this.massage = massage;
        this.lenght = lenght;
        this.data = data;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getMassage() {
        return massage;
    }

    public void setMassage(String massage) {
        this.massage = massage;
    }

    public int getLenght() {
        return lenght;
    }

    public void setLenght(int lenght) {
        this.lenght = lenght;
    }

    public Object getData() {
        return data;
    }

    public void setData(Object data) {
        this.data = data;
    }
}
