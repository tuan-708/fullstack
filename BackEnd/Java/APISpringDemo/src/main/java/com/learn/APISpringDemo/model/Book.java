package com.learn.APISpringDemo.model;

import com.learn.APISpringDemo.model.Author;
import jakarta.persistence.*;

@Entity
@Table(name = "book", schema = "springboot_demo")
public class Book {
    @Id
    @GeneratedValue (strategy = GenerationType.IDENTITY)
    @Column(name = "book_id",nullable = false)
    private int id;

    @Column(name = "book_name", length = 100)
    private String bookName;

    @Column(name = "book_title", length = 150)
    private String bookTitle;

    @ManyToOne
    @JoinColumn(name = "author")
    private Author author;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getBookName() {
        return bookName;
    }

    public void setBookName(String bookName) {
        this.bookName = bookName;
    }

    public String getBookTitle() {
        return bookTitle;
    }

    public void setBookTitle(String bookTitle) {
        this.bookTitle = bookTitle;
    }

    public Author getAuthor() {
        return author;
    }

    public void setAuthor(Author author) {
        this.author = author;
    }

}