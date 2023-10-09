package com.learn.APISpringDemo.controller;

import com.learn.APISpringDemo.model.Author;
import com.learn.APISpringDemo.model.ResponeObject;
import com.learn.APISpringDemo.service.AuthorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
public class AuthorController {

    @Autowired
    private AuthorService authorService;

    @GetMapping(path = "/api/v1/authors")
    public ResponseEntity<ResponeObject> getAllAuthor(){
        List<Author> authors = this.authorService.getAllAuthor();;
        if(!authors.isEmpty()){
            return  ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query successfully", authors.size(), authors)
            );
        }
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(
                new ResponeObject("false", "Don't have authors", 0, "")
        );

    }

    @GetMapping(path = "/api/v1/authors/{authorId}")
    public ResponseEntity<ResponeObject> getAuthorById(@PathVariable("authorId") int id){
        try{
            Optional<Author> author = this.authorService.getAuthorById(id);
            return ResponseEntity.status(HttpStatus.OK).body(
              new ResponeObject("ok", "Query successfully", 1, author)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.NOT_ACCEPTABLE).body(
              new ResponeObject("false", ex.getMessage(), 0 ,"")
            );
        }
    }

    @PostMapping(path = "/api/v1/authors")
    public ResponseEntity<ResponeObject> createAuthor(@RequestBody Author author){
        try{
            Author au = this.authorService.createAuthor(author);
            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query successfully", 1, au)
            );
        }catch (Exception ex){
            return  ResponseEntity.status(HttpStatus.NOT_ACCEPTABLE).body(
                    new ResponeObject("false", ex.getMessage(), 0, "")
            );
        }
    }


    @PutMapping(path = "/api/v1/authors/{authorId}")
    public ResponseEntity<ResponeObject> updateAuthor(@RequestBody Author author, @PathVariable("authorId") int id){
        try{
            Author au = this.authorService.updateAuthor(author, id);
            return ResponseEntity.status(HttpStatus.OK).body(
              new ResponeObject("ok", "Query succesfully",1,au)
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.NOT_ACCEPTABLE).body(
                new ResponeObject("false", ex.getMessage(), 0, "")
            );
        }
    }

    @DeleteMapping(path = "/api/v1/authors/{authorId}")
    public ResponseEntity<ResponeObject> deleteAuthorById(@PathVariable("authorId") int id){
        try{
            this.authorService.deleteAuthorbyId(id);
            return ResponseEntity.status(HttpStatus.OK).body(
                    new ResponeObject("ok", "Query succesfully",1,"")
            );
        }catch (Exception ex){
            return ResponseEntity.status(HttpStatus.NOT_ACCEPTABLE).body(
                    new ResponeObject("false", ex.getMessage(), 0, "")
            );
        }
    }
}
