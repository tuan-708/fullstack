package com.learn.APISpringDemo.repository;

import com.learn.APISpringDemo.model.Book;
import org.springframework.data.jpa.repository.JpaRepository;


public interface BookRepository extends JpaRepository<Book, Integer> {

}
