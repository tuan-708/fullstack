package com.learn.APISpringDemo.service;

import com.learn.APISpringDemo.model.Author;
import com.learn.APISpringDemo.repository.AuthorRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class AuthorService {

    @Autowired
    private AuthorRepository authorRepository;

    public List<Author> getAllAuthor(){
        List<Author> authors = this.authorRepository.findAll();
        return authors;
    }

    public Optional<Author> getAuthorById(Integer id){
        Optional<Author> author = Optional.ofNullable(this.authorRepository.findById(id).orElseThrow(() ->
                new RuntimeException("Can't find author with id " + id)
        ));
        return author;
    }

    public Author createAuthor(Author author){

        return this.authorRepository.save(author);
    }

    public Author updateAuthor(Author author, int id){
        Optional<Author> au = Optional.ofNullable(this.authorRepository.findById(id).orElseThrow(() -> new RuntimeException("Author id " + id + " already existed.")));
        if(au.isPresent()){
            author.setId(id);
            this.authorRepository.save(author);
            return  author;
        }
        return null;
    }

    public void deleteAuthorbyId(int id){
        Optional<Author> au = Optional.ofNullable(this.authorRepository.findById(id).orElseThrow(() -> new RuntimeException("Author id " + id + " already existed.")));
        if(au.isPresent()){
            this.authorRepository.deleteById(id);
        }
    }
}
