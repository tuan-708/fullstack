package com.learn.APISpringDemo.repository;

import com.learn.APISpringDemo.model.Author;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AuthorRepository extends JpaRepository<Author, Integer> {

}
