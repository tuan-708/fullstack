package com.learn.APISpringDemo.model;

import com.fasterxml.jackson.annotation.JsonBackReference;
import jakarta.persistence.*;

import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "author", schema = "springboot_demo")
public class Author {
    @Id
    @GeneratedValue (strategy = GenerationType.IDENTITY)
    @Column(name = "author_id", nullable = false)
    private int id;

    @Column(name = "author_name", length = 45)
    private String authorName;

    @Column(name = "author_address", length = 45)
    private String authorAddress;

    @Column(name = "author_phone", length = 45)
    private String authorPhone;

    public Author(){}

    public Author(String authorName, String authorAddress, String authorPhone) {
        this.authorName = authorName;
        this.authorAddress = authorAddress;
        this.authorPhone = authorPhone;
    }

    @OneToMany(cascade = CascadeType.ALL, mappedBy = "author")
    @JsonBackReference
    private Set<Book> books = new LinkedHashSet<>();

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getAuthorName() {
        return authorName;
    }

    public void setAuthorName(String authorName) {
        this.authorName = authorName;
    }

    public String getAuthorAddress() {
        return authorAddress;
    }

    public void setAuthorAddress(String authorAddress) {
        this.authorAddress = authorAddress;
    }

    public String getAuthorPhone() {
        return authorPhone;
    }

    public void setAuthorPhone(String authorPhone) {
        this.authorPhone = authorPhone;
    }

    public Set<Book> getBooks() {
        return books;
    }

    public void setBooks(Set<Book> books) {
        this.books = books;
    }

}